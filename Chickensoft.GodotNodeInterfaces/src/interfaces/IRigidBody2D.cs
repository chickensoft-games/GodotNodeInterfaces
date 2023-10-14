namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
using Godot.Collections;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class RigidBody2DNode : RigidBody2D, IRigidBody2D { }

/// <summary>
/// <para><see cref="RigidBody2D" /> implements full 2D physics. It cannot be controlled directly, instead, you must apply forces to it (gravity, impulses, etc.), and the physics simulation will calculate the resulting movement, rotation, react to collisions, and affect other physics bodies in its path.</para>
/// <para>The body's behavior can be adjusted via <see cref="RigidBody2D.LockRotation" />, <see cref="RigidBody2D.Freeze" />, and <see cref="RigidBody2D.FreezeMode" />. By changing various properties of the object, such as <see cref="RigidBody2D.Mass" />, you can control how the physics simulation acts on it.</para>
/// <para>A rigid body will always maintain its shape and size, even when forces are applied to it. It is useful for objects that can be interacted with in an environment, such as a tree that can be knocked over or a stack of crates that can be pushed around.</para>
/// <para>If you need to override the default physics behavior, you can write a custom force integration function. See <see cref="RigidBody2D.CustomIntegrator" />.</para>
/// <para><b>Note:</b> Changing the 2D transform or <see cref="RigidBody2D.LinearVelocity" /> of a <see cref="RigidBody2D" /> very often may lead to some unpredictable behaviors. If you need to directly affect the body, prefer <see cref="RigidBody2D._IntegrateForces(Godot.PhysicsDirectBodyState2D)" /> as it allows you to directly access the physics state.</para>
/// </summary>
public interface IRigidBody2D : IPhysicsBody2D {
    /// <summary>
    /// <para>Allows you to read and safely modify the simulation state for the object. Use this instead of <see cref="Node._PhysicsProcess(System.Double)" /> if you need to directly change the body's <c>position</c> or other physics properties. By default, it works in addition to the usual physics behavior, but <see cref="RigidBody2D.CustomIntegrator" /> allows you to disable the default behavior and write custom force integration for a body.</para>
    /// </summary>
    void _IntegrateForces(PhysicsDirectBodyState2D state);
    /// <summary>
    /// <para>Adds a constant directional force without affecting rotation that keeps being applied over time until cleared with <c>constant_force = Vector2(0, 0)</c>.</para>
    /// <para>This is equivalent to using <see cref="RigidBody2D.AddConstantForce(Godot.Vector2,System.Nullable{Godot.Vector2})" /> at the body's center of mass.</para>
    /// </summary>
    void AddConstantCentralForce(Vector2 force);
    /// <summary>
    /// <para>Adds a constant positioned force to the body that keeps being applied over time until cleared with <c>constant_force = Vector2(0, 0)</c>.</para>
    /// <para><paramref name="position" /> is the offset from the body origin in global coordinates.</para>
    /// </summary>
    /// <param name="position">If the parameter is null, then the default value is <c>new Vector2(0, 0)</c>.</param>
    void AddConstantForce(Vector2 force, Nullable<Vector2> position);
    /// <summary>
    /// <para>Adds a constant rotational force without affecting position that keeps being applied over time until cleared with <c>constant_torque = 0</c>.</para>
    /// </summary>
    void AddConstantTorque(float torque);
    /// <summary>
    /// <para>Damps the body's rotation. By default, the body will use the <b>Default Angular Damp</b> in <b>Project &gt; Project Settings &gt; Physics &gt; 2d</b> or any value override set by an <see cref="Area2D" /> the body is in. Depending on <see cref="RigidBody2D.AngularDampMode" />, you can set <see cref="RigidBody2D.AngularDamp" /> to be added to or to replace the body's damping value.</para>
    /// <para>See <c>ProjectSettings.physics/2d/default_angular_damp</c> for more details about damping.</para>
    /// </summary>
    float AngularDamp { get; set; }
    /// <summary>
    /// <para>Defines how <see cref="RigidBody2D.AngularDamp" /> is applied. See <see cref="RigidBody2D.DampMode" /> for possible values.</para>
    /// </summary>
    RigidBody2D.DampMode AngularDampMode { get; set; }
    /// <summary>
    /// <para>The body's rotational velocity in <i>radians</i> per second.</para>
    /// </summary>
    float AngularVelocity { get; set; }
    /// <summary>
    /// <para>Applies a directional force without affecting rotation. A force is time dependent and meant to be applied every physics update.</para>
    /// <para>This is equivalent to using <see cref="RigidBody2D.ApplyForce(Godot.Vector2,System.Nullable{Godot.Vector2})" /> at the body's center of mass.</para>
    /// </summary>
    void ApplyCentralForce(Vector2 force);
    /// <summary>
    /// <para>Applies a directional impulse without affecting rotation.</para>
    /// <para>An impulse is time-independent! Applying an impulse every frame would result in a framerate-dependent force. For this reason, it should only be used when simulating one-time impacts (use the "_force" functions otherwise).</para>
    /// <para>This is equivalent to using <see cref="RigidBody2D.ApplyImpulse(Godot.Vector2,System.Nullable{Godot.Vector2})" /> at the body's center of mass.</para>
    /// </summary>
    /// <param name="impulse">If the parameter is null, then the default value is <c>new Vector2(0, 0)</c>.</param>
    void ApplyCentralImpulse(Nullable<Vector2> impulse);
    /// <summary>
    /// <para>Applies a positioned force to the body. A force is time dependent and meant to be applied every physics update.</para>
    /// <para><paramref name="position" /> is the offset from the body origin in global coordinates.</para>
    /// </summary>
    /// <param name="position">If the parameter is null, then the default value is <c>new Vector2(0, 0)</c>.</param>
    void ApplyForce(Vector2 force, Nullable<Vector2> position);
    /// <summary>
    /// <para>Applies a positioned impulse to the body.</para>
    /// <para>An impulse is time-independent! Applying an impulse every frame would result in a framerate-dependent force. For this reason, it should only be used when simulating one-time impacts (use the "_force" functions otherwise).</para>
    /// <para><paramref name="position" /> is the offset from the body origin in global coordinates.</para>
    /// </summary>
    /// <param name="position">If the parameter is null, then the default value is <c>new Vector2(0, 0)</c>.</param>
    void ApplyImpulse(Vector2 impulse, Nullable<Vector2> position);
    /// <summary>
    /// <para>Applies a rotational force without affecting position. A force is time dependent and meant to be applied every physics update.</para>
    /// <para><b>Note:</b> <see cref="RigidBody2D.Inertia" /> is required for this to work. To have <see cref="RigidBody2D.Inertia" />, an active <see cref="CollisionShape2D" /> must be a child of the node, or you can manually set <see cref="RigidBody2D.Inertia" />.</para>
    /// </summary>
    void ApplyTorque(float torque);
    /// <summary>
    /// <para>Applies a rotational impulse to the body without affecting the position.</para>
    /// <para>An impulse is time-independent! Applying an impulse every frame would result in a framerate-dependent force. For this reason, it should only be used when simulating one-time impacts (use the "_force" functions otherwise).</para>
    /// <para><b>Note:</b> <see cref="RigidBody2D.Inertia" /> is required for this to work. To have <see cref="RigidBody2D.Inertia" />, an active <see cref="CollisionShape2D" /> must be a child of the node, or you can manually set <see cref="RigidBody2D.Inertia" />.</para>
    /// </summary>
    void ApplyTorqueImpulse(float torque);
    /// <summary>
    /// <para>If <c>true</c>, the body can enter sleep mode when there is no movement. See <see cref="RigidBody2D.Sleeping" />.</para>
    /// </summary>
    bool CanSleep { get; set; }
    /// <summary>
    /// <para>The body's custom center of mass, relative to the body's origin position, when <see cref="RigidBody2D.CenterOfMassMode" /> is set to <see cref="RigidBody2D.CenterOfMassModeEnum.Custom" />. This is the balanced point of the body, where applied forces only cause linear acceleration. Applying forces outside of the center of mass causes angular acceleration.</para>
    /// <para>When <see cref="RigidBody2D.CenterOfMassMode" /> is set to <see cref="RigidBody2D.CenterOfMassModeEnum.Auto" /> (default value), the center of mass is automatically computed.</para>
    /// </summary>
    Vector2 CenterOfMass { get; set; }
    /// <summary>
    /// <para>Defines the way the body's center of mass is set. See <see cref="RigidBody2D.CenterOfMassModeEnum" /> for possible values.</para>
    /// </summary>
    RigidBody2D.CenterOfMassModeEnum CenterOfMassMode { get; set; }
    /// <summary>
    /// <para>The body's total constant positional forces applied during each physics update.</para>
    /// <para>See <see cref="RigidBody2D.AddConstantForce(Godot.Vector2,System.Nullable{Godot.Vector2})" /> and <see cref="RigidBody2D.AddConstantCentralForce(Godot.Vector2)" />.</para>
    /// </summary>
    Vector2 ConstantForce { get; set; }
    /// <summary>
    /// <para>The body's total constant rotational forces applied during each physics update.</para>
    /// <para>See <see cref="RigidBody2D.AddConstantTorque(System.Single)" />.</para>
    /// </summary>
    float ConstantTorque { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the RigidBody2D will emit signals when it collides with another body.</para>
    /// <para><b>Note:</b> By default the maximum contacts reported is set to 0, meaning nothing will be recorded, see <see cref="RigidBody2D.MaxContactsReported" />.</para>
    /// </summary>
    bool ContactMonitor { get; set; }
    /// <summary>
    /// <para>Continuous collision detection mode.</para>
    /// <para>Continuous collision detection tries to predict where a moving body will collide instead of moving it and correcting its movement after collision. Continuous collision detection is slower, but more precise and misses fewer collisions with small, fast-moving objects. Raycasting and shapecasting methods are available. See <see cref="RigidBody2D.CcdMode" /> for details.</para>
    /// </summary>
    RigidBody2D.CcdMode ContinuousCd { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, internal force integration is disabled for this body. Aside from collision response, the body will only move as determined by the <see cref="RigidBody2D._IntegrateForces(Godot.PhysicsDirectBodyState2D)" /> function.</para>
    /// </summary>
    bool CustomIntegrator { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the body is frozen. Gravity and forces are not applied anymore.</para>
    /// <para>See <see cref="RigidBody2D.FreezeMode" /> to set the body's behavior when frozen.</para>
    /// <para>For a body that is always frozen, use <see cref="StaticBody2D" /> or <see cref="AnimatableBody2D" /> instead.</para>
    /// </summary>
    bool Freeze { get; set; }
    /// <summary>
    /// <para>The body's freeze mode. Can be used to set the body's behavior when <see cref="RigidBody2D.Freeze" /> is enabled. See <see cref="RigidBody2D.FreezeModeEnum" /> for possible values.</para>
    /// <para>For a body that is always frozen, use <see cref="StaticBody2D" /> or <see cref="AnimatableBody2D" /> instead.</para>
    /// </summary>
    RigidBody2D.FreezeModeEnum FreezeMode { get; set; }
    /// <summary>
    /// <para>Returns a list of the bodies colliding with this one. Requires <see cref="RigidBody2D.ContactMonitor" /> to be set to <c>true</c> and <see cref="RigidBody2D.MaxContactsReported" /> to be set high enough to detect all the collisions.</para>
    /// <para><b>Note:</b> The result of this test is not immediate after moving objects. For performance, list of collisions is updated once per frame and before the physics step. Consider using signals instead.</para>
    /// </summary>
    Godot.Collections.Array<Node2D> GetCollidingBodies();
    /// <summary>
    /// <para>Returns the number of contacts this body has with other bodies. By default, this returns 0 unless bodies are configured to monitor contacts (see <see cref="RigidBody2D.ContactMonitor" />).</para>
    /// <para><b>Note:</b> To retrieve the colliding bodies, use <see cref="RigidBody2D.GetCollidingBodies" />.</para>
    /// </summary>
    int GetContactCount();
    /// <summary>
    /// <para>Multiplies the gravity applied to the body. The body's gravity is calculated from the <b>Default Gravity</b> value in <b>Project &gt; Project Settings &gt; Physics &gt; 2d</b> and/or any additional gravity vector applied by <see cref="Area2D" />s.</para>
    /// </summary>
    float GravityScale { get; set; }
    /// <summary>
    /// <para>The body's moment of inertia. This is like mass, but for rotation: it determines how much torque it takes to rotate the body. The moment of inertia is usually computed automatically from the mass and the shapes, but this property allows you to set a custom value.</para>
    /// <para>If set to <c>0</c>, inertia is automatically computed (default value).</para>
    /// <para><b>Note:</b> This value does not change when inertia is automatically computed. Use <see cref="PhysicsServer2D" /> to get the computed inertia.</para>
    /// <para><code>
    /// private RigidBody2D _ball;
    /// public override void _Ready()
    /// {
    /// _ball = GetNode&lt;RigidBody2D&gt;("Ball");
    /// }
    /// private float GetBallInertia()
    /// {
    /// return 1.0f / PhysicsServer2D.BodyGetDirectState(_ball.GetRid()).InverseInertia;
    /// }
    /// </code></para>
    /// </summary>
    float Inertia { get; set; }
    /// <summary>
    /// <para>Damps the body's movement. By default, the body will use the <b>Default Linear Damp</b> in <b>Project &gt; Project Settings &gt; Physics &gt; 2d</b> or any value override set by an <see cref="Area2D" /> the body is in. Depending on <see cref="RigidBody2D.LinearDampMode" />, you can set <see cref="RigidBody2D.LinearDamp" /> to be added to or to replace the body's damping value.</para>
    /// <para>See <c>ProjectSettings.physics/2d/default_linear_damp</c> for more details about damping.</para>
    /// </summary>
    float LinearDamp { get; set; }
    /// <summary>
    /// <para>Defines how <see cref="RigidBody2D.LinearDamp" /> is applied. See <see cref="RigidBody2D.DampMode" /> for possible values.</para>
    /// </summary>
    RigidBody2D.DampMode LinearDampMode { get; set; }
    /// <summary>
    /// <para>The body's linear velocity in pixels per second. Can be used sporadically, but <b>don't set this every frame</b>, because physics may run in another thread and runs at a different granularity. Use <see cref="RigidBody2D._IntegrateForces(Godot.PhysicsDirectBodyState2D)" /> as your process loop for precise control of the body state.</para>
    /// </summary>
    Vector2 LinearVelocity { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the body cannot rotate. Gravity and forces only apply linear movement.</para>
    /// </summary>
    bool LockRotation { get; set; }
    /// <summary>
    /// <para>The body's mass.</para>
    /// </summary>
    float Mass { get; set; }
    /// <summary>
    /// <para>The maximum number of contacts that will be recorded. Requires a value greater than 0 and <see cref="RigidBody2D.ContactMonitor" /> to be set to <c>true</c> to start to register contacts. Use <see cref="RigidBody2D.GetContactCount" /> to retrieve the count or <see cref="RigidBody2D.GetCollidingBodies" /> to retrieve bodies that have been collided with.</para>
    /// <para><b>Note:</b> The number of contacts is different from the number of collisions. Collisions between parallel edges will result in two contacts (one at each end), and collisions between parallel faces will result in four contacts (one at each corner).</para>
    /// </summary>
    int MaxContactsReported { get; set; }
    /// <summary>
    /// <para>The physics material override for the body.</para>
    /// <para>If a material is assigned to this property, it will be used instead of any other physics material, such as an inherited one.</para>
    /// </summary>
    PhysicsMaterial PhysicsMaterialOverride { get; set; }
    /// <summary>
    /// <para>Sets the body's velocity on the given axis. The velocity in the given vector axis will be set as the given vector length. This is useful for jumping behavior.</para>
    /// </summary>
    void SetAxisVelocity(Vector2 axisVelocity);
    /// <summary>
    /// <para>If <c>true</c>, the body will not move and will not calculate forces until woken up by another body through, for example, a collision, or by using the <see cref="RigidBody2D.ApplyImpulse(Godot.Vector2,System.Nullable{Godot.Vector2})" /> or <see cref="RigidBody2D.ApplyForce(Godot.Vector2,System.Nullable{Godot.Vector2})" /> methods.</para>
    /// </summary>
    bool Sleeping { get; set; }

}