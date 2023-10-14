namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>The VisibleOnScreenNotifier3D detects when it is visible on the screen. It also notifies when its bounding rectangle enters or exits the screen or a <see cref="Camera3D" />'s view.</para>
/// <para>If you want nodes to be disabled automatically when they exit the screen, use <see cref="VisibleOnScreenEnabler3D" /> instead.</para>
/// <para><b>Note:</b> VisibleOnScreenNotifier3D uses the render culling code to determine whether it's visible on screen, which also means that its <see cref="Node3D.Visible" /> must be <c>true</c> to work correctly.</para>
/// </summary>
public interface IVisibleOnScreenNotifier3D : IVisualInstance3D {
    /// <summary>
    /// <para>If <c>true</c>, the bounding box is on the screen.</para>
    /// <para><b>Note:</b> It takes one frame for the node's visibility to be assessed once added to the scene tree, so this method will return <c>false</c> right after it is instantiated, even if it will be on screen in the draw pass.</para>
    /// </summary>
    bool IsOnScreen();
    /// <summary>
    /// <para>The VisibleOnScreenNotifier3D's bounding box.</para>
    /// </summary>
    Aabb Aabb { get; set; }

}