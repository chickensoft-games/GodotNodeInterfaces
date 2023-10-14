namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para><see cref="OptionButton" /> is a type of button that brings up a dropdown with selectable items when pressed. The item selected becomes the "current" item and is displayed as the button text.</para>
/// <para>See also <see cref="BaseButton" /> which contains common properties and methods associated with this node.</para>
/// <para><b>Note:</b> The ID values used for items are limited to 32 bits, not full 64 bits of <see cref="T:System.Int32" />. This has a range of <c>-2^32</c> to <c>2^32 - 1</c>, i.e. <c>-2147483648</c> to <c>2147483647</c>.</para>
/// <para><b>Note:</b> The <see cref="Button.Text" /> and <see cref="Button.Icon" /> properties are set automatically based on the selected item. They shouldn't be changed manually.</para>
/// </summary>
public interface IOptionButton : IButton {
    /// <summary>
    /// <para>Adds an item, with text <paramref name="label" /> and (optionally) <paramref name="id" />. If no <paramref name="id" /> is passed, the item index will be used as the item's ID. New items are appended at the end.</para>
    /// </summary>
    void AddItem(string label, int id);
    /// <summary>
    /// <para>Adds an item, with a <paramref name="texture" /> icon, text <paramref name="label" /> and (optionally) <paramref name="id" />. If no <paramref name="id" /> is passed, the item index will be used as the item's ID. New items are appended at the end.</para>
    /// </summary>
    void AddIconItem(Texture2D texture, string label, int id);
    /// <summary>
    /// <para>Sets the text of the item at index <paramref name="idx" />.</para>
    /// </summary>
    void SetItemText(int idx, string text);
    /// <summary>
    /// <para>Sets the icon of the item at index <paramref name="idx" />.</para>
    /// </summary>
    void SetItemIcon(int idx, Texture2D texture);
    /// <summary>
    /// <para>Sets whether the item at index <paramref name="idx" /> is disabled.</para>
    /// <para>Disabled items are drawn differently in the dropdown and are not selectable by the user. If the current selected item is set as disabled, it will remain selected.</para>
    /// </summary>
    void SetItemDisabled(int idx, bool disabled);
    /// <summary>
    /// <para>Sets the ID of the item at index <paramref name="idx" />.</para>
    /// </summary>
    void SetItemId(int idx, int id);
    /// <summary>
    /// <para>Sets the metadata of an item. Metadata may be of any type and can be used to store extra information about an item, such as an external string ID.</para>
    /// </summary>
    void SetItemMetadata(int idx, Variant metadata);
    /// <summary>
    /// <para>Sets the tooltip of the item at index <paramref name="idx" />.</para>
    /// </summary>
    void SetItemTooltip(int idx, string tooltip);
    /// <summary>
    /// <para>Returns the text of the item at index <paramref name="idx" />.</para>
    /// </summary>
    string GetItemText(int idx);
    /// <summary>
    /// <para>Returns the icon of the item at index <paramref name="idx" />.</para>
    /// </summary>
    Texture2D GetItemIcon(int idx);
    /// <summary>
    /// <para>Returns the ID of the item at index <paramref name="idx" />.</para>
    /// </summary>
    int GetItemId(int idx);
    /// <summary>
    /// <para>Returns the index of the item with the given <paramref name="id" />.</para>
    /// </summary>
    int GetItemIndex(int id);
    /// <summary>
    /// <para>Retrieves the metadata of an item. Metadata may be any type and can be used to store extra information about an item, such as an external string ID.</para>
    /// </summary>
    Variant GetItemMetadata(int idx);
    /// <summary>
    /// <para>Returns the tooltip of the item at index <paramref name="idx" />.</para>
    /// </summary>
    string GetItemTooltip(int idx);
    /// <summary>
    /// <para>Returns <c>true</c> if the item at index <paramref name="idx" /> is disabled.</para>
    /// </summary>
    bool IsItemDisabled(int idx);
    /// <summary>
    /// <para>Returns <c>true</c> if the item at index <paramref name="idx" /> is marked as a separator.</para>
    /// </summary>
    bool IsItemSeparator(int idx);
    /// <summary>
    /// <para>Adds a separator to the list of items. Separators help to group items, and can optionally be given a <paramref name="text" /> header. A separator also gets an index assigned, and is appended at the end of the item list.</para>
    /// </summary>
    void AddSeparator(string text);
    /// <summary>
    /// <para>Clears all the items in the <see cref="OptionButton" />.</para>
    /// </summary>
    void Clear();
    /// <summary>
    /// <para>Selects an item by index and makes it the current item. This will work even if the item is disabled.</para>
    /// <para>Passing <c>-1</c> as the index deselects any currently selected item.</para>
    /// </summary>
    void Select(int idx);
    /// <summary>
    /// <para>Returns the ID of the selected item, or <c>-1</c> if no item is selected.</para>
    /// </summary>
    int GetSelectedId();
    /// <summary>
    /// <para>Gets the metadata of the selected item. Metadata for items can be set using <see cref="M:Godot.OptionButton.SetItemMetadata(System.Int32,Godot.Variant)" />.</para>
    /// </summary>
    Variant GetSelectedMetadata();
    /// <summary>
    /// <para>Removes the item at index <paramref name="idx" />.</para>
    /// </summary>
    void RemoveItem(int idx);
    /// <summary>
    /// <para>Returns the <see cref="PopupMenu" /> contained in this button.</para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash. If you wish to hide it or any of its children, use their <see cref="Window.Visible" /> property.</para>
    /// </summary>
    PopupMenu GetPopup();
    /// <summary>
    /// <para>Adjusts popup position and sizing for the <see cref="OptionButton" />, then shows the <see cref="PopupMenu" />. Prefer this over using <c>get_popup().popup()</c>.</para>
    /// </summary>
    void ShowPopup();
    /// <summary>
    /// <para>Returns <c>true</c> if this button contains at least one item which is not disabled, or marked as a separator.</para>
    /// </summary>
    bool HasSelectableItems();
    /// <summary>
    /// <para>Returns the index of the first item which is not disabled, or marked as a separator. If <paramref name="fromLast" /> is <c>true</c>, the items will be searched in reverse order.</para>
    /// <para>Returns <c>-1</c> if no item is found.</para>
    /// </summary>
    int GetSelectableItem(bool fromLast);
    /// <summary>
    /// <para>If <c>true</c>, shortcuts are disabled and cannot be used to trigger the button.</para>
    /// </summary>
    void SetDisableShortcuts(bool disabled);
    /// <summary>
    /// <para>The number of items to select from.</para>
    /// </summary>
    int ItemCount { get; set; }
    /// <summary>
    /// <para>The index of the currently selected item, or <c>-1</c> if no item is selected.</para>
    /// </summary>
    int Selected { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, minimum size will be determined by the longest item's text, instead of the currently selected one's.</para>
    /// <para><b>Note:</b> For performance reasons, the minimum size doesn't update immediately when adding, removing or modifying items.</para>
    /// </summary>
    bool FitToLongestItem { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the currently selected item can be selected again.</para>
    /// </summary>
    bool AllowReselect { get; set; }

}