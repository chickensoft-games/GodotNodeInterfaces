namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class CsgTorus3DNode : CsgTorus3D, ICsgTorus3D { }

/// <summary>
/// <para>This node allows you to create a torus for use with the CSG system.</para>
/// <para><b>Note:</b> CSG nodes are intended to be used for level prototyping. Creating CSG nodes has a significant CPU cost compared to creating a <see cref="MeshInstance3D" /> with a <see cref="PrimitiveMesh" />. Moving a CSG node within another CSG node also has a significant CPU cost, so it should be avoided during gameplay.</para>
/// </summary>
public interface ICsgTorus3D : ICsgPrimitive3D {
    /// <summary>
    /// <para>The inner radius of the torus.</para>
    /// </summary>
    float InnerRadius { get; set; }
    /// <summary>
    /// <para>The material used to render the torus.</para>
    /// </summary>
    Material Material { get; set; }
    /// <summary>
    /// <para>The outer radius of the torus.</para>
    /// </summary>
    float OuterRadius { get; set; }
    /// <summary>
    /// <para>The number of edges each ring of the torus is constructed of.</para>
    /// </summary>
    int RingSides { get; set; }
    /// <summary>
    /// <para>The number of slices the torus is constructed of.</para>
    /// </summary>
    int Sides { get; set; }
    /// <summary>
    /// <para>If <c>true</c> the normals of the torus are set to give a smooth effect making the torus seem rounded. If <c>false</c> the torus will have a flat shaded look.</para>
    /// </summary>
    bool SmoothFaces { get; set; }

}