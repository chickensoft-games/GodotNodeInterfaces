namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
using Godot.Collections;
/// <summary>
/// <para><see cref="RigidBody3D" /> implements full 3D physics. It cannot be controlled directly, instead, you must apply forces to it (gravity, impulses, etc.), and the physics simulation will calculate the resulting movement, rotation, react to collisions, and affect other physics bodies in its path.</para>
/// <para>The body's behavior can be adjusted via <see cref="RigidBody3D.LockRotation" />, <see cref="RigidBody3D.Freeze" />, and <see cref="RigidBody3D.FreezeMode" />. By changing various properties of the object, such as <see cref="RigidBody3D.Mass" />, you can control how the physics simulation acts on it.</para>
/// <para>A rigid body will always maintain its shape and size, even when forces are applied to it. It is useful for objects that can be interacted with in an environment, such as a tree that can be knocked over or a stack of crates that can be pushed around.</para>
/// <para>If you need to override the default physics behavior, you can write a custom force integration function. See <see cref="RigidBody3D.CustomIntegrator" />.</para>
/// <para><b>Note:</b> Changing the 3D transform or <see cref="RigidBody3D.LinearVelocity" /> of a <see cref="RigidBody3D" /> very often may lead to some unpredictable behaviors. If you need to directly affect the body, prefer <see cref="RigidBody3D._IntegrateForces(Godot.PhysicsDirectBodyState3D)" /> as it allows you to directly access the physics state.</para>
/// </summary>
public class RigidBody3DAdapter : PhysicsBody3DAdapter, IRigidBody3D {
  private readonly RigidBody3D _node;

  public RigidBody3DAdapter(RigidBody3D node) : base(node) { _node = node; }

    /// <summary>
    /// <para>Called during physics processing, allowing you to read and safely modify the simulation state for the object. By default, it works in addition to the usual physics behavior, but the <see cref="RigidBody3D.CustomIntegrator" /> property allows you to disable the default behavior and do fully custom force integration for a body.</para>
    /// </summary>
    public void _IntegrateForces(PhysicsDirectBodyState3D state) => _node._IntegrateForces(state);
    /// <summary>
    /// <para>Adds a constant directional force without affecting rotation that keeps being applied over time until cleared with <c>constant_force = Vector3(0, 0, 0)</c>.</para>
    /// <para>This is equivalent to using <see cref="RigidBody3D.AddConstantForce(Godot.Vector3,System.Nullable{Godot.Vector3})" /> at the body's center of mass.</para>
    /// </summary>
    public void AddConstantCentralForce(Vector3 force) => _node.AddConstantCentralForce(force);
    /// <summary>
    /// <para>Adds a constant positioned force to the body that keeps being applied over time until cleared with <c>constant_force = Vector3(0, 0, 0)</c>.</para>
    /// <para><paramref name="position" /> is the offset from the body origin in global coordinates.</para>
    /// </summary>
    /// <param name="position">If the parameter is null, then the default value is <c>new Vector3(0, 0, 0)</c>.</param>
    public void AddConstantForce(Vector3 force, Nullable<Vector3> position) => _node.AddConstantForce(force, position);
    /// <summary>
    /// <para>Adds a constant rotational force without affecting position that keeps being applied over time until cleared with <c>constant_torque = Vector3(0, 0, 0)</c>.</para>
    /// </summary>
    public void AddConstantTorque(Vector3 torque) => _node.AddConstantTorque(torque);
    /// <summary>
    /// <para>Damps the body's rotation. By default, the body will use the <b>Default Angular Damp</b> in <b>Project &gt; Project Settings &gt; Physics &gt; 3d</b> or any value override set by an <see cref="Area3D" /> the body is in. Depending on <see cref="RigidBody3D.AngularDampMode" />, you can set <see cref="RigidBody3D.AngularDamp" /> to be added to or to replace the body's damping value.</para>
    /// <para>See <c>ProjectSettings.physics/3d/default_angular_damp</c> for more details about damping.</para>
    /// </summary>
    public float AngularDamp { get => _node.AngularDamp; set => _node.AngularDamp = value; }
    /// <summary>
    /// <para>Defines how <see cref="RigidBody3D.AngularDamp" /> is applied. See <see cref="RigidBody3D.DampMode" /> for possible values.</para>
    /// </summary>
    public RigidBody3D.DampMode AngularDampMode { get => _node.AngularDampMode; set => _node.AngularDampMode = value; }
    /// <summary>
    /// <para>The RigidBody3D's rotational velocity in <i>radians</i> per second.</para>
    /// </summary>
    public Vector3 AngularVelocity { get => _node.AngularVelocity; set => _node.AngularVelocity = value; }
    /// <summary>
    /// <para>Applies a directional force without affecting rotation. A force is time dependent and meant to be applied every physics update.</para>
    /// <para>This is equivalent to using <see cref="RigidBody3D.ApplyForce(Godot.Vector3,System.Nullable{Godot.Vector3})" /> at the body's center of mass.</para>
    /// </summary>
    public void ApplyCentralForce(Vector3 force) => _node.ApplyCentralForce(force);
    /// <summary>
    /// <para>Applies a directional impulse without affecting rotation.</para>
    /// <para>An impulse is time-independent! Applying an impulse every frame would result in a framerate-dependent force. For this reason, it should only be used when simulating one-time impacts (use the "_force" functions otherwise).</para>
    /// <para>This is equivalent to using <see cref="RigidBody3D.ApplyImpulse(Godot.Vector3,System.Nullable{Godot.Vector3})" /> at the body's center of mass.</para>
    /// </summary>
    public void ApplyCentralImpulse(Vector3 impulse) => _node.ApplyCentralImpulse(impulse);
    /// <summary>
    /// <para>Applies a positioned force to the body. A force is time dependent and meant to be applied every physics update.</para>
    /// <para><paramref name="position" /> is the offset from the body origin in global coordinates.</para>
    /// </summary>
    /// <param name="position">If the parameter is null, then the default value is <c>new Vector3(0, 0, 0)</c>.</param>
    public void ApplyForce(Vector3 force, Nullable<Vector3> position) => _node.ApplyForce(force, position);
    /// <summary>
    /// <para>Applies a positioned impulse to the body.</para>
    /// <para>An impulse is time-independent! Applying an impulse every frame would result in a framerate-dependent force. For this reason, it should only be used when simulating one-time impacts (use the "_force" functions otherwise).</para>
    /// <para><paramref name="position" /> is the offset from the body origin in global coordinates.</para>
    /// </summary>
    /// <param name="position">If the parameter is null, then the default value is <c>new Vector3(0, 0, 0)</c>.</param>
    public void ApplyImpulse(Vector3 impulse, Nullable<Vector3> position) => _node.ApplyImpulse(impulse, position);
    /// <summary>
    /// <para>Applies a rotational force without affecting position. A force is time dependent and meant to be applied every physics update.</para>
    /// <para><b>Note:</b> <see cref="RigidBody3D.Inertia" /> is required for this to work. To have <see cref="RigidBody3D.Inertia" />, an active <see cref="CollisionShape3D" /> must be a child of the node, or you can manually set <see cref="RigidBody3D.Inertia" />.</para>
    /// </summary>
    public void ApplyTorque(Vector3 torque) => _node.ApplyTorque(torque);
    /// <summary>
    /// <para>Applies a rotational impulse to the body without affecting the position.</para>
    /// <para>An impulse is time-independent! Applying an impulse every frame would result in a framerate-dependent force. For this reason, it should only be used when simulating one-time impacts (use the "_force" functions otherwise).</para>
    /// <para><b>Note:</b> <see cref="RigidBody3D.Inertia" /> is required for this to work. To have <see cref="RigidBody3D.Inertia" />, an active <see cref="CollisionShape3D" /> must be a child of the node, or you can manually set <see cref="RigidBody3D.Inertia" />.</para>
    /// </summary>
    public void ApplyTorqueImpulse(Vector3 impulse) => _node.ApplyTorqueImpulse(impulse);
    /// <summary>
    /// <para>If <c>true</c>, the body can enter sleep mode when there is no movement. See <see cref="RigidBody3D.Sleeping" />.</para>
    /// </summary>
    public bool CanSleep { get => _node.CanSleep; set => _node.CanSleep = value; }
    /// <summary>
    /// <para>The body's custom center of mass, relative to the body's origin position, when <see cref="RigidBody3D.CenterOfMassMode" /> is set to <see cref="RigidBody3D.CenterOfMassModeEnum.Custom" />. This is the balanced point of the body, where applied forces only cause linear acceleration. Applying forces outside of the center of mass causes angular acceleration.</para>
    /// <para>When <see cref="RigidBody3D.CenterOfMassMode" /> is set to <see cref="RigidBody3D.CenterOfMassModeEnum.Auto" /> (default value), the center of mass is automatically computed.</para>
    /// </summary>
    public Vector3 CenterOfMass { get => _node.CenterOfMass; set => _node.CenterOfMass = value; }
    /// <summary>
    /// <para>Defines the way the body's center of mass is set. See <see cref="RigidBody3D.CenterOfMassModeEnum" /> for possible values.</para>
    /// </summary>
    public RigidBody3D.CenterOfMassModeEnum CenterOfMassMode { get => _node.CenterOfMassMode; set => _node.CenterOfMassMode = value; }
    /// <summary>
    /// <para>The body's total constant positional forces applied during each physics update.</para>
    /// <para>See <see cref="RigidBody3D.AddConstantForce(Godot.Vector3,System.Nullable{Godot.Vector3})" /> and <see cref="RigidBody3D.AddConstantCentralForce(Godot.Vector3)" />.</para>
    /// </summary>
    public Vector3 ConstantForce { get => _node.ConstantForce; set => _node.ConstantForce = value; }
    /// <summary>
    /// <para>The body's total constant rotational forces applied during each physics update.</para>
    /// <para>See <see cref="RigidBody3D.AddConstantTorque(Godot.Vector3)" />.</para>
    /// </summary>
    public Vector3 ConstantTorque { get => _node.ConstantTorque; set => _node.ConstantTorque = value; }
    /// <summary>
    /// <para>If <c>true</c>, the RigidBody3D will emit signals when it collides with another body.</para>
    /// <para><b>Note:</b> By default the maximum contacts reported is set to 0, meaning nothing will be recorded, see <see cref="RigidBody3D.MaxContactsReported" />.</para>
    /// </summary>
    public bool ContactMonitor { get => _node.ContactMonitor; set => _node.ContactMonitor = value; }
    /// <summary>
    /// <para>If <c>true</c>, continuous collision detection is used.</para>
    /// <para>Continuous collision detection tries to predict where a moving body will collide, instead of moving it and correcting its movement if it collided. Continuous collision detection is more precise, and misses fewer impacts by small, fast-moving objects. Not using continuous collision detection is faster to compute, but can miss small, fast-moving objects.</para>
    /// </summary>
    public bool ContinuousCd { get => _node.ContinuousCd; set => _node.ContinuousCd = value; }
    /// <summary>
    /// <para>If <c>true</c>, internal force integration will be disabled (like gravity or air friction) for this body. Other than collision response, the body will only move as determined by the <see cref="RigidBody3D._IntegrateForces(Godot.PhysicsDirectBodyState3D)" /> function, if defined.</para>
    /// </summary>
    public bool CustomIntegrator { get => _node.CustomIntegrator; set => _node.CustomIntegrator = value; }
    /// <summary>
    /// <para>If <c>true</c>, the body is frozen. Gravity and forces are not applied anymore.</para>
    /// <para>See <see cref="RigidBody3D.FreezeMode" /> to set the body's behavior when frozen.</para>
    /// <para>For a body that is always frozen, use <see cref="StaticBody3D" /> or <see cref="AnimatableBody3D" /> instead.</para>
    /// </summary>
    public bool Freeze { get => _node.Freeze; set => _node.Freeze = value; }
    /// <summary>
    /// <para>The body's freeze mode. Can be used to set the body's behavior when <see cref="RigidBody3D.Freeze" /> is enabled. See <see cref="RigidBody3D.FreezeModeEnum" /> for possible values.</para>
    /// <para>For a body that is always frozen, use <see cref="StaticBody3D" /> or <see cref="AnimatableBody3D" /> instead.</para>
    /// </summary>
    public RigidBody3D.FreezeModeEnum FreezeMode { get => _node.FreezeMode; set => _node.FreezeMode = value; }
    /// <summary>
    /// <para>Returns a list of the bodies colliding with this one. Requires <see cref="RigidBody3D.ContactMonitor" /> to be set to <c>true</c> and <see cref="RigidBody3D.MaxContactsReported" /> to be set high enough to detect all the collisions.</para>
    /// <para><b>Note:</b> The result of this test is not immediate after moving objects. For performance, list of collisions is updated once per frame and before the physics step. Consider using signals instead.</para>
    /// </summary>
    public Godot.Collections.Array<Node3D> GetCollidingBodies() => _node.GetCollidingBodies();
    /// <summary>
    /// <para>Returns the number of contacts this body has with other bodies. By default, this returns 0 unless bodies are configured to monitor contacts (see <see cref="RigidBody3D.ContactMonitor" />).</para>
    /// <para><b>Note:</b> To retrieve the colliding bodies, use <see cref="RigidBody3D.GetCollidingBodies" />.</para>
    /// </summary>
    public int GetContactCount() => _node.GetContactCount();
    /// <summary>
    /// <para>Returns the inverse inertia tensor basis. This is used to calculate the angular acceleration resulting from a torque applied to the <see cref="RigidBody3D" />.</para>
    /// </summary>
    public Basis GetInverseInertiaTensor() => _node.GetInverseInertiaTensor();
    /// <summary>
    /// <para>This is multiplied by the global 3D gravity setting found in <b>Project &gt; Project Settings &gt; Physics &gt; 3d</b> to produce RigidBody3D's gravity. For example, a value of 1 will be normal gravity, 2 will apply double gravity, and 0.5 will apply half gravity to this object.</para>
    /// </summary>
    public float GravityScale { get => _node.GravityScale; set => _node.GravityScale = value; }
    /// <summary>
    /// <para>The body's moment of inertia. This is like mass, but for rotation: it determines how much torque it takes to rotate the body on each axis. The moment of inertia is usually computed automatically from the mass and the shapes, but this property allows you to set a custom value.</para>
    /// <para>If set to <c>Vector3.ZERO</c>, inertia is automatically computed (default value).</para>
    /// <para><b>Note:</b> This value does not change when inertia is automatically computed. Use <see cref="PhysicsServer3D" /> to get the computed inertia.</para>
    /// <para><code>
    /// private RigidBody3D _ball;
    /// public override void _Ready()
    /// {
    /// _ball = GetNode&lt;RigidBody3D&gt;("Ball");
    /// }
    /// private Vector3 GetBallInertia()
    /// {
    /// return PhysicsServer3D.BodyGetDirectState(_ball.GetRid()).InverseInertia.Inverse();
    /// }
    /// </code></para>
    /// </summary>
    public Vector3 Inertia { get => _node.Inertia; set => _node.Inertia = value; }
    /// <summary>
    /// <para>Damps the body's movement. By default, the body will use the <b>Default Linear Damp</b> in <b>Project &gt; Project Settings &gt; Physics &gt; 3d</b> or any value override set by an <see cref="Area3D" /> the body is in. Depending on <see cref="RigidBody3D.LinearDampMode" />, you can set <see cref="RigidBody3D.LinearDamp" /> to be added to or to replace the body's damping value.</para>
    /// <para>See <c>ProjectSettings.physics/3d/default_linear_damp</c> for more details about damping.</para>
    /// </summary>
    public float LinearDamp { get => _node.LinearDamp; set => _node.LinearDamp = value; }
    /// <summary>
    /// <para>Defines how <see cref="RigidBody3D.LinearDamp" /> is applied. See <see cref="RigidBody3D.DampMode" /> for possible values.</para>
    /// </summary>
    public RigidBody3D.DampMode LinearDampMode { get => _node.LinearDampMode; set => _node.LinearDampMode = value; }
    /// <summary>
    /// <para>The body's linear velocity in units per second. Can be used sporadically, but <b>don't set this every frame</b>, because physics may run in another thread and runs at a different granularity. Use <see cref="RigidBody3D._IntegrateForces(Godot.PhysicsDirectBodyState3D)" /> as your process loop for precise control of the body state.</para>
    /// </summary>
    public Vector3 LinearVelocity { get => _node.LinearVelocity; set => _node.LinearVelocity = value; }
    /// <summary>
    /// <para>If <c>true</c>, the body cannot rotate. Gravity and forces only apply linear movement.</para>
    /// </summary>
    public bool LockRotation { get => _node.LockRotation; set => _node.LockRotation = value; }
    /// <summary>
    /// <para>The body's mass.</para>
    /// </summary>
    public float Mass { get => _node.Mass; set => _node.Mass = value; }
    /// <summary>
    /// <para>The maximum number of contacts that will be recorded. Requires a value greater than 0 and <see cref="RigidBody3D.ContactMonitor" /> to be set to <c>true</c> to start to register contacts. Use <see cref="RigidBody3D.GetContactCount" /> to retrieve the count or <see cref="RigidBody3D.GetCollidingBodies" /> to retrieve bodies that have been collided with.</para>
    /// <para><b>Note:</b> The number of contacts is different from the number of collisions. Collisions between parallel edges will result in two contacts (one at each end), and collisions between parallel faces will result in four contacts (one at each corner).</para>
    /// </summary>
    public int MaxContactsReported { get => _node.MaxContactsReported; set => _node.MaxContactsReported = value; }
    /// <summary>
    /// <para>The physics material override for the body.</para>
    /// <para>If a material is assigned to this property, it will be used instead of any other physics material, such as an inherited one.</para>
    /// </summary>
    public PhysicsMaterial PhysicsMaterialOverride { get => _node.PhysicsMaterialOverride; set => _node.PhysicsMaterialOverride = value; }
    /// <summary>
    /// <para>Sets an axis velocity. The velocity in the given vector axis will be set as the given vector length. This is useful for jumping behavior.</para>
    /// </summary>
    public void SetAxisVelocity(Vector3 axisVelocity) => _node.SetAxisVelocity(axisVelocity);
    /// <summary>
    /// <para>If <c>true</c>, the body will not move and will not calculate forces until woken up by another body through, for example, a collision, or by using the <see cref="RigidBody3D.ApplyImpulse(Godot.Vector3,System.Nullable{Godot.Vector3})" /> or <see cref="RigidBody3D.ApplyForce(Godot.Vector3,System.Nullable{Godot.Vector3})" /> methods.</para>
    /// </summary>
    public bool Sleeping { get => _node.Sleeping; set => _node.Sleeping = value; }

}