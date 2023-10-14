namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para>Displays a rectangle filled with a solid <see cref="ColorRect.Color" />. If you need to display the border alone, consider using a <see cref="Panel" /> instead.</para>
/// </summary>
public class ColorRectAdapter : ColorRect, IColorRect {
  private readonly ColorRect _node;

  public ColorRectAdapter(ColorRect node) => _node = node;
    /// <summary>
    /// <para>The fill color of the rectangle.</para>
    /// </summary>
    public Color Color { get => _node.Color; set => _node.Color = value; }

}