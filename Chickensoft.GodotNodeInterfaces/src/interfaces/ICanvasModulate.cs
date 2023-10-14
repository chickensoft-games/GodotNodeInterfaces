namespace Chickensoft.GodotNodeInterfaces;

using Godot;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class CanvasModulateNode : CanvasModulate, ICanvasModulate { }

/// <summary>
/// <para><see cref="CanvasModulate" /> applies a color tint to all nodes on a canvas. Only one can be used to tint a canvas, but <see cref="CanvasLayer" />s can be used to render things independently.</para>
/// </summary>
public interface ICanvasModulate : INode2D {
    /// <summary>
    /// <para>The tint color to apply.</para>
    /// </summary>
    Color Color { get; set; }

}