namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para>A box-shaped attractor that influences particles from <see cref="GpuParticles3D" /> nodes. Can be used to attract particles towards its origin, or to push them away from its origin.</para>
/// <para>Particle attractors work in real-time and can be moved, rotated and scaled during gameplay. Unlike collision shapes, non-uniform scaling of attractors is also supported.</para>
/// <para><b>Note:</b> Particle attractors only affect <see cref="GpuParticles3D" />, not <see cref="CpuParticles3D" />.</para>
/// </summary>
public class GpuParticlesAttractorBox3DAdapter : GpuParticlesAttractor3DAdapter, IGpuParticlesAttractorBox3D {
  private readonly GpuParticlesAttractorBox3D _node;

  public GpuParticlesAttractorBox3DAdapter(Node node) : base(node) {
    if (node is not GpuParticlesAttractorBox3D typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a GpuParticlesAttractorBox3D"
      );
    }
    _node = typedNode;
  }

    /// <summary>
    /// <para>The attractor box's size in 3D units.</para>
    /// </summary>
    public Vector3 Size { get => _node.Size; set => _node.Size = value; }

}