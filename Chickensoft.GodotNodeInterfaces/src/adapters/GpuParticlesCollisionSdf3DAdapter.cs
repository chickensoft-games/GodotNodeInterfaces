namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A baked signed distance field 3D particle collision shape affecting <see cref="GpuParticles3D" /> nodes.</para>
/// <para>Signed distance fields (SDF) allow for efficiently representing approximate collision shapes for convex and concave objects of any shape. This is more flexible than <see cref="GpuParticlesCollisionHeightField3D" />, but it requires a baking step.</para>
/// <para><b>Baking:</b> The signed distance field texture can be baked by selecting the <see cref="GpuParticlesCollisionSdf3D" /> node in the editor, then clicking <b>Bake SDF</b> at the top of the 3D viewport. Any <i>visible</i> <see cref="MeshInstance3D" />s within the <see cref="GpuParticlesCollisionSdf3D.Size" /> will be taken into account for baking, regardless of their <see cref="GeometryInstance3D.GIMode" />.</para>
/// <para><b>Note:</b> Baking a <see cref="GpuParticlesCollisionSdf3D" />'s <see cref="GpuParticlesCollisionSdf3D.Texture" /> is only possible within the editor, as there is no bake method exposed for use in exported projects. However, it's still possible to load pre-baked <see cref="Texture3D" />s into its <see cref="GpuParticlesCollisionSdf3D.Texture" /> property in an exported project.</para>
/// <para><b>Note:</b> <see cref="ParticleProcessMaterial.CollisionMode" /> must be <see cref="ParticleProcessMaterial.CollisionModeEnum.Rigid" /> or <see cref="ParticleProcessMaterial.CollisionModeEnum.HideOnContact" /> on the <see cref="GpuParticles3D" />'s process material for collision to work.</para>
/// <para><b>Note:</b> Particle collision only affects <see cref="GpuParticles3D" />, not <see cref="CpuParticles3D" />.</para>
/// </summary>
public class GpuParticlesCollisionSdf3DAdapter : GpuParticlesCollision3DAdapter, IGpuParticlesCollisionSdf3D {
  private readonly GpuParticlesCollisionSdf3D _node;

  public GpuParticlesCollisionSdf3DAdapter(GpuParticlesCollisionSdf3D node) : base(node) { _node = node; }

    /// <summary>
    /// <para>The visual layers to account for when baking the particle collision SDF. Only <see cref="MeshInstance3D" />s whose <see cref="VisualInstance3D.Layers" /> match with this <see cref="GpuParticlesCollisionSdf3D.BakeMask" /> will be included in the generated particle collision SDF. By default, all objects are taken into account for the particle collision SDF baking.</para>
    /// </summary>
    public uint BakeMask { get => _node.BakeMask; set => _node.BakeMask = value; }
    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="GpuParticlesCollisionSdf3D.BakeMask" /> is enabled, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    public bool GetBakeMaskValue(int layerNumber) => _node.GetBakeMaskValue(layerNumber);
    /// <summary>
    /// <para>The bake resolution to use for the signed distance field <see cref="GpuParticlesCollisionSdf3D.Texture" />. The texture must be baked again for changes to the <see cref="GpuParticlesCollisionSdf3D.Resolution" /> property to be effective. Higher resolutions have a greater performance cost and take more time to bake. Higher resolutions also result in larger baked textures, leading to increased VRAM and storage space requirements. To improve performance and reduce bake times, use the lowest resolution possible for the object you're representing the collision of.</para>
    /// </summary>
    public GpuParticlesCollisionSdf3D.ResolutionEnum Resolution { get => _node.Resolution; set => _node.Resolution = value; }
    /// <summary>
    /// <para>Based on <paramref name="value" />, enables or disables the specified layer in the <see cref="GpuParticlesCollisionSdf3D.BakeMask" />, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    public void SetBakeMaskValue(int layerNumber, bool value) => _node.SetBakeMaskValue(layerNumber, value);
    /// <summary>
    /// <para>The collision SDF's size in 3D units. To improve SDF quality, the <see cref="GpuParticlesCollisionSdf3D.Size" /> should be set as small as possible while covering the parts of the scene you need.</para>
    /// </summary>
    public Vector3 Size { get => _node.Size; set => _node.Size = value; }
    /// <summary>
    /// <para>The 3D texture representing the signed distance field.</para>
    /// </summary>
    public Texture3D Texture { get => _node.Texture; set => _node.Texture = value; }
    /// <summary>
    /// <para>The collision shape's thickness. Unlike other particle colliders, <see cref="GpuParticlesCollisionSdf3D" /> is actually hollow on the inside. <see cref="GpuParticlesCollisionSdf3D.Thickness" /> can be increased to prevent particles from tunneling through the collision shape at high speeds, or when the <see cref="GpuParticlesCollisionSdf3D" /> is moved.</para>
    /// </summary>
    public float Thickness { get => _node.Thickness; set => _node.Thickness = value; }

}