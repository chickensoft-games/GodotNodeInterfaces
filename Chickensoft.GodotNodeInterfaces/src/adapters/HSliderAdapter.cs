namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para>A horizontal slider, used to adjust a value by moving a grabber along a horizontal axis. It is a <see cref="Range" />-based control and goes from left (min) to right (max).</para>
/// </summary>
public class HSliderAdapter : SliderAdapter, IHSlider {
  private readonly HSlider _node;

  public HSliderAdapter(HSlider node) : base(node) { _node = node; }


}