namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>RemoteTransform2D pushes its own <see cref="Transform2D" /> to another <see cref="Node2D" /> derived node (called the remote node) in the scene.</para>
/// <para>It can be set to update another node's position, rotation and/or scale. It can use either global or local coordinates.</para>
/// </summary>
public class RemoteTransform2DAdapter : Node2DAdapter, IRemoteTransform2D {
  private readonly RemoteTransform2D _node;

  public RemoteTransform2DAdapter(RemoteTransform2D node) : base(node) { _node = node; }

    /// <summary>
    /// <para><see cref="RemoteTransform2D" /> caches the remote node. It may not notice if the remote node disappears; <see cref="RemoteTransform2D.ForceUpdateCache" /> forces it to update the cache again.</para>
    /// </summary>
    public void ForceUpdateCache() => _node.ForceUpdateCache();
    /// <summary>
    /// <para>The <see cref="NodePath" /> to the remote node, relative to the RemoteTransform2D's position in the scene.</para>
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