namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>This node allows you to create a torus for use with the CSG system.</para>
/// <para><b>Note:</b> CSG nodes are intended to be used for level prototyping. Creating CSG nodes has a significant CPU cost compared to creating a <see cref="MeshInstance3D" /> with a <see cref="PrimitiveMesh" />. Moving a CSG node within another CSG node also has a significant CPU cost, so it should be avoided during gameplay.</para>
/// </summary>
public class CsgTorus3DAdapter : CsgTorus3D, ICsgTorus3D {
  private readonly CsgTorus3D _node;

  public CsgTorus3DAdapter(CsgTorus3D node) => _node = node;
    /// <summary>
    /// <para>The inner radius of the torus.</para>
    /// </summary>
    public float InnerRadius { get => _node.InnerRadius; set => _node.InnerRadius = value; }
    /// <summary>
    /// <para>The material used to render the torus.</para>
    /// </summary>
    public Material Material { get => _node.Material; set => _node.Material = value; }
    /// <summary>
    /// <para>The outer radius of the torus.</para>
    /// </summary>
    public float OuterRadius { get => _node.OuterRadius; set => _node.OuterRadius = value; }
    /// <summary>
    /// <para>The number of edges each ring of the torus is constructed of.</para>
    /// </summary>
    public int RingSides { get => _node.RingSides; set => _node.RingSides = value; }
    /// <summary>
    /// <para>The number of slices the torus is constructed of.</para>
    /// </summary>
    public int Sides { get => _node.Sides; set => _node.Sides = value; }
    /// <summary>
    /// <para>If <c>true</c> the normals of the torus are set to give a smooth effect making the torus seem rounded. If <c>false</c> the torus will have a flat shaded look.</para>
    /// </summary>
    public bool SmoothFaces { get => _node.SmoothFaces; set => _node.SmoothFaces = value; }

}