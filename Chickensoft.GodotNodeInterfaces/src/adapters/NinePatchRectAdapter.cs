namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>Also known as 9-slice panels, <see cref="NinePatchRect" /> produces clean panels of any size based on a small texture. To do so, it splits the texture in a 3×3 grid. When you scale the node, it tiles the texture's edges horizontally or vertically, tiles the center on both axes, and leaves the corners unchanged.</para>
/// </summary>
public class NinePatchRectAdapter : ControlAdapter, INinePatchRect {
  private readonly NinePatchRect _node;

  public NinePatchRectAdapter(NinePatchRect node) : base(node) { _node = node; }

    /// <summary>
    /// <para>The stretch mode to use for horizontal stretching/tiling. See <see cref="NinePatchRect.AxisStretchMode" /> for possible values.</para>
    /// </summary>
    public NinePatchRect.AxisStretchMode AxisStretchHorizontal { get => _node.AxisStretchHorizontal; set => _node.AxisStretchHorizontal = value; }
    /// <summary>
    /// <para>The stretch mode to use for vertical stretching/tiling. See <see cref="NinePatchRect.AxisStretchMode" /> for possible values.</para>
    /// </summary>
    public NinePatchRect.AxisStretchMode AxisStretchVertical { get => _node.AxisStretchVertical; set => _node.AxisStretchVertical = value; }
    /// <summary>
    /// <para>If <c>true</c>, draw the panel's center. Else, only draw the 9-slice's borders.</para>
    /// </summary>
    public bool DrawCenter { get => _node.DrawCenter; set => _node.DrawCenter = value; }
    /// <summary>
    /// <para>The height of the 9-slice's bottom row. A margin of 16 means the 9-slice's bottom corners and side will have a height of 16 pixels. You can set all 4 margin values individually to create panels with non-uniform borders.</para>
    /// </summary>
    public int PatchMarginBottom { get => _node.PatchMarginBottom; set => _node.PatchMarginBottom = value; }
    /// <summary>
    /// <para>The width of the 9-slice's left column. A margin of 16 means the 9-slice's left corners and side will have a width of 16 pixels. You can set all 4 margin values individually to create panels with non-uniform borders.</para>
    /// </summary>
    public int PatchMarginLeft { get => _node.PatchMarginLeft; set => _node.PatchMarginLeft = value; }
    /// <summary>
    /// <para>The width of the 9-slice's right column. A margin of 16 means the 9-slice's right corners and side will have a width of 16 pixels. You can set all 4 margin values individually to create panels with non-uniform borders.</para>
    /// </summary>
    public int PatchMarginRight { get => _node.PatchMarginRight; set => _node.PatchMarginRight = value; }
    /// <summary>
    /// <para>The height of the 9-slice's top row. A margin of 16 means the 9-slice's top corners and side will have a height of 16 pixels. You can set all 4 margin values individually to create panels with non-uniform borders.</para>
    /// </summary>
    public int PatchMarginTop { get => _node.PatchMarginTop; set => _node.PatchMarginTop = value; }
    /// <summary>
    /// <para>Rectangular region of the texture to sample from. If you're working with an atlas, use this property to define the area the 9-slice should use. All other properties are relative to this one. If the rect is empty, NinePatchRect will use the whole texture.</para>
    /// </summary>
    public Rect2 RegionRect { get => _node.RegionRect; set => _node.RegionRect = value; }
    /// <summary>
    /// <para>The node's texture resource.</para>
    /// </summary>
    public Texture2D Texture { get => _node.Texture; set => _node.Texture = value; }

}