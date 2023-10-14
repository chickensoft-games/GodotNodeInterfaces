 namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>2D particle node used to create a variety of particle systems and effects. <see cref="GpuParticles2D" /> features an emitter that generates some number of particles at a given rate.</para>
/// <para>Use the <see cref="GpuParticles2D.ProcessMaterial" /> property to add a <see cref="ParticleProcessMaterial" /> to configure particle appearance and behavior. Alternatively, you can add a <see cref="ShaderMaterial" /> which will be applied to all particles.</para>
/// <para>2D particles can optionally collide with <see cref="LightOccluder2D" />, but they don't collide with <see cref="PhysicsBody2D" /> nodes.</para>
/// </summary>
public class GpuParticles2DAdapter : GpuParticles2D, IGpuParticles2D {
  private readonly GpuParticles2D _node;

  public GpuParticles2DAdapter(GpuParticles2D node) => _node = node;
    /// <summary>
    /// <para>Number of particles emitted in one emission cycle.</para>
    /// </summary>
    public int Amount { get => _node.Amount; set => _node.Amount = value; }
    /// <summary>
    /// <para>The ratio of particles that should actually be emitted. If set to a value lower than <c>1.0</c>, this will set the amount of emitted particles throughout the lifetime to <c>amount * amount_ratio</c>. Unlike changing <see cref="GpuParticles2D.Amount" />, changing <see cref="GpuParticles2D.AmountRatio" /> while emitting does not affect already-emitted particles and doesn't cause the particle system to restart. <see cref="GpuParticles2D.AmountRatio" /> can be used to create effects that make the number of emitted particles vary over time.</para>
    /// <para><b>Note:</b> Reducing the <see cref="GpuParticles2D.AmountRatio" /> has no performance benefit, since resources need to be allocated and processed for the total <see cref="GpuParticles2D.Amount" /> of particles regardless of the <see cref="GpuParticles2D.AmountRatio" />.</para>
    /// </summary>
    public float AmountRatio { get => _node.AmountRatio; set => _node.AmountRatio = value; }
    /// <summary>
    /// <para>Returns a rectangle containing the positions of all existing particles.</para>
    /// <para><b>Note:</b> When using threaded rendering this method synchronizes the rendering thread. Calling it often may have a negative impact on performance.</para>
    /// </summary>
    public Rect2 CaptureRect() => _node.CaptureRect();
    /// <summary>
    /// <para>Multiplier for particle's collision radius. <c>1.0</c> corresponds to the size of the sprite.</para>
    /// </summary>
    public float CollisionBaseSize { get => _node.CollisionBaseSize; set => _node.CollisionBaseSize = value; }
    /// <summary>
    /// <para>Sets this node's properties to match a given <see cref="CpuParticles2D" /> node.</para>
    /// </summary>
    public void ConvertFromParticles(Node particles) => _node.ConvertFromParticles(particles);
    /// <summary>
    /// <para>Particle draw order. Uses <see cref="GpuParticles2D.DrawOrderEnum" /> values.</para>
    /// </summary>
    public GpuParticles2D.DrawOrderEnum DrawOrder { get => _node.DrawOrder; set => _node.DrawOrder = value; }
    /// <summary>
    /// <para>Emits a single particle. Whether <paramref name="xform" />, <paramref name="velocity" />, <paramref name="color" /> and <paramref name="custom" /> are applied depends on the value of <paramref name="flags" />. See <see cref="GpuParticles2D.EmitFlags" />.</para>
    /// </summary>
    public void EmitParticle(Transform2D xform, Vector2 velocity, Color color, Color custom, uint flags) => _node.EmitParticle(xform, velocity, color, custom, flags);
    /// <summary>
    /// <para>If <c>true</c>, particles are being emitted. <see cref="GpuParticles2D.Emitting" /> can be used to start and stop particles from emitting. However, if <see cref="GpuParticles2D.OneShot" /> is <c>true</c> setting <see cref="GpuParticles2D.Emitting" /> to <c>true</c> will not restart the emission cycle until after all active particles finish processing. You can use the <see cref="GpuParticles2D.Finished" /> signal to be notified once all active particles finish processing.</para>
    /// </summary>
    public bool Emitting { get => _node.Emitting; set => _node.Emitting = value; }
    /// <summary>
    /// <para>How rapidly particles in an emission cycle are emitted. If greater than <c>0</c>, there will be a gap in emissions before the next cycle begins.</para>
    /// </summary>
    public float Explosiveness { get => _node.Explosiveness; set => _node.Explosiveness = value; }
    /// <summary>
    /// <para>The particle system's frame rate is fixed to a value. For example, changing the value to 2 will make the particles render at 2 frames per second. Note this does not slow down the simulation of the particle system itself.</para>
    /// </summary>
    public int FixedFps { get => _node.FixedFps; set => _node.FixedFps = value; }
    /// <summary>
    /// <para>If <c>true</c>, results in fractional delta calculation which has a smoother particles display effect.</para>
    /// </summary>
    public bool FractDelta { get => _node.FractDelta; set => _node.FractDelta = value; }
    /// <summary>
    /// <para>Enables particle interpolation, which makes the particle movement smoother when their <see cref="GpuParticles2D.FixedFps" /> is lower than the screen refresh rate.</para>
    /// </summary>
    public bool Interpolate { get => _node.Interpolate; set => _node.Interpolate = value; }
    /// <summary>
    /// <para>Causes all the particles in this node to interpolate towards the end of their lifetime.</para>
    /// <para><b>Note</b>: This only works when used with a <see cref="ParticleProcessMaterial" />. It needs to be manually implemented for custom process shaders.</para>
    /// </summary>
    public float InterpToEnd { get => _node.InterpToEnd; set => _node.InterpToEnd = value; }
    /// <summary>
    /// <para>Amount of time each particle will exist.</para>
    /// </summary>
    public double Lifetime { get => _node.Lifetime; set => _node.Lifetime = value; }
    /// <summary>
    /// <para>If <c>true</c>, particles use the parent node's coordinate space (known as local coordinates). This will cause particles to move and rotate along the <see cref="GpuParticles2D" /> node (and its parents) when it is moved or rotated. If <c>false</c>, particles use global coordinates; they will not move or rotate along the <see cref="GpuParticles2D" /> node (and its parents) when it is moved or rotated.</para>
    /// </summary>
    public bool LocalCoords { get => _node.LocalCoords; set => _node.LocalCoords = value; }
    /// <summary>
    /// <para>If <c>true</c>, only one emission cycle occurs. If set <c>true</c> during a cycle, emission will stop at the cycle's end.</para>
    /// </summary>
    public bool OneShot { get => _node.OneShot; set => _node.OneShot = value; }
    /// <summary>
    /// <para>Particle system starts as if it had already run for this many seconds.</para>
    /// </summary>
    public double Preprocess { get => _node.Preprocess; set => _node.Preprocess = value; }
    /// <summary>
    /// <para><see cref="Material" /> for processing particles. Can be a <see cref="ParticleProcessMaterial" /> or a <see cref="ShaderMaterial" />.</para>
    /// </summary>
    public Material ProcessMaterial { get => _node.ProcessMaterial; set => _node.ProcessMaterial = value; }
    /// <summary>
    /// <para>Emission lifetime randomness ratio.</para>
    /// </summary>
    public float Randomness { get => _node.Randomness; set => _node.Randomness = value; }
    /// <summary>
    /// <para>Restarts all the existing particles.</para>
    /// </summary>
    public void Restart() => _node.Restart();
    /// <summary>
    /// <para>Particle system's running speed scaling ratio. A value of <c>0</c> can be used to pause the particles.</para>
    /// </summary>
    public double SpeedScale { get => _node.SpeedScale; set => _node.SpeedScale = value; }
    /// <summary>
    /// <para>The <see cref="NodePath" /> to the <see cref="GpuParticles2D" /> used for sub-emissions.</para>
    /// </summary>
    public NodePath SubEmitter { get => _node.SubEmitter; set => _node.SubEmitter = value; }
    /// <summary>
    /// <para>Particle texture. If <c>null</c>, particles will be squares.</para>
    /// </summary>
    public Texture2D Texture { get => _node.Texture; set => _node.Texture = value; }
    /// <summary>
    /// <para>If <c>true</c>, enables particle trails using a mesh skinning system.</para>
    /// <para><b>Note:</b> Unlike <see cref="GpuParticles3D" />, the number of trail sections and subdivisions is set with the <see cref="GpuParticles2D.TrailSections" /> and <see cref="GpuParticles2D.TrailSectionSubdivisions" /> properties.</para>
    /// </summary>
    public bool TrailEnabled { get => _node.TrailEnabled; set => _node.TrailEnabled = value; }
    /// <summary>
    /// <para>The amount of time the particle's trail should represent (in seconds). Only effective if <see cref="GpuParticles2D.TrailEnabled" /> is <c>true</c>.</para>
    /// </summary>
    public double TrailLifetime { get => _node.TrailLifetime; set => _node.TrailLifetime = value; }
    /// <summary>
    /// <para>The number of sections to use for the particle trail rendering. Higher values can result in smoother trail curves, at the cost of performance due to increased mesh complexity. See also <see cref="GpuParticles2D.TrailSectionSubdivisions" />. Only effective if <see cref="GpuParticles2D.TrailEnabled" /> is <c>true</c>.</para>
    /// </summary>
    public int TrailSections { get => _node.TrailSections; set => _node.TrailSections = value; }
    /// <summary>
    /// <para>The number of subdivisions to use for the particle trail rendering. Higher values can result in smoother trail curves, at the cost of performance due to increased mesh complexity. See also <see cref="GpuParticles2D.TrailSections" />. Only effective if <see cref="GpuParticles2D.TrailEnabled" /> is <c>true</c>.</para>
    /// </summary>
    public int TrailSectionSubdivisions { get => _node.TrailSectionSubdivisions; set => _node.TrailSectionSubdivisions = value; }
    /// <summary>
    /// <para>The <see cref="Rect2" /> that determines the node's region which needs to be visible on screen for the particle system to be active.</para>
    /// <para>Grow the rect if particles suddenly appear/disappear when the node enters/exits the screen. The <see cref="Rect2" /> can be grown via code or with the <b>Particles → Generate Visibility Rect</b> editor tool.</para>
    /// </summary>
    public Rect2 VisibilityRect { get => _node.VisibilityRect; set => _node.VisibilityRect = value; }

}