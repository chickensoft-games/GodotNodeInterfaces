namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A container type that arranges its child controls in a way that preserves their proportions automatically when the container is resized. Useful when a container has a dynamic size and the child nodes must adjust their sizes accordingly without losing their aspect ratios.</para>
/// </summary>
public class AspectRatioContainerAdapter : AspectRatioContainer, IAspectRatioContainer {
  private readonly AspectRatioContainer _node;

  public AspectRatioContainerAdapter(AspectRatioContainer node) => _node = node;
    /// <summary>
    /// <para>Specifies the horizontal relative position of child controls.</para>
    /// </summary>
    public AspectRatioContainer.AlignmentMode AlignmentHorizontal { get => _node.AlignmentHorizontal; set => _node.AlignmentHorizontal = value; }
    /// <summary>
    /// <para>Specifies the vertical relative position of child controls.</para>
    /// </summary>
    public AspectRatioContainer.AlignmentMode AlignmentVertical { get => _node.AlignmentVertical; set => _node.AlignmentVertical = value; }
    /// <summary>
    /// <para>The aspect ratio to enforce on child controls. This is the width divided by the height. The ratio depends on the <see cref="AspectRatioContainer.StretchMode" />.</para>
    /// </summary>
    public float Ratio { get => _node.Ratio; set => _node.Ratio = value; }
    /// <summary>
    /// <para>The stretch mode used to align child controls.</para>
    /// </summary>
    public AspectRatioContainer.StretchModeEnum StretchMode { get => _node.StretchMode; set => _node.StretchMode = value; }

}