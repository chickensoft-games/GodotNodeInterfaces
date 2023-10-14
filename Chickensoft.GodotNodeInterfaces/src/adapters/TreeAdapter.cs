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
public class TreeAdapter : Tree, ITree {
  private readonly Tree _node;

  public TreeAdapter(Tree node) => _node = node;
    /// <summary>
    /// <para>If <c>true</c>, the currently selected cell may be selected again.</para>
    /// </summary>
    public bool AllowReselect { get => _node.AllowReselect; set => _node.AllowReselect = value; }
    /// <summary>
    /// <para>If <c>true</c>, a right mouse button click can select items.</para>
    /// </summary>
    public bool AllowRmbSelect { get => _node.AllowRmbSelect; set => _node.AllowRmbSelect = value; }
    /// <summary>
    /// <para>If <c>true</c>, allows navigating the <see cref="Tree" /> with letter keys through incremental search.</para>
    /// </summary>
    public bool AllowSearch { get => _node.AllowSearch; set => _node.AllowSearch = value; }
    /// <summary>
    /// <para>Clears the tree. This removes all items.</para>
    /// </summary>
    public void Clear() => _node.Clear();
    /// <summary>
    /// <para>The number of columns.</para>
    /// </summary>
    public int Columns { get => _node.Columns; set => _node.Columns = value; }
    /// <summary>
    /// <para>If <c>true</c>, column titles are visible.</para>
    /// </summary>
    public bool ColumnTitlesVisible { get => _node.ColumnTitlesVisible; set => _node.ColumnTitlesVisible = value; }
    /// <summary>
    /// <para>Creates an item in the tree and adds it as a child of <paramref name="parent" />, which can be either a valid <see cref="TreeItem" /> or <c>null</c>.</para>
    /// <para>If <paramref name="parent" /> is <c>null</c>, the root item will be the parent, or the new item will be the root itself if the tree is empty.</para>
    /// <para>The new item will be the <paramref name="index" />-th child of parent, or it will be the last child if there are not enough siblings.</para>
    /// </summary>
    public TreeItem CreateItem(TreeItem parent, int index) => _node.CreateItem(parent, index);
    /// <summary>
    /// <para>Deselects all tree items (rows and columns). In <see cref="Tree.SelectModeEnum.Multi" /> mode also removes selection cursor.</para>
    /// </summary>
    public void DeselectAll() => _node.DeselectAll();
    /// <summary>
    /// <para>The drop mode as an OR combination of flags. See <see cref="Tree.DropModeFlagsEnum" /> constants. Once dropping is done, reverts to <see cref="Tree.DropModeFlagsEnum.Disabled" />. Setting this during <see cref="Control._CanDropData(Godot.Vector2,Godot.Variant)" /> is recommended.</para>
    /// <para>This controls the drop sections, i.e. the decision and drawing of possible drop locations based on the mouse position.</para>
    /// </summary>
    public int DropModeFlags { get => _node.DropModeFlags; set => _node.DropModeFlags = value; }
    /// <inheritdoc cref="M:Godot.Tree.EditSelected(System.Boolean)" />
    public bool EditSelected() => _node.EditSelected();
    /// <summary>
    /// <para>Edits the selected tree item as if it was clicked.</para>
    /// <para>Either the item must be set editable with <see cref="TreeItem.SetEditable(System.Int32,System.Boolean)" /> or <paramref name="forceEdit" /> must be <c>true</c>.</para>
    /// <para>Returns <c>true</c> if the item could be edited. Fails if no item is selected.</para>
    /// </summary>
    public bool EditSelected(bool forceEdit) => _node.EditSelected(forceEdit);
    /// <summary>
    /// <para>If <c>true</c>, recursive folding is enabled for this <see cref="Tree" />. Holding down Shift while clicking the fold arrow collapses or uncollapses the <see cref="TreeItem" /> and all its descendants.</para>
    /// </summary>
    public bool EnableRecursiveFolding { get => _node.EnableRecursiveFolding; set => _node.EnableRecursiveFolding = value; }
    /// <summary>
    /// <para>Makes the currently focused cell visible.</para>
    /// <para>This will scroll the tree if necessary. In <see cref="Tree.SelectModeEnum.Row" /> mode, this will not do horizontal scrolling, as all the cells in the selected row is focused logically.</para>
    /// <para><b>Note:</b> Despite the name of this method, the focus cursor itself is only visible in <see cref="Tree.SelectModeEnum.Multi" /> mode.</para>
    /// </summary>
    public void EnsureCursorIsVisible() => _node.EnsureCursorIsVisible();
    /// <summary>
    /// <para>Returns the button ID at <paramref name="position" />, or -1 if no button is there.</para>
    /// </summary>
    public int GetButtonIdAtPosition(Vector2 position) => _node.GetButtonIdAtPosition(position);
    /// <summary>
    /// <para>Returns the column index at <paramref name="position" />, or -1 if no item is there.</para>
    /// </summary>
    public int GetColumnAtPosition(Vector2 position) => _node.GetColumnAtPosition(position);
    /// <summary>
    /// <para>Returns the expand ratio assigned to the column.</para>
    /// </summary>
    public int GetColumnExpandRatio(int column) => _node.GetColumnExpandRatio(column);
    /// <summary>
    /// <para>Returns the column's title.</para>
    /// </summary>
    public string GetColumnTitle(int column) => _node.GetColumnTitle(column);
    /// <summary>
    /// <para>Returns the column title alignment.</para>
    /// </summary>
    public HorizontalAlignment GetColumnTitleAlignment(int column) => _node.GetColumnTitleAlignment(column);
    /// <summary>
    /// <para>Returns column title base writing direction.</para>
    /// </summary>
    public Control.TextDirection GetColumnTitleDirection(int column) => _node.GetColumnTitleDirection(column);
    /// <summary>
    /// <para>Returns column title language code.</para>
    /// </summary>
    public string GetColumnTitleLanguage(int column) => _node.GetColumnTitleLanguage(column);
    /// <summary>
    /// <para>Returns the column's width in pixels.</para>
    /// </summary>
    public int GetColumnWidth(int column) => _node.GetColumnWidth(column);
    /// <summary>
    /// <para>Returns the rectangle for custom popups. Helper to create custom cell controls that display a popup. See <see cref="TreeItem.SetCellMode(System.Int32,Godot.TreeItem.TreeCellMode)" />.</para>
    /// </summary>
    public Rect2 GetCustomPopupRect() => _node.GetCustomPopupRect();
    /// <summary>
    /// <para>Returns the drop section at <paramref name="position" />, or -100 if no item is there.</para>
    /// <para>Values -1, 0, or 1 will be returned for the "above item", "on item", and "below item" drop sections, respectively. See <see cref="Tree.DropModeFlagsEnum" /> for a description of each drop section.</para>
    /// <para>To get the item which the returned drop section is relative to, use <see cref="Tree.GetItemAtPosition(Godot.Vector2)" />.</para>
    /// </summary>
    public int GetDropSectionAtPosition(Vector2 position) => _node.GetDropSectionAtPosition(position);
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
    public TreeItem GetEdited() => _node.GetEdited();
    /// <summary>
    /// <para>Returns the column for the currently edited item.</para>
    /// </summary>
    public int GetEditedColumn() => _node.GetEditedColumn();
    /// <summary>
    /// <para>Returns the rectangle area for the specified <see cref="TreeItem" />. If <paramref name="column" /> is specified, only get the position and size of that column, otherwise get the rectangle containing all columns. If a button index is specified, the rectangle of that button will be returned.</para>
    /// </summary>
    public Rect2 GetItemAreaRect(TreeItem item, int column, int buttonIndex) => _node.GetItemAreaRect(item, column, buttonIndex);
    /// <summary>
    /// <para>Returns the tree item at the specified position (relative to the tree origin position).</para>
    /// </summary>
    public TreeItem GetItemAtPosition(Vector2 position) => _node.GetItemAtPosition(position);
    /// <summary>
    /// <para>Returns the next selected <see cref="TreeItem" /> after the given one, or <c>null</c> if the end is reached.</para>
    /// <para>If <paramref name="from" /> is <c>null</c>, this returns the first selected item.</para>
    /// </summary>
    public TreeItem GetNextSelected(TreeItem @from) => _node.GetNextSelected(@from);
    /// <summary>
    /// <para>Returns the last pressed button's index.</para>
    /// </summary>
    public int GetPressedButton() => _node.GetPressedButton();
    /// <summary>
    /// <para>Returns the tree's root item, or <c>null</c> if the tree is empty.</para>
    /// </summary>
    public TreeItem GetRoot() => _node.GetRoot();
    /// <summary>
    /// <para>Returns the current scrolling position.</para>
    /// </summary>
    public Vector2 GetScroll() => _node.GetScroll();
    /// <summary>
    /// <para>Returns the currently focused item, or <c>null</c> if no item is focused.</para>
    /// <para>In <see cref="Tree.SelectModeEnum.Row" /> and <see cref="Tree.SelectModeEnum.Single" /> modes, the focused item is same as the selected item. In <see cref="Tree.SelectModeEnum.Multi" /> mode, the focused item is the item under the focus cursor, not necessarily selected.</para>
    /// <para>To get the currently selected item(s), use <see cref="Tree.GetNextSelected(Godot.TreeItem)" />.</para>
    /// </summary>
    public TreeItem GetSelected() => _node.GetSelected();
    /// <summary>
    /// <para>Returns the currently focused column, or -1 if no column is focused.</para>
    /// <para>In <see cref="Tree.SelectModeEnum.Single" /> mode, the focused column is the selected column. In <see cref="Tree.SelectModeEnum.Row" /> mode, the focused column is always 0 if any item is selected. In <see cref="Tree.SelectModeEnum.Multi" /> mode, the focused column is the column under the focus cursor, and there are not necessarily any column selected.</para>
    /// <para>To tell whether a column of an item is selected, use <see cref="TreeItem.IsSelected(System.Int32)" />.</para>
    /// </summary>
    public int GetSelectedColumn() => _node.GetSelectedColumn();
    /// <summary>
    /// <para>If <c>true</c>, the folding arrow is hidden.</para>
    /// </summary>
    public bool HideFolding { get => _node.HideFolding; set => _node.HideFolding = value; }
    /// <summary>
    /// <para>If <c>true</c>, the tree's root is hidden.</para>
    /// </summary>
    public bool HideRoot { get => _node.HideRoot; set => _node.HideRoot = value; }
    /// <summary>
    /// <para>Returns <c>true</c> if the column has enabled clipping (see <see cref="Tree.SetColumnClipContent(System.Int32,System.Boolean)" />).</para>
    /// </summary>
    public bool IsColumnClippingContent(int column) => _node.IsColumnClippingContent(column);
    /// <summary>
    /// <para>Returns <c>true</c> if the column has enabled expanding (see <see cref="Tree.SetColumnExpand(System.Int32,System.Boolean)" />).</para>
    /// </summary>
    public bool IsColumnExpanding(int column) => _node.IsColumnExpanding(column);
    /// <summary>
    /// <para>If <c>true</c>, enables horizontal scrolling.</para>
    /// </summary>
    public bool ScrollHorizontalEnabled { get => _node.ScrollHorizontalEnabled; set => _node.ScrollHorizontalEnabled = value; }
    /// <summary>
    /// <para>Causes the <see cref="Tree" /> to jump to the specified <see cref="TreeItem" />.</para>
    /// </summary>
    public void ScrollToItem(TreeItem item, bool centerOnItem) => _node.ScrollToItem(item, centerOnItem);
    /// <summary>
    /// <para>If <c>true</c>, enables vertical scrolling.</para>
    /// </summary>
    public bool ScrollVerticalEnabled { get => _node.ScrollVerticalEnabled; set => _node.ScrollVerticalEnabled = value; }
    /// <summary>
    /// <para>Allows single or multiple selection. See the <see cref="Tree.SelectModeEnum" /> constants.</para>
    /// </summary>
    public Tree.SelectModeEnum SelectMode { get => _node.SelectMode; set => _node.SelectMode = value; }
    /// <summary>
    /// <para>Allows to enable clipping for column's content, making the content size ignored.</para>
    /// </summary>
    public void SetColumnClipContent(int column, bool enable) => _node.SetColumnClipContent(column, enable);
    /// <summary>
    /// <para>Overrides the calculated minimum width of a column. It can be set to <c>0</c> to restore the default behavior. Columns that have the "Expand" flag will use their "min_width" in a similar fashion to <see cref="Control.SizeFlagsStretchRatio" />.</para>
    /// </summary>
    public void SetColumnCustomMinimumWidth(int column, int minWidth) => _node.SetColumnCustomMinimumWidth(column, minWidth);
    /// <summary>
    /// <para>If <c>true</c>, the column will have the "Expand" flag of <see cref="Control" />. Columns that have the "Expand" flag will use their expand ratio in a similar fashion to <see cref="Control.SizeFlagsStretchRatio" /> (see <see cref="Tree.SetColumnExpandRatio(System.Int32,System.Int32)" />).</para>
    /// </summary>
    public void SetColumnExpand(int column, bool expand) => _node.SetColumnExpand(column, expand);
    /// <summary>
    /// <para>Sets the relative expand ratio for a column. See <see cref="Tree.SetColumnExpand(System.Int32,System.Boolean)" />.</para>
    /// </summary>
    public void SetColumnExpandRatio(int column, int ratio) => _node.SetColumnExpandRatio(column, ratio);
    /// <summary>
    /// <para>Sets the title of a column.</para>
    /// </summary>
    public void SetColumnTitle(int column, string title) => _node.SetColumnTitle(column, title);
    /// <summary>
    /// <para>Sets the column title alignment. Note that <see cref="HorizontalAlignment.Fill" /> is not supported for column titles.</para>
    /// </summary>
    public void SetColumnTitleAlignment(int column, HorizontalAlignment titleAlignment) => _node.SetColumnTitleAlignment(column, titleAlignment);
    /// <summary>
    /// <para>Sets column title base writing direction.</para>
    /// </summary>
    public void SetColumnTitleDirection(int column, Control.TextDirection direction) => _node.SetColumnTitleDirection(column, direction);
    /// <summary>
    /// <para>Sets language code of column title used for line-breaking and text shaping algorithms, if left empty current locale is used instead.</para>
    /// </summary>
    public void SetColumnTitleLanguage(int column, string language) => _node.SetColumnTitleLanguage(column, language);
    /// <summary>
    /// <para>Selects the specified <see cref="TreeItem" /> and column.</para>
    /// </summary>
    public void SetSelected(TreeItem item, int column) => _node.SetSelected(item, column);

}