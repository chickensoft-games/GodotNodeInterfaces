namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>Abstract base class for all joints in 3D physics. 3D joints bind together two physics bodies and apply a constraint.</para>
/// </summary>
public interface IJoint3D : INode3D {
    /// <summary>
    /// <para>If <c>true</c>, the two bodies of the nodes are not able to collide with each other.</para>
    /// </summary>
    bool ExcludeNodesFromCollision { get; set; }
    /// <summary>
    /// <para>Returns the joint's <see cref="Rid" />.</para>
    /// </summary>
    Rid GetRid();
    /// <summary>
    /// <para>The node attached to the first side (A) of the joint.</para>
    /// </summary>
    NodePath NodeA { get; set; }
    /// <summary>
    /// <para>The node attached to the second side (B) of the joint.</para>
    /// </summary>
    NodePath NodeB { get; set; }
    /// <summary>
    /// <para>The priority used to define which solver is executed first for multiple joints. The lower the value, the higher the priority.</para>
    /// </summary>
    int SolverPriority { get; set; }

}