 namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A raycast represents a ray from its origin to its <see cref="RayCast3D.TargetPosition" /> that finds the closest <see cref="CollisionObject3D" /> along its path, if it intersects any. This is useful for a lot of things, such as</para>
/// <para><see cref="RayCast3D" /> can ignore some objects by adding them to an exception list, by making its detection reporting ignore <see cref="Area3D" />s (<see cref="RayCast3D.CollideWithAreas" />) or <see cref="PhysicsBody3D" />s (<see cref="RayCast3D.CollideWithBodies" />), or by configuring physics layers.</para>
/// <para><see cref="RayCast3D" /> calculates intersection every physics frame, and it holds the result until the next physics frame. For an immediate raycast, or if you want to configure a <see cref="RayCast3D" /> multiple times within the same physics frame, use <see cref="RayCast3D.ForceRaycastUpdate" />.</para>
/// <para>To sweep over a region of 3D space, you can approximate the region with multiple <see cref="RayCast3D" />s or use <see cref="ShapeCast3D" />.</para>
/// </summary>
public class RayCast3DAdapter : RayCast3D, IRayCast3D {
  private readonly RayCast3D _node;

  public RayCast3DAdapter(RayCast3D node) => _node = node;
    /// <summary>
    /// <para>Adds a collision exception so the ray does not report collisions with the specified <see cref="CollisionObject3D" /> node.</para>
    /// </summary>
    public void AddException(CollisionObject3D node) => _node.AddException(node);
    /// <summary>
    /// <para>Adds a collision exception so the ray does not report collisions with the specified <see cref="Rid" />.</para>
    /// </summary>
    public void AddExceptionRid(Rid rid) => _node.AddExceptionRid(rid);
    /// <summary>
    /// <para>Removes all collision exceptions for this ray.</para>
    /// </summary>
    public void ClearExceptions() => _node.ClearExceptions();
    /// <summary>
    /// <para>If <c>true</c>, collisions with <see cref="Area3D" />s will be reported.</para>
    /// </summary>
    public bool CollideWithAreas { get => _node.CollideWithAreas; set => _node.CollideWithAreas = value; }
    /// <summary>
    /// <para>If <c>true</c>, collisions with <see cref="PhysicsBody3D" />s will be reported.</para>
    /// </summary>
    public bool CollideWithBodies { get => _node.CollideWithBodies; set => _node.CollideWithBodies = value; }
    /// <summary>
    /// <para>The ray's collision mask. Only objects in at least one collision layer enabled in the mask will be detected. See <a href="$DOCS_URL/tutorials/physics/physics_introduction.html#collision-layers-and-masks">Collision layers and masks</a> in the documentation for more information.</para>
    /// </summary>
    public uint CollisionMask { get => _node.CollisionMask; set => _node.CollisionMask = value; }
    /// <summary>
    /// <para>The custom color to use to draw the shape in the editor and at run-time if <b>Visible Collision Shapes</b> is enabled in the <b>Debug</b> menu. This color will be highlighted at run-time if the <see cref="RayCast3D" /> is colliding with something.</para>
    /// <para>If set to <c>Color(0.0, 0.0, 0.0)</c> (by default), the color set in <c>ProjectSettings.debug/shapes/collision/shape_color</c> is used.</para>
    /// </summary>
    public Color DebugShapeCustomColor { get => _node.DebugShapeCustomColor; set => _node.DebugShapeCustomColor = value; }
    /// <summary>
    /// <para>If set to <c>1</c>, a line is used as the debug shape. Otherwise, a truncated pyramid is drawn to represent the <see cref="RayCast3D" />. Requires <b>Visible Collision Shapes</b> to be enabled in the <b>Debug</b> menu for the debug shape to be visible at run-time.</para>
    /// </summary>
    public int DebugShapeThickness { get => _node.DebugShapeThickness; set => _node.DebugShapeThickness = value; }
    /// <summary>
    /// <para>If <c>true</c>, collisions will be reported.</para>
    /// </summary>
    public bool Enabled { get => _node.Enabled; set => _node.Enabled = value; }
    /// <summary>
    /// <para>If <c>true</c>, collisions will be ignored for this RayCast3D's immediate parent.</para>
    /// </summary>
    public bool ExcludeParent { get => _node.ExcludeParent; set => _node.ExcludeParent = value; }
    /// <summary>
    /// <para>Updates the collision information for the ray immediately, without waiting for the next <c>_physics_process</c> call. Use this method, for example, when the ray or its parent has changed state.</para>
    /// <para><b>Note:</b> <see cref="RayCast3D.Enabled" /> does not need to be <c>true</c> for this to work.</para>
    /// </summary>
    public void ForceRaycastUpdate() => _node.ForceRaycastUpdate();
    /// <summary>
    /// <para>Returns the first object that the ray intersects, or <c>null</c> if no object is intersecting the ray (i.e. <see cref="RayCast3D.IsColliding" /> returns <c>false</c>).</para>
    /// </summary>
    public GodotObject GetCollider() => _node.GetCollider();
    /// <summary>
    /// <para>Returns the <see cref="Rid" /> of the first object that the ray intersects, or an empty <see cref="Rid" /> if no object is intersecting the ray (i.e. <see cref="RayCast3D.IsColliding" /> returns <c>false</c>).</para>
    /// </summary>
    public Rid GetColliderRid() => _node.GetColliderRid();
    /// <summary>
    /// <para>Returns the shape ID of the first object that the ray intersects, or <c>0</c> if no object is intersecting the ray (i.e. <see cref="RayCast3D.IsColliding" /> returns <c>false</c>).</para>
    /// </summary>
    public int GetColliderShape() => _node.GetColliderShape();
    /// <summary>
    /// <para>Returns the collision object's face index at the collision point, or <c>-1</c> if the shape intersecting the ray is not a <see cref="ConcavePolygonShape3D" />.</para>
    /// </summary>
    public int GetCollisionFaceIndex() => _node.GetCollisionFaceIndex();
    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="RayCast3D.CollisionMask" /> is enabled, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    public bool GetCollisionMaskValue(int layerNumber) => _node.GetCollisionMaskValue(layerNumber);
    /// <summary>
    /// <para>Returns the normal of the intersecting object's shape at the collision point, or <c>Vector3(0, 0, 0)</c> if the ray starts inside the shape and <see cref="RayCast3D.HitFromInside" /> is <c>true</c>.</para>
    /// </summary>
    public Vector3 GetCollisionNormal() => _node.GetCollisionNormal();
    /// <summary>
    /// <para>Returns the collision point at which the ray intersects the closest object.</para>
    /// <para><b>Note:</b> This point is in the <b>global</b> coordinate system.</para>
    /// </summary>
    public Vector3 GetCollisionPoint() => _node.GetCollisionPoint();
    /// <summary>
    /// <para>If <c>true</c>, the ray will hit back faces with concave polygon shapes with back face enabled or heightmap shapes.</para>
    /// </summary>
    public bool HitBackFaces { get => _node.HitBackFaces; set => _node.HitBackFaces = value; }
    /// <summary>
    /// <para>If <c>true</c>, the ray will detect a hit when starting inside shapes. In this case the collision normal will be <c>Vector3(0, 0, 0)</c>. Does not affect shapes with no volume like concave polygon or heightmap.</para>
    /// </summary>
    public bool HitFromInside { get => _node.HitFromInside; set => _node.HitFromInside = value; }
    /// <summary>
    /// <para>Returns whether any object is intersecting with the ray's vector (considering the vector length).</para>
    /// </summary>
    public bool IsColliding() => _node.IsColliding();
    /// <summary>
    /// <para>Removes a collision exception so the ray does report collisions with the specified <see cref="CollisionObject3D" /> node.</para>
    /// </summary>
    public void RemoveException(CollisionObject3D node) => _node.RemoveException(node);
    /// <summary>
    /// <para>Removes a collision exception so the ray does report collisions with the specified <see cref="Rid" />.</para>
    /// </summary>
    public void RemoveExceptionRid(Rid rid) => _node.RemoveExceptionRid(rid);
    /// <summary>
    /// <para>Based on <paramref name="value" />, enables or disables the specified layer in the <see cref="RayCast3D.CollisionMask" />, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    public void SetCollisionMaskValue(int layerNumber, bool value) => _node.SetCollisionMaskValue(layerNumber, value);
    /// <summary>
    /// <para>The ray's destination point, relative to the RayCast's <c>position</c>.</para>
    /// </summary>
    public Vector3 TargetPosition { get => _node.TargetPosition; set => _node.TargetPosition = value; }

}