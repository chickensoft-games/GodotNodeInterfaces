namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
using Godot.Collections;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class SoftBody3DNode : SoftBody3D, ISoftBody3D { }

/// <summary>
/// <para>A deformable 3D physics mesh. Used to create elastic or deformable objects such as cloth, rubber, or other flexible materials.</para>
/// <para><b>Note:</b> There are many known bugs in <see cref="SoftBody3D" />. Therefore, it's not recommended to use them for things that can affect gameplay (such as trampolines).</para>
/// </summary>
public interface ISoftBody3D : IMeshInstance3D {
    /// <summary>
    /// <para>Adds a body to the list of bodies that this body can't collide with.</para>
    /// </summary>
    void AddCollisionExceptionWith(Node body);
    /// <summary>
    /// <para>The physics layers this SoftBody3D <b>is in</b>. Collision objects can exist in one or more of 32 different layers. See also <see cref="SoftBody3D.CollisionMask" />.</para>
    /// <para><b>Note:</b> Object A can detect a contact with object B only if object B is in any of the layers that object A scans. See <a href="$DOCS_URL/tutorials/physics/physics_introduction.html#collision-layers-and-masks">Collision layers and masks</a> in the documentation for more information.</para>
    /// </summary>
    uint CollisionLayer { get; set; }
    /// <summary>
    /// <para>The physics layers this SoftBody3D <b>scans</b>. Collision objects can scan one or more of 32 different layers. See also <see cref="SoftBody3D.CollisionLayer" />.</para>
    /// <para><b>Note:</b> Object A can detect a contact with object B only if object B is in any of the layers that object A scans. See <a href="$DOCS_URL/tutorials/physics/physics_introduction.html#collision-layers-and-masks">Collision layers and masks</a> in the documentation for more information.</para>
    /// </summary>
    uint CollisionMask { get; set; }

    float DampingCoefficient { get; set; }
    /// <summary>
    /// <para>Defines the behavior in physics when <see cref="Node.ProcessMode" /> is set to <see cref="Node.ProcessModeEnum.Disabled" />. See <see cref="SoftBody3D.DisableModeEnum" /> for more details about the different modes.</para>
    /// </summary>
    SoftBody3D.DisableModeEnum DisableMode { get; set; }

    float DragCoefficient { get; set; }
    /// <summary>
    /// <para>Returns an array of nodes that were added as collision exceptions for this body.</para>
    /// </summary>
    Godot.Collections.Array<PhysicsBody3D> GetCollisionExceptions();
    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="SoftBody3D.CollisionLayer" /> is enabled, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    bool GetCollisionLayerValue(int layerNumber);
    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="SoftBody3D.CollisionMask" /> is enabled, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    bool GetCollisionMaskValue(int layerNumber);

    Rid GetPhysicsRid();
    /// <summary>
    /// <para>Returns local translation of a vertex in the surface array.</para>
    /// </summary>
    Vector3 GetPointTransform(int pointIndex);
    /// <summary>
    /// <para>Returns <c>true</c> if vertex is set to pinned.</para>
    /// </summary>
    bool IsPointPinned(int pointIndex);
    /// <summary>
    /// <para>Higher values will result in a stiffer body, while lower values will increase the body's ability to bend. The value can be between <c>0.0</c> and <c>1.0</c> (inclusive).</para>
    /// </summary>
    float LinearStiffness { get; set; }
    /// <summary>
    /// <para><see cref="NodePath" /> to a <see cref="CollisionObject3D" /> this SoftBody3D should avoid clipping.</para>
    /// </summary>
    NodePath ParentCollisionIgnore { get; set; }

    float PressureCoefficient { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the <see cref="SoftBody3D" /> will respond to <see cref="RayCast3D" />s.</para>
    /// </summary>
    bool RayPickable { get; set; }
    /// <summary>
    /// <para>Removes a body from the list of bodies that this body can't collide with.</para>
    /// </summary>
    void RemoveCollisionExceptionWith(Node body);
    /// <summary>
    /// <para>Based on <paramref name="value" />, enables or disables the specified layer in the <see cref="SoftBody3D.CollisionLayer" />, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    void SetCollisionLayerValue(int layerNumber, bool value);
    /// <summary>
    /// <para>Based on <paramref name="value" />, enables or disables the specified layer in the <see cref="SoftBody3D.CollisionMask" />, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    void SetCollisionMaskValue(int layerNumber, bool value);
    /// <summary>
    /// <para>Sets the pinned state of a surface vertex. When set to <c>true</c>, the optional <paramref name="attachmentPath" /> can define a <see cref="Node3D" /> the pinned vertex will be attached to.</para>
    /// </summary>
    void SetPointPinned(int pointIndex, bool pinned, NodePath attachmentPath);
    /// <summary>
    /// <para>Increasing this value will improve the resulting simulation, but can affect performance. Use with care.</para>
    /// </summary>
    int SimulationPrecision { get; set; }
    /// <summary>
    /// <para>The SoftBody3D's mass.</para>
    /// </summary>
    float TotalMass { get; set; }

}