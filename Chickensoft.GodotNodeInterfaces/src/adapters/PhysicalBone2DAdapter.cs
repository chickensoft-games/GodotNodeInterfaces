namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>The <see cref="PhysicalBone2D" /> node is a <see cref="RigidBody2D" />-based node that can be used to make <see cref="Bone2D" />s in a <see cref="Skeleton2D" /> react to physics.</para>
/// <para><b>Note:</b> To make the <see cref="Bone2D" />s visually follow the <see cref="PhysicalBone2D" /> node, use a <see cref="SkeletonModification2DPhysicalBones" /> modification on the <see cref="Skeleton2D" /> parent.</para>
/// <para><b>Note:</b> The <see cref="PhysicalBone2D" /> node does not automatically create a <see cref="Joint2D" /> node to keep <see cref="PhysicalBone2D" /> nodes together. They must be created manually. For most cases, you want to use a <see cref="PinJoint2D" /> node. The <see cref="PhysicalBone2D" /> node will automatically configure the <see cref="Joint2D" /> node once it's been added as a child node.</para>
/// </summary>
public class PhysicalBone2DAdapter : RigidBody2DAdapter, IPhysicalBone2D {
  private readonly PhysicalBone2D _node;

  public PhysicalBone2DAdapter(Node node) : base(node) {
    if (node is not PhysicalBone2D typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a PhysicalBone2D"
      );
    }
    _node = typedNode;
  }

    /// <summary>
    /// <para>If <c>true</c>, the <see cref="PhysicalBone2D" /> will automatically configure the first <see cref="Joint2D" /> child node. The automatic configuration is limited to setting up the node properties and positioning the <see cref="Joint2D" />.</para>
    /// </summary>
    public bool AutoConfigureJoint { get => _node.AutoConfigureJoint; set => _node.AutoConfigureJoint = value; }
    /// <summary>
    /// <para>The index of the <see cref="Bone2D" /> that this <see cref="PhysicalBone2D" /> should simulate.</para>
    /// </summary>
    public int Bone2DIndex { get => _node.Bone2DIndex; set => _node.Bone2DIndex = value; }
    /// <summary>
    /// <para>The <see cref="NodePath" /> to the <see cref="Bone2D" /> that this <see cref="PhysicalBone2D" /> should simulate.</para>
    /// </summary>
    public NodePath Bone2DNodePath { get => _node.Bone2DNodePath; set => _node.Bone2DNodePath = value; }
    /// <summary>
    /// <para>If <c>true</c>, the <see cref="PhysicalBone2D" /> will keep the transform of the bone it is bound to when simulating physics.</para>
    /// </summary>
    public bool FollowBoneWhenSimulating { get => _node.FollowBoneWhenSimulating; set => _node.FollowBoneWhenSimulating = value; }
    /// <summary>
    /// <para>Returns the first <see cref="Joint2D" /> child node, if one exists. This is mainly a helper function to make it easier to get the <see cref="Joint2D" /> that the <see cref="PhysicalBone2D" /> is autoconfiguring.</para>
    /// </summary>
    public Joint2D GetJoint() => _node.GetJoint();
    /// <summary>
    /// <para>Returns a boolean that indicates whether the <see cref="PhysicalBone2D" /> is running and simulating using the Godot 2D physics engine. When <c>true</c>, the PhysicalBone2D node is using physics.</para>
    /// </summary>
    public bool IsSimulatingPhysics() => _node.IsSimulatingPhysics();
    /// <summary>
    /// <para>If <c>true</c>, the <see cref="PhysicalBone2D" /> will start simulating using physics. If <c>false</c>, the <see cref="PhysicalBone2D" /> will follow the transform of the <see cref="Bone2D" /> node.</para>
    /// <para><b>Note:</b> To have the <see cref="Bone2D" />s visually follow the <see cref="PhysicalBone2D" />, use a <see cref="SkeletonModification2DPhysicalBones" /> modification on the <see cref="Skeleton2D" /> node with the <see cref="Bone2D" /> nodes.</para>
    /// </summary>
    public bool SimulatePhysics { get => _node.SimulatePhysics; set => _node.SimulatePhysics = value; }

}