namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para>A variant of <see cref="BoxContainer" /> that can only arrange its child controls vertically. Child controls are rearranged automatically when their minimum size changes.</para>
/// </summary>
public class VBoxContainerAdapter : BoxContainerAdapter, IVBoxContainer {
  private readonly VBoxContainer _node;

  public VBoxContainerAdapter(Node node) : base(node) {
    if (node is not VBoxContainer typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a VBoxContainer"
      );
    }
    _node = typedNode;
  }


}