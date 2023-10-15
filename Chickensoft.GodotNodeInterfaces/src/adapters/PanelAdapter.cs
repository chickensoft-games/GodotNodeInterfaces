namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para><see cref="Panel" /> is a GUI control that displays a <see cref="StyleBox" />. See also <see cref="PanelContainer" />.</para>
/// </summary>
public class PanelAdapter : ControlAdapter, IPanel {
  private readonly Panel _node;

  public PanelAdapter(Node node) : base(node) {
    if (node is not Panel typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a Panel"
      );
    }
    _node = typedNode;
  }


}