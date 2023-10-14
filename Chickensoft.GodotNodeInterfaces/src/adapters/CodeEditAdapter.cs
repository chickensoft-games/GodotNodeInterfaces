namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
using Godot.Collections;
/// <summary>
/// <para>CodeEdit is a specialized <see cref="TextEdit" /> designed for editing plain text code files. It has many features commonly found in code editors such as line numbers, line folding, code completion, indent management, and string/comment management.</para>
/// <para><b>Note:</b> Regardless of locale, <see cref="CodeEdit" /> will by default always use left-to-right text direction to correctly display source code.</para>
/// </summary>
public class CodeEditAdapter : CodeEdit, ICodeEdit {
  private readonly CodeEdit _node;

  public CodeEditAdapter(CodeEdit node) => _node = node;
    /// <summary>
    /// <para>Override this method to define how the selected entry should be inserted. If <paramref name="replace" /> is true, any existing text should be replaced.</para>
    /// </summary>
    public void _ConfirmCodeCompletion(bool replace) => _node._ConfirmCodeCompletion(replace);
    /// <summary>
    /// <para>Override this method to define what items in <paramref name="candidates" /> should be displayed.</para>
    /// <para>Both <paramref name="candidates" /> and the return is a <see cref="Collections.Array" /> of <see cref="Collections.Dictionary" />, see <see cref="CodeEdit.GetCodeCompletionOption(System.Int32)" /> for <see cref="Collections.Dictionary" /> content.</para>
    /// </summary>
    public Godot.Collections.Array<Dictionary> _FilterCodeCompletionCandidates(Godot.Collections.Array<Dictionary> candidates) => _node._FilterCodeCompletionCandidates(candidates);
    /// <summary>
    /// <para>Override this method to define what happens when the user requests code completion. If <paramref name="force" /> is true, any checks should be bypassed.</para>
    /// </summary>
    public void _RequestCodeCompletion(bool force) => _node._RequestCodeCompletion(force);
    /// <summary>
    /// <para>Adds a brace pair.</para>
    /// <para>Both the start and end keys must be symbols. Only the start key has to be unique.</para>
    /// </summary>
    public void AddAutoBraceCompletionPair(string startKey, string endKey) => _node.AddAutoBraceCompletionPair(startKey, endKey);
    /// <summary>
    /// <para>Submits an item to the queue of potential candidates for the autocomplete menu. Call <see cref="CodeEdit.UpdateCodeCompletionOptions(System.Boolean)" /> to update the list.</para>
    /// <para><paramref name="location" /> indicates location of the option relative to the location of the code completion query. See <see cref="CodeEdit.CodeCompletionLocation" /> for how to set this value.</para>
    /// <para><b>Note:</b> This list will replace all current candidates.</para>
    /// </summary>
    /// <param name="textColor">If the parameter is null, then the default value is <c>new Color(1, 1, 1, 1)</c>.</param>
    /// <param name="value">If the parameter is null, then the default value is <c>(Variant)(0)</c>.</param>
    public void AddCodeCompletionOption(CodeEdit.CodeCompletionKind @type, string displayText, string insertText, Nullable<Color> textColor, Resource icon, Nullable<Variant> value, int location) => _node.AddCodeCompletionOption(@type, displayText, insertText, textColor, icon, value, location);
    /// <inheritdoc cref="M:Godot.CodeEdit.AddCodeCompletionOption(Godot.CodeEdit.CodeCompletionKind,System.String,System.String,System.Nullable{Godot.Color},Godot.Resource,System.Nullable{Godot.Variant},System.Int32)" />
    public void AddCodeCompletionOption(CodeEdit.CodeCompletionKind @type, string displayText, string insertText, Nullable<Color> textColor, Resource icon, Nullable<Variant> value) => _node.AddCodeCompletionOption(@type, displayText, insertText, textColor, icon, value);
    /// <summary>
    /// <para>Adds a comment delimiter.</para>
    /// <para>Both the start and end keys must be symbols. Only the start key has to be unique.</para>
    /// <para><paramref name="lineOnly" /> denotes if the region should continue until the end of the line or carry over on to the next line. If the end key is blank this is automatically set to <c>true</c>.</para>
    /// </summary>
    public void AddCommentDelimiter(string startKey, string endKey, bool lineOnly) => _node.AddCommentDelimiter(startKey, endKey, lineOnly);
    /// <summary>
    /// <para>Adds a string delimiter.</para>
    /// <para>Both the start and end keys must be symbols. Only the start key has to be unique.</para>
    /// <para><paramref name="lineOnly" /> denotes if the region should continue until the end of the line or carry over on to the next line. If the end key is blank this is automatically set to <c>true</c>.</para>
    /// </summary>
    public void AddStringDelimiter(string startKey, string endKey, bool lineOnly) => _node.AddStringDelimiter(startKey, endKey, lineOnly);
    /// <summary>
    /// <para>Sets whether brace pairs should be autocompleted.</para>
    /// </summary>
    public bool AutoBraceCompletionEnabled { get => _node.AutoBraceCompletionEnabled; set => _node.AutoBraceCompletionEnabled = value; }
    /// <summary>
    /// <para>Highlight mismatching brace pairs.</para>
    /// </summary>
    public bool AutoBraceCompletionHighlightMatching { get => _node.AutoBraceCompletionHighlightMatching; set => _node.AutoBraceCompletionHighlightMatching = value; }
    /// <summary>
    /// <para>Sets the brace pairs to be autocompleted.</para>
    /// </summary>
    public Godot.Collections.Dictionary AutoBraceCompletionPairs { get => _node.AutoBraceCompletionPairs; set => _node.AutoBraceCompletionPairs = value; }
    /// <summary>
    /// <para>Cancels the autocomplete menu.</para>
    /// </summary>
    public void CancelCodeCompletion() => _node.CancelCodeCompletion();
    /// <summary>
    /// <para>Returns if the given line is foldable, that is, it has indented lines right below it or a comment / string block.</para>
    /// </summary>
    public bool CanFoldLine(int line) => _node.CanFoldLine(line);
    /// <summary>
    /// <para>Clears all bookmarked lines.</para>
    /// </summary>
    public void ClearBookmarkedLines() => _node.ClearBookmarkedLines();
    /// <summary>
    /// <para>Clears all breakpointed lines.</para>
    /// </summary>
    public void ClearBreakpointedLines() => _node.ClearBreakpointedLines();
    /// <summary>
    /// <para>Removes all comment delimiters.</para>
    /// </summary>
    public void ClearCommentDelimiters() => _node.ClearCommentDelimiters();
    /// <summary>
    /// <para>Clears all executed lines.</para>
    /// </summary>
    public void ClearExecutingLines() => _node.ClearExecutingLines();
    /// <summary>
    /// <para>Removes all string delimiters.</para>
    /// </summary>
    public void ClearStringDelimiters() => _node.ClearStringDelimiters();
    /// <summary>
    /// <para>Sets whether code completion is allowed.</para>
    /// </summary>
    public bool CodeCompletionEnabled { get => _node.CodeCompletionEnabled; set => _node.CodeCompletionEnabled = value; }
    /// <summary>
    /// <para>Sets prefixes that will trigger code completion.</para>
    /// </summary>
    public Godot.Collections.Array<string> CodeCompletionPrefixes { get => _node.CodeCompletionPrefixes; set => _node.CodeCompletionPrefixes = value; }
    /// <summary>
    /// <para>Inserts the selected entry into the text. If <paramref name="replace" /> is true, any existing text is replaced rather than merged.</para>
    /// </summary>
    public void ConfirmCodeCompletion(bool replace) => _node.ConfirmCodeCompletion(replace);
    /// <summary>
    /// <para>Converts the indents of lines between <paramref name="fromLine" /> and <paramref name="toLine" /> to tabs or spaces as set by <see cref="CodeEdit.IndentUseSpaces" />.</para>
    /// <para>Values of <c>-1</c> convert the entire text.</para>
    /// </summary>
    public void ConvertIndent(int fromLine, int toLine) => _node.ConvertIndent(fromLine, toLine);
    /// <summary>
    /// <para>Creates a new code region with the selection. At least one single line comment delimiter have to be defined (see <see cref="CodeEdit.AddCommentDelimiter(System.String,System.String,System.Boolean)" />).</para>
    /// <para>A code region is a part of code that is highlighted when folded and can help organize your script.</para>
    /// <para>Code region start and end tags can be customized (see <see cref="CodeEdit.SetCodeRegionTags(System.String,System.String)" />).</para>
    /// <para>Code regions are delimited using start and end tags (respectively <c>region</c> and <c>endregion</c> by default) preceded by one line comment delimiter. (eg. <c>#region</c> and <c>#endregion</c>)</para>
    /// </summary>
    public void CreateCodeRegion() => _node.CreateCodeRegion();
    /// <summary>
    /// <para>Sets the comment delimiters. All existing comment delimiters will be removed.</para>
    /// </summary>
    public Godot.Collections.Array<string> DelimiterComments { get => _node.DelimiterComments; set => _node.DelimiterComments = value; }
    /// <summary>
    /// <para>Sets the string delimiters. All existing string delimiters will be removed.</para>
    /// </summary>
    public Godot.Collections.Array<string> DelimiterStrings { get => _node.DelimiterStrings; set => _node.DelimiterStrings = value; }
    /// <summary>
    /// <para>Perform an indent as if the user activated the "ui_text_indent" action.</para>
    /// </summary>
    public void DoIndent() => _node.DoIndent();
    /// <summary>
    /// <para>Duplicates all lines currently selected with any caret. Duplicates the entire line beneath the current one no matter where the caret is within the line.</para>
    /// </summary>
    public void DuplicateLines() => _node.DuplicateLines();
    /// <summary>
    /// <para>Folds all lines that are possible to be folded (see <see cref="CodeEdit.CanFoldLine(System.Int32)" />).</para>
    /// </summary>
    public void FoldAllLines() => _node.FoldAllLines();
    /// <summary>
    /// <para>Folds the given line, if possible (see <see cref="CodeEdit.CanFoldLine(System.Int32)" />).</para>
    /// </summary>
    public void FoldLine(int line) => _node.FoldLine(line);
    /// <summary>
    /// <para>Gets the matching auto brace close key for <paramref name="openKey" />.</para>
    /// </summary>
    public string GetAutoBraceCompletionCloseKey(string openKey) => _node.GetAutoBraceCompletionCloseKey(openKey);
    /// <summary>
    /// <para>Gets all bookmarked lines.</para>
    /// </summary>
    public int[] GetBookmarkedLines() => _node.GetBookmarkedLines();
    /// <summary>
    /// <para>Gets all breakpointed lines.</para>
    /// </summary>
    public int[] GetBreakpointedLines() => _node.GetBreakpointedLines();
    /// <summary>
    /// <para>Gets the completion option at <paramref name="index" />. The return <see cref="Collections.Dictionary" /> has the following key-values:</para>
    /// <para><c>kind</c>: <see cref="CodeEdit.CodeCompletionKind" /></para>
    /// <para><c>display_text</c>: Text that is shown on the autocomplete menu.</para>
    /// <para><c>insert_text</c>: Text that is to be inserted when this item is selected.</para>
    /// <para><c>font_color</c>: Color of the text on the autocomplete menu.</para>
    /// <para><c>icon</c>: Icon to draw on the autocomplete menu.</para>
    /// <para><c>default_value</c>: Value of the symbol.</para>
    /// </summary>
    public Godot.Collections.Dictionary GetCodeCompletionOption(int index) => _node.GetCodeCompletionOption(index);
    /// <summary>
    /// <para>Gets all completion options, see <see cref="CodeEdit.GetCodeCompletionOption(System.Int32)" /> for return content.</para>
    /// </summary>
    public Godot.Collections.Array<Dictionary> GetCodeCompletionOptions() => _node.GetCodeCompletionOptions();
    /// <summary>
    /// <para>Gets the index of the current selected completion option.</para>
    /// </summary>
    public int GetCodeCompletionSelectedIndex() => _node.GetCodeCompletionSelectedIndex();
    /// <summary>
    /// <para>Returns the code region end tag (without comment delimiter).</para>
    /// </summary>
    public string GetCodeRegionEndTag() => _node.GetCodeRegionEndTag();
    /// <summary>
    /// <para>Returns the code region start tag (without comment delimiter).</para>
    /// </summary>
    public string GetCodeRegionStartTag() => _node.GetCodeRegionStartTag();
    /// <summary>
    /// <para>Gets the end key for a string or comment region index.</para>
    /// </summary>
    public string GetDelimiterEndKey(int delimiterIndex) => _node.GetDelimiterEndKey(delimiterIndex);
    /// <summary>
    /// <para>If <paramref name="line" /> <paramref name="column" /> is in a string or comment, returns the end position of the region. If not or no end could be found, both <see cref="Vector2" /> values will be <c>-1</c>.</para>
    /// </summary>
    public Vector2 GetDelimiterEndPosition(int line, int column) => _node.GetDelimiterEndPosition(line, column);
    /// <summary>
    /// <para>Gets the start key for a string or comment region index.</para>
    /// </summary>
    public string GetDelimiterStartKey(int delimiterIndex) => _node.GetDelimiterStartKey(delimiterIndex);
    /// <summary>
    /// <para>If <paramref name="line" /> <paramref name="column" /> is in a string or comment, returns the start position of the region. If not or no start could be found, both <see cref="Vector2" /> values will be <c>-1</c>.</para>
    /// </summary>
    public Vector2 GetDelimiterStartPosition(int line, int column) => _node.GetDelimiterStartPosition(line, column);
    /// <summary>
    /// <para>Gets all executing lines.</para>
    /// </summary>
    public int[] GetExecutingLines() => _node.GetExecutingLines();
    /// <summary>
    /// <para>Returns all lines that are current folded.</para>
    /// </summary>
    public Godot.Collections.Array<int> GetFoldedLines() => _node.GetFoldedLines();
    /// <summary>
    /// <para>Returns the full text with char <c>0xFFFF</c> at the caret location.</para>
    /// </summary>
    public string GetTextForCodeCompletion() => _node.GetTextForCodeCompletion();
    /// <summary>
    /// <para>Returns the full text with char <c>0xFFFF</c> at the cursor location.</para>
    /// </summary>
    public string GetTextForSymbolLookup() => _node.GetTextForSymbolLookup();
    /// <summary>
    /// <para>Returns the full text with char <c>0xFFFF</c> at the specified location.</para>
    /// </summary>
    public string GetTextWithCursorChar(int line, int column) => _node.GetTextWithCursorChar(line, column);
    /// <summary>
    /// <para>Sets if bookmarked should be drawn in the gutter. This gutter is shared with breakpoints and executing lines.</para>
    /// </summary>
    public bool GuttersDrawBookmarks { get => _node.GuttersDrawBookmarks; set => _node.GuttersDrawBookmarks = value; }
    /// <summary>
    /// <para>Sets if breakpoints should be drawn in the gutter. This gutter is shared with bookmarks and executing lines.</para>
    /// </summary>
    public bool GuttersDrawBreakpointsGutter { get => _node.GuttersDrawBreakpointsGutter; set => _node.GuttersDrawBreakpointsGutter = value; }
    /// <summary>
    /// <para>Sets if executing lines should be marked in the gutter. This gutter is shared with breakpoints and bookmarks lines.</para>
    /// </summary>
    public bool GuttersDrawExecutingLines { get => _node.GuttersDrawExecutingLines; set => _node.GuttersDrawExecutingLines = value; }
    /// <summary>
    /// <para>Sets if foldable lines icons should be drawn in the gutter.</para>
    /// </summary>
    public bool GuttersDrawFoldGutter { get => _node.GuttersDrawFoldGutter; set => _node.GuttersDrawFoldGutter = value; }
    /// <summary>
    /// <para>Sets if line numbers should be drawn in the gutter.</para>
    /// </summary>
    public bool GuttersDrawLineNumbers { get => _node.GuttersDrawLineNumbers; set => _node.GuttersDrawLineNumbers = value; }
    /// <summary>
    /// <para>Sets if line numbers drawn in the gutter are zero padded.</para>
    /// </summary>
    public bool GuttersZeroPadLineNumbers { get => _node.GuttersZeroPadLineNumbers; set => _node.GuttersZeroPadLineNumbers = value; }
    /// <summary>
    /// <para>Returns <c>true</c> if close key <paramref name="closeKey" /> exists.</para>
    /// </summary>
    public bool HasAutoBraceCompletionCloseKey(string closeKey) => _node.HasAutoBraceCompletionCloseKey(closeKey);
    /// <summary>
    /// <para>Returns <c>true</c> if open key <paramref name="openKey" /> exists.</para>
    /// </summary>
    public bool HasAutoBraceCompletionOpenKey(string openKey) => _node.HasAutoBraceCompletionOpenKey(openKey);
    /// <summary>
    /// <para>Returns <c>true</c> if comment <paramref name="startKey" /> exists.</para>
    /// </summary>
    public bool HasCommentDelimiter(string startKey) => _node.HasCommentDelimiter(startKey);
    /// <summary>
    /// <para>Returns <c>true</c> if string <paramref name="startKey" /> exists.</para>
    /// </summary>
    public bool HasStringDelimiter(string startKey) => _node.HasStringDelimiter(startKey);
    /// <summary>
    /// <para>Sets whether automatic indent are enabled, this will add an extra indent if a prefix or brace is found.</para>
    /// </summary>
    public bool IndentAutomatic { get => _node.IndentAutomatic; set => _node.IndentAutomatic = value; }
    /// <summary>
    /// <para>Prefixes to trigger an automatic indent.</para>
    /// </summary>
    public Godot.Collections.Array<string> IndentAutomaticPrefixes { get => _node.IndentAutomaticPrefixes; set => _node.IndentAutomaticPrefixes = value; }
    /// <summary>
    /// <para>Indents selected lines, or in the case of no selection the caret line by one.</para>
    /// </summary>
    public void IndentLines() => _node.IndentLines();
    /// <summary>
    /// <para>Size of the tabulation indent (one Tab press) in characters. If <see cref="CodeEdit.IndentUseSpaces" /> is enabled the number of spaces to use.</para>
    /// </summary>
    public int IndentSize { get => _node.IndentSize; set => _node.IndentSize = value; }
    /// <summary>
    /// <para>Use spaces instead of tabs for indentation.</para>
    /// </summary>
    public bool IndentUseSpaces { get => _node.IndentUseSpaces; set => _node.IndentUseSpaces = value; }
    /// <summary>
    /// <para>Returns delimiter index if <paramref name="line" /> <paramref name="column" /> is in a comment. If <paramref name="column" /> is not provided, will return delimiter index if the entire <paramref name="line" /> is a comment. Otherwise <c>-1</c>.</para>
    /// </summary>
    public int IsInComment(int line, int column) => _node.IsInComment(line, column);
    /// <summary>
    /// <para>Returns the delimiter index if <paramref name="line" /> <paramref name="column" /> is in a string. If <paramref name="column" /> is not provided, will return the delimiter index if the entire <paramref name="line" /> is a string. Otherwise <c>-1</c>.</para>
    /// </summary>
    public int IsInString(int line, int column) => _node.IsInString(line, column);
    /// <summary>
    /// <para>Returns whether the line at the specified index is bookmarked or not.</para>
    /// </summary>
    public bool IsLineBookmarked(int line) => _node.IsLineBookmarked(line);
    /// <summary>
    /// <para>Returns whether the line at the specified index is breakpointed or not.</para>
    /// </summary>
    public bool IsLineBreakpointed(int line) => _node.IsLineBreakpointed(line);
    /// <summary>
    /// <para>Returns whether the line at the specified index is a code region end.</para>
    /// </summary>
    public bool IsLineCodeRegionEnd(int line) => _node.IsLineCodeRegionEnd(line);
    /// <summary>
    /// <para>Returns whether the line at the specified index is a code region start.</para>
    /// </summary>
    public bool IsLineCodeRegionStart(int line) => _node.IsLineCodeRegionStart(line);
    /// <summary>
    /// <para>Returns whether the line at the specified index is marked as executing or not.</para>
    /// </summary>
    public bool IsLineExecuting(int line) => _node.IsLineExecuting(line);
    /// <summary>
    /// <para>Returns whether the line at the specified index is folded or not.</para>
    /// </summary>
    public bool IsLineFolded(int line) => _node.IsLineFolded(line);
    /// <summary>
    /// <para>Sets whether line folding is allowed.</para>
    /// </summary>
    public bool LineFolding { get => _node.LineFolding; set => _node.LineFolding = value; }
    /// <summary>
    /// <para>Draws vertical lines at the provided columns. The first entry is considered a main hard guideline and is draw more prominently.</para>
    /// </summary>
    public Godot.Collections.Array<int> LineLengthGuidelines { get => _node.LineLengthGuidelines; set => _node.LineLengthGuidelines = value; }
    /// <summary>
    /// <para>Removes the comment delimiter with <paramref name="startKey" />.</para>
    /// </summary>
    public void RemoveCommentDelimiter(string startKey) => _node.RemoveCommentDelimiter(startKey);
    /// <summary>
    /// <para>Removes the string delimiter with <paramref name="startKey" />.</para>
    /// </summary>
    public void RemoveStringDelimiter(string startKey) => _node.RemoveStringDelimiter(startKey);
    /// <summary>
    /// <para>Emits <see cref="CodeEdit.CodeCompletionRequested" />, if <paramref name="force" /> is true will bypass all checks. Otherwise will check that the caret is in a word or in front of a prefix. Will ignore the request if all current options are of type file path, node path or signal.</para>
    /// </summary>
    public void RequestCodeCompletion(bool force) => _node.RequestCodeCompletion(force);
    /// <summary>
    /// <para>Sets the current selected completion option.</para>
    /// </summary>
    public void SetCodeCompletionSelectedIndex(int index) => _node.SetCodeCompletionSelectedIndex(index);
    /// <summary>
    /// <para>Sets the code hint text. Pass an empty string to clear.</para>
    /// </summary>
    public void SetCodeHint(string codeHint) => _node.SetCodeHint(codeHint);
    /// <summary>
    /// <para>Sets if the code hint should draw below the text.</para>
    /// </summary>
    public void SetCodeHintDrawBelow(bool drawBelow) => _node.SetCodeHintDrawBelow(drawBelow);
    /// <summary>
    /// <para>Sets the code region start and end tags (without comment delimiter).</para>
    /// </summary>
    public void SetCodeRegionTags(string start, string end) => _node.SetCodeRegionTags(start, end);
    /// <summary>
    /// <para>Sets the line as bookmarked.</para>
    /// </summary>
    public void SetLineAsBookmarked(int line, bool bookmarked) => _node.SetLineAsBookmarked(line, bookmarked);
    /// <summary>
    /// <para>Sets the line as breakpointed.</para>
    /// </summary>
    public void SetLineAsBreakpoint(int line, bool breakpointed) => _node.SetLineAsBreakpoint(line, breakpointed);
    /// <summary>
    /// <para>Sets the line as executing.</para>
    /// </summary>
    public void SetLineAsExecuting(int line, bool executing) => _node.SetLineAsExecuting(line, executing);
    /// <summary>
    /// <para>Sets the symbol emitted by <see cref="CodeEdit.SymbolValidate" /> as a valid lookup.</para>
    /// </summary>
    public void SetSymbolLookupWordAsValid(bool valid) => _node.SetSymbolLookupWordAsValid(valid);
    /// <summary>
    /// <para>Set when a validated word from <see cref="CodeEdit.SymbolValidate" /> is clicked, the <see cref="CodeEdit.SymbolLookup" /> should be emitted.</para>
    /// </summary>
    public bool SymbolLookupOnClick { get => _node.SymbolLookupOnClick; set => _node.SymbolLookupOnClick = value; }
    /// <summary>
    /// <para>Toggle the folding of the code block at the given line.</para>
    /// </summary>
    public void ToggleFoldableLine(int line) => _node.ToggleFoldableLine(line);
    /// <summary>
    /// <para>Unfolds all lines, folded or not.</para>
    /// </summary>
    public void UnfoldAllLines() => _node.UnfoldAllLines();
    /// <summary>
    /// <para>Unfolds all lines that were previously folded.</para>
    /// </summary>
    public void UnfoldLine(int line) => _node.UnfoldLine(line);
    /// <summary>
    /// <para>Unindents selected lines, or in the case of no selection the caret line by one. Same as performing "ui_text_unindent" action.</para>
    /// </summary>
    public void UnindentLines() => _node.UnindentLines();
    /// <summary>
    /// <para>Submits all completion options added with <see cref="CodeEdit.AddCodeCompletionOption(Godot.CodeEdit.CodeCompletionKind,System.String,System.String,System.Nullable{Godot.Color},Godot.Resource,System.Nullable{Godot.Variant},System.Int32)" />. Will try to force the autocomplete menu to popup, if <paramref name="force" /> is <c>true</c>.</para>
    /// <para><b>Note:</b> This will replace all current candidates.</para>
    /// </summary>
    public void UpdateCodeCompletionOptions(bool force) => _node.UpdateCodeCompletionOptions(force);

}