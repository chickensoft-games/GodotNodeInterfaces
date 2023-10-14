namespace Chickensoft.GodotNodeInterfaces;

using Godot;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class HFlowContainerNode : HFlowContainer, IHFlowContainer { }

/// <summary>
/// <para>A variant of <see cref="FlowContainer" /> that can only arrange its child controls horizontally, wrapping them around at the borders. This is similar to how text in a book wraps around when no more words can fit on a line.</para>
/// </summary>
public interface IHFlowContainer : IFlowContainer {

}