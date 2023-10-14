 namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A container that arranges its child controls horizontally or vertically and wraps them around at the borders. This is similar to how text in a book wraps around when no more words can fit on a line.</para>
/// </summary>
public class FlowContainerAdapter : FlowContainer, IFlowContainer {
  private readonly FlowContainer _node;

  public FlowContainerAdapter(FlowContainer node) => _node = node;
    /// <summary>
    /// <para>The alignment of the container's children (must be one of <see cref="FlowContainer.AlignmentMode.Begin" />, <see cref="FlowContainer.AlignmentMode.Center" />, or <see cref="FlowContainer.AlignmentMode.End" />).</para>
    /// </summary>
    public FlowContainer.AlignmentMode Alignment { get => _node.Alignment; set => _node.Alignment = value; }
    /// <summary>
    /// <para>Returns the current line count.</para>
    /// </summary>
    public int GetLineCount() => _node.GetLineCount();
    /// <summary>
    /// <para>If <c>true</c>, the <see cref="FlowContainer" /> will arrange its children vertically, rather than horizontally.</para>
    /// <para>Can't be changed when using <see cref="HFlowContainer" /> and <see cref="VFlowContainer" />.</para>
    /// </summary>
    public bool Vertical { get => _node.Vertical; set => _node.Vertical = value; }

}