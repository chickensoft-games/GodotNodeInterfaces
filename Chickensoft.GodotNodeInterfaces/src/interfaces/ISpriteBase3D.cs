namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>A node that displays 2D texture information in a 3D environment. See also <see cref="Sprite3D" /> where many other properties are defined.</para>
/// </summary>
public interface ISpriteBase3D : IGeometryInstance3D {
    /// <summary>
    /// <para>Returns the rectangle representing this sprite.</para>
    /// </summary>
    Rect2 GetItemRect();
    /// <summary>
    /// <para>Returns a <see cref="TriangleMesh" /> with the sprite's vertices following its current configuration (such as its <see cref="SpriteBase3D.Axis" /> and <see cref="SpriteBase3D.PixelSize" />).</para>
    /// </summary>
    TriangleMesh GenerateTriangleMesh();
    /// <summary>
    /// <para>If <c>true</c>, texture will be centered.</para>
    /// </summary>
    bool Centered { get; set; }
    /// <summary>
    /// <para>The texture's drawing offset.</para>
    /// </summary>
    Vector2 Offset { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, texture is flipped horizontally.</para>
    /// </summary>
    bool FlipH { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, texture is flipped vertically.</para>
    /// </summary>
    bool FlipV { get; set; }
    /// <summary>
    /// <para>A color value used to <i>multiply</i> the texture's colors. Can be used for mood-coloring or to simulate the color of light.</para>
    /// <para><b>Note:</b> If a <see cref="GeometryInstance3D.MaterialOverride" /> is defined on the <see cref="SpriteBase3D" />, the material override must be configured to take vertex colors into account for albedo. Otherwise, the color defined in <see cref="SpriteBase3D.Modulate" /> will be ignored. For a <see cref="BaseMaterial3D" />, <see cref="BaseMaterial3D.VertexColorUseAsAlbedo" /> must be <c>true</c>. For a <see cref="ShaderMaterial" />, <c>ALBEDO *= COLOR.rgb;</c> must be inserted in the shader's <c>fragment()</c> function.</para>
    /// </summary>
    Color Modulate { get; set; }
    /// <summary>
    /// <para>The size of one pixel's width on the sprite to scale it in 3D.</para>
    /// </summary>
    float PixelSize { get; set; }
    /// <summary>
    /// <para>The direction in which the front of the texture faces.</para>
    /// </summary>
    Vector3.Axis Axis { get; set; }
    /// <summary>
    /// <para>The billboard mode to use for the sprite. See <see cref="BaseMaterial3D.BillboardModeEnum" /> for possible values.</para>
    /// </summary>
    BaseMaterial3D.BillboardModeEnum Billboard { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the texture's transparency and the opacity are used to make those parts of the sprite invisible.</para>
    /// </summary>
    bool Transparent { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the <see cref="Light3D" /> in the <see cref="Environment" /> has effects on the sprite.</para>
    /// </summary>
    bool Shaded { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, texture can be seen from the back as well, if <c>false</c>, it is invisible when looking at it from behind.</para>
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
    /// <para>The alpha cutting mode to use for the sprite. See <see cref="SpriteBase3D.AlphaCutMode" /> for possible values.</para>
    /// </summary>
    SpriteBase3D.AlphaCutMode AlphaCut { get; set; }
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
    /// <para>Sets the render priority for the sprite. Higher priority objects will be sorted in front of lower priority objects.</para>
    /// <para><b>Note:</b> This only applies if <see cref="SpriteBase3D.AlphaCut" /> is set to <see cref="SpriteBase3D.AlphaCutMode.Disabled" /> (default value).</para>
    /// <para><b>Note:</b> This only applies to sorting of transparent objects. This will not impact how transparent objects are sorted relative to opaque objects. This is because opaque objects are not sorted, while transparent objects are sorted from back to front (subject to priority).</para>
    /// </summary>
    int RenderPriority { get; set; }

}