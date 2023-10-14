namespace Chickensoft.GodotNodeInterfaces;

using Godot;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class PanelNode : Panel, IPanel { }

/// <summary>
/// <para><see cref="Panel" /> is a GUI control that displays a <see cref="StyleBox" />. See also <see cref="PanelContainer" />.</para>
/// </summary>
public interface IPanel : IControl {

}