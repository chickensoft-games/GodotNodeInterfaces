namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A container used to provide a child control with scrollbars when needed. Scrollbars will automatically be drawn at the right (for vertical) or bottom (for horizontal) and will enable dragging to move the viewable Control (and its children) within the ScrollContainer. Scrollbars will also automatically resize the grabber based on the <see cref="Control.CustomMinimumSize" /> of the Control relative to the ScrollContainer.</para>
/// </summary>
public class ScrollContainerAdapter : ContainerAdapter, IScrollContainer {
  private readonly ScrollContainer _node;

  public ScrollContainerAdapter(Node node) : base(node) {
    if (node is not ScrollContainer typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a ScrollContainer"
      );
    }
    _node = typedNode;
  }

    /// <summary>
    /// <para>Ensures the given <paramref name="control" /> is visible (must be a direct or indirect child of the ScrollContainer). Used by <see cref="ScrollContainer.FollowFocus" />.</para>
    /// <para><b>Note:</b> This will not work on a node that was just added during the same frame. If you want to scroll to a newly added child, you must wait until the next frame using <see cref="SceneTree.ProcessFrame" />:</para>
    /// <para><code>
    /// add_child(child_node)
    /// await get_tree().process_frame
    /// ensure_control_visible(child_node)
    /// </code></para>
    /// </summary>
    public void EnsureControlVisible(Control control) => _node.EnsureControlVisible(control);
    /// <summary>
    /// <para>If <c>true</c>, the ScrollContainer will automatically scroll to focused children (including indirect children) to make sure they are fully visible.</para>
    /// </summary>
    public bool FollowFocus { get => _node.FollowFocus; set => _node.FollowFocus = value; }
    /// <summary>
    /// <para>Returns the horizontal scrollbar <see cref="HScrollBar" /> of this <see cref="ScrollContainer" />.</para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash. If you wish to disable or hide a scrollbar, you can use <see cref="ScrollContainer.HorizontalScrollMode" />.</para>
    /// </summary>
    public HScrollBar GetHScrollBar() => _node.GetHScrollBar();
    /// <summary>
    /// <para>Returns the vertical scrollbar <see cref="VScrollBar" /> of this <see cref="ScrollContainer" />.</para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash. If you wish to disable or hide a scrollbar, you can use <see cref="ScrollContainer.VerticalScrollMode" />.</para>
    /// </summary>
    public VScrollBar GetVScrollBar() => _node.GetVScrollBar();
    /// <summary>
    /// <para>Controls whether horizontal scrollbar can be used and when it should be visible. See <see cref="ScrollContainer.ScrollMode" /> for options.</para>
    /// </summary>
    public ScrollContainer.ScrollMode HorizontalScrollMode { get => _node.HorizontalScrollMode; set => _node.HorizontalScrollMode = value; }
    /// <summary>
    /// <para>Deadzone for touch scrolling. Lower deadzone makes the scrolling more sensitive.</para>
    /// </summary>
    public int ScrollDeadzone { get => _node.ScrollDeadzone; set => _node.ScrollDeadzone = value; }
    /// <summary>
    /// <para>The current horizontal scroll value.</para>
    /// <para><b>Note:</b> If you are setting this value in the <see cref="Node._Ready" /> function or earlier, it needs to be wrapped with <see cref="GodotObject.SetDeferred(Godot.StringName,Godot.Variant)" />, since scroll bar's <see cref="Range.MaxValue" /> is not initialized yet.</para>
    /// <para><code>
    /// func _ready():
    /// set_deferred("scroll_horizontal", 600)
    /// </code></para>
    /// </summary>
    public int ScrollHorizontal { get => _node.ScrollHorizontal; set => _node.ScrollHorizontal = value; }
    /// <summary>
    /// <para>Overrides the <see cref="ScrollBar.CustomStep" /> used when clicking the internal scroll bar's horizontal increment and decrement buttons or when using arrow keys when the <see cref="ScrollBar" /> is focused.</para>
    /// </summary>
    public float ScrollHorizontalCustomStep { get => _node.ScrollHorizontalCustomStep; set => _node.ScrollHorizontalCustomStep = value; }
    /// <summary>
    /// <para>The current vertical scroll value.</para>
    /// <para><b>Note:</b> Setting it early needs to be deferred, just like in <see cref="ScrollContainer.ScrollHorizontal" />.</para>
    /// <para><code>
    /// func _ready():
    /// set_deferred("scroll_vertical", 600)
    /// </code></para>
    /// </summary>
    public int ScrollVertical { get => _node.ScrollVertical; set => _node.ScrollVertical = value; }
    /// <summary>
    /// <para>Overrides the <see cref="ScrollBar.CustomStep" /> used when clicking the internal scroll bar's vertical increment and decrement buttons or when using arrow keys when the <see cref="ScrollBar" /> is focused.</para>
    /// </summary>
    public float ScrollVerticalCustomStep { get => _node.ScrollVerticalCustomStep; set => _node.ScrollVerticalCustomStep = value; }
    /// <summary>
    /// <para>Controls whether vertical scrollbar can be used and when it should be visible. See <see cref="ScrollContainer.ScrollMode" /> for options.</para>
    /// </summary>
    public ScrollContainer.ScrollMode VerticalScrollMode { get => _node.VerticalScrollMode; set => _node.VerticalScrollMode = value; }

}