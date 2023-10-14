namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class GrooveJoint2DNode : GrooveJoint2D, IGrooveJoint2D { }

/// <summary>
/// <para>A physics joint that restricts the movement of two 2D physics bodies to a fixed axis. For example, a <see cref="StaticBody2D" /> representing a piston base can be attached to a <see cref="RigidBody2D" /> representing the piston head, moving up and down.</para>
/// </summary>
public interface IGrooveJoint2D : IJoint2D {
    /// <summary>
    /// <para>The body B's initial anchor position defined by the joint's origin and a local offset <see cref="GrooveJoint2D.InitialOffset" /> along the joint's Y axis (along the groove).</para>
    /// </summary>
    float InitialOffset { get; set; }
    /// <summary>
    /// <para>The groove's length. The groove is from the joint's origin towards <see cref="GrooveJoint2D.Length" /> along the joint's local Y axis.</para>
    /// </summary>
    float Length { get; set; }

}