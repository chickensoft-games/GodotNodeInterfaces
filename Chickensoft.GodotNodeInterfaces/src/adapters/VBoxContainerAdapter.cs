 namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para>A variant of <see cref="BoxContainer" /> that can only arrange its child controls vertically. Child controls are rearranged automatically when their minimum size changes.</para>
/// </summary>
public class VBoxContainerAdapter : VBoxContainer, IVBoxContainer {
  private readonly VBoxContainer _node;

  public VBoxContainerAdapter(VBoxContainer node) => _node = node;

}