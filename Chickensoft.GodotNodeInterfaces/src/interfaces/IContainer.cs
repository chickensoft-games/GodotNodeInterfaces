namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>Base class for all GUI containers. A <see cref="Container" /> automatically arranges its child controls in a certain way. This class can be inherited to make custom container types.</para>
/// </summary>
public interface IContainer : IControl {
    /// <summary>
    /// <para>Implement to return a list of allowed horizontal <see cref="Control.SizeFlags" /> for child nodes. This doesn't technically prevent the usages of any other size flags, if your implementation requires that. This only limits the options available to the user in the Inspector dock.</para>
    /// <para><b>Note:</b> Having no size flags is equal to having <see cref="Control.SizeFlags.ShrinkBegin" />. As such, this value is always implicitly allowed.</para>
    /// </summary>
    int[] _GetAllowedSizeFlagsHorizontal();
    /// <summary>
    /// <para>Implement to return a list of allowed vertical <see cref="Control.SizeFlags" /> for child nodes. This doesn't technically prevent the usages of any other size flags, if your implementation requires that. This only limits the options available to the user in the Inspector dock.</para>
    /// <para><b>Note:</b> Having no size flags is equal to having <see cref="Control.SizeFlags.ShrinkBegin" />. As such, this value is always implicitly allowed.</para>
    /// </summary>
    int[] _GetAllowedSizeFlagsVertical();
    /// <summary>
    /// <para>Queue resort of the contained children. This is called automatically anyway, but can be called upon request.</para>
    /// </summary>
    void QueueSort();
    /// <summary>
    /// <para>Fit a child control in a given rect. This is mainly a helper for creating custom container classes.</para>
    /// </summary>
    void FitChildInRect(Control child, Rect2 rect);

}