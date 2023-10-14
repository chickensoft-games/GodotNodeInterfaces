 namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>An array of 2D points is extruded to quickly and easily create a variety of 3D meshes. See also <see cref="CsgMesh3D" /> for using 3D meshes as CSG nodes.</para>
/// <para><b>Note:</b> CSG nodes are intended to be used for level prototyping. Creating CSG nodes has a significant CPU cost compared to creating a <see cref="MeshInstance3D" /> with a <see cref="PrimitiveMesh" />. Moving a CSG node within another CSG node also has a significant CPU cost, so it should be avoided during gameplay.</para>
/// </summary>
public class CsgPolygon3DAdapter : CsgPolygon3D, ICsgPolygon3D {
  private readonly CsgPolygon3D _node;

  public CsgPolygon3DAdapter(CsgPolygon3D node) => _node = node;
    /// <summary>
    /// <para>When <see cref="CsgPolygon3D.Mode" /> is <see cref="CsgPolygon3D.ModeEnum.Depth" />, the depth of the extrusion.</para>
    /// </summary>
    public float Depth { get => _node.Depth; set => _node.Depth = value; }
    /// <summary>
    /// <para>Material to use for the resulting mesh. The UV maps the top half of the material to the extruded shape (U along the length of the extrusions and V around the outline of the <see cref="CsgPolygon3D.Polygon" />), the bottom-left quarter to the front end face, and the bottom-right quarter to the back end face.</para>
    /// </summary>
    public Material Material { get => _node.Material; set => _node.Material = value; }
    /// <summary>
    /// <para>The <see cref="CsgPolygon3D.Mode" /> used to extrude the <see cref="CsgPolygon3D.Polygon" />.</para>
    /// </summary>
    public CsgPolygon3D.ModeEnum Mode { get => _node.Mode; set => _node.Mode = value; }
    /// <summary>
    /// <para>When <see cref="CsgPolygon3D.Mode" /> is <see cref="CsgPolygon3D.ModeEnum.Path" />, by default, the top half of the <see cref="CsgPolygon3D.Material" /> is stretched along the entire length of the extruded shape. If <c>false</c> the top half of the material is repeated every step of the extrusion.</para>
    /// </summary>
    public bool PathContinuousU { get => _node.PathContinuousU; set => _node.PathContinuousU = value; }
    /// <summary>
    /// <para>When <see cref="CsgPolygon3D.Mode" /> is <see cref="CsgPolygon3D.ModeEnum.Path" />, the path interval or ratio of path points to extrusions.</para>
    /// </summary>
    public float PathInterval { get => _node.PathInterval; set => _node.PathInterval = value; }
    /// <summary>
    /// <para>When <see cref="CsgPolygon3D.Mode" /> is <see cref="CsgPolygon3D.ModeEnum.Path" />, this will determine if the interval should be by distance (<see cref="CsgPolygon3D.PathIntervalTypeEnum.Distance" />) or subdivision fractions (<see cref="CsgPolygon3D.PathIntervalTypeEnum.Subdivide" />).</para>
    /// </summary>
    public CsgPolygon3D.PathIntervalTypeEnum PathIntervalType { get => _node.PathIntervalType; set => _node.PathIntervalType = value; }
    /// <summary>
    /// <para>When <see cref="CsgPolygon3D.Mode" /> is <see cref="CsgPolygon3D.ModeEnum.Path" />, if <c>true</c> the ends of the path are joined, by adding an extrusion between the last and first points of the path.</para>
    /// </summary>
    public bool PathJoined { get => _node.PathJoined; set => _node.PathJoined = value; }
    /// <summary>
    /// <para>When <see cref="CsgPolygon3D.Mode" /> is <see cref="CsgPolygon3D.ModeEnum.Path" />, if <c>true</c> the <see cref="Transform3D" /> of the <see cref="CsgPolygon3D" /> is used as the starting point for the extrusions, not the <see cref="Transform3D" /> of the <see cref="CsgPolygon3D.PathNode" />.</para>
    /// </summary>
    public bool PathLocal { get => _node.PathLocal; set => _node.PathLocal = value; }
    /// <summary>
    /// <para>When <see cref="CsgPolygon3D.Mode" /> is <see cref="CsgPolygon3D.ModeEnum.Path" />, the location of the <see cref="Path3D" /> object used to extrude the <see cref="CsgPolygon3D.Polygon" />.</para>
    /// </summary>
    public NodePath PathNode { get => _node.PathNode; set => _node.PathNode = value; }
    /// <summary>
    /// <para>When <see cref="CsgPolygon3D.Mode" /> is <see cref="CsgPolygon3D.ModeEnum.Path" />, the <see cref="CsgPolygon3D.PathRotationEnum" /> method used to rotate the <see cref="CsgPolygon3D.Polygon" /> as it is extruded.</para>
    /// </summary>
    public CsgPolygon3D.PathRotationEnum PathRotation { get => _node.PathRotation; set => _node.PathRotation = value; }
    /// <summary>
    /// <para>When <see cref="CsgPolygon3D.Mode" /> is <see cref="CsgPolygon3D.ModeEnum.Path" />, extrusions that are less than this angle, will be merged together to reduce polygon count.</para>
    /// </summary>
    public float PathSimplifyAngle { get => _node.PathSimplifyAngle; set => _node.PathSimplifyAngle = value; }
    /// <summary>
    /// <para>When <see cref="CsgPolygon3D.Mode" /> is <see cref="CsgPolygon3D.ModeEnum.Path" />, this is the distance along the path, in meters, the texture coordinates will tile. When set to 0, texture coordinates will match geometry exactly with no tiling.</para>
    /// </summary>
    public float PathUDistance { get => _node.PathUDistance; set => _node.PathUDistance = value; }
    /// <summary>
    /// <para>The point array that defines the 2D polygon that is extruded. This can be a convex or concave polygon with 3 or more points. The polygon must <i>not</i> have any intersecting edges. Otherwise, triangulation will fail and no mesh will be generated.</para>
    /// <para><b>Note:</b> If only 1 or 2 points are defined in <see cref="CsgPolygon3D.Polygon" />, no mesh will be generated.</para>
    /// </summary>
    public Vector2[] Polygon { get => _node.Polygon; set => _node.Polygon = value; }
    /// <summary>
    /// <para>If <c>true</c>, applies smooth shading to the extrusions.</para>
    /// </summary>
    public bool SmoothFaces { get => _node.SmoothFaces; set => _node.SmoothFaces = value; }
    /// <summary>
    /// <para>When <see cref="CsgPolygon3D.Mode" /> is <see cref="CsgPolygon3D.ModeEnum.Spin" />, the total number of degrees the <see cref="CsgPolygon3D.Polygon" /> is rotated when extruding.</para>
    /// </summary>
    public float SpinDegrees { get => _node.SpinDegrees; set => _node.SpinDegrees = value; }
    /// <summary>
    /// <para>When <see cref="CsgPolygon3D.Mode" /> is <see cref="CsgPolygon3D.ModeEnum.Spin" />, the number of extrusions made.</para>
    /// </summary>
    public int SpinSides { get => _node.SpinSides; set => _node.SpinSides = value; }

}