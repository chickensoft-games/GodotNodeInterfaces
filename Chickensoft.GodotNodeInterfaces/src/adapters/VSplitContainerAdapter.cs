namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para>A container that accepts only two child controls, then arranges them vertically and creates a divisor between them. The divisor can be dragged around to change the size relation between the child controls.</para>
/// </summary>
public class VSplitContainerAdapter : SplitContainerAdapter, IVSplitContainer {
  private readonly VSplitContainer _node;

  public VSplitContainerAdapter(VSplitContainer node) : base(node) { _node = node; }


}