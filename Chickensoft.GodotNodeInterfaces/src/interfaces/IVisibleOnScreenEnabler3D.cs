namespace Chickensoft.GodotNodeInterfaces;

using Godot;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class VisibleOnScreenEnabler3DNode : VisibleOnScreenEnabler3D, IVisibleOnScreenEnabler3D { }

/// <summary>
/// <para>The VisibleOnScreenEnabler3D will disable <see cref="RigidBody3D" /> and <see cref="AnimationPlayer" /> nodes when they are not visible. It will only affect other nodes within the same scene as the VisibleOnScreenEnabler3D itself.</para>
/// <para>If you just want to receive notifications, use <see cref="VisibleOnScreenNotifier3D" /> instead.</para>
/// <para><b>Note:</b> VisibleOnScreenEnabler3D uses an approximate heuristic for performance reasons. It doesn't take walls and other occlusion into account. The heuristic is an implementation detail and may change in future versions. If you need precise visibility checking, use another method such as adding an <see cref="Area3D" /> node as a child of a <see cref="Camera3D" /> node and/or <c>Vector3.dot</c>.</para>
/// <para><b>Note:</b> VisibleOnScreenEnabler3D will not affect nodes added after scene initialization.</para>
/// </summary>
public interface IVisibleOnScreenEnabler3D : IVisibleOnScreenNotifier3D {

    VisibleOnScreenEnabler3D.EnableModeEnum EnableMode { get; set; }

    NodePath EnableNodePath { get; set; }

}