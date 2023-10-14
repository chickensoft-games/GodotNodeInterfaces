namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>This node draws a 2D polyline, i.e. a shape consisting of several points connected by segments. <see cref="Line2D" /> is not a mathematical polyline, i.e. the segments are not infinitely thin. It is intended for rendering and it can be colored and optionally textured.</para>
/// <para><b>Warning:</b> Certain configurations may be impossible to draw nicely, such as very sharp angles. In these situations, the node uses fallback drawing logic to look decent.</para>
/// <para><b>Note:</b> <see cref="Line2D" /> is drawn using a 2D mesh.</para>
/// </summary>
public class Line2DAdapter : Line2D, ILine2D {
  private readonly Line2D _node;

  public Line2DAdapter(Line2D node) => _node = node;
    /// <summary>
    /// <para>Adds a point with the specified <paramref name="position" /> relative to the polyline's own position. If no <paramref name="index" /> is provided, the new point will be added to the end of the points array.</para>
    /// <para>If <paramref name="index" /> is given, the new point is inserted before the existing point identified by index <paramref name="index" />. The indices of the points after the new point get increased by 1. The provided <paramref name="index" /> must not exceed the number of existing points in the polyline. See <see cref="Line2D.GetPointCount" />.</para>
    /// </summary>
    public void AddPoint(Vector2 position, int index) => _node.AddPoint(position, index);
    /// <summary>
    /// <para>If <c>true</c>, the polyline's border will be anti-aliased.</para>
    /// <para><b>Note:</b> <see cref="Line2D" /> is not accelerated by batching when being anti-aliased.</para>
    /// </summary>
    public bool Antialiased { get => _node.Antialiased; set => _node.Antialiased = value; }
    /// <summary>
    /// <para>The style of the beginning of the polyline, if <see cref="Line2D.Closed" /> is <c>false</c>. Use <see cref="Line2D.LineCapMode" /> constants.</para>
    /// </summary>
    public Line2D.LineCapMode BeginCapMode { get => _node.BeginCapMode; set => _node.BeginCapMode = value; }
    /// <summary>
    /// <para>Removes all points from the polyline, making it empty.</para>
    /// </summary>
    public void ClearPoints() => _node.ClearPoints();
    /// <summary>
    /// <para>If <c>true</c> and the polyline has more than 2 points, the last point and the first one will be connected by a segment.</para>
    /// <para><b>Note:</b> The shape of the closing segment is not guaranteed to be seamless if a <see cref="Line2D.WidthCurve" /> is provided.</para>
    /// <para><b>Note:</b> The joint between the closing segment and the first segment is drawn first and it samples the <see cref="Line2D.Gradient" /> and the <see cref="Line2D.WidthCurve" /> at the beginning. This is an implementation detail that might change in a future version.</para>
    /// </summary>
    public bool Closed { get => _node.Closed; set => _node.Closed = value; }
    /// <summary>
    /// <para>The color of the polyline. Will not be used if a gradient is set.</para>
    /// </summary>
    public Color DefaultColor { get => _node.DefaultColor; set => _node.DefaultColor = value; }
    /// <summary>
    /// <para>The style of the end of the polyline, if <see cref="Line2D.Closed" /> is <c>false</c>. Use <see cref="Line2D.LineCapMode" /> constants.</para>
    /// </summary>
    public Line2D.LineCapMode EndCapMode { get => _node.EndCapMode; set => _node.EndCapMode = value; }
    /// <summary>
    /// <para>Returns the number of points in the polyline.</para>
    /// </summary>
    public int GetPointCount() => _node.GetPointCount();
    /// <summary>
    /// <para>Returns the position of the point at index <paramref name="index" />.</para>
    /// </summary>
    public Vector2 GetPointPosition(int index) => _node.GetPointPosition(index);
    /// <summary>
    /// <para>The gradient is drawn through the whole line from start to finish. The <see cref="Line2D.DefaultColor" /> will not be used if this property is set.</para>
    /// </summary>
    public Gradient Gradient { get => _node.Gradient; set => _node.Gradient = value; }
    /// <summary>
    /// <para>The style of the connections between segments of the polyline. Use <see cref="Line2D.LineJointMode" /> constants.</para>
    /// </summary>
    public Line2D.LineJointMode JointMode { get => _node.JointMode; set => _node.JointMode = value; }
    /// <summary>
    /// <para>The points of the polyline, interpreted in local 2D coordinates. Segments are drawn between the adjacent points in this array.</para>
    /// </summary>
    public Vector2[] Points { get => _node.Points; set => _node.Points = value; }
    /// <summary>
    /// <para>Removes the point at index <paramref name="index" /> from the polyline.</para>
    /// </summary>
    public void RemovePoint(int index) => _node.RemovePoint(index);
    /// <summary>
    /// <para>The smoothness used for rounded joints and caps. Higher values result in smoother corners, but are more demanding to render and update.</para>
    /// </summary>
    public int RoundPrecision { get => _node.RoundPrecision; set => _node.RoundPrecision = value; }
    /// <summary>
    /// <para>Overwrites the position of the point at the given <paramref name="index" /> with the supplied <paramref name="position" />.</para>
    /// </summary>
    public void SetPointPosition(int index, Vector2 position) => _node.SetPointPosition(index, position);
    /// <summary>
    /// <para>Determines the miter limit of the polyline. Normally, when <see cref="Line2D.JointMode" /> is set to <see cref="Line2D.LineJointMode.Sharp" />, sharp angles fall back to using the logic of <see cref="Line2D.LineJointMode.Bevel" /> joints to prevent very long miters. Higher values of this property mean that the fallback to a bevel joint will happen at sharper angles.</para>
    /// </summary>
    public float SharpLimit { get => _node.SharpLimit; set => _node.SharpLimit = value; }
    /// <summary>
    /// <para>The texture used for the polyline. Uses <see cref="Line2D.TextureMode" /> for drawing style.</para>
    /// </summary>
    public Texture2D Texture { get => _node.Texture; set => _node.Texture = value; }
    /// <summary>
    /// <para>The style to render the <see cref="Line2D.Texture" /> of the polyline. Use <see cref="Line2D.LineTextureMode" /> constants.</para>
    /// </summary>
    public Line2D.LineTextureMode TextureMode { get => _node.TextureMode; set => _node.TextureMode = value; }
    /// <summary>
    /// <para>The polyline's width.</para>
    /// </summary>
    public float Width { get => _node.Width; set => _node.Width = value; }
    /// <summary>
    /// <para>The polyline's width curve. The width of the polyline over its length will be equivalent to the value of the width curve over its domain.</para>
    /// </summary>
    public Curve WidthCurve { get => _node.WidthCurve; set => _node.WidthCurve = value; }

}