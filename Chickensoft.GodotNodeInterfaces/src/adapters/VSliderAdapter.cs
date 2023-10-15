namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para>A vertical slider, used to adjust a value by moving a grabber along a vertical axis. It is a <see cref="Range" />-based control and goes from bottom (min) to top (max). Note that this direction is the opposite of <see cref="VScrollBar" />'s.</para>
/// </summary>
public class VSliderAdapter : SliderAdapter, IVSlider {
  private readonly VSlider _node;

  public VSliderAdapter(Node node) : base(node) {
    if (node is not VSlider typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a VSlider"
      );
    }
    _node = typedNode;
  }


}