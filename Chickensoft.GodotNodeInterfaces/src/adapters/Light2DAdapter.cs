namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>Casts light in a 2D environment. A light is defined as a color, an energy value, a mode (see constants), and various other parameters (range and shadows-related).</para>
/// </summary>
public class Light2DAdapter : Node2DAdapter, ILight2D {
  private readonly Light2D _node;

  public Light2DAdapter(Light2D node) : base(node) { _node = node; }

    /// <summary>
    /// <para>The Light2D's blend mode. See <see cref="Light2D.BlendModeEnum" /> constants for values.</para>
    /// </summary>
    public Light2D.BlendModeEnum BlendMode { get => _node.BlendMode; set => _node.BlendMode = value; }
    /// <summary>
    /// <para>The Light2D's <see cref="Color" />.</para>
    /// </summary>
    public Color Color { get => _node.Color; set => _node.Color = value; }
    /// <summary>
    /// <para>If <c>true</c>, Light2D will only appear when editing the scene.</para>
    /// </summary>
    public bool EditorOnly { get => _node.EditorOnly; set => _node.EditorOnly = value; }
    /// <summary>
    /// <para>If <c>true</c>, Light2D will emit light.</para>
    /// </summary>
    public bool Enabled { get => _node.Enabled; set => _node.Enabled = value; }
    /// <summary>
    /// <para>The Light2D's energy value. The larger the value, the stronger the light.</para>
    /// </summary>
    public float Energy { get => _node.Energy; set => _node.Energy = value; }
    /// <summary>
    /// <para>Returns the light's height, which is used in 2D normal mapping. See <see cref="PointLight2D.Height" /> and <see cref="DirectionalLight2D.Height" />.</para>
    /// </summary>
    public float GetHeight() => _node.GetHeight();
    /// <summary>
    /// <para>The layer mask. Only objects with a matching <see cref="CanvasItem.LightMask" /> will be affected by the Light2D. See also <see cref="Light2D.ShadowItemCullMask" />, which affects which objects can cast shadows.</para>
    /// <para><b>Note:</b> <see cref="Light2D.RangeItemCullMask" /> is ignored by <see cref="DirectionalLight2D" />, which will always light a 2D node regardless of the 2D node's <see cref="CanvasItem.LightMask" />.</para>
    /// </summary>
    public int RangeItemCullMask { get => _node.RangeItemCullMask; set => _node.RangeItemCullMask = value; }
    /// <summary>
    /// <para>Maximum layer value of objects that are affected by the Light2D.</para>
    /// </summary>
    public int RangeLayerMax { get => _node.RangeLayerMax; set => _node.RangeLayerMax = value; }
    /// <summary>
    /// <para>Minimum layer value of objects that are affected by the Light2D.</para>
    /// </summary>
    public int RangeLayerMin { get => _node.RangeLayerMin; set => _node.RangeLayerMin = value; }
    /// <summary>
    /// <para>Maximum <c>z</c> value of objects that are affected by the Light2D.</para>
    /// </summary>
    public int RangeZMax { get => _node.RangeZMax; set => _node.RangeZMax = value; }
    /// <summary>
    /// <para>Minimum <c>z</c> value of objects that are affected by the Light2D.</para>
    /// </summary>
    public int RangeZMin { get => _node.RangeZMin; set => _node.RangeZMin = value; }
    /// <summary>
    /// <para>Sets the light's height, which is used in 2D normal mapping. See <see cref="PointLight2D.Height" /> and <see cref="DirectionalLight2D.Height" />.</para>
    /// </summary>
    public void SetHeight(float height) => _node.SetHeight(height);
    /// <summary>
    /// <para><see cref="Color" /> of shadows cast by the Light2D.</para>
    /// </summary>
    public Color ShadowColor { get => _node.ShadowColor; set => _node.ShadowColor = value; }
    /// <summary>
    /// <para>If <c>true</c>, the Light2D will cast shadows.</para>
    /// </summary>
    public bool ShadowEnabled { get => _node.ShadowEnabled; set => _node.ShadowEnabled = value; }
    /// <summary>
    /// <para>Shadow filter type. See <see cref="Light2D.ShadowFilterEnum" /> for possible values.</para>
    /// </summary>
    public Light2D.ShadowFilterEnum ShadowFilter { get => _node.ShadowFilter; set => _node.ShadowFilter = value; }
    /// <summary>
    /// <para>Smoothing value for shadows. Higher values will result in softer shadows, at the cost of visible streaks that can appear in shadow rendering. <see cref="Light2D.ShadowFilterSmooth" /> only has an effect if <see cref="Light2D.ShadowFilter" /> is <see cref="Light2D.ShadowFilterEnum.Pcf5" /> or <see cref="Light2D.ShadowFilterEnum.Pcf13" />.</para>
    /// </summary>
    public float ShadowFilterSmooth { get => _node.ShadowFilterSmooth; set => _node.ShadowFilterSmooth = value; }
    /// <summary>
    /// <para>The shadow mask. Used with <see cref="LightOccluder2D" /> to cast shadows. Only occluders with a matching <see cref="CanvasItem.LightMask" /> will cast shadows. See also <see cref="Light2D.RangeItemCullMask" />, which affects which objects can <i>receive</i> the light.</para>
    /// </summary>
    public int ShadowItemCullMask { get => _node.ShadowItemCullMask; set => _node.ShadowItemCullMask = value; }

}