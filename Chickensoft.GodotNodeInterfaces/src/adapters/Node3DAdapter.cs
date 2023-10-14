namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
using Godot.Collections;
/// <summary>
/// <para>Most basic 3D game object, with a <see cref="Transform3D" /> and visibility settings. All other 3D game objects inherit from <see cref="Node3D" />. Use <see cref="Node3D" /> as a parent node to move, scale, rotate and show/hide children in a 3D project.</para>
/// <para>Affine operations (rotate, scale, translate) happen in parent's local coordinate system, unless the <see cref="Node3D" /> object is set as top-level. Affine operations in this coordinate system correspond to direct affine operations on the <see cref="Node3D" />'s transform. The word local below refers to this coordinate system. The coordinate system that is attached to the <see cref="Node3D" /> object itself is referred to as object-local coordinate system.</para>
/// <para><b>Note:</b> Unless otherwise specified, all methods that have angle parameters must have angles specified as <i>radians</i>. To convert degrees to radians, use <c>@GlobalScope.deg_to_rad</c>.</para>
/// <para><b>Note:</b> Be aware that "Spatial" nodes are now called "Node3D" starting with Godot 4. Any Godot 3.x references to "Spatial" nodes refer to "Node3D" in Godot 4.</para>
/// </summary>
public class Node3DAdapter : NodeAdapter, INode3D {
  private readonly Node3D _node;

  public Node3DAdapter(Node3D node) : base(node) { _node = node; }

    /// <summary>
    /// <para>Attach an editor gizmo to this <see cref="Node3D" />.</para>
    /// <para><b>Note:</b> The gizmo object would typically be an instance of <c>EditorNode3DGizmo</c>, but the argument type is kept generic to avoid creating a dependency on editor classes in <see cref="Node3D" />.</para>
    /// </summary>
    public void AddGizmo(Node3DGizmo gizmo) => _node.AddGizmo(gizmo);
    /// <summary>
    /// <para>Direct access to the 3x3 basis of the <see cref="Node3D.Transform" /> property.</para>
    /// </summary>
    public Basis Basis { get => _node.Basis; set => _node.Basis = value; }
    /// <summary>
    /// <para>Clear all gizmos attached to this <see cref="Node3D" />.</para>
    /// </summary>
    public void ClearGizmos() => _node.ClearGizmos();
    /// <summary>
    /// <para>Clears subgizmo selection for this node in the editor. Useful when subgizmo IDs become invalid after a property change.</para>
    /// </summary>
    public void ClearSubgizmoSelection() => _node.ClearSubgizmoSelection();
    /// <summary>
    /// <para>Forces the transform to update. Transform changes in physics are not instant for performance reasons. Transforms are accumulated and then set. Use this if you need an up-to-date transform when doing physics operations.</para>
    /// </summary>
    public void ForceUpdateTransform() => _node.ForceUpdateTransform();
    /// <summary>
    /// <para>Returns all the gizmos attached to this <see cref="Node3D" />.</para>
    /// </summary>
    public Godot.Collections.Array<Node3DGizmo> GetGizmos() => _node.GetGizmos();
    /// <summary>
    /// <para>Returns the parent <see cref="Node3D" />, or an empty <see cref="GodotObject" /> if no parent exists or parent is not of type <see cref="Node3D" />.</para>
    /// </summary>
    public Node3D GetParentNode3D() => _node.GetParentNode3D();
    /// <summary>
    /// <para>Returns the current <see cref="World3D" /> resource this <see cref="Node3D" /> node is registered to.</para>
    /// </summary>
    public World3D GetWorld3D() => _node.GetWorld3D();
    /// <summary>
    /// <para>Global basis of this node. This is equivalent to <c>global_transform.basis</c>.</para>
    /// </summary>
    public Basis GlobalBasis { get => _node.GlobalBasis; set => _node.GlobalBasis = value; }
    /// <summary>
    /// <para>Global position of this node. This is equivalent to <c>global_transform.origin</c>.</para>
    /// </summary>
    public Vector3 GlobalPosition { get => _node.GlobalPosition; set => _node.GlobalPosition = value; }
    /// <summary>
    /// <para>Rotates the global (world) transformation around axis, a unit <see cref="Vector3" />, by specified angle in radians. The rotation axis is in global coordinate system.</para>
    /// </summary>
    public void GlobalRotate(Vector3 axis, float angle) => _node.GlobalRotate(axis, angle);
    /// <summary>
    /// <para>Rotation part of the global transformation in radians, specified in terms of YXZ-Euler angles in the format (X angle, Y angle, Z angle).</para>
    /// <para><b>Note:</b> In the mathematical sense, rotation is a matrix and not a vector. The three Euler angles, which are the three independent parameters of the Euler-angle parametrization of the rotation matrix, are stored in a <see cref="Vector3" /> data structure not because the rotation is a vector, but only because <see cref="Vector3" /> exists as a convenient data-structure to store 3 floating-point numbers. Therefore, applying affine operations on the rotation "vector" is not meaningful.</para>
    /// </summary>
    public Vector3 GlobalRotation { get => _node.GlobalRotation; set => _node.GlobalRotation = value; }
    /// <summary>
    /// <para>Helper property to access <see cref="Node3D.GlobalRotation" /> in degrees instead of radians.</para>
    /// </summary>
    public Vector3 GlobalRotationDegrees { get => _node.GlobalRotationDegrees; set => _node.GlobalRotationDegrees = value; }
    /// <summary>
    /// <para>Scales the global (world) transformation by the given <see cref="Vector3" /> scale factors.</para>
    /// </summary>
    public void GlobalScale(Vector3 scale) => _node.GlobalScale(scale);
    /// <summary>
    /// <para>World3D space (global) <see cref="Transform3D" /> of this node.</para>
    /// </summary>
    public Transform3D GlobalTransform { get => _node.GlobalTransform; set => _node.GlobalTransform = value; }
    /// <summary>
    /// <para>Moves the global (world) transformation by <see cref="Vector3" /> offset. The offset is in global coordinate system.</para>
    /// </summary>
    public void GlobalTranslate(Vector3 offset) => _node.GlobalTranslate(offset);
    /// <summary>
    /// <para>Disables rendering of this node. Changes <see cref="Node3D.Visible" /> to <c>false</c>.</para>
    /// </summary>
    public void Hide() => _node.Hide();
    /// <summary>
    /// <para>Returns whether node notifies about its local transformation changes. <see cref="Node3D" /> will not propagate this by default.</para>
    /// </summary>
    public bool IsLocalTransformNotificationEnabled() => _node.IsLocalTransformNotificationEnabled();
    /// <summary>
    /// <para>Returns whether this node uses a scale of <c>(1, 1, 1)</c> or its local transformation scale.</para>
    /// </summary>
    public bool IsScaleDisabled() => _node.IsScaleDisabled();
    /// <summary>
    /// <para>Returns whether the node notifies about its global and local transformation changes. <see cref="Node3D" /> will not propagate this by default.</para>
    /// </summary>
    public bool IsTransformNotificationEnabled() => _node.IsTransformNotificationEnabled();
    /// <summary>
    /// <para>Returns <c>true</c> if the node is present in the <see cref="SceneTree" />, its <see cref="Node3D.Visible" /> property is <c>true</c> and all its ancestors are also visible. If any ancestor is hidden, this node will not be visible in the scene tree.</para>
    /// </summary>
    public bool IsVisibleInTree() => _node.IsVisibleInTree();
    /// <inheritdoc cref="M:Godot.Node3D.LookAt(Godot.Vector3,System.Nullable{Godot.Vector3},System.Boolean)" />
    public void LookAt(Vector3 target, Nullable<Vector3> up) => _node.LookAt(target, up);
    /// <summary>
    /// <para>Rotates the node so that the local forward axis (-Z, <c>Vector3.FORWARD</c>) points toward the <paramref name="target" /> position.</para>
    /// <para>The local up axis (+Y) points as close to the <paramref name="up" /> vector as possible while staying perpendicular to the local forward axis. The resulting transform is orthogonal, and the scale is preserved. Non-uniform scaling may not work correctly.</para>
    /// <para>The <paramref name="target" /> position cannot be the same as the node's position, the <paramref name="up" /> vector cannot be zero, and the direction from the node's position to the <paramref name="target" /> vector cannot be parallel to the <paramref name="up" /> vector.</para>
    /// <para>Operations take place in global space, which means that the node must be in the scene tree.</para>
    /// <para>If <paramref name="useModelFront" /> is <c>true</c>, the +Z axis (asset front) is treated as forward (implies +X is left) and points toward the <paramref name="target" /> position. By default, the -Z axis (camera forward) is treated as forward (implies +X is right).</para>
    /// </summary>
    /// <param name="up">If the parameter is null, then the default value is <c>new Vector3(0, 1, 0)</c>.</param>
    public void LookAt(Vector3 target, Nullable<Vector3> up, bool useModelFront) => _node.LookAt(target, up, useModelFront);
    /// <inheritdoc cref="M:Godot.Node3D.LookAtFromPosition(Godot.Vector3,Godot.Vector3,System.Nullable{Godot.Vector3},System.Boolean)" />
    public void LookAtFromPosition(Vector3 position, Vector3 target, Nullable<Vector3> up) => _node.LookAtFromPosition(position, target, up);
    /// <summary>
    /// <para>Moves the node to the specified <paramref name="position" />, and then rotates the node to point toward the <paramref name="target" /> as per <see cref="Node3D.LookAt(Godot.Vector3,System.Nullable{Godot.Vector3},System.Boolean)" />. Operations take place in global space.</para>
    /// </summary>
    /// <param name="up">If the parameter is null, then the default value is <c>new Vector3(0, 1, 0)</c>.</param>
    public void LookAtFromPosition(Vector3 position, Vector3 target, Nullable<Vector3> up, bool useModelFront) => _node.LookAtFromPosition(position, target, up, useModelFront);
    /// <summary>
    /// <para>Resets this node's transformations (like scale, skew and taper) preserving its rotation and translation by performing Gram-Schmidt orthonormalization on this node's <see cref="Transform3D" />.</para>
    /// </summary>
    public void Orthonormalize() => _node.Orthonormalize();
    /// <summary>
    /// <para>Local position or translation of this node relative to the parent. This is equivalent to <c>transform.origin</c>.</para>
    /// </summary>
    public Vector3 Position { get => _node.Position; set => _node.Position = value; }
    /// <summary>
    /// <para>Access to the node rotation as a <see cref="Quaternion" />. This property is ideal for tweening complex rotations.</para>
    /// </summary>
    public Quaternion Quaternion { get => _node.Quaternion; set => _node.Quaternion = value; }
    /// <summary>
    /// <para>Rotates the local transformation around axis, a unit <see cref="Vector3" />, by specified angle in radians.</para>
    /// </summary>
    public void Rotate(Vector3 axis, float angle) => _node.Rotate(axis, angle);
    /// <summary>
    /// <para>Rotates the local transformation around axis, a unit <see cref="Vector3" />, by specified angle in radians. The rotation axis is in object-local coordinate system.</para>
    /// </summary>
    public void RotateObjectLocal(Vector3 axis, float angle) => _node.RotateObjectLocal(axis, angle);
    /// <summary>
    /// <para>Rotates the local transformation around the X axis by angle in radians.</para>
    /// </summary>
    public void RotateX(float angle) => _node.RotateX(angle);
    /// <summary>
    /// <para>Rotates the local transformation around the Y axis by angle in radians.</para>
    /// </summary>
    public void RotateY(float angle) => _node.RotateY(angle);
    /// <summary>
    /// <para>Rotates the local transformation around the Z axis by angle in radians.</para>
    /// </summary>
    public void RotateZ(float angle) => _node.RotateZ(angle);
    /// <summary>
    /// <para>Rotation part of the local transformation in radians, specified in terms of Euler angles. The angles construct a rotation in the order specified by the <see cref="Node3D.RotationOrder" /> property.</para>
    /// <para><b>Note:</b> In the mathematical sense, rotation is a matrix and not a vector. The three Euler angles, which are the three independent parameters of the Euler-angle parametrization of the rotation matrix, are stored in a <see cref="Vector3" /> data structure not because the rotation is a vector, but only because <see cref="Vector3" /> exists as a convenient data-structure to store 3 floating-point numbers. Therefore, applying affine operations on the rotation "vector" is not meaningful.</para>
    /// <para><b>Note:</b> This property is edited in the inspector in degrees. If you want to use degrees in a script, use <see cref="Node3D.RotationDegrees" />.</para>
    /// </summary>
    public Vector3 Rotation { get => _node.Rotation; set => _node.Rotation = value; }
    /// <summary>
    /// <para>Helper property to access <see cref="Node3D.Rotation" /> in degrees instead of radians.</para>
    /// </summary>
    public Vector3 RotationDegrees { get => _node.RotationDegrees; set => _node.RotationDegrees = value; }
    /// <summary>
    /// <para>Specify how rotation (and scale) will be presented in the editor.</para>
    /// </summary>
    public Node3D.RotationEditModeEnum RotationEditMode { get => _node.RotationEditMode; set => _node.RotationEditMode = value; }
    /// <summary>
    /// <para>Specify the axis rotation order of the <see cref="Node3D.Rotation" /> property. The final orientation is constructed by rotating the Euler angles in the order specified by this property.</para>
    /// </summary>
    public EulerOrder RotationOrder { get => _node.RotationOrder; set => _node.RotationOrder = value; }
    /// <summary>
    /// <para>Scale part of the local transformation.</para>
    /// <para><b>Note:</b> Mixed negative scales in 3D are not decomposable from the transformation matrix. Due to the way scale is represented with transformation matrices in Godot, the scale values will either be all positive or all negative.</para>
    /// <para><b>Note:</b> Not all nodes are visually scaled by the <see cref="Node3D.Scale" /> property. For example, <see cref="Light3D" />s are not visually affected by <see cref="Node3D.Scale" />.</para>
    /// </summary>
    public Vector3 Scale { get => _node.Scale; set => _node.Scale = value; }
    /// <summary>
    /// <para>Scales the local transformation by given 3D scale factors in object-local coordinate system.</para>
    /// </summary>
    public void ScaleObjectLocal(Vector3 scale) => _node.ScaleObjectLocal(scale);
    /// <summary>
    /// <para>Sets whether the node uses a scale of <c>(1, 1, 1)</c> or its local transformation scale. Changes to the local transformation scale are preserved.</para>
    /// </summary>
    public void SetDisableScale(bool disable) => _node.SetDisableScale(disable);
    /// <summary>
    /// <para>Reset all transformations for this node (sets its <see cref="Transform3D" /> to the identity matrix).</para>
    /// </summary>
    public void SetIdentity() => _node.SetIdentity();
    /// <summary>
    /// <para>Sets whether the node ignores notification that its transformation (global or local) changed.</para>
    /// </summary>
    public void SetIgnoreTransformNotification(bool enabled) => _node.SetIgnoreTransformNotification(enabled);
    /// <summary>
    /// <para>Sets whether the node notifies about its local transformation changes. <see cref="Node3D" /> will not propagate this by default.</para>
    /// </summary>
    public void SetNotifyLocalTransform(bool enable) => _node.SetNotifyLocalTransform(enable);
    /// <summary>
    /// <para>Sets whether the node notifies about its global and local transformation changes. <see cref="Node3D" /> will not propagate this by default, unless it is in the editor context and it has a valid gizmo.</para>
    /// </summary>
    public void SetNotifyTransform(bool enable) => _node.SetNotifyTransform(enable);
    /// <summary>
    /// <para>Set subgizmo selection for this node in the editor.</para>
    /// <para><b>Note:</b> The gizmo object would typically be an instance of <c>EditorNode3DGizmo</c>, but the argument type is kept generic to avoid creating a dependency on editor classes in <see cref="Node3D" />.</para>
    /// </summary>
    public void SetSubgizmoSelection(Node3DGizmo gizmo, int id, Transform3D transform) => _node.SetSubgizmoSelection(gizmo, id, transform);
    /// <summary>
    /// <para>Enables rendering of this node. Changes <see cref="Node3D.Visible" /> to <c>true</c>.</para>
    /// </summary>
    public void Show() => _node.Show();
    /// <summary>
    /// <para>Transforms <paramref name="localPoint" /> from this node's local space to world space.</para>
    /// </summary>
    public Vector3 ToGlobal(Vector3 localPoint) => _node.ToGlobal(localPoint);
    /// <summary>
    /// <para>Transforms <paramref name="globalPoint" /> from world space to this node's local space.</para>
    /// </summary>
    public Vector3 ToLocal(Vector3 globalPoint) => _node.ToLocal(globalPoint);
    /// <summary>
    /// <para>If <c>true</c>, the node will not inherit its transformations from its parent. Node transformations are only in global space.</para>
    /// </summary>
    public bool TopLevel { get => _node.TopLevel; set => _node.TopLevel = value; }
    /// <summary>
    /// <para>Local space <see cref="Transform3D" /> of this node, with respect to the parent node.</para>
    /// </summary>
    public Transform3D Transform { get => _node.Transform; set => _node.Transform = value; }
    /// <summary>
    /// <para>Changes the node's position by the given offset <see cref="Vector3" />.</para>
    /// <para>Note that the translation <paramref name="offset" /> is affected by the node's scale, so if scaled by e.g. <c>(10, 1, 1)</c>, a translation by an offset of <c>(2, 0, 0)</c> would actually add 20 (<c>2 * 10</c>) to the X coordinate.</para>
    /// </summary>
    public void Translate(Vector3 offset) => _node.Translate(offset);
    /// <summary>
    /// <para>Changes the node's position by the given offset <see cref="Vector3" /> in local space.</para>
    /// </summary>
    public void TranslateObjectLocal(Vector3 offset) => _node.TranslateObjectLocal(offset);
    /// <summary>
    /// <para>Updates all the <see cref="Node3D" /> gizmos attached to this node.</para>
    /// </summary>
    public void UpdateGizmos() => _node.UpdateGizmos();
    /// <summary>
    /// <para>Defines the visibility range parent for this node and its subtree. The visibility parent must be a GeometryInstance3D. Any visual instance will only be visible if the visibility parent (and all of its visibility ancestors) is hidden by being closer to the camera than its own <see cref="GeometryInstance3D.VisibilityRangeBegin" />. Nodes hidden via the <see cref="Node3D.Visible" /> property are essentially removed from the visibility dependency tree, so dependent instances will not take the hidden node or its ancestors into account.</para>
    /// </summary>
    public NodePath VisibilityParent { get => _node.VisibilityParent; set => _node.VisibilityParent = value; }
    /// <summary>
    /// <para>If <c>true</c>, this node is drawn. The node is only visible if all of its ancestors are visible as well (in other words, <see cref="Node3D.IsVisibleInTree" /> must return <c>true</c>).</para>
    /// </summary>
    public bool Visible { get => _node.Visible; set => _node.Visible = value; }

}