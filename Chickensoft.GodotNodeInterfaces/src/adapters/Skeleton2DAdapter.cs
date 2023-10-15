namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para><see cref="Skeleton2D" /> parents a hierarchy of <see cref="Bone2D" /> nodes. It holds a reference to each <see cref="Bone2D" />'s rest pose and acts as a single point of access to its bones.</para>
/// <para>To set up different types of inverse kinematics for the given Skeleton2D, a <see cref="SkeletonModificationStack2D" /> should be created. The inverse kinematics be applied by increasing <see cref="SkeletonModificationStack2D.ModificationCount" /> and creating the desired number of modifications.</para>
/// </summary>
public class Skeleton2DAdapter : Node2DAdapter, ISkeleton2D {
  private readonly Skeleton2D _node;

  public Skeleton2DAdapter(Node node) : base(node) {
    if (node is not Skeleton2D typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a Skeleton2D"
      );
    }
    _node = typedNode;
  }

    /// <summary>
    /// <para>Executes all the modifications on the <see cref="SkeletonModificationStack2D" />, if the Skeleton2D has one assigned.</para>
    /// </summary>
    public void ExecuteModifications(float delta, int executionMode) => _node.ExecuteModifications(delta, executionMode);
    /// <summary>
    /// <para>Returns a <see cref="Bone2D" /> from the node hierarchy parented by Skeleton2D. The object to return is identified by the parameter <paramref name="idx" />. Bones are indexed by descending the node hierarchy from top to bottom, adding the children of each branch before moving to the next sibling.</para>
    /// </summary>
    public Bone2D GetBone(int idx) => _node.GetBone(idx);
    /// <summary>
    /// <para>Returns the number of <see cref="Bone2D" /> nodes in the node hierarchy parented by Skeleton2D.</para>
    /// </summary>
    public int GetBoneCount() => _node.GetBoneCount();
    /// <summary>
    /// <para>Returns the local pose override transform for <paramref name="boneIdx" />.</para>
    /// </summary>
    public Transform2D GetBoneLocalPoseOverride(int boneIdx) => _node.GetBoneLocalPoseOverride(boneIdx);
    /// <summary>
    /// <para>Returns the <see cref="SkeletonModificationStack2D" /> attached to this skeleton, if one exists.</para>
    /// </summary>
    public SkeletonModificationStack2D GetModificationStack() => _node.GetModificationStack();
    /// <summary>
    /// <para>Returns the <see cref="Rid" /> of a Skeleton2D instance.</para>
    /// </summary>
    public Rid GetSkeleton() => _node.GetSkeleton();
    /// <summary>
    /// <para>Sets the local pose transform, <paramref name="overridePose" />, for the bone at <paramref name="boneIdx" />.</para>
    /// <para><paramref name="strength" /> is the interpolation strength that will be used when applying the pose, and <paramref name="persistent" /> determines if the applied pose will remain.</para>
    /// <para><b>Note:</b> The pose transform needs to be a local transform relative to the <see cref="Bone2D" /> node at <paramref name="boneIdx" />!</para>
    /// </summary>
    public void SetBoneLocalPoseOverride(int boneIdx, Transform2D overridePose, float strength, bool persistent) => _node.SetBoneLocalPoseOverride(boneIdx, overridePose, strength, persistent);
    /// <summary>
    /// <para>Sets the <see cref="SkeletonModificationStack2D" /> attached to this skeleton.</para>
    /// </summary>
    public void SetModificationStack(SkeletonModificationStack2D modificationStack) => _node.SetModificationStack(modificationStack);

}