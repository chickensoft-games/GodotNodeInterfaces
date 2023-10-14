 namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A node that displays a 2D texture in a 3D environment. The texture displayed can be a region from a larger atlas texture, or a frame from a sprite sheet animation. See also <see cref="SpriteBase3D" /> where properties such as the billboard mode are defined.</para>
/// </summary>
public class Sprite3DAdapter : Sprite3D, ISprite3D {
  private readonly Sprite3D _node;

  public Sprite3DAdapter(Sprite3D node) => _node = node;
    /// <summary>
    /// <para>Current frame to display from sprite sheet. <see cref="Sprite3D.Hframes" /> or <see cref="Sprite3D.Vframes" /> must be greater than 1.</para>
    /// </summary>
    public int Frame { get => _node.Frame; set => _node.Frame = value; }
    /// <summary>
    /// <para>Coordinates of the frame to display from sprite sheet. This is as an alias for the <see cref="Sprite3D.Frame" /> property. <see cref="Sprite3D.Hframes" /> or <see cref="Sprite3D.Vframes" /> must be greater than 1.</para>
    /// </summary>
    public Vector2I FrameCoords { get => _node.FrameCoords; set => _node.FrameCoords = value; }
    /// <summary>
    /// <para>The number of columns in the sprite sheet.</para>
    /// </summary>
    public int Hframes { get => _node.Hframes; set => _node.Hframes = value; }
    /// <summary>
    /// <para>If <c>true</c>, the sprite will use <see cref="Sprite3D.RegionRect" /> and display only the specified part of its texture.</para>
    /// </summary>
    public bool RegionEnabled { get => _node.RegionEnabled; set => _node.RegionEnabled = value; }
    /// <summary>
    /// <para>The region of the atlas texture to display. <see cref="Sprite3D.RegionEnabled" /> must be <c>true</c>.</para>
    /// </summary>
    public Rect2 RegionRect { get => _node.RegionRect; set => _node.RegionRect = value; }
    /// <summary>
    /// <para><see cref="Texture2D" /> object to draw. If <see cref="GeometryInstance3D.MaterialOverride" /> is used, this will be overridden. The size information is still used.</para>
    /// </summary>
    public Texture2D Texture { get => _node.Texture; set => _node.Texture = value; }
    /// <summary>
    /// <para>The number of rows in the sprite sheet.</para>
    /// </summary>
    public int Vframes { get => _node.Vframes; set => _node.Vframes = value; }

}