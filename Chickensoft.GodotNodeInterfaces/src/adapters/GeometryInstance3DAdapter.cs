namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>Base node for geometry-based visual instances. Shares some common functionality like visibility and custom materials.</para>
/// </summary>
public class GeometryInstance3DAdapter : GeometryInstance3D, IGeometryInstance3D {
  private readonly GeometryInstance3D _node;

  public GeometryInstance3DAdapter(GeometryInstance3D node) => _node = node;
    /// <summary>
    /// <para>The selected shadow casting flag. See <see cref="GeometryInstance3D.ShadowCastingSetting" /> for possible values.</para>
    /// </summary>
    public GeometryInstance3D.ShadowCastingSetting CastShadow { get => _node.CastShadow; set => _node.CastShadow = value; }
    /// <summary>
    /// <para>Overrides the bounding box of this node with a custom one. This can be used to avoid the expensive <see cref="Aabb" /> recalculation that happens when a skeleton is used with a <see cref="MeshInstance3D" /> or to have fine control over the <see cref="MeshInstance3D" />'s bounding box. To use the default AABB, set value to an <see cref="Aabb" /> with all fields set to <c>0.0</c>. To avoid frustum culling, set <see cref="GeometryInstance3D.CustomAabb" /> to a very large AABB that covers your entire game world such as <c>AABB(-10000, -10000, -10000, 20000, 20000, 20000)</c>. To disable all forms of culling (including occlusion culling), call <see cref="RenderingServer.InstanceSetIgnoreCulling(Godot.Rid,System.Boolean)" /> on the <see cref="GeometryInstance3D" />'s <see cref="Rid" />.</para>
    /// </summary>
    public Aabb CustomAabb { get => _node.CustomAabb; set => _node.CustomAabb = value; }
    /// <summary>
    /// <para>The extra distance added to the GeometryInstance3D's bounding box (<see cref="Aabb" />) to increase its cull box.</para>
    /// </summary>
    public float ExtraCullMargin { get => _node.ExtraCullMargin; set => _node.ExtraCullMargin = value; }
    /// <summary>
    /// <para>Get the value of a shader parameter as set on this instance.</para>
    /// </summary>
    public Variant GetInstanceShaderParameter(StringName name) => _node.GetInstanceShaderParameter(name);
    /// <summary>
    /// <para>The texel density to use for lightmapping in <see cref="LightmapGI" />. Greater scale values provide higher resolution in the lightmap, which can result in sharper shadows for lights that have both direct and indirect light baked. However, greater scale values will also increase the space taken by the mesh in the lightmap texture, which increases the memory, storage, and bake time requirements. When using a single mesh at different scales, consider adjusting this value to keep the lightmap texel density consistent across meshes.</para>
    /// </summary>
    public GeometryInstance3D.LightmapScale GILightmapScale { get => _node.GILightmapScale; set => _node.GILightmapScale = value; }
    /// <summary>
    /// <para>The global illumination mode to use for the whole geometry. To avoid inconsistent results, use a mode that matches the purpose of the mesh during gameplay (static/dynamic).</para>
    /// <para><b>Note:</b> Lights' bake mode will also affect the global illumination rendering. See <see cref="Light3D.LightBakeMode" />.</para>
    /// </summary>
    public GeometryInstance3D.GIModeEnum GIMode { get => _node.GIMode; set => _node.GIMode = value; }
    /// <summary>
    /// <para>If <c>true</c>, disables occlusion culling for this instance. Useful for gizmos that must be rendered even when occlusion culling is in use.</para>
    /// <para><b>Note:</b> <see cref="GeometryInstance3D.IgnoreOcclusionCulling" /> does not affect frustum culling (which is what happens when an object is not visible given the camera's angle). To avoid frustum culling, set <see cref="GeometryInstance3D.CustomAabb" /> to a very large AABB that covers your entire game world such as <c>AABB(-10000, -10000, -10000, 20000, 20000, 20000)</c>.</para>
    /// </summary>
    public bool IgnoreOcclusionCulling { get => _node.IgnoreOcclusionCulling; set => _node.IgnoreOcclusionCulling = value; }
    /// <summary>
    /// <para>Changes how quickly the mesh transitions to a lower level of detail. A value of 0 will force the mesh to its lowest level of detail, a value of 1 will use the default settings, and larger values will keep the mesh in a higher level of detail at farther distances.</para>
    /// <para>Useful for testing level of detail transitions in the editor.</para>
    /// </summary>
    public float LodBias { get => _node.LodBias; set => _node.LodBias = value; }
    /// <summary>
    /// <para>The material overlay for the whole geometry.</para>
    /// <para>If a material is assigned to this property, it will be rendered on top of any other active material for all the surfaces.</para>
    /// </summary>
    public Material MaterialOverlay { get => _node.MaterialOverlay; set => _node.MaterialOverlay = value; }
    /// <summary>
    /// <para>The material override for the whole geometry.</para>
    /// <para>If a material is assigned to this property, it will be used instead of any material set in any material slot of the mesh.</para>
    /// </summary>
    public Material MaterialOverride { get => _node.MaterialOverride; set => _node.MaterialOverride = value; }
    /// <summary>
    /// <para>Set the value of a shader uniform for this instance only (<a href="$DOCS_URL/tutorials/shaders/shader_reference/shading_language.html#per-instance-uniforms">per-instance uniform</a>). See also <see cref="ShaderMaterial.SetShaderParameter(Godot.StringName,Godot.Variant)" /> to assign a uniform on all instances using the same <see cref="ShaderMaterial" />.</para>
    /// <para><b>Note:</b> For a shader uniform to be assignable on a per-instance basis, it <i>must</i> be defined with <c>instance uniform ...</c> rather than <c>uniform ...</c> in the shader code.</para>
    /// <para><b>Note:</b> <paramref name="name" /> is case-sensitive and must match the name of the uniform in the code exactly (not the capitalized name in the inspector).</para>
    /// <para><b>Note:</b> Per-instance shader uniforms are currently only available in 3D, so there is no 2D equivalent of this method.</para>
    /// </summary>
    public void SetInstanceShaderParameter(StringName name, Variant value) => _node.SetInstanceShaderParameter(name, value);
    /// <summary>
    /// <para>The transparency applied to the whole geometry (as a multiplier of the materials' existing transparency). <c>0.0</c> is fully opaque, while <c>1.0</c> is fully transparent. Values greater than <c>0.0</c> (exclusive) will force the geometry's materials to go through the transparent pipeline, which is slower to render and can exhibit rendering issues due to incorrect transparency sorting. However, unlike using a transparent material, setting <see cref="GeometryInstance3D.Transparency" /> to a value greater than <c>0.0</c> (exclusive) will <i>not</i> disable shadow rendering.</para>
    /// <para>In spatial shaders, <c>1.0 - transparency</c> is set as the default value of the <c>ALPHA</c> built-in.</para>
    /// <para><b>Note:</b> <see cref="GeometryInstance3D.Transparency" /> is clamped between <c>0.0</c> and <c>1.0</c>, so this property cannot be used to make transparent materials more opaque than they originally are.</para>
    /// </summary>
    public float Transparency { get => _node.Transparency; set => _node.Transparency = value; }
    /// <summary>
    /// <para>Starting distance from which the GeometryInstance3D will be visible, taking <see cref="GeometryInstance3D.VisibilityRangeBeginMargin" /> into account as well. The default value of 0 is used to disable the range check.</para>
    /// </summary>
    public float VisibilityRangeBegin { get => _node.VisibilityRangeBegin; set => _node.VisibilityRangeBegin = value; }
    /// <summary>
    /// <para>Margin for the <see cref="GeometryInstance3D.VisibilityRangeBegin" /> threshold. The GeometryInstance3D will only change its visibility state when it goes over or under the <see cref="GeometryInstance3D.VisibilityRangeBegin" /> threshold by this amount.</para>
    /// <para>If <see cref="GeometryInstance3D.VisibilityRangeFadeMode" /> is <see cref="GeometryInstance3D.VisibilityRangeFadeModeEnum.Disabled" />, this acts as a hysteresis distance. If <see cref="GeometryInstance3D.VisibilityRangeFadeMode" /> is <see cref="GeometryInstance3D.VisibilityRangeFadeModeEnum.Self" /> or <see cref="GeometryInstance3D.VisibilityRangeFadeModeEnum.Dependencies" />, this acts as a fade transition distance and must be set to a value greater than <c>0.0</c> for the effect to be noticeable.</para>
    /// </summary>
    public float VisibilityRangeBeginMargin { get => _node.VisibilityRangeBeginMargin; set => _node.VisibilityRangeBeginMargin = value; }
    /// <summary>
    /// <para>Distance from which the GeometryInstance3D will be hidden, taking <see cref="GeometryInstance3D.VisibilityRangeEndMargin" /> into account as well. The default value of 0 is used to disable the range check.</para>
    /// </summary>
    public float VisibilityRangeEnd { get => _node.VisibilityRangeEnd; set => _node.VisibilityRangeEnd = value; }
    /// <summary>
    /// <para>Margin for the <see cref="GeometryInstance3D.VisibilityRangeEnd" /> threshold. The GeometryInstance3D will only change its visibility state when it goes over or under the <see cref="GeometryInstance3D.VisibilityRangeEnd" /> threshold by this amount.</para>
    /// <para>If <see cref="GeometryInstance3D.VisibilityRangeFadeMode" /> is <see cref="GeometryInstance3D.VisibilityRangeFadeModeEnum.Disabled" />, this acts as a hysteresis distance. If <see cref="GeometryInstance3D.VisibilityRangeFadeMode" /> is <see cref="GeometryInstance3D.VisibilityRangeFadeModeEnum.Self" /> or <see cref="GeometryInstance3D.VisibilityRangeFadeModeEnum.Dependencies" />, this acts as a fade transition distance and must be set to a value greater than <c>0.0</c> for the effect to be noticeable.</para>
    /// </summary>
    public float VisibilityRangeEndMargin { get => _node.VisibilityRangeEndMargin; set => _node.VisibilityRangeEndMargin = value; }
    /// <summary>
    /// <para>Controls which instances will be faded when approaching the limits of the visibility range. See <see cref="GeometryInstance3D.VisibilityRangeFadeModeEnum" /> for possible values.</para>
    /// </summary>
    public GeometryInstance3D.VisibilityRangeFadeModeEnum VisibilityRangeFadeMode { get => _node.VisibilityRangeFadeMode; set => _node.VisibilityRangeFadeMode = value; }

}