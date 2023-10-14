namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class CpuParticles2DNode : CpuParticles2D, ICpuParticles2D { }

/// <summary>
/// <para>CPU-based 2D particle node used to create a variety of particle systems and effects.</para>
/// <para>See also <see cref="GpuParticles2D" />, which provides the same functionality with hardware acceleration, but may not run on older devices.</para>
/// </summary>
public interface ICpuParticles2D : INode2D {
    /// <summary>
    /// <para>Number of particles emitted in one emission cycle.</para>
    /// </summary>
    int Amount { get; set; }
    /// <summary>
    /// <para>Each particle's rotation will be animated along this <see cref="Curve" />.</para>
    /// </summary>
    Curve AngleCurve { get; set; }
    /// <summary>
    /// <para>Maximum initial rotation applied to each particle, in degrees.</para>
    /// </summary>
    float AngleMax { get; set; }
    /// <summary>
    /// <para>Minimum equivalent of <see cref="CpuParticles2D.AngleMax" />.</para>
    /// </summary>
    float AngleMin { get; set; }
    /// <summary>
    /// <para>Each particle's angular velocity will vary along this <see cref="Curve" />.</para>
    /// </summary>
    Curve AngularVelocityCurve { get; set; }
    /// <summary>
    /// <para>Maximum initial angular velocity (rotation speed) applied to each particle in <i>degrees</i> per second.</para>
    /// </summary>
    float AngularVelocityMax { get; set; }
    /// <summary>
    /// <para>Minimum equivalent of <see cref="CpuParticles2D.AngularVelocityMax" />.</para>
    /// </summary>
    float AngularVelocityMin { get; set; }
    /// <summary>
    /// <para>Each particle's animation offset will vary along this <see cref="Curve" />.</para>
    /// </summary>
    Curve AnimOffsetCurve { get; set; }
    /// <summary>
    /// <para>Maximum animation offset that corresponds to frame index in the texture. <c>0</c> is the first frame, <c>1</c> is the last one. See <see cref="CanvasItemMaterial.ParticlesAnimation" />.</para>
    /// </summary>
    float AnimOffsetMax { get; set; }
    /// <summary>
    /// <para>Minimum equivalent of <see cref="CpuParticles2D.AnimOffsetMax" />.</para>
    /// </summary>
    float AnimOffsetMin { get; set; }
    /// <summary>
    /// <para>Each particle's animation speed will vary along this <see cref="Curve" />.</para>
    /// </summary>
    Curve AnimSpeedCurve { get; set; }
    /// <summary>
    /// <para>Maximum particle animation speed. Animation speed of <c>1</c> means that the particles will make full <c>0</c> to <c>1</c> offset cycle during lifetime, <c>2</c> means <c>2</c> cycles etc.</para>
    /// <para>With animation speed greater than <c>1</c>, remember to enable <see cref="CanvasItemMaterial.ParticlesAnimLoop" /> property if you want the animation to repeat.</para>
    /// </summary>
    float AnimSpeedMax { get; set; }
    /// <summary>
    /// <para>Minimum equivalent of <see cref="CpuParticles2D.AnimSpeedMax" />.</para>
    /// </summary>
    float AnimSpeedMin { get; set; }
    /// <summary>
    /// <para>Each particle's initial color. If <see cref="CpuParticles2D.Texture" /> is defined, it will be multiplied by this color.</para>
    /// </summary>
    Color Color { get; set; }
    /// <summary>
    /// <para>Each particle's initial color will vary along this <see cref="GradientTexture1D" /> (multiplied with <see cref="CpuParticles2D.Color" />).</para>
    /// </summary>
    Gradient ColorInitialRamp { get; set; }
    /// <summary>
    /// <para>Each particle's color will vary along this <see cref="Gradient" /> (multiplied with <see cref="CpuParticles2D.Color" />).</para>
    /// </summary>
    Gradient ColorRamp { get; set; }
    /// <summary>
    /// <para>Sets this node's properties to match a given <see cref="GpuParticles2D" /> node with an assigned <see cref="ParticleProcessMaterial" />.</para>
    /// </summary>
    void ConvertFromParticles(Node particles);
    /// <summary>
    /// <para>Damping will vary along this <see cref="Curve" />.</para>
    /// </summary>
    Curve DampingCurve { get; set; }
    /// <summary>
    /// <para>The maximum rate at which particles lose velocity. For example value of <c>100</c> means that the particle will go from <c>100</c> velocity to <c>0</c> in <c>1</c> second.</para>
    /// </summary>
    float DampingMax { get; set; }
    /// <summary>
    /// <para>Minimum equivalent of <see cref="CpuParticles2D.DampingMax" />.</para>
    /// </summary>
    float DampingMin { get; set; }
    /// <summary>
    /// <para>Unit vector specifying the particles' emission direction.</para>
    /// </summary>
    Vector2 Direction { get; set; }
    /// <summary>
    /// <para>Particle draw order. Uses <see cref="CpuParticles2D.DrawOrderEnum" /> values.</para>
    /// </summary>
    CpuParticles2D.DrawOrderEnum DrawOrder { get; set; }
    /// <summary>
    /// <para>Sets the <see cref="Color" />s to modulate particles by when using <see cref="CpuParticles2D.EmissionShapeEnum.Points" /> or <see cref="CpuParticles2D.EmissionShapeEnum.DirectedPoints" />.</para>
    /// </summary>
    Color[] EmissionColors { get; set; }
    /// <summary>
    /// <para>Sets the direction the particles will be emitted in when using <see cref="CpuParticles2D.EmissionShapeEnum.DirectedPoints" />.</para>
    /// </summary>
    Vector2[] EmissionNormals { get; set; }
    /// <summary>
    /// <para>Sets the initial positions to spawn particles when using <see cref="CpuParticles2D.EmissionShapeEnum.Points" /> or <see cref="CpuParticles2D.EmissionShapeEnum.DirectedPoints" />.</para>
    /// </summary>
    Vector2[] EmissionPoints { get; set; }
    /// <summary>
    /// <para>The rectangle's extents if <see cref="CpuParticles2D.EmissionShape" /> is set to <see cref="CpuParticles2D.EmissionShapeEnum.Rectangle" />.</para>
    /// </summary>
    Vector2 EmissionRectExtents { get; set; }
    /// <summary>
    /// <para>Particles will be emitted inside this region. See <see cref="CpuParticles2D.EmissionShapeEnum" /> for possible values.</para>
    /// </summary>
    CpuParticles2D.EmissionShapeEnum EmissionShape { get; set; }
    /// <summary>
    /// <para>The sphere's radius if <see cref="CpuParticles2D.EmissionShape" /> is set to <see cref="CpuParticles2D.EmissionShapeEnum.Sphere" />.</para>
    /// </summary>
    float EmissionSphereRadius { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, particles are being emitted. <see cref="CpuParticles2D.Emitting" /> can be used to start and stop particles from emitting. However, if <see cref="CpuParticles2D.OneShot" /> is <c>true</c> setting <see cref="CpuParticles2D.Emitting" /> to <c>true</c> will not restart the emission cycle until after all active particles finish processing. You can use the <see cref="CpuParticles2D.Finished" /> signal to be notified once all active particles finish processing.</para>
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
    /// <para>Gravity applied to every particle.</para>
    /// </summary>
    Vector2 Gravity { get; set; }
    /// <summary>
    /// <para>Each particle's hue will vary along this <see cref="Curve" />.</para>
    /// </summary>
    Curve HueVariationCurve { get; set; }
    /// <summary>
    /// <para>Maximum initial hue variation applied to each particle. It will shift the particle color's hue.</para>
    /// </summary>
    float HueVariationMax { get; set; }
    /// <summary>
    /// <para>Minimum equivalent of <see cref="CpuParticles2D.HueVariationMax" />.</para>
    /// </summary>
    float HueVariationMin { get; set; }
    /// <summary>
    /// <para>Maximum initial velocity magnitude for each particle. Direction comes from <see cref="CpuParticles2D.Direction" /> and <see cref="CpuParticles2D.Spread" />.</para>
    /// </summary>
    float InitialVelocityMax { get; set; }
    /// <summary>
    /// <para>Minimum equivalent of <see cref="CpuParticles2D.InitialVelocityMax" />.</para>
    /// </summary>
    float InitialVelocityMin { get; set; }
    /// <summary>
    /// <para>Amount of time each particle will exist.</para>
    /// </summary>
    double Lifetime { get; set; }
    /// <summary>
    /// <para>Particle lifetime randomness ratio.</para>
    /// </summary>
    double LifetimeRandomness { get; set; }
    /// <summary>
    /// <para>Each particle's linear acceleration will vary along this <see cref="Curve" />.</para>
    /// </summary>
    Curve LinearAccelCurve { get; set; }
    /// <summary>
    /// <para>Maximum linear acceleration applied to each particle in the direction of motion.</para>
    /// </summary>
    float LinearAccelMax { get; set; }
    /// <summary>
    /// <para>Minimum equivalent of <see cref="CpuParticles2D.LinearAccelMax" />.</para>
    /// </summary>
    float LinearAccelMin { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, particles use the parent node's coordinate space (known as local coordinates). This will cause particles to move and rotate along the <see cref="CpuParticles2D" /> node (and its parents) when it is moved or rotated. If <c>false</c>, particles use global coordinates; they will not move or rotate along the <see cref="CpuParticles2D" /> node (and its parents) when it is moved or rotated.</para>
    /// </summary>
    bool LocalCoords { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, only one emission cycle occurs. If set <c>true</c> during a cycle, emission will stop at the cycle's end.</para>
    /// </summary>
    bool OneShot { get; set; }
    /// <summary>
    /// <para>Each particle's orbital velocity will vary along this <see cref="Curve" />.</para>
    /// </summary>
    Curve OrbitVelocityCurve { get; set; }
    /// <summary>
    /// <para>Maximum orbital velocity applied to each particle. Makes the particles circle around origin. Specified in number of full rotations around origin per second.</para>
    /// </summary>
    float OrbitVelocityMax { get; set; }
    /// <summary>
    /// <para>Minimum equivalent of <see cref="CpuParticles2D.OrbitVelocityMax" />.</para>
    /// </summary>
    float OrbitVelocityMin { get; set; }
    /// <summary>
    /// <para>Align Y axis of particle with the direction of its velocity.</para>
    /// </summary>
    bool ParticleFlagAlignY { get; set; }
    /// <summary>
    /// <para>Particle system starts as if it had already run for this many seconds.</para>
    /// </summary>
    double Preprocess { get; set; }
    /// <summary>
    /// <para>Each particle's radial acceleration will vary along this <see cref="Curve" />.</para>
    /// </summary>
    Curve RadialAccelCurve { get; set; }
    /// <summary>
    /// <para>Maximum radial acceleration applied to each particle. Makes particle accelerate away from the origin or towards it if negative.</para>
    /// </summary>
    float RadialAccelMax { get; set; }
    /// <summary>
    /// <para>Minimum equivalent of <see cref="CpuParticles2D.RadialAccelMax" />.</para>
    /// </summary>
    float RadialAccelMin { get; set; }
    /// <summary>
    /// <para>Emission lifetime randomness ratio.</para>
    /// </summary>
    float Randomness { get; set; }
    /// <summary>
    /// <para>Restarts the particle emitter.</para>
    /// </summary>
    void Restart();
    /// <summary>
    /// <para>Each particle's scale will vary along this <see cref="Curve" />.</para>
    /// </summary>
    Curve ScaleAmountCurve { get; set; }
    /// <summary>
    /// <para>Maximum initial scale applied to each particle.</para>
    /// </summary>
    float ScaleAmountMax { get; set; }
    /// <summary>
    /// <para>Minimum equivalent of <see cref="CpuParticles2D.ScaleAmountMax" />.</para>
    /// </summary>
    float ScaleAmountMin { get; set; }
    /// <summary>
    /// <para>Each particle's horizontal scale will vary along this <see cref="Curve" />.</para>
    /// <para><see cref="CpuParticles2D.SplitScale" /> must be enabled.</para>
    /// </summary>
    Curve ScaleCurveX { get; set; }
    /// <summary>
    /// <para>Each particle's vertical scale will vary along this <see cref="Curve" />.</para>
    /// <para><see cref="CpuParticles2D.SplitScale" /> must be enabled.</para>
    /// </summary>
    Curve ScaleCurveY { get; set; }
    /// <summary>
    /// <para>Particle system's running speed scaling ratio. A value of <c>0</c> can be used to pause the particles.</para>
    /// </summary>
    double SpeedScale { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the scale curve will be split into x and y components. See <see cref="CpuParticles2D.ScaleCurveX" /> and <see cref="CpuParticles2D.ScaleCurveY" />.</para>
    /// </summary>
    bool SplitScale { get; set; }
    /// <summary>
    /// <para>Each particle's initial direction range from <c>+spread</c> to <c>-spread</c> degrees.</para>
    /// </summary>
    float Spread { get; set; }
    /// <summary>
    /// <para>Each particle's tangential acceleration will vary along this <see cref="Curve" />.</para>
    /// </summary>
    Curve TangentialAccelCurve { get; set; }
    /// <summary>
    /// <para>Maximum tangential acceleration applied to each particle. Tangential acceleration is perpendicular to the particle's velocity giving the particles a swirling motion.</para>
    /// </summary>
    float TangentialAccelMax { get; set; }
    /// <summary>
    /// <para>Minimum equivalent of <see cref="CpuParticles2D.TangentialAccelMax" />.</para>
    /// </summary>
    float TangentialAccelMin { get; set; }
    /// <summary>
    /// <para>Particle texture. If <c>null</c>, particles will be squares.</para>
    /// </summary>
    Texture2D Texture { get; set; }

}