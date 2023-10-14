namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A raycast represents a ray from its origin to its <see cref="RayCast2D.TargetPosition" /> that finds the closest <see cref="CollisionObject2D" /> along its path, if it intersects any. This is useful for a lot of things, such as</para>
/// <para><see cref="RayCast2D" /> can ignore some objects by adding them to an exception list, by making its detection reporting ignore <see cref="Area2D" />s (<see cref="RayCast2D.CollideWithAreas" />) or <see cref="PhysicsBody2D" />s (<see cref="RayCast2D.CollideWithBodies" />), or by configuring physics layers.</para>
/// <para><see cref="RayCast2D" /> calculates intersection every physics frame, and it holds the result until the next physics frame. For an immediate raycast, or if you want to configure a <see cref="RayCast2D" /> multiple times within the same physics frame, use <see cref="RayCast2D.ForceRaycastUpdate" />.</para>
/// <para>To sweep over a region of 2D space, you can approximate the region with multiple <see cref="RayCast2D" />s or use <see cref="ShapeCast2D" />.</para>
/// </summary>
public class RayCast2DAdapter : Node2DAdapter, IRayCast2D {
  private readonly RayCast2D _node;

  public RayCast2DAdapter(RayCast2D node) : base(node) { _node = node; }

    /// <summary>
    /// <para>Adds a collision exception so the ray does not report collisions with the specified <see cref="CollisionObject2D" /> node.</para>
    /// </summary>
    public void AddException(CollisionObject2D node) => _node.AddException(node);
    /// <summary>
    /// <para>Adds a collision exception so the ray does not report collisions with the specified <see cref="Rid" />.</para>
    /// </summary>
    public void AddExceptionRid(Rid rid) => _node.AddExceptionRid(rid);
    /// <summary>
    /// <para>Removes all collision exceptions for this ray.</para>
    /// </summary>
    public void ClearExceptions() => _node.ClearExceptions();
    /// <summary>
    /// <para>If <c>true</c>, collisions with <see cref="Area2D" />s will be reported.</para>
    /// </summary>
    public bool CollideWithAreas { get => _node.CollideWithAreas; set => _node.CollideWithAreas = value; }
    /// <summary>
    /// <para>If <c>true</c>, collisions with <see cref="PhysicsBody2D" />s will be reported.</para>
    /// </summary>
    public bool CollideWithBodies { get => _node.CollideWithBodies; set => _node.CollideWithBodies = value; }
    /// <summary>
    /// <para>The ray's collision mask. Only objects in at least one collision layer enabled in the mask will be detected. See <a href="$DOCS_URL/tutorials/physics/physics_introduction.html#collision-layers-and-masks">Collision layers and masks</a> in the documentation for more information.</para>
    /// </summary>
    public uint CollisionMask { get => _node.CollisionMask; set => _node.CollisionMask = value; }
    /// <summary>
    /// <para>If <c>true</c>, collisions will be reported.</para>
    /// </summary>
    public bool Enabled { get => _node.Enabled; set => _node.Enabled = value; }
    /// <summary>
    /// <para>If <c>true</c>, the parent node will be excluded from collision detection.</para>
    /// </summary>
    public bool ExcludeParent { get => _node.ExcludeParent; set => _node.ExcludeParent = value; }
    /// <summary>
    /// <para>Updates the collision information for the ray immediately, without waiting for the next <c>_physics_process</c> call. Use this method, for example, when the ray or its parent has changed state.</para>
    /// <para><b>Note:</b> <see cref="RayCast2D.Enabled" /> does not need to be <c>true</c> for this to work.</para>
    /// </summary>
    public void ForceRaycastUpdate() => _node.ForceRaycastUpdate();
    /// <summary>
    /// <para>Returns the first object that the ray intersects, or <c>null</c> if no object is intersecting the ray (i.e. <see cref="RayCast2D.IsColliding" /> returns <c>false</c>).</para>
    /// </summary>
    public GodotObject GetCollider() => _node.GetCollider();
    /// <summary>
    /// <para>Returns the <see cref="Rid" /> of the first object that the ray intersects, or an empty <see cref="Rid" /> if no object is intersecting the ray (i.e. <see cref="RayCast2D.IsColliding" /> returns <c>false</c>).</para>
    /// </summary>
    public Rid GetColliderRid() => _node.GetColliderRid();
    /// <summary>
    /// <para>Returns the shape ID of the first object that the ray intersects, or <c>0</c> if no object is intersecting the ray (i.e. <see cref="RayCast2D.IsColliding" /> returns <c>false</c>).</para>
    /// </summary>
    public int GetColliderShape() => _node.GetColliderShape();
    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="RayCast2D.CollisionMask" /> is enabled, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    public bool GetCollisionMaskValue(int layerNumber) => _node.GetCollisionMaskValue(layerNumber);
    /// <summary>
    /// <para>Returns the normal of the intersecting object's shape at the collision point, or <c>Vector2(0, 0)</c> if the ray starts inside the shape and <see cref="RayCast2D.HitFromInside" /> is <c>true</c>.</para>
    /// </summary>
    public Vector2 GetCollisionNormal() => _node.GetCollisionNormal();
    /// <summary>
    /// <para>Returns the collision point at which the ray intersects the closest object.</para>
    /// <para><b>Note:</b> This point is in the <b>global</b> coordinate system.</para>
    /// </summary>
    public Vector2 GetCollisionPoint() => _node.GetCollisionPoint();
    /// <summary>
    /// <para>If <c>true</c>, the ray will detect a hit when starting inside shapes. In this case the collision normal will be <c>Vector2(0, 0)</c>. Does not affect concave polygon shapes.</para>
    /// </summary>
    public bool HitFromInside { get => _node.HitFromInside; set => _node.HitFromInside = value; }
    /// <summary>
    /// <para>Returns whether any object is intersecting with the ray's vector (considering the vector length).</para>
    /// </summary>
    public bool IsColliding() => _node.IsColliding();
    /// <summary>
    /// <para>Removes a collision exception so the ray does report collisions with the specified <see cref="CollisionObject2D" /> node.</para>
    /// </summary>
    public void RemoveException(CollisionObject2D node) => _node.RemoveException(node);
    /// <summary>
    /// <para>Removes a collision exception so the ray does report collisions with the specified <see cref="Rid" />.</para>
    /// </summary>
    public void RemoveExceptionRid(Rid rid) => _node.RemoveExceptionRid(rid);
    /// <summary>
    /// <para>Based on <paramref name="value" />, enables or disables the specified layer in the <see cref="RayCast2D.CollisionMask" />, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    public void SetCollisionMaskValue(int layerNumber, bool value) => _node.SetCollisionMaskValue(layerNumber, value);
    /// <summary>
    /// <para>The ray's destination point, relative to the RayCast's <c>position</c>.</para>
    /// </summary>
    public Vector2 TargetPosition { get => _node.TargetPosition; set => _node.TargetPosition = value; }

}