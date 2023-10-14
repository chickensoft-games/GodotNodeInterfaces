 namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>This node takes its parent <see cref="Path2D" />, and returns the coordinates of a point within it, given a distance from the first vertex.</para>
/// <para>It is useful for making other nodes follow a path, without coding the movement pattern. For that, the nodes must be children of this node. The descendant nodes will then move accordingly when setting the <see cref="PathFollow2D.Progress" /> in this node.</para>
/// </summary>
public class PathFollow2DAdapter : PathFollow2D, IPathFollow2D {
  private readonly PathFollow2D _node;

  public PathFollow2DAdapter(PathFollow2D node) => _node = node;
    /// <summary>
    /// <para>If <c>true</c>, the position between two cached points is interpolated cubically, and linearly otherwise.</para>
    /// <para>The points along the <see cref="Curve2D" /> of the <see cref="Path2D" /> are precomputed before use, for faster calculations. The point at the requested offset is then calculated interpolating between two adjacent cached points. This may present a problem if the curve makes sharp turns, as the cached points may not follow the curve closely enough.</para>
    /// <para>There are two answers to this problem: either increase the number of cached points and increase memory consumption, or make a cubic interpolation between two points at the cost of (slightly) slower calculations.</para>
    /// </summary>
    public bool CubicInterp { get => _node.CubicInterp; set => _node.CubicInterp = value; }
    /// <summary>
    /// <para>The node's offset along the curve.</para>
    /// </summary>
    public float HOffset { get => _node.HOffset; set => _node.HOffset = value; }
    /// <summary>
    /// <para>If <c>true</c>, any offset outside the path's length will wrap around, instead of stopping at the ends. Use it for cyclic paths.</para>
    /// </summary>
    public bool Loop { get => _node.Loop; set => _node.Loop = value; }
    /// <summary>
    /// <para>The distance along the path, in pixels. Changing this value sets this node's position to a point within the path.</para>
    /// </summary>
    public float Progress { get => _node.Progress; set => _node.Progress = value; }
    /// <summary>
    /// <para>The distance along the path as a number in the range 0.0 (for the first vertex) to 1.0 (for the last). This is just another way of expressing the progress within the path, as the offset supplied is multiplied internally by the path's length.</para>
    /// </summary>
    public float ProgressRatio { get => _node.ProgressRatio; set => _node.ProgressRatio = value; }
    /// <summary>
    /// <para>If <c>true</c>, this node rotates to follow the path, with the +X direction facing forward on the path.</para>
    /// </summary>
    public bool Rotates { get => _node.Rotates; set => _node.Rotates = value; }
    /// <summary>
    /// <para>The node's offset perpendicular to the curve.</para>
    /// </summary>
    public float VOffset { get => _node.VOffset; set => _node.VOffset = value; }

}