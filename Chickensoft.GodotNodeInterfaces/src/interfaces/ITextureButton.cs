namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para><see cref="TextureButton" /> has the same functionality as <see cref="Button" />, except it uses sprites instead of Godot's <see cref="Theme" /> resource. It is faster to create, but it doesn't support localization like more complex <see cref="Control" />s.</para>
/// <para>The "normal" state must contain a texture (<see cref="TextureButton.TextureNormal" />); other textures are optional.</para>
/// <para>See also <see cref="BaseButton" /> which contains common properties and methods associated with this node.</para>
/// </summary>
public interface ITextureButton : IBaseButton {
    /// <summary>
    /// <para>Texture to display by default, when the node is <b>not</b> in the disabled, hover or pressed state. This texture is still displayed in the focused state, with <see cref="TextureButton.TextureFocused" /> drawn on top.</para>
    /// </summary>
    Texture2D TextureNormal { get; set; }
    /// <summary>
    /// <para>Texture to display on mouse down over the node, if the node has keyboard focus and the player presses the Enter key or if the player presses the <see cref="BaseButton.Shortcut" /> key.</para>
    /// </summary>
    Texture2D TexturePressed { get; set; }
    /// <summary>
    /// <para>Texture to display when the mouse hovers the node.</para>
    /// </summary>
    Texture2D TextureHover { get; set; }
    /// <summary>
    /// <para>Texture to display when the node is disabled. See <see cref="BaseButton.Disabled" />.</para>
    /// </summary>
    Texture2D TextureDisabled { get; set; }
    /// <summary>
    /// <para>Texture to display when the node has mouse or keyboard focus. <see cref="TextureButton.TextureFocused" /> is displayed <i>over</i> the base texture, so a partially transparent texture should be used to ensure the base texture remains visible. A texture that represents an outline or an underline works well for this purpose. To disable the focus visual effect, assign a fully transparent texture of any size. Note that disabling the focus visual effect will harm keyboard/controller navigation usability, so this is not recommended for accessibility reasons.</para>
    /// </summary>
    Texture2D TextureFocused { get; set; }
    /// <summary>
    /// <para>Pure black and white <see cref="Bitmap" /> image to use for click detection. On the mask, white pixels represent the button's clickable area. Use it to create buttons with curved shapes.</para>
    /// </summary>
    Bitmap TextureClickMask { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the size of the texture won't be considered for minimum size calculation, so the <see cref="TextureButton" /> can be shrunk down past the texture size.</para>
    /// </summary>
    bool IgnoreTextureSize { get; set; }
    /// <summary>
    /// <para>Controls the texture's behavior when you resize the node's bounding rectangle. See the <see cref="TextureButton.StretchModeEnum" /> constants for available options.</para>
    /// </summary>
    TextureButton.StretchModeEnum StretchMode { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, texture is flipped horizontally.</para>
    /// </summary>
    bool FlipH { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, texture is flipped vertically.</para>
    /// </summary>
    bool FlipV { get; set; }

}