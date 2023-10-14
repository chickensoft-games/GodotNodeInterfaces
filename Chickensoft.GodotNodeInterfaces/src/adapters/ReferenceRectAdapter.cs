 namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A rectangle box that displays only a colored border around its rectangle. It is used to visualize the extents of a <see cref="Control" />.</para>
/// </summary>
public class ReferenceRectAdapter : ReferenceRect, IReferenceRect {
  private readonly ReferenceRect _node;

  public ReferenceRectAdapter(ReferenceRect node) => _node = node;
    /// <summary>
    /// <para>Sets the border color of the <see cref="ReferenceRect" />.</para>
    /// </summary>
    public Color BorderColor { get => _node.BorderColor; set => _node.BorderColor = value; }
    /// <summary>
    /// <para>Sets the border width of the <see cref="ReferenceRect" />. The border grows both inwards and outwards with respect to the rectangle box.</para>
    /// </summary>
    public float BorderWidth { get => _node.BorderWidth; set => _node.BorderWidth = value; }
    /// <summary>
    /// <para>If <c>true</c>, the <see cref="ReferenceRect" /> will only be visible while in editor. Otherwise, <see cref="ReferenceRect" /> will be visible in the running project.</para>
    /// </summary>
    public bool EditorOnly { get => _node.EditorOnly; set => _node.EditorOnly = value; }

}