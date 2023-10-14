namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class Bone2DNode : Bone2D, IBone2D { }

/// <summary>
/// <para>A hierarchy of <see cref="Bone2D" />s can be bound to a <see cref="Skeleton2D" /> to control and animate other <see cref="Node2D" /> nodes.</para>
/// <para>You can use <see cref="Bone2D" /> and <see cref="Skeleton2D" /> nodes to animate 2D meshes created with the <see cref="Polygon2D" /> UV editor.</para>
/// <para>Each bone has a <see cref="Bone2D.Rest" /> transform that you can reset to with <see cref="Bone2D.ApplyRest" />. These rest poses are relative to the bone's parent.</para>
/// <para>If in the editor, you can set the rest pose of an entire skeleton using a menu option, from the code, you need to iterate over the bones to set their individual rest poses.</para>
/// </summary>
public interface IBone2D : INode2D {
    /// <summary>
    /// <para>Stores the node's current transforms in <see cref="Bone2D.Rest" />.</para>
    /// </summary>
    void ApplyRest();
    /// <summary>
    /// <para>Returns whether this <see cref="Bone2D" /> is going to autocalculate its length and bone angle using its first <see cref="Bone2D" /> child node, if one exists. If there are no <see cref="Bone2D" /> children, then it cannot autocalculate these values and will print a warning.</para>
    /// </summary>
    bool GetAutocalculateLengthAndAngle();
    /// <summary>
    /// <para>Returns the angle of the bone in the <see cref="Bone2D" />.</para>
    /// <para><b>Note:</b> This is different from the <see cref="Bone2D" />'s rotation. The bone's angle is the rotation of the bone shown by the gizmo, which is unaffected by the <see cref="Bone2D" />'s <see cref="Node2D.Transform" />.</para>
    /// </summary>
    float GetBoneAngle();
    /// <summary>
    /// <para>Returns the node's index as part of the entire skeleton. See <see cref="Skeleton2D" />.</para>
    /// </summary>
    int GetIndexInSkeleton();
    /// <summary>
    /// <para>Returns the length of the bone in the <see cref="Bone2D" /> node.</para>
    /// </summary>
    float GetLength();
    /// <summary>
    /// <para>Returns the node's <see cref="Bone2D.Rest" /> <see cref="Transform2D" /> if it doesn't have a parent, or its rest pose relative to its parent.</para>
    /// </summary>
    Transform2D GetSkeletonRest();
    /// <summary>
    /// <para>Rest transform of the bone. You can reset the node's transforms to this value using <see cref="Bone2D.ApplyRest" />.</para>
    /// </summary>
    Transform2D Rest { get; set; }
    /// <summary>
    /// <para>When set to <c>true</c>, the <see cref="Bone2D" /> node will attempt to automatically calculate the bone angle and length using the first child <see cref="Bone2D" /> node, if one exists. If none exist, the <see cref="Bone2D" /> cannot automatically calculate these values and will print a warning.</para>
    /// </summary>
    void SetAutocalculateLengthAndAngle(bool autoCalculate);
    /// <summary>
    /// <para>Sets the bone angle for the <see cref="Bone2D" />. This is typically set to the rotation from the <see cref="Bone2D" /> to a child <see cref="Bone2D" /> node.</para>
    /// <para><b>Note:</b> This is different from the <see cref="Bone2D" />'s rotation. The bone's angle is the rotation of the bone shown by the gizmo, which is unaffected by the <see cref="Bone2D" />'s <see cref="Node2D.Transform" />.</para>
    /// </summary>
    void SetBoneAngle(float angle);
    /// <summary>
    /// <para>Sets the length of the bone in the <see cref="Bone2D" />.</para>
    /// </summary>
    void SetLength(float length);

}