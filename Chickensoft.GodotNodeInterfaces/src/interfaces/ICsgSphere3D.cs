namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class CsgSphere3DNode : CsgSphere3D, ICsgSphere3D { }

/// <summary>
/// <para>This node allows you to create a sphere for use with the CSG system.</para>
/// <para><b>Note:</b> CSG nodes are intended to be used for level prototyping. Creating CSG nodes has a significant CPU cost compared to creating a <see cref="MeshInstance3D" /> with a <see cref="PrimitiveMesh" />. Moving a CSG node within another CSG node also has a significant CPU cost, so it should be avoided during gameplay.</para>
/// </summary>
public interface ICsgSphere3D : ICsgPrimitive3D {
    /// <summary>
    /// <para>The material used to render the sphere.</para>
    /// </summary>
    Material Material { get; set; }
    /// <summary>
    /// <para>Number of vertical slices for the sphere.</para>
    /// </summary>
    int RadialSegments { get; set; }
    /// <summary>
    /// <para>Radius of the sphere.</para>
    /// </summary>
    float Radius { get; set; }
    /// <summary>
    /// <para>Number of horizontal slices for the sphere.</para>
    /// </summary>
    int Rings { get; set; }
    /// <summary>
    /// <para>If <c>true</c> the normals of the sphere are set to give a smooth effect making the sphere seem rounded. If <c>false</c> the sphere will have a flat shaded look.</para>
    /// </summary>
    bool SmoothFaces { get; set; }

}