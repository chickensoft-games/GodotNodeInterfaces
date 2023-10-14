namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class GpuParticlesCollisionSdf3DNode : GpuParticlesCollisionSdf3D, IGpuParticlesCollisionSdf3D { }

/// <summary>
/// <para>A baked signed distance field 3D particle collision shape affecting <see cref="GpuParticles3D" /> nodes.</para>
/// <para>Signed distance fields (SDF) allow for efficiently representing approximate collision shapes for convex and concave objects of any shape. This is more flexible than <see cref="GpuParticlesCollisionHeightField3D" />, but it requires a baking step.</para>
/// <para><b>Baking:</b> The signed distance field texture can be baked by selecting the <see cref="GpuParticlesCollisionSdf3D" /> node in the editor, then clicking <b>Bake SDF</b> at the top of the 3D viewport. Any <i>visible</i> <see cref="MeshInstance3D" />s within the <see cref="GpuParticlesCollisionSdf3D.Size" /> will be taken into account for baking, regardless of their <see cref="GeometryInstance3D.GIMode" />.</para>
/// <para><b>Note:</b> Baking a <see cref="GpuParticlesCollisionSdf3D" />'s <see cref="GpuParticlesCollisionSdf3D.Texture" /> is only possible within the editor, as there is no bake method exposed for use in exported projects. However, it's still possible to load pre-baked <see cref="Texture3D" />s into its <see cref="GpuParticlesCollisionSdf3D.Texture" /> property in an exported project.</para>
/// <para><b>Note:</b> <see cref="ParticleProcessMaterial.CollisionMode" /> must be <see cref="ParticleProcessMaterial.CollisionModeEnum.Rigid" /> or <see cref="ParticleProcessMaterial.CollisionModeEnum.HideOnContact" /> on the <see cref="GpuParticles3D" />'s process material for collision to work.</para>
/// <para><b>Note:</b> Particle collision only affects <see cref="GpuParticles3D" />, not <see cref="CpuParticles3D" />.</para>
/// </summary>
public interface IGpuParticlesCollisionSdf3D : IGpuParticlesCollision3D {
    /// <summary>
    /// <para>The visual layers to account for when baking the particle collision SDF. Only <see cref="MeshInstance3D" />s whose <see cref="VisualInstance3D.Layers" /> match with this <see cref="GpuParticlesCollisionSdf3D.BakeMask" /> will be included in the generated particle collision SDF. By default, all objects are taken into account for the particle collision SDF baking.</para>
    /// </summary>
    uint BakeMask { get; set; }
    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="GpuParticlesCollisionSdf3D.BakeMask" /> is enabled, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    bool GetBakeMaskValue(int layerNumber);
    /// <summary>
    /// <para>The bake resolution to use for the signed distance field <see cref="GpuParticlesCollisionSdf3D.Texture" />. The texture must be baked again for changes to the <see cref="GpuParticlesCollisionSdf3D.Resolution" /> property to be effective. Higher resolutions have a greater performance cost and take more time to bake. Higher resolutions also result in larger baked textures, leading to increased VRAM and storage space requirements. To improve performance and reduce bake times, use the lowest resolution possible for the object you're representing the collision of.</para>
    /// </summary>
    GpuParticlesCollisionSdf3D.ResolutionEnum Resolution { get; set; }
    /// <summary>
    /// <para>Based on <paramref name="value" />, enables or disables the specified layer in the <see cref="GpuParticlesCollisionSdf3D.BakeMask" />, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    void SetBakeMaskValue(int layerNumber, bool value);
    /// <summary>
    /// <para>The collision SDF's size in 3D units. To improve SDF quality, the <see cref="GpuParticlesCollisionSdf3D.Size" /> should be set as small as possible while covering the parts of the scene you need.</para>
    /// </summary>
    Vector3 Size { get; set; }
    /// <summary>
    /// <para>The 3D texture representing the signed distance field.</para>
    /// </summary>
    Texture3D Texture { get; set; }
    /// <summary>
    /// <para>The collision shape's thickness. Unlike other particle colliders, <see cref="GpuParticlesCollisionSdf3D" /> is actually hollow on the inside. <see cref="GpuParticlesCollisionSdf3D.Thickness" /> can be increased to prevent particles from tunneling through the collision shape at high speeds, or when the <see cref="GpuParticlesCollisionSdf3D" /> is moved.</para>
    /// </summary>
    float Thickness { get; set; }

}