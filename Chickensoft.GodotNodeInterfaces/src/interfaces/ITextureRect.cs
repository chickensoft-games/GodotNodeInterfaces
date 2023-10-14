namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>A control that displays a texture, for example an icon inside a GUI. The texture's placement can be controlled with the <see cref="TextureRect.StretchMode" /> property. It can scale, tile, or stay centered inside its bounding rectangle.</para>
/// </summary>
public interface ITextureRect : IControl {
    /// <summary>
    /// <para>The node's <see cref="Texture2D" /> resource.</para>
    /// </summary>
    Texture2D Texture { get; set; }
    /// <summary>
    /// <para>Defines how minimum size is determined based on the texture's size. See <see cref="TextureRect.ExpandModeEnum" /> for options.</para>
    /// <para><b>Note:</b> Using <see cref="TextureRect.ExpandModeEnum.FitWidth" />, <see cref="TextureRect.ExpandModeEnum.FitWidthProportional" />, <see cref="TextureRect.ExpandModeEnum.FitHeight" /> or <see cref="TextureRect.ExpandModeEnum.FitHeightProportional" /> may result in unstable behavior in some containers. This functionality is being re-evaluated and will change in the future.</para>
    /// </summary>
    TextureRect.ExpandModeEnum ExpandMode { get; set; }
    /// <summary>
    /// <para>Controls the texture's behavior when resizing the node's bounding rectangle. See <see cref="TextureRect.StretchModeEnum" />.</para>
    /// </summary>
    TextureRect.StretchModeEnum StretchMode { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, texture is flipped horizontally.</para>
    /// </summary>
    bool FlipH { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, texture is flipped vertically.</para>
    /// </summary>
    bool FlipV { get; set; }

}