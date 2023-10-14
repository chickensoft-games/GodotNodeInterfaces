namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>Abstract base class for everything in 2D space. Canvas items are laid out in a tree; children inherit and extend their parent's transform. <see cref="CanvasItem" /> is extended by <see cref="Control" /> for GUI-related nodes, and by <see cref="Node2D" /> for 2D game objects.</para>
/// <para>Any <see cref="CanvasItem" /> can draw. For this, <see cref="CanvasItem.QueueRedraw" /> is called by the engine, then <see cref="CanvasItem.NotificationDraw" /> will be received on idle time to request a redraw. Because of this, canvas items don't need to be redrawn on every frame, improving the performance significantly. Several functions for drawing on the <see cref="CanvasItem" /> are provided (see <c>draw_*</c> functions). However, they can only be used inside <see cref="CanvasItem._Draw" />, its corresponding <see cref="GodotObject._Notification(System.Int32)" /> or methods connected to the <see cref="CanvasItem.Draw" /> signal.</para>
/// <para>Canvas items are drawn in tree order on their canvas layer. By default, children are on top of their parents, so a root <see cref="CanvasItem" /> will be drawn behind everything. This behavior can be changed on a per-item basis.</para>
/// <para>A <see cref="CanvasItem" /> can be hidden, which will also hide its children. By adjusting various other properties of a <see cref="CanvasItem" />, you can also modulate its color (via <see cref="CanvasItem.Modulate" /> or <see cref="CanvasItem.SelfModulate" />), change its Z-index, blend mode, and more.</para>
/// </summary>
public class CanvasItemAdapter : NodeAdapter, ICanvasItem {
  private readonly CanvasItem _node;

  public CanvasItemAdapter(CanvasItem node) : base(node) { _node = node; }

    /// <summary>
    /// <para>Called when <see cref="CanvasItem" /> has been requested to redraw (after <see cref="CanvasItem.QueueRedraw" /> is called, either manually or by the engine).</para>
    /// <para>Corresponds to the <see cref="CanvasItem.NotificationDraw" /> notification in <see cref="GodotObject._Notification(System.Int32)" />.</para>
    /// </summary>
    public void _Draw() => _node._Draw();
    /// <summary>
    /// <para>Allows the current node to clip children nodes, essentially acting as a mask.</para>
    /// </summary>
    public CanvasItem.ClipChildrenMode ClipChildren { get => _node.ClipChildren; set => _node.ClipChildren = value; }
    /// <summary>
    /// <para>Subsequent drawing commands will be ignored unless they fall within the specified animation slice. This is a faster way to implement animations that loop on background rather than redrawing constantly.</para>
    /// </summary>
    public void DrawAnimationSlice(double animationLength, double sliceBegin, double sliceEnd, double offset) => _node.DrawAnimationSlice(animationLength, sliceBegin, sliceEnd, offset);
    /// <summary>
    /// <para>Draws an unfilled arc between the given angles with a uniform <paramref name="color" /> and <paramref name="width" /> and optional antialiasing (supported only for positive <paramref name="width" />). The larger the value of <paramref name="pointCount" />, the smoother the curve. See also <see cref="CanvasItem.DrawCircle(Godot.Vector2,System.Single,Godot.Color)" />.</para>
    /// <para>If <paramref name="width" /> is negative, then the arc is drawn using <see cref="RenderingServer.PrimitiveType.LineStrip" />. This means that when the CanvasItem is scaled, the arc will remain thin. If this behavior is not desired, then pass a positive <paramref name="width" /> like <c>1.0</c>.</para>
    /// <para>The arc is drawn from <paramref name="startAngle" /> towards the value of <paramref name="endAngle" /> so in clockwise direction if <c>start_angle &lt; end_angle</c> and counter-clockwise otherwise. Passing the same angles but in reversed order will produce the same arc. If absolute difference of <paramref name="startAngle" /> and <paramref name="endAngle" /> is greater than <c>@GDScript.TAU</c> radians, then a full circle arc is drawn (i.e. arc will not overlap itself).</para>
    /// </summary>
    public void DrawArc(Vector2 center, float radius, float startAngle, float endAngle, int pointCount, Color color, float width, bool antialiased) => _node.DrawArc(center, radius, startAngle, endAngle, pointCount, color, width, antialiased);
    /// <summary>
    /// <para>Draws a string first character using a custom font.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1, 1, 1, 1)</c>.</param>
    public void DrawChar(Font font, Vector2 pos, string @char, int fontSize, Nullable<Color> modulate) => _node.DrawChar(font, pos, @char, fontSize, modulate);
    /// <summary>
    /// <para>Draws a string first character outline using a custom font.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1, 1, 1, 1)</c>.</param>
    public void DrawCharOutline(Font font, Vector2 pos, string @char, int fontSize, int size, Nullable<Color> modulate) => _node.DrawCharOutline(font, pos, @char, fontSize, size, modulate);
    /// <summary>
    /// <para>Draws a colored, filled circle. See also <see cref="CanvasItem.DrawArc(Godot.Vector2,System.Single,System.Single,System.Single,System.Int32,Godot.Color,System.Single,System.Boolean)" />, <see cref="CanvasItem.DrawPolyline(Godot.Vector2[],Godot.Color,System.Single,System.Boolean)" /> and <see cref="CanvasItem.DrawPolygon(Godot.Vector2[],Godot.Color[],Godot.Vector2[],Godot.Texture2D)" />.</para>
    /// </summary>
    public void DrawCircle(Vector2 position, float radius, Color color) => _node.DrawCircle(position, radius, color);
    /// <summary>
    /// <para>Draws a colored polygon of any number of points, convex or concave. Unlike <see cref="CanvasItem.DrawPolygon(Godot.Vector2[],Godot.Color[],Godot.Vector2[],Godot.Texture2D)" />, a single color must be specified for the whole polygon.</para>
    /// </summary>
    /// <param name="uvs">If the parameter is null, then the default value is <c>Array.Empty&lt;Vector2&gt;()</c>.</param>
    public void DrawColoredPolygon(Vector2[] points, Color color, Vector2[] uvs, Texture2D texture) => _node.DrawColoredPolygon(points, color, uvs, texture);
    /// <summary>
    /// <para>Draws a dashed line from a 2D point to another, with a given color and width. See also <see cref="CanvasItem.DrawMultiline(Godot.Vector2[],Godot.Color,System.Single)" /> and <see cref="CanvasItem.DrawPolyline(Godot.Vector2[],Godot.Color,System.Single,System.Boolean)" />.</para>
    /// <para>If <paramref name="width" /> is negative, then a two-point primitives will be drawn instead of a four-point ones. This means that when the CanvasItem is scaled, the line parts will remain thin. If this behavior is not desired, then pass a positive <paramref name="width" /> like <c>1.0</c>.</para>
    /// </summary>
    public void DrawDashedLine(Vector2 @from, Vector2 to, Color color, float width, float dash, bool aligned) => _node.DrawDashedLine(@from, to, color, width, dash, aligned);
    /// <summary>
    /// <para>After submitting all animations slices via <see cref="CanvasItem.DrawAnimationSlice(System.Double,System.Double,System.Double,System.Double)" />, this function can be used to revert drawing to its default state (all subsequent drawing commands will be visible). If you don't care about this particular use case, usage of this function after submitting the slices is not required.</para>
    /// </summary>
    public void DrawEndAnimation() => _node.DrawEndAnimation();
    /// <summary>
    /// <para>Draws a textured rectangle region of the font texture with LCD subpixel anti-aliasing at a given position, optionally modulated by a color.</para>
    /// <para>Texture is drawn using the following blend operation, blend mode of the <see cref="CanvasItemMaterial" /> is ignored:</para>
    /// <para><code>
    /// dst.r = texture.r * modulate.r * modulate.a + dst.r * (1.0 - texture.r * modulate.a);
    /// dst.g = texture.g * modulate.g * modulate.a + dst.g * (1.0 - texture.g * modulate.a);
    /// dst.b = texture.b * modulate.b * modulate.a + dst.b * (1.0 - texture.b * modulate.a);
    /// dst.a = modulate.a + dst.a * (1.0 - modulate.a);
    /// </code></para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1, 1, 1, 1)</c>.</param>
    public void DrawLcdTextureRectRegion(Texture2D texture, Rect2 rect, Rect2 srcRect, Nullable<Color> modulate) => _node.DrawLcdTextureRectRegion(texture, rect, srcRect, modulate);
    /// <summary>
    /// <para>Draws a line from a 2D point to another, with a given color and width. It can be optionally antialiased. See also <see cref="CanvasItem.DrawMultiline(Godot.Vector2[],Godot.Color,System.Single)" /> and <see cref="CanvasItem.DrawPolyline(Godot.Vector2[],Godot.Color,System.Single,System.Boolean)" />.</para>
    /// <para>If <paramref name="width" /> is negative, then a two-point primitive will be drawn instead of a four-point one. This means that when the CanvasItem is scaled, the line will remain thin. If this behavior is not desired, then pass a positive <paramref name="width" /> like <c>1.0</c>.</para>
    /// </summary>
    public void DrawLine(Vector2 @from, Vector2 to, Color color, float width, bool antialiased) => _node.DrawLine(@from, to, color, width, antialiased);
    /// <summary>
    /// <para>Draws a <see cref="Mesh" /> in 2D, using the provided texture. See <see cref="MeshInstance2D" /> for related documentation.</para>
    /// </summary>
    /// <param name="transform">If the parameter is null, then the default value is <c>Transform2D.Identity</c>.</param>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1, 1, 1, 1)</c>.</param>
    public void DrawMesh(Mesh mesh, Texture2D texture, Nullable<Transform2D> transform, Nullable<Color> modulate) => _node.DrawMesh(mesh, texture, transform, modulate);
    /// <summary>
    /// <para>Draws a textured rectangle region of the multi-channel signed distance field texture at a given position, optionally modulated by a color. See <see cref="FontFile.MultichannelSignedDistanceField" /> for more information and caveats about MSDF font rendering.</para>
    /// <para>If <paramref name="outline" /> is positive, each alpha channel value of pixel in region is set to maximum value of true distance in the <paramref name="outline" /> radius.</para>
    /// <para>Value of the <paramref name="pixelRange" /> should the same that was used during distance field texture generation.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1, 1, 1, 1)</c>.</param>
    public void DrawMsdfTextureRectRegion(Texture2D texture, Rect2 rect, Rect2 srcRect, Nullable<Color> modulate, double outline, double pixelRange, double scale) => _node.DrawMsdfTextureRectRegion(texture, rect, srcRect, modulate, outline, pixelRange, scale);
    /// <summary>
    /// <para>Draws multiple disconnected lines with a uniform <paramref name="width" /> and <paramref name="color" />. Each line is defined by two consecutive points from <paramref name="points" /> array, i.e. i-th segment consists of <c>points[2 * i]</c>, <c>points[2 * i + 1]</c> endpoints. When drawing large amounts of lines, this is faster than using individual <see cref="CanvasItem.DrawLine(Godot.Vector2,Godot.Vector2,Godot.Color,System.Single,System.Boolean)" /> calls. To draw interconnected lines, use <see cref="CanvasItem.DrawPolyline(Godot.Vector2[],Godot.Color,System.Single,System.Boolean)" /> instead.</para>
    /// <para>If <paramref name="width" /> is negative, then two-point primitives will be drawn instead of a four-point ones. This means that when the CanvasItem is scaled, the lines will remain thin. If this behavior is not desired, then pass a positive <paramref name="width" /> like <c>1.0</c>.</para>
    /// </summary>
    public void DrawMultiline(Vector2[] points, Color color, float width) => _node.DrawMultiline(points, color, width);
    /// <summary>
    /// <para>Draws multiple disconnected lines with a uniform <paramref name="width" /> and segment-by-segment coloring. Each segment is defined by two consecutive points from <paramref name="points" /> array and a corresponding color from <paramref name="colors" /> array, i.e. i-th segment consists of <c>points[2 * i]</c>, <c>points[2 * i + 1]</c> endpoints and has <c>colors[i]</c> color. When drawing large amounts of lines, this is faster than using individual <see cref="CanvasItem.DrawLine(Godot.Vector2,Godot.Vector2,Godot.Color,System.Single,System.Boolean)" /> calls. To draw interconnected lines, use <see cref="CanvasItem.DrawPolylineColors(Godot.Vector2[],Godot.Color[],System.Single,System.Boolean)" /> instead.</para>
    /// <para>If <paramref name="width" /> is negative, then two-point primitives will be drawn instead of a four-point ones. This means that when the CanvasItem is scaled, the lines will remain thin. If this behavior is not desired, then pass a positive <paramref name="width" /> like <c>1.0</c>.</para>
    /// </summary>
    public void DrawMultilineColors(Vector2[] points, Color[] colors, float width) => _node.DrawMultilineColors(points, colors, width);
    /// <summary>
    /// <para>Breaks <paramref name="text" /> into lines and draws it using the specified <paramref name="font" /> at the <paramref name="pos" /> (top-left corner). The text will have its color multiplied by <paramref name="modulate" />. If <paramref name="width" /> is greater than or equal to 0, the text will be clipped if it exceeds the specified width.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1, 1, 1, 1)</c>.</param>
    public void DrawMultilineString(Font font, Vector2 pos, string text, HorizontalAlignment alignment, float width, int fontSize, int maxLines, Nullable<Color> modulate, TextServer.LineBreakFlag brkFlags, TextServer.JustificationFlag justificationFlags, TextServer.Direction direction, TextServer.Orientation orientation) => _node.DrawMultilineString(font, pos, text, alignment, width, fontSize, maxLines, modulate, brkFlags, justificationFlags, direction, orientation);
    /// <summary>
    /// <para>Breaks <paramref name="text" /> to the lines and draws text outline using the specified <paramref name="font" /> at the <paramref name="pos" /> (top-left corner). The text will have its color multiplied by <paramref name="modulate" />. If <paramref name="width" /> is greater than or equal to 0, the text will be clipped if it exceeds the specified width.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1, 1, 1, 1)</c>.</param>
    public void DrawMultilineStringOutline(Font font, Vector2 pos, string text, HorizontalAlignment alignment, float width, int fontSize, int maxLines, int size, Nullable<Color> modulate, TextServer.LineBreakFlag brkFlags, TextServer.JustificationFlag justificationFlags, TextServer.Direction direction, TextServer.Orientation orientation) => _node.DrawMultilineStringOutline(font, pos, text, alignment, width, fontSize, maxLines, size, modulate, brkFlags, justificationFlags, direction, orientation);
    /// <summary>
    /// <para>Draws a <see cref="MultiMesh" /> in 2D with the provided texture. See <see cref="MultiMeshInstance2D" /> for related documentation.</para>
    /// </summary>
    public void DrawMultimesh(MultiMesh multimesh, Texture2D texture) => _node.DrawMultimesh(multimesh, texture);
    /// <summary>
    /// <para>Draws a solid polygon of any number of points, convex or concave. Unlike <see cref="CanvasItem.DrawColoredPolygon(Godot.Vector2[],Godot.Color,Godot.Vector2[],Godot.Texture2D)" />, each point's color can be changed individually. See also <see cref="CanvasItem.DrawPolyline(Godot.Vector2[],Godot.Color,System.Single,System.Boolean)" /> and <see cref="CanvasItem.DrawPolylineColors(Godot.Vector2[],Godot.Color[],System.Single,System.Boolean)" />. If you need more flexibility (such as being able to use bones), use <see cref="RenderingServer.CanvasItemAddTriangleArray(Godot.Rid,System.Int32[],Godot.Vector2[],Godot.Color[],Godot.Vector2[],System.Int32[],System.Single[],Godot.Rid,System.Int32)" /> instead.</para>
    /// </summary>
    /// <param name="uvs">If the parameter is null, then the default value is <c>Array.Empty&lt;Vector2&gt;()</c>.</param>
    public void DrawPolygon(Vector2[] points, Color[] colors, Vector2[] uvs, Texture2D texture) => _node.DrawPolygon(points, colors, uvs, texture);
    /// <summary>
    /// <para>Draws interconnected line segments with a uniform <paramref name="color" /> and <paramref name="width" /> and optional antialiasing (supported only for positive <paramref name="width" />). When drawing large amounts of lines, this is faster than using individual <see cref="CanvasItem.DrawLine(Godot.Vector2,Godot.Vector2,Godot.Color,System.Single,System.Boolean)" /> calls. To draw disconnected lines, use <see cref="CanvasItem.DrawMultiline(Godot.Vector2[],Godot.Color,System.Single)" /> instead. See also <see cref="CanvasItem.DrawPolygon(Godot.Vector2[],Godot.Color[],Godot.Vector2[],Godot.Texture2D)" />.</para>
    /// <para>If <paramref name="width" /> is negative, the polyline is drawn using <see cref="RenderingServer.PrimitiveType.LineStrip" />. This means that when the CanvasItem is scaled, the polyline will remain thin. If this behavior is not desired, then pass a positive <paramref name="width" /> like <c>1.0</c>.</para>
    /// </summary>
    public void DrawPolyline(Vector2[] points, Color color, float width, bool antialiased) => _node.DrawPolyline(points, color, width, antialiased);
    /// <summary>
    /// <para>Draws interconnected line segments with a uniform <paramref name="width" />, point-by-point coloring, and optional antialiasing (supported only for positive <paramref name="width" />). Colors assigned to line points match by index between <paramref name="points" /> and <paramref name="colors" />, i.e. each line segment is filled with a gradient between the colors of the endpoints. When drawing large amounts of lines, this is faster than using individual <see cref="CanvasItem.DrawLine(Godot.Vector2,Godot.Vector2,Godot.Color,System.Single,System.Boolean)" /> calls. To draw disconnected lines, use <see cref="CanvasItem.DrawMultilineColors(Godot.Vector2[],Godot.Color[],System.Single)" /> instead. See also <see cref="CanvasItem.DrawPolygon(Godot.Vector2[],Godot.Color[],Godot.Vector2[],Godot.Texture2D)" />.</para>
    /// <para>If <paramref name="width" /> is negative, then the polyline is drawn using <see cref="RenderingServer.PrimitiveType.LineStrip" />. This means that when the CanvasItem is scaled, the polyline will remain thin. If this behavior is not desired, then pass a positive <paramref name="width" /> like <c>1.0</c>.</para>
    /// </summary>
    public void DrawPolylineColors(Vector2[] points, Color[] colors, float width, bool antialiased) => _node.DrawPolylineColors(points, colors, width, antialiased);
    /// <summary>
    /// <para>Draws a custom primitive. 1 point for a point, 2 points for a line, 3 points for a triangle, and 4 points for a quad. If 0 points or more than 4 points are specified, nothing will be drawn and an error message will be printed. See also <see cref="CanvasItem.DrawLine(Godot.Vector2,Godot.Vector2,Godot.Color,System.Single,System.Boolean)" />, <see cref="CanvasItem.DrawPolyline(Godot.Vector2[],Godot.Color,System.Single,System.Boolean)" />, <see cref="CanvasItem.DrawPolygon(Godot.Vector2[],Godot.Color[],Godot.Vector2[],Godot.Texture2D)" />, and <see cref="CanvasItem.DrawRect(Godot.Rect2,Godot.Color,System.Boolean,System.Single)" />.</para>
    /// </summary>
    public void DrawPrimitive(Vector2[] points, Color[] colors, Vector2[] uvs, Texture2D texture) => _node.DrawPrimitive(points, colors, uvs, texture);
    /// <summary>
    /// <para>Draws a rectangle. If <paramref name="filled" /> is <c>true</c>, the rectangle will be filled with the <paramref name="color" /> specified. If <paramref name="filled" /> is <c>false</c>, the rectangle will be drawn as a stroke with the <paramref name="color" /> and <paramref name="width" /> specified. See also <see cref="CanvasItem.DrawTextureRect(Godot.Texture2D,Godot.Rect2,System.Boolean,System.Nullable{Godot.Color},System.Boolean)" />.</para>
    /// <para>If <paramref name="width" /> is negative, then two-point primitives will be drawn instead of a four-point ones. This means that when the CanvasItem is scaled, the lines will remain thin. If this behavior is not desired, then pass a positive <paramref name="width" /> like <c>1.0</c>.</para>
    /// <para><b>Note:</b> <paramref name="width" /> is only effective if <paramref name="filled" /> is <c>false</c>.</para>
    /// <para><b>Note:</b> Unfilled rectangles drawn with a negative <paramref name="width" /> may not display perfectly. For example, corners may be missing or brighter due to overlapping lines (for a translucent <paramref name="color" />).</para>
    /// </summary>
    public void DrawRect(Rect2 rect, Color color, bool filled, float width) => _node.DrawRect(rect, color, filled, width);
    /// <summary>
    /// <para>Sets a custom transform for drawing via components. Anything drawn afterwards will be transformed by this.</para>
    /// <para><b>Note:</b> <see cref="FontFile.Oversampling" /> does <i>not</i> take <paramref name="scale" /> into account. This means that scaling up/down will cause bitmap fonts and rasterized (non-MSDF) dynamic fonts to appear blurry or pixelated. To ensure text remains crisp regardless of scale, you can enable MSDF font rendering by enabling <c>ProjectSettings.gui/theme/default_font_multichannel_signed_distance_field</c> (applies to the default project font only), or enabling <b>Multichannel Signed Distance Field</b> in the import options of a DynamicFont for custom fonts. On system fonts, <see cref="SystemFont.MultichannelSignedDistanceField" /> can be enabled in the inspector.</para>
    /// </summary>
    /// <param name="scale">If the parameter is null, then the default value is <c>new Vector2(1, 1)</c>.</param>
    public void DrawSetTransform(Vector2 position, float rotation, Nullable<Vector2> scale) => _node.DrawSetTransform(position, rotation, scale);
    /// <summary>
    /// <para>Sets a custom transform for drawing via matrix. Anything drawn afterwards will be transformed by this.</para>
    /// </summary>
    public void DrawSetTransformMatrix(Transform2D xform) => _node.DrawSetTransformMatrix(xform);
    /// <summary>
    /// <para>Draws <paramref name="text" /> using the specified <paramref name="font" /> at the <paramref name="pos" /> (bottom-left corner using the baseline of the font). The text will have its color multiplied by <paramref name="modulate" />. If <paramref name="width" /> is greater than or equal to 0, the text will be clipped if it exceeds the specified width.</para>
    /// <para><b>Example using the default project font:</b></para>
    /// <para><code>
    /// // If using this method in a script that redraws constantly, move the
    /// // `default_font` declaration to a member variable assigned in `_Ready()`
    /// // so the Control is only created once.
    /// Font defaultFont = ThemeDB.FallbackFont;
    /// int defaultFontSize = ThemeDB.FallbackFontSize;
    /// DrawString(defaultFont, new Vector2(64, 64), "Hello world", HORIZONTAL_ALIGNMENT_LEFT, -1, defaultFontSize);
    /// </code></para>
    /// <para>See also <see cref="Font.DrawString(Godot.Rid,Godot.Vector2,System.String,Godot.HorizontalAlignment,System.Single,System.Int32,System.Nullable{Godot.Color},Godot.TextServer.JustificationFlag,Godot.TextServer.Direction,Godot.TextServer.Orientation)" />.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1, 1, 1, 1)</c>.</param>
    public void DrawString(Font font, Vector2 pos, string text, HorizontalAlignment alignment, float width, int fontSize, Nullable<Color> modulate, TextServer.JustificationFlag justificationFlags, TextServer.Direction direction, TextServer.Orientation orientation) => _node.DrawString(font, pos, text, alignment, width, fontSize, modulate, justificationFlags, direction, orientation);
    /// <summary>
    /// <para>Draws <paramref name="text" /> outline using the specified <paramref name="font" /> at the <paramref name="pos" /> (bottom-left corner using the baseline of the font). The text will have its color multiplied by <paramref name="modulate" />. If <paramref name="width" /> is greater than or equal to 0, the text will be clipped if it exceeds the specified width.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1, 1, 1, 1)</c>.</param>
    public void DrawStringOutline(Font font, Vector2 pos, string text, HorizontalAlignment alignment, float width, int fontSize, int size, Nullable<Color> modulate, TextServer.JustificationFlag justificationFlags, TextServer.Direction direction, TextServer.Orientation orientation) => _node.DrawStringOutline(font, pos, text, alignment, width, fontSize, size, modulate, justificationFlags, direction, orientation);
    /// <summary>
    /// <para>Draws a styled rectangle.</para>
    /// </summary>
    public void DrawStyleBox(StyleBox styleBox, Rect2 rect) => _node.DrawStyleBox(styleBox, rect);
    /// <summary>
    /// <para>Draws a texture at a given position.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1, 1, 1, 1)</c>.</param>
    public void DrawTexture(Texture2D texture, Vector2 position, Nullable<Color> modulate) => _node.DrawTexture(texture, position, modulate);
    /// <summary>
    /// <para>Draws a textured rectangle at a given position, optionally modulated by a color. If <paramref name="transpose" /> is <c>true</c>, the texture will have its X and Y coordinates swapped. See also <see cref="CanvasItem.DrawRect(Godot.Rect2,Godot.Color,System.Boolean,System.Single)" /> and <see cref="CanvasItem.DrawTextureRectRegion(Godot.Texture2D,Godot.Rect2,Godot.Rect2,System.Nullable{Godot.Color},System.Boolean,System.Boolean)" />.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1, 1, 1, 1)</c>.</param>
    public void DrawTextureRect(Texture2D texture, Rect2 rect, bool tile, Nullable<Color> modulate, bool transpose) => _node.DrawTextureRect(texture, rect, tile, modulate, transpose);
    /// <summary>
    /// <para>Draws a textured rectangle from a texture's region (specified by <paramref name="srcRect" />) at a given position, optionally modulated by a color. If <paramref name="transpose" /> is <c>true</c>, the texture will have its X and Y coordinates swapped. See also <see cref="CanvasItem.DrawTextureRect(Godot.Texture2D,Godot.Rect2,System.Boolean,System.Nullable{Godot.Color},System.Boolean)" />.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1, 1, 1, 1)</c>.</param>
    public void DrawTextureRectRegion(Texture2D texture, Rect2 rect, Rect2 srcRect, Nullable<Color> modulate, bool transpose, bool clipUV) => _node.DrawTextureRectRegion(texture, rect, srcRect, modulate, transpose, clipUV);
    /// <summary>
    /// <para>Forces the transform to update. Transform changes in physics are not instant for performance reasons. Transforms are accumulated and then set. Use this if you need an up-to-date transform when doing physics operations.</para>
    /// </summary>
    public void ForceUpdateTransform() => _node.ForceUpdateTransform();
    /// <summary>
    /// <para>Returns the <see cref="Rid" /> of the <see cref="World2D" /> canvas where this item is in.</para>
    /// </summary>
    public Rid GetCanvas() => _node.GetCanvas();
    /// <summary>
    /// <para>Returns the canvas item RID used by <see cref="RenderingServer" /> for this item.</para>
    /// </summary>
    public Rid GetCanvasItem() => _node.GetCanvasItem();
    /// <summary>
    /// <para>Returns the transform from the coordinate system of the canvas, this item is in, to the <see cref="Viewport" />s coordinate system.</para>
    /// </summary>
    public Transform2D GetCanvasTransform() => _node.GetCanvasTransform();
    /// <summary>
    /// <para>Returns the mouse's position in the <see cref="CanvasLayer" /> that this <see cref="CanvasItem" /> is in using the coordinate system of the <see cref="CanvasLayer" />.</para>
    /// <para><b>Note:</b> For screen-space coordinates (e.g. when using a non-embedded <see cref="Popup" />), you can use <see cref="DisplayServer.MouseGetPosition" />.</para>
    /// </summary>
    public Vector2 GetGlobalMousePosition() => _node.GetGlobalMousePosition();
    /// <summary>
    /// <para>Returns the global transform matrix of this item, i.e. the combined transform up to the topmost <see cref="CanvasItem" /> node. The topmost item is a <see cref="CanvasItem" /> that either has no parent, has non-<see cref="CanvasItem" /> parent or it has <see cref="CanvasItem.TopLevel" /> enabled.</para>
    /// </summary>
    public Transform2D GetGlobalTransform() => _node.GetGlobalTransform();
    /// <summary>
    /// <para>Returns the transform from the local coordinate system of this <see cref="CanvasItem" /> to the <see cref="Viewport" />s coordinate system.</para>
    /// </summary>
    public Transform2D GetGlobalTransformWithCanvas() => _node.GetGlobalTransformWithCanvas();
    /// <summary>
    /// <para>Returns the mouse's position in this <see cref="CanvasItem" /> using the local coordinate system of this <see cref="CanvasItem" />.</para>
    /// </summary>
    public Vector2 GetLocalMousePosition() => _node.GetLocalMousePosition();
    /// <summary>
    /// <para>Returns the transform of this <see cref="CanvasItem" /> in global screen coordinates (i.e. taking window position into account). Mostly useful for editor plugins.</para>
    /// <para>Equals to <see cref="CanvasItem.GetGlobalTransform" /> if the window is embedded (see <see cref="Viewport.GuiEmbedSubwindows" />).</para>
    /// </summary>
    public Transform2D GetScreenTransform() => _node.GetScreenTransform();
    /// <summary>
    /// <para>Returns the transform matrix of this item.</para>
    /// </summary>
    public Transform2D GetTransform() => _node.GetTransform();
    /// <summary>
    /// <para>Returns the viewport's boundaries as a <see cref="Rect2" />.</para>
    /// </summary>
    public Rect2 GetViewportRect() => _node.GetViewportRect();
    /// <summary>
    /// <para>Returns the transform from the coordinate system of the canvas, this item is in, to the <see cref="Viewport" />s embedders coordinate system.</para>
    /// </summary>
    public Transform2D GetViewportTransform() => _node.GetViewportTransform();
    /// <summary>
    /// <para>Returns an individual bit on the rendering visibility layer.</para>
    /// </summary>
    public bool GetVisibilityLayerBit(uint layer) => _node.GetVisibilityLayerBit(layer);
    /// <summary>
    /// <para>Returns the <see cref="World2D" /> where this item is in.</para>
    /// </summary>
    public World2D GetWorld2D() => _node.GetWorld2D();
    /// <summary>
    /// <para>Hide the <see cref="CanvasItem" /> if it's currently visible. This is equivalent to setting <see cref="CanvasItem.Visible" /> to <c>false</c>.</para>
    /// </summary>
    public void Hide() => _node.Hide();
    /// <summary>
    /// <para>Returns <c>true</c> if local transform notifications are communicated to children.</para>
    /// </summary>
    public bool IsLocalTransformNotificationEnabled() => _node.IsLocalTransformNotificationEnabled();
    /// <summary>
    /// <para>Returns <c>true</c> if global transform notifications are communicated to children.</para>
    /// </summary>
    public bool IsTransformNotificationEnabled() => _node.IsTransformNotificationEnabled();
    /// <summary>
    /// <para>Returns <c>true</c> if the node is present in the <see cref="SceneTree" />, its <see cref="CanvasItem.Visible" /> property is <c>true</c> and all its ancestors are also visible. If any ancestor is hidden, this node will not be visible in the scene tree, and is consequently not drawn (see <see cref="CanvasItem._Draw" />).</para>
    /// </summary>
    public bool IsVisibleInTree() => _node.IsVisibleInTree();
    /// <summary>
    /// <para>The rendering layers in which this <see cref="CanvasItem" /> responds to <see cref="Light2D" /> nodes.</para>
    /// </summary>
    public int LightMask { get => _node.LightMask; set => _node.LightMask = value; }
    /// <summary>
    /// <para>Assigns <paramref name="screenPoint" /> as this node's new local transform.</para>
    /// </summary>
    public Vector2 MakeCanvasPositionLocal(Vector2 screenPoint) => _node.MakeCanvasPositionLocal(screenPoint);
    /// <summary>
    /// <para>Transformations issued by <paramref name="event" />'s inputs are applied in local space instead of global space.</para>
    /// </summary>
    public InputEvent MakeInputLocal(InputEvent @event) => _node.MakeInputLocal(@event);
    /// <summary>
    /// <para>The material applied to this <see cref="CanvasItem" />.</para>
    /// </summary>
    public Material Material { get => _node.Material; set => _node.Material = value; }
    /// <summary>
    /// <para>The color applied to this <see cref="CanvasItem" />. This property does affect child <see cref="CanvasItem" />s, unlike <see cref="CanvasItem.SelfModulate" /> which only affects the node itself.</para>
    /// </summary>
    public Color Modulate { get => _node.Modulate; set => _node.Modulate = value; }
    /// <summary>
    /// <para>Moves this node to display on top of its siblings.</para>
    /// <para>Internally, the node is moved to the bottom of parent's children list. The method has no effect on nodes without a parent.</para>
    /// </summary>
    public void MoveToFront() => _node.MoveToFront();
    /// <summary>
    /// <para>Queues the <see cref="CanvasItem" /> to redraw. During idle time, if <see cref="CanvasItem" /> is visible, <see cref="CanvasItem.NotificationDraw" /> is sent and <see cref="CanvasItem._Draw" /> is called. This only occurs <b>once</b> per frame, even if this method has been called multiple times.</para>
    /// </summary>
    public void QueueRedraw() => _node.QueueRedraw();
    /// <summary>
    /// <para>The color applied to this <see cref="CanvasItem" />. This property does <b>not</b> affect child <see cref="CanvasItem" />s, unlike <see cref="CanvasItem.Modulate" /> which affects both the node itself and its children.</para>
    /// <para><b>Note:</b> Internal children (e.g. sliders in <see cref="ColorPicker" /> or tab bar in <see cref="TabContainer" />) are also not affected by this property (see <c>include_internal</c> parameter of <see cref="Node.GetChild(System.Int32,System.Boolean)" /> and other similar methods).</para>
    /// </summary>
    public Color SelfModulate { get => _node.SelfModulate; set => _node.SelfModulate = value; }
    /// <summary>
    /// <para>If <paramref name="enable" /> is <c>true</c>, this node will receive <see cref="CanvasItem.NotificationLocalTransformChanged" /> when its local transform changes.</para>
    /// </summary>
    public void SetNotifyLocalTransform(bool enable) => _node.SetNotifyLocalTransform(enable);
    /// <summary>
    /// <para>If <paramref name="enable" /> is <c>true</c>, this node will receive <see cref="CanvasItem.NotificationTransformChanged" /> when its global transform changes.</para>
    /// </summary>
    public void SetNotifyTransform(bool enable) => _node.SetNotifyTransform(enable);
    /// <summary>
    /// <para>Set/clear individual bits on the rendering visibility layer. This simplifies editing this <see cref="CanvasItem" />'s visibility layer.</para>
    /// </summary>
    public void SetVisibilityLayerBit(uint layer, bool enabled) => _node.SetVisibilityLayerBit(layer, enabled);
    /// <summary>
    /// <para>Show the <see cref="CanvasItem" /> if it's currently hidden. This is equivalent to setting <see cref="CanvasItem.Visible" /> to <c>true</c>. For controls that inherit <see cref="Popup" />, the correct way to make them visible is to call one of the multiple <c>popup*()</c> functions instead.</para>
    /// </summary>
    public void Show() => _node.Show();
    /// <summary>
    /// <para>If <c>true</c>, the object draws behind its parent.</para>
    /// </summary>
    public bool ShowBehindParent { get => _node.ShowBehindParent; set => _node.ShowBehindParent = value; }
    /// <summary>
    /// <para>The texture filtering mode to use on this <see cref="CanvasItem" />.</para>
    /// </summary>
    public CanvasItem.TextureFilterEnum TextureFilter { get => _node.TextureFilter; set => _node.TextureFilter = value; }
    /// <summary>
    /// <para>The texture repeating mode to use on this <see cref="CanvasItem" />.</para>
    /// </summary>
    public CanvasItem.TextureRepeatEnum TextureRepeat { get => _node.TextureRepeat; set => _node.TextureRepeat = value; }
    /// <summary>
    /// <para>If <c>true</c>, this <see cref="CanvasItem" /> will <i>not</i> inherit its transform from parent <see cref="CanvasItem" />s. Its draw order will also be changed to make it draw on top of other <see cref="CanvasItem" />s that do not have <see cref="CanvasItem.TopLevel" /> set to <c>true</c>. The <see cref="CanvasItem" /> will effectively act as if it was placed as a child of a bare <see cref="Node" />.</para>
    /// </summary>
    public bool TopLevel { get => _node.TopLevel; set => _node.TopLevel = value; }
    /// <summary>
    /// <para>If <c>true</c>, the parent <see cref="CanvasItem" />'s <see cref="CanvasItem.Material" /> property is used as this one's material.</para>
    /// </summary>
    public bool UseParentMaterial { get => _node.UseParentMaterial; set => _node.UseParentMaterial = value; }
    /// <summary>
    /// <para>The rendering layer in which this <see cref="CanvasItem" /> is rendered by <see cref="Viewport" /> nodes. A <see cref="Viewport" /> will render a <see cref="CanvasItem" /> if it and all its parents share a layer with the <see cref="Viewport" />'s canvas cull mask.</para>
    /// </summary>
    public uint VisibilityLayer { get => _node.VisibilityLayer; set => _node.VisibilityLayer = value; }
    /// <summary>
    /// <para>If <c>true</c>, this <see cref="CanvasItem" /> is drawn. The node is only visible if all of its ancestors are visible as well (in other words, <see cref="CanvasItem.IsVisibleInTree" /> must return <c>true</c>).</para>
    /// <para><b>Note:</b> For controls that inherit <see cref="Popup" />, the correct way to make them visible is to call one of the multiple <c>popup*()</c> functions instead.</para>
    /// </summary>
    public bool Visible { get => _node.Visible; set => _node.Visible = value; }
    /// <summary>
    /// <para>If <c>true</c>, child nodes with the lowest Y position are drawn before those with a higher Y position. If <c>false</c>, Y-sorting is disabled. Y-sorting only affects children that inherit from <see cref="CanvasItem" />.</para>
    /// <para>You can nest nodes with Y-sorting. Child Y-sorted nodes are sorted in the same space as the parent Y-sort. This feature allows you to organize a scene better or divide it into multiple ones without changing your scene tree.</para>
    /// </summary>
    public bool YSortEnabled { get => _node.YSortEnabled; set => _node.YSortEnabled = value; }
    /// <summary>
    /// <para>If <c>true</c>, the node's Z index is relative to its parent's Z index. If this node's Z index is 2 and its parent's effective Z index is 3, then this node's effective Z index will be 2 + 3 = 5.</para>
    /// </summary>
    public bool ZAsRelative { get => _node.ZAsRelative; set => _node.ZAsRelative = value; }
    /// <summary>
    /// <para>Z index. Controls the order in which the nodes render. A node with a higher Z index will display in front of others. Must be between <see cref="RenderingServer.CanvasItemZMin" /> and <see cref="RenderingServer.CanvasItemZMax" /> (inclusive).</para>
    /// <para><b>Note:</b> Changing the Z index of a <see cref="Control" /> only affects the drawing order, not the order in which input events are handled. This can be useful to implement certain UI animations, e.g. a menu where hovered items are scaled and should overlap others.</para>
    /// </summary>
    public int ZIndex { get => _node.ZIndex; set => _node.ZIndex = value; }

}