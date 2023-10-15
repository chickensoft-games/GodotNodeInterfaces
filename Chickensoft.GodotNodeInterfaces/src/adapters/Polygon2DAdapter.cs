namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
using Godot.Collections;
/// <summary>
/// <para>A Polygon2D is defined by a set of points. Each point is connected to the next, with the final point being connected to the first, resulting in a closed polygon. Polygon2Ds can be filled with color (solid or gradient) or filled with a given texture.</para>
/// </summary>
public class Polygon2DAdapter : Node2DAdapter, IPolygon2D {
  private readonly Polygon2D _node;

  public Polygon2DAdapter(Node node) : base(node) {
    if (node is not Polygon2D typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a Polygon2D"
      );
    }
    _node = typedNode;
  }

    /// <summary>
    /// <para>Adds a bone with the specified <paramref name="path" /> and <paramref name="weights" />.</para>
    /// </summary>
    public void AddBone(NodePath path, float[] weights) => _node.AddBone(path, weights);
    /// <summary>
    /// <para>If <c>true</c>, polygon edges will be anti-aliased.</para>
    /// </summary>
    public bool Antialiased { get => _node.Antialiased; set => _node.Antialiased = value; }
    /// <summary>
    /// <para>Internal list of <see cref="Bone2D" /> nodes used by the assigned <see cref="Polygon2D.Skeleton" />. Edited using the Polygon2D editor ("UV" button on the top toolbar).</para>
    /// </summary>
    public Godot.Collections.Array Bones { get => _node.Bones; set => _node.Bones = value; }
    /// <summary>
    /// <para>Removes all bones from this <see cref="Polygon2D" />.</para>
    /// </summary>
    public void ClearBones() => _node.ClearBones();
    /// <summary>
    /// <para>The polygon's fill color. If <see cref="Polygon2D.Texture" /> is set, it will be multiplied by this color. It will also be the default color for vertices not set in <see cref="Polygon2D.VertexColors" />.</para>
    /// </summary>
    public Color Color { get => _node.Color; set => _node.Color = value; }
    /// <summary>
    /// <para>Removes the specified bone from this <see cref="Polygon2D" />.</para>
    /// </summary>
    public void EraseBone(int index) => _node.EraseBone(index);
    /// <summary>
    /// <para>Returns the number of bones in this <see cref="Polygon2D" />.</para>
    /// </summary>
    public int GetBoneCount() => _node.GetBoneCount();
    /// <summary>
    /// <para>Returns the path to the node associated with the specified bone.</para>
    /// </summary>
    public NodePath GetBonePath(int index) => _node.GetBonePath(index);
    /// <summary>
    /// <para>Returns the weight values of the specified bone.</para>
    /// </summary>
    public float[] GetBoneWeights(int index) => _node.GetBoneWeights(index);
    /// <summary>
    /// <para>Number of internal vertices, used for UV mapping.</para>
    /// </summary>
    public int InternalVertexCount { get => _node.InternalVertexCount; set => _node.InternalVertexCount = value; }
    /// <summary>
    /// <para>Added padding applied to the bounding box when <see cref="Polygon2D.InvertEnabled" /> is set to <c>true</c>. Setting this value too small may result in a "Bad Polygon" error.</para>
    /// </summary>
    public float InvertBorder { get => _node.InvertBorder; set => _node.InvertBorder = value; }
    /// <summary>
    /// <para>If <c>true</c>, the polygon will be inverted, containing the area outside the defined points and extending to the <see cref="Polygon2D.InvertBorder" />.</para>
    /// </summary>
    public bool InvertEnabled { get => _node.InvertEnabled; set => _node.InvertEnabled = value; }
    /// <summary>
    /// <para>The offset applied to each vertex.</para>
    /// </summary>
    public Vector2 Offset { get => _node.Offset; set => _node.Offset = value; }
    /// <summary>
    /// <para>The polygon's list of vertices. The final point will be connected to the first.</para>
    /// <para><b>Note:</b> This returns a copy of the <see cref="Vector2" />[] rather than a reference.</para>
    /// </summary>
    public Vector2[] Polygon { get => _node.Polygon; set => _node.Polygon = value; }
    /// <summary>
    /// <para>The list of polygons, in case more than one is being represented. Every individual polygon is stored as a <see cref="T:System.Int32" />[] where each <see cref="T:System.Int32" /> is an index to a point in <see cref="Polygon2D.Polygon" />. If empty, this property will be ignored, and the resulting single polygon will be composed of all points in <see cref="Polygon2D.Polygon" />, using the order they are stored in.</para>
    /// </summary>
    public Godot.Collections.Array Polygons { get => _node.Polygons; set => _node.Polygons = value; }
    /// <summary>
    /// <para>Sets the path to the node associated with the specified bone.</para>
    /// </summary>
    public void SetBonePath(int index, NodePath path) => _node.SetBonePath(index, path);
    /// <summary>
    /// <para>Sets the weight values for the specified bone.</para>
    /// </summary>
    public void SetBoneWeights(int index, float[] weights) => _node.SetBoneWeights(index, weights);
    /// <summary>
    /// <para>Path to a <see cref="Skeleton2D" /> node used for skeleton-based deformations of this polygon. If empty or invalid, skeletal deformations will not be used.</para>
    /// </summary>
    public NodePath Skeleton { get => _node.Skeleton; set => _node.Skeleton = value; }
    /// <summary>
    /// <para>The polygon's fill texture. Use <see cref="Polygon2D.UV" /> to set texture coordinates.</para>
    /// </summary>
    public Texture2D Texture { get => _node.Texture; set => _node.Texture = value; }
    /// <summary>
    /// <para>Amount to offset the polygon's <see cref="Polygon2D.Texture" />. If set to <c>Vector2(0, 0)</c>, the texture's origin (its top-left corner) will be placed at the polygon's position.</para>
    /// </summary>
    public Vector2 TextureOffset { get => _node.TextureOffset; set => _node.TextureOffset = value; }
    /// <summary>
    /// <para>The texture's rotation in radians.</para>
    /// </summary>
    public float TextureRotation { get => _node.TextureRotation; set => _node.TextureRotation = value; }
    /// <summary>
    /// <para>Amount to multiply the <see cref="Polygon2D.UV" /> coordinates when using <see cref="Polygon2D.Texture" />. Larger values make the texture smaller, and vice versa.</para>
    /// </summary>
    public Vector2 TextureScale { get => _node.TextureScale; set => _node.TextureScale = value; }
    /// <summary>
    /// <para>Texture coordinates for each vertex of the polygon. There should be one UV value per polygon vertex. If there are fewer, undefined vertices will use <c>Vector2(0, 0)</c>.</para>
    /// </summary>
    public Vector2[] UV { get => _node.UV; set => _node.UV = value; }
    /// <summary>
    /// <para>Color for each vertex. Colors are interpolated between vertices, resulting in smooth gradients. There should be one per polygon vertex. If there are fewer, undefined vertices will use <see cref="Polygon2D.Color" />.</para>
    /// </summary>
    public Color[] VertexColors { get => _node.VertexColors; set => _node.VertexColors = value; }

}