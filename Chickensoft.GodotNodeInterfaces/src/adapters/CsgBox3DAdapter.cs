namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para>This node allows you to create a box for use with the CSG system.</para>
/// <para><b>Note:</b> CSG nodes are intended to be used for level prototyping. Creating CSG nodes has a significant CPU cost compared to creating a <see cref="MeshInstance3D" /> with a <see cref="PrimitiveMesh" />. Moving a CSG node within another CSG node also has a significant CPU cost, so it should be avoided during gameplay.</para>
/// </summary>
public class CsgBox3DAdapter : CsgPrimitive3DAdapter, ICsgBox3D {
  private readonly CsgBox3D _node;

  public CsgBox3DAdapter(CsgBox3D node) : base(node) { _node = node; }

    /// <summary>
    /// <para>The material used to render the box.</para>
    /// </summary>
    public Material Material { get => _node.Material; set => _node.Material = value; }
    /// <summary>
    /// <para>The box's width, height and depth.</para>
    /// </summary>
    public Vector3 Size { get => _node.Size; set => _node.Size = value; }

}