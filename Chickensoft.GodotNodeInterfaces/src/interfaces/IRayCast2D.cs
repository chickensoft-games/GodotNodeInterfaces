namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class RayCast2DNode : RayCast2D, IRayCast2D { }

/// <summary>
/// <para>A raycast represents a ray from its origin to its <see cref="RayCast2D.TargetPosition" /> that finds the closest <see cref="CollisionObject2D" /> along its path, if it intersects any. This is useful for a lot of things, such as</para>
/// <para><see cref="RayCast2D" /> can ignore some objects by adding them to an exception list, by making its detection reporting ignore <see cref="Area2D" />s (<see cref="RayCast2D.CollideWithAreas" />) or <see cref="PhysicsBody2D" />s (<see cref="RayCast2D.CollideWithBodies" />), or by configuring physics layers.</para>
/// <para><see cref="RayCast2D" /> calculates intersection every physics frame, and it holds the result until the next physics frame. For an immediate raycast, or if you want to configure a <see cref="RayCast2D" /> multiple times within the same physics frame, use <see cref="RayCast2D.ForceRaycastUpdate" />.</para>
/// <para>To sweep over a region of 2D space, you can approximate the region with multiple <see cref="RayCast2D" />s or use <see cref="ShapeCast2D" />.</para>
/// </summary>
public interface IRayCast2D : INode2D {
    /// <summary>
    /// <para>Adds a collision exception so the ray does not report collisions with the specified <see cref="CollisionObject2D" /> node.</para>
    /// </summary>
    void AddException(CollisionObject2D node);
    /// <summary>
    /// <para>Adds a collision exception so the ray does not report collisions with the specified <see cref="Rid" />.</para>
    /// </summary>
    void AddExceptionRid(Rid rid);
    /// <summary>
    /// <para>Removes all collision exceptions for this ray.</para>
    /// </summary>
    void ClearExceptions();
    /// <summary>
    /// <para>If <c>true</c>, collisions with <see cref="Area2D" />s will be reported.</para>
    /// </summary>
    bool CollideWithAreas { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, collisions with <see cref="PhysicsBody2D" />s will be reported.</para>
    /// </summary>
    bool CollideWithBodies { get; set; }
    /// <summary>
    /// <para>The ray's collision mask. Only objects in at least one collision layer enabled in the mask will be detected. See <a href="$DOCS_URL/tutorials/physics/physics_introduction.html#collision-layers-and-masks">Collision layers and masks</a> in the documentation for more information.</para>
    /// </summary>
    uint CollisionMask { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, collisions will be reported.</para>
    /// </summary>
    bool Enabled { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the parent node will be excluded from collision detection.</para>
    /// </summary>
    bool ExcludeParent { get; set; }
    /// <summary>
    /// <para>Updates the collision information for the ray immediately, without waiting for the next <c>_physics_process</c> call. Use this method, for example, when the ray or its parent has changed state.</para>
    /// <para><b>Note:</b> <see cref="RayCast2D.Enabled" /> does not need to be <c>true</c> for this to work.</para>
    /// </summary>
    void ForceRaycastUpdate();
    /// <summary>
    /// <para>Returns the first object that the ray intersects, or <c>null</c> if no object is intersecting the ray (i.e. <see cref="RayCast2D.IsColliding" /> returns <c>false</c>).</para>
    /// </summary>
    GodotObject GetCollider();
    /// <summary>
    /// <para>Returns the <see cref="Rid" /> of the first object that the ray intersects, or an empty <see cref="Rid" /> if no object is intersecting the ray (i.e. <see cref="RayCast2D.IsColliding" /> returns <c>false</c>).</para>
    /// </summary>
    Rid GetColliderRid();
    /// <summary>
    /// <para>Returns the shape ID of the first object that the ray intersects, or <c>0</c> if no object is intersecting the ray (i.e. <see cref="RayCast2D.IsColliding" /> returns <c>false</c>).</para>
    /// </summary>
    int GetColliderShape();
    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="RayCast2D.CollisionMask" /> is enabled, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    bool GetCollisionMaskValue(int layerNumber);
    /// <summary>
    /// <para>Returns the normal of the intersecting object's shape at the collision point, or <c>Vector2(0, 0)</c> if the ray starts inside the shape and <see cref="RayCast2D.HitFromInside" /> is <c>true</c>.</para>
    /// </summary>
    Vector2 GetCollisionNormal();
    /// <summary>
    /// <para>Returns the collision point at which the ray intersects the closest object.</para>
    /// <para><b>Note:</b> This point is in the <b>global</b> coordinate system.</para>
    /// </summary>
    Vector2 GetCollisionPoint();
    /// <summary>
    /// <para>If <c>true</c>, the ray will detect a hit when starting inside shapes. In this case the collision normal will be <c>Vector2(0, 0)</c>. Does not affect concave polygon shapes.</para>
    /// </summary>
    bool HitFromInside { get; set; }
    /// <summary>
    /// <para>Returns whether any object is intersecting with the ray's vector (considering the vector length).</para>
    /// </summary>
    bool IsColliding();
    /// <summary>
    /// <para>Removes a collision exception so the ray does report collisions with the specified <see cref="CollisionObject2D" /> node.</para>
    /// </summary>
    void RemoveException(CollisionObject2D node);
    /// <summary>
    /// <para>Removes a collision exception so the ray does report collisions with the specified <see cref="Rid" />.</para>
    /// </summary>
    void RemoveExceptionRid(Rid rid);
    /// <summary>
    /// <para>Based on <paramref name="value" />, enables or disables the specified layer in the <see cref="RayCast2D.CollisionMask" />, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    void SetCollisionMaskValue(int layerNumber, bool value);
    /// <summary>
    /// <para>The ray's destination point, relative to the RayCast's <c>position</c>.</para>
    /// </summary>
    Vector2 TargetPosition { get; set; }

}