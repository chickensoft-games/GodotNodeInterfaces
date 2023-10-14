namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class Sprite2DNode : Sprite2D, ISprite2D { }

/// <summary>
/// <para>A node that displays a 2D texture. The texture displayed can be a region from a larger atlas texture, or a frame from a sprite sheet animation.</para>
/// </summary>
public interface ISprite2D : INode2D {
    /// <summary>
    /// <para>If <c>true</c>, texture is centered.</para>
    /// </summary>
    bool Centered { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, texture is flipped horizontally.</para>
    /// </summary>
    bool FlipH { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, texture is flipped vertically.</para>
    /// </summary>
    bool FlipV { get; set; }
    /// <summary>
    /// <para>Current frame to display from sprite sheet. <see cref="Sprite2D.Hframes" /> or <see cref="Sprite2D.Vframes" /> must be greater than 1.</para>
    /// </summary>
    int Frame { get; set; }
    /// <summary>
    /// <para>Coordinates of the frame to display from sprite sheet. This is as an alias for the <see cref="Sprite2D.Frame" /> property. <see cref="Sprite2D.Hframes" /> or <see cref="Sprite2D.Vframes" /> must be greater than 1.</para>
    /// </summary>
    Vector2I FrameCoords { get; set; }
    /// <summary>
    /// <para>Returns a <see cref="Rect2" /> representing the Sprite2D's boundary in local coordinates. Can be used to detect if the Sprite2D was clicked.</para>
    /// <para><b>Example:</b></para>
    /// <para><code>
    /// public override void _Input(InputEvent @event)
    /// {
    /// if (@event is InputEventMouseButton inputEventMouse)
    /// {
    /// if (inputEventMouse.Pressed &amp;&amp; inputEventMouse.ButtonIndex == MouseButton.Left)
    /// {
    /// if (GetRect().HasPoint(ToLocal(inputEventMouse.Position)))
    /// {
    /// GD.Print("A click!");
    /// }
    /// }
    /// }
    /// }
    /// </code></para>
    /// </summary>
    Rect2 GetRect();
    /// <summary>
    /// <para>The number of columns in the sprite sheet.</para>
    /// </summary>
    int Hframes { get; set; }
    /// <summary>
    /// <para>Returns <c>true</c>, if the pixel at the given position is opaque and <c>false</c> in other case.</para>
    /// <para><b>Note:</b> It also returns <c>false</c>, if the sprite's texture is <c>null</c> or if the given position is invalid.</para>
    /// </summary>
    bool IsPixelOpaque(Vector2 pos);
    /// <summary>
    /// <para>The texture's drawing offset.</para>
    /// </summary>
    Vector2 Offset { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, texture is cut from a larger atlas texture. See <see cref="Sprite2D.RegionRect" />.</para>
    /// </summary>
    bool RegionEnabled { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the outermost pixels get blurred out. <see cref="Sprite2D.RegionEnabled" /> must be <c>true</c>.</para>
    /// </summary>
    bool RegionFilterClipEnabled { get; set; }
    /// <summary>
    /// <para>The region of the atlas texture to display. <see cref="Sprite2D.RegionEnabled" /> must be <c>true</c>.</para>
    /// </summary>
    Rect2 RegionRect { get; set; }
    /// <summary>
    /// <para><see cref="Texture2D" /> object to draw.</para>
    /// </summary>
    Texture2D Texture { get; set; }
    /// <summary>
    /// <para>The number of rows in the sprite sheet.</para>
    /// </summary>
    int Vframes { get; set; }

}