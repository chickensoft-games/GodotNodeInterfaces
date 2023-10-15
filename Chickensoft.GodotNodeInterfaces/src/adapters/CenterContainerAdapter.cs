namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para><see cref="CenterContainer" /> is a container that keeps all of its child controls in its center at their minimum size.</para>
/// </summary>
public class CenterContainerAdapter : ContainerAdapter, ICenterContainer {
  private readonly CenterContainer _node;

  public CenterContainerAdapter(Node node) : base(node) {
    if (node is not CenterContainer typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a CenterContainer"
      );
    }
    _node = typedNode;
  }

    /// <summary>
    /// <para>If <c>true</c>, centers children relative to the <see cref="CenterContainer" />'s top left corner.</para>
    /// </summary>
    public bool UseTopLeft { get => _node.UseTopLeft; set => _node.UseTopLeft = value; }

}