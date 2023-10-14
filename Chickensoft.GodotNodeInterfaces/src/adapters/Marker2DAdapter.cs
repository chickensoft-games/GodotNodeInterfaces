 namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>Generic 2D position hint for editing. It's just like a plain <see cref="Node2D" />, but it displays as a cross in the 2D editor at all times. You can set the cross' visual size by using the gizmo in the 2D editor while the node is selected.</para>
/// </summary>
public class Marker2DAdapter : Marker2D, IMarker2D {
  private readonly Marker2D _node;

  public Marker2DAdapter(Marker2D node) => _node = node;
    /// <summary>
    /// <para>Size of the gizmo cross that appears in the editor.</para>
    /// </summary>
    public float GizmoExtents { get => _node.GizmoExtents; set => _node.GizmoExtents = value; }

}