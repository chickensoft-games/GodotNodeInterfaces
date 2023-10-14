namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
using Godot.Collections;
/// <summary>
/// <para>Shape casting allows to detect collision objects by sweeping its <see cref="ShapeCast2D.Shape" /> along the cast direction determined by <see cref="ShapeCast2D.TargetPosition" />. This is similar to <see cref="RayCast2D" />, but it allows for sweeping a region of space, rather than just a straight line. <see cref="ShapeCast2D" /> can detect multiple collision objects. It is useful for things like wide laser beams or snapping a simple shape to a floor.</para>
/// <para>Immediate collision overlaps can be done with the <see cref="ShapeCast2D.TargetPosition" /> set to <c>Vector2(0, 0)</c> and by calling <see cref="ShapeCast2D.ForceShapecastUpdate" /> within the same physics frame. This helps to overcome some limitations of <see cref="Area2D" /> when used as an instantaneous detection area, as collision information isn't immediately available to it.</para>
/// <para><b>Note:</b> Shape casting is more computationally expensive than ray casting.</para>
/// </summary>
public class ShapeCast2DAdapter : Node2DAdapter, IShapeCast2D {
  private readonly ShapeCast2D _node;

  public ShapeCast2DAdapter(ShapeCast2D node) : base(node) { _node = node; }

    /// <summary>
    /// <para>Adds a collision exception so the shape does not report collisions with the specified <see cref="CollisionObject2D" /> node.</para>
    /// </summary>
    public void AddException(CollisionObject2D node) => _node.AddException(node);
    /// <summary>
    /// <para>Adds a collision exception so the shape does not report collisions with the specified <see cref="Rid" />.</para>
    /// </summary>
    public void AddExceptionRid(Rid rid) => _node.AddExceptionRid(rid);
    /// <summary>
    /// <para>Removes all collision exceptions for this shape.</para>
    /// </summary>
    public void ClearExceptions() => _node.ClearExceptions();
    /// <summary>
    /// <para>If <c>true</c>, collision with <see cref="Area2D" />s will be reported.</para>
    /// </summary>
    public bool CollideWithAreas { get => _node.CollideWithAreas; set => _node.CollideWithAreas = value; }
    /// <summary>
    /// <para>If <c>true</c>, collision with <see cref="PhysicsBody2D" />s will be reported.</para>
    /// </summary>
    public bool CollideWithBodies { get => _node.CollideWithBodies; set => _node.CollideWithBodies = value; }
    /// <summary>
    /// <para>The shape's collision mask. Only objects in at least one collision layer enabled in the mask will be detected.</para>
    /// </summary>
    public uint CollisionMask { get => _node.CollisionMask; set => _node.CollisionMask = value; }
    /// <summary>
    /// <para>Returns the complete collision information from the collision sweep. The data returned is the same as in the <see cref="PhysicsDirectSpaceState2D.GetRestInfo(Godot.PhysicsShapeQueryParameters2D)" /> method.</para>
    /// </summary>
    public Godot.Collections.Array CollisionResult { get => _node.CollisionResult; }
    /// <summary>
    /// <para>If <c>true</c>, collisions will be reported.</para>
    /// </summary>
    public bool Enabled { get => _node.Enabled; set => _node.Enabled = value; }
    /// <summary>
    /// <para>If <c>true</c>, the parent node will be excluded from collision detection.</para>
    /// </summary>
    public bool ExcludeParent { get => _node.ExcludeParent; set => _node.ExcludeParent = value; }
    /// <summary>
    /// <para>Updates the collision information for the shape. Use this method to update the collision information immediately instead of waiting for the next <c>_physics_process</c> call, for example if the shape or its parent has changed state.</para>
    /// <para><b>Note:</b> <c>enabled == true</c> is not required for this to work.</para>
    /// </summary>
    public void ForceShapecastUpdate() => _node.ForceShapecastUpdate();
    /// <summary>
    /// <para>The fraction from the <see cref="ShapeCast2D" />'s origin to its <see cref="ShapeCast2D.TargetPosition" /> (between 0 and 1) of how far the shape can move without triggering a collision.</para>
    /// </summary>
    public float GetClosestCollisionSafeFraction() => _node.GetClosestCollisionSafeFraction();
    /// <summary>
    /// <para>The fraction from the <see cref="ShapeCast2D" />'s origin to its <see cref="ShapeCast2D.TargetPosition" /> (between 0 and 1) of how far the shape must move to trigger a collision.</para>
    /// </summary>
    public float GetClosestCollisionUnsafeFraction() => _node.GetClosestCollisionUnsafeFraction();
    /// <summary>
    /// <para>Returns the collided <see cref="GodotObject" /> of one of the multiple collisions at <paramref name="index" />, or <c>null</c> if no object is intersecting the shape (i.e. <see cref="ShapeCast2D.IsColliding" /> returns <c>false</c>).</para>
    /// </summary>
    public GodotObject GetCollider(int index) => _node.GetCollider(index);
    /// <summary>
    /// <para>Returns the <see cref="Rid" /> of the collided object of one of the multiple collisions at <paramref name="index" />.</para>
    /// </summary>
    public Rid GetColliderRid(int index) => _node.GetColliderRid(index);
    /// <summary>
    /// <para>Returns the shape ID of the colliding shape of one of the multiple collisions at <paramref name="index" />, or <c>0</c> if no object is intersecting the shape (i.e. <see cref="ShapeCast2D.IsColliding" /> returns <c>false</c>).</para>
    /// </summary>
    public int GetColliderShape(int index) => _node.GetColliderShape(index);
    /// <summary>
    /// <para>The number of collisions detected at the point of impact. Use this to iterate over multiple collisions as provided by <see cref="ShapeCast2D.GetCollider(System.Int32)" />, <see cref="ShapeCast2D.GetColliderShape(System.Int32)" />, <see cref="ShapeCast2D.GetCollisionPoint(System.Int32)" />, and <see cref="ShapeCast2D.GetCollisionNormal(System.Int32)" /> methods.</para>
    /// </summary>
    public int GetCollisionCount() => _node.GetCollisionCount();
    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="ShapeCast2D.CollisionMask" /> is enabled, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    public bool GetCollisionMaskValue(int layerNumber) => _node.GetCollisionMaskValue(layerNumber);
    /// <summary>
    /// <para>Returns the normal of one of the multiple collisions at <paramref name="index" /> of the intersecting object.</para>
    /// </summary>
    public Vector2 GetCollisionNormal(int index) => _node.GetCollisionNormal(index);
    /// <summary>
    /// <para>Returns the collision point of one of the multiple collisions at <paramref name="index" /> where the shape intersects the colliding object.</para>
    /// <para><b>Note:</b> this point is in the <b>global</b> coordinate system.</para>
    /// </summary>
    public Vector2 GetCollisionPoint(int index) => _node.GetCollisionPoint(index);
    /// <summary>
    /// <para>Returns whether any object is intersecting with the shape's vector (considering the vector length).</para>
    /// </summary>
    public bool IsColliding() => _node.IsColliding();
    /// <summary>
    /// <para>The collision margin for the shape. A larger margin helps detecting collisions more consistently, at the cost of precision.</para>
    /// </summary>
    public float Margin { get => _node.Margin; set => _node.Margin = value; }
    /// <summary>
    /// <para>The number of intersections can be limited with this parameter, to reduce the processing time.</para>
    /// </summary>
    public int MaxResults { get => _node.MaxResults; set => _node.MaxResults = value; }
    /// <summary>
    /// <para>Removes a collision exception so the shape does report collisions with the specified <see cref="CollisionObject2D" /> node.</para>
    /// </summary>
    public void RemoveException(CollisionObject2D node) => _node.RemoveException(node);
    /// <summary>
    /// <para>Removes a collision exception so the shape does report collisions with the specified <see cref="Rid" />.</para>
    /// </summary>
    public void RemoveExceptionRid(Rid rid) => _node.RemoveExceptionRid(rid);
    /// <summary>
    /// <para>Based on <paramref name="value" />, enables or disables the specified layer in the <see cref="ShapeCast2D.CollisionMask" />, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    public void SetCollisionMaskValue(int layerNumber, bool value) => _node.SetCollisionMaskValue(layerNumber, value);
    /// <summary>
    /// <para>The <see cref="Shape2D" />-derived shape to be used for collision queries.</para>
    /// </summary>
    public Shape2D Shape { get => _node.Shape; set => _node.Shape = value; }
    /// <summary>
    /// <para>The shape's destination point, relative to this node's <c>position</c>.</para>
    /// </summary>
    public Vector2 TargetPosition { get => _node.TargetPosition; set => _node.TargetPosition = value; }

}