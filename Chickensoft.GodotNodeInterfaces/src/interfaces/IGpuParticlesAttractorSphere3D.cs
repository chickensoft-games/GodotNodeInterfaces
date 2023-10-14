namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class GpuParticlesAttractorSphere3DNode : GpuParticlesAttractorSphere3D, IGpuParticlesAttractorSphere3D { }

/// <summary>
/// <para>A spheroid-shaped attractor that influences particles from <see cref="GpuParticles3D" /> nodes. Can be used to attract particles towards its origin, or to push them away from its origin.</para>
/// <para>Particle attractors work in real-time and can be moved, rotated and scaled during gameplay. Unlike collision shapes, non-uniform scaling of attractors is also supported.</para>
/// <para><b>Note:</b> Particle attractors only affect <see cref="GpuParticles3D" />, not <see cref="CpuParticles3D" />.</para>
/// </summary>
public interface IGpuParticlesAttractorSphere3D : IGpuParticlesAttractor3D {
    /// <summary>
    /// <para>The attractor sphere's radius in 3D units.</para>
    /// <para><b>Note:</b> Stretched ellipses can be obtained by using non-uniform scaling on the <see cref="GpuParticlesAttractorSphere3D" /> node.</para>
    /// </summary>
    float Radius { get; set; }

}