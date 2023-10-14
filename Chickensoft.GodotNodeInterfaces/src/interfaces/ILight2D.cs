namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>Casts light in a 2D environment. A light is defined as a color, an energy value, a mode (see constants), and various other parameters (range and shadows-related).</para>
/// </summary>
public interface ILight2D : INode2D {
    /// <summary>
    /// <para>The Light2D's blend mode. See <see cref="Light2D.BlendModeEnum" /> constants for values.</para>
    /// </summary>
    Light2D.BlendModeEnum BlendMode { get; set; }
    /// <summary>
    /// <para>The Light2D's <see cref="Color" />.</para>
    /// </summary>
    Color Color { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, Light2D will only appear when editing the scene.</para>
    /// </summary>
    bool EditorOnly { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, Light2D will emit light.</para>
    /// </summary>
    bool Enabled { get; set; }
    /// <summary>
    /// <para>The Light2D's energy value. The larger the value, the stronger the light.</para>
    /// </summary>
    float Energy { get; set; }
    /// <summary>
    /// <para>Returns the light's height, which is used in 2D normal mapping. See <see cref="PointLight2D.Height" /> and <see cref="DirectionalLight2D.Height" />.</para>
    /// </summary>
    float GetHeight();
    /// <summary>
    /// <para>The layer mask. Only objects with a matching <see cref="CanvasItem.LightMask" /> will be affected by the Light2D. See also <see cref="Light2D.ShadowItemCullMask" />, which affects which objects can cast shadows.</para>
    /// <para><b>Note:</b> <see cref="Light2D.RangeItemCullMask" /> is ignored by <see cref="DirectionalLight2D" />, which will always light a 2D node regardless of the 2D node's <see cref="CanvasItem.LightMask" />.</para>
    /// </summary>
    int RangeItemCullMask { get; set; }
    /// <summary>
    /// <para>Maximum layer value of objects that are affected by the Light2D.</para>
    /// </summary>
    int RangeLayerMax { get; set; }
    /// <summary>
    /// <para>Minimum layer value of objects that are affected by the Light2D.</para>
    /// </summary>
    int RangeLayerMin { get; set; }
    /// <summary>
    /// <para>Maximum <c>z</c> value of objects that are affected by the Light2D.</para>
    /// </summary>
    int RangeZMax { get; set; }
    /// <summary>
    /// <para>Minimum <c>z</c> value of objects that are affected by the Light2D.</para>
    /// </summary>
    int RangeZMin { get; set; }
    /// <summary>
    /// <para>Sets the light's height, which is used in 2D normal mapping. See <see cref="PointLight2D.Height" /> and <see cref="DirectionalLight2D.Height" />.</para>
    /// </summary>
    void SetHeight(float height);
    /// <summary>
    /// <para><see cref="Color" /> of shadows cast by the Light2D.</para>
    /// </summary>
    Color ShadowColor { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the Light2D will cast shadows.</para>
    /// </summary>
    bool ShadowEnabled { get; set; }
    /// <summary>
    /// <para>Shadow filter type. See <see cref="Light2D.ShadowFilterEnum" /> for possible values.</para>
    /// </summary>
    Light2D.ShadowFilterEnum ShadowFilter { get; set; }
    /// <summary>
    /// <para>Smoothing value for shadows. Higher values will result in softer shadows, at the cost of visible streaks that can appear in shadow rendering. <see cref="Light2D.ShadowFilterSmooth" /> only has an effect if <see cref="Light2D.ShadowFilter" /> is <see cref="Light2D.ShadowFilterEnum.Pcf5" /> or <see cref="Light2D.ShadowFilterEnum.Pcf13" />.</para>
    /// </summary>
    float ShadowFilterSmooth { get; set; }
    /// <summary>
    /// <para>The shadow mask. Used with <see cref="LightOccluder2D" /> to cast shadows. Only occluders with a matching <see cref="CanvasItem.LightMask" /> will cast shadows. See also <see cref="Light2D.RangeItemCullMask" />, which affects which objects can <i>receive</i> the light.</para>
    /// </summary>
    int ShadowItemCullMask { get; set; }

}