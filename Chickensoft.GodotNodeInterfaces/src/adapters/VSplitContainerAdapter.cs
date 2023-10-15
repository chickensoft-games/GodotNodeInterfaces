namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para>A container that accepts only two child controls, then arranges them vertically and creates a divisor between them. The divisor can be dragged around to change the size relation between the child controls.</para>
/// </summary>
public class VSplitContainerAdapter : SplitContainerAdapter, IVSplitContainer {
  private readonly VSplitContainer _node;

  public VSplitContainerAdapter(Node node) : base(node) {
    if (node is not VSplitContainer typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a VSplitContainer"
      );
    }
    _node = typedNode;
  }


}