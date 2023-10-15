namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>TextureProgressBar works like <see cref="ProgressBar" />, but uses up to 3 textures instead of Godot's <see cref="Theme" /> resource. It can be used to create horizontal, vertical and radial progress bars.</para>
/// </summary>
public class TextureProgressBarAdapter : RangeAdapter, ITextureProgressBar {
  private readonly TextureProgressBar _node;

  public TextureProgressBarAdapter(Node node) : base(node) {
    if (node is not TextureProgressBar typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a TextureProgressBar"
      );
    }
    _node = typedNode;
  }

    /// <summary>
    /// <para>The fill direction. See <see cref="TextureProgressBar.FillModeEnum" /> for possible values.</para>
    /// </summary>
    public int FillMode { get => _node.FillMode; set => _node.FillMode = value; }
    /// <summary>
    /// <para>If <c>true</c>, Godot treats the bar's textures like in <see cref="NinePatchRect" />. Use the <c>stretch_margin_*</c> properties like <see cref="TextureProgressBar.StretchMarginBottom" /> to set up the nine patch's 3×3 grid. When using a radial <see cref="TextureProgressBar.FillMode" />, this setting will enable stretching.</para>
    /// </summary>
    public bool NinePatchStretch { get => _node.NinePatchStretch; set => _node.NinePatchStretch = value; }
    /// <summary>
    /// <para>Offsets <see cref="TextureProgressBar.TextureProgress" /> if <see cref="TextureProgressBar.FillMode" /> is <see cref="TextureProgressBar.FillModeEnum.Clockwise" /> or <see cref="TextureProgressBar.FillModeEnum.CounterClockwise" />.</para>
    /// </summary>
    public Vector2 RadialCenterOffset { get => _node.RadialCenterOffset; set => _node.RadialCenterOffset = value; }
    /// <summary>
    /// <para>Upper limit for the fill of <see cref="TextureProgressBar.TextureProgress" /> if <see cref="TextureProgressBar.FillMode" /> is <see cref="TextureProgressBar.FillModeEnum.Clockwise" /> or <see cref="TextureProgressBar.FillModeEnum.CounterClockwise" />. When the node's <c>value</c> is equal to its <c>max_value</c>, the texture fills up to this angle.</para>
    /// <para>See <see cref="Range.Value" />, <see cref="Range.MaxValue" />.</para>
    /// </summary>
    public float RadialFillDegrees { get => _node.RadialFillDegrees; set => _node.RadialFillDegrees = value; }
    /// <summary>
    /// <para>Starting angle for the fill of <see cref="TextureProgressBar.TextureProgress" /> if <see cref="TextureProgressBar.FillMode" /> is <see cref="TextureProgressBar.FillModeEnum.Clockwise" /> or <see cref="TextureProgressBar.FillModeEnum.CounterClockwise" />. When the node's <c>value</c> is equal to its <c>min_value</c>, the texture doesn't show up at all. When the <c>value</c> increases, the texture fills and tends towards <see cref="TextureProgressBar.RadialFillDegrees" />.</para>
    /// </summary>
    public float RadialInitialAngle { get => _node.RadialInitialAngle; set => _node.RadialInitialAngle = value; }
    /// <summary>
    /// <para>The height of the 9-patch's bottom row. A margin of 16 means the 9-slice's bottom corners and side will have a height of 16 pixels. You can set all 4 margin values individually to create panels with non-uniform borders.</para>
    /// </summary>
    public int StretchMarginBottom { get => _node.StretchMarginBottom; set => _node.StretchMarginBottom = value; }
    /// <summary>
    /// <para>The width of the 9-patch's left column.</para>
    /// </summary>
    public int StretchMarginLeft { get => _node.StretchMarginLeft; set => _node.StretchMarginLeft = value; }
    /// <summary>
    /// <para>The width of the 9-patch's right column.</para>
    /// </summary>
    public int StretchMarginRight { get => _node.StretchMarginRight; set => _node.StretchMarginRight = value; }
    /// <summary>
    /// <para>The height of the 9-patch's top row.</para>
    /// </summary>
    public int StretchMarginTop { get => _node.StretchMarginTop; set => _node.StretchMarginTop = value; }
    /// <summary>
    /// <para><see cref="Texture2D" /> that draws over the progress bar. Use it to add highlights or an upper-frame that hides part of <see cref="TextureProgressBar.TextureProgress" />.</para>
    /// </summary>
    public Texture2D TextureOver { get => _node.TextureOver; set => _node.TextureOver = value; }
    /// <summary>
    /// <para><see cref="Texture2D" /> that clips based on the node's <c>value</c> and <see cref="TextureProgressBar.FillMode" />. As <c>value</c> increased, the texture fills up. It shows entirely when <c>value</c> reaches <c>max_value</c>. It doesn't show at all if <c>value</c> is equal to <c>min_value</c>.</para>
    /// <para>The <c>value</c> property comes from <see cref="Range" />. See <see cref="Range.Value" />, <see cref="Range.MinValue" />, <see cref="Range.MaxValue" />.</para>
    /// </summary>
    public Texture2D TextureProgress { get => _node.TextureProgress; set => _node.TextureProgress = value; }
    /// <summary>
    /// <para>The offset of <see cref="TextureProgressBar.TextureProgress" />. Useful for <see cref="TextureProgressBar.TextureOver" /> and <see cref="TextureProgressBar.TextureUnder" /> with fancy borders, to avoid transparent margins in your progress texture.</para>
    /// </summary>
    public Vector2 TextureProgressOffset { get => _node.TextureProgressOffset; set => _node.TextureProgressOffset = value; }
    /// <summary>
    /// <para><see cref="Texture2D" /> that draws under the progress bar. The bar's background.</para>
    /// </summary>
    public Texture2D TextureUnder { get => _node.TextureUnder; set => _node.TextureUnder = value; }
    /// <summary>
    /// <para>Multiplies the color of the bar's <see cref="TextureProgressBar.TextureOver" /> texture. The effect is similar to <see cref="CanvasItem.Modulate" />, except it only affects this specific texture instead of the entire node.</para>
    /// </summary>
    public Color TintOver { get => _node.TintOver; set => _node.TintOver = value; }
    /// <summary>
    /// <para>Multiplies the color of the bar's <see cref="TextureProgressBar.TextureProgress" /> texture.</para>
    /// </summary>
    public Color TintProgress { get => _node.TintProgress; set => _node.TintProgress = value; }
    /// <summary>
    /// <para>Multiplies the color of the bar's <see cref="TextureProgressBar.TextureUnder" /> texture.</para>
    /// </summary>
    public Color TintUnder { get => _node.TintUnder; set => _node.TintUnder = value; }

}