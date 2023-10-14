namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para><see cref="SpringArm3D" /> casts a ray or a shape along its Z axis and moves all its direct children to the collision point, with an optional margin. This is useful for 3rd person cameras that move closer to the player when inside a tight space (you may need to exclude the player's collider from the <see cref="SpringArm3D" />'s collision check).</para>
/// </summary>
public class SpringArm3DAdapter : SpringArm3D, ISpringArm3D {
  private readonly SpringArm3D _node;

  public SpringArm3DAdapter(SpringArm3D node) => _node = node;
    /// <summary>
    /// <para>Adds the <see cref="PhysicsBody3D" /> object with the given <see cref="Rid" /> to the list of <see cref="PhysicsBody3D" /> objects excluded from the collision check.</para>
    /// </summary>
    public void AddExcludedObject(Rid rID) => _node.AddExcludedObject(rID);
    /// <summary>
    /// <para>Clears the list of <see cref="PhysicsBody3D" /> objects excluded from the collision check.</para>
    /// </summary>
    public void ClearExcludedObjects() => _node.ClearExcludedObjects();
    /// <summary>
    /// <para>The layers against which the collision check shall be done. See <a href="$DOCS_URL/tutorials/physics/physics_introduction.html#collision-layers-and-masks">Collision layers and masks</a> in the documentation for more information.</para>
    /// </summary>
    public uint CollisionMask { get => _node.CollisionMask; set => _node.CollisionMask = value; }
    /// <summary>
    /// <para>Returns the spring arm's current length.</para>
    /// </summary>
    public float GetHitLength() => _node.GetHitLength();
    /// <summary>
    /// <para>When the collision check is made, a candidate length for the SpringArm3D is given.</para>
    /// <para>The margin is then subtracted to this length and the translation is applied to the child objects of the SpringArm3D.</para>
    /// <para>This margin is useful for when the SpringArm3D has a <see cref="Camera3D" /> as a child node: without the margin, the <see cref="Camera3D" /> would be placed on the exact point of collision, while with the margin the <see cref="Camera3D" /> would be placed close to the point of collision.</para>
    /// </summary>
    public float Margin { get => _node.Margin; set => _node.Margin = value; }
    /// <summary>
    /// <para>Removes the given <see cref="Rid" /> from the list of <see cref="PhysicsBody3D" /> objects excluded from the collision check.</para>
    /// </summary>
    public bool RemoveExcludedObject(Rid rID) => _node.RemoveExcludedObject(rID);
    /// <summary>
    /// <para>The <see cref="Shape3D" /> to use for the SpringArm3D.</para>
    /// <para>When the shape is set, the SpringArm3D will cast the <see cref="Shape3D" /> on its z axis instead of performing a ray cast.</para>
    /// </summary>
    public Shape3D Shape { get => _node.Shape; set => _node.Shape = value; }
    /// <summary>
    /// <para>The maximum extent of the SpringArm3D. This is used as a length for both the ray and the shape cast used internally to calculate the desired position of the SpringArm3D's child nodes.</para>
    /// <para>To know more about how to perform a shape cast or a ray cast, please consult the <see cref="PhysicsDirectSpaceState3D" /> documentation.</para>
    /// </summary>
    public float SpringLength { get => _node.SpringLength; set => _node.SpringLength = value; }

}