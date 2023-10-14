namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para><see cref="PopupMenu" /> is a modal window used to display a list of options. Useful for toolbars and context menus.</para>
/// <para>The size of a <see cref="PopupMenu" /> can be limited by using <see cref="Window.MaxSize" />. If the height of the list of items is larger than the maximum height of the <see cref="PopupMenu" />, a <see cref="ScrollContainer" /> within the popup will allow the user to scroll the contents. If no maximum size is set, or if it is set to <c>0</c>, the <see cref="PopupMenu" /> height will be limited by its parent rect.</para>
/// <para>All <c>set_*</c> methods allow negative item indices, i.e. <c>-1</c> to access the last item, <c>-2</c> to select the second-to-last item, and so on.</para>
/// <para><b>Incremental search:</b> Like <see cref="ItemList" /> and <see cref="Tree" />, <see cref="PopupMenu" /> supports searching within the list while the control is focused. Press a key that matches the first letter of an item's name to select the first item starting with the given letter. After that point, there are two ways to perform incremental search: 1) Press the same key again before the timeout duration to select the next item starting with the same letter. 2) Press letter keys that match the rest of the word before the timeout duration to match to select the item in question directly. Both of these actions will be reset to the beginning of the list if the timeout duration has passed since the last keystroke was registered. You can adjust the timeout duration by changing <c>ProjectSettings.gui/timers/incremental_search_max_interval_msec</c>.</para>
/// <para><b>Note:</b> The ID values used for items are limited to 32 bits, not full 64 bits of <see cref="T:System.Int32" />. This has a range of <c>-2^32</c> to <c>2^32 - 1</c>, i.e. <c>-2147483648</c> to <c>2147483647</c>.</para>
/// </summary>
public class PopupMenuAdapter : PopupMenu, IPopupMenu {
  private readonly PopupMenu _node;

  public PopupMenuAdapter(PopupMenu node) => _node = node;
    /// <summary>
    /// <para>Checks the provided <paramref name="event" /> against the <see cref="PopupMenu" />'s shortcuts and accelerators, and activates the first item with matching events. If <paramref name="forGlobalOnly" /> is <c>true</c>, only shortcuts and accelerators with <c>global</c> set to <c>true</c> will be called.</para>
    /// <para>Returns <c>true</c> if an item was successfully activated.</para>
    /// <para><b>Note:</b> Certain <see cref="Control" />s, such as <see cref="MenuButton" />, will call this method automatically.</para>
    /// </summary>
    public bool ActivateItemByEvent(InputEvent @event, bool forGlobalOnly) => _node.ActivateItemByEvent(@event, forGlobalOnly);
    /// <summary>
    /// <para>Adds a new checkable item with text <paramref name="label" />.</para>
    /// <para>An <paramref name="id" /> can optionally be provided, as well as an accelerator (<paramref name="accel" />). If no <paramref name="id" /> is provided, one will be created from the index. If no <paramref name="accel" /> is provided, then the default value of 0 (corresponding to <see cref="Key.None" />) will be assigned to the item (which means it won't have any accelerator). See <see cref="PopupMenu.GetItemAccelerator(System.Int32)" /> for more info on accelerators.</para>
    /// <para><b>Note:</b> Checkable items just display a checkmark, but don't have any built-in checking behavior and must be checked/unchecked manually. See <see cref="PopupMenu.SetItemChecked(System.Int32,System.Boolean)" /> for more info on how to control it.</para>
    /// </summary>
    public void AddCheckItem(string label, int id, Key accel) => _node.AddCheckItem(label, id, accel);
    /// <summary>
    /// <para>Adds a new checkable item and assigns the specified <see cref="Shortcut" /> to it. Sets the label of the checkbox to the <see cref="Shortcut" />'s name.</para>
    /// <para>An <paramref name="id" /> can optionally be provided. If no <paramref name="id" /> is provided, one will be created from the index.</para>
    /// <para><b>Note:</b> Checkable items just display a checkmark, but don't have any built-in checking behavior and must be checked/unchecked manually. See <see cref="PopupMenu.SetItemChecked(System.Int32,System.Boolean)" /> for more info on how to control it.</para>
    /// </summary>
    public void AddCheckShortcut(Shortcut shortcut, int id, bool @global) => _node.AddCheckShortcut(shortcut, id, @global);
    /// <summary>
    /// <para>Adds a new checkable item with text <paramref name="label" /> and icon <paramref name="texture" />.</para>
    /// <para>An <paramref name="id" /> can optionally be provided, as well as an accelerator (<paramref name="accel" />). If no <paramref name="id" /> is provided, one will be created from the index. If no <paramref name="accel" /> is provided, then the default value of 0 (corresponding to <see cref="Key.None" />) will be assigned to the item (which means it won't have any accelerator). See <see cref="PopupMenu.GetItemAccelerator(System.Int32)" /> for more info on accelerators.</para>
    /// <para><b>Note:</b> Checkable items just display a checkmark, but don't have any built-in checking behavior and must be checked/unchecked manually. See <see cref="PopupMenu.SetItemChecked(System.Int32,System.Boolean)" /> for more info on how to control it.</para>
    /// </summary>
    public void AddIconCheckItem(Texture2D texture, string label, int id, Key accel) => _node.AddIconCheckItem(texture, label, id, accel);
    /// <summary>
    /// <para>Adds a new checkable item and assigns the specified <see cref="Shortcut" /> and icon <paramref name="texture" /> to it. Sets the label of the checkbox to the <see cref="Shortcut" />'s name.</para>
    /// <para>An <paramref name="id" /> can optionally be provided. If no <paramref name="id" /> is provided, one will be created from the index.</para>
    /// <para><b>Note:</b> Checkable items just display a checkmark, but don't have any built-in checking behavior and must be checked/unchecked manually. See <see cref="PopupMenu.SetItemChecked(System.Int32,System.Boolean)" /> for more info on how to control it.</para>
    /// </summary>
    public void AddIconCheckShortcut(Texture2D texture, Shortcut shortcut, int id, bool @global) => _node.AddIconCheckShortcut(texture, shortcut, id, @global);
    /// <summary>
    /// <para>Adds a new item with text <paramref name="label" /> and icon <paramref name="texture" />.</para>
    /// <para>An <paramref name="id" /> can optionally be provided, as well as an accelerator (<paramref name="accel" />). If no <paramref name="id" /> is provided, one will be created from the index. If no <paramref name="accel" /> is provided, then the default value of 0 (corresponding to <see cref="Key.None" />) will be assigned to the item (which means it won't have any accelerator). See <see cref="PopupMenu.GetItemAccelerator(System.Int32)" /> for more info on accelerators.</para>
    /// </summary>
    public void AddIconItem(Texture2D texture, string label, int id, Key accel) => _node.AddIconItem(texture, label, id, accel);
    /// <summary>
    /// <para>Same as <see cref="PopupMenu.AddIconCheckItem(Godot.Texture2D,System.String,System.Int32,Godot.Key)" />, but uses a radio check button.</para>
    /// </summary>
    public void AddIconRadioCheckItem(Texture2D texture, string label, int id, Key accel) => _node.AddIconRadioCheckItem(texture, label, id, accel);
    /// <summary>
    /// <para>Same as <see cref="PopupMenu.AddIconCheckShortcut(Godot.Texture2D,Godot.Shortcut,System.Int32,System.Boolean)" />, but uses a radio check button.</para>
    /// </summary>
    public void AddIconRadioCheckShortcut(Texture2D texture, Shortcut shortcut, int id, bool @global) => _node.AddIconRadioCheckShortcut(texture, shortcut, id, @global);
    /// <summary>
    /// <para>Adds a new item and assigns the specified <see cref="Shortcut" /> and icon <paramref name="texture" /> to it. Sets the label of the checkbox to the <see cref="Shortcut" />'s name.</para>
    /// <para>An <paramref name="id" /> can optionally be provided. If no <paramref name="id" /> is provided, one will be created from the index.</para>
    /// <para>If <paramref name="allowEcho" /> is <c>true</c>, the shortcut can be activated with echo events.</para>
    /// </summary>
    public void AddIconShortcut(Texture2D texture, Shortcut shortcut, int id, bool @global, bool allowEcho) => _node.AddIconShortcut(texture, shortcut, id, @global, allowEcho);
    /// <summary>
    /// <para>Adds a new item and assigns the specified <see cref="Shortcut" /> and icon <paramref name="texture" /> to it. Sets the label of the checkbox to the <see cref="Shortcut" />'s name.</para>
    /// <para>An <paramref name="id" /> can optionally be provided. If no <paramref name="id" /> is provided, one will be created from the index.</para>
    /// <para>If <paramref name="allowEcho" /> is <c>true</c>, the shortcut can be activated with echo events.</para>
    /// </summary>
    public void AddIconShortcut(Texture2D texture, Shortcut shortcut, int id, bool @global) => _node.AddIconShortcut(texture, shortcut, id, @global);
    /// <summary>
    /// <para>Adds a new item with text <paramref name="label" />.</para>
    /// <para>An <paramref name="id" /> can optionally be provided, as well as an accelerator (<paramref name="accel" />). If no <paramref name="id" /> is provided, one will be created from the index. If no <paramref name="accel" /> is provided, then the default value of 0 (corresponding to <see cref="Key.None" />) will be assigned to the item (which means it won't have any accelerator). See <see cref="PopupMenu.GetItemAccelerator(System.Int32)" /> for more info on accelerators.</para>
    /// <para><b>Note:</b> The provided <paramref name="id" /> is used only in <see cref="PopupMenu.IdPressed" /> and <see cref="PopupMenu.IdFocused" /> signals. It's not related to the <c>index</c> arguments in e.g. <see cref="PopupMenu.SetItemChecked(System.Int32,System.Boolean)" />.</para>
    /// </summary>
    public void AddItem(string label, int id, Key accel) => _node.AddItem(label, id, accel);
    /// <summary>
    /// <para>Adds a new multistate item with text <paramref name="label" />.</para>
    /// <para>Contrarily to normal binary items, multistate items can have more than two states, as defined by <paramref name="maxStates" />. Each press or activate of the item will increase the state by one. The default value is defined by <paramref name="defaultState" />.</para>
    /// <para>An <paramref name="id" /> can optionally be provided, as well as an accelerator (<paramref name="accel" />). If no <paramref name="id" /> is provided, one will be created from the index. If no <paramref name="accel" /> is provided, then the default value of 0 (corresponding to <see cref="Key.None" />) will be assigned to the item (which means it won't have any accelerator). See <see cref="PopupMenu.GetItemAccelerator(System.Int32)" /> for more info on accelerators.</para>
    /// </summary>
    public void AddMultistateItem(string label, int maxStates, int defaultState, int id, Key accel) => _node.AddMultistateItem(label, maxStates, defaultState, id, accel);
    /// <summary>
    /// <para>Adds a new radio check button with text <paramref name="label" />.</para>
    /// <para>An <paramref name="id" /> can optionally be provided, as well as an accelerator (<paramref name="accel" />). If no <paramref name="id" /> is provided, one will be created from the index. If no <paramref name="accel" /> is provided, then the default value of 0 (corresponding to <see cref="Key.None" />) will be assigned to the item (which means it won't have any accelerator). See <see cref="PopupMenu.GetItemAccelerator(System.Int32)" /> for more info on accelerators.</para>
    /// <para><b>Note:</b> Checkable items just display a checkmark, but don't have any built-in checking behavior and must be checked/unchecked manually. See <see cref="PopupMenu.SetItemChecked(System.Int32,System.Boolean)" /> for more info on how to control it.</para>
    /// </summary>
    public void AddRadioCheckItem(string label, int id, Key accel) => _node.AddRadioCheckItem(label, id, accel);
    /// <summary>
    /// <para>Adds a new radio check button and assigns a <see cref="Shortcut" /> to it. Sets the label of the checkbox to the <see cref="Shortcut" />'s name.</para>
    /// <para>An <paramref name="id" /> can optionally be provided. If no <paramref name="id" /> is provided, one will be created from the index.</para>
    /// <para><b>Note:</b> Checkable items just display a checkmark, but don't have any built-in checking behavior and must be checked/unchecked manually. See <see cref="PopupMenu.SetItemChecked(System.Int32,System.Boolean)" /> for more info on how to control it.</para>
    /// </summary>
    public void AddRadioCheckShortcut(Shortcut shortcut, int id, bool @global) => _node.AddRadioCheckShortcut(shortcut, id, @global);
    /// <summary>
    /// <para>Adds a separator between items. Separators also occupy an index, which you can set by using the <paramref name="id" /> parameter.</para>
    /// <para>A <paramref name="label" /> can optionally be provided, which will appear at the center of the separator.</para>
    /// </summary>
    public void AddSeparator(string label, int id) => _node.AddSeparator(label, id);
    /// <summary>
    /// <para>Adds a <see cref="Shortcut" />.</para>
    /// <para>An <paramref name="id" /> can optionally be provided. If no <paramref name="id" /> is provided, one will be created from the index.</para>
    /// <para>If <paramref name="allowEcho" /> is <c>true</c>, the shortcut can be activated with echo events.</para>
    /// </summary>
    public void AddShortcut(Shortcut shortcut, int id, bool @global, bool allowEcho) => _node.AddShortcut(shortcut, id, @global, allowEcho);
    /// <summary>
    /// <para>Adds a <see cref="Shortcut" />.</para>
    /// <para>An <paramref name="id" /> can optionally be provided. If no <paramref name="id" /> is provided, one will be created from the index.</para>
    /// <para>If <paramref name="allowEcho" /> is <c>true</c>, the shortcut can be activated with echo events.</para>
    /// </summary>
    public void AddShortcut(Shortcut shortcut, int id, bool @global) => _node.AddShortcut(shortcut, id, @global);
    /// <summary>
    /// <para>Adds an item that will act as a submenu of the parent <see cref="PopupMenu" /> node when clicked. The <paramref name="submenu" /> argument is the name of the child <see cref="PopupMenu" /> node that will be shown when the item is clicked.</para>
    /// <para>An <paramref name="id" /> can optionally be provided. If no <paramref name="id" /> is provided, one will be created from the index.</para>
    /// </summary>
    public void AddSubmenuItem(string label, string submenu, int id) => _node.AddSubmenuItem(label, submenu, id);
    /// <summary>
    /// <para>If <c>true</c>, allows navigating <see cref="PopupMenu" /> with letter keys.</para>
    /// </summary>
    public bool AllowSearch { get => _node.AllowSearch; set => _node.AllowSearch = value; }
    /// <summary>
    /// <para>Removes all items from the <see cref="PopupMenu" />. If <paramref name="freeSubmenus" /> is <c>true</c>, the submenu nodes are automatically freed.</para>
    /// </summary>
    public void Clear(bool freeSubmenus) => _node.Clear(freeSubmenus);
    /// <summary>
    /// <para>Removes all items from the <see cref="PopupMenu" />. If <paramref name="freeSubmenus" /> is <c>true</c>, the submenu nodes are automatically freed.</para>
    /// </summary>
    public void Clear() => _node.Clear();
    /// <summary>
    /// <para>Returns the index of the currently focused item. Returns <c>-1</c> if no item is focused.</para>
    /// </summary>
    public int GetFocusedItem() => _node.GetFocusedItem();
    /// <summary>
    /// <para>Returns the accelerator of the item at the given <paramref name="index" />. An accelerator is a keyboard shortcut that can be pressed to trigger the menu button even if it's not currently open. The return value is an integer which is generally a combination of <see cref="KeyModifierMask" />s and <see cref="Key" />s using bitwise OR such as <c>KEY_MASK_CTRL | KEY_A</c> (Ctrl + A). If no accelerator is defined for the specified <paramref name="index" />, <see cref="PopupMenu.GetItemAccelerator(System.Int32)" /> returns <c>0</c> (corresponding to <see cref="Key.None" />).</para>
    /// </summary>
    public Key GetItemAccelerator(int index) => _node.GetItemAccelerator(index);
    /// <summary>
    /// <para>Returns the icon of the item at the given <paramref name="index" />.</para>
    /// </summary>
    public Texture2D GetItemIcon(int index) => _node.GetItemIcon(index);
    /// <summary>
    /// <para>Returns the maximum allowed width of the icon for the item at the given <paramref name="index" />.</para>
    /// </summary>
    public int GetItemIconMaxWidth(int index) => _node.GetItemIconMaxWidth(index);
    /// <summary>
    /// <para>Returns a <see cref="Color" /> modulating the item's icon at the given <paramref name="index" />.</para>
    /// </summary>
    public Color GetItemIconModulate(int index) => _node.GetItemIconModulate(index);
    /// <summary>
    /// <para>Returns the ID of the item at the given <paramref name="index" />. <c>id</c> can be manually assigned, while index can not.</para>
    /// </summary>
    public int GetItemId(int index) => _node.GetItemId(index);
    /// <summary>
    /// <para>Returns the horizontal offset of the item at the given <paramref name="index" />.</para>
    /// </summary>
    public int GetItemIndent(int index) => _node.GetItemIndent(index);
    /// <summary>
    /// <para>Returns the index of the item containing the specified <paramref name="id" />. Index is automatically assigned to each item by the engine and can not be set manually.</para>
    /// </summary>
    public int GetItemIndex(int id) => _node.GetItemIndex(id);
    /// <summary>
    /// <para>Returns item's text language code.</para>
    /// </summary>
    public string GetItemLanguage(int index) => _node.GetItemLanguage(index);
    /// <summary>
    /// <para>Returns the metadata of the specified item, which might be of any type. You can set it with <see cref="PopupMenu.SetItemMetadata(System.Int32,Godot.Variant)" />, which provides a simple way of assigning context data to items.</para>
    /// </summary>
    public Variant GetItemMetadata(int index) => _node.GetItemMetadata(index);
    /// <summary>
    /// <para>Returns the <see cref="Shortcut" /> associated with the item at the given <paramref name="index" />.</para>
    /// </summary>
    public Shortcut GetItemShortcut(int index) => _node.GetItemShortcut(index);
    /// <summary>
    /// <para>Returns the submenu name of the item at the given <paramref name="index" />. See <see cref="PopupMenu.AddSubmenuItem(System.String,System.String,System.Int32)" /> for more info on how to add a submenu.</para>
    /// </summary>
    public string GetItemSubmenu(int index) => _node.GetItemSubmenu(index);
    /// <summary>
    /// <para>Returns the text of the item at the given <paramref name="index" />.</para>
    /// </summary>
    public string GetItemText(int index) => _node.GetItemText(index);
    /// <summary>
    /// <para>Returns item's text base writing direction.</para>
    /// </summary>
    public Control.TextDirection GetItemTextDirection(int index) => _node.GetItemTextDirection(index);
    /// <summary>
    /// <para>Returns the tooltip associated with the item at the given <paramref name="index" />.</para>
    /// </summary>
    public string GetItemTooltip(int index) => _node.GetItemTooltip(index);
    /// <summary>
    /// <para>If <c>true</c>, hides the <see cref="PopupMenu" /> when a checkbox or radio button is selected.</para>
    /// </summary>
    public bool HideOnCheckableItemSelection { get => _node.HideOnCheckableItemSelection; set => _node.HideOnCheckableItemSelection = value; }
    /// <summary>
    /// <para>If <c>true</c>, hides the <see cref="PopupMenu" /> when an item is selected.</para>
    /// </summary>
    public bool HideOnItemSelection { get => _node.HideOnItemSelection; set => _node.HideOnItemSelection = value; }
    /// <summary>
    /// <para>If <c>true</c>, hides the <see cref="PopupMenu" /> when a state item is selected.</para>
    /// </summary>
    public bool HideOnStateItemSelection { get => _node.HideOnStateItemSelection; set => _node.HideOnStateItemSelection = value; }
    /// <summary>
    /// <para>Returns <c>true</c> if the item at the given <paramref name="index" /> is checkable in some way, i.e. if it has a checkbox or radio button.</para>
    /// <para><b>Note:</b> Checkable items just display a checkmark or radio button, but don't have any built-in checking behavior and must be checked/unchecked manually.</para>
    /// </summary>
    public bool IsItemCheckable(int index) => _node.IsItemCheckable(index);
    /// <summary>
    /// <para>Returns <c>true</c> if the item at the given <paramref name="index" /> is checked.</para>
    /// </summary>
    public bool IsItemChecked(int index) => _node.IsItemChecked(index);
    /// <summary>
    /// <para>Returns <c>true</c> if the item at the given <paramref name="index" /> is disabled. When it is disabled it can't be selected, or its action invoked.</para>
    /// <para>See <see cref="PopupMenu.SetItemDisabled(System.Int32,System.Boolean)" /> for more info on how to disable an item.</para>
    /// </summary>
    public bool IsItemDisabled(int index) => _node.IsItemDisabled(index);
    /// <summary>
    /// <para>Returns <c>true</c> if the item at the given <paramref name="index" /> has radio button-style checkability.</para>
    /// <para><b>Note:</b> This is purely cosmetic; you must add the logic for checking/unchecking items in radio groups.</para>
    /// </summary>
    public bool IsItemRadioCheckable(int index) => _node.IsItemRadioCheckable(index);
    /// <summary>
    /// <para>Returns <c>true</c> if the item is a separator. If it is, it will be displayed as a line. See <see cref="PopupMenu.AddSeparator(System.String,System.Int32)" /> for more info on how to add a separator.</para>
    /// </summary>
    public bool IsItemSeparator(int index) => _node.IsItemSeparator(index);
    /// <summary>
    /// <para>Returns <c>true</c> if the specified item's shortcut is disabled.</para>
    /// </summary>
    public bool IsItemShortcutDisabled(int index) => _node.IsItemShortcutDisabled(index);
    /// <summary>
    /// <para>The number of items currently in the list.</para>
    /// </summary>
    public int ItemCount { get => _node.ItemCount; set => _node.ItemCount = value; }
    /// <summary>
    /// <para>Removes the item at the given <paramref name="index" /> from the menu.</para>
    /// <para><b>Note:</b> The indices of items after the removed item will be shifted by one.</para>
    /// </summary>
    public void RemoveItem(int index) => _node.RemoveItem(index);
    /// <summary>
    /// <para>Moves the scroll view to make the item at the given <paramref name="index" /> visible.</para>
    /// </summary>
    public void ScrollToItem(int index) => _node.ScrollToItem(index);
    /// <summary>
    /// <para>Sets the currently focused item as the given <paramref name="index" />.</para>
    /// <para>Passing <c>-1</c> as the index makes so that no item is focused.</para>
    /// </summary>
    public void SetFocusedItem(int index) => _node.SetFocusedItem(index);
    /// <summary>
    /// <para>Sets the accelerator of the item at the given <paramref name="index" />. An accelerator is a keyboard shortcut that can be pressed to trigger the menu button even if it's not currently open. <paramref name="accel" /> is generally a combination of <see cref="KeyModifierMask" />s and <see cref="Key" />s using bitwise OR such as <c>KEY_MASK_CTRL | KEY_A</c> (Ctrl + A).</para>
    /// </summary>
    public void SetItemAccelerator(int index, Key accel) => _node.SetItemAccelerator(index, accel);
    /// <summary>
    /// <para>Sets whether the item at the given <paramref name="index" /> has a checkbox. If <c>false</c>, sets the type of the item to plain text.</para>
    /// <para><b>Note:</b> Checkable items just display a checkmark, but don't have any built-in checking behavior and must be checked/unchecked manually.</para>
    /// </summary>
    public void SetItemAsCheckable(int index, bool enable) => _node.SetItemAsCheckable(index, enable);
    /// <summary>
    /// <para>Sets the type of the item at the given <paramref name="index" /> to radio button. If <c>false</c>, sets the type of the item to plain text.</para>
    /// </summary>
    public void SetItemAsRadioCheckable(int index, bool enable) => _node.SetItemAsRadioCheckable(index, enable);
    /// <summary>
    /// <para>Mark the item at the given <paramref name="index" /> as a separator, which means that it would be displayed as a line. If <c>false</c>, sets the type of the item to plain text.</para>
    /// </summary>
    public void SetItemAsSeparator(int index, bool enable) => _node.SetItemAsSeparator(index, enable);
    /// <summary>
    /// <para>Sets the checkstate status of the item at the given <paramref name="index" />.</para>
    /// </summary>
    public void SetItemChecked(int index, bool @checked) => _node.SetItemChecked(index, @checked);
    /// <summary>
    /// <para>Enables/disables the item at the given <paramref name="index" />. When it is disabled, it can't be selected and its action can't be invoked.</para>
    /// </summary>
    public void SetItemDisabled(int index, bool disabled) => _node.SetItemDisabled(index, disabled);
    /// <summary>
    /// <para>Replaces the <see cref="Texture2D" /> icon of the item at the given <paramref name="index" />.</para>
    /// </summary>
    public void SetItemIcon(int index, Texture2D icon) => _node.SetItemIcon(index, icon);
    /// <summary>
    /// <para>Sets the maximum allowed width of the icon for the item at the given <paramref name="index" />. This limit is applied on top of the default size of the icon and on top of <c>icon_max_width</c>. The height is adjusted according to the icon's ratio.</para>
    /// </summary>
    public void SetItemIconMaxWidth(int index, int width) => _node.SetItemIconMaxWidth(index, width);
    /// <summary>
    /// <para>Sets a modulating <see cref="Color" /> of the item's icon at the given <paramref name="index" />.</para>
    /// </summary>
    public void SetItemIconModulate(int index, Color modulate) => _node.SetItemIconModulate(index, modulate);
    /// <summary>
    /// <para>Sets the <paramref name="id" /> of the item at the given <paramref name="index" />.</para>
    /// <para>The <paramref name="id" /> is used in <see cref="PopupMenu.IdPressed" /> and <see cref="PopupMenu.IdFocused" /> signals.</para>
    /// </summary>
    public void SetItemId(int index, int id) => _node.SetItemId(index, id);
    /// <summary>
    /// <para>Sets the horizontal offset of the item at the given <paramref name="index" />.</para>
    /// </summary>
    public void SetItemIndent(int index, int indent) => _node.SetItemIndent(index, indent);
    /// <summary>
    /// <para>Sets language code of item's text used for line-breaking and text shaping algorithms, if left empty current locale is used instead.</para>
    /// </summary>
    public void SetItemLanguage(int index, string language) => _node.SetItemLanguage(index, language);
    /// <summary>
    /// <para>Sets the metadata of an item, which may be of any type. You can later get it with <see cref="PopupMenu.GetItemMetadata(System.Int32)" />, which provides a simple way of assigning context data to items.</para>
    /// </summary>
    public void SetItemMetadata(int index, Variant metadata) => _node.SetItemMetadata(index, metadata);
    /// <summary>
    /// <para>Sets the state of a multistate item. See <see cref="PopupMenu.AddMultistateItem(System.String,System.Int32,System.Int32,System.Int32,Godot.Key)" /> for details.</para>
    /// </summary>
    public void SetItemMultistate(int index, int state) => _node.SetItemMultistate(index, state);
    /// <summary>
    /// <para>Sets a <see cref="Shortcut" /> for the item at the given <paramref name="index" />.</para>
    /// </summary>
    public void SetItemShortcut(int index, Shortcut shortcut, bool @global) => _node.SetItemShortcut(index, shortcut, @global);
    /// <summary>
    /// <para>Disables the <see cref="Shortcut" /> of the item at the given <paramref name="index" />.</para>
    /// </summary>
    public void SetItemShortcutDisabled(int index, bool disabled) => _node.SetItemShortcutDisabled(index, disabled);
    /// <summary>
    /// <para>Sets the submenu of the item at the given <paramref name="index" />. The submenu is the name of a child <see cref="PopupMenu" /> node that would be shown when the item is clicked.</para>
    /// </summary>
    public void SetItemSubmenu(int index, string submenu) => _node.SetItemSubmenu(index, submenu);
    /// <summary>
    /// <para>Sets the text of the item at the given <paramref name="index" />.</para>
    /// </summary>
    public void SetItemText(int index, string text) => _node.SetItemText(index, text);
    /// <summary>
    /// <para>Sets item's text base writing direction.</para>
    /// </summary>
    public void SetItemTextDirection(int index, Control.TextDirection direction) => _node.SetItemTextDirection(index, direction);
    /// <summary>
    /// <para>Sets the <see cref="T:System.String" /> tooltip of the item at the given <paramref name="index" />.</para>
    /// </summary>
    public void SetItemTooltip(int index, string tooltip) => _node.SetItemTooltip(index, tooltip);
    /// <summary>
    /// <para>Sets the delay time in seconds for the submenu item to popup on mouse hovering. If the popup menu is added as a child of another (acting as a submenu), it will inherit the delay time of the parent menu item.</para>
    /// </summary>
    public float SubmenuPopupDelay { get => _node.SubmenuPopupDelay; set => _node.SubmenuPopupDelay = value; }
    /// <summary>
    /// <para>Toggles the check state of the item at the given <paramref name="index" />.</para>
    /// </summary>
    public void ToggleItemChecked(int index) => _node.ToggleItemChecked(index);
    /// <summary>
    /// <para>Cycle to the next state of a multistate item. See <see cref="PopupMenu.AddMultistateItem(System.String,System.Int32,System.Int32,System.Int32,Godot.Key)" /> for details.</para>
    /// </summary>
    public void ToggleItemMultistate(int index) => _node.ToggleItemMultistate(index);

}