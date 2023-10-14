namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A spheroid-shaped attractor that influences particles from <see cref="GpuParticles3D" /> nodes. Can be used to attract particles towards its origin, or to push them away from its origin.</para>
/// <para>Particle attractors work in real-time and can be moved, rotated and scaled during gameplay. Unlike collision shapes, non-uniform scaling of attractors is also supported.</para>
/// <para><b>Note:</b> Particle attractors only affect <see cref="GpuParticles3D" />, not <see cref="CpuParticles3D" />.</para>
/// </summary>
public class GpuParticlesAttractorSphere3DAdapter : GpuParticlesAttractor3DAdapter, IGpuParticlesAttractorSphere3D {
  private readonly GpuParticlesAttractorSphere3D _node;

  public GpuParticlesAttractorSphere3DAdapter(GpuParticlesAttractorSphere3D node) : base(node) { _node = node; }

    /// <summary>
    /// <para>The attractor sphere's radius in 3D units.</para>
    /// <para><b>Note:</b> Stretched ellipses can be obtained by using non-uniform scaling on the <see cref="GpuParticlesAttractorSphere3D" /> node.</para>
    /// </summary>
    public float Radius { get => _node.Radius; set => _node.Radius = value; }

}