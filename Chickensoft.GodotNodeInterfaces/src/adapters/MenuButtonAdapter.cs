namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A button that brings up a <see cref="PopupMenu" /> when clicked. To create new items inside this <see cref="PopupMenu" />, use <c>get_popup().add_item("My Item Name")</c>. You can also create them directly from Godot editor's inspector.</para>
/// <para>See also <see cref="BaseButton" /> which contains common properties and methods associated with this node.</para>
/// </summary>
public class MenuButtonAdapter : MenuButton, IMenuButton {
  private readonly MenuButton _node;

  public MenuButtonAdapter(MenuButton node) => _node = node;
    /// <summary>
    /// <para>Returns the <see cref="PopupMenu" /> contained in this button.</para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash. If you wish to hide it or any of its children, use their <see cref="Window.Visible" /> property.</para>
    /// </summary>
    public PopupMenu GetPopup() => _node.GetPopup();
    /// <summary>
    /// <para>The number of items currently in the list.</para>
    /// </summary>
    public int ItemCount { get => _node.ItemCount; set => _node.ItemCount = value; }
    /// <summary>
    /// <para>If <c>true</c>, shortcuts are disabled and cannot be used to trigger the button.</para>
    /// </summary>
    public void SetDisableShortcuts(bool disabled) => _node.SetDisableShortcuts(disabled);
    /// <summary>
    /// <para>Adjusts popup position and sizing for the <see cref="MenuButton" />, then shows the <see cref="PopupMenu" />. Prefer this over using <c>get_popup().popup()</c>.</para>
    /// </summary>
    public void ShowPopup() => _node.ShowPopup();
    /// <summary>
    /// <para>If <c>true</c>, when the cursor hovers above another <see cref="MenuButton" /> within the same parent which also has <see cref="MenuButton.SwitchOnHover" /> enabled, it will close the current <see cref="MenuButton" /> and open the other one.</para>
    /// </summary>
    public bool SwitchOnHover { get => _node.SwitchOnHover; set => _node.SwitchOnHover = value; }

}