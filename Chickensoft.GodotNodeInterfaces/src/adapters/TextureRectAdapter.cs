 namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A control that displays a texture, for example an icon inside a GUI. The texture's placement can be controlled with the <see cref="TextureRect.StretchMode" /> property. It can scale, tile, or stay centered inside its bounding rectangle.</para>
/// </summary>
public class TextureRectAdapter : TextureRect, ITextureRect {
  private readonly TextureRect _node;

  public TextureRectAdapter(TextureRect node) => _node = node;
    /// <summary>
    /// <para>Defines how minimum size is determined based on the texture's size. See <see cref="TextureRect.ExpandModeEnum" /> for options.</para>
    /// <para><b>Note:</b> Using <see cref="TextureRect.ExpandModeEnum.FitWidth" />, <see cref="TextureRect.ExpandModeEnum.FitWidthProportional" />, <see cref="TextureRect.ExpandModeEnum.FitHeight" /> or <see cref="TextureRect.ExpandModeEnum.FitHeightProportional" /> may result in unstable behavior in some containers. This functionality is being re-evaluated and will change in the future.</para>
    /// </summary>
    public TextureRect.ExpandModeEnum ExpandMode { get => _node.ExpandMode; set => _node.ExpandMode = value; }
    /// <summary>
    /// <para>If <c>true</c>, texture is flipped horizontally.</para>
    /// </summary>
    public bool FlipH { get => _node.FlipH; set => _node.FlipH = value; }
    /// <summary>
    /// <para>If <c>true</c>, texture is flipped vertically.</para>
    /// </summary>
    public bool FlipV { get => _node.FlipV; set => _node.FlipV = value; }
    /// <summary>
    /// <para>Controls the texture's behavior when resizing the node's bounding rectangle. See <see cref="TextureRect.StretchModeEnum" />.</para>
    /// </summary>
    public TextureRect.StretchModeEnum StretchMode { get => _node.StretchMode; set => _node.StretchMode = value; }
    /// <summary>
    /// <para>The node's <see cref="Texture2D" /> resource.</para>
    /// </summary>
    public Texture2D Texture { get => _node.Texture; set => _node.Texture = value; }

}