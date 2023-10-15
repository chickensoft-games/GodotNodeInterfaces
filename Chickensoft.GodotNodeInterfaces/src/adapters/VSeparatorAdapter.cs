namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para>A vertical separator used for separating other controls that are arranged <b>horizontally</b>. <see cref="VSeparator" /> is purely visual and normally drawn as a <see cref="StyleBoxLine" />.</para>
/// </summary>
public class VSeparatorAdapter : SeparatorAdapter, IVSeparator {
  private readonly VSeparator _node;

  public VSeparatorAdapter(Node node) : base(node) {
    if (node is not VSeparator typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a VSeparator"
      );
    }
    _node = typedNode;
  }


}