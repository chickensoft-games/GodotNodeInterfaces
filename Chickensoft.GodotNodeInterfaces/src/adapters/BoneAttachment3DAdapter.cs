namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>This node selects a bone in a <see cref="Skeleton3D" /> and attaches to it. This means that the <see cref="BoneAttachment3D" /> node will either dynamically copy or override the 3D transform of the selected bone.</para>
/// </summary>
public class BoneAttachment3DAdapter : Node3DAdapter, IBoneAttachment3D {
  private readonly BoneAttachment3D _node;

  public BoneAttachment3DAdapter(BoneAttachment3D node) : base(node) { _node = node; }

    /// <summary>
    /// <para>The index of the attached bone.</para>
    /// </summary>
    public int BoneIdx { get => _node.BoneIdx; set => _node.BoneIdx = value; }
    /// <summary>
    /// <para>The name of the attached bone.</para>
    /// </summary>
    public string BoneName { get => _node.BoneName; set => _node.BoneName = value; }
    /// <summary>
    /// <para>Returns the <see cref="NodePath" /> to the external <see cref="Skeleton3D" /> node, if one has been set.</para>
    /// </summary>
    public NodePath GetExternalSkeleton() => _node.GetExternalSkeleton();
    /// <summary>
    /// <para>Returns whether the BoneAttachment3D node is using an external <see cref="Skeleton3D" /> rather than attempting to use its parent node as the <see cref="Skeleton3D" />.</para>
    /// </summary>
    public bool GetUseExternalSkeleton() => _node.GetUseExternalSkeleton();
    /// <summary>
    /// <para>A function that is called automatically when the <see cref="Skeleton3D" /> the BoneAttachment3D node is using has a bone that has changed its pose. This function is where the BoneAttachment3D node updates its position so it is correctly bound when it is <i>not</i> set to override the bone pose.</para>
    /// </summary>
    public void OnBonePoseUpdate(int boneIndex) => _node.OnBonePoseUpdate(boneIndex);
    /// <summary>
    /// <para>Whether the BoneAttachment3D node will override the bone pose of the bone it is attached to. When set to <c>true</c>, the BoneAttachment3D node can change the pose of the bone. When set to <c>false</c>, the BoneAttachment3D will always be set to the bone's transform.</para>
    /// </summary>
    public bool OverridePose { get => _node.OverridePose; set => _node.OverridePose = value; }
    /// <summary>
    /// <para>Sets the <see cref="NodePath" /> to the external skeleton that the BoneAttachment3D node should use. See <see cref="BoneAttachment3D.SetUseExternalSkeleton(System.Boolean)" /> to enable the external <see cref="Skeleton3D" /> node.</para>
    /// </summary>
    public void SetExternalSkeleton(NodePath externalSkeleton) => _node.SetExternalSkeleton(externalSkeleton);
    /// <summary>
    /// <para>Sets whether the BoneAttachment3D node will use an external <see cref="Skeleton3D" /> node rather than attempting to use its parent node as the <see cref="Skeleton3D" />. When set to <c>true</c>, the BoneAttachment3D node will use the external <see cref="Skeleton3D" /> node set in <see cref="BoneAttachment3D.SetExternalSkeleton(Godot.NodePath)" />.</para>
    /// </summary>
    public void SetUseExternalSkeleton(bool useExternalSkeleton) => _node.SetUseExternalSkeleton(useExternalSkeleton);

}