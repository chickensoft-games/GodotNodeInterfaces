namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class TabBarNode : TabBar, ITabBar { }

/// <summary>
/// <para>A control that provides a horizontal bar with tabs. Similar to <see cref="TabContainer" /> but is only in charge of drawing tabs, not interacting with children.</para>
/// </summary>
public interface ITabBar : IControl {
    /// <summary>
    /// <para>Adds a new tab.</para>
    /// </summary>
    void AddTab(string title, Texture2D icon);
    /// <summary>
    /// <para>Clears all tabs.</para>
    /// </summary>
    void ClearTabs();
    /// <summary>
    /// <para>If <c>true</c>, tabs overflowing this node's width will be hidden, displaying two navigation buttons instead. Otherwise, this node's minimum size is updated so that all tabs are visible.</para>
    /// </summary>
    bool ClipTabs { get; set; }
    /// <summary>
    /// <para>Select tab at index <c>tab_idx</c>.</para>
    /// </summary>
    int CurrentTab { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, tabs can be rearranged with mouse drag.</para>
    /// </summary>
    bool DragToRearrangeEnabled { get; set; }
    /// <summary>
    /// <para>Moves the scroll view to make the tab visible.</para>
    /// </summary>
    void EnsureTabVisible(int idx);
    /// <summary>
    /// <para>Returns <c>true</c> if the offset buttons (the ones that appear when there's not enough space for all tabs) are visible.</para>
    /// </summary>
    bool GetOffsetButtonsVisible();
    /// <summary>
    /// <para>Returns the previously active tab index.</para>
    /// </summary>
    int GetPreviousTab();
    /// <summary>
    /// <para>Returns the icon for the right button of the tab at index <paramref name="tabIdx" /> or <c>null</c> if the right button has no icon.</para>
    /// </summary>
    Texture2D GetTabButtonIcon(int tabIdx);
    /// <summary>
    /// <para>Returns the icon for the tab at index <paramref name="tabIdx" /> or <c>null</c> if the tab has no icon.</para>
    /// </summary>
    Texture2D GetTabIcon(int tabIdx);
    /// <summary>
    /// <para>Returns the maximum allowed width of the icon for the tab at index <paramref name="tabIdx" />.</para>
    /// </summary>
    int GetTabIconMaxWidth(int tabIdx);
    /// <summary>
    /// <para>Returns the index of the tab at local coordinates <paramref name="point" />. Returns <c>-1</c> if the point is outside the control boundaries or if there's no tab at the queried position.</para>
    /// </summary>
    int GetTabIdxAtPoint(Vector2 point);
    /// <summary>
    /// <para>Returns tab title language code.</para>
    /// </summary>
    string GetTabLanguage(int tabIdx);
    /// <summary>
    /// <para>Returns the metadata value set to the tab at index <paramref name="tabIdx" /> using <see cref="TabBar.SetTabMetadata(System.Int32,Godot.Variant)" />. If no metadata was previously set, returns <c>null</c> by default.</para>
    /// </summary>
    Variant GetTabMetadata(int tabIdx);
    /// <summary>
    /// <para>Returns the number of hidden tabs offsetted to the left.</para>
    /// </summary>
    int GetTabOffset();
    /// <summary>
    /// <para>Returns tab <see cref="Rect2" /> with local position and size.</para>
    /// </summary>
    Rect2 GetTabRect(int tabIdx);
    /// <summary>
    /// <para>Returns tab title text base writing direction.</para>
    /// </summary>
    Control.TextDirection GetTabTextDirection(int tabIdx);
    /// <summary>
    /// <para>Returns the title of the tab at index <paramref name="tabIdx" />.</para>
    /// </summary>
    string GetTabTitle(int tabIdx);
    /// <summary>
    /// <para>Returns <c>true</c> if the tab at index <paramref name="tabIdx" /> is disabled.</para>
    /// </summary>
    bool IsTabDisabled(int tabIdx);
    /// <summary>
    /// <para>Returns <c>true</c> if the tab at index <paramref name="tabIdx" /> is hidden.</para>
    /// </summary>
    bool IsTabHidden(int tabIdx);
    /// <summary>
    /// <para>Sets the maximum width which all tabs should be limited to. Unlimited if set to <c>0</c>.</para>
    /// </summary>
    int MaxTabWidth { get; set; }
    /// <summary>
    /// <para>Moves a tab from <paramref name="from" /> to <paramref name="to" />.</para>
    /// </summary>
    void MoveTab(int @from, int to);
    /// <summary>
    /// <para>Removes the tab at index <paramref name="tabIdx" />.</para>
    /// </summary>
    void RemoveTab(int tabIdx);
    /// <summary>
    /// <para>if <c>true</c>, the mouse's scroll wheel can be used to navigate the scroll view.</para>
    /// </summary>
    bool ScrollingEnabled { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the tab offset will be changed to keep the currently selected tab visible.</para>
    /// </summary>
    bool ScrollToSelected { get; set; }
    /// <summary>
    /// <para>Selects the first available tab with greater index than the currently selected. Returns <c>true</c> if tab selection changed.</para>
    /// </summary>
    bool SelectNextAvailable();
    /// <summary>
    /// <para>Selects the first available tab with lower index than the currently selected. Returns <c>true</c> if tab selection changed.</para>
    /// </summary>
    bool SelectPreviousAvailable();
    /// <summary>
    /// <para>If <c>true</c>, enables selecting a tab with the right mouse button.</para>
    /// </summary>
    bool SelectWithRmb { get; set; }
    /// <summary>
    /// <para>Sets an <paramref name="icon" /> for the button of the tab at index <paramref name="tabIdx" /> (located to the right, before the close button), making it visible and clickable (See <see cref="TabBar.TabButtonPressed" />). Giving it a <c>null</c> value will hide the button.</para>
    /// </summary>
    void SetTabButtonIcon(int tabIdx, Texture2D icon);
    /// <summary>
    /// <para>If <paramref name="disabled" /> is <c>true</c>, disables the tab at index <paramref name="tabIdx" />, making it non-interactable.</para>
    /// </summary>
    void SetTabDisabled(int tabIdx, bool disabled);
    /// <summary>
    /// <para>If <paramref name="hidden" /> is <c>true</c>, hides the tab at index <paramref name="tabIdx" />, making it disappear from the tab area.</para>
    /// </summary>
    void SetTabHidden(int tabIdx, bool hidden);
    /// <summary>
    /// <para>Sets an <paramref name="icon" /> for the tab at index <paramref name="tabIdx" />.</para>
    /// </summary>
    void SetTabIcon(int tabIdx, Texture2D icon);
    /// <summary>
    /// <para>Sets the maximum allowed width of the icon for the tab at index <paramref name="tabIdx" />. This limit is applied on top of the default size of the icon and on top of <c>icon_max_width</c>. The height is adjusted according to the icon's ratio.</para>
    /// </summary>
    void SetTabIconMaxWidth(int tabIdx, int width);
    /// <summary>
    /// <para>Sets language code of tab title used for line-breaking and text shaping algorithms, if left empty current locale is used instead.</para>
    /// </summary>
    void SetTabLanguage(int tabIdx, string language);
    /// <summary>
    /// <para>Sets the metadata value for the tab at index <paramref name="tabIdx" />, which can be retrieved later using <see cref="TabBar.GetTabMetadata(System.Int32)" />.</para>
    /// </summary>
    void SetTabMetadata(int tabIdx, Variant metadata);
    /// <summary>
    /// <para>Sets tab title base writing direction.</para>
    /// </summary>
    void SetTabTextDirection(int tabIdx, Control.TextDirection direction);
    /// <summary>
    /// <para>Sets a <paramref name="title" /> for the tab at index <paramref name="tabIdx" />.</para>
    /// </summary>
    void SetTabTitle(int tabIdx, string title);
    /// <summary>
    /// <para>Sets the position at which tabs will be placed. See <see cref="TabBar.AlignmentMode" /> for details.</para>
    /// </summary>
    TabBar.AlignmentMode TabAlignment { get; set; }
    /// <summary>
    /// <para>Sets when the close button will appear on the tabs. See <see cref="TabBar.CloseButtonDisplayPolicy" /> for details.</para>
    /// </summary>
    TabBar.CloseButtonDisplayPolicy TabCloseDisplayPolicy { get; set; }
    /// <summary>
    /// <para>The number of tabs currently in the bar.</para>
    /// </summary>
    int TabCount { get; set; }
    /// <summary>
    /// <para><see cref="TabBar" />s with the same rearrange group ID will allow dragging the tabs between them. Enable drag with <see cref="TabBar.DragToRearrangeEnabled" />.</para>
    /// <para>Setting this to <c>-1</c> will disable rearranging between <see cref="TabBar" />s.</para>
    /// </summary>
    int TabsRearrangeGroup { get; set; }

}