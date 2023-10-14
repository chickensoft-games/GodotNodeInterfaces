namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class CpuParticles3DNode : CpuParticles3D, ICpuParticles3D { }

/// <summary>
/// <para>CPU-based 3D particle node used to create a variety of particle systems and effects.</para>
/// <para>See also <see cref="GpuParticles3D" />, which provides the same functionality with hardware acceleration, but may not run on older devices.</para>
/// </summary>
public interface ICpuParticles3D : IGeometryInstance3D {
    /// <summary>
    /// <para>Number of particles emitted in one emission cycle.</para>
    /// </summary>
    int Amount { get; set; }
    /// <summary>
    /// <para>Each particle's rotation will be animated along this <see cref="Curve" />.</para>
    /// </summary>
    Curve AngleCurve { get; set; }
    /// <summary>
    /// <para>Maximum angle.</para>
    /// </summary>
    float AngleMax { get; set; }
    /// <summary>
    /// <para>Minimum angle.</para>
    /// </summary>
    float AngleMin { get; set; }
    /// <summary>
    /// <para>Each particle's angular velocity (rotation speed) will vary along this <see cref="Curve" /> over its lifetime.</para>
    /// </summary>
    Curve AngularVelocityCurve { get; set; }
    /// <summary>
    /// <para>Maximum initial angular velocity (rotation speed) applied to each particle in <i>degrees</i> per second.</para>
    /// </summary>
    float AngularVelocityMax { get; set; }
    /// <summary>
    /// <para>Minimum initial angular velocity (rotation speed) applied to each particle in <i>degrees</i> per second.</para>
    /// </summary>
    float AngularVelocityMin { get; set; }
    /// <summary>
    /// <para>Each particle's animation offset will vary along this <see cref="Curve" />.</para>
    /// </summary>
    Curve AnimOffsetCurve { get; set; }
    /// <summary>
    /// <para>Maximum animation offset.</para>
    /// </summary>
    float AnimOffsetMax { get; set; }
    /// <summary>
    /// <para>Minimum animation offset.</para>
    /// </summary>
    float AnimOffsetMin { get; set; }
    /// <summary>
    /// <para>Each particle's animation speed will vary along this <see cref="Curve" />.</para>
    /// </summary>
    Curve AnimSpeedCurve { get; set; }
    /// <summary>
    /// <para>Maximum particle animation speed.</para>
    /// </summary>
    float AnimSpeedMax { get; set; }
    /// <summary>
    /// <para>Minimum particle animation speed.</para>
    /// </summary>
    float AnimSpeedMin { get; set; }
    /// <summary>
    /// <para>Each particle's initial color.</para>
    /// <para><b>Note:</b> <see cref="CpuParticles3D.Color" /> multiplies the particle mesh's vertex colors. To have a visible effect on a <see cref="BaseMaterial3D" />, <see cref="BaseMaterial3D.VertexColorUseAsAlbedo" /> <i>must</i> be <c>true</c>. For a <see cref="ShaderMaterial" />, <c>ALBEDO *= COLOR.rgb;</c> must be inserted in the shader's <c>fragment()</c> function. Otherwise, <see cref="CpuParticles3D.Color" /> will have no visible effect.</para>
    /// </summary>
    Color Color { get; set; }
    /// <summary>
    /// <para>Each particle's initial color will vary along this <see cref="GradientTexture1D" /> (multiplied with <see cref="CpuParticles3D.Color" />).</para>
    /// <para><b>Note:</b> <see cref="CpuParticles3D.ColorInitialRamp" /> multiplies the particle mesh's vertex colors. To have a visible effect on a <see cref="BaseMaterial3D" />, <see cref="BaseMaterial3D.VertexColorUseAsAlbedo" /> <i>must</i> be <c>true</c>. For a <see cref="ShaderMaterial" />, <c>ALBEDO *= COLOR.rgb;</c> must be inserted in the shader's <c>fragment()</c> function. Otherwise, <see cref="CpuParticles3D.ColorInitialRamp" /> will have no visible effect.</para>
    /// </summary>
    Gradient ColorInitialRamp { get; set; }
    /// <summary>
    /// <para>Each particle's color will vary along this <see cref="GradientTexture1D" /> over its lifetime (multiplied with <see cref="CpuParticles3D.Color" />).</para>
    /// <para><b>Note:</b> <see cref="CpuParticles3D.ColorRamp" /> multiplies the particle mesh's vertex colors. To have a visible effect on a <see cref="BaseMaterial3D" />, <see cref="BaseMaterial3D.VertexColorUseAsAlbedo" /> <i>must</i> be <c>true</c>. For a <see cref="ShaderMaterial" />, <c>ALBEDO *= COLOR.rgb;</c> must be inserted in the shader's <c>fragment()</c> function. Otherwise, <see cref="CpuParticles3D.ColorRamp" /> will have no visible effect.</para>
    /// </summary>
    Gradient ColorRamp { get; set; }
    /// <summary>
    /// <para>Sets this node's properties to match a given <see cref="GpuParticles3D" /> node with an assigned <see cref="ParticleProcessMaterial" />.</para>
    /// </summary>
    void ConvertFromParticles(Node particles);
    /// <summary>
    /// <para>Damping will vary along this <see cref="Curve" />.</para>
    /// </summary>
    Curve DampingCurve { get; set; }
    /// <summary>
    /// <para>Maximum damping.</para>
    /// </summary>
    float DampingMax { get; set; }
    /// <summary>
    /// <para>Minimum damping.</para>
    /// </summary>
    float DampingMin { get; set; }
    /// <summary>
    /// <para>Unit vector specifying the particles' emission direction.</para>
    /// </summary>
    Vector3 Direction { get; set; }
    /// <summary>
    /// <para>Particle draw order. Uses <see cref="CpuParticles3D.DrawOrderEnum" /> values.</para>
    /// </summary>
    CpuParticles3D.DrawOrderEnum DrawOrder { get; set; }
    /// <summary>
    /// <para>The rectangle's extents if <see cref="CpuParticles3D.EmissionShape" /> is set to <see cref="CpuParticles3D.EmissionShapeEnum.Box" />.</para>
    /// </summary>
    Vector3 EmissionBoxExtents { get; set; }
    /// <summary>
    /// <para>Sets the <see cref="Color" />s to modulate particles by when using <see cref="CpuParticles3D.EmissionShapeEnum.Points" /> or <see cref="CpuParticles3D.EmissionShapeEnum.DirectedPoints" />.</para>
    /// <para><b>Note:</b> <see cref="CpuParticles3D.EmissionColors" /> multiplies the particle mesh's vertex colors. To have a visible effect on a <see cref="BaseMaterial3D" />, <see cref="BaseMaterial3D.VertexColorUseAsAlbedo" /> <i>must</i> be <c>true</c>. For a <see cref="ShaderMaterial" />, <c>ALBEDO *= COLOR.rgb;</c> must be inserted in the shader's <c>fragment()</c> function. Otherwise, <see cref="CpuParticles3D.EmissionColors" /> will have no visible effect.</para>
    /// </summary>
    Color[] EmissionColors { get; set; }
    /// <summary>
    /// <para>Sets the direction the particles will be emitted in when using <see cref="CpuParticles3D.EmissionShapeEnum.DirectedPoints" />.</para>
    /// </summary>
    Vector3[] EmissionNormals { get; set; }
    /// <summary>
    /// <para>Sets the initial positions to spawn particles when using <see cref="CpuParticles3D.EmissionShapeEnum.Points" /> or <see cref="CpuParticles3D.EmissionShapeEnum.DirectedPoints" />.</para>
    /// </summary>
    Vector3[] EmissionPoints { get; set; }
    /// <summary>
    /// <para>The axis of the ring when using the emitter <see cref="CpuParticles3D.EmissionShapeEnum.Ring" />.</para>
    /// </summary>
    Vector3 EmissionRingAxis { get; set; }
    /// <summary>
    /// <para>The height of the ring when using the emitter <see cref="CpuParticles3D.EmissionShapeEnum.Ring" />.</para>
    /// </summary>
    float EmissionRingHeight { get; set; }
    /// <summary>
    /// <para>The inner radius of the ring when using the emitter <see cref="CpuParticles3D.EmissionShapeEnum.Ring" />.</para>
    /// </summary>
    float EmissionRingInnerRadius { get; set; }
    /// <summary>
    /// <para>The radius of the ring when using the emitter <see cref="CpuParticles3D.EmissionShapeEnum.Ring" />.</para>
    /// </summary>
    float EmissionRingRadius { get; set; }
    /// <summary>
    /// <para>Particles will be emitted inside this region. See <see cref="CpuParticles3D.EmissionShapeEnum" /> for possible values.</para>
    /// </summary>
    CpuParticles3D.EmissionShapeEnum EmissionShape { get; set; }
    /// <summary>
    /// <para>The sphere's radius if <see cref="CpuParticles3D.EmissionShapeEnum" /> is set to <see cref="CpuParticles3D.EmissionShapeEnum.Sphere" />.</para>
    /// </summary>
    float EmissionSphereRadius { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, particles are being emitted. <see cref="CpuParticles3D.Emitting" /> can be used to start and stop particles from emitting. However, if <see cref="CpuParticles3D.OneShot" /> is <c>true</c> setting <see cref="CpuParticles3D.Emitting" /> to <c>true</c> will not restart the emission cycle until after all active particles finish processing. You can use the <see cref="CpuParticles3D.Finished" /> signal to be notified once all active particles finish processing.</para>
    /// </summary>
    bool Emitting { get; set; }
    /// <summary>
    /// <para>How rapidly particles in an emission cycle are emitted. If greater than <c>0</c>, there will be a gap in emissions before the next cycle begins.</para>
    /// </summary>
    float Explosiveness { get; set; }
    /// <summary>
    /// <para>The particle system's frame rate is fixed to a value. For example, changing the value to 2 will make the particles render at 2 frames per second. Note this does not slow down the particle system itself.</para>
    /// </summary>
    int FixedFps { get; set; }
    /// <summary>
    /// <para>Amount of <see cref="CpuParticles3D.Spread" /> in Y/Z plane. A value of <c>1</c> restricts particles to X/Z plane.</para>
    /// </summary>
    float Flatness { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, results in fractional delta calculation which has a smoother particles display effect.</para>
    /// </summary>
    bool FractDelta { get; set; }
    /// <summary>
    /// <para>Gravity applied to every particle.</para>
    /// </summary>
    Vector3 Gravity { get; set; }
    /// <summary>
    /// <para>Each particle's hue will vary along this <see cref="Curve" />.</para>
    /// </summary>
    Curve HueVariationCurve { get; set; }
    /// <summary>
    /// <para>Maximum hue variation.</para>
    /// </summary>
    float HueVariationMax { get; set; }
    /// <summary>
    /// <para>Minimum hue variation.</para>
    /// </summary>
    float HueVariationMin { get; set; }
    /// <summary>
    /// <para>Maximum value of the initial velocity.</para>
    /// </summary>
    float InitialVelocityMax { get; set; }
    /// <summary>
    /// <para>Minimum value of the initial velocity.</para>
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
    /// <para>Maximum linear acceleration.</para>
    /// </summary>
    float LinearAccelMax { get; set; }
    /// <summary>
    /// <para>Minimum linear acceleration.</para>
    /// </summary>
    float LinearAccelMin { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, particles use the parent node's coordinate space (known as local coordinates). This will cause particles to move and rotate along the <see cref="CpuParticles3D" /> node (and its parents) when it is moved or rotated. If <c>false</c>, particles use global coordinates; they will not move or rotate along the <see cref="CpuParticles3D" /> node (and its parents) when it is moved or rotated.</para>
    /// </summary>
    bool LocalCoords { get; set; }
    /// <summary>
    /// <para>The <see cref="Mesh" /> used for each particle. If <c>null</c>, particles will be spheres.</para>
    /// </summary>
    Mesh Mesh { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, only one emission cycle occurs. If set <c>true</c> during a cycle, emission will stop at the cycle's end.</para>
    /// </summary>
    bool OneShot { get; set; }
    /// <summary>
    /// <para>Each particle's orbital velocity will vary along this <see cref="Curve" />.</para>
    /// </summary>
    Curve OrbitVelocityCurve { get; set; }
    /// <summary>
    /// <para>Maximum orbit velocity.</para>
    /// </summary>
    float OrbitVelocityMax { get; set; }
    /// <summary>
    /// <para>Minimum orbit velocity.</para>
    /// </summary>
    float OrbitVelocityMin { get; set; }
    /// <summary>
    /// <para>Align Y axis of particle with the direction of its velocity.</para>
    /// </summary>
    bool ParticleFlagAlignY { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, particles will not move on the Z axis.</para>
    /// </summary>
    bool ParticleFlagDisableZ { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, particles rotate around Y axis by <see cref="CpuParticles3D.AngleMin" />.</para>
    /// </summary>
    bool ParticleFlagRotateY { get; set; }
    /// <summary>
    /// <para>Particle system starts as if it had already run for this many seconds.</para>
    /// </summary>
    double Preprocess { get; set; }
    /// <summary>
    /// <para>Each particle's radial acceleration will vary along this <see cref="Curve" />.</para>
    /// </summary>
    Curve RadialAccelCurve { get; set; }
    /// <summary>
    /// <para>Maximum radial acceleration.</para>
    /// </summary>
    float RadialAccelMax { get; set; }
    /// <summary>
    /// <para>Minimum radial acceleration.</para>
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
    /// <para>Maximum scale.</para>
    /// </summary>
    float ScaleAmountMax { get; set; }
    /// <summary>
    /// <para>Minimum scale.</para>
    /// </summary>
    float ScaleAmountMin { get; set; }
    /// <summary>
    /// <para>Curve for the scale over life, along the x axis.</para>
    /// </summary>
    Curve ScaleCurveX { get; set; }
    /// <summary>
    /// <para>Curve for the scale over life, along the y axis.</para>
    /// </summary>
    Curve ScaleCurveY { get; set; }
    /// <summary>
    /// <para>Curve for the scale over life, along the z axis.</para>
    /// </summary>
    Curve ScaleCurveZ { get; set; }
    /// <summary>
    /// <para>Particle system's running speed scaling ratio. A value of <c>0</c> can be used to pause the particles.</para>
    /// </summary>
    double SpeedScale { get; set; }
    /// <summary>
    /// <para>If set to <c>true</c>, three different scale curves can be specified, one per scale axis.</para>
    /// </summary>
    bool SplitScale { get; set; }
    /// <summary>
    /// <para>Each particle's initial direction range from <c>+spread</c> to <c>-spread</c> degrees. Applied to X/Z plane and Y/Z planes.</para>
    /// </summary>
    float Spread { get; set; }
    /// <summary>
    /// <para>Each particle's tangential acceleration will vary along this <see cref="Curve" />.</para>
    /// </summary>
    Curve TangentialAccelCurve { get; set; }
    /// <summary>
    /// <para>Maximum tangent acceleration.</para>
    /// </summary>
    float TangentialAccelMax { get; set; }
    /// <summary>
    /// <para>Minimum tangent acceleration.</para>
    /// </summary>
    float TangentialAccelMin { get; set; }

}