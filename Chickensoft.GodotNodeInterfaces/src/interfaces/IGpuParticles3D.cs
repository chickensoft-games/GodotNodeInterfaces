namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class GpuParticles3DNode : GpuParticles3D, IGpuParticles3D { }

/// <summary>
/// <para>3D particle node used to create a variety of particle systems and effects. <see cref="GpuParticles3D" /> features an emitter that generates some number of particles at a given rate.</para>
/// <para>Use <see cref="GpuParticles3D.ProcessMaterial" /> to add a <see cref="ParticleProcessMaterial" /> to configure particle appearance and behavior. Alternatively, you can add a <see cref="ShaderMaterial" /> which will be applied to all particles.</para>
/// </summary>
public interface IGpuParticles3D : IGeometryInstance3D {
    /// <summary>
    /// <para>Number of particles to emit.</para>
    /// </summary>
    int Amount { get; set; }
    /// <summary>
    /// <para>The ratio of particles that should actually be emitted. If set to a value lower than <c>1.0</c>, this will set the amount of emitted particles throughout the lifetime to <c>amount * amount_ratio</c>. Unlike changing <see cref="GpuParticles3D.Amount" />, changing <see cref="GpuParticles3D.AmountRatio" /> while emitting does not affect already-emitted particles and doesn't cause the particle system to restart. <see cref="GpuParticles3D.AmountRatio" /> can be used to create effects that make the number of emitted particles vary over time.</para>
    /// <para><b>Note:</b> Reducing the <see cref="GpuParticles3D.AmountRatio" /> has no performance benefit, since resources need to be allocated and processed for the total <see cref="GpuParticles3D.Amount" /> of particles regardless of the <see cref="GpuParticles3D.AmountRatio" />.</para>
    /// </summary>
    float AmountRatio { get; set; }
    /// <summary>
    /// <para>Returns the axis-aligned bounding box that contains all the particles that are active in the current frame.</para>
    /// </summary>
    Aabb CaptureAabb();

    float CollisionBaseSize { get; set; }
    /// <summary>
    /// <para>Sets this node's properties to match a given <see cref="CpuParticles3D" /> node.</para>
    /// </summary>
    void ConvertFromParticles(Node particles);
    /// <summary>
    /// <para>Particle draw order. Uses <see cref="GpuParticles3D.DrawOrderEnum" /> values.</para>
    /// <para><b>Note:</b> <see cref="GpuParticles3D.DrawOrderEnum.Index" /> is the only option that supports motion vectors for effects like TAA. It is suggested to use this draw order if the particles are opaque to fix ghosting artifacts.</para>
    /// </summary>
    GpuParticles3D.DrawOrderEnum DrawOrder { get; set; }
    /// <summary>
    /// <para><see cref="Mesh" /> that is drawn for the first draw pass.</para>
    /// </summary>
    Mesh DrawPass1 { get; set; }
    /// <summary>
    /// <para><see cref="Mesh" /> that is drawn for the second draw pass.</para>
    /// </summary>
    Mesh DrawPass2 { get; set; }
    /// <summary>
    /// <para><see cref="Mesh" /> that is drawn for the third draw pass.</para>
    /// </summary>
    Mesh DrawPass3 { get; set; }
    /// <summary>
    /// <para><see cref="Mesh" /> that is drawn for the fourth draw pass.</para>
    /// </summary>
    Mesh DrawPass4 { get; set; }
    /// <summary>
    /// <para>The number of draw passes when rendering particles.</para>
    /// </summary>
    int DrawPasses { get; set; }

    Skin DrawSkin { get; set; }
    /// <summary>
    /// <para>Emits a single particle. Whether <paramref name="xform" />, <paramref name="velocity" />, <paramref name="color" /> and <paramref name="custom" /> are applied depends on the value of <paramref name="flags" />. See <see cref="GpuParticles3D.EmitFlags" />.</para>
    /// </summary>
    void EmitParticle(Transform3D xform, Vector3 velocity, Color color, Color custom, uint flags);
    /// <summary>
    /// <para>If <c>true</c>, particles are being emitted. <see cref="GpuParticles3D.Emitting" /> can be used to start and stop particles from emitting. However, if <see cref="GpuParticles3D.OneShot" /> is <c>true</c> setting <see cref="GpuParticles3D.Emitting" /> to <c>true</c> will not restart the emission cycle until after all active particles finish processing. You can use the <see cref="GpuParticles3D.Finished" /> signal to be notified once all active particles finish processing.</para>
    /// </summary>
    bool Emitting { get; set; }
    /// <summary>
    /// <para>Time ratio between each emission. If <c>0</c>, particles are emitted continuously. If <c>1</c>, all particles are emitted simultaneously.</para>
    /// </summary>
    float Explosiveness { get; set; }
    /// <summary>
    /// <para>The particle system's frame rate is fixed to a value. For example, changing the value to 2 will make the particles render at 2 frames per second. Note this does not slow down the simulation of the particle system itself.</para>
    /// </summary>
    int FixedFps { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, results in fractional delta calculation which has a smoother particles display effect.</para>
    /// </summary>
    bool FractDelta { get; set; }
    /// <summary>
    /// <para>Enables particle interpolation, which makes the particle movement smoother when their <see cref="GpuParticles3D.FixedFps" /> is lower than the screen refresh rate.</para>
    /// </summary>
    bool Interpolate { get; set; }
    /// <summary>
    /// <para>Causes all the particles in this node to interpolate towards the end of their lifetime.</para>
    /// <para><b>Note</b>: This only works when used with a <see cref="ParticleProcessMaterial" />. It needs to be manually implemented for custom process shaders.</para>
    /// </summary>
    float InterpToEnd { get; set; }
    /// <summary>
    /// <para>Amount of time each particle will exist.</para>
    /// </summary>
    double Lifetime { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, particles use the parent node's coordinate space (known as local coordinates). This will cause particles to move and rotate along the <see cref="GpuParticles3D" /> node (and its parents) when it is moved or rotated. If <c>false</c>, particles use global coordinates; they will not move or rotate along the <see cref="GpuParticles3D" /> node (and its parents) when it is moved or rotated.</para>
    /// </summary>
    bool LocalCoords { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, only the number of particles equal to <see cref="GpuParticles3D.Amount" /> will be emitted.</para>
    /// </summary>
    bool OneShot { get; set; }
    /// <summary>
    /// <para>Amount of time to preprocess the particles before animation starts. Lets you start the animation some time after particles have started emitting.</para>
    /// </summary>
    double Preprocess { get; set; }
    /// <summary>
    /// <para><see cref="Material" /> for processing particles. Can be a <see cref="ParticleProcessMaterial" /> or a <see cref="ShaderMaterial" />.</para>
    /// </summary>
    Material ProcessMaterial { get; set; }
    /// <summary>
    /// <para>Emission randomness ratio.</para>
    /// </summary>
    float Randomness { get; set; }
    /// <summary>
    /// <para>Restarts the particle emission, clearing existing particles.</para>
    /// </summary>
    void Restart();
    /// <summary>
    /// <para>Speed scaling ratio. A value of <c>0</c> can be used to pause the particles.</para>
    /// </summary>
    double SpeedScale { get; set; }

    NodePath SubEmitter { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, enables particle trails using a mesh skinning system. Designed to work with <see cref="RibbonTrailMesh" /> and <see cref="TubeTrailMesh" />.</para>
    /// <para><b>Note:</b> <see cref="BaseMaterial3D.UseParticleTrails" /> must also be enabled on the particle mesh's material. Otherwise, setting <see cref="GpuParticles3D.TrailEnabled" /> to <c>true</c> will have no effect.</para>
    /// <para><b>Note:</b> Unlike <see cref="GpuParticles2D" />, the number of trail sections and subdivisions is set in the <see cref="RibbonTrailMesh" /> or the <see cref="TubeTrailMesh" />'s properties.</para>
    /// </summary>
    bool TrailEnabled { get; set; }
    /// <summary>
    /// <para>The amount of time the particle's trail should represent (in seconds). Only effective if <see cref="GpuParticles3D.TrailEnabled" /> is <c>true</c>.</para>
    /// </summary>
    double TrailLifetime { get; set; }

    GpuParticles3D.TransformAlignEnum TransformAlign { get; set; }
    /// <summary>
    /// <para>The <see cref="Aabb" /> that determines the node's region which needs to be visible on screen for the particle system to be active.</para>
    /// <para>Grow the box if particles suddenly appear/disappear when the node enters/exits the screen. The <see cref="Aabb" /> can be grown via code or with the <b>Particles → Generate AABB</b> editor tool.</para>
    /// </summary>
    Aabb VisibilityAabb { get; set; }

}