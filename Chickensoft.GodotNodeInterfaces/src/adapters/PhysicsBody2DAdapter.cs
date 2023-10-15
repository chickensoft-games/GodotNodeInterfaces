namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
using Godot.Collections;
/// <summary>
/// <para><see cref="PhysicsBody2D" /> is an abstract base class for 2D game objects affected by physics. All 2D physics bodies inherit from it.</para>
/// </summary>
public class PhysicsBody2DAdapter : CollisionObject2DAdapter, IPhysicsBody2D {
  private readonly PhysicsBody2D _node;

  public PhysicsBody2DAdapter(Node node) : base(node) {
    if (node is not PhysicsBody2D typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a PhysicsBody2D"
      );
    }
    _node = typedNode;
  }

    /// <summary>
    /// <para>Adds a body to the list of bodies that this body can't collide with.</para>
    /// </summary>
    public void AddCollisionExceptionWith(Node body) => _node.AddCollisionExceptionWith(body);
    /// <summary>
    /// <para>Returns an array of nodes that were added as collision exceptions for this body.</para>
    /// </summary>
    public Godot.Collections.Array<PhysicsBody2D> GetCollisionExceptions() => _node.GetCollisionExceptions();
    /// <summary>
    /// <para>Moves the body along the vector <paramref name="motion" />. In order to be frame rate independent in <see cref="Node._PhysicsProcess(System.Double)" /> or <see cref="Node._Process(System.Double)" />, <paramref name="motion" /> should be computed using <c>delta</c>.</para>
    /// <para>Returns a <see cref="KinematicCollision2D" />, which contains information about the collision when stopped, or when touching another body along the motion.</para>
    /// <para>If <paramref name="testOnly" /> is <c>true</c>, the body does not move but the would-be collision information is given.</para>
    /// <para><paramref name="safeMargin" /> is the extra margin used for collision recovery (see <see cref="CharacterBody2D.SafeMargin" /> for more details).</para>
    /// <para>If <paramref name="recoveryAsCollision" /> is <c>true</c>, any depenetration from the recovery phase is also reported as a collision; this is used e.g. by <see cref="CharacterBody2D" /> for improving floor detection during floor snapping.</para>
    /// </summary>
    public KinematicCollision2D MoveAndCollide(Vector2 motion, bool testOnly, float safeMargin, bool recoveryAsCollision) => _node.MoveAndCollide(motion, testOnly, safeMargin, recoveryAsCollision);
    /// <summary>
    /// <para>Removes a body from the list of bodies that this body can't collide with.</para>
    /// </summary>
    public void RemoveCollisionExceptionWith(Node body) => _node.RemoveCollisionExceptionWith(body);
    /// <summary>
    /// <para>Checks for collisions without moving the body. In order to be frame rate independent in <see cref="Node._PhysicsProcess(System.Double)" /> or <see cref="Node._Process(System.Double)" />, <paramref name="motion" /> should be computed using <c>delta</c>.</para>
    /// <para>Virtually sets the node's position, scale and rotation to that of the given <see cref="Transform2D" />, then tries to move the body along the vector <paramref name="motion" />. Returns <c>true</c> if a collision would stop the body from moving along the whole path.</para>
    /// <para><paramref name="collision" /> is an optional object of type <see cref="KinematicCollision2D" />, which contains additional information about the collision when stopped, or when touching another body along the motion.</para>
    /// <para><paramref name="safeMargin" /> is the extra margin used for collision recovery (see <see cref="CharacterBody2D.SafeMargin" /> for more details).</para>
    /// <para>If <paramref name="recoveryAsCollision" /> is <c>true</c>, any depenetration from the recovery phase is also reported as a collision; this is useful for checking whether the body would <i>touch</i> any other bodies.</para>
    /// </summary>
    public bool TestMove(Transform2D @from, Vector2 motion, KinematicCollision2D collision, float safeMargin, bool recoveryAsCollision) => _node.TestMove(@from, motion, collision, safeMargin, recoveryAsCollision);

}