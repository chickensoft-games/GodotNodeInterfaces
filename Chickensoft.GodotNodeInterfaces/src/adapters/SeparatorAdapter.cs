namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para>Abstract base class for separators, used for separating other controls. <see cref="Separator" />s are purely visual and normally drawn as a <see cref="StyleBoxLine" />.</para>
/// </summary>
public class SeparatorAdapter : ControlAdapter, ISeparator {
  private readonly Separator _node;

  public SeparatorAdapter(Separator node) : base(node) { _node = node; }


}