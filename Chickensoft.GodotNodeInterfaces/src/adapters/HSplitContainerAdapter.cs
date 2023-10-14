namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para>A container that accepts only two child controls, then arranges them horizontally and creates a divisor between them. The divisor can be dragged around to change the size relation between the child controls.</para>
/// </summary>
public class HSplitContainerAdapter : HSplitContainer, IHSplitContainer {
  private readonly HSplitContainer _node;

  public HSplitContainerAdapter(HSplitContainer node) => _node = node;

}