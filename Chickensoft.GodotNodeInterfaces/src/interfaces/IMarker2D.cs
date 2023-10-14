namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class Marker2DNode : Marker2D, IMarker2D { }

/// <summary>
/// <para>Generic 2D position hint for editing. It's just like a plain <see cref="Node2D" />, but it displays as a cross in the 2D editor at all times. You can set the cross' visual size by using the gizmo in the 2D editor while the node is selected.</para>
/// </summary>
public interface IMarker2D : INode2D {
    /// <summary>
    /// <para>Size of the gizmo cross that appears in the editor.</para>
    /// </summary>
    float GizmoExtents { get; set; }

}