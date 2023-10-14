namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
using Godot.Collections;
/// <summary>
/// <para>A multiline text editor. It also has limited facilities for editing code, such as syntax highlighting support. For more advanced facilities for editing code, see <see cref="CodeEdit" />.</para>
/// <para><b>Note:</b> Most viewport, caret and edit methods contain a <c>caret_index</c> argument for <see cref="TextEdit.CaretMultiple" /> support. The argument should be one of the following: <c>-1</c> for all carets, <c>0</c> for the main caret, or greater than <c>0</c> for secondary carets.</para>
/// <para><b>Note:</b> When holding down Alt, the vertical scroll wheel will scroll 5 times as fast as it would normally do. This also works in the Godot script editor.</para>
/// </summary>
public class TextEditAdapter : TextEdit, ITextEdit {
  private readonly TextEdit _node;

  public TextEditAdapter(TextEdit node) => _node = node;
    /// <summary>
    /// <para>Override this method to define what happens when the user presses the backspace key.</para>
    /// </summary>
    public void _Backspace(int caretIndex) => _node._Backspace(caretIndex);
    /// <summary>
    /// <para>Override this method to define what happens when the user performs a copy operation.</para>
    /// </summary>
    public void _Copy(int caretIndex) => _node._Copy(caretIndex);
    /// <summary>
    /// <para>Override this method to define what happens when the user performs a cut operation.</para>
    /// </summary>
    public void _Cut(int caretIndex) => _node._Cut(caretIndex);
    /// <summary>
    /// <para>Override this method to define what happens when the user types in the provided key <paramref name="unicodeChar" />.</para>
    /// </summary>
    public void _HandleUnicodeInput(int unicodeChar, int caretIndex) => _node._HandleUnicodeInput(unicodeChar, caretIndex);
    /// <summary>
    /// <para>Override this method to define what happens when the user performs a paste operation.</para>
    /// </summary>
    public void _Paste(int caretIndex) => _node._Paste(caretIndex);
    /// <summary>
    /// <para>Override this method to define what happens when the user performs a paste operation with middle mouse button.</para>
    /// <para><b>Note:</b> This method is only implemented on Linux.</para>
    /// </summary>
    public void _PastePrimaryClipboard(int caretIndex) => _node._PastePrimaryClipboard(caretIndex);
    /// <summary>
    /// <para>Adds a new caret at the given location. Returns the index of the new caret, or <c>-1</c> if the location is invalid.</para>
    /// </summary>
    public int AddCaret(int line, int col) => _node.AddCaret(line, col);
    /// <summary>
    /// <para>Adds an additional caret above or below every caret. If <paramref name="below" /> is true the new caret will be added below and above otherwise.</para>
    /// </summary>
    public void AddCaretAtCarets(bool below) => _node.AddCaretAtCarets(below);
    /// <summary>
    /// <para>Register a new gutter to this <see cref="TextEdit" />. Use <paramref name="at" /> to have a specific gutter order. A value of <c>-1</c> appends the gutter to the right.</para>
    /// </summary>
    public void AddGutter(int at) => _node.AddGutter(at);
    /// <summary>
    /// <para>Adds a selection and a caret for the next occurrence of the current selection. If there is no active selection, selects word under caret.</para>
    /// </summary>
    public void AddSelectionForNextOccurrence() => _node.AddSelectionForNextOccurrence();
    /// <summary>
    /// <para>Reposition the carets affected by the edit. This assumes edits are applied in edit order, see <see cref="TextEdit.GetCaretIndexEditOrder" />.</para>
    /// </summary>
    public void AdjustCaretsAfterEdit(int caret, int fromLine, int fromCol, int toLine, int toCol) => _node.AdjustCaretsAfterEdit(caret, fromLine, fromCol, toLine, toCol);
    /// <summary>
    /// <para>Adjust the viewport so the caret is visible.</para>
    /// </summary>
    public void AdjustViewportToCaret(int caretIndex) => _node.AdjustViewportToCaret(caretIndex);
    /// <summary>
    /// <para>If <see cref="TextEdit.WrapMode" /> is set to <see cref="TextEdit.LineWrappingMode.Boundary" />, sets text wrapping mode. To see how each mode behaves, see <see cref="TextServer.AutowrapMode" />.</para>
    /// </summary>
    public TextServer.AutowrapMode AutowrapMode { get => _node.AutowrapMode; set => _node.AutowrapMode = value; }
    /// <summary>
    /// <para>Called when the user presses the backspace key. Can be overridden with <see cref="TextEdit._Backspace(System.Int32)" />.</para>
    /// </summary>
    public void Backspace(int caretIndex) => _node.Backspace(caretIndex);
    /// <summary>
    /// <para>Starts a multipart edit. All edits will be treated as one action until <see cref="TextEdit.EndComplexOperation" /> is called.</para>
    /// </summary>
    public void BeginComplexOperation() => _node.BeginComplexOperation();
    /// <summary>
    /// <para>If <c>true</c>, makes the caret blink.</para>
    /// </summary>
    public bool CaretBlink { get => _node.CaretBlink; set => _node.CaretBlink = value; }
    /// <summary>
    /// <para>The interval at which the caret blinks (in seconds).</para>
    /// </summary>
    public float CaretBlinkInterval { get => _node.CaretBlinkInterval; set => _node.CaretBlinkInterval = value; }
    /// <summary>
    /// <para>If <c>true</c>, caret will be visible when <see cref="TextEdit.Editable" /> is disabled.</para>
    /// </summary>
    public bool CaretDrawWhenEditableDisabled { get => _node.CaretDrawWhenEditableDisabled; set => _node.CaretDrawWhenEditableDisabled = value; }
    /// <summary>
    /// <para>Allow moving caret, selecting and removing the individual composite character components.</para>
    /// <para><b>Note:</b> Backspace is always removing individual composite character components.</para>
    /// </summary>
    public bool CaretMidGrapheme { get => _node.CaretMidGrapheme; set => _node.CaretMidGrapheme = value; }
    /// <summary>
    /// <para>If <c>true</c>, a right-click moves the caret at the mouse position before displaying the context menu.</para>
    /// <para>If <c>false</c>, the context menu disregards mouse location.</para>
    /// </summary>
    public bool CaretMoveOnRightClick { get => _node.CaretMoveOnRightClick; set => _node.CaretMoveOnRightClick = value; }
    /// <summary>
    /// <para>Sets if multiple carets are allowed.</para>
    /// </summary>
    public bool CaretMultiple { get => _node.CaretMultiple; set => _node.CaretMultiple = value; }
    /// <summary>
    /// <para>Set the type of caret to draw.</para>
    /// </summary>
    public TextEdit.CaretTypeEnum CaretType { get => _node.CaretType; set => _node.CaretType = value; }
    /// <summary>
    /// <para>Centers the viewport on the line the editing caret is at. This also resets the <see cref="TextEdit.ScrollHorizontal" /> value to <c>0</c>.</para>
    /// </summary>
    public void CenterViewportToCaret(int caretIndex) => _node.CenterViewportToCaret(caretIndex);
    /// <summary>
    /// <para>Performs a full reset of <see cref="TextEdit" />, including undo history.</para>
    /// </summary>
    public void Clear() => _node.Clear();
    /// <summary>
    /// <para>Clears the undo history.</para>
    /// </summary>
    public void ClearUndoHistory() => _node.ClearUndoHistory();
    /// <summary>
    /// <para>If <c>true</c>, a right-click displays the context menu.</para>
    /// </summary>
    public bool ContextMenuEnabled { get => _node.ContextMenuEnabled; set => _node.ContextMenuEnabled = value; }
    /// <summary>
    /// <para>Copies the current text selection. Can be overridden with <see cref="TextEdit._Copy(System.Int32)" />.</para>
    /// </summary>
    public void Copy(int caretIndex) => _node.Copy(caretIndex);
    /// <summary>
    /// <para>Cut's the current selection. Can be overridden with <see cref="TextEdit._Cut(System.Int32)" />.</para>
    /// </summary>
    public void Cut(int caretIndex) => _node.Cut(caretIndex);
    /// <summary>
    /// <para>Deletes the selected text.</para>
    /// </summary>
    public void DeleteSelection(int caretIndex) => _node.DeleteSelection(caretIndex);
    /// <summary>
    /// <para>Deselects the current selection.</para>
    /// </summary>
    public void Deselect(int caretIndex) => _node.Deselect(caretIndex);
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
    /// <para>If <c>true</c>, the "space" character will have a visible representation.</para>
    /// </summary>
    public bool DrawSpaces { get => _node.DrawSpaces; set => _node.DrawSpaces = value; }
    /// <summary>
    /// <para>If <c>true</c>, the "tab" character will have a visible representation.</para>
    /// </summary>
    public bool DrawTabs { get => _node.DrawTabs; set => _node.DrawTabs = value; }
    /// <summary>
    /// <para>If <c>false</c>, existing text cannot be modified and new text cannot be added.</para>
    /// </summary>
    public bool Editable { get => _node.Editable; set => _node.Editable = value; }
    /// <summary>
    /// <para>Marks the end of steps in the current action started with <see cref="TextEdit.StartAction(Godot.TextEdit.EditAction)" />.</para>
    /// </summary>
    public void EndAction() => _node.EndAction();
    /// <summary>
    /// <para>Ends a multipart edit, started with <see cref="TextEdit.BeginComplexOperation" />. If called outside a complex operation, the current operation is pushed onto the undo/redo stack.</para>
    /// </summary>
    public void EndComplexOperation() => _node.EndComplexOperation();
    /// <summary>
    /// <para>Returns the column the editing caret is at.</para>
    /// </summary>
    public int GetCaretColumn(int caretIndex) => _node.GetCaretColumn(caretIndex);
    /// <summary>
    /// <para>Returns the number of carets in this <see cref="TextEdit" />.</para>
    /// </summary>
    public int GetCaretCount() => _node.GetCaretCount();
    /// <summary>
    /// <para>Returns the caret pixel draw position.</para>
    /// </summary>
    public Vector2 GetCaretDrawPos(int caretIndex) => _node.GetCaretDrawPos(caretIndex);
    /// <summary>
    /// <para>Returns a list of caret indexes in their edit order, this done from bottom to top. Edit order refers to the way actions such as <see cref="TextEdit.InsertTextAtCaret(System.String,System.Int32)" /> are applied.</para>
    /// </summary>
    public int[] GetCaretIndexEditOrder() => _node.GetCaretIndexEditOrder();
    /// <summary>
    /// <para>Returns the line the editing caret is on.</para>
    /// </summary>
    public int GetCaretLine(int caretIndex) => _node.GetCaretLine(caretIndex);
    /// <summary>
    /// <para>Returns the wrap index the editing caret is on.</para>
    /// </summary>
    public int GetCaretWrapIndex(int caretIndex) => _node.GetCaretWrapIndex(caretIndex);
    /// <summary>
    /// <para>Returns the first column containing a non-whitespace character.</para>
    /// </summary>
    public int GetFirstNonWhiteSpaceColumn(int line) => _node.GetFirstNonWhiteSpaceColumn(line);
    /// <summary>
    /// <para>Returns the first visible line.</para>
    /// </summary>
    public int GetFirstVisibleLine() => _node.GetFirstVisibleLine();
    /// <summary>
    /// <para>Returns the number of gutters registered.</para>
    /// </summary>
    public int GetGutterCount() => _node.GetGutterCount();
    /// <summary>
    /// <para>Returns the name of the gutter at the given index.</para>
    /// </summary>
    public string GetGutterName(int gutter) => _node.GetGutterName(gutter);
    /// <summary>
    /// <para>Returns the type of the gutter at the given index.</para>
    /// </summary>
    public TextEdit.GutterType GetGutterType(int gutter) => _node.GetGutterType(gutter);
    /// <summary>
    /// <para>Returns the width of the gutter at the given index.</para>
    /// </summary>
    public int GetGutterWidth(int gutter) => _node.GetGutterWidth(gutter);
    /// <summary>
    /// <para>Returns the <see cref="HScrollBar" /> used by <see cref="TextEdit" />.</para>
    /// </summary>
    public HScrollBar GetHScrollBar() => _node.GetHScrollBar();
    /// <summary>
    /// <para>Returns the number of spaces and <c>tab * tab_size</c> before the first char.</para>
    /// </summary>
    public int GetIndentLevel(int line) => _node.GetIndentLevel(line);
    /// <summary>
    /// <para>Returns the last visible line. Use <see cref="TextEdit.GetLastFullVisibleLineWrapIndex" /> for the wrap index.</para>
    /// </summary>
    public int GetLastFullVisibleLine() => _node.GetLastFullVisibleLine();
    /// <summary>
    /// <para>Returns the last visible wrap index of the last visible line.</para>
    /// </summary>
    public int GetLastFullVisibleLineWrapIndex() => _node.GetLastFullVisibleLineWrapIndex();
    /// <summary>
    /// <para>Returns the last unhidden line in the entire <see cref="TextEdit" />.</para>
    /// </summary>
    public int GetLastUnhiddenLine() => _node.GetLastUnhiddenLine();
    /// <summary>
    /// <para>Returns the text of a specific line.</para>
    /// </summary>
    public string GetLine(int line) => _node.GetLine(line);
    /// <summary>
    /// <para>Returns the current background color of the line. <c>Color(0, 0, 0, 0)</c> is returned if no color is set.</para>
    /// </summary>
    public Color GetLineBackgroundColor(int line) => _node.GetLineBackgroundColor(line);
    /// <summary>
    /// <para>Returns the line and column at the given position. In the returned vector, <c>x</c> is the column, <c>y</c> is the line. If <paramref name="allowOutOfBounds" /> is <c>false</c> and the position is not over the text, both vector values will be set to <c>-1</c>.</para>
    /// </summary>
    public Vector2I GetLineColumnAtPos(Vector2I position, bool allowOutOfBounds) => _node.GetLineColumnAtPos(position, allowOutOfBounds);
    /// <summary>
    /// <para>Returns the number of lines in the text.</para>
    /// </summary>
    public int GetLineCount() => _node.GetLineCount();
    /// <summary>
    /// <para>Returns the icon currently in <paramref name="gutter" /> at <paramref name="line" />.</para>
    /// </summary>
    public Texture2D GetLineGutterIcon(int line, int gutter) => _node.GetLineGutterIcon(line, gutter);
    /// <summary>
    /// <para>Returns the color currently in <paramref name="gutter" /> at <paramref name="line" />.</para>
    /// </summary>
    public Color GetLineGutterItemColor(int line, int gutter) => _node.GetLineGutterItemColor(line, gutter);
    /// <summary>
    /// <para>Returns the metadata currently in <paramref name="gutter" /> at <paramref name="line" />.</para>
    /// </summary>
    public Variant GetLineGutterMetadata(int line, int gutter) => _node.GetLineGutterMetadata(line, gutter);
    /// <summary>
    /// <para>Returns the text currently in <paramref name="gutter" /> at <paramref name="line" />.</para>
    /// </summary>
    public string GetLineGutterText(int line, int gutter) => _node.GetLineGutterText(line, gutter);
    /// <summary>
    /// <para>Returns the maximum value of the line height among all lines.</para>
    /// <para><b>Note:</b> The return value is influenced by <c>line_spacing</c> and <c>font_size</c>. And it will not be less than <c>1</c>.</para>
    /// </summary>
    public int GetLineHeight() => _node.GetLineHeight();
    /// <summary>
    /// <para>Returns the width in pixels of the <paramref name="wrapIndex" /> on <paramref name="line" />.</para>
    /// </summary>
    public int GetLineWidth(int line, int wrapIndex) => _node.GetLineWidth(line, wrapIndex);
    /// <summary>
    /// <para>Returns the number of times the given line is wrapped.</para>
    /// </summary>
    public int GetLineWrapCount(int line) => _node.GetLineWrapCount(line);
    /// <summary>
    /// <para>Returns the wrap index of the given line column.</para>
    /// </summary>
    public int GetLineWrapIndexAtColumn(int line, int column) => _node.GetLineWrapIndexAtColumn(line, column);
    /// <summary>
    /// <para>Returns an array of <see cref="T:System.String" />s representing each wrapped index.</para>
    /// </summary>
    public string[] GetLineWrappedText(int line) => _node.GetLineWrappedText(line);
    /// <summary>
    /// <para>Returns the local mouse position adjusted for the text direction.</para>
    /// </summary>
    public Vector2 GetLocalMousePos() => _node.GetLocalMousePos();
    /// <summary>
    /// <para>Returns the <see cref="PopupMenu" /> of this <see cref="TextEdit" />. By default, this menu is displayed when right-clicking on the <see cref="TextEdit" />.</para>
    /// <para>You can add custom menu items or remove standard ones. Make sure your IDs don't conflict with the standard ones (see <see cref="TextEdit.MenuItems" />). For example:</para>
    /// <para><code>
    /// public override void _Ready()
    /// {
    /// var menu = GetMenu();
    /// // Remove all items after "Redo".
    /// menu.ItemCount = menu.GetItemIndex(TextEdit.MenuItems.Redo) + 1;
    /// // Add custom items.
    /// menu.AddSeparator();
    /// menu.AddItem("Insert Date", TextEdit.MenuItems.Max + 1);
    /// // Add event handler.
    /// menu.IdPressed += OnItemPressed;
    /// }
    /// public void OnItemPressed(int id)
    /// {
    /// if (id == TextEdit.MenuItems.Max + 1)
    /// {
    /// InsertTextAtCaret(Time.GetDateStringFromSystem());
    /// }
    /// }
    /// </code></para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash. If you wish to hide it or any of its children, use their <see cref="Window.Visible" /> property.</para>
    /// </summary>
    public PopupMenu GetMenu() => _node.GetMenu();
    /// <summary>
    /// <para>Returns the equivalent minimap line at <paramref name="position" />.</para>
    /// </summary>
    public int GetMinimapLineAtPos(Vector2I position) => _node.GetMinimapLineAtPos(position);
    /// <summary>
    /// <para>Returns the number of lines that may be drawn on the minimap.</para>
    /// </summary>
    public int GetMinimapVisibleLines() => _node.GetMinimapVisibleLines();
    /// <summary>
    /// <para>Similar to <see cref="TextEdit.GetNextVisibleLineOffsetFrom(System.Int32,System.Int32)" />, but takes into account the line wrap indexes. In the returned vector, <c>x</c> is the line, <c>y</c> is the wrap index.</para>
    /// </summary>
    public Vector2I GetNextVisibleLineIndexOffsetFrom(int line, int wrapIndex, int visibleAmount) => _node.GetNextVisibleLineIndexOffsetFrom(line, wrapIndex, visibleAmount);
    /// <summary>
    /// <para>Returns the count to the next visible line from <paramref name="line" /> to <c>line + visible_amount</c>. Can also count backwards. For example if a <see cref="TextEdit" /> has 5 lines with lines 2 and 3 hidden, calling this with <c>line = 1, visible_amount = 1</c> would return 3.</para>
    /// </summary>
    public int GetNextVisibleLineOffsetFrom(int line, int visibleAmount) => _node.GetNextVisibleLineOffsetFrom(line, visibleAmount);
    /// <summary>
    /// <para>Returns the local position for the given <paramref name="line" /> and <paramref name="column" />. If <c>x</c> or <c>y</c> of the returned vector equal <c>-1</c>, the position is outside of the viewable area of the control.</para>
    /// <para><b>Note:</b> The Y position corresponds to the bottom side of the line. Use <see cref="TextEdit.GetRectAtLineColumn(System.Int32,System.Int32)" /> to get the top side position.</para>
    /// </summary>
    public Vector2I GetPosAtLineColumn(int line, int column) => _node.GetPosAtLineColumn(line, column);
    /// <summary>
    /// <para>Returns the local position and size for the grapheme at the given <paramref name="line" /> and <paramref name="column" />. If <c>x</c> or <c>y</c> position of the returned rect equal <c>-1</c>, the position is outside of the viewable area of the control.</para>
    /// <para><b>Note:</b> The Y position of the returned rect corresponds to the top side of the line, unlike <see cref="TextEdit.GetPosAtLineColumn(System.Int32,System.Int32)" /> which returns the bottom side.</para>
    /// </summary>
    public Rect2I GetRectAtLineColumn(int line, int column) => _node.GetRectAtLineColumn(line, column);
    /// <summary>
    /// <para>Returns the last tagged saved version from <see cref="TextEdit.TagSavedVersion" />.</para>
    /// </summary>
    public uint GetSavedVersion() => _node.GetSavedVersion();
    /// <summary>
    /// <para>Returns the scroll position for <paramref name="wrapIndex" /> of <paramref name="line" />.</para>
    /// </summary>
    public double GetScrollPosForLine(int line, int wrapIndex) => _node.GetScrollPosForLine(line, wrapIndex);
    /// <summary>
    /// <para>Returns the text inside the selection of a caret, or all the carets if <paramref name="caretIndex" /> is its default value <c>-1</c>.</para>
    /// </summary>
    public string GetSelectedText(int caretIndex) => _node.GetSelectedText(caretIndex);
    /// <summary>
    /// <para>Returns the original start column of the selection.</para>
    /// </summary>
    public int GetSelectionColumn(int caretIndex) => _node.GetSelectionColumn(caretIndex);
    /// <summary>
    /// <para>Returns the selection begin column.</para>
    /// </summary>
    public int GetSelectionFromColumn(int caretIndex) => _node.GetSelectionFromColumn(caretIndex);
    /// <summary>
    /// <para>Returns the selection begin line.</para>
    /// </summary>
    public int GetSelectionFromLine(int caretIndex) => _node.GetSelectionFromLine(caretIndex);
    /// <summary>
    /// <para>Returns the original start line of the selection.</para>
    /// </summary>
    public int GetSelectionLine(int caretIndex) => _node.GetSelectionLine(caretIndex);
    /// <summary>
    /// <para>Returns the current selection mode.</para>
    /// </summary>
    public TextEdit.SelectionMode GetSelectionMode() => _node.GetSelectionMode();
    /// <summary>
    /// <para>Returns the selection end column.</para>
    /// </summary>
    public int GetSelectionToColumn(int caretIndex) => _node.GetSelectionToColumn(caretIndex);
    /// <summary>
    /// <para>Returns the selection end line.</para>
    /// </summary>
    public int GetSelectionToLine(int caretIndex) => _node.GetSelectionToLine(caretIndex);
    /// <summary>
    /// <para>Returns the <see cref="TextEdit" />'s' tab size.</para>
    /// </summary>
    public int GetTabSize() => _node.GetTabSize();
    /// <summary>
    /// <para>Returns the total width of all gutters and internal padding.</para>
    /// </summary>
    public int GetTotalGutterWidth() => _node.GetTotalGutterWidth();
    /// <summary>
    /// <para>Returns the number of lines that may be drawn.</para>
    /// </summary>
    public int GetTotalVisibleLineCount() => _node.GetTotalVisibleLineCount();
    /// <summary>
    /// <para>Returns the current version of the <see cref="TextEdit" />. The version is a count of recorded operations by the undo/redo history.</para>
    /// </summary>
    public uint GetVersion() => _node.GetVersion();
    /// <summary>
    /// <para>Returns the number of visible lines, including wrapped text.</para>
    /// </summary>
    public int GetVisibleLineCount() => _node.GetVisibleLineCount();
    /// <summary>
    /// <para>Returns the total number of visible + wrapped lines between the two lines.</para>
    /// </summary>
    public int GetVisibleLineCountInRange(int fromLine, int toLine) => _node.GetVisibleLineCountInRange(fromLine, toLine);
    /// <summary>
    /// <para>Returns the <see cref="VScrollBar" /> of the <see cref="TextEdit" />.</para>
    /// </summary>
    public VScrollBar GetVScrollBar() => _node.GetVScrollBar();
    /// <summary>
    /// <para>Returns the word at <paramref name="position" />.</para>
    /// </summary>
    public string GetWordAtPos(Vector2 position) => _node.GetWordAtPos(position);
    /// <summary>
    /// <para>Returns a <see cref="T:System.String" /> text with the word under the caret's location.</para>
    /// </summary>
    public string GetWordUnderCaret(int caretIndex) => _node.GetWordUnderCaret(caretIndex);
    /// <summary>
    /// <para>Returns if the user has IME text.</para>
    /// </summary>
    public bool HasImeText() => _node.HasImeText();
    /// <summary>
    /// <para>Returns <c>true</c> if a "redo" action is available.</para>
    /// </summary>
    public bool HasRedo() => _node.HasRedo();
    /// <summary>
    /// <para>Returns <c>true</c> if the user has selected text.</para>
    /// </summary>
    public bool HasSelection(int caretIndex) => _node.HasSelection(caretIndex);
    /// <summary>
    /// <para>Returns <c>true</c> if an "undo" action is available.</para>
    /// </summary>
    public bool HasUndo() => _node.HasUndo();
    /// <summary>
    /// <para>If <c>true</c>, all occurrences of the selected text will be highlighted.</para>
    /// </summary>
    public bool HighlightAllOccurrences { get => _node.HighlightAllOccurrences; set => _node.HighlightAllOccurrences = value; }
    /// <summary>
    /// <para>If <c>true</c>, the line containing the cursor is highlighted.</para>
    /// </summary>
    public bool HighlightCurrentLine { get => _node.HighlightCurrentLine; set => _node.HighlightCurrentLine = value; }
    /// <summary>
    /// <para>Inserts a new line with <paramref name="text" /> at <paramref name="line" />.</para>
    /// </summary>
    public void InsertLineAt(int line, string text) => _node.InsertLineAt(line, text);
    /// <summary>
    /// <para>Insert the specified text at the caret position.</para>
    /// </summary>
    public void InsertTextAtCaret(string text, int caretIndex) => _node.InsertTextAtCaret(text, caretIndex);
    /// <summary>
    /// <para>Returns <c>true</c> if the caret is visible on the screen.</para>
    /// </summary>
    public bool IsCaretVisible(int caretIndex) => _node.IsCaretVisible(caretIndex);
    /// <summary>
    /// <para>Returns <c>true</c> if the user is dragging their mouse for scrolling or selecting.</para>
    /// </summary>
    public bool IsDraggingCursor() => _node.IsDraggingCursor();
    /// <summary>
    /// <para>Returns whether the gutter is clickable.</para>
    /// </summary>
    public bool IsGutterClickable(int gutter) => _node.IsGutterClickable(gutter);
    /// <summary>
    /// <para>Returns whether the gutter is currently drawn.</para>
    /// </summary>
    public bool IsGutterDrawn(int gutter) => _node.IsGutterDrawn(gutter);
    /// <summary>
    /// <para>Returns whether the gutter is overwritable.</para>
    /// </summary>
    public bool IsGutterOverwritable(int gutter) => _node.IsGutterOverwritable(gutter);
    /// <summary>
    /// <para>Returns whether the gutter on the given line is clickable.</para>
    /// </summary>
    public bool IsLineGutterClickable(int line, int gutter) => _node.IsLineGutterClickable(line, gutter);
    /// <summary>
    /// <para>Returns if the given line is wrapped.</para>
    /// </summary>
    public bool IsLineWrapped(int line) => _node.IsLineWrapped(line);
    /// <summary>
    /// <para>Returns whether the menu is visible. Use this instead of <c>get_menu().visible</c> to improve performance (so the creation of the menu is avoided).</para>
    /// </summary>
    public bool IsMenuVisible() => _node.IsMenuVisible();
    /// <summary>
    /// <para>Returns whether the mouse is over selection. If <paramref name="edges" /> is <c>true</c>, the edges are considered part of the selection.</para>
    /// </summary>
    public bool IsMouseOverSelection(bool edges, int caretIndex) => _node.IsMouseOverSelection(edges, caretIndex);
    /// <summary>
    /// <para>Returns whether the user is in overtype mode.</para>
    /// </summary>
    public bool IsOvertypeModeEnabled() => _node.IsOvertypeModeEnabled();
    /// <summary>
    /// <para>Language code used for line-breaking and text shaping algorithms, if left empty current locale is used instead.</para>
    /// </summary>
    public string Language { get => _node.Language; set => _node.Language = value; }
    /// <summary>
    /// <para>Executes a given action as defined in the <see cref="TextEdit.MenuItems" /> enum.</para>
    /// </summary>
    public void MenuOption(int option) => _node.MenuOption(option);
    /// <summary>
    /// <para>Merge the gutters from <paramref name="fromLine" /> into <paramref name="toLine" />. Only overwritable gutters will be copied.</para>
    /// </summary>
    public void MergeGutters(int fromLine, int toLine) => _node.MergeGutters(fromLine, toLine);
    /// <summary>
    /// <para>Merges any overlapping carets. Will favor the newest caret, or the caret with a selection.</para>
    /// <para><b>Note:</b> This is not called when a caret changes position but after certain actions, so it is possible to get into a state where carets overlap.</para>
    /// </summary>
    public void MergeOverlappingCarets() => _node.MergeOverlappingCarets();
    /// <summary>
    /// <para>If <c>false</c>, using middle mouse button to paste clipboard will be disabled.</para>
    /// <para><b>Note:</b> This method is only implemented on Linux.</para>
    /// </summary>
    public bool MiddleMousePasteEnabled { get => _node.MiddleMousePasteEnabled; set => _node.MiddleMousePasteEnabled = value; }
    /// <summary>
    /// <para>If <c>true</c>, a minimap is shown, providing an outline of your source code.</para>
    /// </summary>
    public bool MinimapDraw { get => _node.MinimapDraw; set => _node.MinimapDraw = value; }
    /// <summary>
    /// <para>The width, in pixels, of the minimap.</para>
    /// </summary>
    public int MinimapWidth { get => _node.MinimapWidth; set => _node.MinimapWidth = value; }
    /// <summary>
    /// <para>Paste at the current location. Can be overridden with <see cref="TextEdit._Paste(System.Int32)" />.</para>
    /// </summary>
    public void Paste(int caretIndex) => _node.Paste(caretIndex);
    /// <summary>
    /// <para>Pastes the primary clipboard.</para>
    /// </summary>
    public void PastePrimaryClipboard(int caretIndex) => _node.PastePrimaryClipboard(caretIndex);
    /// <summary>
    /// <para>Text shown when the <see cref="TextEdit" /> is empty. It is <b>not</b> the <see cref="TextEdit" />'s default value (see <see cref="TextEdit.Text" />).</para>
    /// </summary>
    public string PlaceholderText { get => _node.PlaceholderText; set => _node.PlaceholderText = value; }
    /// <summary>
    /// <para>Perform redo operation.</para>
    /// </summary>
    public void Redo() => _node.Redo();
    /// <summary>
    /// <para>Removes the given caret index.</para>
    /// <para><b>Note:</b> This can result in adjustment of all other caret indices.</para>
    /// </summary>
    public void RemoveCaret(int caret) => _node.RemoveCaret(caret);
    /// <summary>
    /// <para>Removes the gutter from this <see cref="TextEdit" />.</para>
    /// </summary>
    public void RemoveGutter(int gutter) => _node.RemoveGutter(gutter);
    /// <summary>
    /// <para>Removes all additional carets.</para>
    /// </summary>
    public void RemoveSecondaryCarets() => _node.RemoveSecondaryCarets();
    /// <summary>
    /// <para>Removes text between the given positions.</para>
    /// <para><b>Note:</b> This does not adjust the caret or selection, which as a result it can end up in an invalid position.</para>
    /// </summary>
    public void RemoveText(int fromLine, int fromColumn, int toLine, int toColumn) => _node.RemoveText(fromLine, fromColumn, toLine, toColumn);
    /// <summary>
    /// <para>If <c>true</c>, <see cref="TextEdit" /> will disable vertical scroll and fit minimum height to the number of visible lines.</para>
    /// </summary>
    public bool ScrollFitContentHeight { get => _node.ScrollFitContentHeight; set => _node.ScrollFitContentHeight = value; }
    /// <summary>
    /// <para>If there is a horizontal scrollbar, this determines the current horizontal scroll value in pixels.</para>
    /// </summary>
    public int ScrollHorizontal { get => _node.ScrollHorizontal; set => _node.ScrollHorizontal = value; }
    /// <summary>
    /// <para>Allow scrolling past the last line into "virtual" space.</para>
    /// </summary>
    public bool ScrollPastEndOfFile { get => _node.ScrollPastEndOfFile; set => _node.ScrollPastEndOfFile = value; }
    /// <summary>
    /// <para>Scroll smoothly over the text rather than jumping to the next location.</para>
    /// </summary>
    public bool ScrollSmooth { get => _node.ScrollSmooth; set => _node.ScrollSmooth = value; }
    /// <summary>
    /// <para>If there is a vertical scrollbar, this determines the current vertical scroll value in line numbers, starting at 0 for the top line.</para>
    /// </summary>
    public double ScrollVertical { get => _node.ScrollVertical; set => _node.ScrollVertical = value; }
    /// <summary>
    /// <para>Sets the scroll speed with the minimap or when <see cref="TextEdit.ScrollSmooth" /> is enabled.</para>
    /// </summary>
    public float ScrollVScrollSpeed { get => _node.ScrollVScrollSpeed; set => _node.ScrollVScrollSpeed = value; }
    /// <summary>
    /// <para>Perform a search inside the text. Search flags can be specified in the <see cref="TextEdit.SearchFlags" /> enum.</para>
    /// <para>In the returned vector, <c>x</c> is the column, <c>y</c> is the line. If no results are found, both are equal to <c>-1</c>.</para>
    /// <para><code>
    /// Vector2I result = Search("print", (uint)TextEdit.SearchFlags.WholeWords, 0, 0);
    /// if (result.X != -1)
    /// {
    /// // Result found.
    /// int lineNumber = result.Y;
    /// int columnNumber = result.X;
    /// }
    /// </code></para>
    /// </summary>
    public Vector2I Search(string text, uint flags, int fromLine, int fromColum) => _node.Search(text, flags, fromLine, fromColum);
    /// <summary>
    /// <para>Perform selection, from line/column to line/column.</para>
    /// <para>If <see cref="TextEdit.SelectingEnabled" /> is <c>false</c>, no selection will occur.</para>
    /// </summary>
    public void Select(int fromLine, int fromColumn, int toLine, int toColumn, int caretIndex) => _node.Select(fromLine, fromColumn, toLine, toColumn, caretIndex);
    /// <summary>
    /// <para>Select all the text.</para>
    /// <para>If <see cref="TextEdit.SelectingEnabled" /> is <c>false</c>, no selection will occur.</para>
    /// </summary>
    public void SelectAll() => _node.SelectAll();
    /// <summary>
    /// <para>If <c>true</c>, text can be selected.</para>
    /// <para>If <c>false</c>, text can not be selected by the user or by the <see cref="TextEdit.Select(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32)" /> or <see cref="TextEdit.SelectAll" /> methods.</para>
    /// </summary>
    public bool SelectingEnabled { get => _node.SelectingEnabled; set => _node.SelectingEnabled = value; }
    /// <summary>
    /// <para>Selects the word under the caret.</para>
    /// </summary>
    public void SelectWordUnderCaret(int caretIndex) => _node.SelectWordUnderCaret(caretIndex);
    /// <summary>
    /// <para>Moves the caret to the specified <paramref name="column" /> index.</para>
    /// <para>If <paramref name="adjustViewport" /> is <c>true</c>, the viewport will center at the caret position after the move occurs.</para>
    /// <para><b>Note:</b> If supporting multiple carets this will not check for any overlap. See <see cref="TextEdit.MergeOverlappingCarets" />.</para>
    /// </summary>
    public void SetCaretColumn(int column, bool adjustViewport, int caretIndex) => _node.SetCaretColumn(column, adjustViewport, caretIndex);
    /// <summary>
    /// <para>Moves the caret to the specified <paramref name="line" /> index.</para>
    /// <para>If <paramref name="adjustViewport" /> is <c>true</c>, the viewport will center at the caret position after the move occurs.</para>
    /// <para>If <paramref name="canBeHidden" /> is <c>true</c>, the specified <paramref name="line" /> can be hidden.</para>
    /// <para><b>Note:</b> If supporting multiple carets this will not check for any overlap. See <see cref="TextEdit.MergeOverlappingCarets" />.</para>
    /// </summary>
    public void SetCaretLine(int line, bool adjustViewport, bool canBeHidden, int wrapIndex, int caretIndex) => _node.SetCaretLine(line, adjustViewport, canBeHidden, wrapIndex, caretIndex);
    /// <summary>
    /// <para>Sets the gutter as clickable. This will change the mouse cursor to a pointing hand when hovering over the gutter.</para>
    /// </summary>
    public void SetGutterClickable(int gutter, bool clickable) => _node.SetGutterClickable(gutter, clickable);
    /// <summary>
    /// <para>Set a custom draw method for the gutter. The callback method must take the following args: <c>line: int, gutter: int, Area: Rect2</c>.</para>
    /// </summary>
    public void SetGutterCustomDraw(int column, Callable drawCallback) => _node.SetGutterCustomDraw(column, drawCallback);
    /// <summary>
    /// <para>Sets whether the gutter should be drawn.</para>
    /// </summary>
    public void SetGutterDraw(int gutter, bool draw) => _node.SetGutterDraw(gutter, draw);
    /// <summary>
    /// <para>Sets the name of the gutter.</para>
    /// </summary>
    public void SetGutterName(int gutter, string name) => _node.SetGutterName(gutter, name);
    /// <summary>
    /// <para>Sets the gutter to overwritable. See <see cref="TextEdit.MergeGutters(System.Int32,System.Int32)" />.</para>
    /// </summary>
    public void SetGutterOverwritable(int gutter, bool overwritable) => _node.SetGutterOverwritable(gutter, overwritable);
    /// <summary>
    /// <para>Sets the type of gutter.</para>
    /// </summary>
    public void SetGutterType(int gutter, TextEdit.GutterType @type) => _node.SetGutterType(gutter, @type);
    /// <summary>
    /// <para>Set the width of the gutter.</para>
    /// </summary>
    public void SetGutterWidth(int gutter, int width) => _node.SetGutterWidth(gutter, width);
    /// <summary>
    /// <para>Sets the text for a specific line.</para>
    /// </summary>
    public void SetLine(int line, string newText) => _node.SetLine(line, newText);
    /// <summary>
    /// <para>Positions the <paramref name="wrapIndex" /> of <paramref name="line" /> at the center of the viewport.</para>
    /// </summary>
    public void SetLineAsCenterVisible(int line, int wrapIndex) => _node.SetLineAsCenterVisible(line, wrapIndex);
    /// <summary>
    /// <para>Positions the <paramref name="wrapIndex" /> of <paramref name="line" /> at the top of the viewport.</para>
    /// </summary>
    public void SetLineAsFirstVisible(int line, int wrapIndex) => _node.SetLineAsFirstVisible(line, wrapIndex);
    /// <summary>
    /// <para>Positions the <paramref name="wrapIndex" /> of <paramref name="line" /> at the bottom of the viewport.</para>
    /// </summary>
    public void SetLineAsLastVisible(int line, int wrapIndex) => _node.SetLineAsLastVisible(line, wrapIndex);
    /// <summary>
    /// <para>Sets the current background color of the line. Set to <c>Color(0, 0, 0, 0)</c> for no color.</para>
    /// </summary>
    public void SetLineBackgroundColor(int line, Color color) => _node.SetLineBackgroundColor(line, color);
    /// <summary>
    /// <para>If <paramref name="clickable" /> is <c>true</c>, makes the <paramref name="gutter" /> on <paramref name="line" /> clickable. See <see cref="TextEdit.GutterClicked" />.</para>
    /// </summary>
    public void SetLineGutterClickable(int line, int gutter, bool clickable) => _node.SetLineGutterClickable(line, gutter, clickable);
    /// <summary>
    /// <para>Sets the icon for <paramref name="gutter" /> on <paramref name="line" /> to <paramref name="icon" />.</para>
    /// </summary>
    public void SetLineGutterIcon(int line, int gutter, Texture2D icon) => _node.SetLineGutterIcon(line, gutter, icon);
    /// <summary>
    /// <para>Sets the color for <paramref name="gutter" /> on <paramref name="line" /> to <paramref name="color" />.</para>
    /// </summary>
    public void SetLineGutterItemColor(int line, int gutter, Color color) => _node.SetLineGutterItemColor(line, gutter, color);
    /// <summary>
    /// <para>Sets the metadata for <paramref name="gutter" /> on <paramref name="line" /> to <paramref name="metadata" />.</para>
    /// </summary>
    public void SetLineGutterMetadata(int line, int gutter, Variant metadata) => _node.SetLineGutterMetadata(line, gutter, metadata);
    /// <summary>
    /// <para>Sets the text for <paramref name="gutter" /> on <paramref name="line" /> to <paramref name="text" />.</para>
    /// </summary>
    public void SetLineGutterText(int line, int gutter, string text) => _node.SetLineGutterText(line, gutter, text);
    /// <summary>
    /// <para>If <c>true</c>, sets the user into overtype mode. When the user types in this mode, it will override existing text.</para>
    /// </summary>
    public void SetOvertypeModeEnabled(bool enabled) => _node.SetOvertypeModeEnabled(enabled);
    /// <summary>
    /// <para>Sets the search <paramref name="flags" />. This is used with <see cref="TextEdit.SetSearchText(System.String)" /> to highlight occurrences of the searched text. Search flags can be specified from the <see cref="TextEdit.SearchFlags" /> enum.</para>
    /// </summary>
    public void SetSearchFlags(uint flags) => _node.SetSearchFlags(flags);
    /// <summary>
    /// <para>Sets the search text. See <see cref="TextEdit.SetSearchFlags(System.UInt32)" />.</para>
    /// </summary>
    public void SetSearchText(string searchText) => _node.SetSearchText(searchText);
    /// <summary>
    /// <para>Sets the current selection mode.</para>
    /// </summary>
    public void SetSelectionMode(TextEdit.SelectionMode mode, int line, int column, int caretIndex) => _node.SetSelectionMode(mode, line, column, caretIndex);
    /// <summary>
    /// <para>Sets the tab size for the <see cref="TextEdit" /> to use.</para>
    /// </summary>
    public void SetTabSize(int size) => _node.SetTabSize(size);
    /// <summary>
    /// <para>Provide custom tooltip text. The callback method must take the following args: <c>hovered_word: String</c>.</para>
    /// </summary>
    public void SetTooltipRequestFunc(Callable callback) => _node.SetTooltipRequestFunc(callback);
    /// <summary>
    /// <para>If <c>true</c>, shortcut keys for context menu items are enabled, even if the context menu is disabled.</para>
    /// </summary>
    public bool ShortcutKeysEnabled { get => _node.ShortcutKeysEnabled; set => _node.ShortcutKeysEnabled = value; }
    /// <summary>
    /// <para>Starts an action, will end the current action if <paramref name="action" /> is different.</para>
    /// <para>An action will also end after a call to <see cref="TextEdit.EndAction" />, after <c>ProjectSettings.gui/timers/text_edit_idle_detect_sec</c> is triggered or a new undoable step outside the <see cref="TextEdit.StartAction(Godot.TextEdit.EditAction)" /> and <see cref="TextEdit.EndAction" /> calls.</para>
    /// </summary>
    public void StartAction(TextEdit.EditAction action) => _node.StartAction(action);
    /// <summary>
    /// <para>Set BiDi algorithm override for the structured text.</para>
    /// </summary>
    public TextServer.StructuredTextParser StructuredTextBidiOverride { get => _node.StructuredTextBidiOverride; set => _node.StructuredTextBidiOverride = value; }
    /// <summary>
    /// <para>Set additional options for BiDi override.</para>
    /// </summary>
    public Godot.Collections.Array StructuredTextBidiOverrideOptions { get => _node.StructuredTextBidiOverrideOptions; set => _node.StructuredTextBidiOverrideOptions = value; }
    /// <summary>
    /// <para>Swaps the two lines.</para>
    /// </summary>
    public void SwapLines(int fromLine, int toLine) => _node.SwapLines(fromLine, toLine);
    /// <summary>
    /// <para>Sets the <see cref="SyntaxHighlighter" /> to use.</para>
    /// </summary>
    public SyntaxHighlighter SyntaxHighlighter { get => _node.SyntaxHighlighter; set => _node.SyntaxHighlighter = value; }
    /// <summary>
    /// <para>Tag the current version as saved.</para>
    /// </summary>
    public void TagSavedVersion() => _node.TagSavedVersion();
    /// <summary>
    /// <para>String value of the <see cref="TextEdit" />.</para>
    /// </summary>
    public string Text { get => _node.Text; set => _node.Text = value; }
    /// <summary>
    /// <para>Base text writing direction.</para>
    /// </summary>
    public Control.TextDirection TextDirection { get => _node.TextDirection; set => _node.TextDirection = value; }
    /// <summary>
    /// <para>Perform undo operation.</para>
    /// </summary>
    public void Undo() => _node.Undo();
    /// <summary>
    /// <para>If <c>true</c>, the native virtual keyboard is shown when focused on platforms that support it.</para>
    /// </summary>
    public bool VirtualKeyboardEnabled { get => _node.VirtualKeyboardEnabled; set => _node.VirtualKeyboardEnabled = value; }
    /// <summary>
    /// <para>Sets the line wrapping mode to use.</para>
    /// </summary>
    public TextEdit.LineWrappingMode WrapMode { get => _node.WrapMode; set => _node.WrapMode = value; }

}