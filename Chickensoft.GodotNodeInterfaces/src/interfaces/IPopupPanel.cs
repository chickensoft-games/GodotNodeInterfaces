namespace Chickensoft.GodotNodeInterfaces;

using Godot;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class PopupPanelNode : PopupPanel, IPopupPanel { }

/// <summary>
/// <para>A popup with a configurable panel background. Any child controls added to this node will be stretched to fit the panel's size (similar to how <see cref="PanelContainer" /> works). If you are making windows, see <see cref="Window" />.</para>
/// </summary>
public interface IPopupPanel : IPopup {

}