namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class SkeletonIK3DNode : SkeletonIK3D, ISkeletonIK3D { }

/// <summary>
/// <para>SkeletonIK3D is used to rotate all bones of a <see cref="Skeleton3D" /> bone chain a way that places the end bone at a desired 3D position. A typical scenario for IK in games is to place a character's feet on the ground or a character's hands on a currently held object. SkeletonIK uses FabrikInverseKinematic internally to solve the bone chain and applies the results to the <see cref="Skeleton3D" /> <c>bones_global_pose_override</c> property for all affected bones in the chain. If fully applied, this overwrites any bone transform from <see cref="Animation" />s or bone custom poses set by users. The applied amount can be controlled with the <see cref="SkeletonIK3D.Interpolation" /> property.</para>
/// <para><code>
/// # Apply IK effect automatically on every new frame (not the current)
/// skeleton_ik_node.start()
/// # Apply IK effect only on the current frame
/// skeleton_ik_node.start(true)
/// # Stop IK effect and reset bones_global_pose_override on Skeleton
/// skeleton_ik_node.stop()
/// # Apply full IK effect
/// skeleton_ik_node.set_interpolation(1.0)
/// # Apply half IK effect
/// skeleton_ik_node.set_interpolation(0.5)
/// # Apply zero IK effect (a value at or below 0.01 also removes bones_global_pose_override on Skeleton)
/// skeleton_ik_node.set_interpolation(0.0)
/// </code></para>
/// <para><i>Deprecated.</i> This class is deprecated, and might be removed in a future release.</para>
/// </summary>
public interface ISkeletonIK3D : INode {
    /// <summary>
    /// <para>Returns the parent <see cref="Skeleton3D" /> Node that was present when SkeletonIK entered the <see cref="SceneTree" />. Returns null if the parent node was not a <see cref="Skeleton3D" /> Node when SkeletonIK3D entered the <see cref="SceneTree" />.</para>
    /// </summary>
    Skeleton3D GetParentSkeleton();
    /// <summary>
    /// <para>Interpolation value for how much the IK results are applied to the current skeleton bone chain. A value of <c>1.0</c> will overwrite all skeleton bone transforms completely while a value of <c>0.0</c> will visually disable the SkeletonIK. A value at or below <c>0.01</c> also calls <see cref="Skeleton3D.ClearBonesGlobalPoseOverride" />.</para>
    /// </summary>
    float Interpolation { get; set; }
    /// <summary>
    /// <para>Returns <c>true</c> if SkeletonIK is applying IK effects on continues frames to the <see cref="Skeleton3D" /> bones. Returns <c>false</c> if SkeletonIK is stopped or <see cref="SkeletonIK3D.Start(System.Boolean)" /> was used with the <c>one_time</c> parameter set to <c>true</c>.</para>
    /// </summary>
    bool IsRunning();
    /// <summary>
    /// <para>Secondary target position (first is <see cref="SkeletonIK3D.Target" /> property or <see cref="SkeletonIK3D.TargetNode" />) for the IK chain. Use magnet position (pole target) to control the bending of the IK chain. Only works if the bone chain has more than 2 bones. The middle chain bone position will be linearly interpolated with the magnet position.</para>
    /// </summary>
    Vector3 Magnet { get; set; }
    /// <summary>
    /// <para>Number of iteration loops used by the IK solver to produce more accurate (and elegant) bone chain results.</para>
    /// </summary>
    int MaxIterations { get; set; }
    /// <summary>
    /// <para>The minimum distance between bone and goal target. If the distance is below this value, the IK solver stops further iterations.</para>
    /// </summary>
    float MinDistance { get; set; }
    /// <summary>
    /// <para>If <c>true</c> overwrites the rotation of the tip bone with the rotation of the <see cref="SkeletonIK3D.Target" /> (or <see cref="SkeletonIK3D.TargetNode" /> if defined).</para>
    /// </summary>
    bool OverrideTipBasis { get; set; }
    /// <summary>
    /// <para>The name of the current root bone, the first bone in the IK chain.</para>
    /// </summary>
    StringName RootBone { get; set; }
    /// <summary>
    /// <para>Starts applying IK effects on each frame to the <see cref="Skeleton3D" /> bones but will only take effect starting on the next frame. If <paramref name="oneTime" /> is <c>true</c>, this will take effect immediately but also reset on the next frame.</para>
    /// </summary>
    void Start(bool oneTime);
    /// <summary>
    /// <para>Stops applying IK effects on each frame to the <see cref="Skeleton3D" /> bones and also calls <see cref="Skeleton3D.ClearBonesGlobalPoseOverride" /> to remove existing overrides on all bones.</para>
    /// </summary>
    void Stop();
    /// <summary>
    /// <para>First target of the IK chain where the tip bone is placed and, if <see cref="SkeletonIK3D.OverrideTipBasis" /> is <c>true</c>, how the tip bone is rotated. If a <see cref="SkeletonIK3D.TargetNode" /> path is available the nodes transform is used instead and this property is ignored.</para>
    /// </summary>
    Transform3D Target { get; set; }
    /// <summary>
    /// <para>Target node <see cref="NodePath" /> for the IK chain. If available, the node's current <see cref="Transform3D" /> is used instead of the <see cref="SkeletonIK3D.Target" /> property.</para>
    /// </summary>
    NodePath TargetNode { get; set; }
    /// <summary>
    /// <para>The name of the current tip bone, the last bone in the IK chain placed at the <see cref="SkeletonIK3D.Target" /> transform (or <see cref="SkeletonIK3D.TargetNode" /> if defined).</para>
    /// </summary>
    StringName TipBone { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, instructs the IK solver to consider the secondary magnet target (pole target) when calculating the bone chain. Use the magnet position (pole target) to control the bending of the IK chain.</para>
    /// </summary>
    bool UseMagnet { get; set; }

}