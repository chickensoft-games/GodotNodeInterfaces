namespace Chickensoft.GodotNodeInterfaces;

using Godot;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class MultiMeshInstance2DNode : MultiMeshInstance2D, IMultiMeshInstance2D { }

/// <summary>
/// <para><see cref="MultiMeshInstance2D" /> is a specialized node to instance a <see cref="MultiMesh" /> resource in 2D.</para>
/// <para>Usage is the same as <see cref="MultiMeshInstance3D" />.</para>
/// </summary>
public interface IMultiMeshInstance2D : INode2D {
    /// <summary>
    /// <para>The <see cref="MultiMesh" /> that will be drawn by the <see cref="MultiMeshInstance2D" />.</para>
    /// </summary>
    MultiMesh Multimesh { get; set; }
    /// <summary>
    /// <para>The <see cref="Texture2D" /> that will be used if using the default <see cref="CanvasItemMaterial" />. Can be accessed as <c>TEXTURE</c> in CanvasItem shader.</para>
    /// </summary>
    Texture2D Texture { get; set; }

}