namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para>A horizontal scrollbar, typically used to navigate through content that extends beyond the visible width of a control. It is a <see cref="Range" />-based control and goes from left (min) to right (max).</para>
/// </summary>
public class HScrollBarAdapter : ScrollBarAdapter, IHScrollBar {
  private readonly HScrollBar _node;

  public HScrollBarAdapter(HScrollBar node) : base(node) { _node = node; }


}