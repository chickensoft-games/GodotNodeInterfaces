namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class CollisionShape2DNode : CollisionShape2D, ICollisionShape2D { }

/// <summary>
/// <para>A node that provides a <see cref="Shape2D" /> to a <see cref="CollisionObject2D" /> parent and allows to edit it. This can give a detection shape to an <see cref="Area2D" /> or turn a <see cref="PhysicsBody2D" /> into a solid object.</para>
/// </summary>
public interface ICollisionShape2D : INode2D {
    /// <summary>
    /// <para>The collision shape debug color.</para>
    /// <para><b>Note:</b> The default value is <c>ProjectSettings.debug/shapes/collision/shape_color</c>. The <c>Color(0, 0, 0, 1)</c> value documented here is a placeholder, and not the actual default debug color.</para>
    /// </summary>
    Color DebugColor { get; set; }
    /// <summary>
    /// <para>A disabled collision shape has no effect in the world. This property should be changed with <see cref="GodotObject.SetDeferred(Godot.StringName,Godot.Variant)" />.</para>
    /// </summary>
    bool Disabled { get; set; }
    /// <summary>
    /// <para>Sets whether this collision shape should only detect collision on one side (top or bottom).</para>
    /// <para><b>Note:</b> This property has no effect if this <see cref="CollisionShape2D" /> is a child of an <see cref="Area2D" /> node.</para>
    /// </summary>
    bool OneWayCollision { get; set; }
    /// <summary>
    /// <para>The margin used for one-way collision (in pixels). Higher values will make the shape thicker, and work better for colliders that enter the shape at a high velocity.</para>
    /// </summary>
    float OneWayCollisionMargin { get; set; }
    /// <summary>
    /// <para>The actual shape owned by this collision shape.</para>
    /// </summary>
    Shape2D Shape { get; set; }

}