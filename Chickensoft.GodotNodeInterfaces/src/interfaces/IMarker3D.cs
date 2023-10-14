namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class Marker3DNode : Marker3D, IMarker3D { }

/// <summary>
/// <para>Generic 3D position hint for editing. It's just like a plain <see cref="Node3D" />, but it displays as a cross in the 3D editor at all times.</para>
/// </summary>
public interface IMarker3D : INode3D {
    /// <summary>
    /// <para>Size of the gizmo cross that appears in the editor.</para>
    /// </summary>
    float GizmoExtents { get; set; }

}