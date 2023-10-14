namespace Chickensoft.GodotNodeInterfaces;

using Godot;


/// <summary>
/// <para>Displays a rectangle filled with a solid <see cref="ColorRect.Color" />. If you need to display the border alone, consider using a <see cref="Panel" /> instead.</para>
/// </summary>
public interface IColorRect : IControl {
    /// <summary>
    /// <para>The fill color of the rectangle.</para>
    /// </summary>
    Color Color { get; set; }

}