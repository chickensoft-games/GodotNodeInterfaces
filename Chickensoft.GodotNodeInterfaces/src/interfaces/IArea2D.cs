namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using Godot.Collections;
using System;


/// <summary>
/// <para><see cref="Area2D" /> is a region of 2D space defined by one or multiple <see cref="CollisionShape2D" /> or <see cref="CollisionPolygon2D" /> child nodes. It detects when other <see cref="CollisionObject2D" />s enter or exit it, and it also keeps track of which collision objects haven't exited it yet (i.e. which one are overlapping it).</para>
/// <para>This node can also locally alter or override physics parameters (gravity, damping) and route audio to custom audio buses.</para>
/// </summary>
public interface IArea2D : ICollisionObject2D {
    /// <summary>
    /// <para>Returns a list of intersecting <see cref="PhysicsBody2D" />s and <see cref="TileMap" />s. The overlapping body's <see cref="CollisionObject2D.CollisionLayer" /> must be part of this area's <see cref="CollisionObject2D.CollisionMask" /> in order to be detected.</para>
    /// <para>For performance reasons (collisions are all processed at the same time) this list is modified once during the physics step, not immediately after objects are moved. Consider using signals instead.</para>
    /// </summary>
    Godot.Collections.Array<Node2D> GetOverlappingBodies();
    /// <summary>
    /// <para>Returns a list of intersecting <see cref="Area2D" />s. The overlapping area's <see cref="CollisionObject2D.CollisionLayer" /> must be part of this area's <see cref="CollisionObject2D.CollisionMask" /> in order to be detected.</para>
    /// <para>For performance reasons (collisions are all processed at the same time) this list is modified once during the physics step, not immediately after objects are moved. Consider using signals instead.</para>
    /// </summary>
    Godot.Collections.Array<Area2D> GetOverlappingAreas();
    /// <summary>
    /// <para>Returns <c>true</c> if intersecting any <see cref="PhysicsBody2D" />s or <see cref="TileMap" />s, otherwise returns <c>false</c>. The overlapping body's <see cref="CollisionObject2D.CollisionLayer" /> must be part of this area's <see cref="CollisionObject2D.CollisionMask" /> in order to be detected.</para>
    /// <para>For performance reasons (collisions are all processed at the same time) the list of overlapping bodies is modified once during the physics step, not immediately after objects are moved. Consider using signals instead.</para>
    /// </summary>
    bool HasOverlappingBodies();
    /// <summary>
    /// <para>Returns <c>true</c> if intersecting any <see cref="Area2D" />s, otherwise returns <c>false</c>. The overlapping area's <see cref="CollisionObject2D.CollisionLayer" /> must be part of this area's <see cref="CollisionObject2D.CollisionMask" /> in order to be detected.</para>
    /// <para>For performance reasons (collisions are all processed at the same time) the list of overlapping areas is modified once during the physics step, not immediately after objects are moved. Consider using signals instead.</para>
    /// </summary>
    bool HasOverlappingAreas();
    /// <summary>
    /// <para>Returns <c>true</c> if the given physics body intersects or overlaps this <see cref="Area2D" />, <c>false</c> otherwise.</para>
    /// <para><b>Note:</b> The result of this test is not immediate after moving objects. For performance, list of overlaps is updated once per frame and before the physics step. Consider using signals instead.</para>
    /// <para>The <paramref name="body" /> argument can either be a <see cref="PhysicsBody2D" /> or a <see cref="TileMap" /> instance. While TileMaps are not physics bodies themselves, they register their tiles with collision shapes as a virtual physics body.</para>
    /// </summary>
    bool OverlapsBody(Node body);
    /// <summary>
    /// <para>Returns <c>true</c> if the given <see cref="Area2D" /> intersects or overlaps this <see cref="Area2D" />, <c>false</c> otherwise.</para>
    /// <para><b>Note:</b> The result of this test is not immediate after moving objects. For performance, the list of overlaps is updated once per frame and before the physics step. Consider using signals instead.</para>
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
    /// <para>The area's priority. Higher priority areas are processed first. The <see cref="World2D" />'s physics is always processed last, after all areas.</para>
    /// </summary>
    int Priority { get; set; }
    /// <summary>
    /// <para>Override mode for gravity calculations within this area. See <see cref="Area2D.SpaceOverride" /> for possible values.</para>
    /// </summary>
    Area2D.SpaceOverride GravitySpaceOverride { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, gravity is calculated from a point (set via <see cref="Area2D.GravityPointCenter" />). See also <see cref="Area2D.GravitySpaceOverride" />.</para>
    /// </summary>
    bool GravityPoint { get; set; }
    /// <summary>
    /// <para>The distance at which the gravity strength is equal to <see cref="Area2D.Gravity" />. For example, on a planet 100 pixels in radius with a surface gravity of 4.0 px/s², set the <see cref="Area2D.Gravity" /> to 4.0 and the unit distance to 100.0. The gravity will have falloff according to the inverse square law, so in the example, at 200 pixels from the center the gravity will be 1.0 px/s² (twice the distance, 1/4th the gravity), at 50 pixels it will be 16.0 px/s² (half the distance, 4x the gravity), and so on.</para>
    /// <para>The above is true only when the unit distance is a positive number. When this is set to 0.0, the gravity will be constant regardless of distance.</para>
    /// </summary>
    float GravityPointUnitDistance { get; set; }
    /// <summary>
    /// <para>If gravity is a point (see <see cref="Area2D.GravityPoint" />), this will be the point of attraction.</para>
    /// </summary>
    Vector2 GravityPointCenter { get; set; }
    /// <summary>
    /// <para>The area's gravity vector (not normalized).</para>
    /// </summary>
    Vector2 GravityDirection { get; set; }
    /// <summary>
    /// <para>The area's gravity intensity (in pixels per second squared). This value multiplies the gravity direction. This is useful to alter the force of gravity without altering its direction.</para>
    /// </summary>
    float Gravity { get; set; }
    /// <summary>
    /// <para>Override mode for linear damping calculations within this area. See <see cref="Area2D.SpaceOverride" /> for possible values.</para>
    /// </summary>
    Area2D.SpaceOverride LinearDampSpaceOverride { get; set; }
    /// <summary>
    /// <para>The rate at which objects stop moving in this area. Represents the linear velocity lost per second.</para>
    /// <para>See <c>ProjectSettings.physics/2d/default_linear_damp</c> for more details about damping.</para>
    /// </summary>
    float LinearDamp { get; set; }
    /// <summary>
    /// <para>Override mode for angular damping calculations within this area. See <see cref="Area2D.SpaceOverride" /> for possible values.</para>
    /// </summary>
    Area2D.SpaceOverride AngularDampSpaceOverride { get; set; }
    /// <summary>
    /// <para>The rate at which objects stop spinning in this area. Represents the angular velocity lost per second.</para>
    /// <para>See <c>ProjectSettings.physics/2d/default_angular_damp</c> for more details about damping.</para>
    /// </summary>
    float AngularDamp { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the area's audio bus overrides the default audio bus.</para>
    /// </summary>
    bool AudioBusOverride { get; set; }
    /// <summary>
    /// <para>The name of the area's audio bus.</para>
    /// </summary>
    StringName AudioBusName { get; set; }

}