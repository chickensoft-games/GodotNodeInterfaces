namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class TextureProgressBarNode : TextureProgressBar, ITextureProgressBar { }

/// <summary>
/// <para>TextureProgressBar works like <see cref="ProgressBar" />, but uses up to 3 textures instead of Godot's <see cref="Theme" /> resource. It can be used to create horizontal, vertical and radial progress bars.</para>
/// </summary>
public interface ITextureProgressBar : IRange {
    /// <summary>
    /// <para>The fill direction. See <see cref="TextureProgressBar.FillModeEnum" /> for possible values.</para>
    /// </summary>
    int FillMode { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, Godot treats the bar's textures like in <see cref="NinePatchRect" />. Use the <c>stretch_margin_*</c> properties like <see cref="TextureProgressBar.StretchMarginBottom" /> to set up the nine patch's 3×3 grid. When using a radial <see cref="TextureProgressBar.FillMode" />, this setting will enable stretching.</para>
    /// </summary>
    bool NinePatchStretch { get; set; }
    /// <summary>
    /// <para>Offsets <see cref="TextureProgressBar.TextureProgress" /> if <see cref="TextureProgressBar.FillMode" /> is <see cref="TextureProgressBar.FillModeEnum.Clockwise" /> or <see cref="TextureProgressBar.FillModeEnum.CounterClockwise" />.</para>
    /// </summary>
    Vector2 RadialCenterOffset { get; set; }
    /// <summary>
    /// <para>Upper limit for the fill of <see cref="TextureProgressBar.TextureProgress" /> if <see cref="TextureProgressBar.FillMode" /> is <see cref="TextureProgressBar.FillModeEnum.Clockwise" /> or <see cref="TextureProgressBar.FillModeEnum.CounterClockwise" />. When the node's <c>value</c> is equal to its <c>max_value</c>, the texture fills up to this angle.</para>
    /// <para>See <see cref="Range.Value" />, <see cref="Range.MaxValue" />.</para>
    /// </summary>
    float RadialFillDegrees { get; set; }
    /// <summary>
    /// <para>Starting angle for the fill of <see cref="TextureProgressBar.TextureProgress" /> if <see cref="TextureProgressBar.FillMode" /> is <see cref="TextureProgressBar.FillModeEnum.Clockwise" /> or <see cref="TextureProgressBar.FillModeEnum.CounterClockwise" />. When the node's <c>value</c> is equal to its <c>min_value</c>, the texture doesn't show up at all. When the <c>value</c> increases, the texture fills and tends towards <see cref="TextureProgressBar.RadialFillDegrees" />.</para>
    /// </summary>
    float RadialInitialAngle { get; set; }
    /// <summary>
    /// <para>The height of the 9-patch's bottom row. A margin of 16 means the 9-slice's bottom corners and side will have a height of 16 pixels. You can set all 4 margin values individually to create panels with non-uniform borders.</para>
    /// </summary>
    int StretchMarginBottom { get; set; }
    /// <summary>
    /// <para>The width of the 9-patch's left column.</para>
    /// </summary>
    int StretchMarginLeft { get; set; }
    /// <summary>
    /// <para>The width of the 9-patch's right column.</para>
    /// </summary>
    int StretchMarginRight { get; set; }
    /// <summary>
    /// <para>The height of the 9-patch's top row.</para>
    /// </summary>
    int StretchMarginTop { get; set; }
    /// <summary>
    /// <para><see cref="Texture2D" /> that draws over the progress bar. Use it to add highlights or an upper-frame that hides part of <see cref="TextureProgressBar.TextureProgress" />.</para>
    /// </summary>
    Texture2D TextureOver { get; set; }
    /// <summary>
    /// <para><see cref="Texture2D" /> that clips based on the node's <c>value</c> and <see cref="TextureProgressBar.FillMode" />. As <c>value</c> increased, the texture fills up. It shows entirely when <c>value</c> reaches <c>max_value</c>. It doesn't show at all if <c>value</c> is equal to <c>min_value</c>.</para>
    /// <para>The <c>value</c> property comes from <see cref="Range" />. See <see cref="Range.Value" />, <see cref="Range.MinValue" />, <see cref="Range.MaxValue" />.</para>
    /// </summary>
    Texture2D TextureProgress { get; set; }
    /// <summary>
    /// <para>The offset of <see cref="TextureProgressBar.TextureProgress" />. Useful for <see cref="TextureProgressBar.TextureOver" /> and <see cref="TextureProgressBar.TextureUnder" /> with fancy borders, to avoid transparent margins in your progress texture.</para>
    /// </summary>
    Vector2 TextureProgressOffset { get; set; }
    /// <summary>
    /// <para><see cref="Texture2D" /> that draws under the progress bar. The bar's background.</para>
    /// </summary>
    Texture2D TextureUnder { get; set; }
    /// <summary>
    /// <para>Multiplies the color of the bar's <see cref="TextureProgressBar.TextureOver" /> texture. The effect is similar to <see cref="CanvasItem.Modulate" />, except it only affects this specific texture instead of the entire node.</para>
    /// </summary>
    Color TintOver { get; set; }
    /// <summary>
    /// <para>Multiplies the color of the bar's <see cref="TextureProgressBar.TextureProgress" /> texture.</para>
    /// </summary>
    Color TintProgress { get; set; }
    /// <summary>
    /// <para>Multiplies the color of the bar's <see cref="TextureProgressBar.TextureUnder" /> texture.</para>
    /// </summary>
    Color TintUnder { get; set; }

}