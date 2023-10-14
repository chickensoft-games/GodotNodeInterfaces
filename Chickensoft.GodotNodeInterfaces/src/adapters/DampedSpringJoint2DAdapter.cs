namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A physics joint that connects two 2D physics bodies with a spring-like force. This resembles a spring that always wants to stretch to a given length.</para>
/// </summary>
public class DampedSpringJoint2DAdapter : DampedSpringJoint2D, IDampedSpringJoint2D {
  private readonly DampedSpringJoint2D _node;

  public DampedSpringJoint2DAdapter(DampedSpringJoint2D node) => _node = node;
    /// <summary>
    /// <para>The spring joint's damping ratio. A value between <c>0</c> and <c>1</c>. When the two bodies move into different directions the system tries to align them to the spring axis again. A high <see cref="DampedSpringJoint2D.Damping" /> value forces the attached bodies to align faster.</para>
    /// </summary>
    public float Damping { get => _node.Damping; set => _node.Damping = value; }
    /// <summary>
    /// <para>The spring joint's maximum length. The two attached bodies cannot stretch it past this value.</para>
    /// </summary>
    public float Length { get => _node.Length; set => _node.Length = value; }
    /// <summary>
    /// <para>When the bodies attached to the spring joint move they stretch or squash it. The joint always tries to resize towards this length.</para>
    /// </summary>
    public float RestLength { get => _node.RestLength; set => _node.RestLength = value; }
    /// <summary>
    /// <para>The higher the value, the less the bodies attached to the joint will deform it. The joint applies an opposing force to the bodies, the product of the stiffness multiplied by the size difference from its resting length.</para>
    /// </summary>
    public float Stiffness { get => _node.Stiffness; set => _node.Stiffness = value; }

}