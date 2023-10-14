namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>A container that accepts only two child controls, then arranges them horizontally or vertically and creates a divisor between them. The divisor can be dragged around to change the size relation between the child controls.</para>
/// </summary>
public interface ISplitContainer : IContainer {
    /// <summary>
    /// <para>Clamps the <see cref="SplitContainer.SplitOffset" /> value to not go outside the currently possible minimal and maximum values.</para>
    /// </summary>
    void ClampSplitOffset();
    /// <summary>
    /// <para>The initial offset of the splitting between the two <see cref="Control" />s, with <c>0</c> being at the end of the first <see cref="Control" />.</para>
    /// </summary>
    int SplitOffset { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the area of the first <see cref="Control" /> will be collapsed and the dragger will be disabled.</para>
    /// </summary>
    bool Collapsed { get; set; }
    /// <summary>
    /// <para>Determines the dragger's visibility. See <see cref="SplitContainer.DraggerVisibilityEnum" /> for details.</para>
    /// </summary>
    SplitContainer.DraggerVisibilityEnum DraggerVisibility { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the <see cref="SplitContainer" /> will arrange its children vertically, rather than horizontally.</para>
    /// <para>Can't be changed when using <see cref="HSplitContainer" /> and <see cref="VSplitContainer" />.</para>
    /// </summary>
    bool Vertical { get; set; }

}