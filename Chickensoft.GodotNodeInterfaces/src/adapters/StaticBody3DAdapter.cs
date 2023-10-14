namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para>A static 3D physics body. It can't be moved by external forces or contacts, but can be moved manually by other means such as code, <see cref="AnimationMixer" />s (with <see cref="AnimationMixer.CallbackModeProcess" /> set to <see cref="AnimationMixer.AnimationCallbackModeProcess.Physics" />), and <see cref="RemoteTransform3D" />.</para>
/// <para>When <see cref="StaticBody3D" /> is moved, it is teleported to its new position without affecting other physics bodies in its path. If this is not desired, use <see cref="AnimatableBody3D" /> instead.</para>
/// <para><see cref="StaticBody3D" /> is useful for completely static objects like floors and walls, as well as moving surfaces like conveyor belts and circular revolving platforms (by using <see cref="StaticBody3D.ConstantLinearVelocity" /> and <see cref="StaticBody3D.ConstantAngularVelocity" />).</para>
/// </summary>
public class StaticBody3DAdapter : PhysicsBody3DAdapter, IStaticBody3D {
  private readonly StaticBody3D _node;

  public StaticBody3DAdapter(StaticBody3D node) : base(node) { _node = node; }

    /// <summary>
    /// <para>The body's constant angular velocity. This does not rotate the body, but affects touching bodies, as if it were rotating.</para>
    /// </summary>
    public Vector3 ConstantAngularVelocity { get => _node.ConstantAngularVelocity; set => _node.ConstantAngularVelocity = value; }
    /// <summary>
    /// <para>The body's constant linear velocity. This does not move the body, but affects touching bodies, as if it were moving.</para>
    /// </summary>
    public Vector3 ConstantLinearVelocity { get => _node.ConstantLinearVelocity; set => _node.ConstantLinearVelocity = value; }
    /// <summary>
    /// <para>The physics material override for the body.</para>
    /// <para>If a material is assigned to this property, it will be used instead of any other physics material, such as an inherited one.</para>
    /// </summary>
    public PhysicsMaterial PhysicsMaterialOverride { get => _node.PhysicsMaterialOverride; set => _node.PhysicsMaterialOverride = value; }

}