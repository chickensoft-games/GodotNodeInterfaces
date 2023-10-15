namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para><see cref="MultiMeshInstance2D" /> is a specialized node to instance a <see cref="MultiMesh" /> resource in 2D.</para>
/// <para>Usage is the same as <see cref="MultiMeshInstance3D" />.</para>
/// </summary>
public class MultiMeshInstance2DAdapter : Node2DAdapter, IMultiMeshInstance2D {
  private readonly MultiMeshInstance2D _node;

  public MultiMeshInstance2DAdapter(Node node) : base(node) {
    if (node is not MultiMeshInstance2D typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a MultiMeshInstance2D"
      );
    }
    _node = typedNode;
  }

    /// <summary>
    /// <para>The <see cref="MultiMesh" /> that will be drawn by the <see cref="MultiMeshInstance2D" />.</para>
    /// </summary>
    public MultiMesh Multimesh { get => _node.Multimesh; set => _node.Multimesh = value; }
    /// <summary>
    /// <para>The <see cref="Texture2D" /> that will be used if using the default <see cref="CanvasItemMaterial" />. Can be accessed as <c>TEXTURE</c> in CanvasItem shader.</para>
    /// </summary>
    public Texture2D Texture { get => _node.Texture; set => _node.Texture = value; }

}