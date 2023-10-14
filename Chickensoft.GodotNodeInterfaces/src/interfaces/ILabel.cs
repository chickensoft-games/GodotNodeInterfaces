namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
using Godot.Collections;


/// <summary>
/// <para>A control for displaying plain text. It gives you control over the horizontal and vertical alignment and can wrap the text inside the node's bounding rectangle. It doesn't support bold, italics, or other rich text formatting. For that, use <see cref="RichTextLabel" /> instead.</para>
/// </summary>
public interface ILabel : IControl {
    /// <summary>
    /// <para>Returns the height of the line <paramref name="line" />.</para>
    /// <para>If <paramref name="line" /> is set to <c>-1</c>, returns the biggest line height.</para>
    /// <para>If there are no lines, returns font size in pixels.</para>
    /// </summary>
    int GetLineHeight(int line);
    /// <summary>
    /// <para>Returns the number of lines of text the Label has.</para>
    /// </summary>
    int GetLineCount();
    /// <summary>
    /// <para>Returns the number of lines shown. Useful if the <see cref="Label" />'s height cannot currently display all lines.</para>
    /// </summary>
    int GetVisibleLineCount();
    /// <summary>
    /// <para>Returns the total number of printable characters in the text (excluding spaces and newlines).</para>
    /// </summary>
    int GetTotalCharacterCount();
    /// <summary>
    /// <para>The text to display on screen.</para>
    /// </summary>
    string Text { get; set; }
    /// <summary>
    /// <para>A <see cref="LabelSettings" /> resource that can be shared between multiple <see cref="Label" /> nodes. Takes priority over theme properties.</para>
    /// </summary>
    LabelSettings LabelSettings { get; set; }
    /// <summary>
    /// <para>Controls the text's horizontal alignment. Supports left, center, right, and fill, or justify. Set it to one of the <see cref="HorizontalAlignment" /> constants.</para>
    /// </summary>
    HorizontalAlignment HorizontalAlignment { get; set; }
    /// <summary>
    /// <para>Controls the text's vertical alignment. Supports top, center, bottom, and fill. Set it to one of the <see cref="VerticalAlignment" /> constants.</para>
    /// </summary>
    VerticalAlignment VerticalAlignment { get; set; }
    /// <summary>
    /// <para>If set to something other than <see cref="TextServer.AutowrapMode.Off" />, the text gets wrapped inside the node's bounding rectangle. If you resize the node, it will change its height automatically to show all the text. To see how each mode behaves, see <see cref="TextServer.AutowrapMode" />.</para>
    /// </summary>
    TextServer.AutowrapMode AutowrapMode { get; set; }
    /// <summary>
    /// <para>Line fill alignment rules. For more info see <see cref="TextServer.JustificationFlag" />.</para>
    /// </summary>
    TextServer.JustificationFlag JustificationFlags { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the Label only shows the text that fits inside its bounding rectangle and will clip text horizontally.</para>
    /// </summary>
    bool ClipText { get; set; }
    /// <summary>
    /// <para>Sets the clipping behavior when the text exceeds the node's bounding rectangle. See <see cref="TextServer.OverrunBehavior" /> for a description of all modes.</para>
    /// </summary>
    TextServer.OverrunBehavior TextOverrunBehavior { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, all the text displays as UPPERCASE.</para>
    /// </summary>
    bool Uppercase { get; set; }
    /// <summary>
    /// <para>Aligns text to the given tab-stops.</para>
    /// </summary>
    float[] TabStops { get; set; }
    /// <summary>
    /// <para>The number of the lines ignored and not displayed from the start of the <see cref="Label.Text" /> value.</para>
    /// </summary>
    int LinesSkipped { get; set; }
    /// <summary>
    /// <para>Limits the lines of text the node shows on screen.</para>
    /// </summary>
    int MaxLinesVisible { get; set; }
    /// <summary>
    /// <para>The number of characters to display. If set to <c>-1</c>, all characters are displayed. This can be useful when animating the text appearing in a dialog box.</para>
    /// <para><b>Note:</b> Setting this property updates <see cref="Label.VisibleRatio" /> accordingly.</para>
    /// </summary>
    int VisibleCharacters { get; set; }
    /// <summary>
    /// <para>Sets the clipping behavior when <see cref="Label.VisibleCharacters" /> or <see cref="Label.VisibleRatio" /> is set. See <see cref="TextServer.VisibleCharactersBehavior" /> for more info.</para>
    /// </summary>
    TextServer.VisibleCharactersBehavior VisibleCharactersBehavior { get; set; }
    /// <summary>
    /// <para>The fraction of characters to display, relative to the total number of characters (see <see cref="Label.GetTotalCharacterCount" />). If set to <c>1.0</c>, all characters are displayed. If set to <c>0.5</c>, only half of the characters will be displayed. This can be useful when animating the text appearing in a dialog box.</para>
    /// <para><b>Note:</b> Setting this property updates <see cref="Label.VisibleCharacters" /> accordingly.</para>
    /// </summary>
    float VisibleRatio { get; set; }
    /// <summary>
    /// <para>Base text writing direction.</para>
    /// </summary>
    Control.TextDirection TextDirection { get; set; }
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

}