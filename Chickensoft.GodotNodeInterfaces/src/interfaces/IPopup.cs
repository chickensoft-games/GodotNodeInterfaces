namespace Chickensoft.GodotNodeInterfaces;

using Godot;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class PopupNode : Popup, IPopup { }

/// <summary>
/// <para><see cref="Popup" /> is a base class for contextual windows and panels with fixed position. It's a modal by default (see <see cref="Window.PopupWindow" />) and provides methods for implementing custom popup behavior.</para>
/// </summary>
public interface IPopup : IWindow {

}