 namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>CPU-based 2D particle node used to create a variety of particle systems and effects.</para>
/// <para>See also <see cref="GpuParticles2D" />, which provides the same functionality with hardware acceleration, but may not run on older devices.</para>
/// </summary>
public class CpuParticles2DAdapter : CpuParticles2D, ICpuParticles2D {
  private readonly CpuParticles2D _node;

  public CpuParticles2DAdapter(CpuParticles2D node) => _node = node;
    /// <summary>
    /// <para>Number of particles emitted in one emission cycle.</para>
    /// </summary>
    public int Amount { get => _node.Amount; set => _node.Amount = value; }
    /// <summary>
    /// <para>Each particle's rotation will be animated along this <see cref="Curve" />.</para>
    /// </summary>
    public Curve AngleCurve { get => _node.AngleCurve; set => _node.AngleCurve = value; }
    /// <summary>
    /// <para>Maximum initial rotation applied to each particle, in degrees.</para>
    /// </summary>
    public float AngleMax { get => _node.AngleMax; set => _node.AngleMax = value; }
    /// <summary>
    /// <para>Minimum equivalent of <see cref="CpuParticles2D.AngleMax" />.</para>
    /// </summary>
    public float AngleMin { get => _node.AngleMin; set => _node.AngleMin = value; }
    /// <summary>
    /// <para>Each particle's angular velocity will vary along this <see cref="Curve" />.</para>
    /// </summary>
    public Curve AngularVelocityCurve { get => _node.AngularVelocityCurve; set => _node.AngularVelocityCurve = value; }
    /// <summary>
    /// <para>Maximum initial angular velocity (rotation speed) applied to each particle in <i>degrees</i> per second.</para>
    /// </summary>
    public float AngularVelocityMax { get => _node.AngularVelocityMax; set => _node.AngularVelocityMax = value; }
    /// <summary>
    /// <para>Minimum equivalent of <see cref="CpuParticles2D.AngularVelocityMax" />.</para>
    /// </summary>
    public float AngularVelocityMin { get => _node.AngularVelocityMin; set => _node.AngularVelocityMin = value; }
    /// <summary>
    /// <para>Each particle's animation offset will vary along this <see cref="Curve" />.</para>
    /// </summary>
    public Curve AnimOffsetCurve { get => _node.AnimOffsetCurve; set => _node.AnimOffsetCurve = value; }
    /// <summary>
    /// <para>Maximum animation offset that corresponds to frame index in the texture. <c>0</c> is the first frame, <c>1</c> is the last one. See <see cref="CanvasItemMaterial.ParticlesAnimation" />.</para>
    /// </summary>
    public float AnimOffsetMax { get => _node.AnimOffsetMax; set => _node.AnimOffsetMax = value; }
    /// <summary>
    /// <para>Minimum equivalent of <see cref="CpuParticles2D.AnimOffsetMax" />.</para>
    /// </summary>
    public float AnimOffsetMin { get => _node.AnimOffsetMin; set => _node.AnimOffsetMin = value; }
    /// <summary>
    /// <para>Each particle's animation speed will vary along this <see cref="Curve" />.</para>
    /// </summary>
    public Curve AnimSpeedCurve { get => _node.AnimSpeedCurve; set => _node.AnimSpeedCurve = value; }
    /// <summary>
    /// <para>Maximum particle animation speed. Animation speed of <c>1</c> means that the particles will make full <c>0</c> to <c>1</c> offset cycle during lifetime, <c>2</c> means <c>2</c> cycles etc.</para>
    /// <para>With animation speed greater than <c>1</c>, remember to enable <see cref="CanvasItemMaterial.ParticlesAnimLoop" /> property if you want the animation to repeat.</para>
    /// </summary>
    public float AnimSpeedMax { get => _node.AnimSpeedMax; set => _node.AnimSpeedMax = value; }
    /// <summary>
    /// <para>Minimum equivalent of <see cref="CpuParticles2D.AnimSpeedMax" />.</para>
    /// </summary>
    public float AnimSpeedMin { get => _node.AnimSpeedMin; set => _node.AnimSpeedMin = value; }
    /// <summary>
    /// <para>Each particle's initial color. If <see cref="CpuParticles2D.Texture" /> is defined, it will be multiplied by this color.</para>
    /// </summary>
    public Color Color { get => _node.Color; set => _node.Color = value; }
    /// <summary>
    /// <para>Each particle's initial color will vary along this <see cref="GradientTexture1D" /> (multiplied with <see cref="CpuParticles2D.Color" />).</para>
    /// </summary>
    public Gradient ColorInitialRamp { get => _node.ColorInitialRamp; set => _node.ColorInitialRamp = value; }
    /// <summary>
    /// <para>Each particle's color will vary along this <see cref="Gradient" /> (multiplied with <see cref="CpuParticles2D.Color" />).</para>
    /// </summary>
    public Gradient ColorRamp { get => _node.ColorRamp; set => _node.ColorRamp = value; }
    /// <summary>
    /// <para>Sets this node's properties to match a given <see cref="GpuParticles2D" /> node with an assigned <see cref="ParticleProcessMaterial" />.</para>
    /// </summary>
    public void ConvertFromParticles(Node particles) => _node.ConvertFromParticles(particles);
    /// <summary>
    /// <para>Damping will vary along this <see cref="Curve" />.</para>
    /// </summary>
    public Curve DampingCurve { get => _node.DampingCurve; set => _node.DampingCurve = value; }
    /// <summary>
    /// <para>The maximum rate at which particles lose velocity. For example value of <c>100</c> means that the particle will go from <c>100</c> velocity to <c>0</c> in <c>1</c> second.</para>
    /// </summary>
    public float DampingMax { get => _node.DampingMax; set => _node.DampingMax = value; }
    /// <summary>
    /// <para>Minimum equivalent of <see cref="CpuParticles2D.DampingMax" />.</para>
    /// </summary>
    public float DampingMin { get => _node.DampingMin; set => _node.DampingMin = value; }
    /// <summary>
    /// <para>Unit vector specifying the particles' emission direction.</para>
    /// </summary>
    public Vector2 Direction { get => _node.Direction; set => _node.Direction = value; }
    /// <summary>
    /// <para>Particle draw order. Uses <see cref="CpuParticles2D.DrawOrderEnum" /> values.</para>
    /// </summary>
    public CpuParticles2D.DrawOrderEnum DrawOrder { get => _node.DrawOrder; set => _node.DrawOrder = value; }
    /// <summary>
    /// <para>Sets the <see cref="Color" />s to modulate particles by when using <see cref="CpuParticles2D.EmissionShapeEnum.Points" /> or <see cref="CpuParticles2D.EmissionShapeEnum.DirectedPoints" />.</para>
    /// </summary>
    public Color[] EmissionColors { get => _node.EmissionColors; set => _node.EmissionColors = value; }
    /// <summary>
    /// <para>Sets the direction the particles will be emitted in when using <see cref="CpuParticles2D.EmissionShapeEnum.DirectedPoints" />.</para>
    /// </summary>
    public Vector2[] EmissionNormals { get => _node.EmissionNormals; set => _node.EmissionNormals = value; }
    /// <summary>
    /// <para>Sets the initial positions to spawn particles when using <see cref="CpuParticles2D.EmissionShapeEnum.Points" /> or <see cref="CpuParticles2D.EmissionShapeEnum.DirectedPoints" />.</para>
    /// </summary>
    public Vector2[] EmissionPoints { get => _node.EmissionPoints; set => _node.EmissionPoints = value; }
    /// <summary>
    /// <para>The rectangle's extents if <see cref="CpuParticles2D.EmissionShape" /> is set to <see cref="CpuParticles2D.EmissionShapeEnum.Rectangle" />.</para>
    /// </summary>
    public Vector2 EmissionRectExtents { get => _node.EmissionRectExtents; set => _node.EmissionRectExtents = value; }
    /// <summary>
    /// <para>Particles will be emitted inside this region. See <see cref="CpuParticles2D.EmissionShapeEnum" /> for possible values.</para>
    /// </summary>
    public CpuParticles2D.EmissionShapeEnum EmissionShape { get => _node.EmissionShape; set => _node.EmissionShape = value; }
    /// <summary>
    /// <para>The sphere's radius if <see cref="CpuParticles2D.EmissionShape" /> is set to <see cref="CpuParticles2D.EmissionShapeEnum.Sphere" />.</para>
    /// </summary>
    public float EmissionSphereRadius { get => _node.EmissionSphereRadius; set => _node.EmissionSphereRadius = value; }
    /// <summary>
    /// <para>If <c>true</c>, particles are being emitted. <see cref="CpuParticles2D.Emitting" /> can be used to start and stop particles from emitting. However, if <see cref="CpuParticles2D.OneShot" /> is <c>true</c> setting <see cref="CpuParticles2D.Emitting" /> to <c>true</c> will not restart the emission cycle until after all active particles finish processing. You can use the <see cref="CpuParticles2D.Finished" /> signal to be notified once all active particles finish processing.</para>
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
    /// <para>Gravity applied to every particle.</para>
    /// </summary>
    public Vector2 Gravity { get => _node.Gravity; set => _node.Gravity = value; }
    /// <summary>
    /// <para>Each particle's hue will vary along this <see cref="Curve" />.</para>
    /// </summary>
    public Curve HueVariationCurve { get => _node.HueVariationCurve; set => _node.HueVariationCurve = value; }
    /// <summary>
    /// <para>Maximum initial hue variation applied to each particle. It will shift the particle color's hue.</para>
    /// </summary>
    public float HueVariationMax { get => _node.HueVariationMax; set => _node.HueVariationMax = value; }
    /// <summary>
    /// <para>Minimum equivalent of <see cref="CpuParticles2D.HueVariationMax" />.</para>
    /// </summary>
    public float HueVariationMin { get => _node.HueVariationMin; set => _node.HueVariationMin = value; }
    /// <summary>
    /// <para>Maximum initial velocity magnitude for each particle. Direction comes from <see cref="CpuParticles2D.Direction" /> and <see cref="CpuParticles2D.Spread" />.</para>
    /// </summary>
    public float InitialVelocityMax { get => _node.InitialVelocityMax; set => _node.InitialVelocityMax = value; }
    /// <summary>
    /// <para>Minimum equivalent of <see cref="CpuParticles2D.InitialVelocityMax" />.</para>
    /// </summary>
    public float InitialVelocityMin { get => _node.InitialVelocityMin; set => _node.InitialVelocityMin = value; }
    /// <summary>
    /// <para>Amount of time each particle will exist.</para>
    /// </summary>
    public double Lifetime { get => _node.Lifetime; set => _node.Lifetime = value; }
    /// <summary>
    /// <para>Particle lifetime randomness ratio.</para>
    /// </summary>
    public double LifetimeRandomness { get => _node.LifetimeRandomness; set => _node.LifetimeRandomness = value; }
    /// <summary>
    /// <para>Each particle's linear acceleration will vary along this <see cref="Curve" />.</para>
    /// </summary>
    public Curve LinearAccelCurve { get => _node.LinearAccelCurve; set => _node.LinearAccelCurve = value; }
    /// <summary>
    /// <para>Maximum linear acceleration applied to each particle in the direction of motion.</para>
    /// </summary>
    public float LinearAccelMax { get => _node.LinearAccelMax; set => _node.LinearAccelMax = value; }
    /// <summary>
    /// <para>Minimum equivalent of <see cref="CpuParticles2D.LinearAccelMax" />.</para>
    /// </summary>
    public float LinearAccelMin { get => _node.LinearAccelMin; set => _node.LinearAccelMin = value; }
    /// <summary>
    /// <para>If <c>true</c>, particles use the parent node's coordinate space (known as local coordinates). This will cause particles to move and rotate along the <see cref="CpuParticles2D" /> node (and its parents) when it is moved or rotated. If <c>false</c>, particles use global coordinates; they will not move or rotate along the <see cref="CpuParticles2D" /> node (and its parents) when it is moved or rotated.</para>
    /// </summary>
    public bool LocalCoords { get => _node.LocalCoords; set => _node.LocalCoords = value; }
    /// <summary>
    /// <para>If <c>true</c>, only one emission cycle occurs. If set <c>true</c> during a cycle, emission will stop at the cycle's end.</para>
    /// </summary>
    public bool OneShot { get => _node.OneShot; set => _node.OneShot = value; }
    /// <summary>
    /// <para>Each particle's orbital velocity will vary along this <see cref="Curve" />.</para>
    /// </summary>
    public Curve OrbitVelocityCurve { get => _node.OrbitVelocityCurve; set => _node.OrbitVelocityCurve = value; }
    /// <summary>
    /// <para>Maximum orbital velocity applied to each particle. Makes the particles circle around origin. Specified in number of full rotations around origin per second.</para>
    /// </summary>
    public float OrbitVelocityMax { get => _node.OrbitVelocityMax; set => _node.OrbitVelocityMax = value; }
    /// <summary>
    /// <para>Minimum equivalent of <see cref="CpuParticles2D.OrbitVelocityMax" />.</para>
    /// </summary>
    public float OrbitVelocityMin { get => _node.OrbitVelocityMin; set => _node.OrbitVelocityMin = value; }
    /// <summary>
    /// <para>Align Y axis of particle with the direction of its velocity.</para>
    /// </summary>
    public bool ParticleFlagAlignY { get => _node.ParticleFlagAlignY; set => _node.ParticleFlagAlignY = value; }
    /// <summary>
    /// <para>Particle system starts as if it had already run for this many seconds.</para>
    /// </summary>
    public double Preprocess { get => _node.Preprocess; set => _node.Preprocess = value; }
    /// <summary>
    /// <para>Each particle's radial acceleration will vary along this <see cref="Curve" />.</para>
    /// </summary>
    public Curve RadialAccelCurve { get => _node.RadialAccelCurve; set => _node.RadialAccelCurve = value; }
    /// <summary>
    /// <para>Maximum radial acceleration applied to each particle. Makes particle accelerate away from the origin or towards it if negative.</para>
    /// </summary>
    public float RadialAccelMax { get => _node.RadialAccelMax; set => _node.RadialAccelMax = value; }
    /// <summary>
    /// <para>Minimum equivalent of <see cref="CpuParticles2D.RadialAccelMax" />.</para>
    /// </summary>
    public float RadialAccelMin { get => _node.RadialAccelMin; set => _node.RadialAccelMin = value; }
    /// <summary>
    /// <para>Emission lifetime randomness ratio.</para>
    /// </summary>
    public float Randomness { get => _node.Randomness; set => _node.Randomness = value; }
    /// <summary>
    /// <para>Restarts the particle emitter.</para>
    /// </summary>
    public void Restart() => _node.Restart();
    /// <summary>
    /// <para>Each particle's scale will vary along this <see cref="Curve" />.</para>
    /// </summary>
    public Curve ScaleAmountCurve { get => _node.ScaleAmountCurve; set => _node.ScaleAmountCurve = value; }
    /// <summary>
    /// <para>Maximum initial scale applied to each particle.</para>
    /// </summary>
    public float ScaleAmountMax { get => _node.ScaleAmountMax; set => _node.ScaleAmountMax = value; }
    /// <summary>
    /// <para>Minimum equivalent of <see cref="CpuParticles2D.ScaleAmountMax" />.</para>
    /// </summary>
    public float ScaleAmountMin { get => _node.ScaleAmountMin; set => _node.ScaleAmountMin = value; }
    /// <summary>
    /// <para>Each particle's horizontal scale will vary along this <see cref="Curve" />.</para>
    /// <para><see cref="CpuParticles2D.SplitScale" /> must be enabled.</para>
    /// </summary>
    public Curve ScaleCurveX { get => _node.ScaleCurveX; set => _node.ScaleCurveX = value; }
    /// <summary>
    /// <para>Each particle's vertical scale will vary along this <see cref="Curve" />.</para>
    /// <para><see cref="CpuParticles2D.SplitScale" /> must be enabled.</para>
    /// </summary>
    public Curve ScaleCurveY { get => _node.ScaleCurveY; set => _node.ScaleCurveY = value; }
    /// <summary>
    /// <para>Particle system's running speed scaling ratio. A value of <c>0</c> can be used to pause the particles.</para>
    /// </summary>
    public double SpeedScale { get => _node.SpeedScale; set => _node.SpeedScale = value; }
    /// <summary>
    /// <para>If <c>true</c>, the scale curve will be split into x and y components. See <see cref="CpuParticles2D.ScaleCurveX" /> and <see cref="CpuParticles2D.ScaleCurveY" />.</para>
    /// </summary>
    public bool SplitScale { get => _node.SplitScale; set => _node.SplitScale = value; }
    /// <summary>
    /// <para>Each particle's initial direction range from <c>+spread</c> to <c>-spread</c> degrees.</para>
    /// </summary>
    public float Spread { get => _node.Spread; set => _node.Spread = value; }
    /// <summary>
    /// <para>Each particle's tangential acceleration will vary along this <see cref="Curve" />.</para>
    /// </summary>
    public Curve TangentialAccelCurve { get => _node.TangentialAccelCurve; set => _node.TangentialAccelCurve = value; }
    /// <summary>
    /// <para>Maximum tangential acceleration applied to each particle. Tangential acceleration is perpendicular to the particle's velocity giving the particles a swirling motion.</para>
    /// </summary>
    public float TangentialAccelMax { get => _node.TangentialAccelMax; set => _node.TangentialAccelMax = value; }
    /// <summary>
    /// <para>Minimum equivalent of <see cref="CpuParticles2D.TangentialAccelMax" />.</para>
    /// </summary>
    public float TangentialAccelMin { get => _node.TangentialAccelMin; set => _node.TangentialAccelMin = value; }
    /// <summary>
    /// <para>Particle texture. If <c>null</c>, particles will be squares.</para>
    /// </summary>
    public Texture2D Texture { get => _node.Texture; set => _node.Texture = value; }

}