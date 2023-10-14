namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>A widget that provides an interface for selecting or modifying a color. It can optionally provide functionalities like a color sampler (eyedropper), color modes, and presets.</para>
/// <para><b>Note:</b> This control is the color picker widget itself. You can use a <see cref="ColorPickerButton" /> instead if you need a button that brings up a <see cref="ColorPicker" /> in a popup.</para>
/// </summary>
public interface IColorPicker : IVBoxContainer {
    /// <summary>
    /// <para>Adds the given color to a list of color presets. The presets are displayed in the color picker and the user will be able to select them.</para>
    /// <para><b>Note:</b> The presets list is only for <i>this</i> color picker.</para>
    /// </summary>
    void AddPreset(Color color);
    /// <summary>
    /// <para>Removes the given color from the list of color presets of this color picker.</para>
    /// </summary>
    void ErasePreset(Color color);
    /// <summary>
    /// <para>Returns the list of colors in the presets of the color picker.</para>
    /// </summary>
    Color[] GetPresets();
    /// <summary>
    /// <para>Adds the given color to a list of color recent presets so that it can be picked later. Recent presets are the colors that were picked recently, a new preset is automatically created and added to recent presets when you pick a new color.</para>
    /// <para><b>Note:</b> The recent presets list is only for <i>this</i> color picker.</para>
    /// </summary>
    void AddRecentPreset(Color color);
    /// <summary>
    /// <para>Removes the given color from the list of color recent presets of this color picker.</para>
    /// </summary>
    void EraseRecentPreset(Color color);
    /// <summary>
    /// <para>Returns the list of colors in the recent presets of the color picker.</para>
    /// </summary>
    Color[] GetRecentPresets();
    /// <summary>
    /// <para>The currently selected color.</para>
    /// </summary>
    Color Color { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, shows an alpha channel slider (opacity).</para>
    /// </summary>
    bool EditAlpha { get; set; }
    /// <summary>
    /// <para>The currently selected color mode. See <see cref="ColorPicker.ColorModeType" />.</para>
    /// </summary>
    ColorPicker.ColorModeType ColorMode { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the color will apply only after the user releases the mouse button, otherwise it will apply immediately even in mouse motion event (which can cause performance issues).</para>
    /// </summary>
    bool DeferredMode { get; set; }
    /// <summary>
    /// <para>The shape of the color space view. See <see cref="ColorPicker.PickerShapeType" />.</para>
    /// </summary>
    ColorPicker.PickerShapeType PickerShape { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, it's possible to add presets under Swatches. If <c>false</c>, the button to add presets is disabled.</para>
    /// </summary>
    bool CanAddSwatches { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the color sampler and color preview are visible.</para>
    /// </summary>
    bool SamplerVisible { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the color mode buttons are visible.</para>
    /// </summary>
    bool ColorModesVisible { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the color sliders are visible.</para>
    /// </summary>
    bool SlidersVisible { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the hex color code input field is visible.</para>
    /// </summary>
    bool HexVisible { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the Swatches and Recent Colors presets are visible.</para>
    /// </summary>
    bool PresetsVisible { get; set; }

}