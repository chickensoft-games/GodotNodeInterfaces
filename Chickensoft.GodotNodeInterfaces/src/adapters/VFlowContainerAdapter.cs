namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para>A variant of <see cref="FlowContainer" /> that can only arrange its child controls vertically, wrapping them around at the borders. This is similar to how text in a book wraps around when no more words can fit on a line, except vertically.</para>
/// </summary>
public class VFlowContainerAdapter : FlowContainerAdapter, IVFlowContainer {
  private readonly VFlowContainer _node;

  public VFlowContainerAdapter(Node node) : base(node) {
    if (node is not VFlowContainer typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a VFlowContainer"
      );
    }
    _node = typedNode;
  }


}