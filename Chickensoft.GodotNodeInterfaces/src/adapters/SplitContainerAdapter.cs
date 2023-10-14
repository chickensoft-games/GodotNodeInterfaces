 namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A container that accepts only two child controls, then arranges them horizontally or vertically and creates a divisor between them. The divisor can be dragged around to change the size relation between the child controls.</para>
/// </summary>
public class SplitContainerAdapter : SplitContainer, ISplitContainer {
  private readonly SplitContainer _node;

  public SplitContainerAdapter(SplitContainer node) => _node = node;
    /// <summary>
    /// <para>Clamps the <see cref="SplitContainer.SplitOffset" /> value to not go outside the currently possible minimal and maximum values.</para>
    /// </summary>
    public void ClampSplitOffset() => _node.ClampSplitOffset();
    /// <summary>
    /// <para>If <c>true</c>, the area of the first <see cref="Control" /> will be collapsed and the dragger will be disabled.</para>
    /// </summary>
    public bool Collapsed { get => _node.Collapsed; set => _node.Collapsed = value; }
    /// <summary>
    /// <para>Determines the dragger's visibility. See <see cref="SplitContainer.DraggerVisibilityEnum" /> for details.</para>
    /// </summary>
    public SplitContainer.DraggerVisibilityEnum DraggerVisibility { get => _node.DraggerVisibility; set => _node.DraggerVisibility = value; }
    /// <summary>
    /// <para>The initial offset of the splitting between the two <see cref="Control" />s, with <c>0</c> being at the end of the first <see cref="Control" />.</para>
    /// </summary>
    public int SplitOffset { get => _node.SplitOffset; set => _node.SplitOffset = value; }
    /// <summary>
    /// <para>If <c>true</c>, the <see cref="SplitContainer" /> will arrange its children vertically, rather than horizontally.</para>
    /// <para>Can't be changed when using <see cref="HSplitContainer" /> and <see cref="VSplitContainer" />.</para>
    /// </summary>
    public bool Vertical { get => _node.Vertical; set => _node.Vertical = value; }

}