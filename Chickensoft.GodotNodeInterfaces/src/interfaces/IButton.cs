namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para><see cref="Button" /> is the standard themed button. It can contain text and an icon, and it will display them according to the current <see cref="Theme" />.</para>
/// <para><b>Example of creating a button and assigning an action when pressed by code:</b></para>
/// <para><code>
/// public override void _Ready()
/// {
/// var button = new Button();
/// button.Text = "Click me";
/// button.Pressed += ButtonPressed;
/// AddChild(button);
/// }
/// private void ButtonPressed()
/// {
/// GD.Print("Hello world!");
/// }
/// </code></para>
/// <para>See also <see cref="BaseButton" /> which contains common properties and methods associated with this node.</para>
/// <para><b>Note:</b> Buttons do not interpret touch input and therefore don't support multitouch, since mouse emulation can only press one button at a given time. Use <see cref="TouchScreenButton" /> for buttons that trigger gameplay movement or actions.</para>
/// </summary>
public interface IButton : IBaseButton {
    /// <summary>
    /// <para>The button's text that will be displayed inside the button's area.</para>
    /// </summary>
    string Text { get; set; }
    /// <summary>
    /// <para>Button's icon, if text is present the icon will be placed before the text.</para>
    /// <para>To edit margin and spacing of the icon, use <c>h_separation</c> theme property and <c>content_margin_*</c> properties of the used <see cref="StyleBox" />es.</para>
    /// </summary>
    Texture2D Icon { get; set; }
    /// <summary>
    /// <para>Flat buttons don't display decoration.</para>
    /// </summary>
    bool Flat { get; set; }
    /// <summary>
    /// <para>Text alignment policy for the button's text, use one of the <see cref="HorizontalAlignment" /> constants.</para>
    /// </summary>
    HorizontalAlignment Alignment { get; set; }
    /// <summary>
    /// <para>Sets the clipping behavior when the text exceeds the node's bounding rectangle. See <see cref="TextServer.OverrunBehavior" /> for a description of all modes.</para>
    /// </summary>
    TextServer.OverrunBehavior TextOverrunBehavior { get; set; }
    /// <summary>
    /// <para>When this property is enabled, text that is too large to fit the button is clipped, when disabled the Button will always be wide enough to hold the text.</para>
    /// </summary>
    bool ClipText { get; set; }
    /// <summary>
    /// <para>Specifies if the icon should be aligned horizontally to the left, right, or center of a button. Uses the same <see cref="HorizontalAlignment" /> constants as the text alignment. If centered horizontally and vertically, text will draw on top of the icon.</para>
    /// </summary>
    HorizontalAlignment IconAlignment { get; set; }
    /// <summary>
    /// <para>Specifies if the icon should be aligned vertically to the top, bottom, or center of a button. Uses the same <see cref="VerticalAlignment" /> constants as the text alignment. If centered horizontally and vertically, text will draw on top of the icon.</para>
    /// </summary>
    VerticalAlignment VerticalIconAlignment { get; set; }
    /// <summary>
    /// <para>When enabled, the button's icon will expand/shrink to fit the button's size while keeping its aspect. See also <c>icon_max_width</c>.</para>
    /// </summary>
    bool ExpandIcon { get; set; }
    /// <summary>
    /// <para>Base text writing direction.</para>
    /// </summary>
    Control.TextDirection TextDirection { get; set; }
    /// <summary>
    /// <para>Language code used for line-breaking and text shaping algorithms, if left empty current locale is used instead.</para>
    /// </summary>
    string Language { get; set; }

}