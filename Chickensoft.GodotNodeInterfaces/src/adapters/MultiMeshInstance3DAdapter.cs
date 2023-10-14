namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para><see cref="MultiMeshInstance3D" /> is a specialized node to instance <see cref="GeometryInstance3D" />s based on a <see cref="MultiMesh" /> resource.</para>
/// <para>This is useful to optimize the rendering of a high number of instances of a given mesh (for example trees in a forest or grass strands).</para>
/// </summary>
public class MultiMeshInstance3DAdapter : GeometryInstance3DAdapter, IMultiMeshInstance3D {
  private readonly MultiMeshInstance3D _node;

  public MultiMeshInstance3DAdapter(MultiMeshInstance3D node) : base(node) { _node = node; }

    /// <summary>
    /// <para>The <see cref="MultiMesh" /> resource that will be used and shared among all instances of the <see cref="MultiMeshInstance3D" />.</para>
    /// </summary>
    public MultiMesh Multimesh { get => _node.Multimesh; set => _node.Multimesh = value; }

}