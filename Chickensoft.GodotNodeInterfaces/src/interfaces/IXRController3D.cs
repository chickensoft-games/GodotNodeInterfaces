namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class XRController3DNode : XRController3D, IXRController3D { }

/// <summary>
/// <para>This is a helper spatial node that is linked to the tracking of controllers. It also offers several handy passthroughs to the state of buttons and such on the controllers.</para>
/// <para>Controllers are linked by their ID. You can create controller nodes before the controllers are available. If your game always uses two controllers (one for each hand), you can predefine the controllers with ID 1 and 2; they will become active as soon as the controllers are identified. If you expect additional controllers to be used, you should react to the signals and add XRController3D nodes to your scene.</para>
/// <para>The position of the controller node is automatically updated by the <see cref="XRServer" />. This makes this node ideal to add child nodes to visualize the controller.</para>
/// <para>As many XR runtimes now use a configurable action map all inputs are named.</para>
/// </summary>
public interface IXRController3D : IXRNode3D {
    /// <summary>
    /// <para>Returns a numeric value for the input with the given <paramref name="name" />. This is used for triggers and grip sensors.</para>
    /// </summary>
    float GetFloat(StringName name);
    /// <summary>
    /// <para>Returns a <see cref="Variant" /> for the input with the given <paramref name="name" />. This works for any input type, the variant will be typed according to the actions configuration.</para>
    /// </summary>
    Variant GetInput(StringName name);
    /// <summary>
    /// <para>Returns the hand holding this controller, if known. See <see cref="XRPositionalTracker.TrackerHand" />.</para>
    /// </summary>
    XRPositionalTracker.TrackerHand GetTrackerHand();
    /// <summary>
    /// <para>Returns a <see cref="Vector2" /> for the input with the given <paramref name="name" />. This is used for thumbsticks and thumbpads found on many controllers.</para>
    /// </summary>
    Vector2 GetVector2(StringName name);
    /// <summary>
    /// <para>Returns <c>true</c> if the button with the given <paramref name="name" /> is pressed.</para>
    /// </summary>
    bool IsButtonPressed(StringName name);

}