namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
using Godot.Collections;
/// <summary>
/// <para>A control for displaying plain text. It gives you control over the horizontal and vertical alignment and can wrap the text inside the node's bounding rectangle. It doesn't support bold, italics, or other rich text formatting. For that, use <see cref="RichTextLabel" /> instead.</para>
/// </summary>
public class LabelAdapter : Label, ILabel {
  private readonly Label _node;

  public LabelAdapter(Label node) => _node = node;
    /// <summary>
    /// <para>If set to something other than <see cref="TextServer.AutowrapMode.Off" />, the text gets wrapped inside the node's bounding rectangle. If you resize the node, it will change its height automatically to show all the text. To see how each mode behaves, see <see cref="TextServer.AutowrapMode" />.</para>
    /// </summary>
    public TextServer.AutowrapMode AutowrapMode { get => _node.AutowrapMode; set => _node.AutowrapMode = value; }
    /// <summary>
    /// <para>If <c>true</c>, the Label only shows the text that fits inside its bounding rectangle and will clip text horizontally.</para>
    /// </summary>
    public bool ClipText { get => _node.ClipText; set => _node.ClipText = value; }
    /// <summary>
    /// <para>Returns the number of lines of text the Label has.</para>
    /// </summary>
    public int GetLineCount() => _node.GetLineCount();
    /// <summary>
    /// <para>Returns the height of the line <paramref name="line" />.</para>
    /// <para>If <paramref name="line" /> is set to <c>-1</c>, returns the biggest line height.</para>
    /// <para>If there are no lines, returns font size in pixels.</para>
    /// </summary>
    public int GetLineHeight(int line) => _node.GetLineHeight(line);
    /// <summary>
    /// <para>Returns the total number of printable characters in the text (excluding spaces and newlines).</para>
    /// </summary>
    public int GetTotalCharacterCount() => _node.GetTotalCharacterCount();
    /// <summary>
    /// <para>Returns the number of lines shown. Useful if the <see cref="Label" />'s height cannot currently display all lines.</para>
    /// </summary>
    public int GetVisibleLineCount() => _node.GetVisibleLineCount();
    /// <summary>
    /// <para>Controls the text's horizontal alignment. Supports left, center, right, and fill, or justify. Set it to one of the <see cref="HorizontalAlignment" /> constants.</para>
    /// </summary>
    public HorizontalAlignment HorizontalAlignment { get => _node.HorizontalAlignment; set => _node.HorizontalAlignment = value; }
    /// <summary>
    /// <para>Line fill alignment rules. For more info see <see cref="TextServer.JustificationFlag" />.</para>
    /// </summary>
    public TextServer.JustificationFlag JustificationFlags { get => _node.JustificationFlags; set => _node.JustificationFlags = value; }
    /// <summary>
    /// <para>A <see cref="LabelSettings" /> resource that can be shared between multiple <see cref="Label" /> nodes. Takes priority over theme properties.</para>
    /// </summary>
    public LabelSettings LabelSettings { get => _node.LabelSettings; set => _node.LabelSettings = value; }
    /// <summary>
    /// <para>Language code used for line-breaking and text shaping algorithms, if left empty current locale is used instead.</para>
    /// </summary>
    public string Language { get => _node.Language; set => _node.Language = value; }
    /// <summary>
    /// <para>The number of the lines ignored and not displayed from the start of the <see cref="Label.Text" /> value.</para>
    /// </summary>
    public int LinesSkipped { get => _node.LinesSkipped; set => _node.LinesSkipped = value; }
    /// <summary>
    /// <para>Limits the lines of text the node shows on screen.</para>
    /// </summary>
    public int MaxLinesVisible { get => _node.MaxLinesVisible; set => _node.MaxLinesVisible = value; }
    /// <summary>
    /// <para>Set BiDi algorithm override for the structured text.</para>
    /// </summary>
    public TextServer.StructuredTextParser StructuredTextBidiOverride { get => _node.StructuredTextBidiOverride; set => _node.StructuredTextBidiOverride = value; }
    /// <summary>
    /// <para>Set additional options for BiDi override.</para>
    /// </summary>
    public Godot.Collections.Array StructuredTextBidiOverrideOptions { get => _node.StructuredTextBidiOverrideOptions; set => _node.StructuredTextBidiOverrideOptions = value; }
    /// <summary>
    /// <para>Aligns text to the given tab-stops.</para>
    /// </summary>
    public float[] TabStops { get => _node.TabStops; set => _node.TabStops = value; }
    /// <summary>
    /// <para>The text to display on screen.</para>
    /// </summary>
    public string Text { get => _node.Text; set => _node.Text = value; }
    /// <summary>
    /// <para>Base text writing direction.</para>
    /// </summary>
    public Control.TextDirection TextDirection { get => _node.TextDirection; set => _node.TextDirection = value; }
    /// <summary>
    /// <para>Sets the clipping behavior when the text exceeds the node's bounding rectangle. See <see cref="TextServer.OverrunBehavior" /> for a description of all modes.</para>
    /// </summary>
    public TextServer.OverrunBehavior TextOverrunBehavior { get => _node.TextOverrunBehavior; set => _node.TextOverrunBehavior = value; }
    /// <summary>
    /// <para>If <c>true</c>, all the text displays as UPPERCASE.</para>
    /// </summary>
    public bool Uppercase { get => _node.Uppercase; set => _node.Uppercase = value; }
    /// <summary>
    /// <para>Controls the text's vertical alignment. Supports top, center, bottom, and fill. Set it to one of the <see cref="VerticalAlignment" /> constants.</para>
    /// </summary>
    public VerticalAlignment VerticalAlignment { get => _node.VerticalAlignment; set => _node.VerticalAlignment = value; }
    /// <summary>
    /// <para>The number of characters to display. If set to <c>-1</c>, all characters are displayed. This can be useful when animating the text appearing in a dialog box.</para>
    /// <para><b>Note:</b> Setting this property updates <see cref="Label.VisibleRatio" /> accordingly.</para>
    /// </summary>
    public int VisibleCharacters { get => _node.VisibleCharacters; set => _node.VisibleCharacters = value; }
    /// <summary>
    /// <para>Sets the clipping behavior when <see cref="Label.VisibleCharacters" /> or <see cref="Label.VisibleRatio" /> is set. See <see cref="TextServer.VisibleCharactersBehavior" /> for more info.</para>
    /// </summary>
    public TextServer.VisibleCharactersBehavior VisibleCharactersBehavior { get => _node.VisibleCharactersBehavior; set => _node.VisibleCharactersBehavior = value; }
    /// <summary>
    /// <para>The fraction of characters to display, relative to the total number of characters (see <see cref="Label.GetTotalCharacterCount" />). If set to <c>1.0</c>, all characters are displayed. If set to <c>0.5</c>, only half of the characters will be displayed. This can be useful when animating the text appearing in a dialog box.</para>
    /// <para><b>Note:</b> Setting this property updates <see cref="Label.VisibleCharacters" /> accordingly.</para>
    /// </summary>
    public float VisibleRatio { get => _node.VisibleRatio; set => _node.VisibleRatio = value; }

}