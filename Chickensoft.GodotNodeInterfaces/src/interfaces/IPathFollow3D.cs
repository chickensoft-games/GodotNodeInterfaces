namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class PathFollow3DNode : PathFollow3D, IPathFollow3D { }

/// <summary>
/// <para>This node takes its parent <see cref="Path3D" />, and returns the coordinates of a point within it, given a distance from the first vertex.</para>
/// <para>It is useful for making other nodes follow a path, without coding the movement pattern. For that, the nodes must be children of this node. The descendant nodes will then move accordingly when setting the <see cref="PathFollow3D.Progress" /> in this node.</para>
/// </summary>
public interface IPathFollow3D : INode3D {
    /// <summary>
    /// <para>If <c>true</c>, the position between two cached points is interpolated cubically, and linearly otherwise.</para>
    /// <para>The points along the <see cref="Curve3D" /> of the <see cref="Path3D" /> are precomputed before use, for faster calculations. The point at the requested offset is then calculated interpolating between two adjacent cached points. This may present a problem if the curve makes sharp turns, as the cached points may not follow the curve closely enough.</para>
    /// <para>There are two answers to this problem: either increase the number of cached points and increase memory consumption, or make a cubic interpolation between two points at the cost of (slightly) slower calculations.</para>
    /// </summary>
    bool CubicInterp { get; set; }
    /// <summary>
    /// <para>The node's offset along the curve.</para>
    /// </summary>
    float HOffset { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, any offset outside the path's length will wrap around, instead of stopping at the ends. Use it for cyclic paths.</para>
    /// </summary>
    bool Loop { get; set; }
    /// <summary>
    /// <para>The distance from the first vertex, measured in 3D units along the path. Changing this value sets this node's position to a point within the path.</para>
    /// </summary>
    float Progress { get; set; }
    /// <summary>
    /// <para>The distance from the first vertex, considering 0.0 as the first vertex and 1.0 as the last. This is just another way of expressing the progress within the path, as the progress supplied is multiplied internally by the path's length.</para>
    /// </summary>
    float ProgressRatio { get; set; }
    /// <summary>
    /// <para>Allows or forbids rotation on one or more axes, depending on the <see cref="PathFollow3D.RotationModeEnum" /> constants being used.</para>
    /// </summary>
    PathFollow3D.RotationModeEnum RotationMode { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the tilt property of <see cref="Curve3D" /> takes effect.</para>
    /// </summary>
    bool TiltEnabled { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the node moves on the travel path with orienting the +Z axis as forward. See also <c>Vector3.FORWARD</c> and <c>Vector3.MODEL_FRONT</c>.</para>
    /// </summary>
    bool UseModelFront { get; set; }
    /// <summary>
    /// <para>The node's offset perpendicular to the curve.</para>
    /// </summary>
    float VOffset { get; set; }

}