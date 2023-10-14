namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para>A variant of <see cref="FlowContainer" /> that can only arrange its child controls vertically, wrapping them around at the borders. This is similar to how text in a book wraps around when no more words can fit on a line, except vertically.</para>
/// </summary>
public class VFlowContainerAdapter : FlowContainerAdapter, IVFlowContainer {
  private readonly VFlowContainer _node;

  public VFlowContainerAdapter(VFlowContainer node) : base(node) { _node = node; }


}