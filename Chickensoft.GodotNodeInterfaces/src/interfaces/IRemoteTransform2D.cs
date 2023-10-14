namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class RemoteTransform2DNode : RemoteTransform2D, IRemoteTransform2D { }

/// <summary>
/// <para>RemoteTransform2D pushes its own <see cref="Transform2D" /> to another <see cref="Node2D" /> derived node (called the remote node) in the scene.</para>
/// <para>It can be set to update another node's position, rotation and/or scale. It can use either global or local coordinates.</para>
/// </summary>
public interface IRemoteTransform2D : INode2D {
    /// <summary>
    /// <para><see cref="RemoteTransform2D" /> caches the remote node. It may not notice if the remote node disappears; <see cref="RemoteTransform2D.ForceUpdateCache" /> forces it to update the cache again.</para>
    /// </summary>
    void ForceUpdateCache();
    /// <summary>
    /// <para>The <see cref="NodePath" /> to the remote node, relative to the RemoteTransform2D's position in the scene.</para>
    /// </summary>
    NodePath RemotePath { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the remote node's position is updated.</para>
    /// </summary>
    bool UpdatePosition { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the remote node's rotation is updated.</para>
    /// </summary>
    bool UpdateRotation { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the remote node's scale is updated.</para>
    /// </summary>
    bool UpdateScale { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, global coordinates are used. If <c>false</c>, local coordinates are used.</para>
    /// </summary>
    bool UseGlobalCoordinates { get; set; }

}