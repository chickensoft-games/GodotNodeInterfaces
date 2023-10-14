namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>RemoteTransform3D pushes its own <see cref="Transform3D" /> to another <see cref="Node3D" /> derived Node (called the remote node) in the scene.</para>
/// <para>It can be set to update another Node's position, rotation and/or scale. It can use either global or local coordinates.</para>
/// </summary>
public class RemoteTransform3DAdapter : RemoteTransform3D, IRemoteTransform3D {
  private readonly RemoteTransform3D _node;

  public RemoteTransform3DAdapter(RemoteTransform3D node) => _node = node;
    /// <summary>
    /// <para><see cref="RemoteTransform3D" /> caches the remote node. It may not notice if the remote node disappears; <see cref="RemoteTransform3D.ForceUpdateCache" /> forces it to update the cache again.</para>
    /// </summary>
    public void ForceUpdateCache() => _node.ForceUpdateCache();
    /// <summary>
    /// <para>The <see cref="NodePath" /> to the remote node, relative to the RemoteTransform3D's position in the scene.</para>
    /// </summary>
    public NodePath RemotePath { get => _node.RemotePath; set => _node.RemotePath = value; }
    /// <summary>
    /// <para>If <c>true</c>, the remote node's position is updated.</para>
    /// </summary>
    public bool UpdatePosition { get => _node.UpdatePosition; set => _node.UpdatePosition = value; }
    /// <summary>
    /// <para>If <c>true</c>, the remote node's rotation is updated.</para>
    /// </summary>
    public bool UpdateRotation { get => _node.UpdateRotation; set => _node.UpdateRotation = value; }
    /// <summary>
    /// <para>If <c>true</c>, the remote node's scale is updated.</para>
    /// </summary>
    public bool UpdateScale { get => _node.UpdateScale; set => _node.UpdateScale = value; }
    /// <summary>
    /// <para>If <c>true</c>, global coordinates are used. If <c>false</c>, local coordinates are used.</para>
    /// </summary>
    public bool UseGlobalCoordinates { get => _node.UseGlobalCoordinates; set => _node.UseGlobalCoordinates = value; }

}