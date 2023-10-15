namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para>A variant of <see cref="FlowContainer" /> that can only arrange its child controls horizontally, wrapping them around at the borders. This is similar to how text in a book wraps around when no more words can fit on a line.</para>
/// </summary>
public class HFlowContainerAdapter : FlowContainerAdapter, IHFlowContainer {
  private readonly HFlowContainer _node;

  public HFlowContainerAdapter(Node node) : base(node) {
    if (node is not HFlowContainer typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a HFlowContainer"
      );
    }
    _node = typedNode;
  }


}