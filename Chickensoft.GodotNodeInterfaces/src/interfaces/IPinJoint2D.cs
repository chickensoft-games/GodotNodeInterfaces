namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class PinJoint2DNode : PinJoint2D, IPinJoint2D { }

/// <summary>
/// <para>A physics joint that attaches two 2D physics bodies at a single point, allowing them to freely rotate. For example, a <see cref="RigidBody2D" /> can be attached to a <see cref="StaticBody2D" /> to create a pendulum or a seesaw.</para>
/// </summary>
public interface IPinJoint2D : IJoint2D {
    /// <summary>
    /// <para>If <c>true</c>, the pin maximum and minimum rotation, defined by <see cref="PinJoint2D.AngularLimitLower" /> and <see cref="PinJoint2D.AngularLimitUpper" /> are applied.</para>
    /// </summary>
    bool AngularLimitEnabled { get; set; }
    /// <summary>
    /// <para>The minimum rotation. Only active if <see cref="PinJoint2D.AngularLimitEnabled" /> is <c>true</c>.</para>
    /// </summary>
    float AngularLimitLower { get; set; }
    /// <summary>
    /// <para>The maximum rotation. Only active if <see cref="PinJoint2D.AngularLimitEnabled" /> is <c>true</c>.</para>
    /// </summary>
    float AngularLimitUpper { get; set; }
    /// <summary>
    /// <para>When activated, a motor turns the pin.</para>
    /// </summary>
    bool MotorEnabled { get; set; }
    /// <summary>
    /// <para>Target speed for the motor. In radians per second.</para>
    /// </summary>
    float MotorTargetVelocity { get; set; }
    /// <summary>
    /// <para>The higher this value, the more the bond to the pinned partner can flex.</para>
    /// </summary>
    float Softness { get; set; }

}