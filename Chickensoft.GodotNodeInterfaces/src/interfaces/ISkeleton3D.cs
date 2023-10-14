namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
using Godot.Collections;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class Skeleton3DNode : Skeleton3D, ISkeleton3D { }

/// <summary>
/// <para><see cref="Skeleton3D" /> provides an interface for managing a hierarchy of bones, including pose, rest and animation (see <see cref="Animation" />). It can also use ragdoll physics.</para>
/// <para>The overall transform of a bone with respect to the skeleton is determined by bone pose. Bone rest defines the initial transform of the bone pose.</para>
/// <para>Note that "global pose" below refers to the overall transform of the bone with respect to skeleton, so it is not the actual global/world transform of the bone.</para>
/// <para>To setup different types of inverse kinematics, consider using <see cref="SkeletonIK3D" />, or add a custom IK implementation in <see cref="Node._Process(System.Double)" /> as a child node.</para>
/// </summary>
public interface ISkeleton3D : INode3D {
    /// <summary>
    /// <para>Adds a bone, with name <paramref name="name" />. <see cref="Skeleton3D.GetBoneCount" /> will become the bone index.</para>
    /// </summary>
    void AddBone(string name);

    bool AnimatePhysicalBones { get; set; }
    /// <summary>
    /// <para>Clear all the bones in this skeleton.</para>
    /// </summary>
    void ClearBones();
    /// <summary>
    /// <para>Removes the global pose override on all bones in the skeleton.</para>
    /// </summary>
    void ClearBonesGlobalPoseOverride();

    Skin CreateSkinFromRestTransforms();
    /// <summary>
    /// <para>Returns the bone index that matches <paramref name="name" /> as its name.</para>
    /// </summary>
    int FindBone(string name);
    /// <summary>
    /// <para>Force updates the bone transforms/poses for all bones in the skeleton.</para>
    /// <para><i>Deprecated.</i> Do not use.</para>
    /// </summary>
    void ForceUpdateAllBoneTransforms();
    /// <summary>
    /// <para>Force updates the bone transform for the bone at <paramref name="boneIdx" /> and all of its children.</para>
    /// </summary>
    void ForceUpdateBoneChildTransform(int boneIdx);
    /// <summary>
    /// <para>Returns an array containing the bone indexes of all the children node of the passed in bone, <paramref name="boneIdx" />.</para>
    /// </summary>
    int[] GetBoneChildren(int boneIdx);
    /// <summary>
    /// <para>Returns the number of bones in the skeleton.</para>
    /// </summary>
    int GetBoneCount();
    /// <summary>
    /// <para>Returns the overall transform of the specified bone, with respect to the skeleton. Being relative to the skeleton frame, this is not the actual "global" transform of the bone.</para>
    /// </summary>
    Transform3D GetBoneGlobalPose(int boneIdx);
    /// <summary>
    /// <para>Returns the overall transform of the specified bone, with respect to the skeleton, but without any global pose overrides. Being relative to the skeleton frame, this is not the actual "global" transform of the bone.</para>
    /// </summary>
    Transform3D GetBoneGlobalPoseNoOverride(int boneIdx);
    /// <summary>
    /// <para>Returns the global pose override transform for <paramref name="boneIdx" />.</para>
    /// </summary>
    Transform3D GetBoneGlobalPoseOverride(int boneIdx);
    /// <summary>
    /// <para>Returns the global rest transform for <paramref name="boneIdx" />.</para>
    /// </summary>
    Transform3D GetBoneGlobalRest(int boneIdx);
    /// <summary>
    /// <para>Returns the name of the bone at index <paramref name="boneIdx" />.</para>
    /// </summary>
    string GetBoneName(int boneIdx);
    /// <summary>
    /// <para>Returns the bone index which is the parent of the bone at <paramref name="boneIdx" />. If -1, then bone has no parent.</para>
    /// <para><b>Note:</b> The parent bone returned will always be less than <paramref name="boneIdx" />.</para>
    /// </summary>
    int GetBoneParent(int boneIdx);
    /// <summary>
    /// <para>Returns the pose transform of the specified bone.</para>
    /// </summary>
    Transform3D GetBonePose(int boneIdx);

    Vector3 GetBonePosePosition(int boneIdx);

    Quaternion GetBonePoseRotation(int boneIdx);

    Vector3 GetBonePoseScale(int boneIdx);
    /// <summary>
    /// <para>Returns the rest transform for a bone <paramref name="boneIdx" />.</para>
    /// </summary>
    Transform3D GetBoneRest(int boneIdx);
    /// <summary>
    /// <para>Returns an array with all of the bones that are parentless. Another way to look at this is that it returns the indexes of all the bones that are not dependent or modified by other bones in the Skeleton.</para>
    /// </summary>
    int[] GetParentlessBones();
    /// <summary>
    /// <para>Returns the number of times the bone hierarchy has changed within this skeleton, including renames.</para>
    /// <para>The Skeleton version is not serialized: only use within a single instance of Skeleton3D.</para>
    /// <para>Use for invalidating caches in IK solvers and other nodes which process bones.</para>
    /// </summary>
    ulong GetVersion();
    /// <summary>
    /// <para>Returns whether the bone pose for the bone at <paramref name="boneIdx" /> is enabled.</para>
    /// </summary>
    bool IsBoneEnabled(int boneIdx);
    /// <summary>
    /// <para>Returns all bones in the skeleton to their rest poses.</para>
    /// </summary>
    void LocalizeRests();
    /// <summary>
    /// <para>Multiplies the 3D position track animation.</para>
    /// <para><b>Note:</b> Unless this value is <c>1.0</c>, the key value in animation will not match the actual position value.</para>
    /// </summary>
    float MotionScale { get; set; }
    /// <summary>
    /// <para>Adds a collision exception to the physical bone.</para>
    /// <para>Works just like the <see cref="RigidBody3D" /> node.</para>
    /// </summary>
    void PhysicalBonesAddCollisionException(Rid exception);
    /// <summary>
    /// <para>Removes a collision exception to the physical bone.</para>
    /// <para>Works just like the <see cref="RigidBody3D" /> node.</para>
    /// </summary>
    void PhysicalBonesRemoveCollisionException(Rid exception);
    /// <summary>
    /// <para>Tells the <see cref="PhysicalBone3D" /> nodes in the Skeleton to start simulating and reacting to the physics world.</para>
    /// <para>Optionally, a list of bone names can be passed-in, allowing only the passed-in bones to be simulated.</para>
    /// </summary>
    void PhysicalBonesStartSimulation(Godot.Collections.Array<StringName> bones);
    /// <summary>
    /// <para>Tells the <see cref="PhysicalBone3D" /> nodes in the Skeleton to stop simulating.</para>
    /// </summary>
    void PhysicalBonesStopSimulation();
    /// <summary>
    /// <para>Binds the given Skin to the Skeleton.</para>
    /// </summary>
    SkinReference RegisterSkin(Skin skin);
    /// <summary>
    /// <para>Sets the bone pose to rest for <paramref name="boneIdx" />.</para>
    /// </summary>
    void ResetBonePose(int boneIdx);
    /// <summary>
    /// <para>Sets all bone poses to rests.</para>
    /// </summary>
    void ResetBonePoses();
    /// <summary>
    /// <para>Disables the pose for the bone at <paramref name="boneIdx" /> if <c>false</c>, enables the bone pose if <c>true</c>.</para>
    /// </summary>
    void SetBoneEnabled(int boneIdx, bool enabled);
    /// <summary>
    /// <para>Sets the global pose transform, <paramref name="pose" />, for the bone at <paramref name="boneIdx" />.</para>
    /// <para><paramref name="amount" /> is the interpolation strength that will be used when applying the pose, and <paramref name="persistent" /> determines if the applied pose will remain.</para>
    /// <para><b>Note:</b> The pose transform needs to be a global pose! To convert a world transform from a <see cref="Node3D" /> to a global bone pose, multiply the <c>Transform3D.affine_inverse</c> of the node's <see cref="Node3D.GlobalTransform" /> by the desired world transform.</para>
    /// </summary>
    void SetBoneGlobalPoseOverride(int boneIdx, Transform3D pose, float amount, bool persistent);

    void SetBoneName(int boneIdx, string name);
    /// <summary>
    /// <para>Sets the bone index <paramref name="parentIdx" /> as the parent of the bone at <paramref name="boneIdx" />. If -1, then bone has no parent.</para>
    /// <para><b>Note:</b> <paramref name="parentIdx" /> must be less than <paramref name="boneIdx" />.</para>
    /// </summary>
    void SetBoneParent(int boneIdx, int parentIdx);

    void SetBonePosePosition(int boneIdx, Vector3 position);

    void SetBonePoseRotation(int boneIdx, Quaternion rotation);

    void SetBonePoseScale(int boneIdx, Vector3 scale);
    /// <summary>
    /// <para>Sets the rest transform for bone <paramref name="boneIdx" />.</para>
    /// </summary>
    void SetBoneRest(int boneIdx, Transform3D rest);

    bool ShowRestOnly { get; set; }
    /// <summary>
    /// <para>Unparents the bone at <paramref name="boneIdx" /> and sets its rest position to that of its parent prior to being reset.</para>
    /// </summary>
    void UnparentBoneAndRest(int boneIdx);

}