namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para>A container that accepts only two child controls, then arranges them horizontally and creates a divisor between them. The divisor can be dragged around to change the size relation between the child controls.</para>
/// </summary>
public class HSplitContainerAdapter : SplitContainerAdapter, IHSplitContainer {
  private readonly HSplitContainer _node;

  public HSplitContainerAdapter(Node node) : base(node) {
    if (node is not HSplitContainer typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a HSplitContainer"
      );
    }
    _node = typedNode;
  }


}