namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
using Godot.Collections;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class RichTextLabelNode : RichTextLabel, IRichTextLabel { }

/// <summary>
/// <para>A control for displaying text that can contain custom fonts, images, and basic formatting. <see cref="RichTextLabel" /> manages these as an internal tag stack. It also adapts itself to given width/heights.</para>
/// <para><b>Note:</b> Assignments to <see cref="RichTextLabel.Text" /> clear the tag stack and reconstruct it from the property's contents. Any edits made to <see cref="RichTextLabel.Text" /> will erase previous edits made from other manual sources such as <see cref="RichTextLabel.AppendText(System.String)" /> and the <c>push_*</c> / <see cref="RichTextLabel.Pop" /> methods.</para>
/// <para><b>Note:</b> RichTextLabel doesn't support entangled BBCode tags. For example, instead of using <c>[b]bold[i]bold italic[/b]italic[/i]</c>, use <c>[b]bold[i]bold italic[/i][/b][i]italic[/i]</c>.</para>
/// <para><b>Note:</b> <c>push_*/pop_*</c> functions won't affect BBCode.</para>
/// <para><b>Note:</b> Unlike <see cref="Label" />, <see cref="RichTextLabel" /> doesn't have a <i>property</i> to horizontally align text to the center. Instead, enable <see cref="RichTextLabel.BbcodeEnabled" /> and surround the text in a <c>[center]</c> tag as follows: <c>[center]Example[/center]</c>. There is currently no built-in way to vertically align text either, but this can be emulated by relying on anchors/containers and the <see cref="RichTextLabel.FitContent" /> property.</para>
/// </summary>
public interface IRichTextLabel : IControl {
    /// <summary>
    /// <para>Adds an image's opening and closing tags to the tag stack, optionally providing a <paramref name="width" /> and <paramref name="height" /> to resize the image, a <paramref name="color" /> to tint the image and a <paramref name="region" /> to only use parts of the image.</para>
    /// <para>If <paramref name="width" /> or <paramref name="height" /> is set to 0, the image size will be adjusted in order to keep the original aspect ratio.</para>
    /// <para>If <paramref name="width" /> and <paramref name="height" /> are not set, but <paramref name="region" /> is, the region's rect will be used.</para>
    /// <para><paramref name="key" /> is an optional identifier, that can be used to modify the image via <see cref="RichTextLabel.UpdateImage(Godot.Variant,Godot.RichTextLabel.ImageUpdateMask,Godot.Texture2D,System.Int32,System.Int32,System.Nullable{Godot.Color},Godot.InlineAlignment,System.Nullable{Godot.Rect2},System.Boolean,System.String,System.Boolean)" />.</para>
    /// <para>If <paramref name="pad" /> is set, and the image is smaller than the size specified by <paramref name="width" /> and <paramref name="height" />, the image padding is added to match the size instead of upscaling.</para>
    /// <para>If <paramref name="sizeInPercent" /> is set, <paramref name="width" /> and <paramref name="height" /> values are percentages of the control width instead of pixels.</para>
    /// </summary>
    /// <param name="color">If the parameter is null, then the default value is <c>new Color(1, 1, 1, 1)</c>.</param>
    /// <param name="region">If the parameter is null, then the default value is <c>new Rect2(new Vector2(0, 0), new Vector2(0, 0))</c>.</param>
    void AddImage(Texture2D image, int width, int height, Nullable<Color> color, InlineAlignment inlineAlign, Nullable<Rect2> region);
    /// <summary>
    /// <para>Adds an image's opening and closing tags to the tag stack, optionally providing a <paramref name="width" /> and <paramref name="height" /> to resize the image, a <paramref name="color" /> to tint the image and a <paramref name="region" /> to only use parts of the image.</para>
    /// <para>If <paramref name="width" /> or <paramref name="height" /> is set to 0, the image size will be adjusted in order to keep the original aspect ratio.</para>
    /// <para>If <paramref name="width" /> and <paramref name="height" /> are not set, but <paramref name="region" /> is, the region's rect will be used.</para>
    /// <para><paramref name="key" /> is an optional identifier, that can be used to modify the image via <see cref="RichTextLabel.UpdateImage(Godot.Variant,Godot.RichTextLabel.ImageUpdateMask,Godot.Texture2D,System.Int32,System.Int32,System.Nullable{Godot.Color},Godot.InlineAlignment,System.Nullable{Godot.Rect2},System.Boolean,System.String,System.Boolean)" />.</para>
    /// <para>If <paramref name="pad" /> is set, and the image is smaller than the size specified by <paramref name="width" /> and <paramref name="height" />, the image padding is added to match the size instead of upscaling.</para>
    /// <para>If <paramref name="sizeInPercent" /> is set, <paramref name="width" /> and <paramref name="height" /> values are percentages of the control width instead of pixels.</para>
    /// </summary>
    /// <param name="color">If the parameter is null, then the default value is <c>new Color(1, 1, 1, 1)</c>.</param>
    /// <param name="region">If the parameter is null, then the default value is <c>new Rect2(new Vector2(0, 0), new Vector2(0, 0))</c>.</param>
    void AddImage(Texture2D image, int width, int height, Nullable<Color> color, InlineAlignment inlineAlign, Nullable<Rect2> region, Variant key, bool pad, string tooltip, bool sizeInPercent);
    /// <summary>
    /// <para>Adds raw non-BBCode-parsed text to the tag stack.</para>
    /// </summary>
    void AddText(string text);
    /// <summary>
    /// <para>Parses <paramref name="bbcode" /> and adds tags to the tag stack as needed.</para>
    /// <para><b>Note:</b> Using this method, you can't close a tag that was opened in a previous <see cref="RichTextLabel.AppendText(System.String)" /> call. This is done to improve performance, especially when updating large RichTextLabels since rebuilding the whole BBCode every time would be slower. If you absolutely need to close a tag in a future method call, append the <see cref="RichTextLabel.Text" /> instead of using <see cref="RichTextLabel.AppendText(System.String)" />.</para>
    /// </summary>
    void AppendText(string bbcode);
    /// <summary>
    /// <para>If set to something other than <see cref="TextServer.AutowrapMode.Off" />, the text gets wrapped inside the node's bounding rectangle. To see how each mode behaves, see <see cref="TextServer.AutowrapMode" />.</para>
    /// </summary>
    TextServer.AutowrapMode AutowrapMode { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the label uses BBCode formatting.</para>
    /// </summary>
    bool BbcodeEnabled { get; set; }
    /// <summary>
    /// <para>Clears the tag stack.</para>
    /// <para><b>Note:</b> This method will not modify <see cref="RichTextLabel.Text" />, but setting <see cref="RichTextLabel.Text" /> to an empty string also clears the stack.</para>
    /// </summary>
    void Clear();
    /// <summary>
    /// <para>If <c>true</c>, a right-click displays the context menu.</para>
    /// </summary>
    bool ContextMenuEnabled { get; set; }
    /// <summary>
    /// <para>The currently installed custom effects. This is an array of <see cref="RichTextEffect" />s.</para>
    /// <para>To add a custom effect, it's more convenient to use <see cref="RichTextLabel.InstallEffect(Godot.Variant)" />.</para>
    /// </summary>
    Godot.Collections.Array CustomEffects { get; set; }
    /// <summary>
    /// <para>Clears the current selection.</para>
    /// </summary>
    void Deselect();
    /// <summary>
    /// <para>If <c>true</c>, the selected text will be deselected when focus is lost.</para>
    /// </summary>
    bool DeselectOnFocusLossEnabled { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, allow drag and drop of selected text.</para>
    /// </summary>
    bool DragAndDropSelectionEnabled { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the label's minimum size will be automatically updated to fit its content, matching the behavior of <see cref="Label" />.</para>
    /// </summary>
    bool FitContent { get; set; }
    /// <summary>
    /// <para>Returns the line number of the character position provided.</para>
    /// <para><b>Note:</b> If <see cref="RichTextLabel.Threaded" /> is enabled, this method returns a value for the loaded part of the document. Use <see cref="RichTextLabel.IsReady" /> or <see cref="RichTextLabel.Finished" /> to determine whether document is fully loaded.</para>
    /// </summary>
    int GetCharacterLine(int character);
    /// <summary>
    /// <para>Returns the paragraph number of the character position provided.</para>
    /// <para><b>Note:</b> If <see cref="RichTextLabel.Threaded" /> is enabled, this method returns a value for the loaded part of the document. Use <see cref="RichTextLabel.IsReady" /> or <see cref="RichTextLabel.Finished" /> to determine whether document is fully loaded.</para>
    /// </summary>
    int GetCharacterParagraph(int character);
    /// <summary>
    /// <para>Returns the height of the content.</para>
    /// <para><b>Note:</b> If <see cref="RichTextLabel.Threaded" /> is enabled, this method returns a value for the loaded part of the document. Use <see cref="RichTextLabel.IsReady" /> or <see cref="RichTextLabel.Finished" /> to determine whether document is fully loaded.</para>
    /// </summary>
    int GetContentHeight();
    /// <summary>
    /// <para>Returns the width of the content.</para>
    /// <para><b>Note:</b> If <see cref="RichTextLabel.Threaded" /> is enabled, this method returns a value for the loaded part of the document. Use <see cref="RichTextLabel.IsReady" /> or <see cref="RichTextLabel.Finished" /> to determine whether document is fully loaded.</para>
    /// </summary>
    int GetContentWidth();
    /// <summary>
    /// <para>Returns the total number of lines in the text. Wrapped text is counted as multiple lines.</para>
    /// <para><b>Note:</b> If <see cref="RichTextLabel.Threaded" /> is enabled, this method returns a value for the loaded part of the document. Use <see cref="RichTextLabel.IsReady" /> or <see cref="RichTextLabel.Finished" /> to determine whether document is fully loaded.</para>
    /// </summary>
    int GetLineCount();
    /// <summary>
    /// <para>Returns the vertical offset of the line found at the provided index.</para>
    /// <para><b>Note:</b> If <see cref="RichTextLabel.Threaded" /> is enabled, this method returns a value for the loaded part of the document. Use <see cref="RichTextLabel.IsReady" /> or <see cref="RichTextLabel.Finished" /> to determine whether document is fully loaded.</para>
    /// </summary>
    float GetLineOffset(int line);
    /// <summary>
    /// <para>Returns the <see cref="PopupMenu" /> of this <see cref="RichTextLabel" />. By default, this menu is displayed when right-clicking on the <see cref="RichTextLabel" />.</para>
    /// <para>You can add custom menu items or remove standard ones. Make sure your IDs don't conflict with the standard ones (see <see cref="RichTextLabel.MenuItems" />). For example:</para>
    /// <para><code>
    /// public override void _Ready()
    /// {
    /// var menu = GetMenu();
    /// // Remove "Select All" item.
    /// menu.RemoveItem(RichTextLabel.MenuItems.SelectAll);
    /// // Add custom items.
    /// menu.AddSeparator();
    /// menu.AddItem("Duplicate Text", RichTextLabel.MenuItems.Max + 1);
    /// // Add event handler.
    /// menu.IdPressed += OnItemPressed;
    /// }
    /// public void OnItemPressed(int id)
    /// {
    /// if (id == TextEdit.MenuItems.Max + 1)
    /// {
    /// AddText("\n" + GetParsedText());
    /// }
    /// }
    /// </code></para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash. If you wish to hide it or any of its children, use their <see cref="Window.Visible" /> property.</para>
    /// </summary>
    PopupMenu GetMenu();
    /// <summary>
    /// <para>Returns the total number of paragraphs (newlines or <c>p</c> tags in the tag stack's text tags). Considers wrapped text as one paragraph.</para>
    /// </summary>
    int GetParagraphCount();
    /// <summary>
    /// <para>Returns the vertical offset of the paragraph found at the provided index.</para>
    /// <para><b>Note:</b> If <see cref="RichTextLabel.Threaded" /> is enabled, this method returns a value for the loaded part of the document. Use <see cref="RichTextLabel.IsReady" /> or <see cref="RichTextLabel.Finished" /> to determine whether document is fully loaded.</para>
    /// </summary>
    float GetParagraphOffset(int paragraph);
    /// <summary>
    /// <para>Returns the text without BBCode mark-up.</para>
    /// </summary>
    string GetParsedText();
    /// <summary>
    /// <para>Returns the current selection text. Does not include BBCodes.</para>
    /// </summary>
    string GetSelectedText();
    /// <summary>
    /// <para>Returns the current selection first character index if a selection is active, <c>-1</c> otherwise. Does not include BBCodes.</para>
    /// </summary>
    int GetSelectionFrom();
    /// <summary>
    /// <para>Returns the current selection last character index if a selection is active, <c>-1</c> otherwise. Does not include BBCodes.</para>
    /// </summary>
    int GetSelectionTo();
    /// <summary>
    /// <para>Returns the total number of characters from text tags. Does not include BBCodes.</para>
    /// </summary>
    int GetTotalCharacterCount();
    /// <summary>
    /// <para>Returns the number of visible lines.</para>
    /// <para><b>Note:</b> If <see cref="RichTextLabel.Threaded" /> is enabled, this method returns a value for the loaded part of the document. Use <see cref="RichTextLabel.IsReady" /> or <see cref="RichTextLabel.Finished" /> to determine whether document is fully loaded.</para>
    /// </summary>
    int GetVisibleLineCount();
    /// <summary>
    /// <para>Returns the number of visible paragraphs. A paragraph is considered visible if at least one of its lines is visible.</para>
    /// <para><b>Note:</b> If <see cref="RichTextLabel.Threaded" /> is enabled, this method returns a value for the loaded part of the document. Use <see cref="RichTextLabel.IsReady" /> or <see cref="RichTextLabel.Finished" /> to determine whether document is fully loaded.</para>
    /// </summary>
    int GetVisibleParagraphCount();
    /// <summary>
    /// <para>Returns the vertical scrollbar.</para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash. If you wish to hide it or any of its children, use their <see cref="CanvasItem.Visible" /> property.</para>
    /// </summary>
    VScrollBar GetVScrollBar();
    /// <summary>
    /// <para>If <c>true</c>, the label underlines hint tags such as <c>[hint=description]{text}[/hint]</c>.</para>
    /// </summary>
    bool HintUnderlined { get; set; }
    /// <summary>
    /// <para>Installs a custom effect. <paramref name="effect" /> should be a valid <see cref="RichTextEffect" />.</para>
    /// </summary>
    void InstallEffect(Variant effect);
    /// <summary>
    /// <para>Returns whether the menu is visible. Use this instead of <c>get_menu().visible</c> to improve performance (so the creation of the menu is avoided).</para>
    /// </summary>
    bool IsMenuVisible();
    /// <summary>
    /// <para>If <see cref="RichTextLabel.Threaded" /> is enabled, returns <c>true</c> if the background thread has finished text processing, otherwise always return <c>true</c>.</para>
    /// </summary>
    bool IsReady();
    /// <summary>
    /// <para>Language code used for line-breaking and text shaping algorithms, if left empty current locale is used instead.</para>
    /// </summary>
    string Language { get; set; }
    /// <summary>
    /// <para>Executes a given action as defined in the <see cref="RichTextLabel.MenuItems" /> enum.</para>
    /// </summary>
    void MenuOption(int option);
    /// <summary>
    /// <para>If <c>true</c>, the label underlines meta tags such as <c>[url]{text}[/url]</c>.</para>
    /// </summary>
    bool MetaUnderlined { get; set; }
    /// <summary>
    /// <para>Adds a newline tag to the tag stack.</para>
    /// </summary>
    void Newline();
    /// <summary>
    /// <para>The assignment version of <see cref="RichTextLabel.AppendText(System.String)" />. Clears the tag stack and inserts the new content.</para>
    /// </summary>
    void ParseBbcode(string bbcode);
    /// <summary>
    /// <para>Parses BBCode parameter <paramref name="expressions" /> into a dictionary.</para>
    /// </summary>
    Godot.Collections.Dictionary ParseExpressionsForValues(string[] expressions);
    /// <summary>
    /// <para>Terminates the current tag. Use after <c>push_*</c> methods to close BBCodes manually. Does not need to follow <c>add_*</c> methods.</para>
    /// </summary>
    void Pop();
    /// <summary>
    /// <para>Terminates all tags opened by <c>push_*</c> methods.</para>
    /// </summary>
    void PopAll();
    /// <summary>
    /// <para>Terminates tags opened after the last <see cref="RichTextLabel.PushContext" /> call (including context marker), or all tags if there's no context marker on the stack.</para>
    /// </summary>
    void PopContext();
    /// <summary>
    /// <para>The delay after which the loading progress bar is displayed, in milliseconds. Set to <c>-1</c> to disable progress bar entirely.</para>
    /// <para><b>Note:</b> Progress bar is displayed only if <see cref="RichTextLabel.Threaded" /> is enabled.</para>
    /// </summary>
    int ProgressBarDelay { get; set; }
    /// <summary>
    /// <para>Adds a <c>[bgcolor]</c> tag to the tag stack.</para>
    /// </summary>
    void PushBgcolor(Color bgcolor);
    /// <summary>
    /// <para>Adds a <c>[font]</c> tag with a bold font to the tag stack. This is the same as adding a <c>[b]</c> tag if not currently in a <c>[i]</c> tag.</para>
    /// </summary>
    void PushBold();
    /// <summary>
    /// <para>Adds a <c>[font]</c> tag with a bold italics font to the tag stack.</para>
    /// </summary>
    void PushBoldItalics();
    /// <summary>
    /// <para>Adds a <c>[cell]</c> tag to the tag stack. Must be inside a <c>[table]</c> tag. See <see cref="RichTextLabel.PushTable(System.Int32,Godot.InlineAlignment,System.Int32)" /> for details.</para>
    /// </summary>
    void PushCell();
    /// <summary>
    /// <para>Adds a <c>[color]</c> tag to the tag stack.</para>
    /// </summary>
    void PushColor(Color color);
    /// <summary>
    /// <para>Adds a context marker to the tag stack. See <see cref="RichTextLabel.PopContext" />.</para>
    /// </summary>
    void PushContext();
    /// <summary>
    /// <para>Adds a custom effect tag to the tag stack. The effect does not need to be in <see cref="RichTextLabel.CustomEffects" />. The environment is directly passed to the effect.</para>
    /// </summary>
    void PushCustomfx(RichTextEffect effect, Godot.Collections.Dictionary env);
    /// <summary>
    /// <para>Adds a <c>[dropcap]</c> tag to the tag stack. Drop cap (dropped capital) is a decorative element at the beginning of a paragraph that is larger than the rest of the text.</para>
    /// </summary>
    /// <param name="dropcapMargins">If the parameter is null, then the default value is <c>new Rect2(new Vector2(0, 0), new Vector2(0, 0))</c>.</param>
    /// <param name="color">If the parameter is null, then the default value is <c>new Color(1, 1, 1, 1)</c>.</param>
    /// <param name="outlineColor">If the parameter is null, then the default value is <c>new Color(0, 0, 0, 0)</c>.</param>
    void PushDropcap(string @string, Font font, int size, Nullable<Rect2> dropcapMargins, Nullable<Color> color, int outlineSize, Nullable<Color> outlineColor);
    /// <summary>
    /// <para>Adds a <c>[fgcolor]</c> tag to the tag stack.</para>
    /// </summary>
    void PushFgcolor(Color fgcolor);
    /// <summary>
    /// <para>Adds a <c>[font]</c> tag to the tag stack. Overrides default fonts for its duration.</para>
    /// <para>Passing <c>0</c> to <paramref name="fontSize" /> will use the existing default font size.</para>
    /// </summary>
    void PushFont(Font font, int fontSize);
    /// <summary>
    /// <para>Adds a <c>[font_size]</c> tag to the tag stack. Overrides default font size for its duration.</para>
    /// </summary>
    void PushFontSize(int fontSize);
    /// <summary>
    /// <para>Adds a <c>[hint]</c> tag to the tag stack. Same as BBCode <c>[hint=something]{text}[/hint]</c>.</para>
    /// </summary>
    void PushHint(string description);
    /// <summary>
    /// <para>Adds an <c>[indent]</c> tag to the tag stack. Multiplies <paramref name="level" /> by current <see cref="RichTextLabel.TabSize" /> to determine new margin length.</para>
    /// </summary>
    void PushIndent(int level);
    /// <summary>
    /// <para>Adds a <c>[font]</c> tag with an italics font to the tag stack. This is the same as adding an <c>[i]</c> tag if not currently in a <c>[b]</c> tag.</para>
    /// </summary>
    void PushItalics();
    /// <summary>
    /// <para>Adds language code used for text shaping algorithm and Open-Type font features.</para>
    /// </summary>
    void PushLanguage(string language);
    /// <inheritdoc cref="M:Godot.RichTextLabel.PushList(System.Int32,Godot.RichTextLabel.ListType,System.Boolean,System.String)" />
    void PushList(int level, RichTextLabel.ListType @type, bool capitalize);
    /// <summary>
    /// <para>Adds <c>[ol]</c> or <c>[ul]</c> tag to the tag stack. Multiplies <paramref name="level" /> by current <see cref="RichTextLabel.TabSize" /> to determine new margin length.</para>
    /// </summary>
    void PushList(int level, RichTextLabel.ListType @type, bool capitalize, string bullet);
    /// <summary>
    /// <para>Adds a meta tag to the tag stack. Similar to the BBCode <c>[url=something]{text}[/url]</c>, but supports non-<see cref="T:System.String" /> metadata types.</para>
    /// </summary>
    void PushMeta(Variant data);
    /// <summary>
    /// <para>Adds a <c>[font]</c> tag with a monospace font to the tag stack.</para>
    /// </summary>
    void PushMono();
    /// <summary>
    /// <para>Adds a <c>[font]</c> tag with a normal font to the tag stack.</para>
    /// </summary>
    void PushNormal();
    /// <summary>
    /// <para>Adds a <c>[outline_color]</c> tag to the tag stack. Adds text outline for its duration.</para>
    /// </summary>
    void PushOutlineColor(Color color);
    /// <summary>
    /// <para>Adds a <c>[outline_size]</c> tag to the tag stack. Overrides default text outline size for its duration.</para>
    /// </summary>
    void PushOutlineSize(int outlineSize);
    /// <inheritdoc cref="M:Godot.RichTextLabel.PushParagraph(Godot.HorizontalAlignment,Godot.Control.TextDirection,System.String,Godot.TextServer.StructuredTextParser,Godot.TextServer.JustificationFlag,System.Single[])" />
    void PushParagraph(HorizontalAlignment alignment, Control.TextDirection baseDirection, string language, TextServer.StructuredTextParser stParser);
    /// <summary>
    /// <para>Adds a <c>[p]</c> tag to the tag stack.</para>
    /// </summary>
    /// <param name="tabStops">If the parameter is null, then the default value is <c>Array.Empty&lt;float&gt;()</c>.</param>
    void PushParagraph(HorizontalAlignment alignment, Control.TextDirection baseDirection, string language, TextServer.StructuredTextParser stParser, TextServer.JustificationFlag justificationFlags, float[] tabStops);
    /// <summary>
    /// <para>Adds a <c>[s]</c> tag to the tag stack.</para>
    /// </summary>
    void PushStrikethrough();
    /// <summary>
    /// <para>Adds a <c>[table=columns,inline_align]</c> tag to the tag stack.</para>
    /// </summary>
    void PushTable(int columns, InlineAlignment inlineAlign, int alignToRow);
    /// <summary>
    /// <para>Adds a <c>[u]</c> tag to the tag stack.</para>
    /// </summary>
    void PushUnderline();
    /// <summary>
    /// <para>Removes a paragraph of content from the label. Returns <c>true</c> if the paragraph exists.</para>
    /// <para>The <paramref name="paragraph" /> argument is the index of the paragraph to remove, it can take values in the interval <c>[0, get_paragraph_count() - 1]</c>.</para>
    /// </summary>
    bool RemoveParagraph(int paragraph);
    /// <summary>
    /// <para>If <c>true</c>, the scrollbar is visible. Setting this to <c>false</c> does not block scrolling completely. See <see cref="RichTextLabel.ScrollToLine(System.Int32)" />.</para>
    /// </summary>
    bool ScrollActive { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the window scrolls down to display new content automatically.</para>
    /// </summary>
    bool ScrollFollowing { get; set; }
    /// <summary>
    /// <para>Scrolls the window's top line to match <paramref name="line" />.</para>
    /// </summary>
    void ScrollToLine(int line);
    /// <summary>
    /// <para>Scrolls the window's top line to match first line of the <paramref name="paragraph" />.</para>
    /// </summary>
    void ScrollToParagraph(int paragraph);
    /// <summary>
    /// <para>Scrolls to the beginning of the current selection.</para>
    /// </summary>
    void ScrollToSelection();
    /// <summary>
    /// <para>Select all the text.</para>
    /// <para>If <see cref="RichTextLabel.SelectionEnabled" /> is <c>false</c>, no selection will occur.</para>
    /// </summary>
    void SelectAll();
    /// <summary>
    /// <para>If <c>true</c>, the label allows text selection.</para>
    /// </summary>
    bool SelectionEnabled { get; set; }
    /// <summary>
    /// <para>Sets color of a table cell border.</para>
    /// </summary>
    void SetCellBorderColor(Color color);
    /// <summary>
    /// <para>Sets inner padding of a table cell.</para>
    /// </summary>
    void SetCellPadding(Rect2 padding);
    /// <summary>
    /// <para>Sets color of a table cell. Separate colors for alternating rows can be specified.</para>
    /// </summary>
    void SetCellRowBackgroundColor(Color oddRowBg, Color evenRowBg);
    /// <summary>
    /// <para>Sets minimum and maximum size overrides for a table cell.</para>
    /// </summary>
    void SetCellSizeOverride(Vector2 minSize, Vector2 maxSize);
    /// <summary>
    /// <para>Edits the selected column's expansion options. If <paramref name="expand" /> is <c>true</c>, the column expands in proportion to its expansion ratio versus the other columns' ratios.</para>
    /// <para>For example, 2 columns with ratios 3 and 4 plus 70 pixels in available width would expand 30 and 40 pixels, respectively.</para>
    /// <para>If <paramref name="expand" /> is <c>false</c>, the column will not contribute to the total ratio.</para>
    /// </summary>
    void SetTableColumnExpand(int column, bool expand, int ratio);
    /// <summary>
    /// <para>If <c>true</c>, shortcut keys for context menu items are enabled, even if the context menu is disabled.</para>
    /// </summary>
    bool ShortcutKeysEnabled { get; set; }
    /// <summary>
    /// <para>Set BiDi algorithm override for the structured text.</para>
    /// </summary>
    TextServer.StructuredTextParser StructuredTextBidiOverride { get; set; }
    /// <summary>
    /// <para>Set additional options for BiDi override.</para>
    /// </summary>
    Godot.Collections.Array StructuredTextBidiOverrideOptions { get; set; }
    /// <summary>
    /// <para>The number of spaces associated with a single tab length. Does not affect <c>\t</c> in text tags, only indent tags.</para>
    /// </summary>
    int TabSize { get; set; }
    /// <summary>
    /// <para>The label's text in BBCode format. Is not representative of manual modifications to the internal tag stack. Erases changes made by other methods when edited.</para>
    /// <para><b>Note:</b> If <see cref="RichTextLabel.BbcodeEnabled" /> is <c>true</c>, it is unadvised to use the <c>+=</c> operator with <see cref="RichTextLabel.Text" /> (e.g. <c>text += "some string"</c>) as it replaces the whole text and can cause slowdowns. It will also erase all BBCode that was added to stack using <c>push_*</c> methods. Use <see cref="RichTextLabel.AppendText(System.String)" /> for adding text instead, unless you absolutely need to close a tag that was opened in an earlier method call.</para>
    /// </summary>
    string Text { get; set; }
    /// <summary>
    /// <para>Base text writing direction.</para>
    /// </summary>
    Control.TextDirection TextDirection { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, text processing is done in a background thread.</para>
    /// </summary>
    bool Threaded { get; set; }
    /// <summary>
    /// <para>Updates the existing images with the key <paramref name="key" />. Only properties specified by <paramref name="mask" /> bits are updated. See <see cref="RichTextLabel.AddImage(Godot.Texture2D,System.Int32,System.Int32,System.Nullable{Godot.Color},Godot.InlineAlignment,System.Nullable{Godot.Rect2},Godot.Variant,System.Boolean,System.String,System.Boolean)" />.</para>
    /// </summary>
    /// <param name="color">If the parameter is null, then the default value is <c>new Color(1, 1, 1, 1)</c>.</param>
    /// <param name="region">If the parameter is null, then the default value is <c>new Rect2(new Vector2(0, 0), new Vector2(0, 0))</c>.</param>
    void UpdateImage(Variant key, RichTextLabel.ImageUpdateMask mask, Texture2D image, int width, int height, Nullable<Color> color, InlineAlignment inlineAlign, Nullable<Rect2> region, bool pad, string tooltip, bool sizeInPercent);
    /// <summary>
    /// <para>The number of characters to display. If set to <c>-1</c>, all characters are displayed. This can be useful when animating the text appearing in a dialog box.</para>
    /// <para><b>Note:</b> Setting this property updates <see cref="RichTextLabel.VisibleRatio" /> accordingly.</para>
    /// </summary>
    int VisibleCharacters { get; set; }
    /// <summary>
    /// <para>Sets the clipping behavior when <see cref="RichTextLabel.VisibleCharacters" /> or <see cref="RichTextLabel.VisibleRatio" /> is set. See <see cref="TextServer.VisibleCharactersBehavior" /> for more info.</para>
    /// </summary>
    TextServer.VisibleCharactersBehavior VisibleCharactersBehavior { get; set; }
    /// <summary>
    /// <para>The fraction of characters to display, relative to the total number of characters (see <see cref="RichTextLabel.GetTotalCharacterCount" />). If set to <c>1.0</c>, all characters are displayed. If set to <c>0.5</c>, only half of the characters will be displayed. This can be useful when animating the text appearing in a dialog box.</para>
    /// <para><b>Note:</b> Setting this property updates <see cref="RichTextLabel.VisibleCharacters" /> accordingly.</para>
    /// </summary>
    float VisibleRatio { get; set; }

}