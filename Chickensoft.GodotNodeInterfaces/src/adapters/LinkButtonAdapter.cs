namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
using Godot.Collections;
/// <summary>
/// <para>A button that represents a link. This type of button is primarily used for interactions that cause a context change (like linking to a web page).</para>
/// <para>See also <see cref="BaseButton" /> which contains common properties and methods associated with this node.</para>
/// </summary>
public class LinkButtonAdapter : BaseButtonAdapter, ILinkButton {
  private readonly LinkButton _node;

  public LinkButtonAdapter(Node node) : base(node) {
    if (node is not LinkButton typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a LinkButton"
      );
    }
    _node = typedNode;
  }

    /// <summary>
    /// <para>Language code used for line-breaking and text shaping algorithms, if left empty current locale is used instead.</para>
    /// </summary>
    public string Language { get => _node.Language; set => _node.Language = value; }
    /// <summary>
    /// <para>Set BiDi algorithm override for the structured text.</para>
    /// </summary>
    public TextServer.StructuredTextParser StructuredTextBidiOverride { get => _node.StructuredTextBidiOverride; set => _node.StructuredTextBidiOverride = value; }
    /// <summary>
    /// <para>Set additional options for BiDi override.</para>
    /// </summary>
    public Godot.Collections.Array StructuredTextBidiOverrideOptions { get => _node.StructuredTextBidiOverrideOptions; set => _node.StructuredTextBidiOverrideOptions = value; }
    /// <summary>
    /// <para>The button's text that will be displayed inside the button's area.</para>
    /// </summary>
    public string Text { get => _node.Text; set => _node.Text = value; }
    /// <summary>
    /// <para>Base text writing direction.</para>
    /// </summary>
    public Control.TextDirection TextDirection { get => _node.TextDirection; set => _node.TextDirection = value; }
    /// <summary>
    /// <para>The underline mode to use for the text. See <see cref="LinkButton.UnderlineMode" /> for the available modes.</para>
    /// </summary>
    public LinkButton.UnderlineMode Underline { get => _node.Underline; set => _node.Underline = value; }
    /// <summary>
    /// <para>The <a href="https://en.wikipedia.org/wiki/Uniform_Resource_Identifier">URI</a> for this <see cref="LinkButton" />. If set to a valid URI, pressing the button opens the URI using the operating system's default program for the protocol (via <see cref="OS.ShellOpen(System.String)" />). HTTP and HTTPS URLs open the default web browser.</para>
    /// <para><b>Examples:</b></para>
    /// <para><code>
    /// Uri = "https://godotengine.org"; // Opens the URL in the default web browser.
    /// Uri = "C:\SomeFolder"; // Opens the file explorer at the given path.
    /// Uri = "C:\SomeImage.png"; // Opens the given image in the default viewing app.
    /// </code></para>
    /// </summary>
    public string Uri { get => _node.Uri; set => _node.Uri = value; }

}