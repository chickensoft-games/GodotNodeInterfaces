namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A node that provides a thickened polygon shape (a prism) to a <see cref="CollisionObject3D" /> parent and allows to edit it. The polygon can be concave or convex. This can give a detection shape to an <see cref="Area3D" /> or turn <see cref="PhysicsBody3D" /> into a solid object.</para>
/// <para><b>Warning:</b> A non-uniformly scaled <see cref="CollisionShape3D" /> will likely not behave as expected. Make sure to keep its scale the same on all axes and adjust its shape resource instead.</para>
/// </summary>
public class CollisionPolygon3DAdapter : Node3DAdapter, ICollisionPolygon3D {
  private readonly CollisionPolygon3D _node;

  public CollisionPolygon3DAdapter(CollisionPolygon3D node) : base(node) { _node = node; }

    /// <summary>
    /// <para>Length that the resulting collision extends in either direction perpendicular to its 2D polygon.</para>
    /// </summary>
    public float Depth { get => _node.Depth; set => _node.Depth = value; }
    /// <summary>
    /// <para>If <c>true</c>, no collision will be produced.</para>
    /// </summary>
    public bool Disabled { get => _node.Disabled; set => _node.Disabled = value; }
    /// <summary>
    /// <para>The collision margin for the generated <see cref="Shape3D" />. See <see cref="Shape3D.Margin" /> for more details.</para>
    /// </summary>
    public float Margin { get => _node.Margin; set => _node.Margin = value; }
    /// <summary>
    /// <para>Array of vertices which define the 2D polygon in the local XY plane.</para>
    /// <para><b>Note:</b> The returned value is a copy of the original. Methods which mutate the size or properties of the return value will not impact the original polygon. To change properties of the polygon, assign it to a temporary variable and make changes before reassigning the class property.</para>
    /// </summary>
    public Vector2[] Polygon { get => _node.Polygon; set => _node.Polygon = value; }

}