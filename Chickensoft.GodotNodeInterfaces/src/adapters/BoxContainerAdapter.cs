namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A container that arranges its child controls horizontally or vertically, rearranging them automatically when their minimum size changes.</para>
/// </summary>
public class BoxContainerAdapter : ContainerAdapter, IBoxContainer {
  private readonly BoxContainer _node;

  public BoxContainerAdapter(Node node) : base(node) {
    if (node is not BoxContainer typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a BoxContainer"
      );
    }
    _node = typedNode;
  }

    /// <summary>
    /// <para>Adds a <see cref="Control" /> node to the box as a spacer. If <paramref name="begin" /> is <c>true</c>, it will insert the <see cref="Control" /> node in front of all other children.</para>
    /// </summary>
    public Control AddSpacer(bool begin) => _node.AddSpacer(begin);
    /// <summary>
    /// <para>The alignment of the container's children (must be one of <see cref="BoxContainer.AlignmentMode.Begin" />, <see cref="BoxContainer.AlignmentMode.Center" />, or <see cref="BoxContainer.AlignmentMode.End" />).</para>
    /// </summary>
    public BoxContainer.AlignmentMode Alignment { get => _node.Alignment; set => _node.Alignment = value; }
    /// <summary>
    /// <para>If <c>true</c>, the <see cref="BoxContainer" /> will arrange its children vertically, rather than horizontally.</para>
    /// <para>Can't be changed when using <see cref="HBoxContainer" /> and <see cref="VBoxContainer" />.</para>
    /// </summary>
    public bool Vertical { get => _node.Vertical; set => _node.Vertical = value; }

}