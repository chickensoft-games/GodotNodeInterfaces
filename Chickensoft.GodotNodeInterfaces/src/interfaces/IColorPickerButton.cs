namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class ColorPickerButtonNode : ColorPickerButton, IColorPickerButton { }

/// <summary>
/// <para>Encapsulates a <see cref="ColorPicker" />, making it accessible by pressing a button. Pressing the button will toggle the <see cref="ColorPicker" />'s visibility.</para>
/// <para>See also <see cref="BaseButton" /> which contains common properties and methods associated with this node.</para>
/// <para><b>Note:</b> By default, the button may not be wide enough for the color preview swatch to be visible. Make sure to set <see cref="Control.CustomMinimumSize" /> to a big enough value to give the button enough space.</para>
/// </summary>
public interface IColorPickerButton : IButton {
    /// <summary>
    /// <para>The currently selected color.</para>
    /// </summary>
    Color Color { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the alpha channel in the displayed <see cref="ColorPicker" /> will be visible.</para>
    /// </summary>
    bool EditAlpha { get; set; }
    /// <summary>
    /// <para>Returns the <see cref="ColorPicker" /> that this node toggles.</para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash. If you wish to hide it or any of its children, use their <see cref="CanvasItem.Visible" /> property.</para>
    /// </summary>
    ColorPicker GetPicker();
    /// <summary>
    /// <para>Returns the control's <see cref="PopupPanel" /> which allows you to connect to popup signals. This allows you to handle events when the ColorPicker is shown or hidden.</para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash. If you wish to hide it or any of its children, use their <see cref="Window.Visible" /> property.</para>
    /// </summary>
    PopupPanel GetPopup();

}