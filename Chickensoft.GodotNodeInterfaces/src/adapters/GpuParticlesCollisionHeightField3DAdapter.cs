namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A real-time heightmap-shaped 3D particle collision shape affecting <see cref="GpuParticles3D" /> nodes.</para>
/// <para>Heightmap shapes allow for efficiently representing collisions for convex and concave objects with a single "floor" (such as terrain). This is less flexible than <see cref="GpuParticlesCollisionSdf3D" />, but it doesn't require a baking step.</para>
/// <para><see cref="GpuParticlesCollisionHeightField3D" /> can also be regenerated in real-time when it is moved, when the camera moves, or even continuously. This makes <see cref="GpuParticlesCollisionHeightField3D" /> a good choice for weather effects such as rain and snow and games with highly dynamic geometry. However, this class is limited since heightmaps cannot represent overhangs (e.g. indoors or caves).</para>
/// <para><b>Note:</b> <see cref="ParticleProcessMaterial.CollisionMode" /> must be <c>true</c> on the <see cref="GpuParticles3D" />'s process material for collision to work.</para>
/// <para><b>Note:</b> Particle collision only affects <see cref="GpuParticles3D" />, not <see cref="CpuParticles3D" />.</para>
/// </summary>
public class GpuParticlesCollisionHeightField3DAdapter : GpuParticlesCollisionHeightField3D, IGpuParticlesCollisionHeightField3D {
  private readonly GpuParticlesCollisionHeightField3D _node;

  public GpuParticlesCollisionHeightField3DAdapter(GpuParticlesCollisionHeightField3D node) => _node = node;
    /// <summary>
    /// <para>If <c>true</c>, the <see cref="GpuParticlesCollisionHeightField3D" /> will follow the current camera in global space. The <see cref="GpuParticlesCollisionHeightField3D" /> does not need to be a child of the <see cref="Camera3D" /> node for this to work.</para>
    /// <para>Following the camera has a performance cost, as it will force the heightmap to update whenever the camera moves. Consider lowering <see cref="GpuParticlesCollisionHeightField3D.Resolution" /> to improve performance if <see cref="GpuParticlesCollisionHeightField3D.FollowCameraEnabled" /> is <c>true</c>.</para>
    /// </summary>
    public bool FollowCameraEnabled { get => _node.FollowCameraEnabled; set => _node.FollowCameraEnabled = value; }
    /// <summary>
    /// <para>Higher resolutions can represent small details more accurately in large scenes, at the cost of lower performance. If <see cref="GpuParticlesCollisionHeightField3D.UpdateMode" /> is <see cref="GpuParticlesCollisionHeightField3D.UpdateModeEnum.Always" />, consider using the lowest resolution possible.</para>
    /// </summary>
    public GpuParticlesCollisionHeightField3D.ResolutionEnum Resolution { get => _node.Resolution; set => _node.Resolution = value; }
    /// <summary>
    /// <para>The collision heightmap's size in 3D units. To improve heightmap quality, <see cref="GpuParticlesCollisionHeightField3D.Size" /> should be set as small as possible while covering the parts of the scene you need.</para>
    /// </summary>
    public Vector3 Size { get => _node.Size; set => _node.Size = value; }
    /// <summary>
    /// <para>The update policy to use for the generated heightmap.</para>
    /// </summary>
    public GpuParticlesCollisionHeightField3D.UpdateModeEnum UpdateMode { get => _node.UpdateMode; set => _node.UpdateMode = value; }

}