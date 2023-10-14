namespace Chickensoft.GodotNodeInterfaces;

using Godot;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class CsgBox3DNode : CsgBox3D, ICsgBox3D { }

/// <summary>
/// <para>This node allows you to create a box for use with the CSG system.</para>
/// <para><b>Note:</b> CSG nodes are intended to be used for level prototyping. Creating CSG nodes has a significant CPU cost compared to creating a <see cref="MeshInstance3D" /> with a <see cref="PrimitiveMesh" />. Moving a CSG node within another CSG node also has a significant CPU cost, so it should be avoided during gameplay.</para>
/// </summary>
public interface ICsgBox3D : ICsgPrimitive3D {
    /// <summary>
    /// <para>The material used to render the box.</para>
    /// </summary>
    Material Material { get; set; }
    /// <summary>
    /// <para>The box's width, height and depth.</para>
    /// </summary>
    Vector3 Size { get; set; }

}