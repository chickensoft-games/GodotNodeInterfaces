namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>This node selects a bone in a <see cref="Skeleton3D" /> and attaches to it. This means that the <see cref="BoneAttachment3D" /> node will either dynamically copy or override the 3D transform of the selected bone.</para>
/// </summary>
public interface IBoneAttachment3D : INode3D {
    /// <summary>
    /// <para>A function that is called automatically when the <see cref="Skeleton3D" /> the BoneAttachment3D node is using has a bone that has changed its pose. This function is where the BoneAttachment3D node updates its position so it is correctly bound when it is <i>not</i> set to override the bone pose.</para>
    /// </summary>
    void OnBonePoseUpdate(int boneIndex);
    /// <summary>
    /// <para>Sets whether the BoneAttachment3D node will use an external <see cref="Skeleton3D" /> node rather than attempting to use its parent node as the <see cref="Skeleton3D" />. When set to <c>true</c>, the BoneAttachment3D node will use the external <see cref="Skeleton3D" /> node set in <see cref="M:Godot.BoneAttachment3D.SetExternalSkeleton(Godot.NodePath)" />.</para>
    /// </summary>
    void SetUseExternalSkeleton(bool useExternalSkeleton);
    /// <summary>
    /// <para>Returns whether the BoneAttachment3D node is using an external <see cref="Skeleton3D" /> rather than attempting to use its parent node as the <see cref="Skeleton3D" />.</para>
    /// </summary>
    bool GetUseExternalSkeleton();
    /// <summary>
    /// <para>Sets the <see cref="NodePath" /> to the external skeleton that the BoneAttachment3D node should use. See <see cref="M:Godot.BoneAttachment3D.SetUseExternalSkeleton(System.Boolean)" /> to enable the external <see cref="Skeleton3D" /> node.</para>
    /// </summary>
    void SetExternalSkeleton(NodePath externalSkeleton);
    /// <summary>
    /// <para>Returns the <see cref="NodePath" /> to the external <see cref="Skeleton3D" /> node, if one has been set.</para>
    /// </summary>
    NodePath GetExternalSkeleton();
    /// <summary>
    /// <para>The name of the attached bone.</para>
    /// </summary>
    string BoneName { get; set; }
    /// <summary>
    /// <para>The index of the attached bone.</para>
    /// </summary>
    int BoneIdx { get; set; }
    /// <summary>
    /// <para>Whether the BoneAttachment3D node will override the bone pose of the bone it is attached to. When set to <c>true</c>, the BoneAttachment3D node can change the pose of the bone. When set to <c>false</c>, the BoneAttachment3D will always be set to the bone's transform.</para>
    /// </summary>
    bool OverridePose { get; set; }

}