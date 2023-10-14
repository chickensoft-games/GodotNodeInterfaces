namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>Generic 3D position hint for editing. It's just like a plain <see cref="Node3D" />, but it displays as a cross in the 3D editor at all times.</para>
/// </summary>
public class Marker3DAdapter : Marker3D, IMarker3D {
  private readonly Marker3D _node;

  public Marker3DAdapter(Marker3D node) => _node = node;
    /// <summary>
    /// <para>Size of the gizmo cross that appears in the editor.</para>
    /// </summary>
    public float GizmoExtents { get => _node.GizmoExtents; set => _node.GizmoExtents = value; }

}