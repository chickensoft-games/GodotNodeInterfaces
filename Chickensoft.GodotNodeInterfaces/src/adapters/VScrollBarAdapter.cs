 namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para>A vertical scrollbar, typically used to navigate through content that extends beyond the visible height of a control. It is a <see cref="Range" />-based control and goes from top (min) to bottom (max). Note that this direction is the opposite of <see cref="VSlider" />'s.</para>
/// </summary>
public class VScrollBarAdapter : VScrollBar, IVScrollBar {
  private readonly VScrollBar _node;

  public VScrollBarAdapter(VScrollBar node) => _node = node;

}