namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class ItemListNode : ItemList, IItemList { }

/// <summary>
/// <para>This control provides a vertical list of selectable items that may be in a single or in multiple columns, with each item having options for text and an icon. Tooltips are supported and may be different for every item in the list.</para>
/// <para>Selectable items in the list may be selected or deselected and multiple selection may be enabled. Selection with right mouse button may also be enabled to allow use of popup context menus. Items may also be "activated" by double-clicking them or by pressing Enter.</para>
/// <para>Item text only supports single-line strings. Newline characters (e.g. <c>\n</c>) in the string won't produce a newline. Text wrapping is enabled in <see cref="ItemList.IconModeEnum.Top" /> mode, but the column's width is adjusted to fully fit its content by default. You need to set <see cref="ItemList.FixedColumnWidth" /> greater than zero to wrap the text.</para>
/// <para>All <c>set_*</c> methods allow negative item indices, i.e. <c>-1</c> to access the last item, <c>-2</c> to select the second-to-last item, and so on.</para>
/// <para><b>Incremental search:</b> Like <see cref="PopupMenu" /> and <see cref="Tree" />, <see cref="ItemList" /> supports searching within the list while the control is focused. Press a key that matches the first letter of an item's name to select the first item starting with the given letter. After that point, there are two ways to perform incremental search: 1) Press the same key again before the timeout duration to select the next item starting with the same letter. 2) Press letter keys that match the rest of the word before the timeout duration to match to select the item in question directly. Both of these actions will be reset to the beginning of the list if the timeout duration has passed since the last keystroke was registered. You can adjust the timeout duration by changing <c>ProjectSettings.gui/timers/incremental_search_max_interval_msec</c>.</para>
/// </summary>
public interface IItemList : IControl {
    /// <summary>
    /// <para>Adds an item to the item list with no text, only an icon. Returns the index of an added item.</para>
    /// </summary>
    int AddIconItem(Texture2D icon, bool selectable);
    /// <summary>
    /// <para>Adds an item to the item list with specified text. Returns the index of an added item.</para>
    /// <para>Specify an <paramref name="icon" />, or use <c>null</c> as the <paramref name="icon" /> for a list item with no icon.</para>
    /// <para>If selectable is <c>true</c>, the list item will be selectable.</para>
    /// </summary>
    int AddItem(string text, Texture2D icon, bool selectable);
    /// <summary>
    /// <para>If <c>true</c>, the currently selected item can be selected again.</para>
    /// </summary>
    bool AllowReselect { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, right mouse button click can select items.</para>
    /// </summary>
    bool AllowRmbSelect { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, allows navigating the <see cref="ItemList" /> with letter keys through incremental search.</para>
    /// </summary>
    bool AllowSearch { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the control will automatically resize the height to fit its content.</para>
    /// </summary>
    bool AutoHeight { get; set; }
    /// <summary>
    /// <para>Removes all items from the list.</para>
    /// </summary>
    void Clear();
    /// <summary>
    /// <para>Ensures the item associated with the specified index is not selected.</para>
    /// </summary>
    void Deselect(int idx);
    /// <summary>
    /// <para>Ensures there are no items selected.</para>
    /// </summary>
    void DeselectAll();
    /// <summary>
    /// <para>Ensure current selection is visible, adjusting the scroll position as necessary.</para>
    /// </summary>
    void EnsureCurrentIsVisible();
    /// <summary>
    /// <para>The width all columns will be adjusted to.</para>
    /// <para>A value of zero disables the adjustment, each item will have a width equal to the width of its content and the columns will have an uneven width.</para>
    /// </summary>
    int FixedColumnWidth { get; set; }
    /// <summary>
    /// <para>The size all icons will be adjusted to.</para>
    /// <para>If either X or Y component is not greater than zero, icon size won't be affected.</para>
    /// </summary>
    Vector2I FixedIconSize { get; set; }
    /// <summary>
    /// <para>Forces an update to the list size based on its items. This happens automatically whenever size of the items, or other relevant settings like <see cref="ItemList.AutoHeight" />, change. The method can be used to trigger the update ahead of next drawing pass.</para>
    /// </summary>
    void ForceUpdateListSize();
    /// <summary>
    /// <para>Returns the item index at the given <paramref name="position" />.</para>
    /// <para>When there is no item at that point, -1 will be returned if <paramref name="exact" /> is <c>true</c>, and the closest item index will be returned otherwise.</para>
    /// <para><b>Note:</b> The returned value is unreliable if called right after modifying the <see cref="ItemList" />, before it redraws in the next frame.</para>
    /// </summary>
    int GetItemAtPosition(Vector2 position, bool exact);
    /// <summary>
    /// <para>Returns the custom background color of the item specified by <paramref name="idx" /> index.</para>
    /// </summary>
    Color GetItemCustomBgColor(int idx);
    /// <summary>
    /// <para>Returns the custom foreground color of the item specified by <paramref name="idx" /> index.</para>
    /// </summary>
    Color GetItemCustomFgColor(int idx);
    /// <summary>
    /// <para>Returns the icon associated with the specified index.</para>
    /// </summary>
    Texture2D GetItemIcon(int idx);
    /// <summary>
    /// <para>Returns a <see cref="Color" /> modulating item's icon at the specified index.</para>
    /// </summary>
    Color GetItemIconModulate(int idx);
    /// <summary>
    /// <para>Returns the region of item's icon used. The whole icon will be used if the region has no area.</para>
    /// </summary>
    Rect2 GetItemIconRegion(int idx);
    /// <summary>
    /// <para>Returns item's text language code.</para>
    /// </summary>
    string GetItemLanguage(int idx);
    /// <summary>
    /// <para>Returns the metadata value of the specified index.</para>
    /// </summary>
    Variant GetItemMetadata(int idx);
    /// <summary>
    /// <para>Returns the position and size of the item with the specified index, in the coordinate system of the <see cref="ItemList" /> node. If <paramref name="expand" /> is <c>true</c> the last column expands to fill the rest of the row.</para>
    /// <para><b>Note:</b> The returned value is unreliable if called right after modifying the <see cref="ItemList" />, before it redraws in the next frame.</para>
    /// </summary>
    Rect2 GetItemRect(int idx, bool expand);
    /// <summary>
    /// <para>Returns the text associated with the specified index.</para>
    /// </summary>
    string GetItemText(int idx);
    /// <summary>
    /// <para>Returns item's text base writing direction.</para>
    /// </summary>
    Control.TextDirection GetItemTextDirection(int idx);
    /// <summary>
    /// <para>Returns the tooltip hint associated with the specified index.</para>
    /// </summary>
    string GetItemTooltip(int idx);
    /// <summary>
    /// <para>Returns an array with the indexes of the selected items.</para>
    /// </summary>
    int[] GetSelectedItems();
    /// <summary>
    /// <para>Returns the vertical scrollbar.</para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash. If you wish to hide it or any of its children, use their <see cref="CanvasItem.Visible" /> property.</para>
    /// </summary>
    VScrollBar GetVScrollBar();
    /// <summary>
    /// <para>The icon position, whether above or to the left of the text. See the <see cref="ItemList.IconModeEnum" /> constants.</para>
    /// </summary>
    ItemList.IconModeEnum IconMode { get; set; }
    /// <summary>
    /// <para>The scale of icon applied after <see cref="ItemList.FixedIconSize" /> and transposing takes effect.</para>
    /// </summary>
    float IconScale { get; set; }
    /// <summary>
    /// <para>Returns <c>true</c> if one or more items are selected.</para>
    /// </summary>
    bool IsAnythingSelected();
    /// <summary>
    /// <para>Returns <c>true</c> if the item at the specified index is disabled.</para>
    /// </summary>
    bool IsItemDisabled(int idx);
    /// <summary>
    /// <para>Returns <c>true</c> if the item icon will be drawn transposed, i.e. the X and Y axes are swapped.</para>
    /// </summary>
    bool IsItemIconTransposed(int idx);
    /// <summary>
    /// <para>Returns <c>true</c> if the item at the specified index is selectable.</para>
    /// </summary>
    bool IsItemSelectable(int idx);
    /// <summary>
    /// <para>Returns <c>true</c> if the tooltip is enabled for specified item index.</para>
    /// </summary>
    bool IsItemTooltipEnabled(int idx);
    /// <summary>
    /// <para>Returns <c>true</c> if the item at the specified index is currently selected.</para>
    /// </summary>
    bool IsSelected(int idx);
    /// <summary>
    /// <para>The number of items currently in the list.</para>
    /// </summary>
    int ItemCount { get; set; }
    /// <summary>
    /// <para>Maximum columns the list will have.</para>
    /// <para>If greater than zero, the content will be split among the specified columns.</para>
    /// <para>A value of zero means unlimited columns, i.e. all items will be put in the same row.</para>
    /// </summary>
    int MaxColumns { get; set; }
    /// <summary>
    /// <para>Maximum lines of text allowed in each item. Space will be reserved even when there is not enough lines of text to display.</para>
    /// <para><b>Note:</b> This property takes effect only when <see cref="ItemList.IconMode" /> is <see cref="ItemList.IconModeEnum.Top" />. To make the text wrap, <see cref="ItemList.FixedColumnWidth" /> should be greater than zero.</para>
    /// </summary>
    int MaxTextLines { get; set; }
    /// <summary>
    /// <para>Moves item from index <paramref name="fromIdx" /> to <paramref name="toIdx" />.</para>
    /// </summary>
    void MoveItem(int fromIdx, int toIdx);
    /// <summary>
    /// <para>Removes the item specified by <paramref name="idx" /> index from the list.</para>
    /// </summary>
    void RemoveItem(int idx);
    /// <summary>
    /// <para>Whether all columns will have the same width.</para>
    /// <para>If <c>true</c>, the width is equal to the largest column width of all columns.</para>
    /// </summary>
    bool SameColumnWidth { get; set; }
    /// <summary>
    /// <para>Select the item at the specified index.</para>
    /// <para><b>Note:</b> This method does not trigger the item selection signal.</para>
    /// </summary>
    void Select(int idx, bool single);
    /// <summary>
    /// <para>Allows single or multiple item selection. See the <see cref="ItemList.SelectModeEnum" /> constants.</para>
    /// </summary>
    ItemList.SelectModeEnum SelectMode { get; set; }
    /// <summary>
    /// <para>Sets the background color of the item specified by <paramref name="idx" /> index to the specified <see cref="Color" />.</para>
    /// </summary>
    void SetItemCustomBgColor(int idx, Color customBgColor);
    /// <summary>
    /// <para>Sets the foreground color of the item specified by <paramref name="idx" /> index to the specified <see cref="Color" />.</para>
    /// </summary>
    void SetItemCustomFgColor(int idx, Color customFgColor);
    /// <summary>
    /// <para>Disables (or enables) the item at the specified index.</para>
    /// <para>Disabled items cannot be selected and do not trigger activation signals (when double-clicking or pressing Enter).</para>
    /// </summary>
    void SetItemDisabled(int idx, bool disabled);
    /// <summary>
    /// <para>Sets (or replaces) the icon's <see cref="Texture2D" /> associated with the specified index.</para>
    /// </summary>
    void SetItemIcon(int idx, Texture2D icon);
    /// <summary>
    /// <para>Sets a modulating <see cref="Color" /> of the item associated with the specified index.</para>
    /// </summary>
    void SetItemIconModulate(int idx, Color modulate);
    /// <summary>
    /// <para>Sets the region of item's icon used. The whole icon will be used if the region has no area.</para>
    /// </summary>
    void SetItemIconRegion(int idx, Rect2 rect);
    /// <summary>
    /// <para>Sets whether the item icon will be drawn transposed.</para>
    /// </summary>
    void SetItemIconTransposed(int idx, bool transposed);
    /// <summary>
    /// <para>Sets language code of item's text used for line-breaking and text shaping algorithms, if left empty current locale is used instead.</para>
    /// </summary>
    void SetItemLanguage(int idx, string language);
    /// <summary>
    /// <para>Sets a value (of any type) to be stored with the item associated with the specified index.</para>
    /// </summary>
    void SetItemMetadata(int idx, Variant metadata);
    /// <summary>
    /// <para>Allows or disallows selection of the item associated with the specified index.</para>
    /// </summary>
    void SetItemSelectable(int idx, bool selectable);
    /// <summary>
    /// <para>Sets text of the item associated with the specified index.</para>
    /// </summary>
    void SetItemText(int idx, string text);
    /// <summary>
    /// <para>Sets item's text base writing direction.</para>
    /// </summary>
    void SetItemTextDirection(int idx, Control.TextDirection direction);
    /// <summary>
    /// <para>Sets the tooltip hint for the item associated with the specified index.</para>
    /// </summary>
    void SetItemTooltip(int idx, string tooltip);
    /// <summary>
    /// <para>Sets whether the tooltip hint is enabled for specified item index.</para>
    /// </summary>
    void SetItemTooltipEnabled(int idx, bool enable);
    /// <summary>
    /// <para>Sorts items in the list by their text.</para>
    /// </summary>
    void SortItemsByText();
    /// <summary>
    /// <para>Sets the clipping behavior when the text exceeds an item's bounding rectangle. See <see cref="TextServer.OverrunBehavior" /> for a description of all modes.</para>
    /// </summary>
    TextServer.OverrunBehavior TextOverrunBehavior { get; set; }

}