namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para>A container that keeps its child controls within the area of a <see cref="StyleBox" />. Useful for giving controls an outline.</para>
/// </summary>
public class PanelContainerAdapter : ContainerAdapter, IPanelContainer {
  private readonly PanelContainer _node;

  public PanelContainerAdapter(PanelContainer node) : base(node) { _node = node; }


}