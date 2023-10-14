namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>MeshInstance3D is a node that takes a <see cref="Mesh" /> resource and adds it to the current scenario by creating an instance of it. This is the class most often used render 3D geometry and can be used to instance a single <see cref="Mesh" /> in many places. This allows reusing geometry, which can save on resources. When a <see cref="Mesh" /> has to be instantiated more than thousands of times at close proximity, consider using a <see cref="MultiMesh" /> in a <see cref="MultiMeshInstance3D" /> instead.</para>
/// </summary>
public interface IMeshInstance3D : IGeometryInstance3D {
    /// <inheritdoc cref="M:Godot.MeshInstance3D.CreateMultipleConvexCollisions(Godot.MeshConvexDecompositionSettings)" />
    void CreateMultipleConvexCollisions();
    /// <summary>
    /// <para>Returns the number of surface override materials. This is equivalent to <see cref="Mesh.GetSurfaceCount" />. See also <see cref="M:Godot.MeshInstance3D.GetSurfaceOverrideMaterial(System.Int32)" />.</para>
    /// </summary>
    int GetSurfaceOverrideMaterialCount();
    /// <summary>
    /// <para>Sets the override <paramref name="material" /> for the specified <paramref name="surface" /> of the <see cref="Mesh" /> resource. This material is associated with this <see cref="MeshInstance3D" /> rather than with <see cref="MeshInstance3D.Mesh" />.</para>
    /// <para><b>Note:</b> This assigns the <see cref="Material" /> associated to the <see cref="MeshInstance3D" />'s Surface Material Override properties, not the material within the <see cref="Mesh" /> resource. To set the material within the <see cref="Mesh" /> resource, use <see cref="M:Godot.Mesh.SurfaceGetMaterial(System.Int32)" /> instead.</para>
    /// </summary>
    void SetSurfaceOverrideMaterial(int surface, Material material);
    /// <summary>
    /// <para>Returns the override <see cref="Material" /> for the specified <paramref name="surface" /> of the <see cref="Mesh" /> resource. See also <see cref="MeshInstance3D.GetSurfaceOverrideMaterialCount" />.</para>
    /// <para><b>Note:</b> This returns the <see cref="Material" /> associated to the <see cref="MeshInstance3D" />'s Surface Material Override properties, not the material within the <see cref="Mesh" /> resource. To get the material within the <see cref="Mesh" /> resource, use <see cref="M:Godot.Mesh.SurfaceGetMaterial(System.Int32)" /> instead.</para>
    /// </summary>
    Material GetSurfaceOverrideMaterial(int surface);
    /// <summary>
    /// <para>Returns the <see cref="Material" /> that will be used by the <see cref="Mesh" /> when drawing. This can return the <see cref="GeometryInstance3D.MaterialOverride" />, the surface override <see cref="Material" /> defined in this <see cref="MeshInstance3D" />, or the surface <see cref="Material" /> defined in the <see cref="MeshInstance3D.Mesh" />. For example, if <see cref="GeometryInstance3D.MaterialOverride" /> is used, all surfaces will return the override material.</para>
    /// <para>Returns <c>null</c> if no material is active, including when <see cref="MeshInstance3D.Mesh" /> is <c>null</c>.</para>
    /// </summary>
    Material GetActiveMaterial(int surface);
    /// <summary>
    /// <para>This helper creates a <see cref="StaticBody3D" /> child node with a <see cref="ConcavePolygonShape3D" /> collision shape calculated from the mesh geometry. It's mainly used for testing.</para>
    /// </summary>
    void CreateTrimeshCollision();
    /// <summary>
    /// <para>This helper creates a <see cref="StaticBody3D" /> child node with a <see cref="ConvexPolygonShape3D" /> collision shape calculated from the mesh geometry. It's mainly used for testing.</para>
    /// <para>If <paramref name="clean" /> is <c>true</c> (default), duplicate and interior vertices are removed automatically. You can set it to <c>false</c> to make the process faster if not needed.</para>
    /// <para>If <paramref name="simplify" /> is <c>true</c>, the geometry can be further simplified to reduce the number of vertices. Disabled by default.</para>
    /// </summary>
    void CreateConvexCollision(bool clean, bool simplify);
    /// <summary>
    /// <para>This helper creates a <see cref="StaticBody3D" /> child node with multiple <see cref="ConvexPolygonShape3D" /> collision shapes calculated from the mesh geometry via convex decomposition. The convex decomposition operation can be controlled with parameters from the optional <paramref name="settings" />.</para>
    /// </summary>
    void CreateMultipleConvexCollisions(MeshConvexDecompositionSettings settings);
    /// <summary>
    /// <para>Returns the number of blend shapes available. Produces an error if <see cref="MeshInstance3D.Mesh" /> is <c>null</c>.</para>
    /// </summary>
    int GetBlendShapeCount();
    /// <summary>
    /// <para>Returns the index of the blend shape with the given <paramref name="name" />. Returns <c>-1</c> if no blend shape with this name exists, including when <see cref="MeshInstance3D.Mesh" /> is <c>null</c>.</para>
    /// </summary>
    int FindBlendShapeByName(StringName name);
    /// <summary>
    /// <para>Returns the value of the blend shape at the given <paramref name="blendShapeIdx" />. Returns <c>0.0</c> and produces an error if <see cref="MeshInstance3D.Mesh" /> is <c>null</c> or doesn't have a blend shape at that index.</para>
    /// </summary>
    float GetBlendShapeValue(int blendShapeIdx);
    /// <summary>
    /// <para>Sets the value of the blend shape at <paramref name="blendShapeIdx" /> to <paramref name="value" />. Produces an error if <see cref="MeshInstance3D.Mesh" /> is <c>null</c> or doesn't have a blend shape at that index.</para>
    /// </summary>
    void SetBlendShapeValue(int blendShapeIdx, float value);
    /// <summary>
    /// <para>This helper creates a <see cref="MeshInstance3D" /> child node with gizmos at every vertex calculated from the mesh geometry. It's mainly used for testing.</para>
    /// </summary>
    void CreateDebugTangents();
    /// <summary>
    /// <para>The <see cref="Mesh" /> resource for the instance.</para>
    /// </summary>
    Mesh Mesh { get; set; }
    /// <summary>
    /// <para>The <see cref="Skin" /> to be used by this instance.</para>
    /// </summary>
    Skin Skin { get; set; }
    /// <summary>
    /// <para><see cref="NodePath" /> to the <see cref="Skeleton3D" /> associated with the instance.</para>
    /// </summary>
    NodePath Skeleton { get; set; }

}