namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>Abstract base class for 3D physics objects. <see cref="CollisionObject3D" /> can hold any number of <see cref="Shape3D" />s for collision. Each shape must be assigned to a <i>shape owner</i>. Shape owners are not nodes and do not appear in the editor, but are accessible through code using the <c>shape_owner_*</c> methods.</para>
/// <para><b>Warning:</b> With a non-uniform scale, this node will likely not behave as expected. It is advised to keep its scale the same on all axes and adjust its collision shape(s) instead.</para>
/// </summary>
public interface ICollisionObject3D : INode3D {
    /// <summary>
    /// <para>Receives unhandled <see cref="InputEvent" />s. <paramref name="position" /> is the location in world space of the mouse pointer on the surface of the shape with index <paramref name="shapeIdx" /> and <paramref name="normal" /> is the normal vector of the surface at that point. Connect to the <see cref="CollisionObject3D.InputEvent" /> signal to easily pick up these events.</para>
    /// <para><b>Note:</b> <see cref="M:Godot.CollisionObject3D._InputEvent(Godot.Camera3D,Godot.InputEvent,Godot.Vector3,Godot.Vector3,System.Int32)" /> requires <see cref="CollisionObject3D.InputRayPickable" /> to be <c>true</c> and at least one <see cref="CollisionObject3D.CollisionLayer" /> bit to be set.</para>
    /// </summary>
    void _InputEvent(Camera3D camera, InputEvent @event, Vector3 position, Vector3 normal, int shapeIdx);
    /// <summary>
    /// <para>Called when the mouse pointer enters any of this object's shapes. Requires <see cref="CollisionObject3D.InputRayPickable" /> to be <c>true</c> and at least one <see cref="CollisionObject3D.CollisionLayer" /> bit to be set. Note that moving between different shapes within a single <see cref="CollisionObject3D" /> won't cause this function to be called.</para>
    /// </summary>
    void _MouseEnter();
    /// <summary>
    /// <para>Called when the mouse pointer exits all this object's shapes. Requires <see cref="CollisionObject3D.InputRayPickable" /> to be <c>true</c> and at least one <see cref="CollisionObject3D.CollisionLayer" /> bit to be set. Note that moving between different shapes within a single <see cref="CollisionObject3D" /> won't cause this function to be called.</para>
    /// </summary>
    void _MouseExit();
    /// <summary>
    /// <para>Based on <paramref name="value" />, enables or disables the specified layer in the <see cref="CollisionObject3D.CollisionLayer" />, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    void SetCollisionLayerValue(int layerNumber, bool value);
    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="CollisionObject3D.CollisionLayer" /> is enabled, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    bool GetCollisionLayerValue(int layerNumber);
    /// <summary>
    /// <para>Based on <paramref name="value" />, enables or disables the specified layer in the <see cref="CollisionObject3D.CollisionMask" />, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    void SetCollisionMaskValue(int layerNumber, bool value);
    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="CollisionObject3D.CollisionMask" /> is enabled, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    bool GetCollisionMaskValue(int layerNumber);
    /// <summary>
    /// <para>Returns the object's <see cref="Rid" />.</para>
    /// </summary>
    Rid GetRid();
    /// <summary>
    /// <para>Creates a new shape owner for the given object. Returns <c>owner_id</c> of the new owner for future reference.</para>
    /// </summary>
    uint CreateShapeOwner(GodotObject owner);
    /// <summary>
    /// <para>Removes the given shape owner.</para>
    /// </summary>
    void RemoveShapeOwner(uint ownerId);
    /// <summary>
    /// <para>Returns an <see cref="Collections.Array" /> of <c>owner_id</c> identifiers. You can use these ids in other methods that take <c>owner_id</c> as an argument.</para>
    /// </summary>
    int[] GetShapeOwners();
    /// <summary>
    /// <para>Sets the <see cref="Transform3D" /> of the given shape owner.</para>
    /// </summary>
    void ShapeOwnerSetTransform(uint ownerId, Transform3D transform);
    /// <summary>
    /// <para>Returns the shape owner's <see cref="Transform3D" />.</para>
    /// </summary>
    Transform3D ShapeOwnerGetTransform(uint ownerId);
    /// <summary>
    /// <para>Returns the parent object of the given shape owner.</para>
    /// </summary>
    GodotObject ShapeOwnerGetOwner(uint ownerId);
    /// <summary>
    /// <para>If <c>true</c>, disables the given shape owner.</para>
    /// </summary>
    void ShapeOwnerSetDisabled(uint ownerId, bool disabled);
    /// <summary>
    /// <para>If <c>true</c>, the shape owner and its shapes are disabled.</para>
    /// </summary>
    bool IsShapeOwnerDisabled(uint ownerId);
    /// <summary>
    /// <para>Adds a <see cref="Shape3D" /> to the shape owner.</para>
    /// </summary>
    void ShapeOwnerAddShape(uint ownerId, Shape3D shape);
    /// <summary>
    /// <para>Returns the number of shapes the given shape owner contains.</para>
    /// </summary>
    int ShapeOwnerGetShapeCount(uint ownerId);
    /// <summary>
    /// <para>Returns the <see cref="Shape3D" /> with the given ID from the given shape owner.</para>
    /// </summary>
    Shape3D ShapeOwnerGetShape(uint ownerId, int shapeId);
    /// <summary>
    /// <para>Returns the child index of the <see cref="Shape3D" /> with the given ID from the given shape owner.</para>
    /// </summary>
    int ShapeOwnerGetShapeIndex(uint ownerId, int shapeId);
    /// <summary>
    /// <para>Removes a shape from the given shape owner.</para>
    /// </summary>
    void ShapeOwnerRemoveShape(uint ownerId, int shapeId);
    /// <summary>
    /// <para>Removes all shapes from the shape owner.</para>
    /// </summary>
    void ShapeOwnerClearShapes(uint ownerId);
    /// <summary>
    /// <para>Returns the <c>owner_id</c> of the given shape.</para>
    /// </summary>
    uint ShapeFindOwner(int shapeIndex);
    /// <summary>
    /// <para>Defines the behavior in physics when <see cref="Node.ProcessMode" /> is set to <see cref="Node.ProcessModeEnum.Disabled" />. See <see cref="CollisionObject3D.DisableModeEnum" /> for more details about the different modes.</para>
    /// </summary>
    CollisionObject3D.DisableModeEnum DisableMode { get; set; }
    /// <summary>
    /// <para>The physics layers this CollisionObject3D <b>is in</b>. Collision objects can exist in one or more of 32 different layers. See also <see cref="CollisionObject3D.CollisionMask" />.</para>
    /// <para><b>Note:</b> Object A can detect a contact with object B only if object B is in any of the layers that object A scans. See <a href="$DOCS_URL/tutorials/physics/physics_introduction.html#collision-layers-and-masks">Collision layers and masks</a> in the documentation for more information.</para>
    /// </summary>
    uint CollisionLayer { get; set; }
    /// <summary>
    /// <para>The physics layers this CollisionObject3D <b>scans</b>. Collision objects can scan one or more of 32 different layers. See also <see cref="CollisionObject3D.CollisionLayer" />.</para>
    /// <para><b>Note:</b> Object A can detect a contact with object B only if object B is in any of the layers that object A scans. See <a href="$DOCS_URL/tutorials/physics/physics_introduction.html#collision-layers-and-masks">Collision layers and masks</a> in the documentation for more information.</para>
    /// </summary>
    uint CollisionMask { get; set; }
    /// <summary>
    /// <para>The priority used to solve colliding when occurring penetration. The higher the priority is, the lower the penetration into the object will be. This can for example be used to prevent the player from breaking through the boundaries of a level.</para>
    /// </summary>
    float CollisionPriority { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, this object is pickable. A pickable object can detect the mouse pointer entering/leaving, and if the mouse is inside it, report input events. Requires at least one <see cref="CollisionObject3D.CollisionLayer" /> bit to be set.</para>
    /// </summary>
    bool InputRayPickable { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the <see cref="CollisionObject3D" /> will continue to receive input events as the mouse is dragged across its shapes.</para>
    /// </summary>
    bool InputCaptureOnDrag { get; set; }

}