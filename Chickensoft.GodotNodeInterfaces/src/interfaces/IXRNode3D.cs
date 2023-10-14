namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>This node can be bound to a specific pose of a <see cref="XRPositionalTracker" /> and will automatically have its <see cref="Node3D.Transform" /> updated by the <see cref="XRServer" />. Nodes of this type must be added as children of the <see cref="XROrigin3D" /> node.</para>
/// </summary>
public interface IXRNode3D : INode3D {
    /// <summary>
    /// <para>Returns <c>true</c> if the <see cref="XRNode3D.Tracker" /> has current tracking data for the <see cref="XRNode3D.Pose" /> being tracked.</para>
    /// </summary>
    bool GetHasTrackingData();
    /// <summary>
    /// <para>Returns <c>true</c> if the <see cref="XRNode3D.Tracker" /> has been registered and the <see cref="XRNode3D.Pose" /> is being tracked.</para>
    /// </summary>
    bool GetIsActive();
    /// <summary>
    /// <para>Returns the <see cref="XRPose" /> containing the current state of the pose being tracked. This gives access to additional properties of this pose.</para>
    /// </summary>
    XRPose GetPose();
    /// <summary>
    /// <para>The name of the pose we're bound to. Which poses a tracker supports is not known during design time.</para>
    /// <para>Godot defines number of standard pose names such as <c>aim</c> and <c>grip</c> but other may be configured within a given <see cref="XRInterface" />.</para>
    /// </summary>
    StringName Pose { get; set; }
    /// <summary>
    /// <para>The name of the tracker we're bound to. Which trackers are available is not known during design time.</para>
    /// <para>Godot defines a number of standard trackers such as <c>left_hand</c> and <c>right_hand</c> but others may be configured within a given <see cref="XRInterface" />.</para>
    /// </summary>
    StringName Tracker { get; set; }
    /// <summary>
    /// <para>Triggers a haptic pulse on a device associated with this interface.</para>
    /// <para><paramref name="actionName" /> is the name of the action for this pulse.</para>
    /// </summary>
    void TriggerHapticPulse(string actionName, double frequency, double amplitude, double durationSec, double delaySec);

}