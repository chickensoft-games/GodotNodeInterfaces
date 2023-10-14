namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class FlowContainerNode : FlowContainer, IFlowContainer { }

/// <summary>
/// <para>A container that arranges its child controls horizontally or vertically and wraps them around at the borders. This is similar to how text in a book wraps around when no more words can fit on a line.</para>
/// </summary>
public interface IFlowContainer : IContainer {
    /// <summary>
    /// <para>The alignment of the container's children (must be one of <see cref="FlowContainer.AlignmentMode.Begin" />, <see cref="FlowContainer.AlignmentMode.Center" />, or <see cref="FlowContainer.AlignmentMode.End" />).</para>
    /// </summary>
    FlowContainer.AlignmentMode Alignment { get; set; }
    /// <summary>
    /// <para>Returns the current line count.</para>
    /// </summary>
    int GetLineCount();
    /// <summary>
    /// <para>If <c>true</c>, the <see cref="FlowContainer" /> will arrange its children vertically, rather than horizontally.</para>
    /// <para>Can't be changed when using <see cref="HFlowContainer" /> and <see cref="VFlowContainer" />.</para>
    /// </summary>
    bool Vertical { get; set; }

}