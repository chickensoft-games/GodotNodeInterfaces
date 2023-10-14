 namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>The VisibleOnScreenNotifier2D detects when it is visible on the screen. It also notifies when its bounding rectangle enters or exits the screen or a viewport.</para>
/// <para>If you want nodes to be disabled automatically when they exit the screen, use <see cref="VisibleOnScreenEnabler2D" /> instead.</para>
/// <para><b>Note:</b> VisibleOnScreenNotifier2D uses the render culling code to determine whether it's visible on screen, which also means that its <see cref="CanvasItem.Visible" /> must be <c>true</c> to work correctly.</para>
/// </summary>
public class VisibleOnScreenNotifier2DAdapter : VisibleOnScreenNotifier2D, IVisibleOnScreenNotifier2D {
  private readonly VisibleOnScreenNotifier2D _node;

  public VisibleOnScreenNotifier2DAdapter(VisibleOnScreenNotifier2D node) => _node = node;
    /// <summary>
    /// <para>If <c>true</c>, the bounding rectangle is on the screen.</para>
    /// <para><b>Note:</b> It takes one frame for the node's visibility to be assessed once added to the scene tree, so this method will return <c>false</c> right after it is instantiated, even if it will be on screen in the draw pass.</para>
    /// </summary>
    public bool IsOnScreen() => _node.IsOnScreen();
    /// <summary>
    /// <para>The VisibleOnScreenNotifier2D's bounding rectangle.</para>
    /// </summary>
    public Rect2 Rect { get => _node.Rect; set => _node.Rect = value; }

}