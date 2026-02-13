namespace Chickensoft.GodotNodeInterfaces.Tests;

using Godot;

/// <summary>
/// A custom Node using GodotNodeInterfaces. Used for testing.
/// </summary>
public interface ICustomNode : INode { }

/// <inheritdoc cref="ICustomNode"/>
public partial class CustomNode : Node, ICustomNode
{
}
