namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
using Godot.Collections;
/// <summary>
/// <para><see cref="LineEdit" /> provides an input field for editing a single line of text. It features many built-in shortcuts that are always available (Ctrl here maps to Cmd on macOS):</para>
/// <para>- Ctrl + C: Copy</para>
/// <para>- Ctrl + X: Cut</para>
/// <para>- Ctrl + V or Ctrl + Y: Paste/"yank"</para>
/// <para>- Ctrl + Z: Undo</para>
/// <para>- Ctrl + ~: Swap input direction.</para>
/// <para>- Ctrl + Shift + Z: Redo</para>
/// <para>- Ctrl + U: Delete text from the caret position to the beginning of the line</para>
/// <para>- Ctrl + K: Delete text from the caret position to the end of the line</para>
/// <para>- Ctrl + A: Select all text</para>
/// <para>- Up Arrow/Down Arrow: Move the caret to the beginning/end of the line</para>
/// <para>On macOS, some extra keyboard shortcuts are available:</para>
/// <para>- Cmd + F: Same as Right Arrow, move the caret one character right</para>
/// <para>- Cmd + B: Same as Left Arrow, move the caret one character left</para>
/// <para>- Cmd + P: Same as Up Arrow, move the caret to the previous line</para>
/// <para>- Cmd + N: Same as Down Arrow, move the caret to the next line</para>
/// <para>- Cmd + D: Same as Delete, delete the character on the right side of caret</para>
/// <para>- Cmd + H: Same as Backspace, delete the character on the left side of the caret</para>
/// <para>- Cmd + A: Same as Home, move the caret to the beginning of the line</para>
/// <para>- Cmd + E: Same as End, move the caret to the end of the line</para>
/// <para>- Cmd + Left Arrow: Same as Home, move the caret to the beginning of the line</para>
/// <para>- Cmd + Right Arrow: Same as End, move the caret to the end of the line</para>
/// </summary>
public class LineEditAdapter : ControlAdapter, ILineEdit {
  private readonly LineEdit _node;

  public LineEditAdapter(LineEdit node) : base(node) { _node = node; }

    /// <summary>
    /// <para>Text alignment as defined in the <see cref="HorizontalAlignment" /> enum.</para>
    /// </summary>
    public HorizontalAlignment Alignment { get => _node.Alignment; set => _node.Alignment = value; }
    /// <summary>
    /// <para>If <c>true</c>, makes the caret blink.</para>
    /// </summary>
    public bool CaretBlink { get => _node.CaretBlink; set => _node.CaretBlink = value; }
    /// <summary>
    /// <para>The interval at which the caret blinks (in seconds).</para>
    /// </summary>
    public float CaretBlinkInterval { get => _node.CaretBlinkInterval; set => _node.CaretBlinkInterval = value; }
    /// <summary>
    /// <para>The caret's column position inside the <see cref="LineEdit" />. When set, the text may scroll to accommodate it.</para>
    /// </summary>
    public int CaretColumn { get => _node.CaretColumn; set => _node.CaretColumn = value; }
    /// <summary>
    /// <para>If <c>true</c>, the <see cref="LineEdit" /> will always show the caret, even if focus is lost.</para>
    /// </summary>
    public bool CaretForceDisplayed { get => _node.CaretForceDisplayed; set => _node.CaretForceDisplayed = value; }
    /// <summary>
    /// <para>Allow moving caret, selecting and removing the individual composite character components.</para>
    /// <para><b>Note:</b> Backspace is always removing individual composite character components.</para>
    /// </summary>
    public bool CaretMidGrapheme { get => _node.CaretMidGrapheme; set => _node.CaretMidGrapheme = value; }
    /// <summary>
    /// <para>Erases the <see cref="LineEdit" />'s <see cref="LineEdit.Text" />.</para>
    /// </summary>
    public void Clear() => _node.Clear();
    /// <summary>
    /// <para>If <c>true</c>, the <see cref="LineEdit" /> will show a clear button if <see cref="LineEdit.Text" /> is not empty, which can be used to clear the text quickly.</para>
    /// </summary>
    public bool ClearButtonEnabled { get => _node.ClearButtonEnabled; set => _node.ClearButtonEnabled = value; }
    /// <summary>
    /// <para>If <c>true</c>, the context menu will appear when right-clicked.</para>
    /// </summary>
    public bool ContextMenuEnabled { get => _node.ContextMenuEnabled; set => _node.ContextMenuEnabled = value; }
    /// <summary>
    /// <para>Deletes one character at the caret's current position (equivalent to pressing Delete).</para>
    /// </summary>
    public void DeleteCharAtCaret() => _node.DeleteCharAtCaret();
    /// <summary>
    /// <para>Deletes a section of the <see cref="LineEdit.Text" /> going from position <paramref name="fromColumn" /> to <paramref name="toColumn" />. Both parameters should be within the text's length.</para>
    /// </summary>
    public void DeleteText(int fromColumn, int toColumn) => _node.DeleteText(fromColumn, toColumn);
    /// <summary>
    /// <para>Clears the current selection.</para>
    /// </summary>
    public void Deselect() => _node.Deselect();
    /// <summary>
    /// <para>If <c>true</c>, the selected text will be deselected when focus is lost.</para>
    /// </summary>
    public bool DeselectOnFocusLossEnabled { get => _node.DeselectOnFocusLossEnabled; set => _node.DeselectOnFocusLossEnabled = value; }
    /// <summary>
    /// <para>If <c>true</c>, allow drag and drop of selected text.</para>
    /// </summary>
    public bool DragAndDropSelectionEnabled { get => _node.DragAndDropSelectionEnabled; set => _node.DragAndDropSelectionEnabled = value; }
    /// <summary>
    /// <para>If <c>true</c>, control characters are displayed.</para>
    /// </summary>
    public bool DrawControlChars { get => _node.DrawControlChars; set => _node.DrawControlChars = value; }
    /// <summary>
    /// <para>If <c>false</c>, existing text cannot be modified and new text cannot be added.</para>
    /// </summary>
    public bool Editable { get => _node.Editable; set => _node.Editable = value; }
    /// <summary>
    /// <para>If <c>true</c>, the <see cref="LineEdit" /> width will increase to stay longer than the <see cref="LineEdit.Text" />. It will <b>not</b> compress if the <see cref="LineEdit.Text" /> is shortened.</para>
    /// </summary>
    public bool ExpandToTextLength { get => _node.ExpandToTextLength; set => _node.ExpandToTextLength = value; }
    /// <summary>
    /// <para>If <c>true</c>, the <see cref="LineEdit" /> doesn't display decoration.</para>
    /// </summary>
    public bool Flat { get => _node.Flat; set => _node.Flat = value; }
    /// <summary>
    /// <para>Returns the <see cref="PopupMenu" /> of this <see cref="LineEdit" />. By default, this menu is displayed when right-clicking on the <see cref="LineEdit" />.</para>
    /// <para>You can add custom menu items or remove standard ones. Make sure your IDs don't conflict with the standard ones (see <see cref="LineEdit.MenuItems" />). For example:</para>
    /// <para><code>
    /// public override void _Ready()
    /// {
    /// var menu = GetMenu();
    /// // Remove all items after "Redo".
    /// menu.ItemCount = menu.GetItemIndex(LineEdit.MenuItems.Redo) + 1;
    /// // Add custom items.
    /// menu.AddSeparator();
    /// menu.AddItem("Insert Date", LineEdit.MenuItems.Max + 1);
    /// // Add event handler.
    /// menu.IdPressed += OnItemPressed;
    /// }
    /// public void OnItemPressed(int id)
    /// {
    /// if (id == LineEdit.MenuItems.Max + 1)
    /// {
    /// InsertTextAtCaret(Time.GetDateStringFromSystem());
    /// }
    /// }
    /// </code></para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash. If you wish to hide it or any of its children, use their <see cref="Window.Visible" /> property.</para>
    /// </summary>
    public PopupMenu GetMenu() => _node.GetMenu();
    /// <summary>
    /// <para>Returns the scroll offset due to <see cref="LineEdit.CaretColumn" />, as a number of characters.</para>
    /// </summary>
    public float GetScrollOffset() => _node.GetScrollOffset();
    /// <summary>
    /// <para>Returns the text inside the selection.</para>
    /// </summary>
    public string GetSelectedText() => _node.GetSelectedText();
    /// <summary>
    /// <para>Returns the selection begin column.</para>
    /// </summary>
    public int GetSelectionFromColumn() => _node.GetSelectionFromColumn();
    /// <summary>
    /// <para>Returns the selection end column.</para>
    /// </summary>
    public int GetSelectionToColumn() => _node.GetSelectionToColumn();
    /// <summary>
    /// <para>Returns <c>true</c> if the user has selected text.</para>
    /// </summary>
    public bool HasSelection() => _node.HasSelection();
    /// <summary>
    /// <para>Inserts <paramref name="text" /> at the caret. If the resulting value is longer than <see cref="LineEdit.MaxLength" />, nothing happens.</para>
    /// </summary>
    public void InsertTextAtCaret(string text) => _node.InsertTextAtCaret(text);
    /// <summary>
    /// <para>Returns whether the menu is visible. Use this instead of <c>get_menu().visible</c> to improve performance (so the creation of the menu is avoided).</para>
    /// </summary>
    public bool IsMenuVisible() => _node.IsMenuVisible();
    /// <summary>
    /// <para>Language code used for line-breaking and text shaping algorithms. If left empty, current locale is used instead.</para>
    /// </summary>
    public string Language { get => _node.Language; set => _node.Language = value; }
    /// <summary>
    /// <para>Maximum number of characters that can be entered inside the <see cref="LineEdit" />. If <c>0</c>, there is no limit.</para>
    /// <para>When a limit is defined, characters that would exceed <see cref="LineEdit.MaxLength" /> are truncated. This happens both for existing <see cref="LineEdit.Text" /> contents when setting the max length, or for new text inserted in the <see cref="LineEdit" />, including pasting. If any input text is truncated, the <see cref="LineEdit.TextChangeRejected" /> signal is emitted with the truncated substring as parameter.</para>
    /// <para><b>Example:</b></para>
    /// <para><code>
    /// Text = "Hello world";
    /// MaxLength = 5;
    /// // `Text` becomes "Hello".
    /// MaxLength = 10;
    /// Text += " goodbye";
    /// // `Text` becomes "Hello good".
    /// // `text_change_rejected` is emitted with "bye" as parameter.
    /// </code></para>
    /// </summary>
    public int MaxLength { get => _node.MaxLength; set => _node.MaxLength = value; }
    /// <summary>
    /// <para>Executes a given action as defined in the <see cref="LineEdit.MenuItems" /> enum.</para>
    /// </summary>
    public void MenuOption(int option) => _node.MenuOption(option);
    /// <summary>
    /// <para>If <c>false</c>, using middle mouse button to paste clipboard will be disabled.</para>
    /// <para><b>Note:</b> This method is only implemented on Linux.</para>
    /// </summary>
    public bool MiddleMousePasteEnabled { get => _node.MiddleMousePasteEnabled; set => _node.MiddleMousePasteEnabled = value; }
    /// <summary>
    /// <para>Text shown when the <see cref="LineEdit" /> is empty. It is <b>not</b> the <see cref="LineEdit" />'s default value (see <see cref="LineEdit.Text" />).</para>
    /// </summary>
    public string PlaceholderText { get => _node.PlaceholderText; set => _node.PlaceholderText = value; }
    /// <summary>
    /// <para>Sets the icon that will appear in the right end of the <see cref="LineEdit" /> if there's no <see cref="LineEdit.Text" />, or always, if <see cref="LineEdit.ClearButtonEnabled" /> is set to <c>false</c>.</para>
    /// </summary>
    public Texture2D RightIcon { get => _node.RightIcon; set => _node.RightIcon = value; }
    /// <summary>
    /// <para>If <c>true</c>, every character is replaced with the secret character (see <see cref="LineEdit.SecretCharacter" />).</para>
    /// </summary>
    public bool Secret { get => _node.Secret; set => _node.Secret = value; }
    /// <summary>
    /// <para>The character to use to mask secret input (defaults to "•"). Only a single character can be used as the secret character.</para>
    /// </summary>
    public string SecretCharacter { get => _node.SecretCharacter; set => _node.SecretCharacter = value; }
    /// <summary>
    /// <para>Selects characters inside <see cref="LineEdit" /> between <paramref name="from" /> and <paramref name="to" />. By default, <paramref name="from" /> is at the beginning and <paramref name="to" /> at the end.</para>
    /// <para><code>
    /// Text = "Welcome";
    /// Select(); // Will select "Welcome".
    /// Select(4); // Will select "ome".
    /// Select(2, 5); // Will select "lco".
    /// </code></para>
    /// </summary>
    public void Select(int @from, int to) => _node.Select(@from, to);
    /// <summary>
    /// <para>Selects the whole <see cref="T:System.String" />.</para>
    /// </summary>
    public void SelectAll() => _node.SelectAll();
    /// <summary>
    /// <para>If <c>true</c>, the <see cref="LineEdit" /> will select the whole text when it gains focus.</para>
    /// </summary>
    public bool SelectAllOnFocus { get => _node.SelectAllOnFocus; set => _node.SelectAllOnFocus = value; }
    /// <summary>
    /// <para>If <c>false</c>, it's impossible to select the text using mouse nor keyboard.</para>
    /// </summary>
    public bool SelectingEnabled { get => _node.SelectingEnabled; set => _node.SelectingEnabled = value; }
    /// <summary>
    /// <para>If <c>false</c>, using shortcuts will be disabled.</para>
    /// </summary>
    public bool ShortcutKeysEnabled { get => _node.ShortcutKeysEnabled; set => _node.ShortcutKeysEnabled = value; }
    /// <summary>
    /// <para>Set BiDi algorithm override for the structured text.</para>
    /// </summary>
    public TextServer.StructuredTextParser StructuredTextBidiOverride { get => _node.StructuredTextBidiOverride; set => _node.StructuredTextBidiOverride = value; }
    /// <summary>
    /// <para>Set additional options for BiDi override.</para>
    /// </summary>
    public Godot.Collections.Array StructuredTextBidiOverrideOptions { get => _node.StructuredTextBidiOverrideOptions; set => _node.StructuredTextBidiOverrideOptions = value; }
    /// <summary>
    /// <para>String value of the <see cref="LineEdit" />.</para>
    /// <para><b>Note:</b> Changing text using this property won't emit the <see cref="LineEdit.TextChanged" /> signal.</para>
    /// </summary>
    public string Text { get => _node.Text; set => _node.Text = value; }
    /// <summary>
    /// <para>Base text writing direction.</para>
    /// </summary>
    public Control.TextDirection TextDirection { get => _node.TextDirection; set => _node.TextDirection = value; }
    /// <summary>
    /// <para>If <c>true</c>, the native virtual keyboard is shown when focused on platforms that support it.</para>
    /// </summary>
    public bool VirtualKeyboardEnabled { get => _node.VirtualKeyboardEnabled; set => _node.VirtualKeyboardEnabled = value; }
    /// <summary>
    /// <para>Specifies the type of virtual keyboard to show.</para>
    /// </summary>
    public LineEdit.VirtualKeyboardTypeEnum VirtualKeyboardType { get => _node.VirtualKeyboardType; set => _node.VirtualKeyboardType = value; }

}