namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class TabContainerNode : TabContainer, ITabContainer { }

/// <summary>
/// <para>Arranges child controls into a tabbed view, creating a tab for each one. The active tab's corresponding control is made visible, while all other child controls are hidden. Ignores non-control children.</para>
/// <para><b>Note:</b> The drawing of the clickable tabs is handled by this node; <see cref="TabBar" /> is not needed.</para>
/// </summary>
public interface ITabContainer : IContainer {
    /// <summary>
    /// <para>If <c>true</c>, all tabs are drawn in front of the panel. If <c>false</c>, inactive tabs are drawn behind the panel.</para>
    /// </summary>
    bool AllTabsInFront { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, tabs overflowing this node's width will be hidden, displaying two navigation buttons instead. Otherwise, this node's minimum size is updated so that all tabs are visible.</para>
    /// </summary>
    bool ClipTabs { get; set; }
    /// <summary>
    /// <para>The current tab index. When set, this index's <see cref="Control" /> node's <c>visible</c> property is set to <c>true</c> and all others are set to <c>false</c>.</para>
    /// </summary>
    int CurrentTab { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, tabs can be rearranged with mouse drag.</para>
    /// </summary>
    bool DragToRearrangeEnabled { get; set; }
    /// <summary>
    /// <para>Returns the child <see cref="Control" /> node located at the active tab index.</para>
    /// </summary>
    Control GetCurrentTabControl();
    /// <summary>
    /// <para>Returns the <see cref="Popup" /> node instance if one has been set already with <see cref="TabContainer.SetPopup(Godot.Node)" />.</para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash. If you wish to hide it or any of its children, use their <see cref="Window.Visible" /> property.</para>
    /// </summary>
    Popup GetPopup();
    /// <summary>
    /// <para>Returns the previously active tab index.</para>
    /// </summary>
    int GetPreviousTab();
    /// <summary>
    /// <para>Returns the <see cref="TabBar" /> contained in this container.</para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it or editing its tabs may cause a crash. If you wish to edit the tabs, use the methods provided in <see cref="TabContainer" />.</para>
    /// </summary>
    TabBar GetTabBar();
    /// <summary>
    /// <para>Returns the button icon from the tab at index <paramref name="tabIdx" />.</para>
    /// </summary>
    Texture2D GetTabButtonIcon(int tabIdx);
    /// <summary>
    /// <para>Returns the <see cref="Control" /> node from the tab at index <paramref name="tabIdx" />.</para>
    /// </summary>
    Control GetTabControl(int tabIdx);
    /// <summary>
    /// <para>Returns the number of tabs.</para>
    /// </summary>
    int GetTabCount();
    /// <summary>
    /// <para>Returns the <see cref="Texture2D" /> for the tab at index <paramref name="tabIdx" /> or <c>null</c> if the tab has no <see cref="Texture2D" />.</para>
    /// </summary>
    Texture2D GetTabIcon(int tabIdx);
    /// <summary>
    /// <para>Returns the index of the tab at local coordinates <paramref name="point" />. Returns <c>-1</c> if the point is outside the control boundaries or if there's no tab at the queried position.</para>
    /// </summary>
    int GetTabIdxAtPoint(Vector2 point);
    /// <summary>
    /// <para>Returns the index of the tab tied to the given <paramref name="control" />. The control must be a child of the <see cref="TabContainer" />.</para>
    /// </summary>
    int GetTabIdxFromControl(Control control);
    /// <summary>
    /// <para>Returns the metadata value set to the tab at index <paramref name="tabIdx" /> using <see cref="TabContainer.SetTabMetadata(System.Int32,Godot.Variant)" />. If no metadata was previously set, returns <c>null</c> by default.</para>
    /// </summary>
    Variant GetTabMetadata(int tabIdx);
    /// <summary>
    /// <para>Returns the title of the tab at index <paramref name="tabIdx" />. Tab titles default to the name of the indexed child node, but this can be overridden with <see cref="TabContainer.SetTabTitle(System.Int32,System.String)" />.</para>
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
    /// <para>Selects the first available tab with greater index than the currently selected. Returns <c>true</c> if tab selection changed.</para>
    /// </summary>
    bool SelectNextAvailable();
    /// <summary>
    /// <para>Selects the first available tab with lower index than the currently selected. Returns <c>true</c> if tab selection changed.</para>
    /// </summary>
    bool SelectPreviousAvailable();
    /// <summary>
    /// <para>If set on a <see cref="Popup" /> node instance, a popup menu icon appears in the top-right corner of the <see cref="TabContainer" /> (setting it to <c>null</c> will make it go away). Clicking it will expand the <see cref="Popup" /> node.</para>
    /// </summary>
    void SetPopup(Node popup);
    /// <summary>
    /// <para>Sets the button icon from the tab at index <paramref name="tabIdx" />.</para>
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
    /// <para>Sets an icon for the tab at index <paramref name="tabIdx" />.</para>
    /// </summary>
    void SetTabIcon(int tabIdx, Texture2D icon);
    /// <summary>
    /// <para>Sets the metadata value for the tab at index <paramref name="tabIdx" />, which can be retrieved later using <see cref="TabContainer.GetTabMetadata(System.Int32)" />.</para>
    /// </summary>
    void SetTabMetadata(int tabIdx, Variant metadata);
    /// <summary>
    /// <para>Sets a custom title for the tab at index <paramref name="tabIdx" /> (tab titles default to the name of the indexed child node). Set it back to the child's name to make the tab default to it again.</para>
    /// </summary>
    void SetTabTitle(int tabIdx, string title);
    /// <summary>
    /// <para>Sets the position at which tabs will be placed. See <see cref="TabBar.AlignmentMode" /> for details.</para>
    /// </summary>
    TabBar.AlignmentMode TabAlignment { get; set; }
    /// <summary>
    /// <para>The focus access mode for the internal <see cref="TabBar" /> node.</para>
    /// </summary>
    Control.FocusModeEnum TabFocusMode { get; set; }
    /// <summary>
    /// <para><see cref="TabContainer" />s with the same rearrange group ID will allow dragging the tabs between them. Enable drag with <see cref="TabContainer.DragToRearrangeEnabled" />.</para>
    /// <para>Setting this to <c>-1</c> will disable rearranging between <see cref="TabContainer" />s.</para>
    /// </summary>
    int TabsRearrangeGroup { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, tabs are visible. If <c>false</c>, tabs' content and titles are hidden.</para>
    /// </summary>
    bool TabsVisible { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, children <see cref="Control" /> nodes that are hidden have their minimum size take into account in the total, instead of only the currently visible one.</para>
    /// </summary>
    bool UseHiddenTabsForMinSize { get; set; }

}