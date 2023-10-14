namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>Parent class for various CSG primitives. It contains code and functionality that is common between them. It cannot be used directly. Instead use one of the various classes that inherit from it.</para>
/// <para><b>Note:</b> CSG nodes are intended to be used for level prototyping. Creating CSG nodes has a significant CPU cost compared to creating a <see cref="MeshInstance3D" /> with a <see cref="PrimitiveMesh" />. Moving a CSG node within another CSG node also has a significant CPU cost, so it should be avoided during gameplay.</para>
/// </summary>
public class CsgPrimitive3DAdapter : CsgShape3DAdapter, ICsgPrimitive3D {
  private readonly CsgPrimitive3D _node;

  public CsgPrimitive3DAdapter(CsgPrimitive3D node) : base(node) { _node = node; }

    /// <summary>
    /// <para>If set, the order of the vertices in each triangle are reversed resulting in the backside of the mesh being drawn.</para>
    /// </summary>
    public bool FlipFaces { get => _node.FlipFaces; set => _node.FlipFaces = value; }

}