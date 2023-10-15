namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A 2D game object, with a transform (position, rotation, and scale). All 2D nodes, including physics objects and sprites, inherit from Node2D. Use Node2D as a parent node to move, scale and rotate children in a 2D project. Also gives control of the node's render order.</para>
/// </summary>
public class Node2DAdapter : CanvasItemAdapter, INode2D {
  private readonly Node2D _node;

  public Node2DAdapter(Node node) : base(node) {
    if (node is not Node2D typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a Node2D"
      );
    }
    _node = typedNode;
  }

    /// <summary>
    /// <para>Multiplies the current scale by the <paramref name="ratio" /> vector.</para>
    /// </summary>
    public void ApplyScale(Vector2 ratio) => _node.ApplyScale(ratio);
    /// <summary>
    /// <para>Returns the angle between the node and the <paramref name="point" /> in radians.</para>
    /// <para><a href="https://raw.githubusercontent.com/godotengine/godot-docs/master/img/node2d_get_angle_to.png">Illustration of the returned angle.</a></para>
    /// </summary>
    public float GetAngleTo(Vector2 point) => _node.GetAngleTo(point);
    /// <summary>
    /// <para>Returns the <see cref="Transform2D" /> relative to this node's parent.</para>
    /// </summary>
    public Transform2D GetRelativeTransformToParent(Node parent) => _node.GetRelativeTransformToParent(parent);
    /// <summary>
    /// <para>Global position.</para>
    /// </summary>
    public Vector2 GlobalPosition { get => _node.GlobalPosition; set => _node.GlobalPosition = value; }
    /// <summary>
    /// <para>Global rotation in radians.</para>
    /// </summary>
    public float GlobalRotation { get => _node.GlobalRotation; set => _node.GlobalRotation = value; }
    /// <summary>
    /// <para>Helper property to access <see cref="Node2D.GlobalRotation" /> in degrees instead of radians.</para>
    /// </summary>
    public float GlobalRotationDegrees { get => _node.GlobalRotationDegrees; set => _node.GlobalRotationDegrees = value; }
    /// <summary>
    /// <para>Global scale.</para>
    /// </summary>
    public Vector2 GlobalScale { get => _node.GlobalScale; set => _node.GlobalScale = value; }
    /// <summary>
    /// <para>Global skew in radians.</para>
    /// </summary>
    public float GlobalSkew { get => _node.GlobalSkew; set => _node.GlobalSkew = value; }
    /// <summary>
    /// <para>Global <see cref="Transform2D" />.</para>
    /// </summary>
    public Transform2D GlobalTransform { get => _node.GlobalTransform; set => _node.GlobalTransform = value; }
    /// <summary>
    /// <para>Adds the <paramref name="offset" /> vector to the node's global position.</para>
    /// </summary>
    public void GlobalTranslate(Vector2 offset) => _node.GlobalTranslate(offset);
    /// <summary>
    /// <para>Rotates the node so it points towards the <paramref name="point" />, which is expected to use global coordinates.</para>
    /// </summary>
    public void LookAt(Vector2 point) => _node.LookAt(point);
    /// <summary>
    /// <para>Applies a local translation on the node's X axis based on the <see cref="Node._Process(System.Double)" />'s <paramref name="delta" />. If <paramref name="scaled" /> is <c>false</c>, normalizes the movement.</para>
    /// </summary>
    public void MoveLocalX(float delta, bool scaled) => _node.MoveLocalX(delta, scaled);
    /// <summary>
    /// <para>Applies a local translation on the node's Y axis based on the <see cref="Node._Process(System.Double)" />'s <paramref name="delta" />. If <paramref name="scaled" /> is <c>false</c>, normalizes the movement.</para>
    /// </summary>
    public void MoveLocalY(float delta, bool scaled) => _node.MoveLocalY(delta, scaled);
    /// <summary>
    /// <para>Position, relative to the node's parent.</para>
    /// </summary>
    public Vector2 Position { get => _node.Position; set => _node.Position = value; }
    /// <summary>
    /// <para>Applies a rotation to the node, in radians, starting from its current rotation.</para>
    /// </summary>
    public void Rotate(float radians) => _node.Rotate(radians);
    /// <summary>
    /// <para>Rotation in radians, relative to the node's parent.</para>
    /// <para><b>Note:</b> This property is edited in the inspector in degrees. If you want to use degrees in a script, use <see cref="Node2D.RotationDegrees" />.</para>
    /// </summary>
    public float Rotation { get => _node.Rotation; set => _node.Rotation = value; }
    /// <summary>
    /// <para>Helper property to access <see cref="Node2D.Rotation" /> in degrees instead of radians.</para>
    /// </summary>
    public float RotationDegrees { get => _node.RotationDegrees; set => _node.RotationDegrees = value; }
    /// <summary>
    /// <para>The node's scale. Unscaled value: <c>(1, 1)</c>.</para>
    /// <para><b>Note:</b> Negative X scales in 2D are not decomposable from the transformation matrix. Due to the way scale is represented with transformation matrices in Godot, negative scales on the X axis will be changed to negative scales on the Y axis and a rotation of 180 degrees when decomposed.</para>
    /// </summary>
    public Vector2 Scale { get => _node.Scale; set => _node.Scale = value; }
    /// <summary>
    /// <para>Slants the node.</para>
    /// <para><b>Note:</b> Skew is X axis only.</para>
    /// </summary>
    public float Skew { get => _node.Skew; set => _node.Skew = value; }
    /// <summary>
    /// <para>Transforms the provided local position into a position in global coordinate space. The input is expected to be local relative to the <see cref="Node2D" /> it is called on. e.g. Applying this method to the positions of child nodes will correctly transform their positions into the global coordinate space, but applying it to a node's own position will give an incorrect result, as it will incorporate the node's own transformation into its global position.</para>
    /// </summary>
    public Vector2 ToGlobal(Vector2 localPoint) => _node.ToGlobal(localPoint);
    /// <summary>
    /// <para>Transforms the provided global position into a position in local coordinate space. The output will be local relative to the <see cref="Node2D" /> it is called on. e.g. It is appropriate for determining the positions of child nodes, but it is not appropriate for determining its own position relative to its parent.</para>
    /// </summary>
    public Vector2 ToLocal(Vector2 globalPoint) => _node.ToLocal(globalPoint);
    /// <summary>
    /// <para>Local <see cref="Transform2D" />.</para>
    /// </summary>
    public Transform2D Transform { get => _node.Transform; set => _node.Transform = value; }
    /// <summary>
    /// <para>Translates the node by the given <paramref name="offset" /> in local coordinates.</para>
    /// </summary>
    public void Translate(Vector2 offset) => _node.Translate(offset);

}