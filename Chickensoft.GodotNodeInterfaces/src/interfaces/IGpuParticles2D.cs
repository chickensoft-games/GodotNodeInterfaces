namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class GpuParticles2DNode : GpuParticles2D, IGpuParticles2D { }

/// <summary>
/// <para>2D particle node used to create a variety of particle systems and effects. <see cref="GpuParticles2D" /> features an emitter that generates some number of particles at a given rate.</para>
/// <para>Use the <see cref="GpuParticles2D.ProcessMaterial" /> property to add a <see cref="ParticleProcessMaterial" /> to configure particle appearance and behavior. Alternatively, you can add a <see cref="ShaderMaterial" /> which will be applied to all particles.</para>
/// <para>2D particles can optionally collide with <see cref="LightOccluder2D" />, but they don't collide with <see cref="PhysicsBody2D" /> nodes.</para>
/// </summary>
public interface IGpuParticles2D : INode2D {
    /// <summary>
    /// <para>Number of particles emitted in one emission cycle.</para>
    /// </summary>
    int Amount { get; set; }
    /// <summary>
    /// <para>The ratio of particles that should actually be emitted. If set to a value lower than <c>1.0</c>, this will set the amount of emitted particles throughout the lifetime to <c>amount * amount_ratio</c>. Unlike changing <see cref="GpuParticles2D.Amount" />, changing <see cref="GpuParticles2D.AmountRatio" /> while emitting does not affect already-emitted particles and doesn't cause the particle system to restart. <see cref="GpuParticles2D.AmountRatio" /> can be used to create effects that make the number of emitted particles vary over time.</para>
    /// <para><b>Note:</b> Reducing the <see cref="GpuParticles2D.AmountRatio" /> has no performance benefit, since resources need to be allocated and processed for the total <see cref="GpuParticles2D.Amount" /> of particles regardless of the <see cref="GpuParticles2D.AmountRatio" />.</para>
    /// </summary>
    float AmountRatio { get; set; }
    /// <summary>
    /// <para>Returns a rectangle containing the positions of all existing particles.</para>
    /// <para><b>Note:</b> When using threaded rendering this method synchronizes the rendering thread. Calling it often may have a negative impact on performance.</para>
    /// </summary>
    Rect2 CaptureRect();
    /// <summary>
    /// <para>Multiplier for particle's collision radius. <c>1.0</c> corresponds to the size of the sprite.</para>
    /// </summary>
    float CollisionBaseSize { get; set; }
    /// <summary>
    /// <para>Sets this node's properties to match a given <see cref="CpuParticles2D" /> node.</para>
    /// </summary>
    void ConvertFromParticles(Node particles);
    /// <summary>
    /// <para>Particle draw order. Uses <see cref="GpuParticles2D.DrawOrderEnum" /> values.</para>
    /// </summary>
    GpuParticles2D.DrawOrderEnum DrawOrder { get; set; }
    /// <summary>
    /// <para>Emits a single particle. Whether <paramref name="xform" />, <paramref name="velocity" />, <paramref name="color" /> and <paramref name="custom" /> are applied depends on the value of <paramref name="flags" />. See <see cref="GpuParticles2D.EmitFlags" />.</para>
    /// </summary>
    void EmitParticle(Transform2D xform, Vector2 velocity, Color color, Color custom, uint flags);
    /// <summary>
    /// <para>If <c>true</c>, particles are being emitted. <see cref="GpuParticles2D.Emitting" /> can be used to start and stop particles from emitting. However, if <see cref="GpuParticles2D.OneShot" /> is <c>true</c> setting <see cref="GpuParticles2D.Emitting" /> to <c>true</c> will not restart the emission cycle until after all active particles finish processing. You can use the <see cref="GpuParticles2D.Finished" /> signal to be notified once all active particles finish processing.</para>
    /// </summary>
    bool Emitting { get; set; }
    /// <summary>
    /// <para>How rapidly particles in an emission cycle are emitted. If greater than <c>0</c>, there will be a gap in emissions before the next cycle begins.</para>
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
    /// <para>Enables particle interpolation, which makes the particle movement smoother when their <see cref="GpuParticles2D.FixedFps" /> is lower than the screen refresh rate.</para>
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
    /// <para>If <c>true</c>, particles use the parent node's coordinate space (known as local coordinates). This will cause particles to move and rotate along the <see cref="GpuParticles2D" /> node (and its parents) when it is moved or rotated. If <c>false</c>, particles use global coordinates; they will not move or rotate along the <see cref="GpuParticles2D" /> node (and its parents) when it is moved or rotated.</para>
    /// </summary>
    bool LocalCoords { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, only one emission cycle occurs. If set <c>true</c> during a cycle, emission will stop at the cycle's end.</para>
    /// </summary>
    bool OneShot { get; set; }
    /// <summary>
    /// <para>Particle system starts as if it had already run for this many seconds.</para>
    /// </summary>
    double Preprocess { get; set; }
    /// <summary>
    /// <para><see cref="Material" /> for processing particles. Can be a <see cref="ParticleProcessMaterial" /> or a <see cref="ShaderMaterial" />.</para>
    /// </summary>
    Material ProcessMaterial { get; set; }
    /// <summary>
    /// <para>Emission lifetime randomness ratio.</para>
    /// </summary>
    float Randomness { get; set; }
    /// <summary>
    /// <para>Restarts all the existing particles.</para>
    /// </summary>
    void Restart();
    /// <summary>
    /// <para>Particle system's running speed scaling ratio. A value of <c>0</c> can be used to pause the particles.</para>
    /// </summary>
    double SpeedScale { get; set; }
    /// <summary>
    /// <para>The <see cref="NodePath" /> to the <see cref="GpuParticles2D" /> used for sub-emissions.</para>
    /// </summary>
    NodePath SubEmitter { get; set; }
    /// <summary>
    /// <para>Particle texture. If <c>null</c>, particles will be squares.</para>
    /// </summary>
    Texture2D Texture { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, enables particle trails using a mesh skinning system.</para>
    /// <para><b>Note:</b> Unlike <see cref="GpuParticles3D" />, the number of trail sections and subdivisions is set with the <see cref="GpuParticles2D.TrailSections" /> and <see cref="GpuParticles2D.TrailSectionSubdivisions" /> properties.</para>
    /// </summary>
    bool TrailEnabled { get; set; }
    /// <summary>
    /// <para>The amount of time the particle's trail should represent (in seconds). Only effective if <see cref="GpuParticles2D.TrailEnabled" /> is <c>true</c>.</para>
    /// </summary>
    double TrailLifetime { get; set; }
    /// <summary>
    /// <para>The number of sections to use for the particle trail rendering. Higher values can result in smoother trail curves, at the cost of performance due to increased mesh complexity. See also <see cref="GpuParticles2D.TrailSectionSubdivisions" />. Only effective if <see cref="GpuParticles2D.TrailEnabled" /> is <c>true</c>.</para>
    /// </summary>
    int TrailSections { get; set; }
    /// <summary>
    /// <para>The number of subdivisions to use for the particle trail rendering. Higher values can result in smoother trail curves, at the cost of performance due to increased mesh complexity. See also <see cref="GpuParticles2D.TrailSections" />. Only effective if <see cref="GpuParticles2D.TrailEnabled" /> is <c>true</c>.</para>
    /// </summary>
    int TrailSectionSubdivisions { get; set; }
    /// <summary>
    /// <para>The <see cref="Rect2" /> that determines the node's region which needs to be visible on screen for the particle system to be active.</para>
    /// <para>Grow the rect if particles suddenly appear/disappear when the node enters/exits the screen. The <see cref="Rect2" /> can be grown via code or with the <b>Particles → Generate Visibility Rect</b> editor tool.</para>
    /// </summary>
    Rect2 VisibilityRect { get; set; }

}