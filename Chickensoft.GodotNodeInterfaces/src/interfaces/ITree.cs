namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>A control used to show a set of internal <see cref="TreeItem" />s in a hierarchical structure. The tree items can be selected, expanded and collapsed. The tree can have multiple columns with custom controls like <see cref="LineEdit" />s, buttons and popups. It can be useful for structured displays and interactions.</para>
/// <para>Trees are built via code, using <see cref="TreeItem" /> objects to create the structure. They have a single root, but multiple roots can be simulated with <see cref="Tree.HideRoot" />:</para>
/// <para><code>
/// public override void _Ready()
/// {
/// var tree = new Tree();
/// TreeItem root = tree.CreateItem();
/// tree.HideRoot = true;
/// TreeItem child1 = tree.CreateItem(root);
/// TreeItem child2 = tree.CreateItem(root);
/// TreeItem subchild1 = tree.CreateItem(child1);
/// subchild1.SetText(0, "Subchild1");
/// }
/// </code></para>
/// <para>To iterate over all the <see cref="TreeItem" /> objects in a <see cref="Tree" /> object, use <see cref="TreeItem.GetNext" /> and <see cref="TreeItem.GetFirstChild" /> after getting the root through <see cref="Tree.GetRoot" />. You can use <see cref="GodotObject.Free" /> on a <see cref="TreeItem" /> to remove it from the <see cref="Tree" />.</para>
/// <para><b>Incremental search:</b> Like <see cref="ItemList" /> and <see cref="PopupMenu" />, <see cref="Tree" /> supports searching within the list while the control is focused. Press a key that matches the first letter of an item's name to select the first item starting with the given letter. After that point, there are two ways to perform incremental search: 1) Press the same key again before the timeout duration to select the next item starting with the same letter. 2) Press letter keys that match the rest of the word before the timeout duration to match to select the item in question directly. Both of these actions will be reset to the beginning of the list if the timeout duration has passed since the last keystroke was registered. You can adjust the timeout duration by changing <c>ProjectSettings.gui/timers/incremental_search_max_interval_msec</c>.</para>
/// </summary>
public interface ITree : IControl {
    /// <inheritdoc cref="M:Godot.Tree.EditSelected(System.Boolean)" />
    bool EditSelected();
    /// <summary>
    /// <para>Clears the tree. This removes all items.</para>
    /// </summary>
    void Clear();
    /// <summary>
    /// <para>Creates an item in the tree and adds it as a child of <paramref name="parent" />, which can be either a valid <see cref="TreeItem" /> or <c>null</c>.</para>
    /// <para>If <paramref name="parent" /> is <c>null</c>, the root item will be the parent, or the new item will be the root itself if the tree is empty.</para>
    /// <para>The new item will be the <paramref name="index" />-th child of parent, or it will be the last child if there are not enough siblings.</para>
    /// </summary>
    TreeItem CreateItem(TreeItem parent, int index);
    /// <summary>
    /// <para>Returns the tree's root item, or <c>null</c> if the tree is empty.</para>
    /// </summary>
    TreeItem GetRoot();
    /// <summary>
    /// <para>Overrides the calculated minimum width of a column. It can be set to <c>0</c> to restore the default behavior. Columns that have the "Expand" flag will use their "min_width" in a similar fashion to <see cref="Control.SizeFlagsStretchRatio" />.</para>
    /// </summary>
    void SetColumnCustomMinimumWidth(int column, int minWidth);
    /// <summary>
    /// <para>If <c>true</c>, the column will have the "Expand" flag of <see cref="Control" />. Columns that have the "Expand" flag will use their expand ratio in a similar fashion to <see cref="Control.SizeFlagsStretchRatio" /> (see <see cref="M:Godot.Tree.SetColumnExpandRatio(System.Int32,System.Int32)" />).</para>
    /// </summary>
    void SetColumnExpand(int column, bool expand);
    /// <summary>
    /// <para>Sets the relative expand ratio for a column. See <see cref="M:Godot.Tree.SetColumnExpand(System.Int32,System.Boolean)" />.</para>
    /// </summary>
    void SetColumnExpandRatio(int column, int ratio);
    /// <summary>
    /// <para>Allows to enable clipping for column's content, making the content size ignored.</para>
    /// </summary>
    void SetColumnClipContent(int column, bool enable);
    /// <summary>
    /// <para>Returns <c>true</c> if the column has enabled expanding (see <see cref="M:Godot.Tree.SetColumnExpand(System.Int32,System.Boolean)" />).</para>
    /// </summary>
    bool IsColumnExpanding(int column);
    /// <summary>
    /// <para>Returns <c>true</c> if the column has enabled clipping (see <see cref="M:Godot.Tree.SetColumnClipContent(System.Int32,System.Boolean)" />).</para>
    /// </summary>
    bool IsColumnClippingContent(int column);
    /// <summary>
    /// <para>Returns the expand ratio assigned to the column.</para>
    /// </summary>
    int GetColumnExpandRatio(int column);
    /// <summary>
    /// <para>Returns the column's width in pixels.</para>
    /// </summary>
    int GetColumnWidth(int column);
    /// <summary>
    /// <para>Returns the next selected <see cref="TreeItem" /> after the given one, or <c>null</c> if the end is reached.</para>
    /// <para>If <paramref name="from" /> is <c>null</c>, this returns the first selected item.</para>
    /// </summary>
    TreeItem GetNextSelected(TreeItem @from);
    /// <summary>
    /// <para>Returns the currently focused item, or <c>null</c> if no item is focused.</para>
    /// <para>In <see cref="Tree.SelectModeEnum.Row" /> and <see cref="Tree.SelectModeEnum.Single" /> modes, the focused item is same as the selected item. In <see cref="Tree.SelectModeEnum.Multi" /> mode, the focused item is the item under the focus cursor, not necessarily selected.</para>
    /// <para>To get the currently selected item(s), use <see cref="M:Godot.Tree.GetNextSelected(Godot.TreeItem)" />.</para>
    /// </summary>
    TreeItem GetSelected();
    /// <summary>
    /// <para>Selects the specified <see cref="TreeItem" /> and column.</para>
    /// </summary>
    void SetSelected(TreeItem item, int column);
    /// <summary>
    /// <para>Returns the currently focused column, or -1 if no column is focused.</para>
    /// <para>In <see cref="Tree.SelectModeEnum.Single" /> mode, the focused column is the selected column. In <see cref="Tree.SelectModeEnum.Row" /> mode, the focused column is always 0 if any item is selected. In <see cref="Tree.SelectModeEnum.Multi" /> mode, the focused column is the column under the focus cursor, and there are not necessarily any column selected.</para>
    /// <para>To tell whether a column of an item is selected, use <see cref="M:Godot.TreeItem.IsSelected(System.Int32)" />.</para>
    /// </summary>
    int GetSelectedColumn();
    /// <summary>
    /// <para>Returns the last pressed button's index.</para>
    /// </summary>
    int GetPressedButton();
    /// <summary>
    /// <para>Deselects all tree items (rows and columns). In <see cref="Tree.SelectModeEnum.Multi" /> mode also removes selection cursor.</para>
    /// </summary>
    void DeselectAll();
    /// <summary>
    /// <para>Returns the currently edited item. Can be used with <see cref="Tree.ItemEdited" /> to get the item that was modified.</para>
    /// <para><code>
    /// public override void _Ready()
    /// {
    /// GetNode&lt;Tree&gt;("Tree").ItemEdited += OnTreeItemEdited;
    /// }
    /// public void OnTreeItemEdited()
    /// {
    /// GD.Print(GetNode&lt;Tree&gt;("Tree").GetEdited()); // This item just got edited (e.g. checked).
    /// }
    /// </code></para>
    /// </summary>
    TreeItem GetEdited();
    /// <summary>
    /// <para>Returns the column for the currently edited item.</para>
    /// </summary>
    int GetEditedColumn();
    /// <summary>
    /// <para>Edits the selected tree item as if it was clicked.</para>
    /// <para>Either the item must be set editable with <see cref="M:Godot.TreeItem.SetEditable(System.Int32,System.Boolean)" /> or <paramref name="forceEdit" /> must be <c>true</c>.</para>
    /// <para>Returns <c>true</c> if the item could be edited. Fails if no item is selected.</para>
    /// </summary>
    bool EditSelected(bool forceEdit);
    /// <summary>
    /// <para>Returns the rectangle for custom popups. Helper to create custom cell controls that display a popup. See <see cref="M:Godot.TreeItem.SetCellMode(System.Int32,Godot.TreeItem.TreeCellMode)" />.</para>
    /// </summary>
    Rect2 GetCustomPopupRect();
    /// <summary>
    /// <para>Returns the rectangle area for the specified <see cref="TreeItem" />. If <paramref name="column" /> is specified, only get the position and size of that column, otherwise get the rectangle containing all columns. If a button index is specified, the rectangle of that button will be returned.</para>
    /// </summary>
    Rect2 GetItemAreaRect(TreeItem item, int column, int buttonIndex);
    /// <summary>
    /// <para>Returns the tree item at the specified position (relative to the tree origin position).</para>
    /// </summary>
    TreeItem GetItemAtPosition(Vector2 position);
    /// <summary>
    /// <para>Returns the column index at <paramref name="position" />, or -1 if no item is there.</para>
    /// </summary>
    int GetColumnAtPosition(Vector2 position);
    /// <summary>
    /// <para>Returns the drop section at <paramref name="position" />, or -100 if no item is there.</para>
    /// <para>Values -1, 0, or 1 will be returned for the "above item", "on item", and "below item" drop sections, respectively. See <see cref="Tree.DropModeFlagsEnum" /> for a description of each drop section.</para>
    /// <para>To get the item which the returned drop section is relative to, use <see cref="M:Godot.Tree.GetItemAtPosition(Godot.Vector2)" />.</para>
    /// </summary>
    int GetDropSectionAtPosition(Vector2 position);
    /// <summary>
    /// <para>Returns the button ID at <paramref name="position" />, or -1 if no button is there.</para>
    /// </summary>
    int GetButtonIdAtPosition(Vector2 position);
    /// <summary>
    /// <para>Makes the currently focused cell visible.</para>
    /// <para>This will scroll the tree if necessary. In <see cref="Tree.SelectModeEnum.Row" /> mode, this will not do horizontal scrolling, as all the cells in the selected row is focused logically.</para>
    /// <para><b>Note:</b> Despite the name of this method, the focus cursor itself is only visible in <see cref="Tree.SelectModeEnum.Multi" /> mode.</para>
    /// </summary>
    void EnsureCursorIsVisible();
    /// <summary>
    /// <para>Sets the title of a column.</para>
    /// </summary>
    void SetColumnTitle(int column, string title);
    /// <summary>
    /// <para>Returns the column's title.</para>
    /// </summary>
    string GetColumnTitle(int column);
    /// <summary>
    /// <para>Sets the column title alignment. Note that <see cref="HorizontalAlignment.Fill" /> is not supported for column titles.</para>
    /// </summary>
    void SetColumnTitleAlignment(int column, HorizontalAlignment titleAlignment);
    /// <summary>
    /// <para>Returns the column title alignment.</para>
    /// </summary>
    HorizontalAlignment GetColumnTitleAlignment(int column);
    /// <summary>
    /// <para>Sets column title base writing direction.</para>
    /// </summary>
    void SetColumnTitleDirection(int column, Control.TextDirection direction);
    /// <summary>
    /// <para>Returns column title base writing direction.</para>
    /// </summary>
    Control.TextDirection GetColumnTitleDirection(int column);
    /// <summary>
    /// <para>Sets language code of column title used for line-breaking and text shaping algorithms, if left empty current locale is used instead.</para>
    /// </summary>
    void SetColumnTitleLanguage(int column, string language);
    /// <summary>
    /// <para>Returns column title language code.</para>
    /// </summary>
    string GetColumnTitleLanguage(int column);
    /// <summary>
    /// <para>Returns the current scrolling position.</para>
    /// </summary>
    Vector2 GetScroll();
    /// <summary>
    /// <para>Causes the <see cref="Tree" /> to jump to the specified <see cref="TreeItem" />.</para>
    /// </summary>
    void ScrollToItem(TreeItem item, bool centerOnItem);
    /// <summary>
    /// <para>The number of columns.</para>
    /// </summary>
    int Columns { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, column titles are visible.</para>
    /// </summary>
    bool ColumnTitlesVisible { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the currently selected cell may be selected again.</para>
    /// </summary>
    bool AllowReselect { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, a right mouse button click can select items.</para>
    /// </summary>
    bool AllowRmbSelect { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, allows navigating the <see cref="Tree" /> with letter keys through incremental search.</para>
    /// </summary>
    bool AllowSearch { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the folding arrow is hidden.</para>
    /// </summary>
    bool HideFolding { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, recursive folding is enabled for this <see cref="Tree" />. Holding down Shift while clicking the fold arrow collapses or uncollapses the <see cref="TreeItem" /> and all its descendants.</para>
    /// </summary>
    bool EnableRecursiveFolding { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the tree's root is hidden.</para>
    /// </summary>
    bool HideRoot { get; set; }
    /// <summary>
    /// <para>The drop mode as an OR combination of flags. See <see cref="Tree.DropModeFlagsEnum" /> constants. Once dropping is done, reverts to <see cref="Tree.DropModeFlagsEnum.Disabled" />. Setting this during <see cref="M:Godot.Control._CanDropData(Godot.Vector2,Godot.Variant)" /> is recommended.</para>
    /// <para>This controls the drop sections, i.e. the decision and drawing of possible drop locations based on the mouse position.</para>
    /// </summary>
    int DropModeFlags { get; set; }
    /// <summary>
    /// <para>Allows single or multiple selection. See the <see cref="Tree.SelectModeEnum" /> constants.</para>
    /// </summary>
    Tree.SelectModeEnum SelectMode { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, enables horizontal scrolling.</para>
    /// </summary>
    bool ScrollHorizontalEnabled { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, enables vertical scrolling.</para>
    /// </summary>
    bool ScrollVerticalEnabled { get; set; }

}