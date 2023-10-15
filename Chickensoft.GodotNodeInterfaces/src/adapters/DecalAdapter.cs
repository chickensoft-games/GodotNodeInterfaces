namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para><see cref="Decal" />s are used to project a texture onto a <see cref="Mesh" /> in the scene. Use Decals to add detail to a scene without affecting the underlying <see cref="Mesh" />. They are often used to add weathering to building, add dirt or mud to the ground, or add variety to props. Decals can be moved at any time, making them suitable for things like blob shadows or laser sight dots.</para>
/// <para>They are made of an <see cref="Aabb" /> and a group of <see cref="Texture2D" />s specifying <see cref="Color" />, normal, ORM (ambient occlusion, roughness, metallic), and emission. Decals are projected within their <see cref="Aabb" /> so altering the orientation of the Decal affects the direction in which they are projected. By default, Decals are projected down (i.e. from positive Y to negative Y).</para>
/// <para>The <see cref="Texture2D" />s associated with the Decal are automatically stored in a texture atlas which is used for drawing the decals so all decals can be drawn at once. Godot uses clustered decals, meaning they are stored in cluster data and drawn when the mesh is drawn, they are not drawn as a post-processing effect after.</para>
/// <para><b>Note:</b> Decals cannot affect an underlying material's transparency, regardless of its transparency mode (alpha blend, alpha scissor, alpha hash, opaque pre-pass). This means translucent or transparent areas of a material will remain translucent or transparent even if an opaque decal is applied on them.</para>
/// <para><b>Note:</b> Decals are only supported in the Forward+ and Mobile rendering methods, not Compatibility. When using the Mobile rendering method, only 8 decals can be displayed on each mesh resource. Attempting to display more than 8 decals on a single mesh resource will result in decals flickering in and out as the camera moves.</para>
/// <para><b>Note:</b> When using the Mobile rendering method, decals will only correctly affect meshes whose visibility AABB intersects with the decal's AABB. If using a shader to deform the mesh in a way that makes it go outside its AABB, <see cref="GeometryInstance3D.ExtraCullMargin" /> must be increased on the mesh. Otherwise, the decal may not be visible on the mesh.</para>
/// </summary>
public class DecalAdapter : VisualInstance3DAdapter, IDecal {
  private readonly Decal _node;

  public DecalAdapter(Node node) : base(node) {
    if (node is not Decal typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a Decal"
      );
    }
    _node = typedNode;
  }

    /// <summary>
    /// <para>Blends the albedo <see cref="Color" /> of the decal with albedo <see cref="Color" /> of the underlying mesh. This can be set to <c>0.0</c> to create a decal that only affects normal or ORM. In this case, an albedo texture is still required as its alpha channel will determine where the normal and ORM will be overridden. See also <see cref="Decal.Modulate" />.</para>
    /// </summary>
    public float AlbedoMix { get => _node.AlbedoMix; set => _node.AlbedoMix = value; }
    /// <summary>
    /// <para>Specifies which <see cref="VisualInstance3D.Layers" /> this decal will project on. By default, Decals affect all layers. This is used so you can specify which types of objects receive the Decal and which do not. This is especially useful so you can ensure that dynamic objects don't accidentally receive a Decal intended for the terrain under them.</para>
    /// </summary>
    public uint CullMask { get => _node.CullMask; set => _node.CullMask = value; }
    /// <summary>
    /// <para>The distance from the camera at which the Decal begins to fade away (in 3D units).</para>
    /// </summary>
    public float DistanceFadeBegin { get => _node.DistanceFadeBegin; set => _node.DistanceFadeBegin = value; }
    /// <summary>
    /// <para>If <c>true</c>, decals will smoothly fade away when far from the active <see cref="Camera3D" /> starting at <see cref="Decal.DistanceFadeBegin" />. The Decal will fade out over <see cref="Decal.DistanceFadeBegin" /> + <see cref="Decal.DistanceFadeLength" />, after which it will be culled and not sent to the shader at all. Use this to reduce the number of active Decals in a scene and thus improve performance.</para>
    /// </summary>
    public bool DistanceFadeEnabled { get => _node.DistanceFadeEnabled; set => _node.DistanceFadeEnabled = value; }
    /// <summary>
    /// <para>The distance over which the Decal fades (in 3D units). The Decal becomes slowly more transparent over this distance and is completely invisible at the end. Higher values result in a smoother fade-out transition, which is more suited when the camera moves fast.</para>
    /// </summary>
    public float DistanceFadeLength { get => _node.DistanceFadeLength; set => _node.DistanceFadeLength = value; }
    /// <summary>
    /// <para>Energy multiplier for the emission texture. This will make the decal emit light at a higher or lower intensity, independently of the albedo color. See also <see cref="Decal.Modulate" />.</para>
    /// </summary>
    public float EmissionEnergy { get => _node.EmissionEnergy; set => _node.EmissionEnergy = value; }
    /// <summary>
    /// <para>Sets the curve over which the decal will fade as the surface gets further from the center of the <see cref="Aabb" />. Only positive values are valid (negative values will be clamped to <c>0.0</c>). See also <see cref="Decal.UpperFade" />.</para>
    /// </summary>
    public float LowerFade { get => _node.LowerFade; set => _node.LowerFade = value; }
    /// <summary>
    /// <para>Changes the <see cref="Color" /> of the Decal by multiplying the albedo and emission colors with this value. The alpha component is only taken into account when multiplying the albedo color, not the emission color. See also <see cref="Decal.EmissionEnergy" /> and <see cref="Decal.AlbedoMix" /> to change the emission and albedo intensity independently of each other.</para>
    /// </summary>
    public Color Modulate { get => _node.Modulate; set => _node.Modulate = value; }
    /// <summary>
    /// <para>Fades the Decal if the angle between the Decal's <see cref="Aabb" /> and the target surface becomes too large. A value of <c>0</c> projects the Decal regardless of angle, a value of <c>1</c> limits the Decal to surfaces that are nearly perpendicular.</para>
    /// <para><b>Note:</b> Setting <see cref="Decal.NormalFade" /> to a value greater than <c>0.0</c> has a small performance cost due to the added normal angle computations.</para>
    /// </summary>
    public float NormalFade { get => _node.NormalFade; set => _node.NormalFade = value; }
    /// <summary>
    /// <para>Sets the size of the <see cref="Aabb" /> used by the decal. All dimensions must be set to a value greater than zero (they will be clamped to <c>0.001</c> if this is not the case). The AABB goes from <c>-size/2</c> to <c>size/2</c>.</para>
    /// <para><b>Note:</b> To improve culling efficiency of "hard surface" decals, set their <see cref="Decal.UpperFade" /> and <see cref="Decal.LowerFade" /> to <c>0.0</c> and set the Y component of the <see cref="Decal.Size" /> as low as possible. This will reduce the decals' AABB size without affecting their appearance.</para>
    /// </summary>
    public Vector3 Size { get => _node.Size; set => _node.Size = value; }
    /// <summary>
    /// <para><see cref="Texture2D" /> with the base <see cref="Color" /> of the Decal. Either this or the <see cref="Decal.TextureEmission" /> must be set for the Decal to be visible. Use the alpha channel like a mask to smoothly blend the edges of the decal with the underlying object.</para>
    /// <para><b>Note:</b> Unlike <see cref="BaseMaterial3D" /> whose filter mode can be adjusted on a per-material basis, the filter mode for <see cref="Decal" /> textures is set globally with <c>ProjectSettings.rendering/textures/decals/filter</c>.</para>
    /// </summary>
    public Texture2D TextureAlbedo { get => _node.TextureAlbedo; set => _node.TextureAlbedo = value; }
    /// <summary>
    /// <para><see cref="Texture2D" /> with the emission <see cref="Color" /> of the Decal. Either this or the <see cref="Decal.TextureAlbedo" /> must be set for the Decal to be visible. Use the alpha channel like a mask to smoothly blend the edges of the decal with the underlying object.</para>
    /// <para><b>Note:</b> Unlike <see cref="BaseMaterial3D" /> whose filter mode can be adjusted on a per-material basis, the filter mode for <see cref="Decal" /> textures is set globally with <c>ProjectSettings.rendering/textures/decals/filter</c>.</para>
    /// </summary>
    public Texture2D TextureEmission { get => _node.TextureEmission; set => _node.TextureEmission = value; }
    /// <summary>
    /// <para><see cref="Texture2D" /> with the per-pixel normal map for the decal. Use this to add extra detail to decals.</para>
    /// <para><b>Note:</b> Unlike <see cref="BaseMaterial3D" /> whose filter mode can be adjusted on a per-material basis, the filter mode for <see cref="Decal" /> textures is set globally with <c>ProjectSettings.rendering/textures/decals/filter</c>.</para>
    /// <para><b>Note:</b> Setting this texture alone will not result in a visible decal, as <see cref="Decal.TextureAlbedo" /> must also be set. To create a normal-only decal, load an albedo texture into <see cref="Decal.TextureAlbedo" /> and set <see cref="Decal.AlbedoMix" /> to <c>0.0</c>. The albedo texture's alpha channel will be used to determine where the underlying surface's normal map should be overridden (and its intensity).</para>
    /// </summary>
    public Texture2D TextureNormal { get => _node.TextureNormal; set => _node.TextureNormal = value; }
    /// <summary>
    /// <para><see cref="Texture2D" /> storing ambient occlusion, roughness, and metallic for the decal. Use this to add extra detail to decals.</para>
    /// <para><b>Note:</b> Unlike <see cref="BaseMaterial3D" /> whose filter mode can be adjusted on a per-material basis, the filter mode for <see cref="Decal" /> textures is set globally with <c>ProjectSettings.rendering/textures/decals/filter</c>.</para>
    /// <para><b>Note:</b> Setting this texture alone will not result in a visible decal, as <see cref="Decal.TextureAlbedo" /> must also be set. To create an ORM-only decal, load an albedo texture into <see cref="Decal.TextureAlbedo" /> and set <see cref="Decal.AlbedoMix" /> to <c>0.0</c>. The albedo texture's alpha channel will be used to determine where the underlying surface's ORM map should be overridden (and its intensity).</para>
    /// </summary>
    public Texture2D TextureOrm { get => _node.TextureOrm; set => _node.TextureOrm = value; }
    /// <summary>
    /// <para>Sets the curve over which the decal will fade as the surface gets further from the center of the <see cref="Aabb" />. Only positive values are valid (negative values will be clamped to <c>0.0</c>). See also <see cref="Decal.LowerFade" />.</para>
    /// </summary>
    public float UpperFade { get => _node.UpperFade; set => _node.UpperFade = value; }

}