namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para>Node used for displaying a <see cref="Mesh" /> in 2D. A <see cref="MeshInstance2D" /> can be automatically created from an existing <see cref="Sprite2D" /> via a tool in the editor toolbar. Select the <see cref="Sprite2D" /> node, then choose <b>Sprite2D &gt; Convert to MeshInstance2D</b> at the top of the 2D editor viewport.</para>
/// </summary>
public class MeshInstance2DAdapter : Node2DAdapter, IMeshInstance2D {
  private readonly MeshInstance2D _node;

  public MeshInstance2DAdapter(MeshInstance2D node) : base(node) { _node = node; }

    /// <summary>
    /// <para>The <see cref="Mesh" /> that will be drawn by the <see cref="MeshInstance2D" />.</para>
    /// </summary>
    public Mesh Mesh { get => _node.Mesh; set => _node.Mesh = value; }
    /// <summary>
    /// <para>The <see cref="Texture2D" /> that will be used if using the default <see cref="CanvasItemMaterial" />. Can be accessed as <c>TEXTURE</c> in CanvasItem shader.</para>
    /// </summary>
    public Texture2D Texture { get => _node.Texture; set => _node.Texture = value; }

}