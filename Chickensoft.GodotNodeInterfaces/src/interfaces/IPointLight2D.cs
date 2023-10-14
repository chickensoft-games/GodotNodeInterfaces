namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>Casts light in a 2D environment. This light's shape is defined by a (usually grayscale) texture.</para>
/// </summary>
public interface IPointLight2D : ILight2D {
    /// <summary>
    /// <para><see cref="Texture2D" /> used for the light's appearance.</para>
    /// </summary>
    Texture2D Texture { get; set; }
    /// <summary>
    /// <para>The offset of the light's <see cref="PointLight2D.Texture" />.</para>
    /// </summary>
    Vector2 Offset { get; set; }
    /// <summary>
    /// <para>The <see cref="PointLight2D.Texture" />'s scale factor.</para>
    /// </summary>
    float TextureScale { get; set; }
    /// <summary>
    /// <para>The height of the light. Used with 2D normal mapping. The units are in pixels, e.g. if the height is 100, then it will illuminate an object 100 pixels away at a 45° angle to the plane.</para>
    /// </summary>
    float Height { get; set; }

}