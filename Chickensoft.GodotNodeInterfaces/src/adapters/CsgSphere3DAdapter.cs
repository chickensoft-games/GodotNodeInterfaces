 namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>This node allows you to create a sphere for use with the CSG system.</para>
/// <para><b>Note:</b> CSG nodes are intended to be used for level prototyping. Creating CSG nodes has a significant CPU cost compared to creating a <see cref="MeshInstance3D" /> with a <see cref="PrimitiveMesh" />. Moving a CSG node within another CSG node also has a significant CPU cost, so it should be avoided during gameplay.</para>
/// </summary>
public class CsgSphere3DAdapter : CsgSphere3D, ICsgSphere3D {
  private readonly CsgSphere3D _node;

  public CsgSphere3DAdapter(CsgSphere3D node) => _node = node;
    /// <summary>
    /// <para>The material used to render the sphere.</para>
    /// </summary>
    public Material Material { get => _node.Material; set => _node.Material = value; }
    /// <summary>
    /// <para>Number of vertical slices for the sphere.</para>
    /// </summary>
    public int RadialSegments { get => _node.RadialSegments; set => _node.RadialSegments = value; }
    /// <summary>
    /// <para>Radius of the sphere.</para>
    /// </summary>
    public float Radius { get => _node.Radius; set => _node.Radius = value; }
    /// <summary>
    /// <para>Number of horizontal slices for the sphere.</para>
    /// </summary>
    public int Rings { get => _node.Rings; set => _node.Rings = value; }
    /// <summary>
    /// <para>If <c>true</c> the normals of the sphere are set to give a smooth effect making the sphere seem rounded. If <c>false</c> the sphere will have a flat shaded look.</para>
    /// </summary>
    public bool SmoothFaces { get => _node.SmoothFaces; set => _node.SmoothFaces = value; }

}