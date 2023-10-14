namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>Arranges child controls into a tabbed view, creating a tab for each one. The active tab's corresponding control is made visible, while all other child controls are hidden. Ignores non-control children.</para>
/// <para><b>Note:</b> The drawing of the clickable tabs is handled by this node; <see cref="TabBar" /> is not needed.</para>
/// </summary>
public class TabContainerAdapter : ContainerAdapter, ITabContainer {
  private readonly TabContainer _node;

  public TabContainerAdapter(TabContainer node) : base(node) { _node = node; }

    /// <summary>
    /// <para>If <c>true</c>, all tabs are drawn in front of the panel. If <c>false</c>, inactive tabs are drawn behind the panel.</para>
    /// </summary>
    public bool AllTabsInFront { get => _node.AllTabsInFront; set => _node.AllTabsInFront = value; }
    /// <summary>
    /// <para>If <c>true</c>, tabs overflowing this node's width will be hidden, displaying two navigation buttons instead. Otherwise, this node's minimum size is updated so that all tabs are visible.</para>
    /// </summary>
    public bool ClipTabs { get => _node.ClipTabs; set => _node.ClipTabs = value; }
    /// <summary>
    /// <para>The current tab index. When set, this index's <see cref="Control" /> node's <c>visible</c> property is set to <c>true</c> and all others are set to <c>false</c>.</para>
    /// </summary>
    public int CurrentTab { get => _node.CurrentTab; set => _node.CurrentTab = value; }
    /// <summary>
    /// <para>If <c>true</c>, tabs can be rearranged with mouse drag.</para>
    /// </summary>
    public bool DragToRearrangeEnabled { get => _node.DragToRearrangeEnabled; set => _node.DragToRearrangeEnabled = value; }
    /// <summary>
    /// <para>Returns the child <see cref="Control" /> node located at the active tab index.</para>
    /// </summary>
    public Control GetCurrentTabControl() => _node.GetCurrentTabControl();
    /// <summary>
    /// <para>Returns the <see cref="Popup" /> node instance if one has been set already with <see cref="TabContainer.SetPopup(Godot.Node)" />.</para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash. If you wish to hide it or any of its children, use their <see cref="Window.Visible" /> property.</para>
    /// </summary>
    public Popup GetPopup() => _node.GetPopup();
    /// <summary>
    /// <para>Returns the previously active tab index.</para>
    /// </summary>
    public int GetPreviousTab() => _node.GetPreviousTab();
    /// <summary>
    /// <para>Returns the <see cref="TabBar" /> contained in this container.</para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it or editing its tabs may cause a crash. If you wish to edit the tabs, use the methods provided in <see cref="TabContainer" />.</para>
    /// </summary>
    public TabBar GetTabBar() => _node.GetTabBar();
    /// <summary>
    /// <para>Returns the button icon from the tab at index <paramref name="tabIdx" />.</para>
    /// </summary>
    public Texture2D GetTabButtonIcon(int tabIdx) => _node.GetTabButtonIcon(tabIdx);
    /// <summary>
    /// <para>Returns the <see cref="Control" /> node from the tab at index <paramref name="tabIdx" />.</para>
    /// </summary>
    public Control GetTabControl(int tabIdx) => _node.GetTabControl(tabIdx);
    /// <summary>
    /// <para>Returns the number of tabs.</para>
    /// </summary>
    public int GetTabCount() => _node.GetTabCount();
    /// <summary>
    /// <para>Returns the <see cref="Texture2D" /> for the tab at index <paramref name="tabIdx" /> or <c>null</c> if the tab has no <see cref="Texture2D" />.</para>
    /// </summary>
    public Texture2D GetTabIcon(int tabIdx) => _node.GetTabIcon(tabIdx);
    /// <summary>
    /// <para>Returns the index of the tab at local coordinates <paramref name="point" />. Returns <c>-1</c> if the point is outside the control boundaries or if there's no tab at the queried position.</para>
    /// </summary>
    public int GetTabIdxAtPoint(Vector2 point) => _node.GetTabIdxAtPoint(point);
    /// <summary>
    /// <para>Returns the index of the tab tied to the given <paramref name="control" />. The control must be a child of the <see cref="TabContainer" />.</para>
    /// </summary>
    public int GetTabIdxFromControl(Control control) => _node.GetTabIdxFromControl(control);
    /// <summary>
    /// <para>Returns the metadata value set to the tab at index <paramref name="tabIdx" /> using <see cref="TabContainer.SetTabMetadata(System.Int32,Godot.Variant)" />. If no metadata was previously set, returns <c>null</c> by default.</para>
    /// </summary>
    public Variant GetTabMetadata(int tabIdx) => _node.GetTabMetadata(tabIdx);
    /// <summary>
    /// <para>Returns the title of the tab at index <paramref name="tabIdx" />. Tab titles default to the name of the indexed child node, but this can be overridden with <see cref="TabContainer.SetTabTitle(System.Int32,System.String)" />.</para>
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
    /// <para>Selects the first available tab with greater index than the currently selected. Returns <c>true</c> if tab selection changed.</para>
    /// </summary>
    public bool SelectNextAvailable() => _node.SelectNextAvailable();
    /// <summary>
    /// <para>Selects the first available tab with lower index than the currently selected. Returns <c>true</c> if tab selection changed.</para>
    /// </summary>
    public bool SelectPreviousAvailable() => _node.SelectPreviousAvailable();
    /// <summary>
    /// <para>If set on a <see cref="Popup" /> node instance, a popup menu icon appears in the top-right corner of the <see cref="TabContainer" /> (setting it to <c>null</c> will make it go away). Clicking it will expand the <see cref="Popup" /> node.</para>
    /// </summary>
    public void SetPopup(Node popup) => _node.SetPopup(popup);
    /// <summary>
    /// <para>Sets the button icon from the tab at index <paramref name="tabIdx" />.</para>
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
    /// <para>Sets an icon for the tab at index <paramref name="tabIdx" />.</para>
    /// </summary>
    public void SetTabIcon(int tabIdx, Texture2D icon) => _node.SetTabIcon(tabIdx, icon);
    /// <summary>
    /// <para>Sets the metadata value for the tab at index <paramref name="tabIdx" />, which can be retrieved later using <see cref="TabContainer.GetTabMetadata(System.Int32)" />.</para>
    /// </summary>
    public void SetTabMetadata(int tabIdx, Variant metadata) => _node.SetTabMetadata(tabIdx, metadata);
    /// <summary>
    /// <para>Sets a custom title for the tab at index <paramref name="tabIdx" /> (tab titles default to the name of the indexed child node). Set it back to the child's name to make the tab default to it again.</para>
    /// </summary>
    public void SetTabTitle(int tabIdx, string title) => _node.SetTabTitle(tabIdx, title);
    /// <summary>
    /// <para>Sets the position at which tabs will be placed. See <see cref="TabBar.AlignmentMode" /> for details.</para>
    /// </summary>
    public TabBar.AlignmentMode TabAlignment { get => _node.TabAlignment; set => _node.TabAlignment = value; }
    /// <summary>
    /// <para>The focus access mode for the internal <see cref="TabBar" /> node.</para>
    /// </summary>
    public Control.FocusModeEnum TabFocusMode { get => _node.TabFocusMode; set => _node.TabFocusMode = value; }
    /// <summary>
    /// <para><see cref="TabContainer" />s with the same rearrange group ID will allow dragging the tabs between them. Enable drag with <see cref="TabContainer.DragToRearrangeEnabled" />.</para>
    /// <para>Setting this to <c>-1</c> will disable rearranging between <see cref="TabContainer" />s.</para>
    /// </summary>
    public int TabsRearrangeGroup { get => _node.TabsRearrangeGroup; set => _node.TabsRearrangeGroup = value; }
    /// <summary>
    /// <para>If <c>true</c>, tabs are visible. If <c>false</c>, tabs' content and titles are hidden.</para>
    /// </summary>
    public bool TabsVisible { get => _node.TabsVisible; set => _node.TabsVisible = value; }
    /// <summary>
    /// <para>If <c>true</c>, children <see cref="Control" /> nodes that are hidden have their minimum size take into account in the total, instead of only the currently visible one.</para>
    /// </summary>
    public bool UseHiddenTabsForMinSize { get => _node.UseHiddenTabsForMinSize; set => _node.UseHiddenTabsForMinSize = value; }

}