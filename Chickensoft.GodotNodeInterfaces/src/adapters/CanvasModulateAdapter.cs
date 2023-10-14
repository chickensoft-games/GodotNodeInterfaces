namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para><see cref="CanvasModulate" /> applies a color tint to all nodes on a canvas. Only one can be used to tint a canvas, but <see cref="CanvasLayer" />s can be used to render things independently.</para>
/// </summary>
public class CanvasModulateAdapter : CanvasModulate, ICanvasModulate {
  private readonly CanvasModulate _node;

  public CanvasModulateAdapter(CanvasModulate node) => _node = node;
    /// <summary>
    /// <para>The tint color to apply.</para>
    /// </summary>
    public Color Color { get => _node.Color; set => _node.Color = value; }

}