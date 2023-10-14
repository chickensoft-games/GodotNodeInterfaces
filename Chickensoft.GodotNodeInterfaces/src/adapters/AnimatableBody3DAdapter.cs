namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>An animatable 3D physics body. It can't be moved by external forces or contacts, but can be moved manually by other means such as code, <see cref="AnimationMixer" />s (with <see cref="AnimationMixer.CallbackModeProcess" /> set to <see cref="AnimationMixer.AnimationCallbackModeProcess.Physics" />), and <see cref="RemoteTransform3D" />.</para>
/// <para>When <see cref="AnimatableBody3D" /> is moved, its linear and angular velocity are estimated and used to affect other physics bodies in its path. This makes it useful for moving platforms, doors, and other moving objects.</para>
/// </summary>
public class AnimatableBody3DAdapter : AnimatableBody3D, IAnimatableBody3D {
  private readonly AnimatableBody3D _node;

  public AnimatableBody3DAdapter(AnimatableBody3D node) => _node = node;
    /// <summary>
    /// <para>If <c>true</c>, the body's movement will be synchronized to the physics frame. This is useful when animating movement via <see cref="AnimationPlayer" />, for example on moving platforms. Do <b>not</b> use together with <see cref="PhysicsBody3D.MoveAndCollide(Godot.Vector3,System.Boolean,System.Single,System.Boolean,System.Int32)" />.</para>
    /// </summary>
    public bool SyncToPhysics { get => _node.SyncToPhysics; set => _node.SyncToPhysics = value; }

}