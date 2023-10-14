namespace Chickensoft.GodotNodeInterfaces;

using Godot;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class MultiMeshInstance3DNode : MultiMeshInstance3D, IMultiMeshInstance3D { }

/// <summary>
/// <para><see cref="MultiMeshInstance3D" /> is a specialized node to instance <see cref="GeometryInstance3D" />s based on a <see cref="MultiMesh" /> resource.</para>
/// <para>This is useful to optimize the rendering of a high number of instances of a given mesh (for example trees in a forest or grass strands).</para>
/// </summary>
public interface IMultiMeshInstance3D : IGeometryInstance3D {
    /// <summary>
    /// <para>The <see cref="MultiMesh" /> resource that will be used and shared among all instances of the <see cref="MultiMeshInstance3D" />.</para>
    /// </summary>
    MultiMesh Multimesh { get; set; }

}