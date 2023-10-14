namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>The <see cref="PhysicalBone3D" /> node is a physics body that can be used to make bones in a <see cref="Skeleton3D" /> react to physics.</para>
/// </summary>
public class PhysicalBone3DAdapter : PhysicsBody3DAdapter, IPhysicalBone3D {
  private readonly PhysicalBone3D _node;

  public PhysicalBone3DAdapter(PhysicalBone3D node) : base(node) { _node = node; }

    /// <summary>
    /// <para>Called during physics processing, allowing you to read and safely modify the simulation state for the object. By default, it works in addition to the usual physics behavior, but the <see cref="PhysicalBone3D.CustomIntegrator" /> property allows you to disable the default behavior and do fully custom force integration for a body.</para>
    /// </summary>
    public void _IntegrateForces(PhysicsDirectBodyState3D state) => _node._IntegrateForces(state);
    /// <summary>
    /// <para>Damps the body's rotation. By default, the body will use the <b>Default Angular Damp</b> in <b>Project &gt; Project Settings &gt; Physics &gt; 3d</b> or any value override set by an <see cref="Area3D" /> the body is in. Depending on <see cref="PhysicalBone3D.AngularDampMode" />, you can set <see cref="PhysicalBone3D.AngularDamp" /> to be added to or to replace the body's damping value.</para>
    /// <para>See <c>ProjectSettings.physics/3d/default_angular_damp</c> for more details about damping.</para>
    /// </summary>
    public float AngularDamp { get => _node.AngularDamp; set => _node.AngularDamp = value; }
    /// <summary>
    /// <para>Defines how <see cref="PhysicalBone3D.AngularDamp" /> is applied. See <see cref="PhysicalBone3D.DampMode" /> for possible values.</para>
    /// </summary>
    public PhysicalBone3D.DampMode AngularDampMode { get => _node.AngularDampMode; set => _node.AngularDampMode = value; }
    /// <summary>
    /// <para>The PhysicalBone3D's rotational velocity in <i>radians</i> per second.</para>
    /// </summary>
    public Vector3 AngularVelocity { get => _node.AngularVelocity; set => _node.AngularVelocity = value; }

    public void ApplyCentralImpulse(Vector3 impulse) => _node.ApplyCentralImpulse(impulse);
    /// <param name="position">If the parameter is null, then the default value is <c>new Vector3(0, 0, 0)</c>.</param>
    public void ApplyImpulse(Vector3 impulse, Nullable<Vector3> position) => _node.ApplyImpulse(impulse, position);
    /// <summary>
    /// <para>Sets the body's transform.</para>
    /// </summary>
    public Transform3D BodyOffset { get => _node.BodyOffset; set => _node.BodyOffset = value; }
    /// <summary>
    /// <para>The body's bounciness. Values range from <c>0</c> (no bounce) to <c>1</c> (full bounciness).</para>
    /// </summary>
    public float Bounce { get => _node.Bounce; set => _node.Bounce = value; }
    /// <summary>
    /// <para>If <c>true</c>, the body is deactivated when there is no movement, so it will not take part in the simulation until it is awakened by an external force.</para>
    /// </summary>
    public bool CanSleep { get => _node.CanSleep; set => _node.CanSleep = value; }
    /// <summary>
    /// <para>If <c>true</c>, internal force integration will be disabled (like gravity or air friction) for this body. Other than collision response, the body will only move as determined by the <see cref="PhysicalBone3D._IntegrateForces(Godot.PhysicsDirectBodyState3D)" /> function, if defined.</para>
    /// </summary>
    public bool CustomIntegrator { get => _node.CustomIntegrator; set => _node.CustomIntegrator = value; }
    /// <summary>
    /// <para>The body's friction, from <c>0</c> (frictionless) to <c>1</c> (max friction).</para>
    /// </summary>
    public float Friction { get => _node.Friction; set => _node.Friction = value; }

    public int GetBoneId() => _node.GetBoneId();

    public bool GetSimulatePhysics() => _node.GetSimulatePhysics();
    /// <summary>
    /// <para>This is multiplied by the global 3D gravity setting found in <b>Project &gt; Project Settings &gt; Physics &gt; 3d</b> to produce the body's gravity. For example, a value of 1 will be normal gravity, 2 will apply double gravity, and 0.5 will apply half gravity to this object.</para>
    /// </summary>
    public float GravityScale { get => _node.GravityScale; set => _node.GravityScale = value; }

    public bool IsSimulatingPhysics() => _node.IsSimulatingPhysics();
    /// <summary>
    /// <para>Sets the joint's transform.</para>
    /// </summary>
    public Transform3D JointOffset { get => _node.JointOffset; set => _node.JointOffset = value; }
    /// <summary>
    /// <para>Sets the joint's rotation in radians.</para>
    /// </summary>
    public Vector3 JointRotation { get => _node.JointRotation; set => _node.JointRotation = value; }
    /// <summary>
    /// <para>Sets the joint type. See <see cref="PhysicalBone3D.JointTypeEnum" /> for possible values.</para>
    /// </summary>
    public PhysicalBone3D.JointTypeEnum JointType { get => _node.JointType; set => _node.JointType = value; }
    /// <summary>
    /// <para>Damps the body's movement. By default, the body will use the <b>Default Linear Damp</b> in <b>Project &gt; Project Settings &gt; Physics &gt; 3d</b> or any value override set by an <see cref="Area3D" /> the body is in. Depending on <see cref="PhysicalBone3D.LinearDampMode" />, you can set <see cref="PhysicalBone3D.LinearDamp" /> to be added to or to replace the body's damping value.</para>
    /// <para>See <c>ProjectSettings.physics/3d/default_linear_damp</c> for more details about damping.</para>
    /// </summary>
    public float LinearDamp { get => _node.LinearDamp; set => _node.LinearDamp = value; }
    /// <summary>
    /// <para>Defines how <see cref="PhysicalBone3D.LinearDamp" /> is applied. See <see cref="PhysicalBone3D.DampMode" /> for possible values.</para>
    /// </summary>
    public PhysicalBone3D.DampMode LinearDampMode { get => _node.LinearDampMode; set => _node.LinearDampMode = value; }
    /// <summary>
    /// <para>The body's linear velocity in units per second. Can be used sporadically, but <b>don't set this every frame</b>, because physics may run in another thread and runs at a different granularity. Use <see cref="PhysicalBone3D._IntegrateForces(Godot.PhysicsDirectBodyState3D)" /> as your process loop for precise control of the body state.</para>
    /// </summary>
    public Vector3 LinearVelocity { get => _node.LinearVelocity; set => _node.LinearVelocity = value; }
    /// <summary>
    /// <para>The body's mass.</para>
    /// </summary>
    public float Mass { get => _node.Mass; set => _node.Mass = value; }

}