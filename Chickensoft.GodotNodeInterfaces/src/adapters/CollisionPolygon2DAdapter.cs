 namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A node that provides a thickened polygon shape (a prism) to a <see cref="CollisionObject2D" /> parent and allows to edit it. The polygon can be concave or convex. This can give a detection shape to an <see cref="Area2D" /> or turn <see cref="PhysicsBody2D" /> into a solid object.</para>
/// <para><b>Warning:</b> A non-uniformly scaled <see cref="CollisionShape2D" /> will likely not behave as expected. Make sure to keep its scale the same on all axes and adjust its shape resource instead.</para>
/// </summary>
public class CollisionPolygon2DAdapter : CollisionPolygon2D, ICollisionPolygon2D {
  private readonly CollisionPolygon2D _node;

  public CollisionPolygon2DAdapter(CollisionPolygon2D node) => _node = node;
    /// <summary>
    /// <para>Collision build mode. Use one of the <see cref="CollisionPolygon2D.BuildModeEnum" /> constants.</para>
    /// </summary>
    public CollisionPolygon2D.BuildModeEnum BuildMode { get => _node.BuildMode; set => _node.BuildMode = value; }
    /// <summary>
    /// <para>If <c>true</c>, no collisions will be detected.</para>
    /// </summary>
    public bool Disabled { get => _node.Disabled; set => _node.Disabled = value; }
    /// <summary>
    /// <para>If <c>true</c>, only edges that face up, relative to <see cref="CollisionPolygon2D" />'s rotation, will collide with other objects.</para>
    /// <para><b>Note:</b> This property has no effect if this <see cref="CollisionPolygon2D" /> is a child of an <see cref="Area2D" /> node.</para>
    /// </summary>
    public bool OneWayCollision { get => _node.OneWayCollision; set => _node.OneWayCollision = value; }
    /// <summary>
    /// <para>The margin used for one-way collision (in pixels). Higher values will make the shape thicker, and work better for colliders that enter the polygon at a high velocity.</para>
    /// </summary>
    public float OneWayCollisionMargin { get => _node.OneWayCollisionMargin; set => _node.OneWayCollisionMargin = value; }
    /// <summary>
    /// <para>The polygon's list of vertices. Each point will be connected to the next, and the final point will be connected to the first.</para>
    /// <para><b>Warning:</b> The returned value is a clone of the <see cref="Vector2" />[], not a reference.</para>
    /// </summary>
    public Vector2[] Polygon { get => _node.Polygon; set => _node.Polygon = value; }

}