namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using Godot.Collections;
using System;


/// <summary>
/// <para><see cref="Area3D" /> is a region of 3D space defined by one or multiple <see cref="CollisionShape3D" /> or <see cref="CollisionPolygon3D" /> child nodes. It detects when other <see cref="CollisionObject3D" />s enter or exit it, and it also keeps track of which collision objects haven't exited it yet (i.e. which one are overlapping it).</para>
/// <para>This node can also locally alter or override physics parameters (gravity, damping) and route audio to custom audio buses.</para>
/// <para><b>Warning:</b> Using a <see cref="ConcavePolygonShape3D" /> inside a <see cref="CollisionShape3D" /> child of this node (created e.g. by using the <b>Create Trimesh Collision Sibling</b> option in the <b>Mesh</b> menu that appears when selecting a <see cref="MeshInstance3D" /> node) may give unexpected results, since this collision shape is hollow. If this is not desired, it has to be split into multiple <see cref="ConvexPolygonShape3D" />s or primitive shapes like <see cref="BoxShape3D" />, or in some cases it may be replaceable by a <see cref="CollisionPolygon3D" />.</para>
/// </summary>
public interface IArea3D : ICollisionObject3D {
    /// <summary>
    /// <para>Returns a list of intersecting <see cref="PhysicsBody3D" />s and <see cref="GridMap" />s. The overlapping body's <see cref="CollisionObject3D.CollisionLayer" /> must be part of this area's <see cref="CollisionObject3D.CollisionMask" /> in order to be detected.</para>
    /// <para>For performance reasons (collisions are all processed at the same time) this list is modified once during the physics step, not immediately after objects are moved. Consider using signals instead.</para>
    /// </summary>
    Godot.Collections.Array<Node3D> GetOverlappingBodies();
    /// <summary>
    /// <para>Returns a list of intersecting <see cref="Area3D" />s. The overlapping area's <see cref="CollisionObject3D.CollisionLayer" /> must be part of this area's <see cref="CollisionObject3D.CollisionMask" /> in order to be detected.</para>
    /// <para>For performance reasons (collisions are all processed at the same time) this list is modified once during the physics step, not immediately after objects are moved. Consider using signals instead.</para>
    /// </summary>
    Godot.Collections.Array<Area3D> GetOverlappingAreas();
    /// <summary>
    /// <para>Returns <c>true</c> if intersecting any <see cref="PhysicsBody3D" />s or <see cref="GridMap" />s, otherwise returns <c>false</c>. The overlapping body's <see cref="CollisionObject3D.CollisionLayer" /> must be part of this area's <see cref="CollisionObject3D.CollisionMask" /> in order to be detected.</para>
    /// <para>For performance reasons (collisions are all processed at the same time) the list of overlapping bodies is modified once during the physics step, not immediately after objects are moved. Consider using signals instead.</para>
    /// </summary>
    bool HasOverlappingBodies();
    /// <summary>
    /// <para>Returns <c>true</c> if intersecting any <see cref="Area3D" />s, otherwise returns <c>false</c>. The overlapping area's <see cref="CollisionObject3D.CollisionLayer" /> must be part of this area's <see cref="CollisionObject3D.CollisionMask" /> in order to be detected.</para>
    /// <para>For performance reasons (collisions are all processed at the same time) the list of overlapping areas is modified once during the physics step, not immediately after objects are moved. Consider using signals instead.</para>
    /// </summary>
    bool HasOverlappingAreas();
    /// <summary>
    /// <para>Returns <c>true</c> if the given physics body intersects or overlaps this <see cref="Area3D" />, <c>false</c> otherwise.</para>
    /// <para><b>Note:</b> The result of this test is not immediate after moving objects. For performance, list of overlaps is updated once per frame and before the physics step. Consider using signals instead.</para>
    /// <para>The <paramref name="body" /> argument can either be a <see cref="PhysicsBody3D" /> or a <see cref="GridMap" /> instance. While GridMaps are not physics body themselves, they register their tiles with collision shapes as a virtual physics body.</para>
    /// </summary>
    bool OverlapsBody(Node body);
    /// <summary>
    /// <para>Returns <c>true</c> if the given <see cref="Area3D" /> intersects or overlaps this <see cref="Area3D" />, <c>false</c> otherwise.</para>
    /// <para><b>Note:</b> The result of this test is not immediate after moving objects. For performance, list of overlaps is updated once per frame and before the physics step. Consider using signals instead.</para>
    /// </summary>
    bool OverlapsArea(Node area);
    /// <summary>
    /// <para>If <c>true</c>, the area detects bodies or areas entering and exiting it.</para>
    /// </summary>
    bool Monitoring { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, other monitoring areas can detect this area.</para>
    /// </summary>
    bool Monitorable { get; set; }
    /// <summary>
    /// <para>The area's priority. Higher priority areas are processed first. The <see cref="World3D" />'s physics is always processed last, after all areas.</para>
    /// </summary>
    int Priority { get; set; }
    /// <summary>
    /// <para>Override mode for gravity calculations within this area. See <see cref="Area3D.SpaceOverride" /> for possible values.</para>
    /// </summary>
    Area3D.SpaceOverride GravitySpaceOverride { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, gravity is calculated from a point (set via <see cref="Area3D.GravityPointCenter" />). See also <see cref="Area3D.GravitySpaceOverride" />.</para>
    /// </summary>
    bool GravityPoint { get; set; }
    /// <summary>
    /// <para>The distance at which the gravity strength is equal to <see cref="Area3D.Gravity" />. For example, on a planet 100 meters in radius with a surface gravity of 4.0 m/s², set the <see cref="Area3D.Gravity" /> to 4.0 and the unit distance to 100.0. The gravity will have falloff according to the inverse square law, so in the example, at 200 meters from the center the gravity will be 1.0 m/s² (twice the distance, 1/4th the gravity), at 50 meters it will be 16.0 m/s² (half the distance, 4x the gravity), and so on.</para>
    /// <para>The above is true only when the unit distance is a positive number. When this is set to 0.0, the gravity will be constant regardless of distance.</para>
    /// </summary>
    float GravityPointUnitDistance { get; set; }
    /// <summary>
    /// <para>If gravity is a point (see <see cref="Area3D.GravityPoint" />), this will be the point of attraction.</para>
    /// </summary>
    Vector3 GravityPointCenter { get; set; }
    /// <summary>
    /// <para>The area's gravity vector (not normalized).</para>
    /// </summary>
    Vector3 GravityDirection { get; set; }
    /// <summary>
    /// <para>The area's gravity intensity (in meters per second squared). This value multiplies the gravity direction. This is useful to alter the force of gravity without altering its direction.</para>
    /// </summary>
    float Gravity { get; set; }
    /// <summary>
    /// <para>Override mode for linear damping calculations within this area. See <see cref="Area3D.SpaceOverride" /> for possible values.</para>
    /// </summary>
    Area3D.SpaceOverride LinearDampSpaceOverride { get; set; }
    /// <summary>
    /// <para>The rate at which objects stop moving in this area. Represents the linear velocity lost per second.</para>
    /// <para>See <c>ProjectSettings.physics/3d/default_linear_damp</c> for more details about damping.</para>
    /// </summary>
    float LinearDamp { get; set; }
    /// <summary>
    /// <para>Override mode for angular damping calculations within this area. See <see cref="Area3D.SpaceOverride" /> for possible values.</para>
    /// </summary>
    Area3D.SpaceOverride AngularDampSpaceOverride { get; set; }
    /// <summary>
    /// <para>The rate at which objects stop spinning in this area. Represents the angular velocity lost per second.</para>
    /// <para>See <c>ProjectSettings.physics/3d/default_angular_damp</c> for more details about damping.</para>
    /// </summary>
    float AngularDamp { get; set; }
    /// <summary>
    /// <para>The magnitude of area-specific wind force.</para>
    /// </summary>
    float WindForceMagnitude { get; set; }
    /// <summary>
    /// <para>The exponential rate at which wind force decreases with distance from its origin.</para>
    /// </summary>
    float WindAttenuationFactor { get; set; }
    /// <summary>
    /// <para>The <see cref="Node3D" /> which is used to specify the direction and origin of an area-specific wind force. The direction is opposite to the z-axis of the <see cref="Node3D" />'s local transform, and its origin is the origin of the <see cref="Node3D" />'s local transform.</para>
    /// </summary>
    NodePath WindSourcePath { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the area's audio bus overrides the default audio bus.</para>
    /// </summary>
    bool AudioBusOverride { get; set; }
    /// <summary>
    /// <para>The name of the area's audio bus.</para>
    /// </summary>
    StringName AudioBusName { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the area applies reverb to its associated audio.</para>
    /// </summary>
    bool ReverbBusEnabled { get; set; }
    /// <summary>
    /// <para>The name of the reverb bus to use for this area's associated audio.</para>
    /// </summary>
    StringName ReverbBusName { get; set; }
    /// <summary>
    /// <para>The degree to which this area applies reverb to its associated audio. Ranges from <c>0</c> to <c>1</c> with <c>0.1</c> precision.</para>
    /// </summary>
    float ReverbBusAmount { get; set; }
    /// <summary>
    /// <para>The degree to which this area's reverb is a uniform effect. Ranges from <c>0</c> to <c>1</c> with <c>0.1</c> precision.</para>
    /// </summary>
    float ReverbBusUniformity { get; set; }

}