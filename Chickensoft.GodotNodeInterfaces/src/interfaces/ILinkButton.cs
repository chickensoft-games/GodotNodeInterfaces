namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
using Godot.Collections;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class LinkButtonNode : LinkButton, ILinkButton { }

/// <summary>
/// <para>A button that represents a link. This type of button is primarily used for interactions that cause a context change (like linking to a web page).</para>
/// <para>See also <see cref="BaseButton" /> which contains common properties and methods associated with this node.</para>
/// </summary>
public interface ILinkButton : IBaseButton {
    /// <summary>
    /// <para>Language code used for line-breaking and text shaping algorithms, if left empty current locale is used instead.</para>
    /// </summary>
    string Language { get; set; }
    /// <summary>
    /// <para>Set BiDi algorithm override for the structured text.</para>
    /// </summary>
    TextServer.StructuredTextParser StructuredTextBidiOverride { get; set; }
    /// <summary>
    /// <para>Set additional options for BiDi override.</para>
    /// </summary>
    Godot.Collections.Array StructuredTextBidiOverrideOptions { get; set; }
    /// <summary>
    /// <para>The button's text that will be displayed inside the button's area.</para>
    /// </summary>
    string Text { get; set; }
    /// <summary>
    /// <para>Base text writing direction.</para>
    /// </summary>
    Control.TextDirection TextDirection { get; set; }
    /// <summary>
    /// <para>The underline mode to use for the text. See <see cref="LinkButton.UnderlineMode" /> for the available modes.</para>
    /// </summary>
    LinkButton.UnderlineMode Underline { get; set; }
    /// <summary>
    /// <para>The <a href="https://en.wikipedia.org/wiki/Uniform_Resource_Identifier">URI</a> for this <see cref="LinkButton" />. If set to a valid URI, pressing the button opens the URI using the operating system's default program for the protocol (via <see cref="OS.ShellOpen(System.String)" />). HTTP and HTTPS URLs open the default web browser.</para>
    /// <para><b>Examples:</b></para>
    /// <para><code>
    /// Uri = "https://godotengine.org"; // Opens the URL in the default web browser.
    /// Uri = "C:\SomeFolder"; // Opens the file explorer at the given path.
    /// Uri = "C:\SomeImage.png"; // Opens the given image in the default viewing app.
    /// </code></para>
    /// </summary>
    string Uri { get; set; }

}