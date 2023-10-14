namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para><see cref="CenterContainer" /> is a container that keeps all of its child controls in its center at their minimum size.</para>
/// </summary>
public class CenterContainerAdapter : CenterContainer, ICenterContainer {
  private readonly CenterContainer _node;

  public CenterContainerAdapter(CenterContainer node) => _node = node;
    /// <summary>
    /// <para>If <c>true</c>, centers children relative to the <see cref="CenterContainer" />'s top left corner.</para>
    /// </summary>
    public bool UseTopLeft { get => _node.UseTopLeft; set => _node.UseTopLeft = value; }

}