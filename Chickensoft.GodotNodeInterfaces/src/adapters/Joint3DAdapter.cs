namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>Abstract base class for all joints in 3D physics. 3D joints bind together two physics bodies and apply a constraint.</para>
/// </summary>
public class Joint3DAdapter : Node3DAdapter, IJoint3D {
  private readonly Joint3D _node;

  public Joint3DAdapter(Joint3D node) : base(node) { _node = node; }

    /// <summary>
    /// <para>If <c>true</c>, the two bodies of the nodes are not able to collide with each other.</para>
    /// </summary>
    public bool ExcludeNodesFromCollision { get => _node.ExcludeNodesFromCollision; set => _node.ExcludeNodesFromCollision = value; }
    /// <summary>
    /// <para>Returns the joint's <see cref="Rid" />.</para>
    /// </summary>
    public Rid GetRid() => _node.GetRid();
    /// <summary>
    /// <para>The node attached to the first side (A) of the joint.</para>
    /// </summary>
    public NodePath NodeA { get => _node.NodeA; set => _node.NodeA = value; }
    /// <summary>
    /// <para>The node attached to the second side (B) of the joint.</para>
    /// </summary>
    public NodePath NodeB { get => _node.NodeB; set => _node.NodeB = value; }
    /// <summary>
    /// <para>The priority used to define which solver is executed first for multiple joints. The lower the value, the higher the priority.</para>
    /// </summary>
    public int SolverPriority { get => _node.SolverPriority; set => _node.SolverPriority = value; }

}