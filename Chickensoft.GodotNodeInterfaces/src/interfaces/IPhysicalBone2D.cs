namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>The <see cref="PhysicalBone2D" /> node is a <see cref="RigidBody2D" />-based node that can be used to make <see cref="Bone2D" />s in a <see cref="Skeleton2D" /> react to physics.</para>
/// <para><b>Note:</b> To make the <see cref="Bone2D" />s visually follow the <see cref="PhysicalBone2D" /> node, use a <see cref="SkeletonModification2DPhysicalBones" /> modification on the <see cref="Skeleton2D" /> parent.</para>
/// <para><b>Note:</b> The <see cref="PhysicalBone2D" /> node does not automatically create a <see cref="Joint2D" /> node to keep <see cref="PhysicalBone2D" /> nodes together. They must be created manually. For most cases, you want to use a <see cref="PinJoint2D" /> node. The <see cref="PhysicalBone2D" /> node will automatically configure the <see cref="Joint2D" /> node once it's been added as a child node.</para>
/// </summary>
public interface IPhysicalBone2D : IRigidBody2D {
    /// <summary>
    /// <para>Returns the first <see cref="Joint2D" /> child node, if one exists. This is mainly a helper function to make it easier to get the <see cref="Joint2D" /> that the <see cref="PhysicalBone2D" /> is autoconfiguring.</para>
    /// </summary>
    Joint2D GetJoint();
    /// <summary>
    /// <para>Returns a boolean that indicates whether the <see cref="PhysicalBone2D" /> is running and simulating using the Godot 2D physics engine. When <c>true</c>, the PhysicalBone2D node is using physics.</para>
    /// </summary>
    bool IsSimulatingPhysics();
    /// <summary>
    /// <para>The <see cref="NodePath" /> to the <see cref="Bone2D" /> that this <see cref="PhysicalBone2D" /> should simulate.</para>
    /// </summary>
    NodePath Bone2DNodePath { get; set; }
    /// <summary>
    /// <para>The index of the <see cref="Bone2D" /> that this <see cref="PhysicalBone2D" /> should simulate.</para>
    /// </summary>
    int Bone2DIndex { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the <see cref="PhysicalBone2D" /> will automatically configure the first <see cref="Joint2D" /> child node. The automatic configuration is limited to setting up the node properties and positioning the <see cref="Joint2D" />.</para>
    /// </summary>
    bool AutoConfigureJoint { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the <see cref="PhysicalBone2D" /> will start simulating using physics. If <c>false</c>, the <see cref="PhysicalBone2D" /> will follow the transform of the <see cref="Bone2D" /> node.</para>
    /// <para><b>Note:</b> To have the <see cref="Bone2D" />s visually follow the <see cref="PhysicalBone2D" />, use a <see cref="SkeletonModification2DPhysicalBones" /> modification on the <see cref="Skeleton2D" /> node with the <see cref="Bone2D" /> nodes.</para>
    /// </summary>
    bool SimulatePhysics { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the <see cref="PhysicalBone2D" /> will keep the transform of the bone it is bound to when simulating physics.</para>
    /// </summary>
    bool FollowBoneWhenSimulating { get; set; }

}