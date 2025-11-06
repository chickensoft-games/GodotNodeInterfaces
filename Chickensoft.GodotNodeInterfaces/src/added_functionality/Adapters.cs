namespace Chickensoft.GodotNodeInterfaces;

using Godot;

/// <summary>A Godot object API adapter.</summary>
public interface IGodotObjectAdapter : IGodotObject
{
  /// <summary>Underlying Godot object this adapter uses.</summary>
  GodotObject TargetObj { get; }
}

/// <summary>A Godot node API adapter.</summary>
public partial interface INodeAdapter : IGodotObjectAdapter, INode
{
  /// <summary>Underlying Godot node this adapter uses.</summary>
  new Node TargetObj { get; }
}
