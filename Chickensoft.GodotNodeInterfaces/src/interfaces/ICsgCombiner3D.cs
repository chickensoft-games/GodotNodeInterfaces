namespace Chickensoft.GodotNodeInterfaces;

using Godot;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class CsgCombiner3DNode : CsgCombiner3D, ICsgCombiner3D { }

/// <summary>
/// <para>For complex arrangements of shapes, it is sometimes needed to add structure to your CSG nodes. The CSGCombiner3D node allows you to create this structure. The node encapsulates the result of the CSG operations of its children. In this way, it is possible to do operations on one set of shapes that are children of one CSGCombiner3D node, and a set of separate operations on a second set of shapes that are children of a second CSGCombiner3D node, and then do an operation that takes the two end results as its input to create the final shape.</para>
/// <para><b>Note:</b> CSG nodes are intended to be used for level prototyping. Creating CSG nodes has a significant CPU cost compared to creating a <see cref="MeshInstance3D" /> with a <see cref="PrimitiveMesh" />. Moving a CSG node within another CSG node also has a significant CPU cost, so it should be avoided during gameplay.</para>
/// </summary>
public interface ICsgCombiner3D : ICsgShape3D {

}