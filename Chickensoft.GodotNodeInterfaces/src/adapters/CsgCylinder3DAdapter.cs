namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>This node allows you to create a cylinder (or cone) for use with the CSG system.</para>
/// <para><b>Note:</b> CSG nodes are intended to be used for level prototyping. Creating CSG nodes has a significant CPU cost compared to creating a <see cref="MeshInstance3D" /> with a <see cref="PrimitiveMesh" />. Moving a CSG node within another CSG node also has a significant CPU cost, so it should be avoided during gameplay.</para>
/// </summary>
public class CsgCylinder3DAdapter : CsgCylinder3D, ICsgCylinder3D {
  private readonly CsgCylinder3D _node;

  public CsgCylinder3DAdapter(CsgCylinder3D node) => _node = node;
    /// <summary>
    /// <para>If <c>true</c> a cone is created, the <see cref="CsgCylinder3D.Radius" /> will only apply to one side.</para>
    /// </summary>
    public bool Cone { get => _node.Cone; set => _node.Cone = value; }
    /// <summary>
    /// <para>The height of the cylinder.</para>
    /// </summary>
    public float Height { get => _node.Height; set => _node.Height = value; }
    /// <summary>
    /// <para>The material used to render the cylinder.</para>
    /// </summary>
    public Material Material { get => _node.Material; set => _node.Material = value; }
    /// <summary>
    /// <para>The radius of the cylinder.</para>
    /// </summary>
    public float Radius { get => _node.Radius; set => _node.Radius = value; }
    /// <summary>
    /// <para>The number of sides of the cylinder, the higher this number the more detail there will be in the cylinder.</para>
    /// </summary>
    public int Sides { get => _node.Sides; set => _node.Sides = value; }
    /// <summary>
    /// <para>If <c>true</c> the normals of the cylinder are set to give a smooth effect making the cylinder seem rounded. If <c>false</c> the cylinder will have a flat shaded look.</para>
    /// </summary>
    public bool SmoothFaces { get => _node.SmoothFaces; set => _node.SmoothFaces = value; }

}