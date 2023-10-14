namespace Chickensoft.GodotNodeInterfaces;

using Godot;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class VSplitContainerNode : VSplitContainer, IVSplitContainer { }

/// <summary>
/// <para>A container that accepts only two child controls, then arranges them vertically and creates a divisor between them. The divisor can be dragged around to change the size relation between the child controls.</para>
/// </summary>
public interface IVSplitContainer : ISplitContainer {

}