namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class AspectRatioContainerNode : AspectRatioContainer, IAspectRatioContainer { }

/// <summary>
/// <para>A container type that arranges its child controls in a way that preserves their proportions automatically when the container is resized. Useful when a container has a dynamic size and the child nodes must adjust their sizes accordingly without losing their aspect ratios.</para>
/// </summary>
public interface IAspectRatioContainer : IContainer {
    /// <summary>
    /// <para>Specifies the horizontal relative position of child controls.</para>
    /// </summary>
    AspectRatioContainer.AlignmentMode AlignmentHorizontal { get; set; }
    /// <summary>
    /// <para>Specifies the vertical relative position of child controls.</para>
    /// </summary>
    AspectRatioContainer.AlignmentMode AlignmentVertical { get; set; }
    /// <summary>
    /// <para>The aspect ratio to enforce on child controls. This is the width divided by the height. The ratio depends on the <see cref="AspectRatioContainer.StretchMode" />.</para>
    /// </summary>
    float Ratio { get; set; }
    /// <summary>
    /// <para>The stretch mode used to align child controls.</para>
    /// </summary>
    AspectRatioContainer.StretchModeEnum StretchMode { get; set; }

}