 namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A physics joint that attaches two 2D physics bodies at a single point, allowing them to freely rotate. For example, a <see cref="RigidBody2D" /> can be attached to a <see cref="StaticBody2D" /> to create a pendulum or a seesaw.</para>
/// </summary>
public class PinJoint2DAdapter : PinJoint2D, IPinJoint2D {
  private readonly PinJoint2D _node;

  public PinJoint2DAdapter(PinJoint2D node) => _node = node;
    /// <summary>
    /// <para>If <c>true</c>, the pin maximum and minimum rotation, defined by <see cref="PinJoint2D.AngularLimitLower" /> and <see cref="PinJoint2D.AngularLimitUpper" /> are applied.</para>
    /// </summary>
    public bool AngularLimitEnabled { get => _node.AngularLimitEnabled; set => _node.AngularLimitEnabled = value; }
    /// <summary>
    /// <para>The minimum rotation. Only active if <see cref="PinJoint2D.AngularLimitEnabled" /> is <c>true</c>.</para>
    /// </summary>
    public float AngularLimitLower { get => _node.AngularLimitLower; set => _node.AngularLimitLower = value; }
    /// <summary>
    /// <para>The maximum rotation. Only active if <see cref="PinJoint2D.AngularLimitEnabled" /> is <c>true</c>.</para>
    /// </summary>
    public float AngularLimitUpper { get => _node.AngularLimitUpper; set => _node.AngularLimitUpper = value; }
    /// <summary>
    /// <para>When activated, a motor turns the pin.</para>
    /// </summary>
    public bool MotorEnabled { get => _node.MotorEnabled; set => _node.MotorEnabled = value; }
    /// <summary>
    /// <para>Target speed for the motor. In radians per second.</para>
    /// </summary>
    public float MotorTargetVelocity { get => _node.MotorTargetVelocity; set => _node.MotorTargetVelocity = value; }
    /// <summary>
    /// <para>The higher this value, the more the bond to the pinned partner can flex.</para>
    /// </summary>
    public float Softness { get => _node.Softness; set => _node.Softness = value; }

}