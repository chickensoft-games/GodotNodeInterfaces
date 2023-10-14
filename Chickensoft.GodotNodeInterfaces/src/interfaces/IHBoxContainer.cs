namespace Chickensoft.GodotNodeInterfaces;

using Godot;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class HBoxContainerNode : HBoxContainer, IHBoxContainer { }

/// <summary>
/// <para>A variant of <see cref="BoxContainer" /> that can only arrange its child controls horizontally. Child controls are rearranged automatically when their minimum size changes.</para>
/// </summary>
public interface IHBoxContainer : IBoxContainer {

}