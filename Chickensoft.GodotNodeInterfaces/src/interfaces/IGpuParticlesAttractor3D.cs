namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>Particle attractors can be used to attract particles towards the attractor's origin, or to push them away from the attractor's origin.</para>
/// <para>Particle attractors work in real-time and can be moved, rotated and scaled during gameplay. Unlike collision shapes, non-uniform scaling of attractors is also supported.</para>
/// <para>Attractors can be temporarily disabled by hiding them, or by setting their <see cref="GpuParticlesAttractor3D.Strength" /> to <c>0.0</c>.</para>
/// <para><b>Note:</b> Particle attractors only affect <see cref="GpuParticles3D" />, not <see cref="CpuParticles3D" />.</para>
/// </summary>
public interface IGpuParticlesAttractor3D : IVisualInstance3D {
    /// <summary>
    /// <para>The particle attractor's attenuation. Higher values result in more gradual pushing of particles as they come closer to the attractor's origin. Zero or negative values will cause particles to be pushed very fast as soon as the touch the attractor's edges.</para>
    /// </summary>
    float Attenuation { get; set; }
    /// <summary>
    /// <para>The particle rendering layers (<see cref="VisualInstance3D.Layers" />) that will be affected by the attractor. By default, all particles are affected by an attractor.</para>
    /// <para>After configuring particle nodes accordingly, specific layers can be unchecked to prevent certain particles from being affected by attractors. For example, this can be used if you're using an attractor as part of a spell effect but don't want the attractor to affect unrelated weather particles at the same position.</para>
    /// <para>Particle attraction can also be disabled on a per-process material basis by setting <see cref="ParticleProcessMaterial.AttractorInteractionEnabled" /> on the <see cref="GpuParticles3D" /> node.</para>
    /// </summary>
    uint CullMask { get; set; }
    /// <summary>
    /// <para>Adjusts how directional the attractor is. At <c>0.0</c>, the attractor is not directional at all: it will attract particles towards its center. At <c>1.0</c>, the attractor is fully directional: particles will always be pushed towards local -Z (or +Z if <see cref="GpuParticlesAttractor3D.Strength" /> is negative).</para>
    /// <para><b>Note:</b> If <see cref="GpuParticlesAttractor3D.Directionality" /> is greater than <c>0.0</c>, the direction in which particles are pushed can be changed by rotating the <see cref="GpuParticlesAttractor3D" /> node.</para>
    /// </summary>
    float Directionality { get; set; }
    /// <summary>
    /// <para>Adjusts the strength of the attractor. If <see cref="GpuParticlesAttractor3D.Strength" /> is negative, particles will be pushed in the opposite direction. Particles will be pushed <i>away</i> from the attractor's origin if <see cref="GpuParticlesAttractor3D.Directionality" /> is <c>0.0</c>, or towards local +Z if <see cref="GpuParticlesAttractor3D.Directionality" /> is greater than <c>0.0</c>.</para>
    /// </summary>
    float Strength { get; set; }

}