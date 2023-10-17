namespace Chickensoft.GodotNodeInterfacesGenerator;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Godot;
using Microsoft.CodeAnalysis.CSharp;
using Towel;

public static class GodotNodeInterfacesGenerator {
  // public const string GODOT_SHARP_XML_PATH = ".output/net6.0/GodotSharp.xml";
  public const string INTERFACES_PATH = "../Chickensoft.GodotNodeInterfaces/src/interfaces";
  public const string ADAPTERS_PATH = "../Chickensoft.GodotNodeInterfaces/src/adapters";

  public const string SRC_PATH = "../Chickensoft.GodotNodeInterfaces/src";

  public static readonly string CrefTagRegex = new(
    @"(<see cref="")([A-Z]:)([^""]*"" />)"
  );

  private static readonly HashSet<string> _usings = new() { "Godot" };

  private static readonly HashSet<string> _ambiguousGodotTypes = new() {
    "Range", "Environment"
  };

  private record ParameterData(
    string Name,
    string Type,
    string? DefaultValue,
    string? Modifier
  ) {
    public override string ToString() =>
      $"{Modifier}{Type} {Name}{DefaultValue}";
  }

  public static void Main(string[] args) {
    // First, inject an interface all adapters will inherit from.
    File.WriteAllText(
      Path.Join(SRC_PATH, "Adapters.cs"),
      """
      namespace Chickensoft.GodotNodeInterfaces;

      using Godot;

      /// <summary>A Godot objet API adapter.</summary>
      public interface IGodotObjectAdapter : IGodotObject {
        /// <summary>Underlying Godot object this adapter uses.</summary>
        public GodotObject Object { get; }
      }

      /// <summary>A Godot node API adapter.</summary>
      public interface INodeAdapter : IGodotObjectAdapter, INode {
        /// <summary>Underlying Godot node this adapter uses.</summary>
        public new Node Object { get; }
      }
      """
    );

    Console.WriteLine("Generated basic adapters");

    var godotAssembly = typeof(Node).Assembly;

    var typesThatExtendGodotNode = godotAssembly.GetTypes()
      .Where(t => t.IsSubclassOf(typeof(Node)) || t == typeof(Node))
      .Append(typeof(GodotObject));

    // map of types to the code that constructs an adapter of that type.
    var adapterFactoryCases = new List<string>();
    var adapterFactoryCasesByGodotNode = new List<string>();

    foreach (var type in typesThatExtendGodotNode) {
      // Look at each type of Godot node.

      var typeName = TypeName(type);

      _usings.Clear();
      _usings.Add("Godot");

      var mainDocumentation = XmlDocToDocComment(type.GetDocumentation(), 0);

      var interfaceName = $"I{type.Name}";
      var interfaceFilename = $"{interfaceName}.cs";

      var adapterName = $"{type.Name}Adapter";
      var adapterFilename = $"{adapterName}.cs";

      var members = type.GetMembers(
        BindingFlags.DeclaredOnly |
        BindingFlags.Public |
        BindingFlags.Instance
      ).OrderBy(m => m.Name);

      var interfaceMembers = new StringBuilder();
      var adapterMembers = new StringBuilder();

      foreach (var member in members) {
        if (member is MethodInfo methodInfo) {
          // For methods
          if (!methodInfo.IsPublic) { continue; }
          if (methodInfo.IsSpecialName) { continue; }

          var methodDocumentation = XmlDocToDocComment(methodInfo.GetDocumentation() ?? "", 2);
          var methodName = methodInfo.Name;
          var returnType = TypeName(methodInfo.ReturnType);
          var parameters = methodInfo.GetParameters();

          var typeParameters = methodInfo.GetGenericArguments();
          var typeParameterList = string.Join(
            ", ",
            typeParameters.Select(p => $"{p.Name}")
          );

          var typeParameterConstraints = "";
          if (typeParameters.Length > 0) {
            methodName += $"<{typeParameterList}>";

            var genericArgs = methodInfo
              .GetGenericMethodDefinition()
              .GetGenericArguments();

            var hasClassConstraint = false;
            var hasNotNullConstraint = false;
            var hasDefaultConstructorConstraint = false;

            // compute type constraints
            var typeConstraints = genericArgs
              .Select(p => {
                var constraints = p.GetGenericParameterConstraints();
                hasClassConstraint = hasClassConstraint ||
                  p.GenericParameterAttributes.HasFlag(
                    GenericParameterAttributes.ReferenceTypeConstraint
                  );
                hasNotNullConstraint = hasNotNullConstraint ||
                  p.GenericParameterAttributes.HasFlag(
                    GenericParameterAttributes.NotNullableValueTypeConstraint
                  );
                hasDefaultConstructorConstraint = hasDefaultConstructorConstraint ||
                  p.GenericParameterAttributes.HasFlag(
                    GenericParameterAttributes.DefaultConstructorConstraint
                  );
                if (constraints.Length == 0) { return ""; }
                var constraintList = string.Join(
                  ", ",
                  constraints.Select(c => TypeName(c))
                );
                return constraints.Length > 0
                  ? $" where {p.Name} : {constraintList}"
                  : "";
              });

            typeParameterConstraints = string.Join("\n", typeConstraints);

            if (hasClassConstraint) {
              typeParameterConstraints =
                " where T : class" + typeParameterConstraints;
            }
            if (hasNotNullConstraint) {
              typeParameterConstraints =
                " where T : struct " + typeParameterConstraints;
            }
            if (hasDefaultConstructorConstraint) {
              typeParameterConstraints =
                " where T : new() " + typeParameterConstraints;
            }
          }

          // we need to compute parameter types, names, modifiers, and default values

          var parametersData = parameters.Select(parameter => {
            var parameterType = TypeName(parameter.ParameterType);
            var parameterName = GetId(parameter);
            var parameterDefaultValue = "";
            object? defaultValue = null;
            if (parameter.HasDefaultValue) {
              defaultValue = parameter.DefaultValue;
              if (defaultValue is null) {
                if (parameter.ParameterType.IsValueType) {
                  parameterDefaultValue = $" = default({parameterType})";
                }
                else {
                  parameterDefaultValue = " = null";
                }
              }
              else if (parameter.ParameterType == typeof(bool)) {
                parameterDefaultValue = $" = {defaultValue.ToString()!.ToLower()}";
              }
              else if (parameter.ParameterType == typeof(double)) {
                parameterDefaultValue = $" = {defaultValue}d";
              }
              else if (parameter.ParameterType == typeof(float)) {
                parameterDefaultValue = $" = {defaultValue}f";
              }
              else if (parameter.ParameterType == typeof(char)) {
                parameterDefaultValue = $" = '{Escape(defaultValue.ToString()!)}'";
              }
              else if (parameter.ParameterType == typeof(string)) {
                parameterDefaultValue = $" = \"{Escape((string)defaultValue)}\"";
              }
              else if (parameter.ParameterType.IsPrimitive) {
                parameterDefaultValue = $" = {defaultValue}";
              }
              else if (parameter.ParameterType.IsEnum) {
                var enumMemberName = Enum.GetName(parameter.ParameterType, defaultValue);
                if (string.IsNullOrEmpty(enumMemberName)) {
                  // see if it's a multi-flag enum
                  var enumValues = defaultValue.ToString()!.Split(",").Select(v => v.Trim());

                  parameterDefaultValue = " = " + string.Join(" | ", enumValues.Select(v => $"{parameterType}.{v}"));
                }
                else {
                  parameterDefaultValue = string.IsNullOrEmpty(enumMemberName)
                    ? $" = ({parameterType}){(int)defaultValue}"
                    : $" = {parameterType}." + enumMemberName;
                }
              }
              else if (parameter.ParameterType.IsValueType) {
                parameterDefaultValue = $" = default({parameterType})";
              }
              else {
                parameterDefaultValue = $" = {defaultValue}";
              }

              if (
                defaultValue is null &&
                !parameterType.StartsWith("Nullable<") &&
                parameter.ParameterType != typeof(Variant)
              ) {
                parameterType += "?";
              }
            }
            var modifier = "";
            if (parameter.IsOut) {
              modifier = "out ";
            }
            else if (parameter.IsIn) {
              modifier = "in ";
            }
            else if (parameter.ParameterType.IsByRef) {
              modifier = "ref ";
            }
            return new ParameterData(
              parameterName,
              parameterType,
              parameterDefaultValue,
              modifier
            );
          });

          var parameterList = string.Join(
            ", ",
            parametersData.Select(p => p.ToString())
          );

          var signature = $"{returnType} {methodName}({parameterList}){typeParameterConstraints}";
          var interfaceSignature = $"{methodDocumentation}\n{"  ".Repeat(2)}{signature};";
          var adapterSignature = $"{methodDocumentation}\n{"  ".Repeat(2)}public {signature}";
          interfaceMembers.AppendLine(interfaceSignature);
          var adapterCode = adapterSignature + " => Object." + methodName + "(" + string.Join(", ", parametersData.Select(p => p.Name)) + ");";
          adapterMembers.AppendLine(adapterCode);
        }
        else if (member is PropertyInfo propertyInfo) {
          // Ignore set_ and get_ properties
          if (propertyInfo.Name.StartsWith("set_") || propertyInfo.Name.StartsWith("get_")) { continue; }

          var getMethod = propertyInfo.GetMethod;
          var isGettable =
            getMethod is MethodInfo getMethodInfo && getMethodInfo.IsPublic;

          // Only show public properties.
          if (!isGettable) { continue; }

          var setMethod = propertyInfo.SetMethod;
          var isSettable =
            setMethod is MethodInfo setMethodInfo && setMethodInfo.IsPublic;

          var writeable = isSettable ? "get; set;" : "get;";

          var propertyType = TypeName(propertyInfo.PropertyType);

          // For properties
          var propertyDocumentation = XmlDocToDocComment(
            propertyInfo.GetDocumentation() ?? "", 2
          );
          var propertyName = GetId(propertyInfo);

          var propertyPrefix = $"{propertyDocumentation}\n{"  ".Repeat(2)}{propertyType} {propertyName}";
          var propertySignature = $"{propertyPrefix} {{ {writeable} }}";

          var adapterCode = $"{propertyDocumentation}\n{"  ".Repeat(2)}public {propertyType} {propertyName}";
          if (isSettable && isGettable) {
            adapterCode += $" {{ get => Object.{propertyName}; set => Object.{propertyName} = value; }}";
          }
          else if (isGettable) {
            adapterCode += $" {{ get => Object.{propertyName}; }}";
          }
          else if (isSettable) {
            adapterCode += $" {{ set => Object.{propertyName} = value; }}";
          }

          interfaceMembers.AppendLine(propertySignature);
          adapterMembers.AppendLine(adapterCode);
        }
        else if (member is EventInfo eventInfo) {
          // For events
          var eventDocumentation = XmlDocToDocComment(
            eventInfo.GetDocumentation() ?? "", 2
          );

          var eventHandlerType = TypeName(eventInfo.EventHandlerType!);
          var eventId = GetId(eventInfo);

          var eventSignature = $"{eventDocumentation}\n{"  ".Repeat(2)}event {eventHandlerType} {eventId};";

          var adapterCode = $"{eventDocumentation}\n{"  ".Repeat(2)}public event {eventHandlerType} {eventId} {{ add => Object.{eventId} += value; remove => Object.{eventId} -= value; }}";

          interfaceMembers.AppendLine(eventSignature);
          adapterMembers.AppendLine(adapterCode);
        }
      }

      var baseType = type.BaseType!;

      // see if base type also extends Godot.Node
      var extendsAnotherObj = baseType.IsSubclassOf(typeof(GodotObject)) || baseType == typeof(GodotObject);

      var interfaceParent = extendsAnotherObj
        ? $" : I{baseType.Name}"
        : "";

      var adapterParent = extendsAnotherObj
        ? $"{baseType.Name}Adapter, "
        : "";

      var adapterBaseCall = extendsAnotherObj
        ? " : base(@object) "
        : " ";

      var adapterAbstract = type.IsAbstract ? " abstract " : " ";

      var interfaceMemberCode = interfaceMembers.ToString();
      var adapterMemberCode = adapterMembers.ToString();
      var iAdapterImpl =
        baseType.IsSubclassOf(typeof(Node)) || baseType == typeof(Node)
          ? ", INodeAdapter"
          : ", IGodotObjectAdapter";

      var usings = string.Join("\n", _usings.Select(u => $"using {u};"));

      var hasPublicParameterlessConstructor = type
        .GetConstructors(BindingFlags.Public | BindingFlags.Instance)
        .Any(c => c.GetParameters().Length == 0);
      var canBeInstantiated =
        !type.IsAbstract && hasPublicParameterlessConstructor;

      if (canBeInstantiated) {
        adapterFactoryCases.Add(
          $"    [typeof({interfaceName})] = node => new {adapterName}(node)"
        );
        adapterFactoryCasesByGodotNode.Add(
          $"    [typeof({typeName})] = node => new {adapterName}(node)"
        );
      }

      var partialClassForVerification = $$"""

      // Apply interface to a Godot node implementation to make sure the
      // generated interface is correct.
      internal partial class {{type.Name}}Node : {{typeName}}, {{interfaceName}} { }

      """;

      var interfaceContents = $$"""
      namespace Chickensoft.GodotNodeInterfaces;

      {{usings}}
      {{(canBeInstantiated ? partialClassForVerification : "\n")}}
      {{mainDocumentation}}
      public interface {{interfaceName}}{{interfaceParent}} {
      {{interfaceMemberCode}}
      }
      """;

      var newKeyword = extendsAnotherObj ? "new" : "";

      var adapterContents = $$"""
      namespace Chickensoft.GodotNodeInterfaces;

      {{usings}}
      {{mainDocumentation}}
      public{{adapterAbstract}}class {{adapterName}} : {{adapterParent}}{{interfaceName}}{{iAdapterImpl}} {
        /// <summary>Underlying Godot object this adapter uses.</summary>
        public {{newKeyword}} {{typeName}} Object { get; private set; }

        /// <summary>Creates a new {{adapterName}} for {{typeName}}.</summary>
        /// <param name="object">Godot object.</param>
        public {{adapterName}}(GodotObject @object){{adapterBaseCall}}{
          if (@object is not {{typeName}} typedObj) {
            throw new System.InvalidCastException(
              $"{@object.GetType().Name} is not a {{typeName}}"
            );
          }
          Object = typedObj;
        }

      {{adapterMemberCode}}
      }
      """;

      var interfaceFilePath = Path.Join(INTERFACES_PATH, interfaceFilename);
      File.WriteAllText(interfaceFilePath, interfaceContents);

      var adapterFilePath = Path.Join(ADAPTERS_PATH, adapterFilename);
      File.WriteAllText(adapterFilePath, adapterContents);

      Console.WriteLine($"Generated {interfaceName} and {adapterName}.");
    }

    var adapterFactoryFilename = SRC_PATH + "/GodotInterfaces.cs";

    var adapterFactoryCaseCode =
      string.Join(",\n  ", adapterFactoryCases).TrimEnd();

    var adapterFactoryCaseCodeByGodotNode =
      string.Join(",\n  ", adapterFactoryCasesByGodotNode).TrimEnd();

    var adapterFactoryContents = $$"""
    namespace Chickensoft.GodotNodeInterfaces;

    using System;
    using System.Collections.Generic;
    using Godot;

    public static class GodotInterfaces {
      private static readonly Dictionary<Type, Func<GodotObject, IGodotObjectAdapter>> _adapters = new() {
      {{adapterFactoryCaseCode}}
      };

      private static readonly Dictionary<Type, Func<GodotObject, IGodotObjectAdapter>> _adaptersByGodotType = new() {
        {{adapterFactoryCaseCodeByGodotNode}}
      };

      /// <summary>
      /// Creates an adapter for the given Godot object. This will throw if the
      /// incorrect adapter type was specified for the object.
      /// </summary>
      /// <typeparam name="T">Adapter type.</typeparam>
      /// <param name="object">Godot object.</param>
      public static T Adapt<T>(GodotObject @object) where T : class, IGodotObject => (T)_adapters[typeof(T)](@object);

      /// <summary>
      /// Creates an adapter for the given Godot object. This will throw if the
      /// incorrect adapter type was specified for the object.
      /// </summary>
      /// <param name="object">Godot object.</param>
      public static IGodotObject AdaptObject(GodotObject @object) => _adaptersByGodotType[@object.GetType()](@object);

      /// <summary>
      /// Creates an adapter for the given Godot node. This will throw if the
      /// incorrect adapter type was specified for the object.
      /// </summary>
      /// <param name="node">Godot node.</param>
      public static INodeAdapter AdaptNode(Node node) => (INodeAdapter)AdaptObject(node);
    }
    """;

    File.WriteAllText(adapterFactoryFilename, adapterFactoryContents);

    Console.WriteLine("Generated GodotInterfaces.");
  }

  private static string GetId(MemberInfo type) =>
    !IsValidId(type.Name) ? $"@{type.Name}" : type.Name;

  private static string GetId(ParameterInfo type) =>
    !IsValidId(type.Name!) ? $"@{type.Name}" : type.Name!;

  private static bool IsValidId(string id) {
    var validId = SyntaxFacts.IsValidIdentifier(id);
    var isReserved = SyntaxFacts.GetKeywordKind(id) != SyntaxKind.None;
    var isContextualReserved =
      SyntaxFacts.GetContextualKeywordKind(id) != SyntaxKind.None;
    return validId && !isReserved && !isContextualReserved;
  }

  private static string Escape(string str) =>
    SymbolDisplay.FormatLiteral(str, false);

  // This is the set of types from the C# keyword list.
  private static readonly Dictionary<Type, string> _typeAlias =
    new() {
    { typeof(bool), "bool" },
    { typeof(byte), "byte" },
    { typeof(char), "char" },
    { typeof(decimal), "decimal" },
    { typeof(double), "double" },
    { typeof(float), "float" },
    { typeof(int), "int" },
    { typeof(long), "long" },
    { typeof(object), "object" },
    { typeof(sbyte), "sbyte" },
    { typeof(short), "short" },
    { typeof(string), "string" },
    { typeof(uint), "uint" },
    { typeof(ulong), "ulong" },
    { typeof(void), "void" },
  };

  private static string TypeName(Type type) {
    var name = TypeNameOrAlias(type);
    // see if type comes from a namespace
    if (type.Namespace is string @namespace) {
      // add namespace to using list
      _usings.Add(@namespace);
    }

    // sometimes, Godot collection types are ambiguous between .net collections
    var isAmbiguousCollectionType = type.Namespace == "Godot.Collections";
    var prefix = isAmbiguousCollectionType ? "Godot.Collections." : "";

    if (_ambiguousGodotTypes.Contains(type.Name)) {
      return $"Godot.{name}";
    }

    return type.IsGenericMethodParameter
      ? type.Name
      : prefix + (
        type.DeclaringType is Type dec
          ? $"{TypeName(dec)}.{name}"
          : name
        );
  }

  private static string TypeNameOrAlias(Type type) {
    // Handle generic types
    if (type.IsGenericType) {
      var name = type.Name.Split('`').FirstOrDefault();
      var @params =
          type.GetGenericArguments()
          .Select(a => type.IsConstructedGenericType ? TypeNameOrAlias(a) : a.Name);
      return $"{name}<{string.Join(",", @params)}>";
    }

    // Handle nullable value types
    var nullableBase = Nullable.GetUnderlyingType(type);
    if (nullableBase != null) {
      return TypeNameOrAlias(nullableBase) + "?";
    }

    // Handle arrays
    if (type.BaseType == typeof(Array)) {
      return TypeNameOrAlias(type.GetElementType()!) + "[]";
    }

    // Lookup alias for type
    if (_typeAlias.TryGetValue(type, out var alias)) {
      return alias;
    }

    // Default to CLR type name
    return type.Name;
  }

  private static string XmlDocToDocComment(string? xmlDocs, int indent) {
    if (xmlDocs is not string xmlDoc) { return ""; }

    var lines = xmlDoc
      .Split("\n")
      .Select(l => l.Trim())
      .Where(l => l != "")
      // Remove unneeded prefixes like `T:` and `E:`, etc,
      // leaving the rest of the cref contents alone
      .Select(l => Regex.Replace(
        l, CrefTagRegex, m => m.Groups[1].Value + m.Groups[3].Value))
      // indent 2 spaces
      .Select(l => $"{" ".Repeat(indent * 2)}/// {l}");

    return string.Join("\n", lines);
  }
}
