namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para>This node enables OpenXR's hand tracking functionality. The node should be a child node of an <see cref="XROrigin3D" /> node, tracking will update its position to where the player's actual hand is positioned. This node also updates the skeleton of a properly skinned hand model. The hand mesh should be a child node of this node.</para>
/// </summary>
public class OpenXRHandAdapter : OpenXRHand, IOpenXRHand {
  private readonly OpenXRHand _node;

  public OpenXRHandAdapter(OpenXRHand node) => _node = node;
    /// <summary>
    /// <para>Specifies whether this node tracks the left or right hand of the player.</para>
    /// </summary>
    public OpenXRHand.Hands Hand { get => _node.Hand; set => _node.Hand = value; }
    /// <summary>
    /// <para>Set a <see cref="Skeleton3D" /> node for which the pose positions will be updated.</para>
    /// </summary>
    public NodePath HandSkeleton { get => _node.HandSkeleton; set => _node.HandSkeleton = value; }
    /// <summary>
    /// <para>Set the motion range (if supported) limiting the hand motion.</para>
    /// </summary>
    public OpenXRHand.MotionRangeEnum MotionRange { get => _node.MotionRange; set => _node.MotionRange = value; }

}