namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para><see cref="Popup" /> is a base class for contextual windows and panels with fixed position. It's a modal by default (see <see cref="Window.PopupWindow" />) and provides methods for implementing custom popup behavior.</para>
/// </summary>
public class PopupAdapter : WindowAdapter, IPopup {
  private readonly Popup _node;

  public PopupAdapter(Popup node) : base(node) { _node = node; }


}