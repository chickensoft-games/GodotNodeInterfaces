namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A widget that provides an interface for selecting or modifying a color. It can optionally provide functionalities like a color sampler (eyedropper), color modes, and presets.</para>
/// <para><b>Note:</b> This control is the color picker widget itself. You can use a <see cref="ColorPickerButton" /> instead if you need a button that brings up a <see cref="ColorPicker" /> in a popup.</para>
/// </summary>
public class ColorPickerAdapter : VBoxContainerAdapter, IColorPicker {
  private readonly ColorPicker _node;

  public ColorPickerAdapter(ColorPicker node) : base(node) { _node = node; }

    /// <summary>
    /// <para>Adds the given color to a list of color presets. The presets are displayed in the color picker and the user will be able to select them.</para>
    /// <para><b>Note:</b> The presets list is only for <i>this</i> color picker.</para>
    /// </summary>
    public void AddPreset(Color color) => _node.AddPreset(color);
    /// <summary>
    /// <para>Adds the given color to a list of color recent presets so that it can be picked later. Recent presets are the colors that were picked recently, a new preset is automatically created and added to recent presets when you pick a new color.</para>
    /// <para><b>Note:</b> The recent presets list is only for <i>this</i> color picker.</para>
    /// </summary>
    public void AddRecentPreset(Color color) => _node.AddRecentPreset(color);
    /// <summary>
    /// <para>If <c>true</c>, it's possible to add presets under Swatches. If <c>false</c>, the button to add presets is disabled.</para>
    /// </summary>
    public bool CanAddSwatches { get => _node.CanAddSwatches; set => _node.CanAddSwatches = value; }
    /// <summary>
    /// <para>The currently selected color.</para>
    /// </summary>
    public Color Color { get => _node.Color; set => _node.Color = value; }
    /// <summary>
    /// <para>The currently selected color mode. See <see cref="ColorPicker.ColorModeType" />.</para>
    /// </summary>
    public ColorPicker.ColorModeType ColorMode { get => _node.ColorMode; set => _node.ColorMode = value; }
    /// <summary>
    /// <para>If <c>true</c>, the color mode buttons are visible.</para>
    /// </summary>
    public bool ColorModesVisible { get => _node.ColorModesVisible; set => _node.ColorModesVisible = value; }
    /// <summary>
    /// <para>If <c>true</c>, the color will apply only after the user releases the mouse button, otherwise it will apply immediately even in mouse motion event (which can cause performance issues).</para>
    /// </summary>
    public bool DeferredMode { get => _node.DeferredMode; set => _node.DeferredMode = value; }
    /// <summary>
    /// <para>If <c>true</c>, shows an alpha channel slider (opacity).</para>
    /// </summary>
    public bool EditAlpha { get => _node.EditAlpha; set => _node.EditAlpha = value; }
    /// <summary>
    /// <para>Removes the given color from the list of color presets of this color picker.</para>
    /// </summary>
    public void ErasePreset(Color color) => _node.ErasePreset(color);
    /// <summary>
    /// <para>Removes the given color from the list of color recent presets of this color picker.</para>
    /// </summary>
    public void EraseRecentPreset(Color color) => _node.EraseRecentPreset(color);
    /// <summary>
    /// <para>Returns the list of colors in the presets of the color picker.</para>
    /// </summary>
    public Color[] GetPresets() => _node.GetPresets();
    /// <summary>
    /// <para>Returns the list of colors in the recent presets of the color picker.</para>
    /// </summary>
    public Color[] GetRecentPresets() => _node.GetRecentPresets();
    /// <summary>
    /// <para>If <c>true</c>, the hex color code input field is visible.</para>
    /// </summary>
    public bool HexVisible { get => _node.HexVisible; set => _node.HexVisible = value; }
    /// <summary>
    /// <para>The shape of the color space view. See <see cref="ColorPicker.PickerShapeType" />.</para>
    /// </summary>
    public ColorPicker.PickerShapeType PickerShape { get => _node.PickerShape; set => _node.PickerShape = value; }
    /// <summary>
    /// <para>If <c>true</c>, the Swatches and Recent Colors presets are visible.</para>
    /// </summary>
    public bool PresetsVisible { get => _node.PresetsVisible; set => _node.PresetsVisible = value; }
    /// <summary>
    /// <para>If <c>true</c>, the color sampler and color preview are visible.</para>
    /// </summary>
    public bool SamplerVisible { get => _node.SamplerVisible; set => _node.SamplerVisible = value; }
    /// <summary>
    /// <para>If <c>true</c>, the color sliders are visible.</para>
    /// </summary>
    public bool SlidersVisible { get => _node.SlidersVisible; set => _node.SlidersVisible = value; }

}