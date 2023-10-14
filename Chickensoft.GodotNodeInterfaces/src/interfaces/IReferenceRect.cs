namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class ReferenceRectNode : ReferenceRect, IReferenceRect { }

/// <summary>
/// <para>A rectangle box that displays only a colored border around its rectangle. It is used to visualize the extents of a <see cref="Control" />.</para>
/// </summary>
public interface IReferenceRect : IControl {
    /// <summary>
    /// <para>Sets the border color of the <see cref="ReferenceRect" />.</para>
    /// </summary>
    Color BorderColor { get; set; }
    /// <summary>
    /// <para>Sets the border width of the <see cref="ReferenceRect" />. The border grows both inwards and outwards with respect to the rectangle box.</para>
    /// </summary>
    float BorderWidth { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the <see cref="ReferenceRect" /> will only be visible while in editor. Otherwise, <see cref="ReferenceRect" /> will be visible in the running project.</para>
    /// </summary>
    bool EditorOnly { get; set; }

}