namespace Chickensoft.GodotNodeInterfaces;

using Godot;


/// <summary>
/// <para>This node enables OpenXR's hand tracking functionality. The node should be a child node of an <see cref="XROrigin3D" /> node, tracking will update its position to where the player's actual hand is positioned. This node also updates the skeleton of a properly skinned hand model. The hand mesh should be a child node of this node.</para>
/// </summary>
public interface IOpenXRHand : INode3D {
    /// <summary>
    /// <para>Specifies whether this node tracks the left or right hand of the player.</para>
    /// </summary>
    OpenXRHand.Hands Hand { get; set; }
    /// <summary>
    /// <para>Set the motion range (if supported) limiting the hand motion.</para>
    /// </summary>
    OpenXRHand.MotionRangeEnum MotionRange { get; set; }
    /// <summary>
    /// <para>Set a <see cref="Skeleton3D" /> node for which the pose positions will be updated.</para>
    /// </summary>
    NodePath HandSkeleton { get; set; }

}