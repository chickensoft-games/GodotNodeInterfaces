namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para><see cref="BaseButton" /> is an abstract base class for GUI buttons. It doesn't display anything by itself.</para>
/// </summary>
public class BaseButtonAdapter : BaseButton, IBaseButton {
  private readonly BaseButton _node;

  public BaseButtonAdapter(BaseButton node) => _node = node;
    /// <summary>
    /// <para>Called when the button is pressed. If you need to know the button's pressed state (and <see cref="BaseButton.ToggleMode" /> is active), use <see cref="BaseButton._Toggled(System.Boolean)" /> instead.</para>
    /// </summary>
    public void _Pressed() => _node._Pressed();
    /// <summary>
    /// <para>Called when the button is toggled (only if <see cref="BaseButton.ToggleMode" /> is active).</para>
    /// </summary>
    public void _Toggled(bool toggledOn) => _node._Toggled(toggledOn);
    /// <summary>
    /// <para>Determines when the button is considered clicked, one of the <see cref="BaseButton.ActionModeEnum" /> constants.</para>
    /// </summary>
    public BaseButton.ActionModeEnum ActionMode { get => _node.ActionMode; set => _node.ActionMode = value; }
    /// <summary>
    /// <para>The <see cref="ButtonGroup" /> associated with the button. Not to be confused with node groups.</para>
    /// <para><b>Note:</b> The button will be configured as a radio button if a <see cref="ButtonGroup" /> is assigned to it.</para>
    /// </summary>
    public ButtonGroup ButtonGroup { get => _node.ButtonGroup; set => _node.ButtonGroup = value; }
    /// <summary>
    /// <para>Binary mask to choose which mouse buttons this button will respond to.</para>
    /// <para>To allow both left-click and right-click, use <c>MOUSE_BUTTON_MASK_LEFT | MOUSE_BUTTON_MASK_RIGHT</c>.</para>
    /// </summary>
    public MouseButtonMask ButtonMask { get => _node.ButtonMask; set => _node.ButtonMask = value; }
    /// <summary>
    /// <para>If <c>true</c>, the button's state is pressed. Means the button is pressed down or toggled (if <see cref="BaseButton.ToggleMode" /> is active). Only works if <see cref="BaseButton.ToggleMode" /> is <c>true</c>.</para>
    /// <para><b>Note:</b> Setting <see cref="BaseButton.ButtonPressed" /> will result in <see cref="BaseButton.Toggled" /> to be emitted. If you want to change the pressed state without emitting that signal, use <see cref="BaseButton.SetPressedNoSignal(System.Boolean)" />.</para>
    /// </summary>
    public bool ButtonPressed { get => _node.ButtonPressed; set => _node.ButtonPressed = value; }
    /// <summary>
    /// <para>If <c>true</c>, the button is in disabled state and can't be clicked or toggled.</para>
    /// </summary>
    public bool Disabled { get => _node.Disabled; set => _node.Disabled = value; }
    /// <summary>
    /// <para>Returns the visual state used to draw the button. This is useful mainly when implementing your own draw code by either overriding _draw() or connecting to "draw" signal. The visual state of the button is defined by the <see cref="BaseButton.DrawMode" /> enum.</para>
    /// </summary>
    public BaseButton.DrawMode GetDrawMode() => _node.GetDrawMode();
    /// <summary>
    /// <para>Returns <c>true</c> if the mouse has entered the button and has not left it yet.</para>
    /// </summary>
    public bool IsHovered() => _node.IsHovered();
    /// <summary>
    /// <para>If <c>true</c>, the button stays pressed when moving the cursor outside the button while pressing it.</para>
    /// <para><b>Note:</b> This property only affects the button's visual appearance. Signals will be emitted at the same moment regardless of this property's value.</para>
    /// </summary>
    public bool KeepPressedOutside { get => _node.KeepPressedOutside; set => _node.KeepPressedOutside = value; }
    /// <summary>
    /// <para>Changes the <see cref="BaseButton.ButtonPressed" /> state of the button, without emitting <see cref="BaseButton.Toggled" />. Use when you just want to change the state of the button without sending the pressed event (e.g. when initializing scene). Only works if <see cref="BaseButton.ToggleMode" /> is <c>true</c>.</para>
    /// <para><b>Note:</b> This method doesn't unpress other buttons in <see cref="BaseButton.ButtonGroup" />.</para>
    /// </summary>
    public void SetPressedNoSignal(bool pressed) => _node.SetPressedNoSignal(pressed);
    /// <summary>
    /// <para><see cref="Shortcut" /> associated to the button.</para>
    /// </summary>
    public Shortcut Shortcut { get => _node.Shortcut; set => _node.Shortcut = value; }
    /// <summary>
    /// <para>If <c>true</c>, the button will highlight for a short amount of time when its shortcut is activated. If <c>false</c> and <see cref="BaseButton.ToggleMode" /> is <c>false</c>, the shortcut will activate without any visual feedback.</para>
    /// </summary>
    public bool ShortcutFeedback { get => _node.ShortcutFeedback; set => _node.ShortcutFeedback = value; }
    /// <summary>
    /// <para>If <c>true</c>, the button will add information about its shortcut in the tooltip.</para>
    /// </summary>
    public bool ShortcutInTooltip { get => _node.ShortcutInTooltip; set => _node.ShortcutInTooltip = value; }
    /// <summary>
    /// <para>If <c>true</c>, the button is in toggle mode. Makes the button flip state between pressed and unpressed each time its area is clicked.</para>
    /// </summary>
    public bool ToggleMode { get => _node.ToggleMode; set => _node.ToggleMode = value; }

}