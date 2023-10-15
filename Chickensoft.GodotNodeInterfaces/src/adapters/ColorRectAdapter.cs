namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para>Displays a rectangle filled with a solid <see cref="ColorRect.Color" />. If you need to display the border alone, consider using a <see cref="Panel" /> instead.</para>
/// </summary>
public class ColorRectAdapter : ControlAdapter, IColorRect {
  private readonly ColorRect _node;

  public ColorRectAdapter(Node node) : base(node) {
    if (node is not ColorRect typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a ColorRect"
      );
    }
    _node = typedNode;
  }

    /// <summary>
    /// <para>The fill color of the rectangle.</para>
    /// </summary>
    public Color Color { get => _node.Color; set => _node.Color = value; }

}