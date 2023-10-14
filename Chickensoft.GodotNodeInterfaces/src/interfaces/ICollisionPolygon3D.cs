namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class CollisionPolygon3DNode : CollisionPolygon3D, ICollisionPolygon3D { }

/// <summary>
/// <para>A node that provides a thickened polygon shape (a prism) to a <see cref="CollisionObject3D" /> parent and allows to edit it. The polygon can be concave or convex. This can give a detection shape to an <see cref="Area3D" /> or turn <see cref="PhysicsBody3D" /> into a solid object.</para>
/// <para><b>Warning:</b> A non-uniformly scaled <see cref="CollisionShape3D" /> will likely not behave as expected. Make sure to keep its scale the same on all axes and adjust its shape resource instead.</para>
/// </summary>
public interface ICollisionPolygon3D : INode3D {
    /// <summary>
    /// <para>Length that the resulting collision extends in either direction perpendicular to its 2D polygon.</para>
    /// </summary>
    float Depth { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, no collision will be produced.</para>
    /// </summary>
    bool Disabled { get; set; }
    /// <summary>
    /// <para>The collision margin for the generated <see cref="Shape3D" />. See <see cref="Shape3D.Margin" /> for more details.</para>
    /// </summary>
    float Margin { get; set; }
    /// <summary>
    /// <para>Array of vertices which define the 2D polygon in the local XY plane.</para>
    /// <para><b>Note:</b> The returned value is a copy of the original. Methods which mutate the size or properties of the return value will not impact the original polygon. To change properties of the polygon, assign it to a temporary variable and make changes before reassigning the class property.</para>
    /// </summary>
    Vector2[] Polygon { get; set; }

}