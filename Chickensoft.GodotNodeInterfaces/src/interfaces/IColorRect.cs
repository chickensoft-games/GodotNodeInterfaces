namespace Chickensoft.GodotNodeInterfaces;

using Godot;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class ColorRectNode : ColorRect, IColorRect { }

/// <summary>
/// <para>Displays a rectangle filled with a solid <see cref="ColorRect.Color" />. If you need to display the border alone, consider using a <see cref="Panel" /> instead.</para>
/// </summary>
public interface IColorRect : IControl {
    /// <summary>
    /// <para>The fill color of the rectangle.</para>
    /// </summary>
    Color Color { get; set; }

}