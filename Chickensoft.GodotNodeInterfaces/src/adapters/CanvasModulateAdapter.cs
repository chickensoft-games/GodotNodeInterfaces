namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para><see cref="CanvasModulate" /> applies a color tint to all nodes on a canvas. Only one can be used to tint a canvas, but <see cref="CanvasLayer" />s can be used to render things independently.</para>
/// </summary>
public class CanvasModulateAdapter : Node2DAdapter, ICanvasModulate {
  private readonly CanvasModulate _node;

  public CanvasModulateAdapter(Node node) : base(node) {
    if (node is not CanvasModulate typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a CanvasModulate"
      );
    }
    _node = typedNode;
  }

    /// <summary>
    /// <para>The tint color to apply.</para>
    /// </summary>
    public Color Color { get => _node.Color; set => _node.Color = value; }

}