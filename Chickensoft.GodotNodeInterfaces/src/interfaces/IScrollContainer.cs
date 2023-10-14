namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class ScrollContainerNode : ScrollContainer, IScrollContainer { }

/// <summary>
/// <para>A container used to provide a child control with scrollbars when needed. Scrollbars will automatically be drawn at the right (for vertical) or bottom (for horizontal) and will enable dragging to move the viewable Control (and its children) within the ScrollContainer. Scrollbars will also automatically resize the grabber based on the <see cref="Control.CustomMinimumSize" /> of the Control relative to the ScrollContainer.</para>
/// </summary>
public interface IScrollContainer : IContainer {
    /// <summary>
    /// <para>Ensures the given <paramref name="control" /> is visible (must be a direct or indirect child of the ScrollContainer). Used by <see cref="ScrollContainer.FollowFocus" />.</para>
    /// <para><b>Note:</b> This will not work on a node that was just added during the same frame. If you want to scroll to a newly added child, you must wait until the next frame using <see cref="SceneTree.ProcessFrame" />:</para>
    /// <para><code>
    /// add_child(child_node)
    /// await get_tree().process_frame
    /// ensure_control_visible(child_node)
    /// </code></para>
    /// </summary>
    void EnsureControlVisible(Control control);
    /// <summary>
    /// <para>If <c>true</c>, the ScrollContainer will automatically scroll to focused children (including indirect children) to make sure they are fully visible.</para>
    /// </summary>
    bool FollowFocus { get; set; }
    /// <summary>
    /// <para>Returns the horizontal scrollbar <see cref="HScrollBar" /> of this <see cref="ScrollContainer" />.</para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash. If you wish to disable or hide a scrollbar, you can use <see cref="ScrollContainer.HorizontalScrollMode" />.</para>
    /// </summary>
    HScrollBar GetHScrollBar();
    /// <summary>
    /// <para>Returns the vertical scrollbar <see cref="VScrollBar" /> of this <see cref="ScrollContainer" />.</para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash. If you wish to disable or hide a scrollbar, you can use <see cref="ScrollContainer.VerticalScrollMode" />.</para>
    /// </summary>
    VScrollBar GetVScrollBar();
    /// <summary>
    /// <para>Controls whether horizontal scrollbar can be used and when it should be visible. See <see cref="ScrollContainer.ScrollMode" /> for options.</para>
    /// </summary>
    ScrollContainer.ScrollMode HorizontalScrollMode { get; set; }
    /// <summary>
    /// <para>Deadzone for touch scrolling. Lower deadzone makes the scrolling more sensitive.</para>
    /// </summary>
    int ScrollDeadzone { get; set; }
    /// <summary>
    /// <para>The current horizontal scroll value.</para>
    /// <para><b>Note:</b> If you are setting this value in the <see cref="Node._Ready" /> function or earlier, it needs to be wrapped with <see cref="GodotObject.SetDeferred(Godot.StringName,Godot.Variant)" />, since scroll bar's <see cref="Range.MaxValue" /> is not initialized yet.</para>
    /// <para><code>
    /// func _ready():
    /// set_deferred("scroll_horizontal", 600)
    /// </code></para>
    /// </summary>
    int ScrollHorizontal { get; set; }
    /// <summary>
    /// <para>Overrides the <see cref="ScrollBar.CustomStep" /> used when clicking the internal scroll bar's horizontal increment and decrement buttons or when using arrow keys when the <see cref="ScrollBar" /> is focused.</para>
    /// </summary>
    float ScrollHorizontalCustomStep { get; set; }
    /// <summary>
    /// <para>The current vertical scroll value.</para>
    /// <para><b>Note:</b> Setting it early needs to be deferred, just like in <see cref="ScrollContainer.ScrollHorizontal" />.</para>
    /// <para><code>
    /// func _ready():
    /// set_deferred("scroll_vertical", 600)
    /// </code></para>
    /// </summary>
    int ScrollVertical { get; set; }
    /// <summary>
    /// <para>Overrides the <see cref="ScrollBar.CustomStep" /> used when clicking the internal scroll bar's vertical increment and decrement buttons or when using arrow keys when the <see cref="ScrollBar" /> is focused.</para>
    /// </summary>
    float ScrollVerticalCustomStep { get; set; }
    /// <summary>
    /// <para>Controls whether vertical scrollbar can be used and when it should be visible. See <see cref="ScrollContainer.ScrollMode" /> for options.</para>
    /// </summary>
    ScrollContainer.ScrollMode VerticalScrollMode { get; set; }

}