namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>Abstract base class for all joints in 2D physics. 2D joints bind together two physics bodies and apply a constraint.</para>
/// </summary>
public interface IJoint2D : INode2D {
    /// <summary>
    /// <para>When <see cref="Joint2D.NodeA" /> and <see cref="Joint2D.NodeB" /> move in different directions the <see cref="Joint2D.Bias" /> controls how fast the joint pulls them back to their original position. The lower the <see cref="Joint2D.Bias" /> the more the two bodies can pull on the joint.</para>
    /// <para>When set to <c>0</c>, the default value from <c>ProjectSettings.physics/2d/solver/default_constraint_bias</c> is used.</para>
    /// </summary>
    float Bias { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, <see cref="Joint2D.NodeA" /> and <see cref="Joint2D.NodeB" /> can not collide.</para>
    /// </summary>
    bool DisableCollision { get; set; }
    /// <summary>
    /// <para>Returns the joint's <see cref="Rid" />.</para>
    /// </summary>
    Rid GetRid();
    /// <summary>
    /// <para>The first body attached to the joint. Must derive from <see cref="PhysicsBody2D" />.</para>
    /// </summary>
    NodePath NodeA { get; set; }
    /// <summary>
    /// <para>The second body attached to the joint. Must derive from <see cref="PhysicsBody2D" />.</para>
    /// </summary>
    NodePath NodeB { get; set; }

}