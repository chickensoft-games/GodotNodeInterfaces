 namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A physics joint that restricts the movement of two 2D physics bodies to a fixed axis. For example, a <see cref="StaticBody2D" /> representing a piston base can be attached to a <see cref="RigidBody2D" /> representing the piston head, moving up and down.</para>
/// </summary>
public class GrooveJoint2DAdapter : GrooveJoint2D, IGrooveJoint2D {
  private readonly GrooveJoint2D _node;

  public GrooveJoint2DAdapter(GrooveJoint2D node) => _node = node;
    /// <summary>
    /// <para>The body B's initial anchor position defined by the joint's origin and a local offset <see cref="GrooveJoint2D.InitialOffset" /> along the joint's Y axis (along the groove).</para>
    /// </summary>
    public float InitialOffset { get => _node.InitialOffset; set => _node.InitialOffset = value; }
    /// <summary>
    /// <para>The groove's length. The groove is from the joint's origin towards <see cref="GrooveJoint2D.Length" /> along the joint's local Y axis.</para>
    /// </summary>
    public float Length { get => _node.Length; set => _node.Length = value; }

}