namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para><see cref="GraphElement" /> allows to create custom elements for a <see cref="GraphEdit" /> graph. By default such elements can be selected, resized, and repositioned, but they cannot be connected. For a graph element that allows for connections see <see cref="GraphNode" />.</para>
/// </summary>
public interface IGraphElement : IContainer {
    /// <summary>
    /// <para>The offset of the GraphElement, relative to the scroll offset of the <see cref="GraphEdit" />.</para>
    /// </summary>
    Vector2 PositionOffset { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the user can resize the GraphElement.</para>
    /// <para><b>Note:</b> Dragging the handle will only emit the <see cref="GraphElement.ResizeRequest" /> signal, the GraphElement needs to be resized manually.</para>
    /// </summary>
    bool Resizable { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the user can drag the GraphElement.</para>
    /// </summary>
    bool Draggable { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the user can select the GraphElement.</para>
    /// </summary>
    bool Selectable { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the GraphElement is selected.</para>
    /// </summary>
    bool Selected { get; set; }

}