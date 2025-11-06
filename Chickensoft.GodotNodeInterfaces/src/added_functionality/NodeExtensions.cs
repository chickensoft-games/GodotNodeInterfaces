namespace Chickensoft.GodotNodeInterfaces;

using System;
using Godot;

public static class NodeExtensions
{
  /// <summary>
  /// <inheritdoc cref="INode.AddChildEx(object, bool, Node.InternalMode)" />
  /// </summary>
  /// <param name="caller">Parent Godot node.</param>
  /// <param name="node"><inheritdoc cref="INode.AddChildEx(object, bool, Node.InternalMode)" path="/param[@name='node']" /></param>
  /// <param name="forceReadableName"><inheritdoc cref="INode.AddChildEx(object, bool, Node.InternalMode)" path="/param[@name='forceReadableName']" /></param>
  /// <param name="internal"><inheritdoc cref="INode.AddChildEx(object, bool, Node.InternalMode)" path="/param[@name='internal']" /></param>
  public static void AddChildEx(
    this Node caller,
    object node,
    bool forceReadableName = false,
    Node.InternalMode @internal =
    Node.InternalMode.Disabled
  ) => AddChildEx((object)caller, node, forceReadableName, @internal);

  /// <summary>
  /// <inheritdoc cref="INode.AddChildEx(object, bool, Node.InternalMode)" />
  /// </summary>
  /// <param name="caller">Parent Godot node or adapter.</param>
  /// <param name="node"><inheritdoc cref="INode.AddChildEx(object, bool, Node.InternalMode)" path="/param[@name='node']" /></param>
  /// <param name="forceReadableName"><inheritdoc cref="INode.AddChildEx(object, bool, Node.InternalMode)" path="/param[@name='forceReadableName']" /></param>
  /// <param name="internal"><inheritdoc cref="INode.AddChildEx(object, bool, Node.InternalMode)" path="/param[@name='internal']" /></param>
  public static void AddChildEx(
    object caller,
    object node,
    bool forceReadableName = false,
    Node.InternalMode @internal =
    Node.InternalMode.Disabled
  ) => TreeOp(
    caller,
    "add child",
    (fakeNodeTree) =>
    {
      if (node is INode iNode)
      {
        fakeNodeTree.AddChild(iNode);
        return true;
      }
      throw new InvalidOperationException(
        $"Cannot add child of type '{node.GetType().Name}' " +
        $"to {caller.GetType().Name}."
      );
    },
    (parent) =>
    {
      if (node is INodeAdapter adapter)
      {
        // If it's an adapter, we can add the underlying node directly.
        parent.AddChild(adapter.TargetObj, forceReadableName, @internal);
        return true;
      }

      if (node is Node godotNode)
      {
        // If it's a Godot node, we can add it directly.
        parent.AddChild(godotNode, forceReadableName, @internal);
        return true;
      }

      throw new InvalidOperationException(
        $"Cannot add child of type '{node.GetType().Name}' " +
        $"to {caller.GetType().Name}."
      );
    }
  );

  /// <summary>
  /// <inheritdoc cref="INode.FindChildEx(string, bool, bool)" />
  /// </summary>
  /// <param name="caller">Parent Godot node.</param>
  /// <param name="pattern"><inheritdoc cref="INode.FindChildEx(string, bool, bool)" path="/param[@name='pattern']" /></param>
  /// <param name="recursive"><inheritdoc cref="INode.FindChildEx(string, bool, bool)" path="/param[@name='recursive']" /></param>
  /// <param name="owned"><inheritdoc cref="INode.FindChildEx(string, bool, bool)" path="/param[@name='owned']" /></param>
  /// <returns>
  /// <inheritdoc cref="INode.FindChildEx(string, bool, bool)" path="/returns" />
  /// </returns>
  public static INode? FindChildEx(
    this Node caller, string pattern, bool recursive = true, bool owned = true
  ) => FindChildEx((object)caller, pattern, recursive, owned);

  /// <summary>
  /// <inheritdoc cref="INode.FindChildEx(string, bool, bool)" />
  /// </summary>
  /// <param name="caller">Parent Godot node or adapter.</param>
  /// <param name="pattern"><inheritdoc cref="INode.FindChildEx(string, bool, bool)" path="/param[@name='pattern']" /></param>
  /// <param name="recursive"><inheritdoc cref="INode.FindChildEx(string, bool, bool)" path="/param[@name='recursive']" /></param>
  /// <param name="owned"><inheritdoc cref="INode.FindChildEx(string, bool, bool)" path="/param[@name='owned']" /></param>
  /// <returns>
  /// <inheritdoc cref="INode.FindChildEx(string, bool, bool)" path="/returns" />
  /// </returns>
  public static INode? FindChildEx(
    object caller, string pattern, bool recursive = true, bool owned = true
  ) => TreeOp(
    caller,
    "find child",
    fakeNodeTree => fakeNodeTree.FindChild(pattern),
    node =>
    {
      var child = node.FindChild(pattern, recursive, owned);
      return child is null ? null : GodotInterfaces.AdaptNode(child);
    }
  );

  /// <summary>
  /// <inheritdoc cref="INode.FindChildrenEx(string, string, bool, bool)" />
  /// </summary>
  /// <param name="caller">Parent Godot node.</param>
  /// <param name="pattern"><inheritdoc cref="INode.FindChildrenEx(string, string, bool, bool)" path="/param[@name='pattern']" /></param>
  /// <param name="type"><inheritdoc cref="INode.FindChildrenEx(string, string, bool, bool)" path="/param[@name='type']" /></param>
  /// <param name="recursive"><inheritdoc cref="INode.FindChildrenEx(string, string, bool, bool)" path="/param[@name='recursive']" /></param>
  /// <param name="owned"><inheritdoc cref="INode.FindChildrenEx(string, string, bool, bool)" path="/param[@name='owned']" /></param>
  /// <returns>
  /// <inheritdoc cref="INode.FindChildrenEx(string, string, bool, bool)" path="/returns" />
  /// </returns>
  public static INode[] FindChildrenEx(
    this Node caller,
    string pattern, string type = "", bool recursive = true, bool owned = true
  ) => FindChildrenEx((object)caller, pattern, type, recursive, owned);

  /// <summary>
  /// <inheritdoc cref="INode.FindChildrenEx(string, string, bool, bool)" />
  /// </summary>
  /// <param name="caller">Parent Godot node or adapter.</param>
  /// <param name="pattern"><inheritdoc cref="INode.FindChildrenEx(string, string, bool, bool)" path="/param[@name='pattern']" /></param>
  /// <param name="type"><inheritdoc cref="INode.FindChildrenEx(string, string, bool, bool)" path="/param[@name='type']" /></param>
  /// <param name="recursive"><inheritdoc cref="INode.FindChildrenEx(string, string, bool, bool)" path="/param[@name='recursive']" /></param>
  /// <param name="owned"><inheritdoc cref="INode.FindChildrenEx(string, string, bool, bool)" path="/param[@name='owned']" /></param>
  /// <returns>
  /// <inheritdoc cref="INode.FindChildrenEx(string, string, bool, bool)" path="/returns" />
  /// </returns>
  public static INode[] FindChildrenEx(
    object caller,
    string pattern, string type = "", bool recursive = true, bool owned = true
  ) => TreeOp(
    caller,
    "find children",
    (fakeNodeTree) => fakeNodeTree.FindChildren(pattern),
    (node) =>
    {
      var nodes = node.FindChildren(pattern, type, recursive, owned);
      var adaptedNodes = new System.Collections.Generic.List<INode>(
        nodes.Count
      );
      foreach (var childNode in nodes)
      {
        adaptedNodes.Add(GodotInterfaces.AdaptNode(childNode));
      }
      return adaptedNodes.ToArray();
    }
  );

  /// <summary>
  /// <inheritdoc cref="INode.GetChildEx(int, bool)" />
  /// </summary>
  /// <param name="caller">Parent Godot node.</param>
  /// <param name="idx"><inheritdoc cref="INode.GetChildEx(int, bool)" path="/param[@name='idx']" /></param>
  /// <param name="includeInternal"><inheritdoc cref="INode.GetChildEx(int, bool)" path="/param[@name='includeInternal']" /></param>
  /// <typeparam name="T"><inheritdoc cref="INode.GetChildEx(int, bool)" path="/typeparam[@name='T']" /></typeparam>
  /// <returns>
  /// <inheritdoc cref="INode.GetChildEx(int, bool)" path="/returns" />
  /// </returns>
  public static T GetChildEx<T>(
    this Node caller, int idx, bool includeInternal = false
  ) where T : class, INode => GetChildEx<T>(
    (object)caller, idx, includeInternal
  );

  /// <summary>
  /// <inheritdoc cref="INode.GetChildEx(int, bool)" />
  /// </summary>
  /// <param name="caller">Parent Godot node or adapter.</param>
  /// <param name="idx"><inheritdoc cref="INode.GetChildEx{T}(int, bool)" path="/param[@name='idx']" /></param>
  /// <param name="includeInternal"><inheritdoc cref="INode.GetChildEx{T}(int, bool)" path="/param[@name='includeInternal']" /></param>
  /// <typeparam name="T"><inheritdoc cref="INode.GetChildEx{T}(int, bool)" path="/typeparam[@name='T']" /></typeparam>
  /// <returns>
  /// <inheritdoc cref="INode.GetChildEx{T}(int, bool)" path="/returns" />
  /// </returns>
  public static T GetChildEx<T>(
    object caller, int idx, bool includeInternal = false
  ) where T : class, INode => TreeOp(
    caller,
    "get child",
    fakeNodeTree => fakeNodeTree.GetChild<T>(idx)!,
    node => GodotInterfaces.Adapt<T>(node.GetChild(idx, includeInternal)!)
  );

  /// <summary>
  /// <inheritdoc cref="INode.GetChildEx(int, bool)" />
  /// </summary>
  /// <param name="caller">Parent Godot node.</param>
  /// <param name="idx"><inheritdoc cref="INode.GetChildEx(int, bool)" path="/param[@name='idx']" /></param>
  /// <param name="includeInternal"><inheritdoc cref="INode.GetChildEx(int, bool)" path="/param[@name='includeInternal']" /></param>
  /// <returns>
  /// <inheritdoc cref="INode.GetChildEx(int, bool)" path="/returns" />
  /// </returns>
  public static INode GetChildEx(
    this Node caller, int idx, bool includeInternal = false
  ) => GetChildEx((object)caller, idx, includeInternal);

  /// <summary>
  /// <inheritdoc cref="INode.GetChildEx(int, bool)" />
  /// </summary>
  /// <param name="caller">Parent Godot node or adapter.</param>
  /// <param name="idx"><inheritdoc cref="INode.GetChildEx(int, bool)" path="/param[@name='idx']" /></param>
  /// <param name="includeInternal"><inheritdoc cref="INode.GetChildEx(int, bool)" path="/param[@name='includeInternal']" /></param>
  /// <returns>
  /// <inheritdoc cref="INode.GetChildEx(int, bool)" path="/returns" />
  /// </returns>
  public static INode GetChildEx(
    object caller, int idx, bool includeInternal
  ) => TreeOp(
    caller,
    "get child",
    fakeNodeTree => fakeNodeTree.GetChild(idx),
    node => GodotInterfaces.AdaptNode(node.GetChild(idx, includeInternal))
  );

  /// <summary>
  /// <inheritdoc cref="INode.GetChildCountEx(bool)" />
  /// </summary>
  /// <param name="caller">Parent Godot node.</param>
  /// <param name="includeInternal"><inheritdoc cref="INode.GetChildCountEx(bool)" path="/param[@name='includeInternal']" /></param>
  /// <returns>
  /// <inheritdoc cref="INode.GetChildCountEx(bool)" path="/returns" />
  /// </returns>
  public static int GetChildCountEx(
    this Node caller, bool includeInternal = false
  ) => GetChildCountEx((object)caller, includeInternal);

  /// <summary>
  /// <inheritdoc cref="INode.GetChildCountEx(bool)" />
  /// </summary>
  /// <param name="caller">Parent Godot node or adapter.</param>
  /// <param name="includeInternal"><inheritdoc cref="INode.GetChildCountEx(bool)" path="/param[@name='includeInternal']" /></param>
  /// <returns>
  /// <inheritdoc cref="INode.GetChildCountEx(bool)" path="/returns" />
  /// </returns>
  public static int GetChildCountEx(
    object caller, bool includeInternal = false
  ) => TreeOp(
    caller: caller,
    "get number of children",
    fakeNodeTree => fakeNodeTree.GetChildCount(),
    parent => parent.GetChildCount(includeInternal)
  );

  /// <summary>
  /// <inheritdoc cref="INode.GetChildrenEx(bool)" />
  /// </summary>
  /// <param name="caller">Parent Godot node.</param>
  /// <param name="includeInternal"><inheritdoc cref="INode.GetChildrenEx(bool)" path="/param[@name='includeInternal']" /></param>
  /// <returns>
  /// <inheritdoc cref="INode.GetChildrenEx(bool)" path="/returns" />
  /// </returns>
  public static INode[] GetChildrenEx(
    this Node caller, bool includeInternal = false
  ) => GetChildrenEx((object)caller, includeInternal);

  /// <summary>
  /// <inheritdoc cref="INode.GetChildrenEx(bool)" />
  /// </summary>
  /// <param name="caller">Parent Godot node or adapter.</param>
  /// <param name="includeInternal"><inheritdoc cref="INode.GetChildrenEx(bool)" path="/param[@name='includeInternal']" /></param>
  /// <returns>
  /// <inheritdoc cref="INode.GetChildrenEx(bool)" path="/returns" />
  /// </returns>
  public static INode[] GetChildrenEx(
    object caller, bool includeInternal = false
  ) => TreeOp(
    caller: caller,
    "get children",
    fakeNodeTree => fakeNodeTree.GetChildren(),
    parent =>
    {
      var nodes = parent.GetChildren(includeInternal);
      var adaptedNodes = new System.Collections.Generic.List<INode>(
        nodes.Count
      );
      foreach (var childNode in nodes)
      {
        adaptedNodes.Add(GodotInterfaces.AdaptNode(childNode));
      }
      return adaptedNodes.ToArray();
    }
  );

  /// <summary>
  /// <inheritdoc cref="INode.GetNodeEx(NodePath)" />
  /// </summary>
  /// <param name="caller">Parent Godot node.</param>
  /// <param name="path"><inheritdoc cref="INode.GetNodeEx(NodePath)" path="/param[@name='path']" /></param>
  /// <returns>
  /// <inheritdoc cref="INode.GetNodeEx(NodePath)" path="/returns" />
  /// </returns>
  public static INode GetNodeEx(this Node caller, NodePath path) =>
    GetNodeEx((object)caller, path);

  /// <summary>
  /// <inheritdoc cref="INode.GetNodeEx(NodePath)" />
  /// </summary>
  /// <param name="caller">Parent Godot node or adapter.</param>
  /// <param name="path"><inheritdoc cref="INode.GetNodeEx(NodePath)" path="/param[@name='path']" /></param>
  /// <returns>
  /// <inheritdoc cref="INode.GetNodeEx(NodePath)" path="/returns" />
  /// </returns>
  public static INode GetNodeEx(object caller, NodePath path) => TreeOp(
    caller,
    "get node",
    fakeNodeTree => fakeNodeTree.GetNode(path)!,
    parent => GodotInterfaces.AdaptNode(parent.GetNode(path))
  );

  /// <summary>
  /// <inheritdoc cref="INode.GetNodeOrNullEx{T}(NodePath)" />
  /// </summary>
  /// <param name="caller">Parent Godot node.</param>
  /// <param name="path"><inheritdoc cref="INode.GetNodeOrNullEx{T}(NodePath)" path="/param[@name='path']" /></param>
  /// <typeparam name="T"><inheritdoc cref="INode.GetNodeOrNullEx{T}(NodePath)" path="/typeparam[@name='T']" /></typeparam>
  /// <returns>
  /// <inheritdoc cref="INode.GetNodeOrNullEx{T}(NodePath)" path="/returns" />
  /// </returns>
  public static T? GetNodeOrNullEx<T>(
    this Node caller,
    NodePath path
  ) where T : class, INode => GetNodeOrNullEx<T>((object)caller, path);

  /// <summary>
  /// <inheritdoc cref="INode.GetNodeOrNullEx{T}(NodePath)" />
  /// </summary>
  /// <param name="caller">Parent Godot node or adapter.</param>
  /// <param name="path"><inheritdoc cref="INode.GetNodeOrNullEx{T}(NodePath)" path="/param[@name='path']" /></param>
  /// <typeparam name="T"><inheritdoc cref="INode.GetNodeOrNullEx{T}(NodePath)" path="/typeparam[@name='T']" /></typeparam>
  /// <returns>
  /// <inheritdoc cref="INode.GetNodeOrNullEx{T}(NodePath)" path="/returns" />
  /// </returns>
  public static T? GetNodeOrNullEx<T>(
    object caller,
    NodePath path
  ) where T : class, INode => TreeOp(
    caller,
    "get node (or null)",
    fakeNodeTree => fakeNodeTree.GetNode<T>(path),
    parent =>
    {
      var node = parent.GetNodeOrNull(path);
      if (node is Node godotNode)
      {
        return GodotInterfaces.Adapt<T>(godotNode);
      }
      return null;
    }
  );

  /// <summary>
  /// <inheritdoc cref="INode.GetNodeOrNullEx(NodePath)" />
  /// </summary>
  /// <param name="caller">Parent Godot node.</param>
  /// <param name="path"><inheritdoc cref="INode.GetNodeOrNullEx(NodePath)" path="/param[@name='path']" /></param>
  /// <returns>
  /// <inheritdoc cref="INode.GetNodeOrNullEx(NodePath)" path="/returns" />
  /// </returns>
  public static INode? GetNodeOrNullEx(this Node caller, NodePath path) =>
    GetNodeOrNullEx((object)caller, path);

  /// <summary>
  /// <inheritdoc cref="INode.GetNodeOrNullEx(NodePath)" />
  /// </summary>
  /// <param name="caller">Parent Godot node or adapter.</param>
  /// <param name="path"><inheritdoc cref="INode.GetNodeOrNullEx(NodePath)" path="/param[@name='path']" /></param>
  /// <returns>
  /// <inheritdoc cref="INode.GetNodeOrNullEx(NodePath)" path="/returns" />
  /// </returns>
  public static INode? GetNodeOrNullEx(object caller, NodePath path) => TreeOp(
    caller: caller,
    "get node (or null)",
    fakeNodeTree => fakeNodeTree.GetNode(path),
    parent =>
    {
      var node = parent.GetNodeOrNull(path);
      if (node is Node godotNode)
      {
        return GodotInterfaces.AdaptNode(godotNode);
      }
      return null;
    }
  );

  /// <summary>
  /// <inheritdoc cref="INode.HasNodeEx(NodePath)" />
  /// </summary>
  /// <param name="caller">Parent Godot node.</param>
  /// <param name="path"><inheritdoc cref="INode.HasNodeEx(NodePath)" path="/param[@name='path']" /></param>
  /// <returns>
  /// <inheritdoc cref="INode.HasNodeEx(NodePath)" path="/returns" />
  /// </returns>
  public static bool HasNodeEx(this Node caller, NodePath path) =>
    HasNodeEx((object)caller, path);

  /// <summary>
  /// <inheritdoc cref="INode.HasNodeEx(NodePath)" />
  /// </summary>
  /// <param name="caller">Parent Godot node or adapter.</param>
  /// <param name="path"><inheritdoc cref="INode.HasNodeEx(NodePath)" path="/param[@name='path']" /></param>
  /// <returns>
  /// <inheritdoc cref="INode.HasNodeEx(NodePath)" path="/returns" />
  /// </returns>
  public static bool HasNodeEx(object caller, NodePath path) => TreeOp(
    caller,
    $"determine if it has a node at {path}",
    fakeNodeTree => fakeNodeTree.HasNode(path),
    parent => parent.HasNode(path)
  );

  /// <summary>
  /// <inheritdoc cref="INode.RemoveChildEx(object)" />
  /// </summary>
  /// <param name="caller">Parent Godot node.</param>
  /// <param name="node"><inheritdoc cref="INode.RemoveChildEx(object)" path="/param[@name='node']" /></param>
  public static void RemoveChildEx(this Node caller, object node) =>
    RemoveChildEx((object)caller, node);

  /// <summary>
  /// <inheritdoc cref="INode.RemoveChildEx(object)" />
  /// </summary>
  /// <param name="caller">Parent Godot node or adapter.</param>
  /// <param name="node"><inheritdoc cref="INode.RemoveChildEx(object)" path="/param[@name='node']" /></param>
  public static void RemoveChildEx(object caller, object node) => TreeOp(
    caller,
    "remove child",
    (fakeNodeTree) =>
    {
      if (node is INode iNode)
      {
        fakeNodeTree.RemoveChild(iNode);
        return true;
      }
      throw new InvalidOperationException(
        $"Cannot add child of type '{node.GetType().Name}' " +
        $"to {caller.GetType().Name}."
      );
    },
    (parent) =>
    {
      if (node is INodeAdapter adapter)
      {
        // If it's an adapter, we can remove the underlying node directly.
        parent.RemoveChild(adapter.TargetObj);
        return true;
      }

      if (node is Node godotNode)
      {
        // If it's a Godot node, we can remove it directly.
        parent.RemoveChild(godotNode);
        return true;
      }

      throw new InvalidOperationException(
        $"Cannot add child of type '{node.GetType().Name}' " +
        $"to {caller.GetType().Name}."
      );
    }
  );

  internal static T TreeOp<T>(
    object caller,
    string operation,
    Func<FakeNodeTree, T> ifFakeNodeTree,
    Func<Node, T> ifNode
  )
  {
    if (
      caller is IFakeNodeTreeEnabled obj &&
      obj.FakeNodes is FakeNodeTree fakeNodeTree
    )
    {
      return ifFakeNodeTree(fakeNodeTree);
    }
    var node = UseNodeOrAdapterTarget(caller, operation);
    return ifNode(node);
  }

  internal static Node UseNodeOrAdapterTarget(object obj, string reason)
  {
    if (obj is INodeAdapter adapter)
    { return adapter.TargetObj; }
    if (obj is Node node)
    { return node; }

    var typeName = obj.GetType().Name;
    throw new InvalidOperationException(
      $"Cannot {reason} on an object with the type '{typeName}'."
    );
  }
}
