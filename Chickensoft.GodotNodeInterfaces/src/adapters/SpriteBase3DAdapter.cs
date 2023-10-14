namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A node that displays 2D texture information in a 3D environment. See also <see cref="Sprite3D" /> where many other properties are defined.</para>
/// </summary>
public class SpriteBase3DAdapter : GeometryInstance3DAdapter, ISpriteBase3D {
  private readonly SpriteBase3D _node;

  public SpriteBase3DAdapter(SpriteBase3D node) : base(node) { _node = node; }

    /// <summary>
    /// <para>Threshold at which antialiasing will be applied on the alpha channel.</para>
    /// </summary>
    public float AlphaAntialiasingEdge { get => _node.AlphaAntialiasingEdge; set => _node.AlphaAntialiasingEdge = value; }
    /// <summary>
    /// <para>The type of alpha antialiasing to apply. See <see cref="BaseMaterial3D.AlphaAntiAliasing" />.</para>
    /// </summary>
    public BaseMaterial3D.AlphaAntiAliasing AlphaAntialiasingMode { get => _node.AlphaAntialiasingMode; set => _node.AlphaAntialiasingMode = value; }
    /// <summary>
    /// <para>The alpha cutting mode to use for the sprite. See <see cref="SpriteBase3D.AlphaCutMode" /> for possible values.</para>
    /// </summary>
    public SpriteBase3D.AlphaCutMode AlphaCut { get => _node.AlphaCut; set => _node.AlphaCut = value; }
    /// <summary>
    /// <para>The hashing scale for Alpha Hash. Recommended values between <c>0</c> and <c>2</c>.</para>
    /// </summary>
    public float AlphaHashScale { get => _node.AlphaHashScale; set => _node.AlphaHashScale = value; }
    /// <summary>
    /// <para>Threshold at which the alpha scissor will discard values.</para>
    /// </summary>
    public float AlphaScissorThreshold { get => _node.AlphaScissorThreshold; set => _node.AlphaScissorThreshold = value; }
    /// <summary>
    /// <para>The direction in which the front of the texture faces.</para>
    /// </summary>
    public Vector3.Axis Axis { get => _node.Axis; set => _node.Axis = value; }
    /// <summary>
    /// <para>The billboard mode to use for the sprite. See <see cref="BaseMaterial3D.BillboardModeEnum" /> for possible values.</para>
    /// </summary>
    public BaseMaterial3D.BillboardModeEnum Billboard { get => _node.Billboard; set => _node.Billboard = value; }
    /// <summary>
    /// <para>If <c>true</c>, texture will be centered.</para>
    /// </summary>
    public bool Centered { get => _node.Centered; set => _node.Centered = value; }
    /// <summary>
    /// <para>If <c>true</c>, texture can be seen from the back as well, if <c>false</c>, it is invisible when looking at it from behind.</para>
    /// </summary>
    public bool DoubleSided { get => _node.DoubleSided; set => _node.DoubleSided = value; }
    /// <summary>
    /// <para>If <c>true</c>, the label is rendered at the same size regardless of distance.</para>
    /// </summary>
    public bool FixedSize { get => _node.FixedSize; set => _node.FixedSize = value; }
    /// <summary>
    /// <para>If <c>true</c>, texture is flipped horizontally.</para>
    /// </summary>
    public bool FlipH { get => _node.FlipH; set => _node.FlipH = value; }
    /// <summary>
    /// <para>If <c>true</c>, texture is flipped vertically.</para>
    /// </summary>
    public bool FlipV { get => _node.FlipV; set => _node.FlipV = value; }
    /// <summary>
    /// <para>Returns a <see cref="TriangleMesh" /> with the sprite's vertices following its current configuration (such as its <see cref="SpriteBase3D.Axis" /> and <see cref="SpriteBase3D.PixelSize" />).</para>
    /// </summary>
    public TriangleMesh GenerateTriangleMesh() => _node.GenerateTriangleMesh();
    /// <summary>
    /// <para>Returns the rectangle representing this sprite.</para>
    /// </summary>
    public Rect2 GetItemRect() => _node.GetItemRect();
    /// <summary>
    /// <para>A color value used to <i>multiply</i> the texture's colors. Can be used for mood-coloring or to simulate the color of light.</para>
    /// <para><b>Note:</b> If a <see cref="GeometryInstance3D.MaterialOverride" /> is defined on the <see cref="SpriteBase3D" />, the material override must be configured to take vertex colors into account for albedo. Otherwise, the color defined in <see cref="SpriteBase3D.Modulate" /> will be ignored. For a <see cref="BaseMaterial3D" />, <see cref="BaseMaterial3D.VertexColorUseAsAlbedo" /> must be <c>true</c>. For a <see cref="ShaderMaterial" />, <c>ALBEDO *= COLOR.rgb;</c> must be inserted in the shader's <c>fragment()</c> function.</para>
    /// </summary>
    public Color Modulate { get => _node.Modulate; set => _node.Modulate = value; }
    /// <summary>
    /// <para>If <c>true</c>, depth testing is disabled and the object will be drawn in render order.</para>
    /// </summary>
    public bool NoDepthTest { get => _node.NoDepthTest; set => _node.NoDepthTest = value; }
    /// <summary>
    /// <para>The texture's drawing offset.</para>
    /// </summary>
    public Vector2 Offset { get => _node.Offset; set => _node.Offset = value; }
    /// <summary>
    /// <para>The size of one pixel's width on the sprite to scale it in 3D.</para>
    /// </summary>
    public float PixelSize { get => _node.PixelSize; set => _node.PixelSize = value; }
    /// <summary>
    /// <para>Sets the render priority for the sprite. Higher priority objects will be sorted in front of lower priority objects.</para>
    /// <para><b>Note:</b> This only applies if <see cref="SpriteBase3D.AlphaCut" /> is set to <see cref="SpriteBase3D.AlphaCutMode.Disabled" /> (default value).</para>
    /// <para><b>Note:</b> This only applies to sorting of transparent objects. This will not impact how transparent objects are sorted relative to opaque objects. This is because opaque objects are not sorted, while transparent objects are sorted from back to front (subject to priority).</para>
    /// </summary>
    public int RenderPriority { get => _node.RenderPriority; set => _node.RenderPriority = value; }
    /// <summary>
    /// <para>If <c>true</c>, the <see cref="Light3D" /> in the <see cref="Environment" /> has effects on the sprite.</para>
    /// </summary>
    public bool Shaded { get => _node.Shaded; set => _node.Shaded = value; }
    /// <summary>
    /// <para>Filter flags for the texture. See <see cref="BaseMaterial3D.TextureFilterEnum" /> for options.</para>
    /// </summary>
    public BaseMaterial3D.TextureFilterEnum TextureFilter { get => _node.TextureFilter; set => _node.TextureFilter = value; }
    /// <summary>
    /// <para>If <c>true</c>, the texture's transparency and the opacity are used to make those parts of the sprite invisible.</para>
    /// </summary>
    public bool Transparent { get => _node.Transparent; set => _node.Transparent = value; }

}