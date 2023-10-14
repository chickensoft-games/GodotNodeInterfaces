namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>Abstract base class for all joints in 2D physics. 2D joints bind together two physics bodies and apply a constraint.</para>
/// </summary>
public class Joint2DAdapter : Node2DAdapter, IJoint2D {
  private readonly Joint2D _node;

  public Joint2DAdapter(Joint2D node) : base(node) { _node = node; }

    /// <summary>
    /// <para>When <see cref="Joint2D.NodeA" /> and <see cref="Joint2D.NodeB" /> move in different directions the <see cref="Joint2D.Bias" /> controls how fast the joint pulls them back to their original position. The lower the <see cref="Joint2D.Bias" /> the more the two bodies can pull on the joint.</para>
    /// <para>When set to <c>0</c>, the default value from <c>ProjectSettings.physics/2d/solver/default_constraint_bias</c> is used.</para>
    /// </summary>
    public float Bias { get => _node.Bias; set => _node.Bias = value; }
    /// <summary>
    /// <para>If <c>true</c>, <see cref="Joint2D.NodeA" /> and <see cref="Joint2D.NodeB" /> can not collide.</para>
    /// </summary>
    public bool DisableCollision { get => _node.DisableCollision; set => _node.DisableCollision = value; }
    /// <summary>
    /// <para>Returns the joint's <see cref="Rid" />.</para>
    /// </summary>
    public Rid GetRid() => _node.GetRid();
    /// <summary>
    /// <para>The first body attached to the joint. Must derive from <see cref="PhysicsBody2D" />.</para>
    /// </summary>
    public NodePath NodeA { get => _node.NodeA; set => _node.NodeA = value; }
    /// <summary>
    /// <para>The second body attached to the joint. Must derive from <see cref="PhysicsBody2D" />.</para>
    /// </summary>
    public NodePath NodeB { get => _node.NodeB; set => _node.NodeB = value; }

}