namespace Chickensoft.GodotNodeInterfaces;

using Godot;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class HScrollBarNode : HScrollBar, IHScrollBar { }

/// <summary>
/// <para>A horizontal scrollbar, typically used to navigate through content that extends beyond the visible width of a control. It is a <see cref="Range" />-based control and goes from left (min) to right (max).</para>
/// </summary>
public interface IHScrollBar : IScrollBar {

}