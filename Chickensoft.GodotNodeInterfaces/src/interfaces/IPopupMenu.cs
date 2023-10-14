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
public interface IPopupMenu : IPopup {
    /// <summary>
    /// <para>Checks the provided <paramref name="event" /> against the <see cref="PopupMenu" />'s shortcuts and accelerators, and activates the first item with matching events. If <paramref name="forGlobalOnly" /> is <c>true</c>, only shortcuts and accelerators with <c>global</c> set to <c>true</c> will be called.</para>
    /// <para>Returns <c>true</c> if an item was successfully activated.</para>
    /// <para><b>Note:</b> Certain <see cref="Control" />s, such as <see cref="MenuButton" />, will call this method automatically.</para>
    /// </summary>
    bool ActivateItemByEvent(InputEvent @event, bool forGlobalOnly);
    /// <summary>
    /// <para>Adds a new item with text <paramref name="label" />.</para>
    /// <para>An <paramref name="id" /> can optionally be provided, as well as an accelerator (<paramref name="accel" />). If no <paramref name="id" /> is provided, one will be created from the index. If no <paramref name="accel" /> is provided, then the default value of 0 (corresponding to <see cref="Key.None" />) will be assigned to the item (which means it won't have any accelerator). See <see cref="M:Godot.PopupMenu.GetItemAccelerator(System.Int32)" /> for more info on accelerators.</para>
    /// <para><b>Note:</b> The provided <paramref name="id" /> is used only in <see cref="PopupMenu.IdPressed" /> and <see cref="PopupMenu.IdFocused" /> signals. It's not related to the <c>index</c> arguments in e.g. <see cref="M:Godot.PopupMenu.SetItemChecked(System.Int32,System.Boolean)" />.</para>
    /// </summary>
    void AddItem(string label, int id, Key accel);
    /// <summary>
    /// <para>Adds a new item with text <paramref name="label" /> and icon <paramref name="texture" />.</para>
    /// <para>An <paramref name="id" /> can optionally be provided, as well as an accelerator (<paramref name="accel" />). If no <paramref name="id" /> is provided, one will be created from the index. If no <paramref name="accel" /> is provided, then the default value of 0 (corresponding to <see cref="Key.None" />) will be assigned to the item (which means it won't have any accelerator). See <see cref="M:Godot.PopupMenu.GetItemAccelerator(System.Int32)" /> for more info on accelerators.</para>
    /// </summary>
    void AddIconItem(Texture2D texture, string label, int id, Key accel);
    /// <summary>
    /// <para>Adds a new checkable item with text <paramref name="label" />.</para>
    /// <para>An <paramref name="id" /> can optionally be provided, as well as an accelerator (<paramref name="accel" />). If no <paramref name="id" /> is provided, one will be created from the index. If no <paramref name="accel" /> is provided, then the default value of 0 (corresponding to <see cref="Key.None" />) will be assigned to the item (which means it won't have any accelerator). See <see cref="M:Godot.PopupMenu.GetItemAccelerator(System.Int32)" /> for more info on accelerators.</para>
    /// <para><b>Note:</b> Checkable items just display a checkmark, but don't have any built-in checking behavior and must be checked/unchecked manually. See <see cref="M:Godot.PopupMenu.SetItemChecked(System.Int32,System.Boolean)" /> for more info on how to control it.</para>
    /// </summary>
    void AddCheckItem(string label, int id, Key accel);
    /// <summary>
    /// <para>Adds a new checkable item with text <paramref name="label" /> and icon <paramref name="texture" />.</para>
    /// <para>An <paramref name="id" /> can optionally be provided, as well as an accelerator (<paramref name="accel" />). If no <paramref name="id" /> is provided, one will be created from the index. If no <paramref name="accel" /> is provided, then the default value of 0 (corresponding to <see cref="Key.None" />) will be assigned to the item (which means it won't have any accelerator). See <see cref="M:Godot.PopupMenu.GetItemAccelerator(System.Int32)" /> for more info on accelerators.</para>
    /// <para><b>Note:</b> Checkable items just display a checkmark, but don't have any built-in checking behavior and must be checked/unchecked manually. See <see cref="M:Godot.PopupMenu.SetItemChecked(System.Int32,System.Boolean)" /> for more info on how to control it.</para>
    /// </summary>
    void AddIconCheckItem(Texture2D texture, string label, int id, Key accel);
    /// <summary>
    /// <para>Adds a new radio check button with text <paramref name="label" />.</para>
    /// <para>An <paramref name="id" /> can optionally be provided, as well as an accelerator (<paramref name="accel" />). If no <paramref name="id" /> is provided, one will be created from the index. If no <paramref name="accel" /> is provided, then the default value of 0 (corresponding to <see cref="Key.None" />) will be assigned to the item (which means it won't have any accelerator). See <see cref="M:Godot.PopupMenu.GetItemAccelerator(System.Int32)" /> for more info on accelerators.</para>
    /// <para><b>Note:</b> Checkable items just display a checkmark, but don't have any built-in checking behavior and must be checked/unchecked manually. See <see cref="M:Godot.PopupMenu.SetItemChecked(System.Int32,System.Boolean)" /> for more info on how to control it.</para>
    /// </summary>
    void AddRadioCheckItem(string label, int id, Key accel);
    /// <summary>
    /// <para>Same as <see cref="M:Godot.PopupMenu.AddIconCheckItem(Godot.Texture2D,System.String,System.Int32,Godot.Key)" />, but uses a radio check button.</para>
    /// </summary>
    void AddIconRadioCheckItem(Texture2D texture, string label, int id, Key accel);
    /// <summary>
    /// <para>Adds a new multistate item with text <paramref name="label" />.</para>
    /// <para>Contrarily to normal binary items, multistate items can have more than two states, as defined by <paramref name="maxStates" />. Each press or activate of the item will increase the state by one. The default value is defined by <paramref name="defaultState" />.</para>
    /// <para>An <paramref name="id" /> can optionally be provided, as well as an accelerator (<paramref name="accel" />). If no <paramref name="id" /> is provided, one will be created from the index. If no <paramref name="accel" /> is provided, then the default value of 0 (corresponding to <see cref="Key.None" />) will be assigned to the item (which means it won't have any accelerator). See <see cref="M:Godot.PopupMenu.GetItemAccelerator(System.Int32)" /> for more info on accelerators.</para>
    /// </summary>
    void AddMultistateItem(string label, int maxStates, int defaultState, int id, Key accel);
    /// <summary>
    /// <para>Adds a <see cref="Shortcut" />.</para>
    /// <para>An <paramref name="id" /> can optionally be provided. If no <paramref name="id" /> is provided, one will be created from the index.</para>
    /// <para>If <paramref name="allowEcho" /> is <c>true</c>, the shortcut can be activated with echo events.</para>
    /// </summary>
    void AddShortcut(Shortcut shortcut, int id, bool @global, bool allowEcho);
    /// <summary>
    /// <para>Adds a new item and assigns the specified <see cref="Shortcut" /> and icon <paramref name="texture" /> to it. Sets the label of the checkbox to the <see cref="Shortcut" />'s name.</para>
    /// <para>An <paramref name="id" /> can optionally be provided. If no <paramref name="id" /> is provided, one will be created from the index.</para>
    /// <para>If <paramref name="allowEcho" /> is <c>true</c>, the shortcut can be activated with echo events.</para>
    /// </summary>
    void AddIconShortcut(Texture2D texture, Shortcut shortcut, int id, bool @global, bool allowEcho);
    /// <summary>
    /// <para>Adds a new checkable item and assigns the specified <see cref="Shortcut" /> to it. Sets the label of the checkbox to the <see cref="Shortcut" />'s name.</para>
    /// <para>An <paramref name="id" /> can optionally be provided. If no <paramref name="id" /> is provided, one will be created from the index.</para>
    /// <para><b>Note:</b> Checkable items just display a checkmark, but don't have any built-in checking behavior and must be checked/unchecked manually. See <see cref="M:Godot.PopupMenu.SetItemChecked(System.Int32,System.Boolean)" /> for more info on how to control it.</para>
    /// </summary>
    void AddCheckShortcut(Shortcut shortcut, int id, bool @global);
    /// <summary>
    /// <para>Adds a new checkable item and assigns the specified <see cref="Shortcut" /> and icon <paramref name="texture" /> to it. Sets the label of the checkbox to the <see cref="Shortcut" />'s name.</para>
    /// <para>An <paramref name="id" /> can optionally be provided. If no <paramref name="id" /> is provided, one will be created from the index.</para>
    /// <para><b>Note:</b> Checkable items just display a checkmark, but don't have any built-in checking behavior and must be checked/unchecked manually. See <see cref="M:Godot.PopupMenu.SetItemChecked(System.Int32,System.Boolean)" /> for more info on how to control it.</para>
    /// </summary>
    void AddIconCheckShortcut(Texture2D texture, Shortcut shortcut, int id, bool @global);
    /// <summary>
    /// <para>Adds a new radio check button and assigns a <see cref="Shortcut" /> to it. Sets the label of the checkbox to the <see cref="Shortcut" />'s name.</para>
    /// <para>An <paramref name="id" /> can optionally be provided. If no <paramref name="id" /> is provided, one will be created from the index.</para>
    /// <para><b>Note:</b> Checkable items just display a checkmark, but don't have any built-in checking behavior and must be checked/unchecked manually. See <see cref="M:Godot.PopupMenu.SetItemChecked(System.Int32,System.Boolean)" /> for more info on how to control it.</para>
    /// </summary>
    void AddRadioCheckShortcut(Shortcut shortcut, int id, bool @global);
    /// <summary>
    /// <para>Same as <see cref="M:Godot.PopupMenu.AddIconCheckShortcut(Godot.Texture2D,Godot.Shortcut,System.Int32,System.Boolean)" />, but uses a radio check button.</para>
    /// </summary>
    void AddIconRadioCheckShortcut(Texture2D texture, Shortcut shortcut, int id, bool @global);
    /// <summary>
    /// <para>Adds an item that will act as a submenu of the parent <see cref="PopupMenu" /> node when clicked. The <paramref name="submenu" /> argument is the name of the child <see cref="PopupMenu" /> node that will be shown when the item is clicked.</para>
    /// <para>An <paramref name="id" /> can optionally be provided. If no <paramref name="id" /> is provided, one will be created from the index.</para>
    /// </summary>
    void AddSubmenuItem(string label, string submenu, int id);
    /// <summary>
    /// <para>Sets the text of the item at the given <paramref name="index" />.</para>
    /// </summary>
    void SetItemText(int index, string text);
    /// <summary>
    /// <para>Sets item's text base writing direction.</para>
    /// </summary>
    void SetItemTextDirection(int index, Control.TextDirection direction);
    /// <summary>
    /// <para>Sets language code of item's text used for line-breaking and text shaping algorithms, if left empty current locale is used instead.</para>
    /// </summary>
    void SetItemLanguage(int index, string language);
    /// <summary>
    /// <para>Replaces the <see cref="Texture2D" /> icon of the item at the given <paramref name="index" />.</para>
    /// </summary>
    void SetItemIcon(int index, Texture2D icon);
    /// <summary>
    /// <para>Sets the maximum allowed width of the icon for the item at the given <paramref name="index" />. This limit is applied on top of the default size of the icon and on top of <c>icon_max_width</c>. The height is adjusted according to the icon's ratio.</para>
    /// </summary>
    void SetItemIconMaxWidth(int index, int width);
    /// <summary>
    /// <para>Sets a modulating <see cref="Color" /> of the item's icon at the given <paramref name="index" />.</para>
    /// </summary>
    void SetItemIconModulate(int index, Color modulate);
    /// <summary>
    /// <para>Sets the checkstate status of the item at the given <paramref name="index" />.</para>
    /// </summary>
    void SetItemChecked(int index, bool @checked);
    /// <summary>
    /// <para>Sets the <paramref name="id" /> of the item at the given <paramref name="index" />.</para>
    /// <para>The <paramref name="id" /> is used in <see cref="PopupMenu.IdPressed" /> and <see cref="PopupMenu.IdFocused" /> signals.</para>
    /// </summary>
    void SetItemId(int index, int id);
    /// <summary>
    /// <para>Sets the accelerator of the item at the given <paramref name="index" />. An accelerator is a keyboard shortcut that can be pressed to trigger the menu button even if it's not currently open. <paramref name="accel" /> is generally a combination of <see cref="KeyModifierMask" />s and <see cref="Key" />s using bitwise OR such as <c>KEY_MASK_CTRL | KEY_A</c> (Ctrl + A).</para>
    /// </summary>
    void SetItemAccelerator(int index, Key accel);
    /// <summary>
    /// <para>Sets the metadata of an item, which may be of any type. You can later get it with <see cref="M:Godot.PopupMenu.GetItemMetadata(System.Int32)" />, which provides a simple way of assigning context data to items.</para>
    /// </summary>
    void SetItemMetadata(int index, Variant metadata);
    /// <summary>
    /// <para>Enables/disables the item at the given <paramref name="index" />. When it is disabled, it can't be selected and its action can't be invoked.</para>
    /// </summary>
    void SetItemDisabled(int index, bool disabled);
    /// <summary>
    /// <para>Sets the submenu of the item at the given <paramref name="index" />. The submenu is the name of a child <see cref="PopupMenu" /> node that would be shown when the item is clicked.</para>
    /// </summary>
    void SetItemSubmenu(int index, string submenu);
    /// <summary>
    /// <para>Mark the item at the given <paramref name="index" /> as a separator, which means that it would be displayed as a line. If <c>false</c>, sets the type of the item to plain text.</para>
    /// </summary>
    void SetItemAsSeparator(int index, bool enable);
    /// <summary>
    /// <para>Sets whether the item at the given <paramref name="index" /> has a checkbox. If <c>false</c>, sets the type of the item to plain text.</para>
    /// <para><b>Note:</b> Checkable items just display a checkmark, but don't have any built-in checking behavior and must be checked/unchecked manually.</para>
    /// </summary>
    void SetItemAsCheckable(int index, bool enable);
    /// <summary>
    /// <para>Sets the type of the item at the given <paramref name="index" /> to radio button. If <c>false</c>, sets the type of the item to plain text.</para>
    /// </summary>
    void SetItemAsRadioCheckable(int index, bool enable);
    /// <summary>
    /// <para>Sets the <see cref="T:System.String" /> tooltip of the item at the given <paramref name="index" />.</para>
    /// </summary>
    void SetItemTooltip(int index, string tooltip);
    /// <summary>
    /// <para>Sets a <see cref="Shortcut" /> for the item at the given <paramref name="index" />.</para>
    /// </summary>
    void SetItemShortcut(int index, Shortcut shortcut, bool @global);
    /// <summary>
    /// <para>Sets the horizontal offset of the item at the given <paramref name="index" />.</para>
    /// </summary>
    void SetItemIndent(int index, int indent);
    /// <summary>
    /// <para>Sets the state of a multistate item. See <see cref="M:Godot.PopupMenu.AddMultistateItem(System.String,System.Int32,System.Int32,System.Int32,Godot.Key)" /> for details.</para>
    /// </summary>
    void SetItemMultistate(int index, int state);
    /// <summary>
    /// <para>Disables the <see cref="Shortcut" /> of the item at the given <paramref name="index" />.</para>
    /// </summary>
    void SetItemShortcutDisabled(int index, bool disabled);
    /// <summary>
    /// <para>Toggles the check state of the item at the given <paramref name="index" />.</para>
    /// </summary>
    void ToggleItemChecked(int index);
    /// <summary>
    /// <para>Cycle to the next state of a multistate item. See <see cref="M:Godot.PopupMenu.AddMultistateItem(System.String,System.Int32,System.Int32,System.Int32,Godot.Key)" /> for details.</para>
    /// </summary>
    void ToggleItemMultistate(int index);
    /// <summary>
    /// <para>Returns the text of the item at the given <paramref name="index" />.</para>
    /// </summary>
    string GetItemText(int index);
    /// <summary>
    /// <para>Returns item's text base writing direction.</para>
    /// </summary>
    Control.TextDirection GetItemTextDirection(int index);
    /// <summary>
    /// <para>Returns item's text language code.</para>
    /// </summary>
    string GetItemLanguage(int index);
    /// <summary>
    /// <para>Returns the icon of the item at the given <paramref name="index" />.</para>
    /// </summary>
    Texture2D GetItemIcon(int index);
    /// <summary>
    /// <para>Returns the maximum allowed width of the icon for the item at the given <paramref name="index" />.</para>
    /// </summary>
    int GetItemIconMaxWidth(int index);
    /// <summary>
    /// <para>Returns a <see cref="Color" /> modulating the item's icon at the given <paramref name="index" />.</para>
    /// </summary>
    Color GetItemIconModulate(int index);
    /// <summary>
    /// <para>Returns <c>true</c> if the item at the given <paramref name="index" /> is checked.</para>
    /// </summary>
    bool IsItemChecked(int index);
    /// <summary>
    /// <para>Returns the ID of the item at the given <paramref name="index" />. <c>id</c> can be manually assigned, while index can not.</para>
    /// </summary>
    int GetItemId(int index);
    /// <summary>
    /// <para>Returns the index of the item containing the specified <paramref name="id" />. Index is automatically assigned to each item by the engine and can not be set manually.</para>
    /// </summary>
    int GetItemIndex(int id);
    /// <summary>
    /// <para>Returns the accelerator of the item at the given <paramref name="index" />. An accelerator is a keyboard shortcut that can be pressed to trigger the menu button even if it's not currently open. The return value is an integer which is generally a combination of <see cref="KeyModifierMask" />s and <see cref="Key" />s using bitwise OR such as <c>KEY_MASK_CTRL | KEY_A</c> (Ctrl + A). If no accelerator is defined for the specified <paramref name="index" />, <see cref="M:Godot.PopupMenu.GetItemAccelerator(System.Int32)" /> returns <c>0</c> (corresponding to <see cref="Key.None" />).</para>
    /// </summary>
    Key GetItemAccelerator(int index);
    /// <summary>
    /// <para>Returns the metadata of the specified item, which might be of any type. You can set it with <see cref="M:Godot.PopupMenu.SetItemMetadata(System.Int32,Godot.Variant)" />, which provides a simple way of assigning context data to items.</para>
    /// </summary>
    Variant GetItemMetadata(int index);
    /// <summary>
    /// <para>Returns <c>true</c> if the item at the given <paramref name="index" /> is disabled. When it is disabled it can't be selected, or its action invoked.</para>
    /// <para>See <see cref="M:Godot.PopupMenu.SetItemDisabled(System.Int32,System.Boolean)" /> for more info on how to disable an item.</para>
    /// </summary>
    bool IsItemDisabled(int index);
    /// <summary>
    /// <para>Returns the submenu name of the item at the given <paramref name="index" />. See <see cref="M:Godot.PopupMenu.AddSubmenuItem(System.String,System.String,System.Int32)" /> for more info on how to add a submenu.</para>
    /// </summary>
    string GetItemSubmenu(int index);
    /// <summary>
    /// <para>Returns <c>true</c> if the item is a separator. If it is, it will be displayed as a line. See <see cref="M:Godot.PopupMenu.AddSeparator(System.String,System.Int32)" /> for more info on how to add a separator.</para>
    /// </summary>
    bool IsItemSeparator(int index);
    /// <summary>
    /// <para>Returns <c>true</c> if the item at the given <paramref name="index" /> is checkable in some way, i.e. if it has a checkbox or radio button.</para>
    /// <para><b>Note:</b> Checkable items just display a checkmark or radio button, but don't have any built-in checking behavior and must be checked/unchecked manually.</para>
    /// </summary>
    bool IsItemCheckable(int index);
    /// <summary>
    /// <para>Returns <c>true</c> if the item at the given <paramref name="index" /> has radio button-style checkability.</para>
    /// <para><b>Note:</b> This is purely cosmetic; you must add the logic for checking/unchecking items in radio groups.</para>
    /// </summary>
    bool IsItemRadioCheckable(int index);
    /// <summary>
    /// <para>Returns <c>true</c> if the specified item's shortcut is disabled.</para>
    /// </summary>
    bool IsItemShortcutDisabled(int index);
    /// <summary>
    /// <para>Returns the tooltip associated with the item at the given <paramref name="index" />.</para>
    /// </summary>
    string GetItemTooltip(int index);
    /// <summary>
    /// <para>Returns the <see cref="Shortcut" /> associated with the item at the given <paramref name="index" />.</para>
    /// </summary>
    Shortcut GetItemShortcut(int index);
    /// <summary>
    /// <para>Returns the horizontal offset of the item at the given <paramref name="index" />.</para>
    /// </summary>
    int GetItemIndent(int index);
    /// <summary>
    /// <para>Sets the currently focused item as the given <paramref name="index" />.</para>
    /// <para>Passing <c>-1</c> as the index makes so that no item is focused.</para>
    /// </summary>
    void SetFocusedItem(int index);
    /// <summary>
    /// <para>Returns the index of the currently focused item. Returns <c>-1</c> if no item is focused.</para>
    /// </summary>
    int GetFocusedItem();
    /// <summary>
    /// <para>Moves the scroll view to make the item at the given <paramref name="index" /> visible.</para>
    /// </summary>
    void ScrollToItem(int index);
    /// <summary>
    /// <para>Removes the item at the given <paramref name="index" /> from the menu.</para>
    /// <para><b>Note:</b> The indices of items after the removed item will be shifted by one.</para>
    /// </summary>
    void RemoveItem(int index);
    /// <summary>
    /// <para>Adds a separator between items. Separators also occupy an index, which you can set by using the <paramref name="id" /> parameter.</para>
    /// <para>A <paramref name="label" /> can optionally be provided, which will appear at the center of the separator.</para>
    /// </summary>
    void AddSeparator(string label, int id);
    /// <summary>
    /// <para>Removes all items from the <see cref="PopupMenu" />. If <paramref name="freeSubmenus" /> is <c>true</c>, the submenu nodes are automatically freed.</para>
    /// </summary>
    void Clear(bool freeSubmenus);
    /// <summary>
    /// <para>Removes all items from the <see cref="PopupMenu" />. If <paramref name="freeSubmenus" /> is <c>true</c>, the submenu nodes are automatically freed.</para>
    /// </summary>
    void Clear();
    /// <summary>
    /// <para>Adds a new item and assigns the specified <see cref="Shortcut" /> and icon <paramref name="texture" /> to it. Sets the label of the checkbox to the <see cref="Shortcut" />'s name.</para>
    /// <para>An <paramref name="id" /> can optionally be provided. If no <paramref name="id" /> is provided, one will be created from the index.</para>
    /// <para>If <paramref name="allowEcho" /> is <c>true</c>, the shortcut can be activated with echo events.</para>
    /// </summary>
    void AddIconShortcut(Texture2D texture, Shortcut shortcut, int id, bool @global);
    /// <summary>
    /// <para>Adds a <see cref="Shortcut" />.</para>
    /// <para>An <paramref name="id" /> can optionally be provided. If no <paramref name="id" /> is provided, one will be created from the index.</para>
    /// <para>If <paramref name="allowEcho" /> is <c>true</c>, the shortcut can be activated with echo events.</para>
    /// </summary>
    void AddShortcut(Shortcut shortcut, int id, bool @global);
    /// <summary>
    /// <para>If <c>true</c>, hides the <see cref="PopupMenu" /> when an item is selected.</para>
    /// </summary>
    bool HideOnItemSelection { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, hides the <see cref="PopupMenu" /> when a checkbox or radio button is selected.</para>
    /// </summary>
    bool HideOnCheckableItemSelection { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, hides the <see cref="PopupMenu" /> when a state item is selected.</para>
    /// </summary>
    bool HideOnStateItemSelection { get; set; }
    /// <summary>
    /// <para>Sets the delay time in seconds for the submenu item to popup on mouse hovering. If the popup menu is added as a child of another (acting as a submenu), it will inherit the delay time of the parent menu item.</para>
    /// </summary>
    float SubmenuPopupDelay { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, allows navigating <see cref="PopupMenu" /> with letter keys.</para>
    /// </summary>
    bool AllowSearch { get; set; }
    /// <summary>
    /// <para>The number of items currently in the list.</para>
    /// </summary>
    int ItemCount { get; set; }

}