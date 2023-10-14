namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>This control provides a vertical list of selectable items that may be in a single or in multiple columns, with each item having options for text and an icon. Tooltips are supported and may be different for every item in the list.</para>
/// <para>Selectable items in the list may be selected or deselected and multiple selection may be enabled. Selection with right mouse button may also be enabled to allow use of popup context menus. Items may also be "activated" by double-clicking them or by pressing Enter.</para>
/// <para>Item text only supports single-line strings. Newline characters (e.g. <c>\n</c>) in the string won't produce a newline. Text wrapping is enabled in <see cref="ItemList.IconModeEnum.Top" /> mode, but the column's width is adjusted to fully fit its content by default. You need to set <see cref="ItemList.FixedColumnWidth" /> greater than zero to wrap the text.</para>
/// <para>All <c>set_*</c> methods allow negative item indices, i.e. <c>-1</c> to access the last item, <c>-2</c> to select the second-to-last item, and so on.</para>
/// <para><b>Incremental search:</b> Like <see cref="PopupMenu" /> and <see cref="Tree" />, <see cref="ItemList" /> supports searching within the list while the control is focused. Press a key that matches the first letter of an item's name to select the first item starting with the given letter. After that point, there are two ways to perform incremental search: 1) Press the same key again before the timeout duration to select the next item starting with the same letter. 2) Press letter keys that match the rest of the word before the timeout duration to match to select the item in question directly. Both of these actions will be reset to the beginning of the list if the timeout duration has passed since the last keystroke was registered. You can adjust the timeout duration by changing <c>ProjectSettings.gui/timers/incremental_search_max_interval_msec</c>.</para>
/// </summary>
public class ItemListAdapter : ControlAdapter, IItemList {
  private readonly ItemList _node;

  public ItemListAdapter(ItemList node) : base(node) { _node = node; }

    /// <summary>
    /// <para>Adds an item to the item list with no text, only an icon. Returns the index of an added item.</para>
    /// </summary>
    public int AddIconItem(Texture2D icon, bool selectable) => _node.AddIconItem(icon, selectable);
    /// <summary>
    /// <para>Adds an item to the item list with specified text. Returns the index of an added item.</para>
    /// <para>Specify an <paramref name="icon" />, or use <c>null</c> as the <paramref name="icon" /> for a list item with no icon.</para>
    /// <para>If selectable is <c>true</c>, the list item will be selectable.</para>
    /// </summary>
    public int AddItem(string text, Texture2D icon, bool selectable) => _node.AddItem(text, icon, selectable);
    /// <summary>
    /// <para>If <c>true</c>, the currently selected item can be selected again.</para>
    /// </summary>
    public bool AllowReselect { get => _node.AllowReselect; set => _node.AllowReselect = value; }
    /// <summary>
    /// <para>If <c>true</c>, right mouse button click can select items.</para>
    /// </summary>
    public bool AllowRmbSelect { get => _node.AllowRmbSelect; set => _node.AllowRmbSelect = value; }
    /// <summary>
    /// <para>If <c>true</c>, allows navigating the <see cref="ItemList" /> with letter keys through incremental search.</para>
    /// </summary>
    public bool AllowSearch { get => _node.AllowSearch; set => _node.AllowSearch = value; }
    /// <summary>
    /// <para>If <c>true</c>, the control will automatically resize the height to fit its content.</para>
    /// </summary>
    public bool AutoHeight { get => _node.AutoHeight; set => _node.AutoHeight = value; }
    /// <summary>
    /// <para>Removes all items from the list.</para>
    /// </summary>
    public void Clear() => _node.Clear();
    /// <summary>
    /// <para>Ensures the item associated with the specified index is not selected.</para>
    /// </summary>
    public void Deselect(int idx) => _node.Deselect(idx);
    /// <summary>
    /// <para>Ensures there are no items selected.</para>
    /// </summary>
    public void DeselectAll() => _node.DeselectAll();
    /// <summary>
    /// <para>Ensure current selection is visible, adjusting the scroll position as necessary.</para>
    /// </summary>
    public void EnsureCurrentIsVisible() => _node.EnsureCurrentIsVisible();
    /// <summary>
    /// <para>The width all columns will be adjusted to.</para>
    /// <para>A value of zero disables the adjustment, each item will have a width equal to the width of its content and the columns will have an uneven width.</para>
    /// </summary>
    public int FixedColumnWidth { get => _node.FixedColumnWidth; set => _node.FixedColumnWidth = value; }
    /// <summary>
    /// <para>The size all icons will be adjusted to.</para>
    /// <para>If either X or Y component is not greater than zero, icon size won't be affected.</para>
    /// </summary>
    public Vector2I FixedIconSize { get => _node.FixedIconSize; set => _node.FixedIconSize = value; }
    /// <summary>
    /// <para>Forces an update to the list size based on its items. This happens automatically whenever size of the items, or other relevant settings like <see cref="ItemList.AutoHeight" />, change. The method can be used to trigger the update ahead of next drawing pass.</para>
    /// </summary>
    public void ForceUpdateListSize() => _node.ForceUpdateListSize();
    /// <summary>
    /// <para>Returns the item index at the given <paramref name="position" />.</para>
    /// <para>When there is no item at that point, -1 will be returned if <paramref name="exact" /> is <c>true</c>, and the closest item index will be returned otherwise.</para>
    /// <para><b>Note:</b> The returned value is unreliable if called right after modifying the <see cref="ItemList" />, before it redraws in the next frame.</para>
    /// </summary>
    public int GetItemAtPosition(Vector2 position, bool exact) => _node.GetItemAtPosition(position, exact);
    /// <summary>
    /// <para>Returns the custom background color of the item specified by <paramref name="idx" /> index.</para>
    /// </summary>
    public Color GetItemCustomBgColor(int idx) => _node.GetItemCustomBgColor(idx);
    /// <summary>
    /// <para>Returns the custom foreground color of the item specified by <paramref name="idx" /> index.</para>
    /// </summary>
    public Color GetItemCustomFgColor(int idx) => _node.GetItemCustomFgColor(idx);
    /// <summary>
    /// <para>Returns the icon associated with the specified index.</para>
    /// </summary>
    public Texture2D GetItemIcon(int idx) => _node.GetItemIcon(idx);
    /// <summary>
    /// <para>Returns a <see cref="Color" /> modulating item's icon at the specified index.</para>
    /// </summary>
    public Color GetItemIconModulate(int idx) => _node.GetItemIconModulate(idx);
    /// <summary>
    /// <para>Returns the region of item's icon used. The whole icon will be used if the region has no area.</para>
    /// </summary>
    public Rect2 GetItemIconRegion(int idx) => _node.GetItemIconRegion(idx);
    /// <summary>
    /// <para>Returns item's text language code.</para>
    /// </summary>
    public string GetItemLanguage(int idx) => _node.GetItemLanguage(idx);
    /// <summary>
    /// <para>Returns the metadata value of the specified index.</para>
    /// </summary>
    public Variant GetItemMetadata(int idx) => _node.GetItemMetadata(idx);
    /// <summary>
    /// <para>Returns the position and size of the item with the specified index, in the coordinate system of the <see cref="ItemList" /> node. If <paramref name="expand" /> is <c>true</c> the last column expands to fill the rest of the row.</para>
    /// <para><b>Note:</b> The returned value is unreliable if called right after modifying the <see cref="ItemList" />, before it redraws in the next frame.</para>
    /// </summary>
    public Rect2 GetItemRect(int idx, bool expand) => _node.GetItemRect(idx, expand);
    /// <summary>
    /// <para>Returns the text associated with the specified index.</para>
    /// </summary>
    public string GetItemText(int idx) => _node.GetItemText(idx);
    /// <summary>
    /// <para>Returns item's text base writing direction.</para>
    /// </summary>
    public Control.TextDirection GetItemTextDirection(int idx) => _node.GetItemTextDirection(idx);
    /// <summary>
    /// <para>Returns the tooltip hint associated with the specified index.</para>
    /// </summary>
    public string GetItemTooltip(int idx) => _node.GetItemTooltip(idx);
    /// <summary>
    /// <para>Returns an array with the indexes of the selected items.</para>
    /// </summary>
    public int[] GetSelectedItems() => _node.GetSelectedItems();
    /// <summary>
    /// <para>Returns the vertical scrollbar.</para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash. If you wish to hide it or any of its children, use their <see cref="CanvasItem.Visible" /> property.</para>
    /// </summary>
    public VScrollBar GetVScrollBar() => _node.GetVScrollBar();
    /// <summary>
    /// <para>The icon position, whether above or to the left of the text. See the <see cref="ItemList.IconModeEnum" /> constants.</para>
    /// </summary>
    public ItemList.IconModeEnum IconMode { get => _node.IconMode; set => _node.IconMode = value; }
    /// <summary>
    /// <para>The scale of icon applied after <see cref="ItemList.FixedIconSize" /> and transposing takes effect.</para>
    /// </summary>
    public float IconScale { get => _node.IconScale; set => _node.IconScale = value; }
    /// <summary>
    /// <para>Returns <c>true</c> if one or more items are selected.</para>
    /// </summary>
    public bool IsAnythingSelected() => _node.IsAnythingSelected();
    /// <summary>
    /// <para>Returns <c>true</c> if the item at the specified index is disabled.</para>
    /// </summary>
    public bool IsItemDisabled(int idx) => _node.IsItemDisabled(idx);
    /// <summary>
    /// <para>Returns <c>true</c> if the item icon will be drawn transposed, i.e. the X and Y axes are swapped.</para>
    /// </summary>
    public bool IsItemIconTransposed(int idx) => _node.IsItemIconTransposed(idx);
    /// <summary>
    /// <para>Returns <c>true</c> if the item at the specified index is selectable.</para>
    /// </summary>
    public bool IsItemSelectable(int idx) => _node.IsItemSelectable(idx);
    /// <summary>
    /// <para>Returns <c>true</c> if the tooltip is enabled for specified item index.</para>
    /// </summary>
    public bool IsItemTooltipEnabled(int idx) => _node.IsItemTooltipEnabled(idx);
    /// <summary>
    /// <para>Returns <c>true</c> if the item at the specified index is currently selected.</para>
    /// </summary>
    public bool IsSelected(int idx) => _node.IsSelected(idx);
    /// <summary>
    /// <para>The number of items currently in the list.</para>
    /// </summary>
    public int ItemCount { get => _node.ItemCount; set => _node.ItemCount = value; }
    /// <summary>
    /// <para>Maximum columns the list will have.</para>
    /// <para>If greater than zero, the content will be split among the specified columns.</para>
    /// <para>A value of zero means unlimited columns, i.e. all items will be put in the same row.</para>
    /// </summary>
    public int MaxColumns { get => _node.MaxColumns; set => _node.MaxColumns = value; }
    /// <summary>
    /// <para>Maximum lines of text allowed in each item. Space will be reserved even when there is not enough lines of text to display.</para>
    /// <para><b>Note:</b> This property takes effect only when <see cref="ItemList.IconMode" /> is <see cref="ItemList.IconModeEnum.Top" />. To make the text wrap, <see cref="ItemList.FixedColumnWidth" /> should be greater than zero.</para>
    /// </summary>
    public int MaxTextLines { get => _node.MaxTextLines; set => _node.MaxTextLines = value; }
    /// <summary>
    /// <para>Moves item from index <paramref name="fromIdx" /> to <paramref name="toIdx" />.</para>
    /// </summary>
    public void MoveItem(int fromIdx, int toIdx) => _node.MoveItem(fromIdx, toIdx);
    /// <summary>
    /// <para>Removes the item specified by <paramref name="idx" /> index from the list.</para>
    /// </summary>
    public void RemoveItem(int idx) => _node.RemoveItem(idx);
    /// <summary>
    /// <para>Whether all columns will have the same width.</para>
    /// <para>If <c>true</c>, the width is equal to the largest column width of all columns.</para>
    /// </summary>
    public bool SameColumnWidth { get => _node.SameColumnWidth; set => _node.SameColumnWidth = value; }
    /// <summary>
    /// <para>Select the item at the specified index.</para>
    /// <para><b>Note:</b> This method does not trigger the item selection signal.</para>
    /// </summary>
    public void Select(int idx, bool single) => _node.Select(idx, single);
    /// <summary>
    /// <para>Allows single or multiple item selection. See the <see cref="ItemList.SelectModeEnum" /> constants.</para>
    /// </summary>
    public ItemList.SelectModeEnum SelectMode { get => _node.SelectMode; set => _node.SelectMode = value; }
    /// <summary>
    /// <para>Sets the background color of the item specified by <paramref name="idx" /> index to the specified <see cref="Color" />.</para>
    /// </summary>
    public void SetItemCustomBgColor(int idx, Color customBgColor) => _node.SetItemCustomBgColor(idx, customBgColor);
    /// <summary>
    /// <para>Sets the foreground color of the item specified by <paramref name="idx" /> index to the specified <see cref="Color" />.</para>
    /// </summary>
    public void SetItemCustomFgColor(int idx, Color customFgColor) => _node.SetItemCustomFgColor(idx, customFgColor);
    /// <summary>
    /// <para>Disables (or enables) the item at the specified index.</para>
    /// <para>Disabled items cannot be selected and do not trigger activation signals (when double-clicking or pressing Enter).</para>
    /// </summary>
    public void SetItemDisabled(int idx, bool disabled) => _node.SetItemDisabled(idx, disabled);
    /// <summary>
    /// <para>Sets (or replaces) the icon's <see cref="Texture2D" /> associated with the specified index.</para>
    /// </summary>
    public void SetItemIcon(int idx, Texture2D icon) => _node.SetItemIcon(idx, icon);
    /// <summary>
    /// <para>Sets a modulating <see cref="Color" /> of the item associated with the specified index.</para>
    /// </summary>
    public void SetItemIconModulate(int idx, Color modulate) => _node.SetItemIconModulate(idx, modulate);
    /// <summary>
    /// <para>Sets the region of item's icon used. The whole icon will be used if the region has no area.</para>
    /// </summary>
    public void SetItemIconRegion(int idx, Rect2 rect) => _node.SetItemIconRegion(idx, rect);
    /// <summary>
    /// <para>Sets whether the item icon will be drawn transposed.</para>
    /// </summary>
    public void SetItemIconTransposed(int idx, bool transposed) => _node.SetItemIconTransposed(idx, transposed);
    /// <summary>
    /// <para>Sets language code of item's text used for line-breaking and text shaping algorithms, if left empty current locale is used instead.</para>
    /// </summary>
    public void SetItemLanguage(int idx, string language) => _node.SetItemLanguage(idx, language);
    /// <summary>
    /// <para>Sets a value (of any type) to be stored with the item associated with the specified index.</para>
    /// </summary>
    public void SetItemMetadata(int idx, Variant metadata) => _node.SetItemMetadata(idx, metadata);
    /// <summary>
    /// <para>Allows or disallows selection of the item associated with the specified index.</para>
    /// </summary>
    public void SetItemSelectable(int idx, bool selectable) => _node.SetItemSelectable(idx, selectable);
    /// <summary>
    /// <para>Sets text of the item associated with the specified index.</para>
    /// </summary>
    public void SetItemText(int idx, string text) => _node.SetItemText(idx, text);
    /// <summary>
    /// <para>Sets item's text base writing direction.</para>
    /// </summary>
    public void SetItemTextDirection(int idx, Control.TextDirection direction) => _node.SetItemTextDirection(idx, direction);
    /// <summary>
    /// <para>Sets the tooltip hint for the item associated with the specified index.</para>
    /// </summary>
    public void SetItemTooltip(int idx, string tooltip) => _node.SetItemTooltip(idx, tooltip);
    /// <summary>
    /// <para>Sets whether the tooltip hint is enabled for specified item index.</para>
    /// </summary>
    public void SetItemTooltipEnabled(int idx, bool enable) => _node.SetItemTooltipEnabled(idx, enable);
    /// <summary>
    /// <para>Sorts items in the list by their text.</para>
    /// </summary>
    public void SortItemsByText() => _node.SortItemsByText();
    /// <summary>
    /// <para>Sets the clipping behavior when the text exceeds an item's bounding rectangle. See <see cref="TextServer.OverrunBehavior" /> for a description of all modes.</para>
    /// </summary>
    public TextServer.OverrunBehavior TextOverrunBehavior { get => _node.TextOverrunBehavior; set => _node.TextOverrunBehavior = value; }

}