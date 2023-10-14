namespace Chickensoft.GodotNodeInterfaces;

using Godot;


/// <summary>
/// <para>Node used for displaying a <see cref="Mesh" /> in 2D. A <see cref="MeshInstance2D" /> can be automatically created from an existing <see cref="Sprite2D" /> via a tool in the editor toolbar. Select the <see cref="Sprite2D" /> node, then choose <b>Sprite2D &gt; Convert to MeshInstance2D</b> at the top of the 2D editor viewport.</para>
/// </summary>
public interface IMeshInstance2D : INode2D {
    /// <summary>
    /// <para>The <see cref="Mesh" /> that will be drawn by the <see cref="MeshInstance2D" />.</para>
    /// </summary>
    Mesh Mesh { get; set; }
    /// <summary>
    /// <para>The <see cref="Texture2D" /> that will be used if using the default <see cref="CanvasItemMaterial" />. Can be accessed as <c>TEXTURE</c> in CanvasItem shader.</para>
    /// </summary>
    Texture2D Texture { get; set; }

}