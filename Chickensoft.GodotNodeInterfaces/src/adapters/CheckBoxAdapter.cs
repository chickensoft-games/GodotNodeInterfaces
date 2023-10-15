namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para><see cref="CheckBox" /> allows the user to choose one of only two possible options. It's similar to <see cref="CheckButton" /> in functionality, but it has a different appearance. To follow established UX patterns, it's recommended to use <see cref="CheckBox" /> when toggling it has <b>no</b> immediate effect on something. For example, it could be used when toggling it will only do something once a confirmation button is pressed.</para>
/// <para>See also <see cref="BaseButton" /> which contains common properties and methods associated with this node.</para>
/// <para>When <see cref="BaseButton.ButtonGroup" /> specifies a <see cref="ButtonGroup" />, <see cref="CheckBox" /> changes its appearance to that of a radio button and uses the various <c>radio_*</c> theme properties.</para>
/// </summary>
public class CheckBoxAdapter : ButtonAdapter, ICheckBox {
  private readonly CheckBox _node;

  public CheckBoxAdapter(Node node) : base(node) {
    if (node is not CheckBox typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a CheckBox"
      );
    }
    _node = typedNode;
  }


}