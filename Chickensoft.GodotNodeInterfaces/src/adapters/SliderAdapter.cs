namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>Abstract base class for sliders, used to adjust a value by moving a grabber along a horizontal or vertical axis. Sliders are <see cref="Range" />-based controls.</para>
/// </summary>
public class SliderAdapter : RangeAdapter, ISlider {
  private readonly Slider _node;

  public SliderAdapter(Node node) : base(node) {
    if (node is not Slider typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a Slider"
      );
    }
    _node = typedNode;
  }

    /// <summary>
    /// <para>If <c>true</c>, the slider can be interacted with. If <c>false</c>, the value can be changed only by code.</para>
    /// </summary>
    public bool Editable { get => _node.Editable; set => _node.Editable = value; }
    /// <summary>
    /// <para>If <c>true</c>, the value can be changed using the mouse wheel.</para>
    /// </summary>
    public bool Scrollable { get => _node.Scrollable; set => _node.Scrollable = value; }
    /// <summary>
    /// <para>Number of ticks displayed on the slider, including border ticks. Ticks are uniformly-distributed value markers.</para>
    /// </summary>
    public int TickCount { get => _node.TickCount; set => _node.TickCount = value; }
    /// <summary>
    /// <para>If <c>true</c>, the slider will display ticks for minimum and maximum values.</para>
    /// </summary>
    public bool TicksOnBorders { get => _node.TicksOnBorders; set => _node.TicksOnBorders = value; }

}