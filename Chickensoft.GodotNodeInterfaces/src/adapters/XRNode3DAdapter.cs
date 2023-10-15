namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>This node can be bound to a specific pose of a <see cref="XRPositionalTracker" /> and will automatically have its <see cref="Node3D.Transform" /> updated by the <see cref="XRServer" />. Nodes of this type must be added as children of the <see cref="XROrigin3D" /> node.</para>
/// </summary>
public class XRNode3DAdapter : Node3DAdapter, IXRNode3D {
  private readonly XRNode3D _node;

  public XRNode3DAdapter(Node node) : base(node) {
    if (node is not XRNode3D typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a XRNode3D"
      );
    }
    _node = typedNode;
  }

    /// <summary>
    /// <para>Returns <c>true</c> if the <see cref="XRNode3D.Tracker" /> has current tracking data for the <see cref="XRNode3D.Pose" /> being tracked.</para>
    /// </summary>
    public bool GetHasTrackingData() => _node.GetHasTrackingData();
    /// <summary>
    /// <para>Returns <c>true</c> if the <see cref="XRNode3D.Tracker" /> has been registered and the <see cref="XRNode3D.Pose" /> is being tracked.</para>
    /// </summary>
    public bool GetIsActive() => _node.GetIsActive();
    /// <summary>
    /// <para>Returns the <see cref="XRPose" /> containing the current state of the pose being tracked. This gives access to additional properties of this pose.</para>
    /// </summary>
    public XRPose GetPose() => _node.GetPose();
    /// <summary>
    /// <para>The name of the pose we're bound to. Which poses a tracker supports is not known during design time.</para>
    /// <para>Godot defines number of standard pose names such as <c>aim</c> and <c>grip</c> but other may be configured within a given <see cref="XRInterface" />.</para>
    /// </summary>
    public StringName Pose { get => _node.Pose; set => _node.Pose = value; }
    /// <summary>
    /// <para>The name of the tracker we're bound to. Which trackers are available is not known during design time.</para>
    /// <para>Godot defines a number of standard trackers such as <c>left_hand</c> and <c>right_hand</c> but others may be configured within a given <see cref="XRInterface" />.</para>
    /// </summary>
    public StringName Tracker { get => _node.Tracker; set => _node.Tracker = value; }
    /// <summary>
    /// <para>Triggers a haptic pulse on a device associated with this interface.</para>
    /// <para><paramref name="actionName" /> is the name of the action for this pulse.</para>
    /// </summary>
    public void TriggerHapticPulse(string actionName, double frequency, double amplitude, double durationSec, double delaySec) => _node.TriggerHapticPulse(actionName, frequency, amplitude, durationSec, delaySec);

}