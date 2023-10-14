namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para>A popup with a configurable panel background. Any child controls added to this node will be stretched to fit the panel's size (similar to how <see cref="PanelContainer" /> works). If you are making windows, see <see cref="Window" />.</para>
/// </summary>
public class PopupPanelAdapter : PopupPanel, IPopupPanel {
  private readonly PopupPanel _node;

  public PopupPanelAdapter(PopupPanel node) => _node = node;

}