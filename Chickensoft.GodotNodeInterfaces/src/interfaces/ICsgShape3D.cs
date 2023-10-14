namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
using Godot.Collections;


/// <summary>
/// <para>This is the CSG base class that provides CSG operation support to the various CSG nodes in Godot.</para>
/// <para><b>Note:</b> CSG nodes are intended to be used for level prototyping. Creating CSG nodes has a significant CPU cost compared to creating a <see cref="MeshInstance3D" /> with a <see cref="PrimitiveMesh" />. Moving a CSG node within another CSG node also has a significant CPU cost, so it should be avoided during gameplay.</para>
/// </summary>
public interface ICsgShape3D : IGeometryInstance3D {
    /// <summary>
    /// <para>Calculate tangents for the CSG shape which allows the use of normal maps. This is only applied on the root shape, this setting is ignored on any child.</para>
    /// </summary>
    bool CalculateTangents { get; set; }
    /// <summary>
    /// <para>The physics layers this area is in.</para>
    /// <para>Collidable objects can exist in any of 32 different layers. These layers work like a tagging system, and are not visual. A collidable can use these layers to select with which objects it can collide, using the collision_mask property.</para>
    /// <para>A contact is detected if object A is in any of the layers that object B scans, or object B is in any layer scanned by object A. See <a href="$DOCS_URL/tutorials/physics/physics_introduction.html#collision-layers-and-masks">Collision layers and masks</a> in the documentation for more information.</para>
    /// </summary>
    uint CollisionLayer { get; set; }
    /// <summary>
    /// <para>The physics layers this CSG shape scans for collisions. Only effective if <see cref="CsgShape3D.UseCollision" /> is <c>true</c>. See <a href="$DOCS_URL/tutorials/physics/physics_introduction.html#collision-layers-and-masks">Collision layers and masks</a> in the documentation for more information.</para>
    /// </summary>
    uint CollisionMask { get; set; }
    /// <summary>
    /// <para>The priority used to solve colliding when occurring penetration. Only effective if <see cref="CsgShape3D.UseCollision" /> is <c>true</c>. The higher the priority is, the lower the penetration into the object will be. This can for example be used to prevent the player from breaking through the boundaries of a level.</para>
    /// </summary>
    float CollisionPriority { get; set; }
    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="CsgShape3D.CollisionLayer" /> is enabled, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    bool GetCollisionLayerValue(int layerNumber);
    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="CsgShape3D.CollisionMask" /> is enabled, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    bool GetCollisionMaskValue(int layerNumber);
    /// <summary>
    /// <para>Returns an <see cref="Collections.Array" /> with two elements, the first is the <see cref="Transform3D" /> of this node and the second is the root <see cref="Mesh" /> of this node. Only works when this node is the root shape.</para>
    /// </summary>
    Godot.Collections.Array GetMeshes();
    /// <summary>
    /// <para>Returns <c>true</c> if this is a root shape and is thus the object that is rendered.</para>
    /// </summary>
    bool IsRootShape();
    /// <summary>
    /// <para>The operation that is performed on this shape. This is ignored for the first CSG child node as the operation is between this node and the previous child of this nodes parent.</para>
    /// </summary>
    CsgShape3D.OperationEnum Operation { get; set; }
    /// <summary>
    /// <para>Based on <paramref name="value" />, enables or disables the specified layer in the <see cref="CsgShape3D.CollisionLayer" />, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    void SetCollisionLayerValue(int layerNumber, bool value);
    /// <summary>
    /// <para>Based on <paramref name="value" />, enables or disables the specified layer in the <see cref="CsgShape3D.CollisionMask" />, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    void SetCollisionMaskValue(int layerNumber, bool value);
    /// <summary>
    /// <para>Snap makes the mesh vertices snap to a given distance so that the faces of two meshes can be perfectly aligned. A lower value results in greater precision but may be harder to adjust.</para>
    /// </summary>
    float Snap { get; set; }
    /// <summary>
    /// <para>Adds a collision shape to the physics engine for our CSG shape. This will always act like a static body. Note that the collision shape is still active even if the CSG shape itself is hidden. See also <see cref="CsgShape3D.CollisionMask" /> and <see cref="CsgShape3D.CollisionPriority" />.</para>
    /// </summary>
    bool UseCollision { get; set; }

}