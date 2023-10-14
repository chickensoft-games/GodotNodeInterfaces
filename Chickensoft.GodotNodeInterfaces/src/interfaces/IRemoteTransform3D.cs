namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>RemoteTransform3D pushes its own <see cref="Transform3D" /> to another <see cref="Node3D" /> derived Node (called the remote node) in the scene.</para>
/// <para>It can be set to update another Node's position, rotation and/or scale. It can use either global or local coordinates.</para>
/// </summary>
public interface IRemoteTransform3D : INode3D {
    /// <summary>
    /// <para><see cref="RemoteTransform3D" /> caches the remote node. It may not notice if the remote node disappears; <see cref="RemoteTransform3D.ForceUpdateCache" /> forces it to update the cache again.</para>
    /// </summary>
    void ForceUpdateCache();
    /// <summary>
    /// <para>The <see cref="NodePath" /> to the remote node, relative to the RemoteTransform3D's position in the scene.</para>
    /// </summary>
    NodePath RemotePath { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, global coordinates are used. If <c>false</c>, local coordinates are used.</para>
    /// </summary>
    bool UseGlobalCoordinates { get; set; }
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

}