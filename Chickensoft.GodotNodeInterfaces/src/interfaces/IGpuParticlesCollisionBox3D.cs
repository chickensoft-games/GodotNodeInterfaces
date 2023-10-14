namespace Chickensoft.GodotNodeInterfaces;

using Godot;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class GpuParticlesCollisionBox3DNode : GpuParticlesCollisionBox3D, IGpuParticlesCollisionBox3D { }

/// <summary>
/// <para>A box-shaped 3D particle collision shape affecting <see cref="GpuParticles3D" /> nodes.</para>
/// <para>Particle collision shapes work in real-time and can be moved, rotated and scaled during gameplay. Unlike attractors, non-uniform scaling of collision shapes is <i>not</i> supported.</para>
/// <para><b>Note:</b> <see cref="ParticleProcessMaterial.CollisionMode" /> must be <see cref="ParticleProcessMaterial.CollisionModeEnum.Rigid" /> or <see cref="ParticleProcessMaterial.CollisionModeEnum.HideOnContact" /> on the <see cref="GpuParticles3D" />'s process material for collision to work.</para>
/// <para><b>Note:</b> Particle collision only affects <see cref="GpuParticles3D" />, not <see cref="CpuParticles3D" />.</para>
/// </summary>
public interface IGpuParticlesCollisionBox3D : IGpuParticlesCollision3D {
    /// <summary>
    /// <para>The collision box's size in 3D units.</para>
    /// </summary>
    Vector3 Size { get; set; }

}