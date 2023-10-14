namespace Chickensoft.GodotNodeInterfaces;

using Godot;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class VScrollBarNode : VScrollBar, IVScrollBar { }

/// <summary>
/// <para>A vertical scrollbar, typically used to navigate through content that extends beyond the visible height of a control. It is a <see cref="Range" />-based control and goes from top (min) to bottom (max). Note that this direction is the opposite of <see cref="VSlider" />'s.</para>
/// </summary>
public interface IVScrollBar : IScrollBar {

}