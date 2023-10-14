namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
using Godot.Collections;


/// <summary>
/// <para>A multiline text editor. It also has limited facilities for editing code, such as syntax highlighting support. For more advanced facilities for editing code, see <see cref="CodeEdit" />.</para>
/// <para><b>Note:</b> Most viewport, caret and edit methods contain a <c>caret_index</c> argument for <see cref="TextEdit.CaretMultiple" /> support. The argument should be one of the following: <c>-1</c> for all carets, <c>0</c> for the main caret, or greater than <c>0</c> for secondary carets.</para>
/// <para><b>Note:</b> When holding down Alt, the vertical scroll wheel will scroll 5 times as fast as it would normally do. This also works in the Godot script editor.</para>
/// </summary>
public interface ITextEdit : IControl {
    /// <summary>
    /// <para>Merge the gutters from <paramref name="fromLine" /> into <paramref name="toLine" />. Only overwritable gutters will be copied.</para>
    /// </summary>
    void MergeGutters(int fromLine, int toLine);
    /// <summary>
    /// <para>Set a custom draw method for the gutter. The callback method must take the following args: <c>line: int, gutter: int, Area: Rect2</c>.</para>
    /// </summary>
    void SetGutterCustomDraw(int column, Callable drawCallback);
    /// <summary>
    /// <para>Returns the total width of all gutters and internal padding.</para>
    /// </summary>
    int GetTotalGutterWidth();
    /// <summary>
    /// <para>Sets the metadata for <paramref name="gutter" /> on <paramref name="line" /> to <paramref name="metadata" />.</para>
    /// </summary>
    void SetLineGutterMetadata(int line, int gutter, Variant metadata);
    /// <summary>
    /// <para>Returns the metadata currently in <paramref name="gutter" /> at <paramref name="line" />.</para>
    /// </summary>
    Variant GetLineGutterMetadata(int line, int gutter);
    /// <summary>
    /// <para>Sets the text for <paramref name="gutter" /> on <paramref name="line" /> to <paramref name="text" />.</para>
    /// </summary>
    void SetLineGutterText(int line, int gutter, string text);
    /// <summary>
    /// <para>Returns the text currently in <paramref name="gutter" /> at <paramref name="line" />.</para>
    /// </summary>
    string GetLineGutterText(int line, int gutter);
    /// <summary>
    /// <para>Sets the icon for <paramref name="gutter" /> on <paramref name="line" /> to <paramref name="icon" />.</para>
    /// </summary>
    void SetLineGutterIcon(int line, int gutter, Texture2D icon);
    /// <summary>
    /// <para>Returns the icon currently in <paramref name="gutter" /> at <paramref name="line" />.</para>
    /// </summary>
    Texture2D GetLineGutterIcon(int line, int gutter);
    /// <summary>
    /// <para>Sets the color for <paramref name="gutter" /> on <paramref name="line" /> to <paramref name="color" />.</para>
    /// </summary>
    void SetLineGutterItemColor(int line, int gutter, Color color);
    /// <summary>
    /// <para>Returns the color currently in <paramref name="gutter" /> at <paramref name="line" />.</para>
    /// </summary>
    Color GetLineGutterItemColor(int line, int gutter);
    /// <summary>
    /// <para>If <paramref name="clickable" /> is <c>true</c>, makes the <paramref name="gutter" /> on <paramref name="line" /> clickable. See <see cref="TextEdit.GutterClicked" />.</para>
    /// </summary>
    void SetLineGutterClickable(int line, int gutter, bool clickable);
    /// <summary>
    /// <para>Returns whether the gutter on the given line is clickable.</para>
    /// </summary>
    bool IsLineGutterClickable(int line, int gutter);
    /// <summary>
    /// <para>Sets the current background color of the line. Set to <c>Color(0, 0, 0, 0)</c> for no color.</para>
    /// </summary>
    void SetLineBackgroundColor(int line, Color color);
    /// <summary>
    /// <para>Returns the current background color of the line. <c>Color(0, 0, 0, 0)</c> is returned if no color is set.</para>
    /// </summary>
    Color GetLineBackgroundColor(int line);
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
    PopupMenu GetMenu();
    /// <summary>
    /// <para>Returns whether the menu is visible. Use this instead of <c>get_menu().visible</c> to improve performance (so the creation of the menu is avoided).</para>
    /// </summary>
    bool IsMenuVisible();
    /// <summary>
    /// <para>Executes a given action as defined in the <see cref="TextEdit.MenuItems" /> enum.</para>
    /// </summary>
    void MenuOption(int option);
    /// <summary>
    /// <para>Starts a multipart edit. All edits will be treated as one action until <see cref="TextEdit.EndComplexOperation" /> is called.</para>
    /// </summary>
    void BeginComplexOperation();
    /// <summary>
    /// <para>Ends a multipart edit, started with <see cref="TextEdit.BeginComplexOperation" />. If called outside a complex operation, the current operation is pushed onto the undo/redo stack.</para>
    /// </summary>
    void EndComplexOperation();
    /// <summary>
    /// <para>Returns <c>true</c> if an "undo" action is available.</para>
    /// </summary>
    bool HasUndo();
    /// <summary>
    /// <para>Returns <c>true</c> if a "redo" action is available.</para>
    /// </summary>
    bool HasRedo();
    /// <summary>
    /// <para>Perform undo operation.</para>
    /// </summary>
    void Undo();
    /// <summary>
    /// <para>Perform redo operation.</para>
    /// </summary>
    void Redo();
    /// <summary>
    /// <para>Clears the undo history.</para>
    /// </summary>
    void ClearUndoHistory();
    /// <summary>
    /// <para>Tag the current version as saved.</para>
    /// </summary>
    void TagSavedVersion();
    /// <summary>
    /// <para>Returns the current version of the <see cref="TextEdit" />. The version is a count of recorded operations by the undo/redo history.</para>
    /// </summary>
    uint GetVersion();
    /// <summary>
    /// <para>Returns the last tagged saved version from <see cref="TextEdit.TagSavedVersion" />.</para>
    /// </summary>
    uint GetSavedVersion();
    /// <summary>
    /// <para>Sets the search text. See <see cref="M:Godot.TextEdit.SetSearchFlags(System.UInt32)" />.</para>
    /// </summary>
    void SetSearchText(string searchText);
    /// <summary>
    /// <para>Sets the search <paramref name="flags" />. This is used with <see cref="M:Godot.TextEdit.SetSearchText(System.String)" /> to highlight occurrences of the searched text. Search flags can be specified from the <see cref="TextEdit.SearchFlags" /> enum.</para>
    /// </summary>
    void SetSearchFlags(uint flags);
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
    Vector2I Search(string text, uint flags, int fromLine, int fromColum);
    /// <summary>
    /// <para>Provide custom tooltip text. The callback method must take the following args: <c>hovered_word: String</c>.</para>
    /// </summary>
    void SetTooltipRequestFunc(Callable callback);
    /// <summary>
    /// <para>Returns the local mouse position adjusted for the text direction.</para>
    /// </summary>
    Vector2 GetLocalMousePos();
    /// <summary>
    /// <para>Returns the word at <paramref name="position" />.</para>
    /// </summary>
    string GetWordAtPos(Vector2 position);
    /// <summary>
    /// <para>Returns the line and column at the given position. In the returned vector, <c>x</c> is the column, <c>y</c> is the line. If <paramref name="allowOutOfBounds" /> is <c>false</c> and the position is not over the text, both vector values will be set to <c>-1</c>.</para>
    /// </summary>
    Vector2I GetLineColumnAtPos(Vector2I position, bool allowOutOfBounds);
    /// <summary>
    /// <para>Returns the local position for the given <paramref name="line" /> and <paramref name="column" />. If <c>x</c> or <c>y</c> of the returned vector equal <c>-1</c>, the position is outside of the viewable area of the control.</para>
    /// <para><b>Note:</b> The Y position corresponds to the bottom side of the line. Use <see cref="M:Godot.TextEdit.GetRectAtLineColumn(System.Int32,System.Int32)" /> to get the top side position.</para>
    /// </summary>
    Vector2I GetPosAtLineColumn(int line, int column);
    /// <summary>
    /// <para>Returns the local position and size for the grapheme at the given <paramref name="line" /> and <paramref name="column" />. If <c>x</c> or <c>y</c> position of the returned rect equal <c>-1</c>, the position is outside of the viewable area of the control.</para>
    /// <para><b>Note:</b> The Y position of the returned rect corresponds to the top side of the line, unlike <see cref="M:Godot.TextEdit.GetPosAtLineColumn(System.Int32,System.Int32)" /> which returns the bottom side.</para>
    /// </summary>
    Rect2I GetRectAtLineColumn(int line, int column);
    /// <summary>
    /// <para>Returns the equivalent minimap line at <paramref name="position" />.</para>
    /// </summary>
    int GetMinimapLineAtPos(Vector2I position);
    /// <summary>
    /// <para>Returns <c>true</c> if the user is dragging their mouse for scrolling or selecting.</para>
    /// </summary>
    bool IsDraggingCursor();
    /// <summary>
    /// <para>Returns whether the mouse is over selection. If <paramref name="edges" /> is <c>true</c>, the edges are considered part of the selection.</para>
    /// </summary>
    bool IsMouseOverSelection(bool edges, int caretIndex);
    /// <summary>
    /// <para>Adds a new caret at the given location. Returns the index of the new caret, or <c>-1</c> if the location is invalid.</para>
    /// </summary>
    int AddCaret(int line, int col);
    /// <summary>
    /// <para>Removes the given caret index.</para>
    /// <para><b>Note:</b> This can result in adjustment of all other caret indices.</para>
    /// </summary>
    void RemoveCaret(int caret);
    /// <summary>
    /// <para>Removes all additional carets.</para>
    /// </summary>
    void RemoveSecondaryCarets();
    /// <summary>
    /// <para>Merges any overlapping carets. Will favor the newest caret, or the caret with a selection.</para>
    /// <para><b>Note:</b> This is not called when a caret changes position but after certain actions, so it is possible to get into a state where carets overlap.</para>
    /// </summary>
    void MergeOverlappingCarets();
    /// <summary>
    /// <para>Returns the number of carets in this <see cref="TextEdit" />.</para>
    /// </summary>
    int GetCaretCount();
    /// <summary>
    /// <para>Adds an additional caret above or below every caret. If <paramref name="below" /> is true the new caret will be added below and above otherwise.</para>
    /// </summary>
    void AddCaretAtCarets(bool below);
    /// <summary>
    /// <para>Returns a list of caret indexes in their edit order, this done from bottom to top. Edit order refers to the way actions such as <see cref="M:Godot.TextEdit.InsertTextAtCaret(System.String,System.Int32)" /> are applied.</para>
    /// </summary>
    int[] GetCaretIndexEditOrder();
    /// <summary>
    /// <para>Reposition the carets affected by the edit. This assumes edits are applied in edit order, see <see cref="TextEdit.GetCaretIndexEditOrder" />.</para>
    /// </summary>
    void AdjustCaretsAfterEdit(int caret, int fromLine, int fromCol, int toLine, int toCol);
    /// <summary>
    /// <para>Returns <c>true</c> if the caret is visible on the screen.</para>
    /// </summary>
    bool IsCaretVisible(int caretIndex);
    /// <summary>
    /// <para>Returns the caret pixel draw position.</para>
    /// </summary>
    Vector2 GetCaretDrawPos(int caretIndex);
    /// <summary>
    /// <para>Moves the caret to the specified <paramref name="line" /> index.</para>
    /// <para>If <paramref name="adjustViewport" /> is <c>true</c>, the viewport will center at the caret position after the move occurs.</para>
    /// <para>If <paramref name="canBeHidden" /> is <c>true</c>, the specified <paramref name="line" /> can be hidden.</para>
    /// <para><b>Note:</b> If supporting multiple carets this will not check for any overlap. See <see cref="TextEdit.MergeOverlappingCarets" />.</para>
    /// </summary>
    void SetCaretLine(int line, bool adjustViewport, bool canBeHidden, int wrapIndex, int caretIndex);
    /// <summary>
    /// <para>Returns the line the editing caret is on.</para>
    /// </summary>
    int GetCaretLine(int caretIndex);
    /// <summary>
    /// <para>Moves the caret to the specified <paramref name="column" /> index.</para>
    /// <para>If <paramref name="adjustViewport" /> is <c>true</c>, the viewport will center at the caret position after the move occurs.</para>
    /// <para><b>Note:</b> If supporting multiple carets this will not check for any overlap. See <see cref="TextEdit.MergeOverlappingCarets" />.</para>
    /// </summary>
    void SetCaretColumn(int column, bool adjustViewport, int caretIndex);
    /// <summary>
    /// <para>Returns the column the editing caret is at.</para>
    /// </summary>
    int GetCaretColumn(int caretIndex);
    /// <summary>
    /// <para>Returns the wrap index the editing caret is on.</para>
    /// </summary>
    int GetCaretWrapIndex(int caretIndex);
    /// <summary>
    /// <para>Returns a <see cref="T:System.String" /> text with the word under the caret's location.</para>
    /// </summary>
    string GetWordUnderCaret(int caretIndex);
    /// <summary>
    /// <para>Sets the current selection mode.</para>
    /// </summary>
    void SetSelectionMode(TextEdit.SelectionMode mode, int line, int column, int caretIndex);
    /// <summary>
    /// <para>Returns the current selection mode.</para>
    /// </summary>
    TextEdit.SelectionMode GetSelectionMode();
    /// <summary>
    /// <para>Select all the text.</para>
    /// <para>If <see cref="TextEdit.SelectingEnabled" /> is <c>false</c>, no selection will occur.</para>
    /// </summary>
    void SelectAll();
    /// <summary>
    /// <para>Selects the word under the caret.</para>
    /// </summary>
    void SelectWordUnderCaret(int caretIndex);
    /// <summary>
    /// <para>Adds a selection and a caret for the next occurrence of the current selection. If there is no active selection, selects word under caret.</para>
    /// </summary>
    void AddSelectionForNextOccurrence();
    /// <summary>
    /// <para>Perform selection, from line/column to line/column.</para>
    /// <para>If <see cref="TextEdit.SelectingEnabled" /> is <c>false</c>, no selection will occur.</para>
    /// </summary>
    void Select(int fromLine, int fromColumn, int toLine, int toColumn, int caretIndex);
    /// <summary>
    /// <para>Returns <c>true</c> if the user has selected text.</para>
    /// </summary>
    bool HasSelection(int caretIndex);
    /// <summary>
    /// <para>Returns the text inside the selection of a caret, or all the carets if <paramref name="caretIndex" /> is its default value <c>-1</c>.</para>
    /// </summary>
    string GetSelectedText(int caretIndex);
    /// <summary>
    /// <para>Returns the original start line of the selection.</para>
    /// </summary>
    int GetSelectionLine(int caretIndex);
    /// <summary>
    /// <para>Returns the original start column of the selection.</para>
    /// </summary>
    int GetSelectionColumn(int caretIndex);
    /// <summary>
    /// <para>Returns the selection begin line.</para>
    /// </summary>
    int GetSelectionFromLine(int caretIndex);
    /// <summary>
    /// <para>Returns the selection begin column.</para>
    /// </summary>
    int GetSelectionFromColumn(int caretIndex);
    /// <summary>
    /// <para>Returns the selection end line.</para>
    /// </summary>
    int GetSelectionToLine(int caretIndex);
    /// <summary>
    /// <para>Returns the selection end column.</para>
    /// </summary>
    int GetSelectionToColumn(int caretIndex);
    /// <summary>
    /// <para>Deselects the current selection.</para>
    /// </summary>
    void Deselect(int caretIndex);
    /// <summary>
    /// <para>Deletes the selected text.</para>
    /// </summary>
    void DeleteSelection(int caretIndex);
    /// <summary>
    /// <para>Returns if the given line is wrapped.</para>
    /// </summary>
    bool IsLineWrapped(int line);
    /// <summary>
    /// <para>Returns the number of times the given line is wrapped.</para>
    /// </summary>
    int GetLineWrapCount(int line);
    /// <summary>
    /// <para>Returns the wrap index of the given line column.</para>
    /// </summary>
    int GetLineWrapIndexAtColumn(int line, int column);
    /// <summary>
    /// <para>Returns an array of <see cref="T:System.String" />s representing each wrapped index.</para>
    /// </summary>
    string[] GetLineWrappedText(int line);
    /// <summary>
    /// <para>Returns the <see cref="VScrollBar" /> of the <see cref="TextEdit" />.</para>
    /// </summary>
    VScrollBar GetVScrollBar();
    /// <summary>
    /// <para>Returns the <see cref="HScrollBar" /> used by <see cref="TextEdit" />.</para>
    /// </summary>
    HScrollBar GetHScrollBar();
    /// <summary>
    /// <para>Returns the scroll position for <paramref name="wrapIndex" /> of <paramref name="line" />.</para>
    /// </summary>
    double GetScrollPosForLine(int line, int wrapIndex);
    /// <summary>
    /// <para>Positions the <paramref name="wrapIndex" /> of <paramref name="line" /> at the top of the viewport.</para>
    /// </summary>
    void SetLineAsFirstVisible(int line, int wrapIndex);
    /// <summary>
    /// <para>Returns the first visible line.</para>
    /// </summary>
    int GetFirstVisibleLine();
    /// <summary>
    /// <para>Positions the <paramref name="wrapIndex" /> of <paramref name="line" /> at the center of the viewport.</para>
    /// </summary>
    void SetLineAsCenterVisible(int line, int wrapIndex);
    /// <summary>
    /// <para>Positions the <paramref name="wrapIndex" /> of <paramref name="line" /> at the bottom of the viewport.</para>
    /// </summary>
    void SetLineAsLastVisible(int line, int wrapIndex);
    /// <summary>
    /// <para>Returns the last visible line. Use <see cref="TextEdit.GetLastFullVisibleLineWrapIndex" /> for the wrap index.</para>
    /// </summary>
    int GetLastFullVisibleLine();
    /// <summary>
    /// <para>Returns the last visible wrap index of the last visible line.</para>
    /// </summary>
    int GetLastFullVisibleLineWrapIndex();
    /// <summary>
    /// <para>Returns the number of visible lines, including wrapped text.</para>
    /// </summary>
    int GetVisibleLineCount();
    /// <summary>
    /// <para>Returns the total number of visible + wrapped lines between the two lines.</para>
    /// </summary>
    int GetVisibleLineCountInRange(int fromLine, int toLine);
    /// <summary>
    /// <para>Returns the number of lines that may be drawn.</para>
    /// </summary>
    int GetTotalVisibleLineCount();
    /// <summary>
    /// <para>Adjust the viewport so the caret is visible.</para>
    /// </summary>
    void AdjustViewportToCaret(int caretIndex);
    /// <summary>
    /// <para>Centers the viewport on the line the editing caret is at. This also resets the <see cref="TextEdit.ScrollHorizontal" /> value to <c>0</c>.</para>
    /// </summary>
    void CenterViewportToCaret(int caretIndex);
    /// <summary>
    /// <para>Returns the number of lines that may be drawn on the minimap.</para>
    /// </summary>
    int GetMinimapVisibleLines();
    /// <summary>
    /// <para>Register a new gutter to this <see cref="TextEdit" />. Use <paramref name="at" /> to have a specific gutter order. A value of <c>-1</c> appends the gutter to the right.</para>
    /// </summary>
    void AddGutter(int at);
    /// <summary>
    /// <para>Removes the gutter from this <see cref="TextEdit" />.</para>
    /// </summary>
    void RemoveGutter(int gutter);
    /// <summary>
    /// <para>Returns the number of gutters registered.</para>
    /// </summary>
    int GetGutterCount();
    /// <summary>
    /// <para>Sets the name of the gutter.</para>
    /// </summary>
    void SetGutterName(int gutter, string name);
    /// <summary>
    /// <para>Returns the name of the gutter at the given index.</para>
    /// </summary>
    string GetGutterName(int gutter);
    /// <summary>
    /// <para>Sets the type of gutter.</para>
    /// </summary>
    void SetGutterType(int gutter, TextEdit.GutterType @type);
    /// <summary>
    /// <para>Returns the type of the gutter at the given index.</para>
    /// </summary>
    TextEdit.GutterType GetGutterType(int gutter);
    /// <summary>
    /// <para>Set the width of the gutter.</para>
    /// </summary>
    void SetGutterWidth(int gutter, int width);
    /// <summary>
    /// <para>Returns the width of the gutter at the given index.</para>
    /// </summary>
    int GetGutterWidth(int gutter);
    /// <summary>
    /// <para>Sets whether the gutter should be drawn.</para>
    /// </summary>
    void SetGutterDraw(int gutter, bool draw);
    /// <summary>
    /// <para>Returns whether the gutter is currently drawn.</para>
    /// </summary>
    bool IsGutterDrawn(int gutter);
    /// <summary>
    /// <para>Sets the gutter as clickable. This will change the mouse cursor to a pointing hand when hovering over the gutter.</para>
    /// </summary>
    void SetGutterClickable(int gutter, bool clickable);
    /// <summary>
    /// <para>Returns whether the gutter is clickable.</para>
    /// </summary>
    bool IsGutterClickable(int gutter);
    /// <summary>
    /// <para>Sets the gutter to overwritable. See <see cref="M:Godot.TextEdit.MergeGutters(System.Int32,System.Int32)" />.</para>
    /// </summary>
    void SetGutterOverwritable(int gutter, bool overwritable);
    /// <summary>
    /// <para>Returns whether the gutter is overwritable.</para>
    /// </summary>
    bool IsGutterOverwritable(int gutter);
    /// <summary>
    /// <para>Override this method to define what happens when the user presses the backspace key.</para>
    /// </summary>
    void _Backspace(int caretIndex);
    /// <summary>
    /// <para>Override this method to define what happens when the user performs a copy operation.</para>
    /// </summary>
    void _Copy(int caretIndex);
    /// <summary>
    /// <para>Override this method to define what happens when the user performs a cut operation.</para>
    /// </summary>
    void _Cut(int caretIndex);
    /// <summary>
    /// <para>Override this method to define what happens when the user types in the provided key <paramref name="unicodeChar" />.</para>
    /// </summary>
    void _HandleUnicodeInput(int unicodeChar, int caretIndex);
    /// <summary>
    /// <para>Override this method to define what happens when the user performs a paste operation.</para>
    /// </summary>
    void _Paste(int caretIndex);
    /// <summary>
    /// <para>Override this method to define what happens when the user performs a paste operation with middle mouse button.</para>
    /// <para><b>Note:</b> This method is only implemented on Linux.</para>
    /// </summary>
    void _PastePrimaryClipboard(int caretIndex);
    /// <summary>
    /// <para>Returns if the user has IME text.</para>
    /// </summary>
    bool HasImeText();
    /// <summary>
    /// <para>Sets the tab size for the <see cref="TextEdit" /> to use.</para>
    /// </summary>
    void SetTabSize(int size);
    /// <summary>
    /// <para>Returns the <see cref="TextEdit" />'s' tab size.</para>
    /// </summary>
    int GetTabSize();
    /// <summary>
    /// <para>If <c>true</c>, sets the user into overtype mode. When the user types in this mode, it will override existing text.</para>
    /// </summary>
    void SetOvertypeModeEnabled(bool enabled);
    /// <summary>
    /// <para>Returns whether the user is in overtype mode.</para>
    /// </summary>
    bool IsOvertypeModeEnabled();
    /// <summary>
    /// <para>Performs a full reset of <see cref="TextEdit" />, including undo history.</para>
    /// </summary>
    void Clear();
    /// <summary>
    /// <para>Returns the number of lines in the text.</para>
    /// </summary>
    int GetLineCount();
    /// <summary>
    /// <para>Sets the text for a specific line.</para>
    /// </summary>
    void SetLine(int line, string newText);
    /// <summary>
    /// <para>Returns the text of a specific line.</para>
    /// </summary>
    string GetLine(int line);
    /// <summary>
    /// <para>Returns the width in pixels of the <paramref name="wrapIndex" /> on <paramref name="line" />.</para>
    /// </summary>
    int GetLineWidth(int line, int wrapIndex);
    /// <summary>
    /// <para>Returns the maximum value of the line height among all lines.</para>
    /// <para><b>Note:</b> The return value is influenced by <c>line_spacing</c> and <c>font_size</c>. And it will not be less than <c>1</c>.</para>
    /// </summary>
    int GetLineHeight();
    /// <summary>
    /// <para>Returns the number of spaces and <c>tab * tab_size</c> before the first char.</para>
    /// </summary>
    int GetIndentLevel(int line);
    /// <summary>
    /// <para>Returns the first column containing a non-whitespace character.</para>
    /// </summary>
    int GetFirstNonWhiteSpaceColumn(int line);
    /// <summary>
    /// <para>Swaps the two lines.</para>
    /// </summary>
    void SwapLines(int fromLine, int toLine);
    /// <summary>
    /// <para>Inserts a new line with <paramref name="text" /> at <paramref name="line" />.</para>
    /// </summary>
    void InsertLineAt(int line, string text);
    /// <summary>
    /// <para>Insert the specified text at the caret position.</para>
    /// </summary>
    void InsertTextAtCaret(string text, int caretIndex);
    /// <summary>
    /// <para>Removes text between the given positions.</para>
    /// <para><b>Note:</b> This does not adjust the caret or selection, which as a result it can end up in an invalid position.</para>
    /// </summary>
    void RemoveText(int fromLine, int fromColumn, int toLine, int toColumn);
    /// <summary>
    /// <para>Returns the last unhidden line in the entire <see cref="TextEdit" />.</para>
    /// </summary>
    int GetLastUnhiddenLine();
    /// <summary>
    /// <para>Returns the count to the next visible line from <paramref name="line" /> to <c>line + visible_amount</c>. Can also count backwards. For example if a <see cref="TextEdit" /> has 5 lines with lines 2 and 3 hidden, calling this with <c>line = 1, visible_amount = 1</c> would return 3.</para>
    /// </summary>
    int GetNextVisibleLineOffsetFrom(int line, int visibleAmount);
    /// <summary>
    /// <para>Similar to <see cref="M:Godot.TextEdit.GetNextVisibleLineOffsetFrom(System.Int32,System.Int32)" />, but takes into account the line wrap indexes. In the returned vector, <c>x</c> is the line, <c>y</c> is the wrap index.</para>
    /// </summary>
    Vector2I GetNextVisibleLineIndexOffsetFrom(int line, int wrapIndex, int visibleAmount);
    /// <summary>
    /// <para>Called when the user presses the backspace key. Can be overridden with <see cref="M:Godot.TextEdit._Backspace(System.Int32)" />.</para>
    /// </summary>
    void Backspace(int caretIndex);
    /// <summary>
    /// <para>Cut's the current selection. Can be overridden with <see cref="M:Godot.TextEdit._Cut(System.Int32)" />.</para>
    /// </summary>
    void Cut(int caretIndex);
    /// <summary>
    /// <para>Copies the current text selection. Can be overridden with <see cref="M:Godot.TextEdit._Copy(System.Int32)" />.</para>
    /// </summary>
    void Copy(int caretIndex);
    /// <summary>
    /// <para>Paste at the current location. Can be overridden with <see cref="M:Godot.TextEdit._Paste(System.Int32)" />.</para>
    /// </summary>
    void Paste(int caretIndex);
    /// <summary>
    /// <para>Pastes the primary clipboard.</para>
    /// </summary>
    void PastePrimaryClipboard(int caretIndex);
    /// <summary>
    /// <para>Starts an action, will end the current action if <paramref name="action" /> is different.</para>
    /// <para>An action will also end after a call to <see cref="TextEdit.EndAction" />, after <c>ProjectSettings.gui/timers/text_edit_idle_detect_sec</c> is triggered or a new undoable step outside the <see cref="M:Godot.TextEdit.StartAction(Godot.TextEdit.EditAction)" /> and <see cref="TextEdit.EndAction" /> calls.</para>
    /// </summary>
    void StartAction(TextEdit.EditAction action);
    /// <summary>
    /// <para>Marks the end of steps in the current action started with <see cref="M:Godot.TextEdit.StartAction(Godot.TextEdit.EditAction)" />.</para>
    /// </summary>
    void EndAction();
    /// <summary>
    /// <para>String value of the <see cref="TextEdit" />.</para>
    /// </summary>
    string Text { get; set; }
    /// <summary>
    /// <para>Text shown when the <see cref="TextEdit" /> is empty. It is <b>not</b> the <see cref="TextEdit" />'s default value (see <see cref="TextEdit.Text" />).</para>
    /// </summary>
    string PlaceholderText { get; set; }
    /// <summary>
    /// <para>If <c>false</c>, existing text cannot be modified and new text cannot be added.</para>
    /// </summary>
    bool Editable { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, a right-click displays the context menu.</para>
    /// </summary>
    bool ContextMenuEnabled { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, shortcut keys for context menu items are enabled, even if the context menu is disabled.</para>
    /// </summary>
    bool ShortcutKeysEnabled { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, text can be selected.</para>
    /// <para>If <c>false</c>, text can not be selected by the user or by the <see cref="M:Godot.TextEdit.Select(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32)" /> or <see cref="TextEdit.SelectAll" /> methods.</para>
    /// </summary>
    bool SelectingEnabled { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the selected text will be deselected when focus is lost.</para>
    /// </summary>
    bool DeselectOnFocusLossEnabled { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, allow drag and drop of selected text.</para>
    /// </summary>
    bool DragAndDropSelectionEnabled { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the native virtual keyboard is shown when focused on platforms that support it.</para>
    /// </summary>
    bool VirtualKeyboardEnabled { get; set; }
    /// <summary>
    /// <para>If <c>false</c>, using middle mouse button to paste clipboard will be disabled.</para>
    /// <para><b>Note:</b> This method is only implemented on Linux.</para>
    /// </summary>
    bool MiddleMousePasteEnabled { get; set; }
    /// <summary>
    /// <para>Sets the line wrapping mode to use.</para>
    /// </summary>
    TextEdit.LineWrappingMode WrapMode { get; set; }
    /// <summary>
    /// <para>If <see cref="TextEdit.WrapMode" /> is set to <see cref="TextEdit.LineWrappingMode.Boundary" />, sets text wrapping mode. To see how each mode behaves, see <see cref="TextServer.AutowrapMode" />.</para>
    /// </summary>
    TextServer.AutowrapMode AutowrapMode { get; set; }
    /// <summary>
    /// <para>Scroll smoothly over the text rather than jumping to the next location.</para>
    /// </summary>
    bool ScrollSmooth { get; set; }
    /// <summary>
    /// <para>Sets the scroll speed with the minimap or when <see cref="TextEdit.ScrollSmooth" /> is enabled.</para>
    /// </summary>
    float ScrollVScrollSpeed { get; set; }
    /// <summary>
    /// <para>Allow scrolling past the last line into "virtual" space.</para>
    /// </summary>
    bool ScrollPastEndOfFile { get; set; }
    /// <summary>
    /// <para>If there is a vertical scrollbar, this determines the current vertical scroll value in line numbers, starting at 0 for the top line.</para>
    /// </summary>
    double ScrollVertical { get; set; }
    /// <summary>
    /// <para>If there is a horizontal scrollbar, this determines the current horizontal scroll value in pixels.</para>
    /// </summary>
    int ScrollHorizontal { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, <see cref="TextEdit" /> will disable vertical scroll and fit minimum height to the number of visible lines.</para>
    /// </summary>
    bool ScrollFitContentHeight { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, a minimap is shown, providing an outline of your source code.</para>
    /// </summary>
    bool MinimapDraw { get; set; }
    /// <summary>
    /// <para>The width, in pixels, of the minimap.</para>
    /// </summary>
    int MinimapWidth { get; set; }
    /// <summary>
    /// <para>Set the type of caret to draw.</para>
    /// </summary>
    TextEdit.CaretTypeEnum CaretType { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, makes the caret blink.</para>
    /// </summary>
    bool CaretBlink { get; set; }
    /// <summary>
    /// <para>The interval at which the caret blinks (in seconds).</para>
    /// </summary>
    float CaretBlinkInterval { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, caret will be visible when <see cref="TextEdit.Editable" /> is disabled.</para>
    /// </summary>
    bool CaretDrawWhenEditableDisabled { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, a right-click moves the caret at the mouse position before displaying the context menu.</para>
    /// <para>If <c>false</c>, the context menu disregards mouse location.</para>
    /// </summary>
    bool CaretMoveOnRightClick { get; set; }
    /// <summary>
    /// <para>Allow moving caret, selecting and removing the individual composite character components.</para>
    /// <para><b>Note:</b> Backspace is always removing individual composite character components.</para>
    /// </summary>
    bool CaretMidGrapheme { get; set; }
    /// <summary>
    /// <para>Sets if multiple carets are allowed.</para>
    /// </summary>
    bool CaretMultiple { get; set; }
    /// <summary>
    /// <para>Sets the <see cref="SyntaxHighlighter" /> to use.</para>
    /// </summary>
    SyntaxHighlighter SyntaxHighlighter { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, all occurrences of the selected text will be highlighted.</para>
    /// </summary>
    bool HighlightAllOccurrences { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the line containing the cursor is highlighted.</para>
    /// </summary>
    bool HighlightCurrentLine { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, control characters are displayed.</para>
    /// </summary>
    bool DrawControlChars { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the "tab" character will have a visible representation.</para>
    /// </summary>
    bool DrawTabs { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the "space" character will have a visible representation.</para>
    /// </summary>
    bool DrawSpaces { get; set; }
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