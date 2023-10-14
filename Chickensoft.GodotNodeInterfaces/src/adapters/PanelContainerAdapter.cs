namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para>A container that keeps its child controls within the area of a <see cref="StyleBox" />. Useful for giving controls an outline.</para>
/// </summary>
public class PanelContainerAdapter : PanelContainer, IPanelContainer {
  private readonly PanelContainer _node;

  public PanelContainerAdapter(PanelContainer node) => _node = node;

}