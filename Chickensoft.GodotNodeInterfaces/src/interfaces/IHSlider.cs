namespace Chickensoft.GodotNodeInterfaces;

using Godot;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class HSliderNode : HSlider, IHSlider { }

/// <summary>
/// <para>A horizontal slider, used to adjust a value by moving a grabber along a horizontal axis. It is a <see cref="Range" />-based control and goes from left (min) to right (max).</para>
/// </summary>
public interface IHSlider : ISlider {

}