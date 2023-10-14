namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A hierarchy of <see cref="Bone2D" />s can be bound to a <see cref="Skeleton2D" /> to control and animate other <see cref="Node2D" /> nodes.</para>
/// <para>You can use <see cref="Bone2D" /> and <see cref="Skeleton2D" /> nodes to animate 2D meshes created with the <see cref="Polygon2D" /> UV editor.</para>
/// <para>Each bone has a <see cref="Bone2D.Rest" /> transform that you can reset to with <see cref="Bone2D.ApplyRest" />. These rest poses are relative to the bone's parent.</para>
/// <para>If in the editor, you can set the rest pose of an entire skeleton using a menu option, from the code, you need to iterate over the bones to set their individual rest poses.</para>
/// </summary>
public class Bone2DAdapter : Node2DAdapter, IBone2D {
  private readonly Bone2D _node;

  public Bone2DAdapter(Bone2D node) : base(node) { _node = node; }

    /// <summary>
    /// <para>Stores the node's current transforms in <see cref="Bone2D.Rest" />.</para>
    /// </summary>
    public void ApplyRest() => _node.ApplyRest();
    /// <summary>
    /// <para>Returns whether this <see cref="Bone2D" /> is going to autocalculate its length and bone angle using its first <see cref="Bone2D" /> child node, if one exists. If there are no <see cref="Bone2D" /> children, then it cannot autocalculate these values and will print a warning.</para>
    /// </summary>
    public bool GetAutocalculateLengthAndAngle() => _node.GetAutocalculateLengthAndAngle();
    /// <summary>
    /// <para>Returns the angle of the bone in the <see cref="Bone2D" />.</para>
    /// <para><b>Note:</b> This is different from the <see cref="Bone2D" />'s rotation. The bone's angle is the rotation of the bone shown by the gizmo, which is unaffected by the <see cref="Bone2D" />'s <see cref="Node2D.Transform" />.</para>
    /// </summary>
    public float GetBoneAngle() => _node.GetBoneAngle();
    /// <summary>
    /// <para>Returns the node's index as part of the entire skeleton. See <see cref="Skeleton2D" />.</para>
    /// </summary>
    public int GetIndexInSkeleton() => _node.GetIndexInSkeleton();
    /// <summary>
    /// <para>Returns the length of the bone in the <see cref="Bone2D" /> node.</para>
    /// </summary>
    public float GetLength() => _node.GetLength();
    /// <summary>
    /// <para>Returns the node's <see cref="Bone2D.Rest" /> <see cref="Transform2D" /> if it doesn't have a parent, or its rest pose relative to its parent.</para>
    /// </summary>
    public Transform2D GetSkeletonRest() => _node.GetSkeletonRest();
    /// <summary>
    /// <para>Rest transform of the bone. You can reset the node's transforms to this value using <see cref="Bone2D.ApplyRest" />.</para>
    /// </summary>
    public Transform2D Rest { get => _node.Rest; set => _node.Rest = value; }
    /// <summary>
    /// <para>When set to <c>true</c>, the <see cref="Bone2D" /> node will attempt to automatically calculate the bone angle and length using the first child <see cref="Bone2D" /> node, if one exists. If none exist, the <see cref="Bone2D" /> cannot automatically calculate these values and will print a warning.</para>
    /// </summary>
    public void SetAutocalculateLengthAndAngle(bool autoCalculate) => _node.SetAutocalculateLengthAndAngle(autoCalculate);
    /// <summary>
    /// <para>Sets the bone angle for the <see cref="Bone2D" />. This is typically set to the rotation from the <see cref="Bone2D" /> to a child <see cref="Bone2D" /> node.</para>
    /// <para><b>Note:</b> This is different from the <see cref="Bone2D" />'s rotation. The bone's angle is the rotation of the bone shown by the gizmo, which is unaffected by the <see cref="Bone2D" />'s <see cref="Node2D.Transform" />.</para>
    /// </summary>
    public void SetBoneAngle(float angle) => _node.SetBoneAngle(angle);
    /// <summary>
    /// <para>Sets the length of the bone in the <see cref="Bone2D" />.</para>
    /// </summary>
    public void SetLength(float length) => _node.SetLength(length);

}