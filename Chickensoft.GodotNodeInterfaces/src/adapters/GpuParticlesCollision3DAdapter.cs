namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>Particle collision shapes can be used to make particles stop or bounce against them.</para>
/// <para>Particle collision shapes work in real-time and can be moved, rotated and scaled during gameplay. Unlike attractors, non-uniform scaling of collision shapes is <i>not</i> supported.</para>
/// <para>Particle collision shapes can be temporarily disabled by hiding them.</para>
/// <para><b>Note:</b> <see cref="ParticleProcessMaterial.CollisionMode" /> must be <see cref="ParticleProcessMaterial.CollisionModeEnum.Rigid" /> or <see cref="ParticleProcessMaterial.CollisionModeEnum.HideOnContact" /> on the <see cref="GpuParticles3D" />'s process material for collision to work.</para>
/// <para><b>Note:</b> Particle collision only affects <see cref="GpuParticles3D" />, not <see cref="CpuParticles3D" />.</para>
/// <para><b>Note:</b> Particles pushed by a collider that is being moved will not be interpolated, which can result in visible stuttering. This can be alleviated by setting <see cref="GpuParticles3D.FixedFps" /> to <c>0</c> or a value that matches or exceeds the target framerate.</para>
/// </summary>
public class GpuParticlesCollision3DAdapter : VisualInstance3DAdapter, IGpuParticlesCollision3D {
  private readonly GpuParticlesCollision3D _node;

  public GpuParticlesCollision3DAdapter(Node node) : base(node) {
    if (node is not GpuParticlesCollision3D typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a GpuParticlesCollision3D"
      );
    }
    _node = typedNode;
  }

    /// <summary>
    /// <para>The particle rendering layers (<see cref="VisualInstance3D.Layers" />) that will be affected by the collision shape. By default, all particles that have <see cref="ParticleProcessMaterial.CollisionMode" /> set to <see cref="ParticleProcessMaterial.CollisionModeEnum.Rigid" /> or <see cref="ParticleProcessMaterial.CollisionModeEnum.HideOnContact" /> will be affected by a collision shape.</para>
    /// <para>After configuring particle nodes accordingly, specific layers can be unchecked to prevent certain particles from being affected by attractors. For example, this can be used if you're using an attractor as part of a spell effect but don't want the attractor to affect unrelated weather particles at the same position.</para>
    /// <para>Particle attraction can also be disabled on a per-process material basis by setting <see cref="ParticleProcessMaterial.AttractorInteractionEnabled" /> on the <see cref="GpuParticles3D" /> node.</para>
    /// </summary>
    public uint CullMask { get => _node.CullMask; set => _node.CullMask = value; }

}