 namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A node that provides a <see cref="Shape3D" /> to a <see cref="CollisionObject3D" /> parent and allows to edit it. This can give a detection shape to an <see cref="Area3D" /> or turn a <see cref="PhysicsBody3D" /> into a solid object.</para>
/// <para><b>Warning:</b> A non-uniformly scaled <see cref="CollisionShape3D" /> will likely not behave as expected. Make sure to keep its scale the same on all axes and adjust its <see cref="CollisionShape3D.Shape" /> resource instead.</para>
/// </summary>
public class CollisionShape3DAdapter : CollisionShape3D, ICollisionShape3D {
  private readonly CollisionShape3D _node;

  public CollisionShape3DAdapter(CollisionShape3D node) => _node = node;
    /// <summary>
    /// <para>A disabled collision shape has no effect in the world.</para>
    /// </summary>
    public bool Disabled { get => _node.Disabled; set => _node.Disabled = value; }
    /// <summary>
    /// <para>Sets the collision shape's shape to the addition of all its convexed <see cref="MeshInstance3D" /> siblings geometry.</para>
    /// </summary>
    public void MakeConvexFromSiblings() => _node.MakeConvexFromSiblings();
    /// <summary>
    /// <para><i>Obsoleted.</i> Use <see cref="Resource.Changed" /> instead.</para>
    /// </summary>
    public void ResourceChanged(Resource resource) => _node.ResourceChanged(resource);
    /// <summary>
    /// <para>The actual shape owned by this collision shape.</para>
    /// </summary>
    public Shape3D Shape { get => _node.Shape; set => _node.Shape = value; }

}