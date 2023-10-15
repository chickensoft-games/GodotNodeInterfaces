namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para>A horizontal scrollbar, typically used to navigate through content that extends beyond the visible width of a control. It is a <see cref="Range" />-based control and goes from left (min) to right (max).</para>
/// </summary>
public class HScrollBarAdapter : ScrollBarAdapter, IHScrollBar {
  private readonly HScrollBar _node;

  public HScrollBarAdapter(Node node) : base(node) {
    if (node is not HScrollBar typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a HScrollBar"
      );
    }
    _node = typedNode;
  }


}