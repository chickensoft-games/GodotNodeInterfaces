namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
using Godot.Collections;


/// <summary>
/// <para><see cref="PhysicsBody3D" /> is an abstract base class for 3D game objects affected by physics. All 3D physics bodies inherit from it.</para>
/// <para><b>Warning:</b> With a non-uniform scale, this node will likely not behave as expected. It is advised to keep its scale the same on all axes and adjust its collision shape(s) instead.</para>
/// </summary>
public interface IPhysicsBody3D : ICollisionObject3D {
    /// <summary>
    /// <para>Moves the body along the vector <paramref name="motion" />. In order to be frame rate independent in <see cref="M:Godot.Node._PhysicsProcess(System.Double)" /> or <see cref="M:Godot.Node._Process(System.Double)" />, <paramref name="motion" /> should be computed using <c>delta</c>.</para>
    /// <para>The body will stop if it collides. Returns a <see cref="KinematicCollision3D" />, which contains information about the collision when stopped, or when touching another body along the motion.</para>
    /// <para>If <paramref name="testOnly" /> is <c>true</c>, the body does not move but the would-be collision information is given.</para>
    /// <para><paramref name="safeMargin" /> is the extra margin used for collision recovery (see <see cref="CharacterBody3D.SafeMargin" /> for more details).</para>
    /// <para>If <paramref name="recoveryAsCollision" /> is <c>true</c>, any depenetration from the recovery phase is also reported as a collision; this is used e.g. by <see cref="CharacterBody3D" /> for improving floor detection during floor snapping.</para>
    /// <para><paramref name="maxCollisions" /> allows to retrieve more than one collision result.</para>
    /// </summary>
    KinematicCollision3D MoveAndCollide(Vector3 motion, bool testOnly, float safeMargin, bool recoveryAsCollision, int maxCollisions);
    /// <summary>
    /// <para>Checks for collisions without moving the body. In order to be frame rate independent in <see cref="M:Godot.Node._PhysicsProcess(System.Double)" /> or <see cref="M:Godot.Node._Process(System.Double)" />, <paramref name="motion" /> should be computed using <c>delta</c>.</para>
    /// <para>Virtually sets the node's position, scale and rotation to that of the given <see cref="Transform3D" />, then tries to move the body along the vector <paramref name="motion" />. Returns <c>true</c> if a collision would stop the body from moving along the whole path.</para>
    /// <para><paramref name="collision" /> is an optional object of type <see cref="KinematicCollision3D" />, which contains additional information about the collision when stopped, or when touching another body along the motion.</para>
    /// <para><paramref name="safeMargin" /> is the extra margin used for collision recovery (see <see cref="CharacterBody3D.SafeMargin" /> for more details).</para>
    /// <para>If <paramref name="recoveryAsCollision" /> is <c>true</c>, any depenetration from the recovery phase is also reported as a collision; this is useful for checking whether the body would <i>touch</i> any other bodies.</para>
    /// <para><paramref name="maxCollisions" /> allows to retrieve more than one collision result.</para>
    /// </summary>
    bool TestMove(Transform3D @from, Vector3 motion, KinematicCollision3D collision, float safeMargin, bool recoveryAsCollision, int maxCollisions);
    /// <summary>
    /// <para>Returns an array of nodes that were added as collision exceptions for this body.</para>
    /// </summary>
    Godot.Collections.Array<PhysicsBody3D> GetCollisionExceptions();
    /// <summary>
    /// <para>Adds a body to the list of bodies that this body can't collide with.</para>
    /// </summary>
    void AddCollisionExceptionWith(Node body);
    /// <summary>
    /// <para>Removes a body from the list of bodies that this body can't collide with.</para>
    /// </summary>
    void RemoveCollisionExceptionWith(Node body);
    /// <summary>
    /// <para>Lock the body's linear movement in the X axis.</para>
    /// </summary>
    bool AxisLockLinearX { get; set; }
    /// <summary>
    /// <para>Lock the body's linear movement in the Y axis.</para>
    /// </summary>
    bool AxisLockLinearY { get; set; }
    /// <summary>
    /// <para>Lock the body's linear movement in the Z axis.</para>
    /// </summary>
    bool AxisLockLinearZ { get; set; }
    /// <summary>
    /// <para>Lock the body's rotation in the X axis.</para>
    /// </summary>
    bool AxisLockAngularX { get; set; }
    /// <summary>
    /// <para>Lock the body's rotation in the Y axis.</para>
    /// </summary>
    bool AxisLockAngularY { get; set; }
    /// <summary>
    /// <para>Lock the body's rotation in the Z axis.</para>
    /// </summary>
    bool AxisLockAngularZ { get; set; }

}