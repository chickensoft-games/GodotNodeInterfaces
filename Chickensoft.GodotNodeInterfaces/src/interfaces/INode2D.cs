namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class Node2DNode : Node2D, INode2D { }

/// <summary>
/// <para>A 2D game object, with a transform (position, rotation, and scale). All 2D nodes, including physics objects and sprites, inherit from Node2D. Use Node2D as a parent node to move, scale and rotate children in a 2D project. Also gives control of the node's render order.</para>
/// </summary>
public interface INode2D : ICanvasItem {
    /// <summary>
    /// <para>Multiplies the current scale by the <paramref name="ratio" /> vector.</para>
    /// </summary>
    void ApplyScale(Vector2 ratio);
    /// <summary>
    /// <para>Returns the angle between the node and the <paramref name="point" /> in radians.</para>
    /// <para><a href="https://raw.githubusercontent.com/godotengine/godot-docs/master/img/node2d_get_angle_to.png">Illustration of the returned angle.</a></para>
    /// </summary>
    float GetAngleTo(Vector2 point);
    /// <summary>
    /// <para>Returns the <see cref="Transform2D" /> relative to this node's parent.</para>
    /// </summary>
    Transform2D GetRelativeTransformToParent(Node parent);
    /// <summary>
    /// <para>Global position.</para>
    /// </summary>
    Vector2 GlobalPosition { get; set; }
    /// <summary>
    /// <para>Global rotation in radians.</para>
    /// </summary>
    float GlobalRotation { get; set; }
    /// <summary>
    /// <para>Helper property to access <see cref="Node2D.GlobalRotation" /> in degrees instead of radians.</para>
    /// </summary>
    float GlobalRotationDegrees { get; set; }
    /// <summary>
    /// <para>Global scale.</para>
    /// </summary>
    Vector2 GlobalScale { get; set; }
    /// <summary>
    /// <para>Global skew in radians.</para>
    /// </summary>
    float GlobalSkew { get; set; }
    /// <summary>
    /// <para>Global <see cref="Transform2D" />.</para>
    /// </summary>
    Transform2D GlobalTransform { get; set; }
    /// <summary>
    /// <para>Adds the <paramref name="offset" /> vector to the node's global position.</para>
    /// </summary>
    void GlobalTranslate(Vector2 offset);
    /// <summary>
    /// <para>Rotates the node so it points towards the <paramref name="point" />, which is expected to use global coordinates.</para>
    /// </summary>
    void LookAt(Vector2 point);
    /// <summary>
    /// <para>Applies a local translation on the node's X axis based on the <see cref="Node._Process(System.Double)" />'s <paramref name="delta" />. If <paramref name="scaled" /> is <c>false</c>, normalizes the movement.</para>
    /// </summary>
    void MoveLocalX(float delta, bool scaled);
    /// <summary>
    /// <para>Applies a local translation on the node's Y axis based on the <see cref="Node._Process(System.Double)" />'s <paramref name="delta" />. If <paramref name="scaled" /> is <c>false</c>, normalizes the movement.</para>
    /// </summary>
    void MoveLocalY(float delta, bool scaled);
    /// <summary>
    /// <para>Position, relative to the node's parent.</para>
    /// </summary>
    Vector2 Position { get; set; }
    /// <summary>
    /// <para>Applies a rotation to the node, in radians, starting from its current rotation.</para>
    /// </summary>
    void Rotate(float radians);
    /// <summary>
    /// <para>Rotation in radians, relative to the node's parent.</para>
    /// <para><b>Note:</b> This property is edited in the inspector in degrees. If you want to use degrees in a script, use <see cref="Node2D.RotationDegrees" />.</para>
    /// </summary>
    float Rotation { get; set; }
    /// <summary>
    /// <para>Helper property to access <see cref="Node2D.Rotation" /> in degrees instead of radians.</para>
    /// </summary>
    float RotationDegrees { get; set; }
    /// <summary>
    /// <para>The node's scale. Unscaled value: <c>(1, 1)</c>.</para>
    /// <para><b>Note:</b> Negative X scales in 2D are not decomposable from the transformation matrix. Due to the way scale is represented with transformation matrices in Godot, negative scales on the X axis will be changed to negative scales on the Y axis and a rotation of 180 degrees when decomposed.</para>
    /// </summary>
    Vector2 Scale { get; set; }
    /// <summary>
    /// <para>Slants the node.</para>
    /// <para><b>Note:</b> Skew is X axis only.</para>
    /// </summary>
    float Skew { get; set; }
    /// <summary>
    /// <para>Transforms the provided local position into a position in global coordinate space. The input is expected to be local relative to the <see cref="Node2D" /> it is called on. e.g. Applying this method to the positions of child nodes will correctly transform their positions into the global coordinate space, but applying it to a node's own position will give an incorrect result, as it will incorporate the node's own transformation into its global position.</para>
    /// </summary>
    Vector2 ToGlobal(Vector2 localPoint);
    /// <summary>
    /// <para>Transforms the provided global position into a position in local coordinate space. The output will be local relative to the <see cref="Node2D" /> it is called on. e.g. It is appropriate for determining the positions of child nodes, but it is not appropriate for determining its own position relative to its parent.</para>
    /// </summary>
    Vector2 ToLocal(Vector2 globalPoint);
    /// <summary>
    /// <para>Local <see cref="Transform2D" />.</para>
    /// </summary>
    Transform2D Transform { get; set; }
    /// <summary>
    /// <para>Translates the node by the given <paramref name="offset" /> in local coordinates.</para>
    /// </summary>
    void Translate(Vector2 offset);

}