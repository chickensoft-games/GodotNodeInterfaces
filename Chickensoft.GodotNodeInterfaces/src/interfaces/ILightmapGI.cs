namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class LightmapGINode : LightmapGI, ILightmapGI { }

/// <summary>
/// <para>The <see cref="LightmapGI" /> node is used to compute and store baked lightmaps. Lightmaps are used to provide high-quality indirect lighting with very little light leaking. <see cref="LightmapGI" /> can also provide rough reflections using spherical harmonics if <see cref="LightmapGI.Directional" /> is enabled. Dynamic objects can receive indirect lighting thanks to <i>light probes</i>, which can be automatically placed by setting <see cref="LightmapGI.GenerateProbesSubdiv" /> to a value other than <see cref="LightmapGI.GenerateProbes.Disabled" />. Additional lightmap probes can also be added by creating <see cref="LightmapProbe" /> nodes. The downside is that lightmaps are fully static and cannot be baked in an exported project. Baking a <see cref="LightmapGI" /> node is also slower compared to <see cref="VoxelGI" />.</para>
/// <para><b>Procedural generation:</b> Lightmap baking functionality is only available in the editor. This means <see cref="LightmapGI" /> is not suited to procedurally generated or user-built levels. For procedurally generated or user-built levels, use <see cref="VoxelGI" /> or SDFGI instead (see <see cref="Environment.SdfgiEnabled" />).</para>
/// <para><b>Performance:</b> <see cref="LightmapGI" /> provides the best possible run-time performance for global illumination. It is suitable for low-end hardware including integrated graphics and mobile devices.</para>
/// <para><b>Note:</b> Due to how lightmaps work, most properties only have a visible effect once lightmaps are baked again.</para>
/// <para><b>Note:</b> Lightmap baking on <see cref="CsgShape3D" />s and <see cref="PrimitiveMesh" />es is not supported, as these cannot store UV2 data required for baking.</para>
/// <para><b>Note:</b> If no custom lightmappers are installed, <see cref="LightmapGI" /> can only be baked when using the Vulkan backend (Forward+ or Mobile), not OpenGL.</para>
/// </summary>
public interface ILightmapGI : IVisualInstance3D {
    /// <summary>
    /// <para>The bias to use when computing shadows. Increasing <see cref="LightmapGI.Bias" /> can fix shadow acne on the resulting baked lightmap, but can introduce peter-panning (shadows not connecting to their casters). Real-time <see cref="Light3D" /> shadows are not affected by this <see cref="LightmapGI.Bias" /> property.</para>
    /// </summary>
    float Bias { get; set; }
    /// <summary>
    /// <para>Number of light bounces that are taken into account during baking. Higher values result in brighter, more realistic lighting, at the cost of longer bake times. If set to <c>0</c>, only environment lighting, direct light and emissive lighting is baked.</para>
    /// </summary>
    int Bounces { get; set; }
    /// <summary>
    /// <para>The <see cref="CameraAttributes" /> resource that specifies exposure levels to bake at. Auto-exposure and non exposure properties will be ignored. Exposure settings should be used to reduce the dynamic range present when baking. If exposure is too high, the <see cref="LightmapGI" /> will have banding artifacts or may have over-exposure artifacts.</para>
    /// </summary>
    CameraAttributes CameraAttributes { get; set; }
    /// <summary>
    /// <para>The strength of denoising step applied to the generated lightmaps. Only effective if <see cref="LightmapGI.UseDenoiser" /> is <c>true</c> and <c>ProjectSettings.rendering/lightmapping/denoising/denoiser</c> is set to JNLM.</para>
    /// </summary>
    float DenoiserStrength { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, bakes lightmaps to contain directional information as spherical harmonics. This results in more realistic lighting appearance, especially with normal mapped materials and for lights that have their direct light baked (<see cref="Light3D.LightBakeMode" /> set to <see cref="Light3D.BakeMode.Static" />). The directional information is also used to provide rough reflections for static and dynamic objects. This has a small run-time performance cost as the shader has to perform more work to interpret the direction information from the lightmap. Directional lightmaps also take longer to bake and result in larger file sizes.</para>
    /// <para><b>Note:</b> The property's name has no relationship with <see cref="DirectionalLight3D" />. <see cref="LightmapGI.Directional" /> works with all light types.</para>
    /// </summary>
    bool Directional { get; set; }
    /// <summary>
    /// <para>The color to use for environment lighting. Only effective if <see cref="LightmapGI.EnvironmentMode" /> is <see cref="LightmapGI.EnvironmentModeEnum.CustomColor" />.</para>
    /// </summary>
    Color EnvironmentCustomColor { get; set; }
    /// <summary>
    /// <para>The color multiplier to use for environment lighting. Only effective if <see cref="LightmapGI.EnvironmentMode" /> is <see cref="LightmapGI.EnvironmentModeEnum.CustomColor" />.</para>
    /// </summary>
    float EnvironmentCustomEnergy { get; set; }
    /// <summary>
    /// <para>The sky to use as a source of environment lighting. Only effective if <see cref="LightmapGI.EnvironmentMode" /> is <see cref="LightmapGI.EnvironmentModeEnum.CustomSky" />.</para>
    /// </summary>
    Sky EnvironmentCustomSky { get; set; }
    /// <summary>
    /// <para>The environment mode to use when baking lightmaps.</para>
    /// </summary>
    LightmapGI.EnvironmentModeEnum EnvironmentMode { get; set; }
    /// <summary>
    /// <para>The level of subdivision to use when automatically generating <see cref="LightmapProbe" />s for dynamic object lighting. Higher values result in more accurate indirect lighting on dynamic objects, at the cost of longer bake times and larger file sizes.</para>
    /// <para><b>Note:</b> Automatically generated <see cref="LightmapProbe" />s are not visible as nodes in the Scene tree dock, and cannot be modified this way after they are generated.</para>
    /// <para><b>Note:</b> Regardless of <see cref="LightmapGI.GenerateProbesSubdiv" />, direct lighting on dynamic objects is always applied using <see cref="Light3D" /> nodes in real-time.</para>
    /// </summary>
    LightmapGI.GenerateProbes GenerateProbesSubdiv { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, ignore environment lighting when baking lightmaps.</para>
    /// </summary>
    bool Interior { get; set; }
    /// <summary>
    /// <para>The <see cref="LightmapGIData" /> associated to this <see cref="LightmapGI" /> node. This resource is automatically created after baking, and is not meant to be created manually.</para>
    /// </summary>
    LightmapGIData LightData { get; set; }
    /// <summary>
    /// <para>The maximum texture size for the generated texture atlas. Higher values will result in fewer slices being generated, but may not work on all hardware as a result of hardware limitations on texture sizes. Leave <see cref="LightmapGI.MaxTextureSize" /> at its default value of <c>16384</c> if unsure.</para>
    /// </summary>
    int MaxTextureSize { get; set; }
    /// <summary>
    /// <para>The quality preset to use when baking lightmaps. This affects bake times, but output file sizes remain mostly identical across quality levels.</para>
    /// <para>To further speed up bake times, decrease <see cref="LightmapGI.Bounces" />, disable <see cref="LightmapGI.UseDenoiser" /> and increase the lightmap texel size on 3D scenes in the Import doc.</para>
    /// </summary>
    LightmapGI.BakeQuality Quality { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, uses a GPU-based denoising algorithm on the generated lightmap. This eliminates most noise within the generated lightmap at the cost of longer bake times. File sizes are generally not impacted significantly by the use of a denoiser, although lossless compression may do a better job at compressing a denoised image.</para>
    /// </summary>
    bool UseDenoiser { get; set; }

}