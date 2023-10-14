namespace Chickensoft.GodotNodeInterfaces;

using Godot;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class PanelContainerNode : PanelContainer, IPanelContainer { }

/// <summary>
/// <para>A container that keeps its child controls within the area of a <see cref="StyleBox" />. Useful for giving controls an outline.</para>
/// </summary>
public interface IPanelContainer : IContainer {

}