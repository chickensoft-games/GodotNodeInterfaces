 namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>Base class for all GUI containers. A <see cref="Container" /> automatically arranges its child controls in a certain way. This class can be inherited to make custom container types.</para>
/// </summary>
public class ContainerAdapter : Container, IContainer {
  private readonly Container _node;

  public ContainerAdapter(Container node) => _node = node;
    /// <summary>
    /// <para>Implement to return a list of allowed horizontal <see cref="Control.SizeFlags" /> for child nodes. This doesn't technically prevent the usages of any other size flags, if your implementation requires that. This only limits the options available to the user in the Inspector dock.</para>
    /// <para><b>Note:</b> Having no size flags is equal to having <see cref="Control.SizeFlags.ShrinkBegin" />. As such, this value is always implicitly allowed.</para>
    /// </summary>
    public int[] _GetAllowedSizeFlagsHorizontal() => _node._GetAllowedSizeFlagsHorizontal();
    /// <summary>
    /// <para>Implement to return a list of allowed vertical <see cref="Control.SizeFlags" /> for child nodes. This doesn't technically prevent the usages of any other size flags, if your implementation requires that. This only limits the options available to the user in the Inspector dock.</para>
    /// <para><b>Note:</b> Having no size flags is equal to having <see cref="Control.SizeFlags.ShrinkBegin" />. As such, this value is always implicitly allowed.</para>
    /// </summary>
    public int[] _GetAllowedSizeFlagsVertical() => _node._GetAllowedSizeFlagsVertical();
    /// <summary>
    /// <para>Fit a child control in a given rect. This is mainly a helper for creating custom container classes.</para>
    /// </summary>
    public void FitChildInRect(Control child, Rect2 rect) => _node.FitChildInRect(child, rect);
    /// <summary>
    /// <para>Queue resort of the contained children. This is called automatically anyway, but can be called upon request.</para>
    /// </summary>
    public void QueueSort() => _node.QueueSort();

}