namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class CollisionShape3DNode : CollisionShape3D, ICollisionShape3D { }

/// <summary>
/// <para>A node that provides a <see cref="Shape3D" /> to a <see cref="CollisionObject3D" /> parent and allows to edit it. This can give a detection shape to an <see cref="Area3D" /> or turn a <see cref="PhysicsBody3D" /> into a solid object.</para>
/// <para><b>Warning:</b> A non-uniformly scaled <see cref="CollisionShape3D" /> will likely not behave as expected. Make sure to keep its scale the same on all axes and adjust its <see cref="CollisionShape3D.Shape" /> resource instead.</para>
/// </summary>
public interface ICollisionShape3D : INode3D {
    /// <summary>
    /// <para>A disabled collision shape has no effect in the world.</para>
    /// </summary>
    bool Disabled { get; set; }
    /// <summary>
    /// <para>Sets the collision shape's shape to the addition of all its convexed <see cref="MeshInstance3D" /> siblings geometry.</para>
    /// </summary>
    void MakeConvexFromSiblings();
    /// <summary>
    /// <para><i>Obsoleted.</i> Use <see cref="Resource.Changed" /> instead.</para>
    /// </summary>
    void ResourceChanged(Resource resource);
    /// <summary>
    /// <para>The actual shape owned by this collision shape.</para>
    /// </summary>
    Shape3D Shape { get; set; }

}