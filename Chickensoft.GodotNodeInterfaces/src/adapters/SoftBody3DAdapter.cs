namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
using Godot.Collections;
/// <summary>
/// <para>A deformable 3D physics mesh. Used to create elastic or deformable objects such as cloth, rubber, or other flexible materials.</para>
/// <para><b>Note:</b> There are many known bugs in <see cref="SoftBody3D" />. Therefore, it's not recommended to use them for things that can affect gameplay (such as trampolines).</para>
/// </summary>
public class SoftBody3DAdapter : MeshInstance3DAdapter, ISoftBody3D {
  private readonly SoftBody3D _node;

  public SoftBody3DAdapter(SoftBody3D node) : base(node) { _node = node; }

    /// <summary>
    /// <para>Adds a body to the list of bodies that this body can't collide with.</para>
    /// </summary>
    public void AddCollisionExceptionWith(Node body) => _node.AddCollisionExceptionWith(body);
    /// <summary>
    /// <para>The physics layers this SoftBody3D <b>is in</b>. Collision objects can exist in one or more of 32 different layers. See also <see cref="SoftBody3D.CollisionMask" />.</para>
    /// <para><b>Note:</b> Object A can detect a contact with object B only if object B is in any of the layers that object A scans. See <a href="$DOCS_URL/tutorials/physics/physics_introduction.html#collision-layers-and-masks">Collision layers and masks</a> in the documentation for more information.</para>
    /// </summary>
    public uint CollisionLayer { get => _node.CollisionLayer; set => _node.CollisionLayer = value; }
    /// <summary>
    /// <para>The physics layers this SoftBody3D <b>scans</b>. Collision objects can scan one or more of 32 different layers. See also <see cref="SoftBody3D.CollisionLayer" />.</para>
    /// <para><b>Note:</b> Object A can detect a contact with object B only if object B is in any of the layers that object A scans. See <a href="$DOCS_URL/tutorials/physics/physics_introduction.html#collision-layers-and-masks">Collision layers and masks</a> in the documentation for more information.</para>
    /// </summary>
    public uint CollisionMask { get => _node.CollisionMask; set => _node.CollisionMask = value; }

    public float DampingCoefficient { get => _node.DampingCoefficient; set => _node.DampingCoefficient = value; }
    /// <summary>
    /// <para>Defines the behavior in physics when <see cref="Node.ProcessMode" /> is set to <see cref="Node.ProcessModeEnum.Disabled" />. See <see cref="SoftBody3D.DisableModeEnum" /> for more details about the different modes.</para>
    /// </summary>
    public SoftBody3D.DisableModeEnum DisableMode { get => _node.DisableMode; set => _node.DisableMode = value; }

    public float DragCoefficient { get => _node.DragCoefficient; set => _node.DragCoefficient = value; }
    /// <summary>
    /// <para>Returns an array of nodes that were added as collision exceptions for this body.</para>
    /// </summary>
    public Godot.Collections.Array<PhysicsBody3D> GetCollisionExceptions() => _node.GetCollisionExceptions();
    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="SoftBody3D.CollisionLayer" /> is enabled, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    public bool GetCollisionLayerValue(int layerNumber) => _node.GetCollisionLayerValue(layerNumber);
    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="SoftBody3D.CollisionMask" /> is enabled, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    public bool GetCollisionMaskValue(int layerNumber) => _node.GetCollisionMaskValue(layerNumber);

    public Rid GetPhysicsRid() => _node.GetPhysicsRid();
    /// <summary>
    /// <para>Returns local translation of a vertex in the surface array.</para>
    /// </summary>
    public Vector3 GetPointTransform(int pointIndex) => _node.GetPointTransform(pointIndex);
    /// <summary>
    /// <para>Returns <c>true</c> if vertex is set to pinned.</para>
    /// </summary>
    public bool IsPointPinned(int pointIndex) => _node.IsPointPinned(pointIndex);
    /// <summary>
    /// <para>Higher values will result in a stiffer body, while lower values will increase the body's ability to bend. The value can be between <c>0.0</c> and <c>1.0</c> (inclusive).</para>
    /// </summary>
    public float LinearStiffness { get => _node.LinearStiffness; set => _node.LinearStiffness = value; }
    /// <summary>
    /// <para><see cref="NodePath" /> to a <see cref="CollisionObject3D" /> this SoftBody3D should avoid clipping.</para>
    /// </summary>
    public NodePath ParentCollisionIgnore { get => _node.ParentCollisionIgnore; set => _node.ParentCollisionIgnore = value; }

    public float PressureCoefficient { get => _node.PressureCoefficient; set => _node.PressureCoefficient = value; }
    /// <summary>
    /// <para>If <c>true</c>, the <see cref="SoftBody3D" /> will respond to <see cref="RayCast3D" />s.</para>
    /// </summary>
    public bool RayPickable { get => _node.RayPickable; set => _node.RayPickable = value; }
    /// <summary>
    /// <para>Removes a body from the list of bodies that this body can't collide with.</para>
    /// </summary>
    public void RemoveCollisionExceptionWith(Node body) => _node.RemoveCollisionExceptionWith(body);
    /// <summary>
    /// <para>Based on <paramref name="value" />, enables or disables the specified layer in the <see cref="SoftBody3D.CollisionLayer" />, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    public void SetCollisionLayerValue(int layerNumber, bool value) => _node.SetCollisionLayerValue(layerNumber, value);
    /// <summary>
    /// <para>Based on <paramref name="value" />, enables or disables the specified layer in the <see cref="SoftBody3D.CollisionMask" />, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    public void SetCollisionMaskValue(int layerNumber, bool value) => _node.SetCollisionMaskValue(layerNumber, value);
    /// <summary>
    /// <para>Sets the pinned state of a surface vertex. When set to <c>true</c>, the optional <paramref name="attachmentPath" /> can define a <see cref="Node3D" /> the pinned vertex will be attached to.</para>
    /// </summary>
    public void SetPointPinned(int pointIndex, bool pinned, NodePath attachmentPath) => _node.SetPointPinned(pointIndex, pinned, attachmentPath);
    /// <summary>
    /// <para>Increasing this value will improve the resulting simulation, but can affect performance. Use with care.</para>
    /// </summary>
    public int SimulationPrecision { get => _node.SimulationPrecision; set => _node.SimulationPrecision = value; }
    /// <summary>
    /// <para>The SoftBody3D's mass.</para>
    /// </summary>
    public float TotalMass { get => _node.TotalMass; set => _node.TotalMass = value; }

}