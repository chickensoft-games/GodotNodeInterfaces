namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A container that displays the contents of underlying <see cref="SubViewport" /> child nodes. It uses the combined size of the <see cref="SubViewport" />s as minimum size, unless <see cref="SubViewportContainer.Stretch" /> is enabled.</para>
/// <para><b>Note:</b> Changing a <see cref="SubViewportContainer" />'s <see cref="Control.Scale" /> will cause its contents to appear distorted. To change its visual size without causing distortion, adjust the node's margins instead (if it's not already in a container).</para>
/// <para><b>Note:</b> The <see cref="SubViewportContainer" /> forwards mouse-enter and mouse-exit notifications to its sub-viewports.</para>
/// </summary>
public class SubViewportContainerAdapter : ContainerAdapter, ISubViewportContainer {
  private readonly SubViewportContainer _node;

  public SubViewportContainerAdapter(Node node) : base(node) {
    if (node is not SubViewportContainer typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a SubViewportContainer"
      );
    }
    _node = typedNode;
  }

    /// <summary>
    /// <para>Virtual method to be implemented by the user. If it returns <c>true</c>, the <paramref name="event" /> is propagated to <see cref="SubViewport" /> children. Propagation doesn't happen if it returns <c>false</c>. If the function is not implemented, all events are propagated to SubViewports.</para>
    /// </summary>
    public bool _PropagateInputEvent(InputEvent @event) => _node._PropagateInputEvent(@event);
    /// <summary>
    /// <para>If <c>true</c>, the sub-viewport will be automatically resized to the control's size.</para>
    /// <para><b>Note:</b> If <c>true</c>, this will prohibit changing <see cref="SubViewport.Size" /> of its children manually.</para>
    /// </summary>
    public bool Stretch { get => _node.Stretch; set => _node.Stretch = value; }
    /// <summary>
    /// <para>Divides the sub-viewport's effective resolution by this value while preserving its scale. This can be used to speed up rendering.</para>
    /// <para>For example, a 1280×720 sub-viewport with <see cref="SubViewportContainer.StretchShrink" /> set to <c>2</c> will be rendered at 640×360 while occupying the same size in the container.</para>
    /// <para><b>Note:</b> <see cref="SubViewportContainer.Stretch" /> must be <c>true</c> for this property to work.</para>
    /// </summary>
    public int StretchShrink { get => _node.StretchShrink; set => _node.StretchShrink = value; }

}