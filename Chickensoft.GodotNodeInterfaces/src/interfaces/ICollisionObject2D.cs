namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>Abstract base class for 2D physics objects. <see cref="CollisionObject2D" /> can hold any number of <see cref="Shape2D" />s for collision. Each shape must be assigned to a <i>shape owner</i>. Shape owners are not nodes and do not appear in the editor, but are accessible through code using the <c>shape_owner_*</c> methods.</para>
/// <para><b>Note:</b> Only collisions between objects within the same canvas (<see cref="Viewport" /> canvas or <see cref="CanvasLayer" />) are supported. The behavior of collisions between objects in different canvases is undefined.</para>
/// </summary>
public interface ICollisionObject2D : INode2D {
    /// <summary>
    /// <para>Accepts unhandled <see cref="InputEvent" />s. <paramref name="shapeIdx" /> is the child index of the clicked <see cref="Shape2D" />. Connect to <see cref="CollisionObject2D.InputEvent" /> to easily pick up these events.</para>
    /// <para><b>Note:</b> <see cref="M:Godot.CollisionObject2D._InputEvent(Godot.Viewport,Godot.InputEvent,System.Int32)" /> requires <see cref="CollisionObject2D.InputPickable" /> to be <c>true</c> and at least one <see cref="CollisionObject2D.CollisionLayer" /> bit to be set.</para>
    /// </summary>
    void _InputEvent(Viewport viewport, InputEvent @event, int shapeIdx);
    /// <summary>
    /// <para>Called when the mouse pointer enters any of this object's shapes. Requires <see cref="CollisionObject2D.InputPickable" /> to be <c>true</c> and at least one <see cref="CollisionObject2D.CollisionLayer" /> bit to be set. Note that moving between different shapes within a single <see cref="CollisionObject2D" /> won't cause this function to be called.</para>
    /// </summary>
    void _MouseEnter();
    /// <summary>
    /// <para>Called when the mouse pointer exits all this object's shapes. Requires <see cref="CollisionObject2D.InputPickable" /> to be <c>true</c> and at least one <see cref="CollisionObject2D.CollisionLayer" /> bit to be set. Note that moving between different shapes within a single <see cref="CollisionObject2D" /> won't cause this function to be called.</para>
    /// </summary>
    void _MouseExit();
    /// <summary>
    /// <para>Called when the mouse pointer enters any of this object's shapes or moves from one shape to another. <paramref name="shapeIdx" /> is the child index of the newly entered <see cref="Shape2D" />. Requires <see cref="CollisionObject2D.InputPickable" /> to be <c>true</c> and at least one <see cref="CollisionObject2D.CollisionLayer" /> bit to be called.</para>
    /// </summary>
    void _MouseShapeEnter(int shapeIdx);
    /// <summary>
    /// <para>Called when the mouse pointer exits any of this object's shapes. <paramref name="shapeIdx" /> is the child index of the exited <see cref="Shape2D" />. Requires <see cref="CollisionObject2D.InputPickable" /> to be <c>true</c> and at least one <see cref="CollisionObject2D.CollisionLayer" /> bit to be called.</para>
    /// </summary>
    void _MouseShapeExit(int shapeIdx);
    /// <summary>
    /// <para>Returns the object's <see cref="Rid" />.</para>
    /// </summary>
    Rid GetRid();
    /// <summary>
    /// <para>Based on <paramref name="value" />, enables or disables the specified layer in the <see cref="CollisionObject2D.CollisionLayer" />, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    void SetCollisionLayerValue(int layerNumber, bool value);
    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="CollisionObject2D.CollisionLayer" /> is enabled, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    bool GetCollisionLayerValue(int layerNumber);
    /// <summary>
    /// <para>Based on <paramref name="value" />, enables or disables the specified layer in the <see cref="CollisionObject2D.CollisionMask" />, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    void SetCollisionMaskValue(int layerNumber, bool value);
    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="CollisionObject2D.CollisionMask" /> is enabled, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    bool GetCollisionMaskValue(int layerNumber);
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
    /// <para>Sets the <see cref="Transform2D" /> of the given shape owner.</para>
    /// </summary>
    void ShapeOwnerSetTransform(uint ownerId, Transform2D transform);
    /// <summary>
    /// <para>Returns the shape owner's <see cref="Transform2D" />.</para>
    /// </summary>
    Transform2D ShapeOwnerGetTransform(uint ownerId);
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
    /// <para>If <paramref name="enable" /> is <c>true</c>, collisions for the shape owner originating from this <see cref="CollisionObject2D" /> will not be reported to collided with <see cref="CollisionObject2D" />s.</para>
    /// </summary>
    void ShapeOwnerSetOneWayCollision(uint ownerId, bool enable);
    /// <summary>
    /// <para>Returns <c>true</c> if collisions for the shape owner originating from this <see cref="CollisionObject2D" /> will not be reported to collided with <see cref="CollisionObject2D" />s.</para>
    /// </summary>
    bool IsShapeOwnerOneWayCollisionEnabled(uint ownerId);
    /// <summary>
    /// <para>Sets the <c>one_way_collision_margin</c> of the shape owner identified by given <paramref name="ownerId" /> to <paramref name="margin" /> pixels.</para>
    /// </summary>
    void ShapeOwnerSetOneWayCollisionMargin(uint ownerId, float margin);
    /// <summary>
    /// <para>Returns the <c>one_way_collision_margin</c> of the shape owner identified by given <paramref name="ownerId" />.</para>
    /// </summary>
    float GetShapeOwnerOneWayCollisionMargin(uint ownerId);
    /// <summary>
    /// <para>Adds a <see cref="Shape2D" /> to the shape owner.</para>
    /// </summary>
    void ShapeOwnerAddShape(uint ownerId, Shape2D shape);
    /// <summary>
    /// <para>Returns the number of shapes the given shape owner contains.</para>
    /// </summary>
    int ShapeOwnerGetShapeCount(uint ownerId);
    /// <summary>
    /// <para>Returns the <see cref="Shape2D" /> with the given ID from the given shape owner.</para>
    /// </summary>
    Shape2D ShapeOwnerGetShape(uint ownerId, int shapeId);
    /// <summary>
    /// <para>Returns the child index of the <see cref="Shape2D" /> with the given ID from the given shape owner.</para>
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
    /// <para>Defines the behavior in physics when <see cref="Node.ProcessMode" /> is set to <see cref="Node.ProcessModeEnum.Disabled" />. See <see cref="CollisionObject2D.DisableModeEnum" /> for more details about the different modes.</para>
    /// </summary>
    CollisionObject2D.DisableModeEnum DisableMode { get; set; }
    /// <summary>
    /// <para>The physics layers this CollisionObject2D is in. Collision objects can exist in one or more of 32 different layers. See also <see cref="CollisionObject2D.CollisionMask" />.</para>
    /// <para><b>Note:</b> Object A can detect a contact with object B only if object B is in any of the layers that object A scans. See <a href="$DOCS_URL/tutorials/physics/physics_introduction.html#collision-layers-and-masks">Collision layers and masks</a> in the documentation for more information.</para>
    /// </summary>
    uint CollisionLayer { get; set; }
    /// <summary>
    /// <para>The physics layers this CollisionObject2D scans. Collision objects can scan one or more of 32 different layers. See also <see cref="CollisionObject2D.CollisionLayer" />.</para>
    /// <para><b>Note:</b> Object A can detect a contact with object B only if object B is in any of the layers that object A scans. See <a href="$DOCS_URL/tutorials/physics/physics_introduction.html#collision-layers-and-masks">Collision layers and masks</a> in the documentation for more information.</para>
    /// </summary>
    uint CollisionMask { get; set; }
    /// <summary>
    /// <para>The priority used to solve colliding when occurring penetration. The higher the priority is, the lower the penetration into the object will be. This can for example be used to prevent the player from breaking through the boundaries of a level.</para>
    /// </summary>
    float CollisionPriority { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, this object is pickable. A pickable object can detect the mouse pointer entering/leaving, and if the mouse is inside it, report input events. Requires at least one <see cref="CollisionObject2D.CollisionLayer" /> bit to be set.</para>
    /// </summary>
    bool InputPickable { get; set; }

}