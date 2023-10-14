namespace Chickensoft.GodotNodeInterfaces;

using Godot;


/// <summary>
/// <para><see cref="CheckButton" /> is a toggle button displayed as a check field. It's similar to <see cref="CheckBox" /> in functionality, but it has a different appearance. To follow established UX patterns, it's recommended to use <see cref="CheckButton" /> when toggling it has an <b>immediate</b> effect on something. For example, it can be used when pressing it shows or hides advanced settings, without asking the user to confirm this action.</para>
/// <para>See also <see cref="BaseButton" /> which contains common properties and methods associated with this node.</para>
/// </summary>
public interface ICheckButton : IButton {

}