namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
using Godot.Collections;
/// <summary>
/// <para>A node for displaying plain text in 3D space. By adjusting various properties of this node, you can configure things such as the text's appearance and whether it always faces the camera.</para>
/// </summary>
public class Label3DAdapter : GeometryInstance3DAdapter, ILabel3D {
  private readonly Label3D _node;

  public Label3DAdapter(Node node) : base(node) {
    if (node is not Label3D typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a Label3D"
      );
    }
    _node = typedNode;
  }

    /// <summary>
    /// <para>Threshold at which antialiasing will be applied on the alpha channel.</para>
    /// </summary>
    public float AlphaAntialiasingEdge { get => _node.AlphaAntialiasingEdge; set => _node.AlphaAntialiasingEdge = value; }
    /// <summary>
    /// <para>The type of alpha antialiasing to apply. See <see cref="BaseMaterial3D.AlphaAntiAliasing" />.</para>
    /// </summary>
    public BaseMaterial3D.AlphaAntiAliasing AlphaAntialiasingMode { get => _node.AlphaAntialiasingMode; set => _node.AlphaAntialiasingMode = value; }
    /// <summary>
    /// <para>The alpha cutting mode to use for the sprite. See <see cref="Label3D.AlphaCutMode" /> for possible values.</para>
    /// </summary>
    public Label3D.AlphaCutMode AlphaCut { get => _node.AlphaCut; set => _node.AlphaCut = value; }
    /// <summary>
    /// <para>The hashing scale for Alpha Hash. Recommended values between <c>0</c> and <c>2</c>.</para>
    /// </summary>
    public float AlphaHashScale { get => _node.AlphaHashScale; set => _node.AlphaHashScale = value; }
    /// <summary>
    /// <para>Threshold at which the alpha scissor will discard values.</para>
    /// </summary>
    public float AlphaScissorThreshold { get => _node.AlphaScissorThreshold; set => _node.AlphaScissorThreshold = value; }
    /// <summary>
    /// <para>If set to something other than <see cref="TextServer.AutowrapMode.Off" />, the text gets wrapped inside the node's bounding rectangle. If you resize the node, it will change its height automatically to show all the text. To see how each mode behaves, see <see cref="TextServer.AutowrapMode" />.</para>
    /// </summary>
    public TextServer.AutowrapMode AutowrapMode { get => _node.AutowrapMode; set => _node.AutowrapMode = value; }
    /// <summary>
    /// <para>The billboard mode to use for the label. See <see cref="BaseMaterial3D.BillboardModeEnum" /> for possible values.</para>
    /// </summary>
    public BaseMaterial3D.BillboardModeEnum Billboard { get => _node.Billboard; set => _node.Billboard = value; }
    /// <summary>
    /// <para>If <c>true</c>, text can be seen from the back as well, if <c>false</c>, it is invisible when looking at it from behind.</para>
    /// </summary>
    public bool DoubleSided { get => _node.DoubleSided; set => _node.DoubleSided = value; }
    /// <summary>
    /// <para>If <c>true</c>, the label is rendered at the same size regardless of distance.</para>
    /// </summary>
    public bool FixedSize { get => _node.FixedSize; set => _node.FixedSize = value; }
    /// <summary>
    /// <para>Font configuration used to display text.</para>
    /// </summary>
    public Font Font { get => _node.Font; set => _node.Font = value; }
    /// <summary>
    /// <para>Font size of the <see cref="Label3D" />'s text. To make the font look more detailed when up close, increase <see cref="Label3D.FontSize" /> while decreasing <see cref="Label3D.PixelSize" /> at the same time.</para>
    /// <para>Higher font sizes require more time to render new characters, which can cause stuttering during gameplay.</para>
    /// </summary>
    public int FontSize { get => _node.FontSize; set => _node.FontSize = value; }
    /// <summary>
    /// <para>Returns a <see cref="TriangleMesh" /> with the label's vertices following its current configuration (such as its <see cref="Label3D.PixelSize" />).</para>
    /// </summary>
    public TriangleMesh GenerateTriangleMesh() => _node.GenerateTriangleMesh();
    /// <summary>
    /// <para>Controls the text's horizontal alignment. Supports left, center, right, and fill, or justify. Set it to one of the <see cref="HorizontalAlignment" /> constants.</para>
    /// </summary>
    public HorizontalAlignment HorizontalAlignment { get => _node.HorizontalAlignment; set => _node.HorizontalAlignment = value; }
    /// <summary>
    /// <para>Line fill alignment rules. For more info see <see cref="TextServer.JustificationFlag" />.</para>
    /// </summary>
    public TextServer.JustificationFlag JustificationFlags { get => _node.JustificationFlags; set => _node.JustificationFlags = value; }
    /// <summary>
    /// <para>Language code used for line-breaking and text shaping algorithms, if left empty current locale is used instead.</para>
    /// </summary>
    public string Language { get => _node.Language; set => _node.Language = value; }
    /// <summary>
    /// <para>Vertical space between lines in multiline <see cref="Label3D" />.</para>
    /// </summary>
    public float LineSpacing { get => _node.LineSpacing; set => _node.LineSpacing = value; }
    /// <summary>
    /// <para>Text <see cref="Color" /> of the <see cref="Label3D" />.</para>
    /// </summary>
    public Color Modulate { get => _node.Modulate; set => _node.Modulate = value; }
    /// <summary>
    /// <para>If <c>true</c>, depth testing is disabled and the object will be drawn in render order.</para>
    /// </summary>
    public bool NoDepthTest { get => _node.NoDepthTest; set => _node.NoDepthTest = value; }
    /// <summary>
    /// <para>The text drawing offset (in pixels).</para>
    /// </summary>
    public Vector2 Offset { get => _node.Offset; set => _node.Offset = value; }
    /// <summary>
    /// <para>The tint of text outline.</para>
    /// </summary>
    public Color OutlineModulate { get => _node.OutlineModulate; set => _node.OutlineModulate = value; }
    /// <summary>
    /// <para>Sets the render priority for the text outline. Higher priority objects will be sorted in front of lower priority objects.</para>
    /// <para><b>Note:</b> This only applies if <see cref="Label3D.AlphaCut" /> is set to <see cref="Label3D.AlphaCutMode.Disabled" /> (default value).</para>
    /// <para><b>Note:</b> This only applies to sorting of transparent objects. This will not impact how transparent objects are sorted relative to opaque objects. This is because opaque objects are not sorted, while transparent objects are sorted from back to front (subject to priority).</para>
    /// </summary>
    public int OutlineRenderPriority { get => _node.OutlineRenderPriority; set => _node.OutlineRenderPriority = value; }
    /// <summary>
    /// <para>Text outline size.</para>
    /// </summary>
    public int OutlineSize { get => _node.OutlineSize; set => _node.OutlineSize = value; }
    /// <summary>
    /// <para>The size of one pixel's width on the label to scale it in 3D. To make the font look more detailed when up close, increase <see cref="Label3D.FontSize" /> while decreasing <see cref="Label3D.PixelSize" /> at the same time.</para>
    /// </summary>
    public float PixelSize { get => _node.PixelSize; set => _node.PixelSize = value; }
    /// <summary>
    /// <para>Sets the render priority for the text. Higher priority objects will be sorted in front of lower priority objects.</para>
    /// <para><b>Note:</b> This only applies if <see cref="Label3D.AlphaCut" /> is set to <see cref="Label3D.AlphaCutMode.Disabled" /> (default value).</para>
    /// <para><b>Note:</b> This only applies to sorting of transparent objects. This will not impact how transparent objects are sorted relative to opaque objects. This is because opaque objects are not sorted, while transparent objects are sorted from back to front (subject to priority).</para>
    /// </summary>
    public int RenderPriority { get => _node.RenderPriority; set => _node.RenderPriority = value; }
    /// <summary>
    /// <para>If <c>true</c>, the <see cref="Light3D" /> in the <see cref="Environment" /> has effects on the label.</para>
    /// </summary>
    public bool Shaded { get => _node.Shaded; set => _node.Shaded = value; }
    /// <summary>
    /// <para>Set BiDi algorithm override for the structured text.</para>
    /// </summary>
    public TextServer.StructuredTextParser StructuredTextBidiOverride { get => _node.StructuredTextBidiOverride; set => _node.StructuredTextBidiOverride = value; }
    /// <summary>
    /// <para>Set additional options for BiDi override.</para>
    /// </summary>
    public Godot.Collections.Array StructuredTextBidiOverrideOptions { get => _node.StructuredTextBidiOverrideOptions; set => _node.StructuredTextBidiOverrideOptions = value; }
    /// <summary>
    /// <para>The text to display on screen.</para>
    /// </summary>
    public string Text { get => _node.Text; set => _node.Text = value; }
    /// <summary>
    /// <para>Base text writing direction.</para>
    /// </summary>
    public TextServer.Direction TextDirection { get => _node.TextDirection; set => _node.TextDirection = value; }
    /// <summary>
    /// <para>Filter flags for the texture. See <see cref="BaseMaterial3D.TextureFilterEnum" /> for options.</para>
    /// </summary>
    public BaseMaterial3D.TextureFilterEnum TextureFilter { get => _node.TextureFilter; set => _node.TextureFilter = value; }
    /// <summary>
    /// <para>If <c>true</c>, all the text displays as UPPERCASE.</para>
    /// </summary>
    public bool Uppercase { get => _node.Uppercase; set => _node.Uppercase = value; }
    /// <summary>
    /// <para>Controls the text's vertical alignment. Supports top, center, bottom. Set it to one of the <see cref="VerticalAlignment" /> constants.</para>
    /// </summary>
    public VerticalAlignment VerticalAlignment { get => _node.VerticalAlignment; set => _node.VerticalAlignment = value; }
    /// <summary>
    /// <para>Text width (in pixels), used for autowrap and fill alignment.</para>
    /// </summary>
    public float Width { get => _node.Width; set => _node.Width = value; }

}