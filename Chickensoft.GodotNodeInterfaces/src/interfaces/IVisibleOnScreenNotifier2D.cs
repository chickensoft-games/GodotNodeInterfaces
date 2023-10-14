namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class VisibleOnScreenNotifier2DNode : VisibleOnScreenNotifier2D, IVisibleOnScreenNotifier2D { }

/// <summary>
/// <para>The VisibleOnScreenNotifier2D detects when it is visible on the screen. It also notifies when its bounding rectangle enters or exits the screen or a viewport.</para>
/// <para>If you want nodes to be disabled automatically when they exit the screen, use <see cref="VisibleOnScreenEnabler2D" /> instead.</para>
/// <para><b>Note:</b> VisibleOnScreenNotifier2D uses the render culling code to determine whether it's visible on screen, which also means that its <see cref="CanvasItem.Visible" /> must be <c>true</c> to work correctly.</para>
/// </summary>
public interface IVisibleOnScreenNotifier2D : INode2D {
    /// <summary>
    /// <para>If <c>true</c>, the bounding rectangle is on the screen.</para>
    /// <para><b>Note:</b> It takes one frame for the node's visibility to be assessed once added to the scene tree, so this method will return <c>false</c> right after it is instantiated, even if it will be on screen in the draw pass.</para>
    /// </summary>
    bool IsOnScreen();
    /// <summary>
    /// <para>The VisibleOnScreenNotifier2D's bounding rectangle.</para>
    /// </summary>
    Rect2 Rect { get; set; }

}