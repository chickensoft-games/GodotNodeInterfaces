namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A horizontal menu bar that creates a <see cref="MenuButton" /> for each <see cref="PopupMenu" /> child. New items are created by adding <see cref="PopupMenu" />s to this node.</para>
/// </summary>
public class MenuBarAdapter : ControlAdapter, IMenuBar {
  private readonly MenuBar _node;

  public MenuBarAdapter(Node node) : base(node) {
    if (node is not MenuBar typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a MenuBar"
      );
    }
    _node = typedNode;
  }

    /// <summary>
    /// <para>Flat <see cref="MenuBar" /> don't display item decoration.</para>
    /// </summary>
    public bool Flat { get => _node.Flat; set => _node.Flat = value; }
    /// <summary>
    /// <para>Returns number of menu items.</para>
    /// </summary>
    public int GetMenuCount() => _node.GetMenuCount();
    /// <summary>
    /// <para>Returns <see cref="PopupMenu" /> associated with menu item.</para>
    /// </summary>
    public PopupMenu GetMenuPopup(int menu) => _node.GetMenuPopup(menu);
    /// <summary>
    /// <para>Returns menu item title.</para>
    /// </summary>
    public string GetMenuTitle(int menu) => _node.GetMenuTitle(menu);
    /// <summary>
    /// <para>Returns menu item tooltip.</para>
    /// </summary>
    public string GetMenuTooltip(int menu) => _node.GetMenuTooltip(menu);
    /// <summary>
    /// <para>Returns <c>true</c>, if menu item is disabled.</para>
    /// </summary>
    public bool IsMenuDisabled(int menu) => _node.IsMenuDisabled(menu);
    /// <summary>
    /// <para>Returns <c>true</c>, if menu item is hidden.</para>
    /// </summary>
    public bool IsMenuHidden(int menu) => _node.IsMenuHidden(menu);
    /// <summary>
    /// <para>Returns <c>true</c>, if system global menu is supported and used by this <see cref="MenuBar" />.</para>
    /// </summary>
    public bool IsNativeMenu() => _node.IsNativeMenu();
    /// <summary>
    /// <para>Language code used for line-breaking and text shaping algorithms, if left empty current locale is used instead.</para>
    /// </summary>
    public string Language { get => _node.Language; set => _node.Language = value; }
    /// <summary>
    /// <para>If <c>true</c>, <see cref="MenuBar" /> will use system global menu when supported.</para>
    /// </summary>
    public bool PreferGlobalMenu { get => _node.PreferGlobalMenu; set => _node.PreferGlobalMenu = value; }
    /// <summary>
    /// <para>If <c>true</c>, shortcuts are disabled and cannot be used to trigger the button.</para>
    /// </summary>
    public void SetDisableShortcuts(bool disabled) => _node.SetDisableShortcuts(disabled);
    /// <summary>
    /// <para>If <c>true</c>, menu item is disabled.</para>
    /// </summary>
    public void SetMenuDisabled(int menu, bool disabled) => _node.SetMenuDisabled(menu, disabled);
    /// <summary>
    /// <para>If <c>true</c>, menu item is hidden.</para>
    /// </summary>
    public void SetMenuHidden(int menu, bool hidden) => _node.SetMenuHidden(menu, hidden);
    /// <summary>
    /// <para>Sets menu item title.</para>
    /// </summary>
    public void SetMenuTitle(int menu, string title) => _node.SetMenuTitle(menu, title);
    /// <summary>
    /// <para>Sets menu item tooltip.</para>
    /// </summary>
    public void SetMenuTooltip(int menu, string tooltip) => _node.SetMenuTooltip(menu, tooltip);
    /// <summary>
    /// <para>Position in the global menu to insert first <see cref="MenuBar" /> item at.</para>
    /// </summary>
    public int StartIndex { get => _node.StartIndex; set => _node.StartIndex = value; }
    /// <summary>
    /// <para>If <c>true</c>, when the cursor hovers above menu item, it will close the current <see cref="PopupMenu" /> and open the other one.</para>
    /// </summary>
    public bool SwitchOnHover { get => _node.SwitchOnHover; set => _node.SwitchOnHover = value; }
    /// <summary>
    /// <para>Base text writing direction.</para>
    /// </summary>
    public Control.TextDirection TextDirection { get => _node.TextDirection; set => _node.TextDirection = value; }

}