namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para><see cref="Popup" /> is a base class for contextual windows and panels with fixed position. It's a modal by default (see <see cref="Window.PopupWindow" />) and provides methods for implementing custom popup behavior.</para>
/// </summary>
public class PopupAdapter : WindowAdapter, IPopup {
  private readonly Popup _node;

  public PopupAdapter(Node node) : base(node) {
    if (node is not Popup typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a Popup"
      );
    }
    _node = typedNode;
  }


}