namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para>A horizontal separator used for separating other controls that are arranged <b>vertically</b>. <see cref="HSeparator" /> is purely visual and normally drawn as a <see cref="StyleBoxLine" />.</para>
/// </summary>
public class HSeparatorAdapter : SeparatorAdapter, IHSeparator {
  private readonly HSeparator _node;

  public HSeparatorAdapter(Node node) : base(node) {
    if (node is not HSeparator typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a HSeparator"
      );
    }
    _node = typedNode;
  }


}