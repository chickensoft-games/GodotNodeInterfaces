namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A node that provides a <see cref="Shape2D" /> to a <see cref="CollisionObject2D" /> parent and allows to edit it. This can give a detection shape to an <see cref="Area2D" /> or turn a <see cref="PhysicsBody2D" /> into a solid object.</para>
/// </summary>
public class CollisionShape2DAdapter : Node2DAdapter, ICollisionShape2D {
  private readonly CollisionShape2D _node;

  public CollisionShape2DAdapter(Node node) : base(node) {
    if (node is not CollisionShape2D typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a CollisionShape2D"
      );
    }
    _node = typedNode;
  }

    /// <summary>
    /// <para>The collision shape debug color.</para>
    /// <para><b>Note:</b> The default value is <c>ProjectSettings.debug/shapes/collision/shape_color</c>. The <c>Color(0, 0, 0, 1)</c> value documented here is a placeholder, and not the actual default debug color.</para>
    /// </summary>
    public Color DebugColor { get => _node.DebugColor; set => _node.DebugColor = value; }
    /// <summary>
    /// <para>A disabled collision shape has no effect in the world. This property should be changed with <see cref="GodotObject.SetDeferred(Godot.StringName,Godot.Variant)" />.</para>
    /// </summary>
    public bool Disabled { get => _node.Disabled; set => _node.Disabled = value; }
    /// <summary>
    /// <para>Sets whether this collision shape should only detect collision on one side (top or bottom).</para>
    /// <para><b>Note:</b> This property has no effect if this <see cref="CollisionShape2D" /> is a child of an <see cref="Area2D" /> node.</para>
    /// </summary>
    public bool OneWayCollision { get => _node.OneWayCollision; set => _node.OneWayCollision = value; }
    /// <summary>
    /// <para>The margin used for one-way collision (in pixels). Higher values will make the shape thicker, and work better for colliders that enter the shape at a high velocity.</para>
    /// </summary>
    public float OneWayCollisionMargin { get => _node.OneWayCollisionMargin; set => _node.OneWayCollisionMargin = value; }
    /// <summary>
    /// <para>The actual shape owned by this collision shape.</para>
    /// </summary>
    public Shape2D Shape { get => _node.Shape; set => _node.Shape = value; }

}