namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para>A vertical slider, used to adjust a value by moving a grabber along a vertical axis. It is a <see cref="Range" />-based control and goes from bottom (min) to top (max). Note that this direction is the opposite of <see cref="VScrollBar" />'s.</para>
/// </summary>
public class VSliderAdapter : VSlider, IVSlider {
  private readonly VSlider _node;

  public VSliderAdapter(VSlider node) => _node = node;

}