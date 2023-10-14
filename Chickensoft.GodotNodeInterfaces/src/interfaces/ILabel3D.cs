namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
using Godot.Collections;


/// <summary>
/// <para>A node for displaying plain text in 3D space. By adjusting various properties of this node, you can configure things such as the text's appearance and whether it always faces the camera.</para>
/// </summary>
public interface ILabel3D : IGeometryInstance3D {
    /// <summary>
    /// <para>Returns a <see cref="TriangleMesh" /> with the label's vertices following its current configuration (such as its <see cref="Label3D.PixelSize" />).</para>
    /// </summary>
    TriangleMesh GenerateTriangleMesh();
    /// <summary>
    /// <para>The size of one pixel's width on the label to scale it in 3D. To make the font look more detailed when up close, increase <see cref="Label3D.FontSize" /> while decreasing <see cref="Label3D.PixelSize" /> at the same time.</para>
    /// </summary>
    float PixelSize { get; set; }
    /// <summary>
    /// <para>The text drawing offset (in pixels).</para>
    /// </summary>
    Vector2 Offset { get; set; }
    /// <summary>
    /// <para>The billboard mode to use for the label. See <see cref="BaseMaterial3D.BillboardModeEnum" /> for possible values.</para>
    /// </summary>
    BaseMaterial3D.BillboardModeEnum Billboard { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the <see cref="Light3D" /> in the <see cref="Environment" /> has effects on the label.</para>
    /// </summary>
    bool Shaded { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, text can be seen from the back as well, if <c>false</c>, it is invisible when looking at it from behind.</para>
    /// </summary>
    bool DoubleSided { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, depth testing is disabled and the object will be drawn in render order.</para>
    /// </summary>
    bool NoDepthTest { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the label is rendered at the same size regardless of distance.</para>
    /// </summary>
    bool FixedSize { get; set; }
    /// <summary>
    /// <para>The alpha cutting mode to use for the sprite. See <see cref="Label3D.AlphaCutMode" /> for possible values.</para>
    /// </summary>
    Label3D.AlphaCutMode AlphaCut { get; set; }
    /// <summary>
    /// <para>Threshold at which the alpha scissor will discard values.</para>
    /// </summary>
    float AlphaScissorThreshold { get; set; }
    /// <summary>
    /// <para>The hashing scale for Alpha Hash. Recommended values between <c>0</c> and <c>2</c>.</para>
    /// </summary>
    float AlphaHashScale { get; set; }
    /// <summary>
    /// <para>The type of alpha antialiasing to apply. See <see cref="BaseMaterial3D.AlphaAntiAliasing" />.</para>
    /// </summary>
    BaseMaterial3D.AlphaAntiAliasing AlphaAntialiasingMode { get; set; }
    /// <summary>
    /// <para>Threshold at which antialiasing will be applied on the alpha channel.</para>
    /// </summary>
    float AlphaAntialiasingEdge { get; set; }
    /// <summary>
    /// <para>Filter flags for the texture. See <see cref="BaseMaterial3D.TextureFilterEnum" /> for options.</para>
    /// </summary>
    BaseMaterial3D.TextureFilterEnum TextureFilter { get; set; }
    /// <summary>
    /// <para>Sets the render priority for the text. Higher priority objects will be sorted in front of lower priority objects.</para>
    /// <para><b>Note:</b> This only applies if <see cref="Label3D.AlphaCut" /> is set to <see cref="Label3D.AlphaCutMode.Disabled" /> (default value).</para>
    /// <para><b>Note:</b> This only applies to sorting of transparent objects. This will not impact how transparent objects are sorted relative to opaque objects. This is because opaque objects are not sorted, while transparent objects are sorted from back to front (subject to priority).</para>
    /// </summary>
    int RenderPriority { get; set; }
    /// <summary>
    /// <para>Sets the render priority for the text outline. Higher priority objects will be sorted in front of lower priority objects.</para>
    /// <para><b>Note:</b> This only applies if <see cref="Label3D.AlphaCut" /> is set to <see cref="Label3D.AlphaCutMode.Disabled" /> (default value).</para>
    /// <para><b>Note:</b> This only applies to sorting of transparent objects. This will not impact how transparent objects are sorted relative to opaque objects. This is because opaque objects are not sorted, while transparent objects are sorted from back to front (subject to priority).</para>
    /// </summary>
    int OutlineRenderPriority { get; set; }
    /// <summary>
    /// <para>Text <see cref="Color" /> of the <see cref="Label3D" />.</para>
    /// </summary>
    Color Modulate { get; set; }
    /// <summary>
    /// <para>The tint of text outline.</para>
    /// </summary>
    Color OutlineModulate { get; set; }
    /// <summary>
    /// <para>The text to display on screen.</para>
    /// </summary>
    string Text { get; set; }
    /// <summary>
    /// <para>Font configuration used to display text.</para>
    /// </summary>
    Font Font { get; set; }
    /// <summary>
    /// <para>Font size of the <see cref="Label3D" />'s text. To make the font look more detailed when up close, increase <see cref="Label3D.FontSize" /> while decreasing <see cref="Label3D.PixelSize" /> at the same time.</para>
    /// <para>Higher font sizes require more time to render new characters, which can cause stuttering during gameplay.</para>
    /// </summary>
    int FontSize { get; set; }
    /// <summary>
    /// <para>Text outline size.</para>
    /// </summary>
    int OutlineSize { get; set; }
    /// <summary>
    /// <para>Controls the text's horizontal alignment. Supports left, center, right, and fill, or justify. Set it to one of the <see cref="HorizontalAlignment" /> constants.</para>
    /// </summary>
    HorizontalAlignment HorizontalAlignment { get; set; }
    /// <summary>
    /// <para>Controls the text's vertical alignment. Supports top, center, bottom. Set it to one of the <see cref="VerticalAlignment" /> constants.</para>
    /// </summary>
    VerticalAlignment VerticalAlignment { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, all the text displays as UPPERCASE.</para>
    /// </summary>
    bool Uppercase { get; set; }
    /// <summary>
    /// <para>Vertical space between lines in multiline <see cref="Label3D" />.</para>
    /// </summary>
    float LineSpacing { get; set; }
    /// <summary>
    /// <para>If set to something other than <see cref="TextServer.AutowrapMode.Off" />, the text gets wrapped inside the node's bounding rectangle. If you resize the node, it will change its height automatically to show all the text. To see how each mode behaves, see <see cref="TextServer.AutowrapMode" />.</para>
    /// </summary>
    TextServer.AutowrapMode AutowrapMode { get; set; }
    /// <summary>
    /// <para>Line fill alignment rules. For more info see <see cref="TextServer.JustificationFlag" />.</para>
    /// </summary>
    TextServer.JustificationFlag JustificationFlags { get; set; }
    /// <summary>
    /// <para>Text width (in pixels), used for autowrap and fill alignment.</para>
    /// </summary>
    float Width { get; set; }
    /// <summary>
    /// <para>Base text writing direction.</para>
    /// </summary>
    TextServer.Direction TextDirection { get; set; }
    /// <summary>
    /// <para>Language code used for line-breaking and text shaping algorithms, if left empty current locale is used instead.</para>
    /// </summary>
    string Language { get; set; }
    /// <summary>
    /// <para>Set BiDi algorithm override for the structured text.</para>
    /// </summary>
    TextServer.StructuredTextParser StructuredTextBidiOverride { get; set; }
    /// <summary>
    /// <para>Set additional options for BiDi override.</para>
    /// </summary>
    Godot.Collections.Array StructuredTextBidiOverrideOptions { get; set; }

}