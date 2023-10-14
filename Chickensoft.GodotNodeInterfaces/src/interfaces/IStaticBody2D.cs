namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>A static 2D physics body. It can't be moved by external forces or contacts, but can be moved manually by other means such as code, <see cref="AnimationMixer" />s (with <see cref="AnimationMixer.CallbackModeProcess" /> set to <see cref="AnimationMixer.AnimationCallbackModeProcess.Physics" />), and <see cref="RemoteTransform2D" />.</para>
/// <para>When <see cref="StaticBody2D" /> is moved, it is teleported to its new position without affecting other physics bodies in its path. If this is not desired, use <see cref="AnimatableBody2D" /> instead.</para>
/// <para><see cref="StaticBody2D" /> is useful for completely static objects like floors and walls, as well as moving surfaces like conveyor belts and circular revolving platforms (by using <see cref="StaticBody2D.ConstantLinearVelocity" /> and <see cref="StaticBody2D.ConstantAngularVelocity" />).</para>
/// </summary>
public interface IStaticBody2D : IPhysicsBody2D {
    /// <summary>
    /// <para>The physics material override for the body.</para>
    /// <para>If a material is assigned to this property, it will be used instead of any other physics material, such as an inherited one.</para>
    /// </summary>
    PhysicsMaterial PhysicsMaterialOverride { get; set; }
    /// <summary>
    /// <para>The body's constant linear velocity. This does not move the body, but affects touching bodies, as if it were moving.</para>
    /// </summary>
    Vector2 ConstantLinearVelocity { get; set; }
    /// <summary>
    /// <para>The body's constant angular velocity. This does not rotate the body, but affects touching bodies, as if it were rotating.</para>
    /// </summary>
    float ConstantAngularVelocity { get; set; }

}