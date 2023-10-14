namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
using Godot.Collections;
/// <summary>
/// <para><see cref="Skeleton3D" /> provides an interface for managing a hierarchy of bones, including pose, rest and animation (see <see cref="Animation" />). It can also use ragdoll physics.</para>
/// <para>The overall transform of a bone with respect to the skeleton is determined by bone pose. Bone rest defines the initial transform of the bone pose.</para>
/// <para>Note that "global pose" below refers to the overall transform of the bone with respect to skeleton, so it is not the actual global/world transform of the bone.</para>
/// <para>To setup different types of inverse kinematics, consider using <see cref="SkeletonIK3D" />, or add a custom IK implementation in <see cref="Node._Process(System.Double)" /> as a child node.</para>
/// </summary>
public class Skeleton3DAdapter : Skeleton3D, ISkeleton3D {
  private readonly Skeleton3D _node;

  public Skeleton3DAdapter(Skeleton3D node) => _node = node;
    /// <summary>
    /// <para>Adds a bone, with name <paramref name="name" />. <see cref="Skeleton3D.GetBoneCount" /> will become the bone index.</para>
    /// </summary>
    public void AddBone(string name) => _node.AddBone(name);

    public bool AnimatePhysicalBones { get => _node.AnimatePhysicalBones; set => _node.AnimatePhysicalBones = value; }
    /// <summary>
    /// <para>Clear all the bones in this skeleton.</para>
    /// </summary>
    public void ClearBones() => _node.ClearBones();
    /// <summary>
    /// <para>Removes the global pose override on all bones in the skeleton.</para>
    /// </summary>
    public void ClearBonesGlobalPoseOverride() => _node.ClearBonesGlobalPoseOverride();

    public Skin CreateSkinFromRestTransforms() => _node.CreateSkinFromRestTransforms();
    /// <summary>
    /// <para>Returns the bone index that matches <paramref name="name" /> as its name.</para>
    /// </summary>
    public int FindBone(string name) => _node.FindBone(name);
    /// <summary>
    /// <para>Force updates the bone transforms/poses for all bones in the skeleton.</para>
    /// <para><i>Deprecated.</i> Do not use.</para>
    /// </summary>
    public void ForceUpdateAllBoneTransforms() => _node.ForceUpdateAllBoneTransforms();
    /// <summary>
    /// <para>Force updates the bone transform for the bone at <paramref name="boneIdx" /> and all of its children.</para>
    /// </summary>
    public void ForceUpdateBoneChildTransform(int boneIdx) => _node.ForceUpdateBoneChildTransform(boneIdx);
    /// <summary>
    /// <para>Returns an array containing the bone indexes of all the children node of the passed in bone, <paramref name="boneIdx" />.</para>
    /// </summary>
    public int[] GetBoneChildren(int boneIdx) => _node.GetBoneChildren(boneIdx);
    /// <summary>
    /// <para>Returns the number of bones in the skeleton.</para>
    /// </summary>
    public int GetBoneCount() => _node.GetBoneCount();
    /// <summary>
    /// <para>Returns the overall transform of the specified bone, with respect to the skeleton. Being relative to the skeleton frame, this is not the actual "global" transform of the bone.</para>
    /// </summary>
    public Transform3D GetBoneGlobalPose(int boneIdx) => _node.GetBoneGlobalPose(boneIdx);
    /// <summary>
    /// <para>Returns the overall transform of the specified bone, with respect to the skeleton, but without any global pose overrides. Being relative to the skeleton frame, this is not the actual "global" transform of the bone.</para>
    /// </summary>
    public Transform3D GetBoneGlobalPoseNoOverride(int boneIdx) => _node.GetBoneGlobalPoseNoOverride(boneIdx);
    /// <summary>
    /// <para>Returns the global pose override transform for <paramref name="boneIdx" />.</para>
    /// </summary>
    public Transform3D GetBoneGlobalPoseOverride(int boneIdx) => _node.GetBoneGlobalPoseOverride(boneIdx);
    /// <summary>
    /// <para>Returns the global rest transform for <paramref name="boneIdx" />.</para>
    /// </summary>
    public Transform3D GetBoneGlobalRest(int boneIdx) => _node.GetBoneGlobalRest(boneIdx);
    /// <summary>
    /// <para>Returns the name of the bone at index <paramref name="boneIdx" />.</para>
    /// </summary>
    public string GetBoneName(int boneIdx) => _node.GetBoneName(boneIdx);
    /// <summary>
    /// <para>Returns the bone index which is the parent of the bone at <paramref name="boneIdx" />. If -1, then bone has no parent.</para>
    /// <para><b>Note:</b> The parent bone returned will always be less than <paramref name="boneIdx" />.</para>
    /// </summary>
    public int GetBoneParent(int boneIdx) => _node.GetBoneParent(boneIdx);
    /// <summary>
    /// <para>Returns the pose transform of the specified bone.</para>
    /// </summary>
    public Transform3D GetBonePose(int boneIdx) => _node.GetBonePose(boneIdx);

    public Vector3 GetBonePosePosition(int boneIdx) => _node.GetBonePosePosition(boneIdx);

    public Quaternion GetBonePoseRotation(int boneIdx) => _node.GetBonePoseRotation(boneIdx);

    public Vector3 GetBonePoseScale(int boneIdx) => _node.GetBonePoseScale(boneIdx);
    /// <summary>
    /// <para>Returns the rest transform for a bone <paramref name="boneIdx" />.</para>
    /// </summary>
    public Transform3D GetBoneRest(int boneIdx) => _node.GetBoneRest(boneIdx);
    /// <summary>
    /// <para>Returns an array with all of the bones that are parentless. Another way to look at this is that it returns the indexes of all the bones that are not dependent or modified by other bones in the Skeleton.</para>
    /// </summary>
    public int[] GetParentlessBones() => _node.GetParentlessBones();
    /// <summary>
    /// <para>Returns the number of times the bone hierarchy has changed within this skeleton, including renames.</para>
    /// <para>The Skeleton version is not serialized: only use within a single instance of Skeleton3D.</para>
    /// <para>Use for invalidating caches in IK solvers and other nodes which process bones.</para>
    /// </summary>
    public ulong GetVersion() => _node.GetVersion();
    /// <summary>
    /// <para>Returns whether the bone pose for the bone at <paramref name="boneIdx" /> is enabled.</para>
    /// </summary>
    public bool IsBoneEnabled(int boneIdx) => _node.IsBoneEnabled(boneIdx);
    /// <summary>
    /// <para>Returns all bones in the skeleton to their rest poses.</para>
    /// </summary>
    public void LocalizeRests() => _node.LocalizeRests();
    /// <summary>
    /// <para>Multiplies the 3D position track animation.</para>
    /// <para><b>Note:</b> Unless this value is <c>1.0</c>, the key value in animation will not match the actual position value.</para>
    /// </summary>
    public float MotionScale { get => _node.MotionScale; set => _node.MotionScale = value; }
    /// <summary>
    /// <para>Adds a collision exception to the physical bone.</para>
    /// <para>Works just like the <see cref="RigidBody3D" /> node.</para>
    /// </summary>
    public void PhysicalBonesAddCollisionException(Rid exception) => _node.PhysicalBonesAddCollisionException(exception);
    /// <summary>
    /// <para>Removes a collision exception to the physical bone.</para>
    /// <para>Works just like the <see cref="RigidBody3D" /> node.</para>
    /// </summary>
    public void PhysicalBonesRemoveCollisionException(Rid exception) => _node.PhysicalBonesRemoveCollisionException(exception);
    /// <summary>
    /// <para>Tells the <see cref="PhysicalBone3D" /> nodes in the Skeleton to start simulating and reacting to the physics world.</para>
    /// <para>Optionally, a list of bone names can be passed-in, allowing only the passed-in bones to be simulated.</para>
    /// </summary>
    public void PhysicalBonesStartSimulation(Godot.Collections.Array<StringName> bones) => _node.PhysicalBonesStartSimulation(bones);
    /// <summary>
    /// <para>Tells the <see cref="PhysicalBone3D" /> nodes in the Skeleton to stop simulating.</para>
    /// </summary>
    public void PhysicalBonesStopSimulation() => _node.PhysicalBonesStopSimulation();
    /// <summary>
    /// <para>Binds the given Skin to the Skeleton.</para>
    /// </summary>
    public SkinReference RegisterSkin(Skin skin) => _node.RegisterSkin(skin);
    /// <summary>
    /// <para>Sets the bone pose to rest for <paramref name="boneIdx" />.</para>
    /// </summary>
    public void ResetBonePose(int boneIdx) => _node.ResetBonePose(boneIdx);
    /// <summary>
    /// <para>Sets all bone poses to rests.</para>
    /// </summary>
    public void ResetBonePoses() => _node.ResetBonePoses();
    /// <summary>
    /// <para>Disables the pose for the bone at <paramref name="boneIdx" /> if <c>false</c>, enables the bone pose if <c>true</c>.</para>
    /// </summary>
    public void SetBoneEnabled(int boneIdx, bool enabled) => _node.SetBoneEnabled(boneIdx, enabled);
    /// <summary>
    /// <para>Sets the global pose transform, <paramref name="pose" />, for the bone at <paramref name="boneIdx" />.</para>
    /// <para><paramref name="amount" /> is the interpolation strength that will be used when applying the pose, and <paramref name="persistent" /> determines if the applied pose will remain.</para>
    /// <para><b>Note:</b> The pose transform needs to be a global pose! To convert a world transform from a <see cref="Node3D" /> to a global bone pose, multiply the <c>Transform3D.affine_inverse</c> of the node's <see cref="Node3D.GlobalTransform" /> by the desired world transform.</para>
    /// </summary>
    public void SetBoneGlobalPoseOverride(int boneIdx, Transform3D pose, float amount, bool persistent) => _node.SetBoneGlobalPoseOverride(boneIdx, pose, amount, persistent);

    public void SetBoneName(int boneIdx, string name) => _node.SetBoneName(boneIdx, name);
    /// <summary>
    /// <para>Sets the bone index <paramref name="parentIdx" /> as the parent of the bone at <paramref name="boneIdx" />. If -1, then bone has no parent.</para>
    /// <para><b>Note:</b> <paramref name="parentIdx" /> must be less than <paramref name="boneIdx" />.</para>
    /// </summary>
    public void SetBoneParent(int boneIdx, int parentIdx) => _node.SetBoneParent(boneIdx, parentIdx);

    public void SetBonePosePosition(int boneIdx, Vector3 position) => _node.SetBonePosePosition(boneIdx, position);

    public void SetBonePoseRotation(int boneIdx, Quaternion rotation) => _node.SetBonePoseRotation(boneIdx, rotation);

    public void SetBonePoseScale(int boneIdx, Vector3 scale) => _node.SetBonePoseScale(boneIdx, scale);
    /// <summary>
    /// <para>Sets the rest transform for bone <paramref name="boneIdx" />.</para>
    /// </summary>
    public void SetBoneRest(int boneIdx, Transform3D rest) => _node.SetBoneRest(boneIdx, rest);

    public bool ShowRestOnly { get => _node.ShowRestOnly; set => _node.ShowRestOnly = value; }
    /// <summary>
    /// <para>Unparents the bone at <paramref name="boneIdx" /> and sets its rest position to that of its parent prior to being reset.</para>
    /// </summary>
    public void UnparentBoneAndRest(int boneIdx) => _node.UnparentBoneAndRest(boneIdx);

}