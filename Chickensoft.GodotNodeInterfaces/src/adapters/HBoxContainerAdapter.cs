namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para>A variant of <see cref="BoxContainer" /> that can only arrange its child controls horizontally. Child controls are rearranged automatically when their minimum size changes.</para>
/// </summary>
public class HBoxContainerAdapter : BoxContainerAdapter, IHBoxContainer {
  private readonly HBoxContainer _node;

  public HBoxContainerAdapter(Node node) : base(node) {
    if (node is not HBoxContainer typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a HBoxContainer"
      );
    }
    _node = typedNode;
  }


}