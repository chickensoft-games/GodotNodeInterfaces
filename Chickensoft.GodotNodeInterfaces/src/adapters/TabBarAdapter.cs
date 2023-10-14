namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A control that provides a horizontal bar with tabs. Similar to <see cref="TabContainer" /> but is only in charge of drawing tabs, not interacting with children.</para>
/// </summary>
public class TabBarAdapter : TabBar, ITabBar {
  private readonly TabBar _node;

  public TabBarAdapter(TabBar node) => _node = node;
    /// <summary>
    /// <para>Adds a new tab.</para>
    /// </summary>
    public void AddTab(string title, Texture2D icon) => _node.AddTab(title, icon);
    /// <summary>
    /// <para>Clears all tabs.</para>
    /// </summary>
    public void ClearTabs() => _node.ClearTabs();
    /// <summary>
    /// <para>If <c>true</c>, tabs overflowing this node's width will be hidden, displaying two navigation buttons instead. Otherwise, this node's minimum size is updated so that all tabs are visible.</para>
    /// </summary>
    public bool ClipTabs { get => _node.ClipTabs; set => _node.ClipTabs = value; }
    /// <summary>
    /// <para>Select tab at index <c>tab_idx</c>.</para>
    /// </summary>
    public int CurrentTab { get => _node.CurrentTab; set => _node.CurrentTab = value; }
    /// <summary>
    /// <para>If <c>true</c>, tabs can be rearranged with mouse drag.</para>
    /// </summary>
    public bool DragToRearrangeEnabled { get => _node.DragToRearrangeEnabled; set => _node.DragToRearrangeEnabled = value; }
    /// <summary>
    /// <para>Moves the scroll view to make the tab visible.</para>
    /// </summary>
    public void EnsureTabVisible(int idx) => _node.EnsureTabVisible(idx);
    /// <summary>
    /// <para>Returns <c>true</c> if the offset buttons (the ones that appear when there's not enough space for all tabs) are visible.</para>
    /// </summary>
    public bool GetOffsetButtonsVisible() => _node.GetOffsetButtonsVisible();
    /// <summary>
    /// <para>Returns the previously active tab index.</para>
    /// </summary>
    public int GetPreviousTab() => _node.GetPreviousTab();
    /// <summary>
    /// <para>Returns the icon for the right button of the tab at index <paramref name="tabIdx" /> or <c>null</c> if the right button has no icon.</para>
    /// </summary>
    public Texture2D GetTabButtonIcon(int tabIdx) => _node.GetTabButtonIcon(tabIdx);
    /// <summary>
    /// <para>Returns the icon for the tab at index <paramref name="tabIdx" /> or <c>null</c> if the tab has no icon.</para>
    /// </summary>
    public Texture2D GetTabIcon(int tabIdx) => _node.GetTabIcon(tabIdx);
    /// <summary>
    /// <para>Returns the maximum allowed width of the icon for the tab at index <paramref name="tabIdx" />.</para>
    /// </summary>
    public int GetTabIconMaxWidth(int tabIdx) => _node.GetTabIconMaxWidth(tabIdx);
    /// <summary>
    /// <para>Returns the index of the tab at local coordinates <paramref name="point" />. Returns <c>-1</c> if the point is outside the control boundaries or if there's no tab at the queried position.</para>
    /// </summary>
    public int GetTabIdxAtPoint(Vector2 point) => _node.GetTabIdxAtPoint(point);
    /// <summary>
    /// <para>Returns tab title language code.</para>
    /// </summary>
    public string GetTabLanguage(int tabIdx) => _node.GetTabLanguage(tabIdx);
    /// <summary>
    /// <para>Returns the metadata value set to the tab at index <paramref name="tabIdx" /> using <see cref="TabBar.SetTabMetadata(System.Int32,Godot.Variant)" />. If no metadata was previously set, returns <c>null</c> by default.</para>
    /// </summary>
    public Variant GetTabMetadata(int tabIdx) => _node.GetTabMetadata(tabIdx);
    /// <summary>
    /// <para>Returns the number of hidden tabs offsetted to the left.</para>
    /// </summary>
    public int GetTabOffset() => _node.GetTabOffset();
    /// <summary>
    /// <para>Returns tab <see cref="Rect2" /> with local position and size.</para>
    /// </summary>
    public Rect2 GetTabRect(int tabIdx) => _node.GetTabRect(tabIdx);
    /// <summary>
    /// <para>Returns tab title text base writing direction.</para>
    /// </summary>
    public Control.TextDirection GetTabTextDirection(int tabIdx) => _node.GetTabTextDirection(tabIdx);
    /// <summary>
    /// <para>Returns the title of the tab at index <paramref name="tabIdx" />.</para>
    /// </summary>
    public string GetTabTitle(int tabIdx) => _node.GetTabTitle(tabIdx);
    /// <summary>
    /// <para>Returns <c>true</c> if the tab at index <paramref name="tabIdx" /> is disabled.</para>
    /// </summary>
    public bool IsTabDisabled(int tabIdx) => _node.IsTabDisabled(tabIdx);
    /// <summary>
    /// <para>Returns <c>true</c> if the tab at index <paramref name="tabIdx" /> is hidden.</para>
    /// </summary>
    public bool IsTabHidden(int tabIdx) => _node.IsTabHidden(tabIdx);
    /// <summary>
    /// <para>Sets the maximum width which all tabs should be limited to. Unlimited if set to <c>0</c>.</para>
    /// </summary>
    public int MaxTabWidth { get => _node.MaxTabWidth; set => _node.MaxTabWidth = value; }
    /// <summary>
    /// <para>Moves a tab from <paramref name="from" /> to <paramref name="to" />.</para>
    /// </summary>
    public void MoveTab(int @from, int to) => _node.MoveTab(@from, to);
    /// <summary>
    /// <para>Removes the tab at index <paramref name="tabIdx" />.</para>
    /// </summary>
    public void RemoveTab(int tabIdx) => _node.RemoveTab(tabIdx);
    /// <summary>
    /// <para>if <c>true</c>, the mouse's scroll wheel can be used to navigate the scroll view.</para>
    /// </summary>
    public bool ScrollingEnabled { get => _node.ScrollingEnabled; set => _node.ScrollingEnabled = value; }
    /// <summary>
    /// <para>If <c>true</c>, the tab offset will be changed to keep the currently selected tab visible.</para>
    /// </summary>
    public bool ScrollToSelected { get => _node.ScrollToSelected; set => _node.ScrollToSelected = value; }
    /// <summary>
    /// <para>Selects the first available tab with greater index than the currently selected. Returns <c>true</c> if tab selection changed.</para>
    /// </summary>
    public bool SelectNextAvailable() => _node.SelectNextAvailable();
    /// <summary>
    /// <para>Selects the first available tab with lower index than the currently selected. Returns <c>true</c> if tab selection changed.</para>
    /// </summary>
    public bool SelectPreviousAvailable() => _node.SelectPreviousAvailable();
    /// <summary>
    /// <para>If <c>true</c>, enables selecting a tab with the right mouse button.</para>
    /// </summary>
    public bool SelectWithRmb { get => _node.SelectWithRmb; set => _node.SelectWithRmb = value; }
    /// <summary>
    /// <para>Sets an <paramref name="icon" /> for the button of the tab at index <paramref name="tabIdx" /> (located to the right, before the close button), making it visible and clickable (See <see cref="TabBar.TabButtonPressed" />). Giving it a <c>null</c> value will hide the button.</para>
    /// </summary>
    public void SetTabButtonIcon(int tabIdx, Texture2D icon) => _node.SetTabButtonIcon(tabIdx, icon);
    /// <summary>
    /// <para>If <paramref name="disabled" /> is <c>true</c>, disables the tab at index <paramref name="tabIdx" />, making it non-interactable.</para>
    /// </summary>
    public void SetTabDisabled(int tabIdx, bool disabled) => _node.SetTabDisabled(tabIdx, disabled);
    /// <summary>
    /// <para>If <paramref name="hidden" /> is <c>true</c>, hides the tab at index <paramref name="tabIdx" />, making it disappear from the tab area.</para>
    /// </summary>
    public void SetTabHidden(int tabIdx, bool hidden) => _node.SetTabHidden(tabIdx, hidden);
    /// <summary>
    /// <para>Sets an <paramref name="icon" /> for the tab at index <paramref name="tabIdx" />.</para>
    /// </summary>
    public void SetTabIcon(int tabIdx, Texture2D icon) => _node.SetTabIcon(tabIdx, icon);
    /// <summary>
    /// <para>Sets the maximum allowed width of the icon for the tab at index <paramref name="tabIdx" />. This limit is applied on top of the default size of the icon and on top of <c>icon_max_width</c>. The height is adjusted according to the icon's ratio.</para>
    /// </summary>
    public void SetTabIconMaxWidth(int tabIdx, int width) => _node.SetTabIconMaxWidth(tabIdx, width);
    /// <summary>
    /// <para>Sets language code of tab title used for line-breaking and text shaping algorithms, if left empty current locale is used instead.</para>
    /// </summary>
    public void SetTabLanguage(int tabIdx, string language) => _node.SetTabLanguage(tabIdx, language);
    /// <summary>
    /// <para>Sets the metadata value for the tab at index <paramref name="tabIdx" />, which can be retrieved later using <see cref="TabBar.GetTabMetadata(System.Int32)" />.</para>
    /// </summary>
    public void SetTabMetadata(int tabIdx, Variant metadata) => _node.SetTabMetadata(tabIdx, metadata);
    /// <summary>
    /// <para>Sets tab title base writing direction.</para>
    /// </summary>
    public void SetTabTextDirection(int tabIdx, Control.TextDirection direction) => _node.SetTabTextDirection(tabIdx, direction);
    /// <summary>
    /// <para>Sets a <paramref name="title" /> for the tab at index <paramref name="tabIdx" />.</para>
    /// </summary>
    public void SetTabTitle(int tabIdx, string title) => _node.SetTabTitle(tabIdx, title);
    /// <summary>
    /// <para>Sets the position at which tabs will be placed. See <see cref="TabBar.AlignmentMode" /> for details.</para>
    /// </summary>
    public TabBar.AlignmentMode TabAlignment { get => _node.TabAlignment; set => _node.TabAlignment = value; }
    /// <summary>
    /// <para>Sets when the close button will appear on the tabs. See <see cref="TabBar.CloseButtonDisplayPolicy" /> for details.</para>
    /// </summary>
    public TabBar.CloseButtonDisplayPolicy TabCloseDisplayPolicy { get => _node.TabCloseDisplayPolicy; set => _node.TabCloseDisplayPolicy = value; }
    /// <summary>
    /// <para>The number of tabs currently in the bar.</para>
    /// </summary>
    public int TabCount { get => _node.TabCount; set => _node.TabCount = value; }
    /// <summary>
    /// <para><see cref="TabBar" />s with the same rearrange group ID will allow dragging the tabs between them. Enable drag with <see cref="TabBar.DragToRearrangeEnabled" />.</para>
    /// <para>Setting this to <c>-1</c> will disable rearranging between <see cref="TabBar" />s.</para>
    /// </summary>
    public int TabsRearrangeGroup { get => _node.TabsRearrangeGroup; set => _node.TabsRearrangeGroup = value; }

}