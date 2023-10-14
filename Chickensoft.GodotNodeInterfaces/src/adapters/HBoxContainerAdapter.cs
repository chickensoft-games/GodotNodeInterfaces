 namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para>A variant of <see cref="BoxContainer" /> that can only arrange its child controls horizontally. Child controls are rearranged automatically when their minimum size changes.</para>
/// </summary>
public class HBoxContainerAdapter : HBoxContainer, IHBoxContainer {
  private readonly HBoxContainer _node;

  public HBoxContainerAdapter(HBoxContainer node) => _node = node;

}