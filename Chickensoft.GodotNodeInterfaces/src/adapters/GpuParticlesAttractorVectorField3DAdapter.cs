 namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para>A box-shaped attractor with varying directions and strengths defined in it that influences particles from <see cref="GpuParticles3D" /> nodes.</para>
/// <para>Unlike <see cref="GpuParticlesAttractorBox3D" />, <see cref="GpuParticlesAttractorVectorField3D" /> uses a <see cref="GpuParticlesAttractorVectorField3D.Texture" /> to affect attraction strength within the box. This can be used to create complex attraction scenarios where particles travel in different directions depending on their location. This can be useful for weather effects such as sandstorms.</para>
/// <para>Particle attractors work in real-time and can be moved, rotated and scaled during gameplay. Unlike collision shapes, non-uniform scaling of attractors is also supported.</para>
/// <para><b>Note:</b> Particle attractors only affect <see cref="GpuParticles3D" />, not <see cref="CpuParticles3D" />.</para>
/// </summary>
public class GpuParticlesAttractorVectorField3DAdapter : GpuParticlesAttractorVectorField3D, IGpuParticlesAttractorVectorField3D {
  private readonly GpuParticlesAttractorVectorField3D _node;

  public GpuParticlesAttractorVectorField3DAdapter(GpuParticlesAttractorVectorField3D node) => _node = node;
    /// <summary>
    /// <para>The size of the vector field box in 3D units.</para>
    /// </summary>
    public Vector3 Size { get => _node.Size; set => _node.Size = value; }
    /// <summary>
    /// <para>The 3D texture to be used. Values are linearly interpolated between the texture's pixels.</para>
    /// <para><b>Note:</b> To get better performance, the 3D texture's resolution should reflect the <see cref="GpuParticlesAttractorVectorField3D.Size" /> of the attractor. Since particle attraction is usually low-frequency data, the texture can be kept at a low resolution such as 64×64×64.</para>
    /// </summary>
    public Texture3D Texture { get => _node.Texture; set => _node.Texture = value; }

}