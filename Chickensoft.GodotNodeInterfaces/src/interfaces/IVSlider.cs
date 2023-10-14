namespace Chickensoft.GodotNodeInterfaces;

using Godot;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class VSliderNode : VSlider, IVSlider { }

/// <summary>
/// <para>A vertical slider, used to adjust a value by moving a grabber along a vertical axis. It is a <see cref="Range" />-based control and goes from bottom (min) to top (max). Note that this direction is the opposite of <see cref="VScrollBar" />'s.</para>
/// </summary>
public interface IVSlider : ISlider {

}