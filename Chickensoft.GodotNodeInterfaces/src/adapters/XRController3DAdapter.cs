namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>This is a helper spatial node that is linked to the tracking of controllers. It also offers several handy passthroughs to the state of buttons and such on the controllers.</para>
/// <para>Controllers are linked by their ID. You can create controller nodes before the controllers are available. If your game always uses two controllers (one for each hand), you can predefine the controllers with ID 1 and 2; they will become active as soon as the controllers are identified. If you expect additional controllers to be used, you should react to the signals and add XRController3D nodes to your scene.</para>
/// <para>The position of the controller node is automatically updated by the <see cref="XRServer" />. This makes this node ideal to add child nodes to visualize the controller.</para>
/// <para>As many XR runtimes now use a configurable action map all inputs are named.</para>
/// </summary>
public class XRController3DAdapter : XRNode3DAdapter, IXRController3D {
  private readonly XRController3D _node;

  public XRController3DAdapter(Node node) : base(node) {
    if (node is not XRController3D typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a XRController3D"
      );
    }
    _node = typedNode;
  }

    /// <summary>
    /// <para>Returns a numeric value for the input with the given <paramref name="name" />. This is used for triggers and grip sensors.</para>
    /// </summary>
    public float GetFloat(StringName name) => _node.GetFloat(name);
    /// <summary>
    /// <para>Returns a <see cref="Variant" /> for the input with the given <paramref name="name" />. This works for any input type, the variant will be typed according to the actions configuration.</para>
    /// </summary>
    public Variant GetInput(StringName name) => _node.GetInput(name);
    /// <summary>
    /// <para>Returns the hand holding this controller, if known. See <see cref="XRPositionalTracker.TrackerHand" />.</para>
    /// </summary>
    public XRPositionalTracker.TrackerHand GetTrackerHand() => _node.GetTrackerHand();
    /// <summary>
    /// <para>Returns a <see cref="Vector2" /> for the input with the given <paramref name="name" />. This is used for thumbsticks and thumbpads found on many controllers.</para>
    /// </summary>
    public Vector2 GetVector2(StringName name) => _node.GetVector2(name);
    /// <summary>
    /// <para>Returns <c>true</c> if the button with the given <paramref name="name" /> is pressed.</para>
    /// </summary>
    public bool IsButtonPressed(StringName name) => _node.IsButtonPressed(name);

}