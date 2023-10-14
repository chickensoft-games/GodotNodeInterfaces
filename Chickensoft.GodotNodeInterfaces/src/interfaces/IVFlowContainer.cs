namespace Chickensoft.GodotNodeInterfaces;

using Godot;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class VFlowContainerNode : VFlowContainer, IVFlowContainer { }

/// <summary>
/// <para>A variant of <see cref="FlowContainer" /> that can only arrange its child controls vertically, wrapping them around at the borders. This is similar to how text in a book wraps around when no more words can fit on a line, except vertically.</para>
/// </summary>
public interface IVFlowContainer : IFlowContainer {

}