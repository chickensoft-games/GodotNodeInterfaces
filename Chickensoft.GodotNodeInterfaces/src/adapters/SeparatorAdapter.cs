namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para>Abstract base class for separators, used for separating other controls. <see cref="Separator" />s are purely visual and normally drawn as a <see cref="StyleBoxLine" />.</para>
/// </summary>
public class SeparatorAdapter : ControlAdapter, ISeparator {
  private readonly Separator _node;

  public SeparatorAdapter(Node node) : base(node) {
    if (node is not Separator typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a Separator"
      );
    }
    _node = typedNode;
  }


}