namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>Also known as 9-slice panels, <see cref="NinePatchRect" /> produces clean panels of any size based on a small texture. To do so, it splits the texture in a 3×3 grid. When you scale the node, it tiles the texture's edges horizontally or vertically, tiles the center on both axes, and leaves the corners unchanged.</para>
/// </summary>
public interface INinePatchRect : IControl {
    /// <summary>
    /// <para>The node's texture resource.</para>
    /// </summary>
    Texture2D Texture { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, draw the panel's center. Else, only draw the 9-slice's borders.</para>
    /// </summary>
    bool DrawCenter { get; set; }
    /// <summary>
    /// <para>Rectangular region of the texture to sample from. If you're working with an atlas, use this property to define the area the 9-slice should use. All other properties are relative to this one. If the rect is empty, NinePatchRect will use the whole texture.</para>
    /// </summary>
    Rect2 RegionRect { get; set; }
    /// <summary>
    /// <para>The width of the 9-slice's left column. A margin of 16 means the 9-slice's left corners and side will have a width of 16 pixels. You can set all 4 margin values individually to create panels with non-uniform borders.</para>
    /// </summary>
    int PatchMarginLeft { get; set; }
    /// <summary>
    /// <para>The height of the 9-slice's top row. A margin of 16 means the 9-slice's top corners and side will have a height of 16 pixels. You can set all 4 margin values individually to create panels with non-uniform borders.</para>
    /// </summary>
    int PatchMarginTop { get; set; }
    /// <summary>
    /// <para>The width of the 9-slice's right column. A margin of 16 means the 9-slice's right corners and side will have a width of 16 pixels. You can set all 4 margin values individually to create panels with non-uniform borders.</para>
    /// </summary>
    int PatchMarginRight { get; set; }
    /// <summary>
    /// <para>The height of the 9-slice's bottom row. A margin of 16 means the 9-slice's bottom corners and side will have a height of 16 pixels. You can set all 4 margin values individually to create panels with non-uniform borders.</para>
    /// </summary>
    int PatchMarginBottom { get; set; }
    /// <summary>
    /// <para>The stretch mode to use for horizontal stretching/tiling. See <see cref="NinePatchRect.AxisStretchMode" /> for possible values.</para>
    /// </summary>
    NinePatchRect.AxisStretchMode AxisStretchHorizontal { get; set; }
    /// <summary>
    /// <para>The stretch mode to use for vertical stretching/tiling. See <see cref="NinePatchRect.AxisStretchMode" /> for possible values.</para>
    /// </summary>
    NinePatchRect.AxisStretchMode AxisStretchVertical { get; set; }

}