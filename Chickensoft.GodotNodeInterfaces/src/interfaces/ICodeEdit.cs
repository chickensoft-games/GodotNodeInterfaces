namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
using Godot.Collections;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class CodeEditNode : CodeEdit, ICodeEdit { }

/// <summary>
/// <para>CodeEdit is a specialized <see cref="TextEdit" /> designed for editing plain text code files. It has many features commonly found in code editors such as line numbers, line folding, code completion, indent management, and string/comment management.</para>
/// <para><b>Note:</b> Regardless of locale, <see cref="CodeEdit" /> will by default always use left-to-right text direction to correctly display source code.</para>
/// </summary>
public interface ICodeEdit : ITextEdit {
    /// <summary>
    /// <para>Override this method to define how the selected entry should be inserted. If <paramref name="replace" /> is true, any existing text should be replaced.</para>
    /// </summary>
    void _ConfirmCodeCompletion(bool replace);
    /// <summary>
    /// <para>Override this method to define what items in <paramref name="candidates" /> should be displayed.</para>
    /// <para>Both <paramref name="candidates" /> and the return is a <see cref="Collections.Array" /> of <see cref="Collections.Dictionary" />, see <see cref="CodeEdit.GetCodeCompletionOption(System.Int32)" /> for <see cref="Collections.Dictionary" /> content.</para>
    /// </summary>
    Godot.Collections.Array<Dictionary> _FilterCodeCompletionCandidates(Godot.Collections.Array<Dictionary> candidates);
    /// <summary>
    /// <para>Override this method to define what happens when the user requests code completion. If <paramref name="force" /> is true, any checks should be bypassed.</para>
    /// </summary>
    void _RequestCodeCompletion(bool force);
    /// <summary>
    /// <para>Adds a brace pair.</para>
    /// <para>Both the start and end keys must be symbols. Only the start key has to be unique.</para>
    /// </summary>
    void AddAutoBraceCompletionPair(string startKey, string endKey);
    /// <summary>
    /// <para>Submits an item to the queue of potential candidates for the autocomplete menu. Call <see cref="CodeEdit.UpdateCodeCompletionOptions(System.Boolean)" /> to update the list.</para>
    /// <para><paramref name="location" /> indicates location of the option relative to the location of the code completion query. See <see cref="CodeEdit.CodeCompletionLocation" /> for how to set this value.</para>
    /// <para><b>Note:</b> This list will replace all current candidates.</para>
    /// </summary>
    /// <param name="textColor">If the parameter is null, then the default value is <c>new Color(1, 1, 1, 1)</c>.</param>
    /// <param name="value">If the parameter is null, then the default value is <c>(Variant)(0)</c>.</param>
    void AddCodeCompletionOption(CodeEdit.CodeCompletionKind @type, string displayText, string insertText, Nullable<Color> textColor, Resource icon, Nullable<Variant> value, int location);
    /// <inheritdoc cref="M:Godot.CodeEdit.AddCodeCompletionOption(Godot.CodeEdit.CodeCompletionKind,System.String,System.String,System.Nullable{Godot.Color},Godot.Resource,System.Nullable{Godot.Variant},System.Int32)" />
    void AddCodeCompletionOption(CodeEdit.CodeCompletionKind @type, string displayText, string insertText, Nullable<Color> textColor, Resource icon, Nullable<Variant> value);
    /// <summary>
    /// <para>Adds a comment delimiter.</para>
    /// <para>Both the start and end keys must be symbols. Only the start key has to be unique.</para>
    /// <para><paramref name="lineOnly" /> denotes if the region should continue until the end of the line or carry over on to the next line. If the end key is blank this is automatically set to <c>true</c>.</para>
    /// </summary>
    void AddCommentDelimiter(string startKey, string endKey, bool lineOnly);
    /// <summary>
    /// <para>Adds a string delimiter.</para>
    /// <para>Both the start and end keys must be symbols. Only the start key has to be unique.</para>
    /// <para><paramref name="lineOnly" /> denotes if the region should continue until the end of the line or carry over on to the next line. If the end key is blank this is automatically set to <c>true</c>.</para>
    /// </summary>
    void AddStringDelimiter(string startKey, string endKey, bool lineOnly);
    /// <summary>
    /// <para>Sets whether brace pairs should be autocompleted.</para>
    /// </summary>
    bool AutoBraceCompletionEnabled { get; set; }
    /// <summary>
    /// <para>Highlight mismatching brace pairs.</para>
    /// </summary>
    bool AutoBraceCompletionHighlightMatching { get; set; }
    /// <summary>
    /// <para>Sets the brace pairs to be autocompleted.</para>
    /// </summary>
    Godot.Collections.Dictionary AutoBraceCompletionPairs { get; set; }
    /// <summary>
    /// <para>Cancels the autocomplete menu.</para>
    /// </summary>
    void CancelCodeCompletion();
    /// <summary>
    /// <para>Returns if the given line is foldable, that is, it has indented lines right below it or a comment / string block.</para>
    /// </summary>
    bool CanFoldLine(int line);
    /// <summary>
    /// <para>Clears all bookmarked lines.</para>
    /// </summary>
    void ClearBookmarkedLines();
    /// <summary>
    /// <para>Clears all breakpointed lines.</para>
    /// </summary>
    void ClearBreakpointedLines();
    /// <summary>
    /// <para>Removes all comment delimiters.</para>
    /// </summary>
    void ClearCommentDelimiters();
    /// <summary>
    /// <para>Clears all executed lines.</para>
    /// </summary>
    void ClearExecutingLines();
    /// <summary>
    /// <para>Removes all string delimiters.</para>
    /// </summary>
    void ClearStringDelimiters();
    /// <summary>
    /// <para>Sets whether code completion is allowed.</para>
    /// </summary>
    bool CodeCompletionEnabled { get; set; }
    /// <summary>
    /// <para>Sets prefixes that will trigger code completion.</para>
    /// </summary>
    Godot.Collections.Array<string> CodeCompletionPrefixes { get; set; }
    /// <summary>
    /// <para>Inserts the selected entry into the text. If <paramref name="replace" /> is true, any existing text is replaced rather than merged.</para>
    /// </summary>
    void ConfirmCodeCompletion(bool replace);
    /// <summary>
    /// <para>Converts the indents of lines between <paramref name="fromLine" /> and <paramref name="toLine" /> to tabs or spaces as set by <see cref="CodeEdit.IndentUseSpaces" />.</para>
    /// <para>Values of <c>-1</c> convert the entire text.</para>
    /// </summary>
    void ConvertIndent(int fromLine, int toLine);
    /// <summary>
    /// <para>Creates a new code region with the selection. At least one single line comment delimiter have to be defined (see <see cref="CodeEdit.AddCommentDelimiter(System.String,System.String,System.Boolean)" />).</para>
    /// <para>A code region is a part of code that is highlighted when folded and can help organize your script.</para>
    /// <para>Code region start and end tags can be customized (see <see cref="CodeEdit.SetCodeRegionTags(System.String,System.String)" />).</para>
    /// <para>Code regions are delimited using start and end tags (respectively <c>region</c> and <c>endregion</c> by default) preceded by one line comment delimiter. (eg. <c>#region</c> and <c>#endregion</c>)</para>
    /// </summary>
    void CreateCodeRegion();
    /// <summary>
    /// <para>Sets the comment delimiters. All existing comment delimiters will be removed.</para>
    /// </summary>
    Godot.Collections.Array<string> DelimiterComments { get; set; }
    /// <summary>
    /// <para>Sets the string delimiters. All existing string delimiters will be removed.</para>
    /// </summary>
    Godot.Collections.Array<string> DelimiterStrings { get; set; }
    /// <summary>
    /// <para>Perform an indent as if the user activated the "ui_text_indent" action.</para>
    /// </summary>
    void DoIndent();
    /// <summary>
    /// <para>Duplicates all lines currently selected with any caret. Duplicates the entire line beneath the current one no matter where the caret is within the line.</para>
    /// </summary>
    void DuplicateLines();
    /// <summary>
    /// <para>Folds all lines that are possible to be folded (see <see cref="CodeEdit.CanFoldLine(System.Int32)" />).</para>
    /// </summary>
    void FoldAllLines();
    /// <summary>
    /// <para>Folds the given line, if possible (see <see cref="CodeEdit.CanFoldLine(System.Int32)" />).</para>
    /// </summary>
    void FoldLine(int line);
    /// <summary>
    /// <para>Gets the matching auto brace close key for <paramref name="openKey" />.</para>
    /// </summary>
    string GetAutoBraceCompletionCloseKey(string openKey);
    /// <summary>
    /// <para>Gets all bookmarked lines.</para>
    /// </summary>
    int[] GetBookmarkedLines();
    /// <summary>
    /// <para>Gets all breakpointed lines.</para>
    /// </summary>
    int[] GetBreakpointedLines();
    /// <summary>
    /// <para>Gets the completion option at <paramref name="index" />. The return <see cref="Collections.Dictionary" /> has the following key-values:</para>
    /// <para><c>kind</c>: <see cref="CodeEdit.CodeCompletionKind" /></para>
    /// <para><c>display_text</c>: Text that is shown on the autocomplete menu.</para>
    /// <para><c>insert_text</c>: Text that is to be inserted when this item is selected.</para>
    /// <para><c>font_color</c>: Color of the text on the autocomplete menu.</para>
    /// <para><c>icon</c>: Icon to draw on the autocomplete menu.</para>
    /// <para><c>default_value</c>: Value of the symbol.</para>
    /// </summary>
    Godot.Collections.Dictionary GetCodeCompletionOption(int index);
    /// <summary>
    /// <para>Gets all completion options, see <see cref="CodeEdit.GetCodeCompletionOption(System.Int32)" /> for return content.</para>
    /// </summary>
    Godot.Collections.Array<Dictionary> GetCodeCompletionOptions();
    /// <summary>
    /// <para>Gets the index of the current selected completion option.</para>
    /// </summary>
    int GetCodeCompletionSelectedIndex();
    /// <summary>
    /// <para>Returns the code region end tag (without comment delimiter).</para>
    /// </summary>
    string GetCodeRegionEndTag();
    /// <summary>
    /// <para>Returns the code region start tag (without comment delimiter).</para>
    /// </summary>
    string GetCodeRegionStartTag();
    /// <summary>
    /// <para>Gets the end key for a string or comment region index.</para>
    /// </summary>
    string GetDelimiterEndKey(int delimiterIndex);
    /// <summary>
    /// <para>If <paramref name="line" /> <paramref name="column" /> is in a string or comment, returns the end position of the region. If not or no end could be found, both <see cref="Vector2" /> values will be <c>-1</c>.</para>
    /// </summary>
    Vector2 GetDelimiterEndPosition(int line, int column);
    /// <summary>
    /// <para>Gets the start key for a string or comment region index.</para>
    /// </summary>
    string GetDelimiterStartKey(int delimiterIndex);
    /// <summary>
    /// <para>If <paramref name="line" /> <paramref name="column" /> is in a string or comment, returns the start position of the region. If not or no start could be found, both <see cref="Vector2" /> values will be <c>-1</c>.</para>
    /// </summary>
    Vector2 GetDelimiterStartPosition(int line, int column);
    /// <summary>
    /// <para>Gets all executing lines.</para>
    /// </summary>
    int[] GetExecutingLines();
    /// <summary>
    /// <para>Returns all lines that are current folded.</para>
    /// </summary>
    Godot.Collections.Array<int> GetFoldedLines();
    /// <summary>
    /// <para>Returns the full text with char <c>0xFFFF</c> at the caret location.</para>
    /// </summary>
    string GetTextForCodeCompletion();
    /// <summary>
    /// <para>Returns the full text with char <c>0xFFFF</c> at the cursor location.</para>
    /// </summary>
    string GetTextForSymbolLookup();
    /// <summary>
    /// <para>Returns the full text with char <c>0xFFFF</c> at the specified location.</para>
    /// </summary>
    string GetTextWithCursorChar(int line, int column);
    /// <summary>
    /// <para>Sets if bookmarked should be drawn in the gutter. This gutter is shared with breakpoints and executing lines.</para>
    /// </summary>
    bool GuttersDrawBookmarks { get; set; }
    /// <summary>
    /// <para>Sets if breakpoints should be drawn in the gutter. This gutter is shared with bookmarks and executing lines.</para>
    /// </summary>
    bool GuttersDrawBreakpointsGutter { get; set; }
    /// <summary>
    /// <para>Sets if executing lines should be marked in the gutter. This gutter is shared with breakpoints and bookmarks lines.</para>
    /// </summary>
    bool GuttersDrawExecutingLines { get; set; }
    /// <summary>
    /// <para>Sets if foldable lines icons should be drawn in the gutter.</para>
    /// </summary>
    bool GuttersDrawFoldGutter { get; set; }
    /// <summary>
    /// <para>Sets if line numbers should be drawn in the gutter.</para>
    /// </summary>
    bool GuttersDrawLineNumbers { get; set; }
    /// <summary>
    /// <para>Sets if line numbers drawn in the gutter are zero padded.</para>
    /// </summary>
    bool GuttersZeroPadLineNumbers { get; set; }
    /// <summary>
    /// <para>Returns <c>true</c> if close key <paramref name="closeKey" /> exists.</para>
    /// </summary>
    bool HasAutoBraceCompletionCloseKey(string closeKey);
    /// <summary>
    /// <para>Returns <c>true</c> if open key <paramref name="openKey" /> exists.</para>
    /// </summary>
    bool HasAutoBraceCompletionOpenKey(string openKey);
    /// <summary>
    /// <para>Returns <c>true</c> if comment <paramref name="startKey" /> exists.</para>
    /// </summary>
    bool HasCommentDelimiter(string startKey);
    /// <summary>
    /// <para>Returns <c>true</c> if string <paramref name="startKey" /> exists.</para>
    /// </summary>
    bool HasStringDelimiter(string startKey);
    /// <summary>
    /// <para>Sets whether automatic indent are enabled, this will add an extra indent if a prefix or brace is found.</para>
    /// </summary>
    bool IndentAutomatic { get; set; }
    /// <summary>
    /// <para>Prefixes to trigger an automatic indent.</para>
    /// </summary>
    Godot.Collections.Array<string> IndentAutomaticPrefixes { get; set; }
    /// <summary>
    /// <para>Indents selected lines, or in the case of no selection the caret line by one.</para>
    /// </summary>
    void IndentLines();
    /// <summary>
    /// <para>Size of the tabulation indent (one Tab press) in characters. If <see cref="CodeEdit.IndentUseSpaces" /> is enabled the number of spaces to use.</para>
    /// </summary>
    int IndentSize { get; set; }
    /// <summary>
    /// <para>Use spaces instead of tabs for indentation.</para>
    /// </summary>
    bool IndentUseSpaces { get; set; }
    /// <summary>
    /// <para>Returns delimiter index if <paramref name="line" /> <paramref name="column" /> is in a comment. If <paramref name="column" /> is not provided, will return delimiter index if the entire <paramref name="line" /> is a comment. Otherwise <c>-1</c>.</para>
    /// </summary>
    int IsInComment(int line, int column);
    /// <summary>
    /// <para>Returns the delimiter index if <paramref name="line" /> <paramref name="column" /> is in a string. If <paramref name="column" /> is not provided, will return the delimiter index if the entire <paramref name="line" /> is a string. Otherwise <c>-1</c>.</para>
    /// </summary>
    int IsInString(int line, int column);
    /// <summary>
    /// <para>Returns whether the line at the specified index is bookmarked or not.</para>
    /// </summary>
    bool IsLineBookmarked(int line);
    /// <summary>
    /// <para>Returns whether the line at the specified index is breakpointed or not.</para>
    /// </summary>
    bool IsLineBreakpointed(int line);
    /// <summary>
    /// <para>Returns whether the line at the specified index is a code region end.</para>
    /// </summary>
    bool IsLineCodeRegionEnd(int line);
    /// <summary>
    /// <para>Returns whether the line at the specified index is a code region start.</para>
    /// </summary>
    bool IsLineCodeRegionStart(int line);
    /// <summary>
    /// <para>Returns whether the line at the specified index is marked as executing or not.</para>
    /// </summary>
    bool IsLineExecuting(int line);
    /// <summary>
    /// <para>Returns whether the line at the specified index is folded or not.</para>
    /// </summary>
    bool IsLineFolded(int line);
    /// <summary>
    /// <para>Sets whether line folding is allowed.</para>
    /// </summary>
    bool LineFolding { get; set; }
    /// <summary>
    /// <para>Draws vertical lines at the provided columns. The first entry is considered a main hard guideline and is draw more prominently.</para>
    /// </summary>
    Godot.Collections.Array<int> LineLengthGuidelines { get; set; }
    /// <summary>
    /// <para>Removes the comment delimiter with <paramref name="startKey" />.</para>
    /// </summary>
    void RemoveCommentDelimiter(string startKey);
    /// <summary>
    /// <para>Removes the string delimiter with <paramref name="startKey" />.</para>
    /// </summary>
    void RemoveStringDelimiter(string startKey);
    /// <summary>
    /// <para>Emits <see cref="CodeEdit.CodeCompletionRequested" />, if <paramref name="force" /> is true will bypass all checks. Otherwise will check that the caret is in a word or in front of a prefix. Will ignore the request if all current options are of type file path, node path or signal.</para>
    /// </summary>
    void RequestCodeCompletion(bool force);
    /// <summary>
    /// <para>Sets the current selected completion option.</para>
    /// </summary>
    void SetCodeCompletionSelectedIndex(int index);
    /// <summary>
    /// <para>Sets the code hint text. Pass an empty string to clear.</para>
    /// </summary>
    void SetCodeHint(string codeHint);
    /// <summary>
    /// <para>Sets if the code hint should draw below the text.</para>
    /// </summary>
    void SetCodeHintDrawBelow(bool drawBelow);
    /// <summary>
    /// <para>Sets the code region start and end tags (without comment delimiter).</para>
    /// </summary>
    void SetCodeRegionTags(string start, string end);
    /// <summary>
    /// <para>Sets the line as bookmarked.</para>
    /// </summary>
    void SetLineAsBookmarked(int line, bool bookmarked);
    /// <summary>
    /// <para>Sets the line as breakpointed.</para>
    /// </summary>
    void SetLineAsBreakpoint(int line, bool breakpointed);
    /// <summary>
    /// <para>Sets the line as executing.</para>
    /// </summary>
    void SetLineAsExecuting(int line, bool executing);
    /// <summary>
    /// <para>Sets the symbol emitted by <see cref="CodeEdit.SymbolValidate" /> as a valid lookup.</para>
    /// </summary>
    void SetSymbolLookupWordAsValid(bool valid);
    /// <summary>
    /// <para>Set when a validated word from <see cref="CodeEdit.SymbolValidate" /> is clicked, the <see cref="CodeEdit.SymbolLookup" /> should be emitted.</para>
    /// </summary>
    bool SymbolLookupOnClick { get; set; }
    /// <summary>
    /// <para>Toggle the folding of the code block at the given line.</para>
    /// </summary>
    void ToggleFoldableLine(int line);
    /// <summary>
    /// <para>Unfolds all lines, folded or not.</para>
    /// </summary>
    void UnfoldAllLines();
    /// <summary>
    /// <para>Unfolds all lines that were previously folded.</para>
    /// </summary>
    void UnfoldLine(int line);
    /// <summary>
    /// <para>Unindents selected lines, or in the case of no selection the caret line by one. Same as performing "ui_text_unindent" action.</para>
    /// </summary>
    void UnindentLines();
    /// <summary>
    /// <para>Submits all completion options added with <see cref="CodeEdit.AddCodeCompletionOption(Godot.CodeEdit.CodeCompletionKind,System.String,System.String,System.Nullable{Godot.Color},Godot.Resource,System.Nullable{Godot.Variant},System.Int32)" />. Will try to force the autocomplete menu to popup, if <paramref name="force" /> is <c>true</c>.</para>
    /// <para><b>Note:</b> This will replace all current candidates.</para>
    /// </summary>
    void UpdateCodeCompletionOptions(bool force);

}