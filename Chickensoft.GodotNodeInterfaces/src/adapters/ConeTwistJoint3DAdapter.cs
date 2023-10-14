namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A physics joint that connects two 3D physics bodies in a way that simulates a ball-and-socket joint. The twist axis is initiated as the X axis of the <see cref="ConeTwistJoint3D" />. Once the physics bodies swing, the twist axis is calculated as the middle of the X axes of the joint in the local space of the two physics bodies. Useful for limbs like shoulders and hips, lamps hanging off a ceiling, etc.</para>
/// </summary>
public class ConeTwistJoint3DAdapter : Joint3DAdapter, IConeTwistJoint3D {
  private readonly ConeTwistJoint3D _node;

  public ConeTwistJoint3DAdapter(ConeTwistJoint3D node) : base(node) { _node = node; }

    /// <summary>
    /// <para>The speed with which the swing or twist will take place.</para>
    /// <para>The higher, the faster.</para>
    /// </summary>
    public float Bias { get => _node.Bias; set => _node.Bias = value; }
    /// <summary>
    /// <para>Defines, how fast the swing- and twist-speed-difference on both sides gets synced.</para>
    /// </summary>
    public float Relaxation { get => _node.Relaxation; set => _node.Relaxation = value; }
    /// <summary>
    /// <para>The ease with which the joint starts to twist. If it's too low, it takes more force to start twisting the joint.</para>
    /// </summary>
    public float Softness { get => _node.Softness; set => _node.Softness = value; }
    /// <summary>
    /// <para>Swing is rotation from side to side, around the axis perpendicular to the twist axis.</para>
    /// <para>The swing span defines, how much rotation will not get corrected along the swing axis.</para>
    /// <para>Could be defined as looseness in the <see cref="ConeTwistJoint3D" />.</para>
    /// <para>If below 0.05, this behavior is locked.</para>
    /// </summary>
    public float SwingSpan { get => _node.SwingSpan; set => _node.SwingSpan = value; }
    /// <summary>
    /// <para>Twist is the rotation around the twist axis, this value defined how far the joint can twist.</para>
    /// <para>Twist is locked if below 0.05.</para>
    /// </summary>
    public float TwistSpan { get => _node.TwistSpan; set => _node.TwistSpan = value; }

}