namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
using Godot.Collections;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class Polygon2DNode : Polygon2D, IPolygon2D { }

/// <summary>
/// <para>A Polygon2D is defined by a set of points. Each point is connected to the next, with the final point being connected to the first, resulting in a closed polygon. Polygon2Ds can be filled with color (solid or gradient) or filled with a given texture.</para>
/// </summary>
public interface IPolygon2D : INode2D {
    /// <summary>
    /// <para>Adds a bone with the specified <paramref name="path" /> and <paramref name="weights" />.</para>
    /// </summary>
    void AddBone(NodePath path, float[] weights);
    /// <summary>
    /// <para>If <c>true</c>, polygon edges will be anti-aliased.</para>
    /// </summary>
    bool Antialiased { get; set; }
    /// <summary>
    /// <para>Internal list of <see cref="Bone2D" /> nodes used by the assigned <see cref="Polygon2D.Skeleton" />. Edited using the Polygon2D editor ("UV" button on the top toolbar).</para>
    /// </summary>
    Godot.Collections.Array Bones { get; set; }
    /// <summary>
    /// <para>Removes all bones from this <see cref="Polygon2D" />.</para>
    /// </summary>
    void ClearBones();
    /// <summary>
    /// <para>The polygon's fill color. If <see cref="Polygon2D.Texture" /> is set, it will be multiplied by this color. It will also be the default color for vertices not set in <see cref="Polygon2D.VertexColors" />.</para>
    /// </summary>
    Color Color { get; set; }
    /// <summary>
    /// <para>Removes the specified bone from this <see cref="Polygon2D" />.</para>
    /// </summary>
    void EraseBone(int index);
    /// <summary>
    /// <para>Returns the number of bones in this <see cref="Polygon2D" />.</para>
    /// </summary>
    int GetBoneCount();
    /// <summary>
    /// <para>Returns the path to the node associated with the specified bone.</para>
    /// </summary>
    NodePath GetBonePath(int index);
    /// <summary>
    /// <para>Returns the weight values of the specified bone.</para>
    /// </summary>
    float[] GetBoneWeights(int index);
    /// <summary>
    /// <para>Number of internal vertices, used for UV mapping.</para>
    /// </summary>
    int InternalVertexCount { get; set; }
    /// <summary>
    /// <para>Added padding applied to the bounding box when <see cref="Polygon2D.InvertEnabled" /> is set to <c>true</c>. Setting this value too small may result in a "Bad Polygon" error.</para>
    /// </summary>
    float InvertBorder { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the polygon will be inverted, containing the area outside the defined points and extending to the <see cref="Polygon2D.InvertBorder" />.</para>
    /// </summary>
    bool InvertEnabled { get; set; }
    /// <summary>
    /// <para>The offset applied to each vertex.</para>
    /// </summary>
    Vector2 Offset { get; set; }
    /// <summary>
    /// <para>The polygon's list of vertices. The final point will be connected to the first.</para>
    /// <para><b>Note:</b> This returns a copy of the <see cref="Vector2" />[] rather than a reference.</para>
    /// </summary>
    Vector2[] Polygon { get; set; }
    /// <summary>
    /// <para>The list of polygons, in case more than one is being represented. Every individual polygon is stored as a <see cref="T:System.Int32" />[] where each <see cref="T:System.Int32" /> is an index to a point in <see cref="Polygon2D.Polygon" />. If empty, this property will be ignored, and the resulting single polygon will be composed of all points in <see cref="Polygon2D.Polygon" />, using the order they are stored in.</para>
    /// </summary>
    Godot.Collections.Array Polygons { get; set; }
    /// <summary>
    /// <para>Sets the path to the node associated with the specified bone.</para>
    /// </summary>
    void SetBonePath(int index, NodePath path);
    /// <summary>
    /// <para>Sets the weight values for the specified bone.</para>
    /// </summary>
    void SetBoneWeights(int index, float[] weights);
    /// <summary>
    /// <para>Path to a <see cref="Skeleton2D" /> node used for skeleton-based deformations of this polygon. If empty or invalid, skeletal deformations will not be used.</para>
    /// </summary>
    NodePath Skeleton { get; set; }
    /// <summary>
    /// <para>The polygon's fill texture. Use <see cref="Polygon2D.UV" /> to set texture coordinates.</para>
    /// </summary>
    Texture2D Texture { get; set; }
    /// <summary>
    /// <para>Amount to offset the polygon's <see cref="Polygon2D.Texture" />. If set to <c>Vector2(0, 0)</c>, the texture's origin (its top-left corner) will be placed at the polygon's position.</para>
    /// </summary>
    Vector2 TextureOffset { get; set; }
    /// <summary>
    /// <para>The texture's rotation in radians.</para>
    /// </summary>
    float TextureRotation { get; set; }
    /// <summary>
    /// <para>Amount to multiply the <see cref="Polygon2D.UV" /> coordinates when using <see cref="Polygon2D.Texture" />. Larger values make the texture smaller, and vice versa.</para>
    /// </summary>
    Vector2 TextureScale { get; set; }
    /// <summary>
    /// <para>Texture coordinates for each vertex of the polygon. There should be one UV value per polygon vertex. If there are fewer, undefined vertices will use <c>Vector2(0, 0)</c>.</para>
    /// </summary>
    Vector2[] UV { get; set; }
    /// <summary>
    /// <para>Color for each vertex. Colors are interpolated between vertices, resulting in smooth gradients. There should be one per polygon vertex. If there are fewer, undefined vertices will use <see cref="Polygon2D.Color" />.</para>
    /// </summary>
    Color[] VertexColors { get; set; }

}