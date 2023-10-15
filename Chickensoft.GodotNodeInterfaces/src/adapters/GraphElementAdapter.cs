namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para><see cref="GraphElement" /> allows to create custom elements for a <see cref="GraphEdit" /> graph. By default such elements can be selected, resized, and repositioned, but they cannot be connected. For a graph element that allows for connections see <see cref="GraphNode" />.</para>
/// </summary>
public class GraphElementAdapter : ContainerAdapter, IGraphElement {
  private readonly GraphElement _node;

  public GraphElementAdapter(Node node) : base(node) {
    if (node is not GraphElement typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a GraphElement"
      );
    }
    _node = typedNode;
  }

    /// <summary>
    /// <para>If <c>true</c>, the user can drag the GraphElement.</para>
    /// </summary>
    public bool Draggable { get => _node.Draggable; set => _node.Draggable = value; }
    /// <summary>
    /// <para>The offset of the GraphElement, relative to the scroll offset of the <see cref="GraphEdit" />.</para>
    /// </summary>
    public Vector2 PositionOffset { get => _node.PositionOffset; set => _node.PositionOffset = value; }
    /// <summary>
    /// <para>If <c>true</c>, the user can resize the GraphElement.</para>
    /// <para><b>Note:</b> Dragging the handle will only emit the <see cref="GraphElement.ResizeRequest" /> signal, the GraphElement needs to be resized manually.</para>
    /// </summary>
    public bool Resizable { get => _node.Resizable; set => _node.Resizable = value; }
    /// <summary>
    /// <para>If <c>true</c>, the user can select the GraphElement.</para>
    /// </summary>
    public bool Selectable { get => _node.Selectable; set => _node.Selectable = value; }
    /// <summary>
    /// <para>If <c>true</c>, the GraphElement is selected.</para>
    /// </summary>
    public bool Selected { get => _node.Selected; set => _node.Selected = value; }

}