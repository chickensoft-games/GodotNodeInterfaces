namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>A node that displays a 2D texture in a 3D environment. The texture displayed can be a region from a larger atlas texture, or a frame from a sprite sheet animation. See also <see cref="SpriteBase3D" /> where properties such as the billboard mode are defined.</para>
/// </summary>
public interface ISprite3D : ISpriteBase3D {
    /// <summary>
    /// <para><see cref="Texture2D" /> object to draw. If <see cref="GeometryInstance3D.MaterialOverride" /> is used, this will be overridden. The size information is still used.</para>
    /// </summary>
    Texture2D Texture { get; set; }
    /// <summary>
    /// <para>The number of columns in the sprite sheet.</para>
    /// </summary>
    int Hframes { get; set; }
    /// <summary>
    /// <para>The number of rows in the sprite sheet.</para>
    /// </summary>
    int Vframes { get; set; }
    /// <summary>
    /// <para>Current frame to display from sprite sheet. <see cref="Sprite3D.Hframes" /> or <see cref="Sprite3D.Vframes" /> must be greater than 1.</para>
    /// </summary>
    int Frame { get; set; }
    /// <summary>
    /// <para>Coordinates of the frame to display from sprite sheet. This is as an alias for the <see cref="Sprite3D.Frame" /> property. <see cref="Sprite3D.Hframes" /> or <see cref="Sprite3D.Vframes" /> must be greater than 1.</para>
    /// </summary>
    Vector2I FrameCoords { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the sprite will use <see cref="Sprite3D.RegionRect" /> and display only the specified part of its texture.</para>
    /// </summary>
    bool RegionEnabled { get; set; }
    /// <summary>
    /// <para>The region of the atlas texture to display. <see cref="Sprite3D.RegionEnabled" /> must be <c>true</c>.</para>
    /// </summary>
    Rect2 RegionRect { get; set; }

}