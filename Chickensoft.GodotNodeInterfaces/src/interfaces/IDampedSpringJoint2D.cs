namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>A physics joint that connects two 2D physics bodies with a spring-like force. This resembles a spring that always wants to stretch to a given length.</para>
/// </summary>
public interface IDampedSpringJoint2D : IJoint2D {
    /// <summary>
    /// <para>The spring joint's maximum length. The two attached bodies cannot stretch it past this value.</para>
    /// </summary>
    float Length { get; set; }
    /// <summary>
    /// <para>When the bodies attached to the spring joint move they stretch or squash it. The joint always tries to resize towards this length.</para>
    /// </summary>
    float RestLength { get; set; }
    /// <summary>
    /// <para>The higher the value, the less the bodies attached to the joint will deform it. The joint applies an opposing force to the bodies, the product of the stiffness multiplied by the size difference from its resting length.</para>
    /// </summary>
    float Stiffness { get; set; }
    /// <summary>
    /// <para>The spring joint's damping ratio. A value between <c>0</c> and <c>1</c>. When the two bodies move into different directions the system tries to align them to the spring axis again. A high <see cref="DampedSpringJoint2D.Damping" /> value forces the attached bodies to align faster.</para>
    /// </summary>
    float Damping { get; set; }

}