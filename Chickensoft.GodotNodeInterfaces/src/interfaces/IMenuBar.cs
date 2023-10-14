namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>A horizontal menu bar that creates a <see cref="MenuButton" /> for each <see cref="PopupMenu" /> child. New items are created by adding <see cref="PopupMenu" />s to this node.</para>
/// </summary>
public interface IMenuBar : IControl {
    /// <summary>
    /// <para>If <c>true</c>, shortcuts are disabled and cannot be used to trigger the button.</para>
    /// </summary>
    void SetDisableShortcuts(bool disabled);
    /// <summary>
    /// <para>Returns <c>true</c>, if system global menu is supported and used by this <see cref="MenuBar" />.</para>
    /// </summary>
    bool IsNativeMenu();
    /// <summary>
    /// <para>Returns number of menu items.</para>
    /// </summary>
    int GetMenuCount();
    /// <summary>
    /// <para>Sets menu item title.</para>
    /// </summary>
    void SetMenuTitle(int menu, string title);
    /// <summary>
    /// <para>Returns menu item title.</para>
    /// </summary>
    string GetMenuTitle(int menu);
    /// <summary>
    /// <para>Sets menu item tooltip.</para>
    /// </summary>
    void SetMenuTooltip(int menu, string tooltip);
    /// <summary>
    /// <para>Returns menu item tooltip.</para>
    /// </summary>
    string GetMenuTooltip(int menu);
    /// <summary>
    /// <para>If <c>true</c>, menu item is disabled.</para>
    /// </summary>
    void SetMenuDisabled(int menu, bool disabled);
    /// <summary>
    /// <para>Returns <c>true</c>, if menu item is disabled.</para>
    /// </summary>
    bool IsMenuDisabled(int menu);
    /// <summary>
    /// <para>If <c>true</c>, menu item is hidden.</para>
    /// </summary>
    void SetMenuHidden(int menu, bool hidden);
    /// <summary>
    /// <para>Returns <c>true</c>, if menu item is hidden.</para>
    /// </summary>
    bool IsMenuHidden(int menu);
    /// <summary>
    /// <para>Returns <see cref="PopupMenu" /> associated with menu item.</para>
    /// </summary>
    PopupMenu GetMenuPopup(int menu);
    /// <summary>
    /// <para>Flat <see cref="MenuBar" /> don't display item decoration.</para>
    /// </summary>
    bool Flat { get; set; }
    /// <summary>
    /// <para>Position in the global menu to insert first <see cref="MenuBar" /> item at.</para>
    /// </summary>
    int StartIndex { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, when the cursor hovers above menu item, it will close the current <see cref="PopupMenu" /> and open the other one.</para>
    /// </summary>
    bool SwitchOnHover { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, <see cref="MenuBar" /> will use system global menu when supported.</para>
    /// </summary>
    bool PreferGlobalMenu { get; set; }
    /// <summary>
    /// <para>Base text writing direction.</para>
    /// </summary>
    Control.TextDirection TextDirection { get; set; }
    /// <summary>
    /// <para>Language code used for line-breaking and text shaping algorithms, if left empty current locale is used instead.</para>
    /// </summary>
    string Language { get; set; }

}