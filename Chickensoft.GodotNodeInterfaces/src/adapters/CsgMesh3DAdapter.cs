 namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para>This CSG node allows you to use any mesh resource as a CSG shape, provided it is closed, does not self-intersect, does not contain internal faces and has no edges that connect to more than two faces. See also <see cref="CsgPolygon3D" /> for drawing 2D extruded polygons to be used as CSG nodes.</para>
/// <para><b>Note:</b> CSG nodes are intended to be used for level prototyping. Creating CSG nodes has a significant CPU cost compared to creating a <see cref="MeshInstance3D" /> with a <see cref="PrimitiveMesh" />. Moving a CSG node within another CSG node also has a significant CPU cost, so it should be avoided during gameplay.</para>
/// </summary>
public class CsgMesh3DAdapter : CsgMesh3D, ICsgMesh3D {
  private readonly CsgMesh3D _node;

  public CsgMesh3DAdapter(CsgMesh3D node) => _node = node;
    /// <summary>
    /// <para>The <see cref="Material" /> used in drawing the CSG shape.</para>
    /// </summary>
    public Material Material { get => _node.Material; set => _node.Material = value; }
    /// <summary>
    /// <para>The <see cref="Mesh" /> resource to use as a CSG shape.</para>
    /// <para><b>Note:</b> When using an <see cref="ArrayMesh" />, all vertex attributes except <see cref="Mesh.ArrayType.Vertex" />, <see cref="Mesh.ArrayType.Normal" /> and <see cref="Mesh.ArrayType.TexUV" /> are left unused. Only <see cref="Mesh.ArrayType.Vertex" /> and <see cref="Mesh.ArrayType.TexUV" /> will be passed to the GPU.</para>
    /// <para><see cref="Mesh.ArrayType.Normal" /> is only used to determine which faces require the use of flat shading. By default, CSGMesh will ignore the mesh's vertex normals, recalculate them for each vertex and use a smooth shader. If a flat shader is required for a face, ensure that all vertex normals of the face are approximately equal.</para>
    /// </summary>
    public Mesh Mesh { get => _node.Mesh; set => _node.Mesh = value; }

}