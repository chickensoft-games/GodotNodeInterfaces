namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>Casts light in a 2D environment. This light's shape is defined by a (usually grayscale) texture.</para>
/// </summary>
public class PointLight2DAdapter : Light2DAdapter, IPointLight2D {
  private readonly PointLight2D _node;

  public PointLight2DAdapter(PointLight2D node) : base(node) { _node = node; }

    /// <summary>
    /// <para>The height of the light. Used with 2D normal mapping. The units are in pixels, e.g. if the height is 100, then it will illuminate an object 100 pixels away at a 45° angle to the plane.</para>
    /// </summary>
    public float Height { get => _node.Height; set => _node.Height = value; }
    /// <summary>
    /// <para>The offset of the light's <see cref="PointLight2D.Texture" />.</para>
    /// </summary>
    public Vector2 Offset { get => _node.Offset; set => _node.Offset = value; }
    /// <summary>
    /// <para><see cref="Texture2D" /> used for the light's appearance.</para>
    /// </summary>
    public Texture2D Texture { get => _node.Texture; set => _node.Texture = value; }
    /// <summary>
    /// <para>The <see cref="PointLight2D.Texture" />'s scale factor.</para>
    /// </summary>
    public float TextureScale { get => _node.TextureScale; set => _node.TextureScale = value; }

}