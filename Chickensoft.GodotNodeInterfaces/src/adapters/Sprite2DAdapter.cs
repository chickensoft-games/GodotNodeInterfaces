 namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A node that displays a 2D texture. The texture displayed can be a region from a larger atlas texture, or a frame from a sprite sheet animation.</para>
/// </summary>
public class Sprite2DAdapter : Sprite2D, ISprite2D {
  private readonly Sprite2D _node;

  public Sprite2DAdapter(Sprite2D node) => _node = node;
    /// <summary>
    /// <para>If <c>true</c>, texture is centered.</para>
    /// </summary>
    public bool Centered { get => _node.Centered; set => _node.Centered = value; }
    /// <summary>
    /// <para>If <c>true</c>, texture is flipped horizontally.</para>
    /// </summary>
    public bool FlipH { get => _node.FlipH; set => _node.FlipH = value; }
    /// <summary>
    /// <para>If <c>true</c>, texture is flipped vertically.</para>
    /// </summary>
    public bool FlipV { get => _node.FlipV; set => _node.FlipV = value; }
    /// <summary>
    /// <para>Current frame to display from sprite sheet. <see cref="Sprite2D.Hframes" /> or <see cref="Sprite2D.Vframes" /> must be greater than 1.</para>
    /// </summary>
    public int Frame { get => _node.Frame; set => _node.Frame = value; }
    /// <summary>
    /// <para>Coordinates of the frame to display from sprite sheet. This is as an alias for the <see cref="Sprite2D.Frame" /> property. <see cref="Sprite2D.Hframes" /> or <see cref="Sprite2D.Vframes" /> must be greater than 1.</para>
    /// </summary>
    public Vector2I FrameCoords { get => _node.FrameCoords; set => _node.FrameCoords = value; }
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
    public Rect2 GetRect() => _node.GetRect();
    /// <summary>
    /// <para>The number of columns in the sprite sheet.</para>
    /// </summary>
    public int Hframes { get => _node.Hframes; set => _node.Hframes = value; }
    /// <summary>
    /// <para>Returns <c>true</c>, if the pixel at the given position is opaque and <c>false</c> in other case.</para>
    /// <para><b>Note:</b> It also returns <c>false</c>, if the sprite's texture is <c>null</c> or if the given position is invalid.</para>
    /// </summary>
    public bool IsPixelOpaque(Vector2 pos) => _node.IsPixelOpaque(pos);
    /// <summary>
    /// <para>The texture's drawing offset.</para>
    /// </summary>
    public Vector2 Offset { get => _node.Offset; set => _node.Offset = value; }
    /// <summary>
    /// <para>If <c>true</c>, texture is cut from a larger atlas texture. See <see cref="Sprite2D.RegionRect" />.</para>
    /// </summary>
    public bool RegionEnabled { get => _node.RegionEnabled; set => _node.RegionEnabled = value; }
    /// <summary>
    /// <para>If <c>true</c>, the outermost pixels get blurred out. <see cref="Sprite2D.RegionEnabled" /> must be <c>true</c>.</para>
    /// </summary>
    public bool RegionFilterClipEnabled { get => _node.RegionFilterClipEnabled; set => _node.RegionFilterClipEnabled = value; }
    /// <summary>
    /// <para>The region of the atlas texture to display. <see cref="Sprite2D.RegionEnabled" /> must be <c>true</c>.</para>
    /// </summary>
    public Rect2 RegionRect { get => _node.RegionRect; set => _node.RegionRect = value; }
    /// <summary>
    /// <para><see cref="Texture2D" /> object to draw.</para>
    /// </summary>
    public Texture2D Texture { get => _node.Texture; set => _node.Texture = value; }
    /// <summary>
    /// <para>The number of rows in the sprite sheet.</para>
    /// </summary>
    public int Vframes { get => _node.Vframes; set => _node.Vframes = value; }

}