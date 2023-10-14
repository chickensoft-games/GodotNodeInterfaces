namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>By default, <see cref="MultiplayerSynchronizer" /> synchronizes configured properties to all peers.</para>
/// <para>Visibility can be handled directly with <see cref="MultiplayerSynchronizer.SetVisibilityFor(System.Int32,System.Boolean)" /> or as-needed with <see cref="MultiplayerSynchronizer.AddVisibilityFilter(Godot.Callable)" /> and <see cref="MultiplayerSynchronizer.UpdateVisibility(System.Int32)" />.</para>
/// <para><see cref="MultiplayerSpawner" />s will handle nodes according to visibility of synchronizers as long as the node at <see cref="MultiplayerSynchronizer.RootPath" /> was spawned by one.</para>
/// <para>Internally, <see cref="MultiplayerSynchronizer" /> uses <see cref="MultiplayerApi.ObjectConfigurationAdd(Godot.GodotObject,Godot.Variant)" /> to notify synchronization start passing the <see cref="Node" /> at <see cref="MultiplayerSynchronizer.RootPath" /> as the <c>object</c> and itself as the <c>configuration</c>, and uses <see cref="MultiplayerApi.ObjectConfigurationRemove(Godot.GodotObject,Godot.Variant)" /> to notify synchronization end in a similar way.</para>
/// <para><b>Note:</b> Synchronization is not supported for <see cref="GodotObject" /> type properties, like <see cref="Resource" />. Properties that are unique to each peer, like the instance IDs of <see cref="GodotObject" />s (see <see cref="GodotObject.GetInstanceId" />) or <see cref="Rid" />s, will also not work in synchronization.</para>
/// </summary>
public class MultiplayerSynchronizerAdapter : MultiplayerSynchronizer, IMultiplayerSynchronizer {
  private readonly MultiplayerSynchronizer _node;

  public MultiplayerSynchronizerAdapter(MultiplayerSynchronizer node) => _node = node;
    /// <summary>
    /// <para>Adds a peer visibility filter for this synchronizer.</para>
    /// <para><paramref name="filter" /> should take a peer ID <see cref="T:System.Int32" /> and return a <see cref="T:System.Boolean" />.</para>
    /// </summary>
    public void AddVisibilityFilter(Callable filter) => _node.AddVisibilityFilter(filter);
    /// <summary>
    /// <para>Time interval between delta synchronizations. When set to <c>0.0</c> (the default), delta synchronizations happen every network process frame.</para>
    /// </summary>
    public double DeltaInterval { get => _node.DeltaInterval; set => _node.DeltaInterval = value; }
    /// <summary>
    /// <para>Queries the current visibility for peer <paramref name="peer" />.</para>
    /// </summary>
    public bool GetVisibilityFor(int peer) => _node.GetVisibilityFor(peer);
    /// <summary>
    /// <para>Whether synchronization should be visible to all peers by default. See <see cref="MultiplayerSynchronizer.SetVisibilityFor(System.Int32,System.Boolean)" /> and <see cref="MultiplayerSynchronizer.AddVisibilityFilter(Godot.Callable)" /> for ways of configuring fine-grained visibility options.</para>
    /// </summary>
    public bool PublicVisibility { get => _node.PublicVisibility; set => _node.PublicVisibility = value; }
    /// <summary>
    /// <para>Removes a peer visibility filter from this synchronizer.</para>
    /// </summary>
    public void RemoveVisibilityFilter(Callable filter) => _node.RemoveVisibilityFilter(filter);
    /// <summary>
    /// <para>Resource containing which properties to synchronize.</para>
    /// </summary>
    public SceneReplicationConfig ReplicationConfig { get => _node.ReplicationConfig; set => _node.ReplicationConfig = value; }
    /// <summary>
    /// <para>Time interval between synchronizations. When set to <c>0.0</c> (the default), synchronizations happen every network process frame.</para>
    /// </summary>
    public double ReplicationInterval { get => _node.ReplicationInterval; set => _node.ReplicationInterval = value; }
    /// <summary>
    /// <para>Node path that replicated properties are relative to.</para>
    /// <para>If <see cref="MultiplayerSynchronizer.RootPath" /> was spawned by a <see cref="MultiplayerSpawner" />, the node will be also be spawned and despawned based on this synchronizer visibility options.</para>
    /// </summary>
    public NodePath RootPath { get => _node.RootPath; set => _node.RootPath = value; }
    /// <summary>
    /// <para>Sets the visibility of <paramref name="peer" /> to <paramref name="visible" />. If <paramref name="peer" /> is <c>0</c>, the value of <see cref="MultiplayerSynchronizer.PublicVisibility" /> will be updated instead.</para>
    /// </summary>
    public void SetVisibilityFor(int peer, bool visible) => _node.SetVisibilityFor(peer, visible);
    /// <summary>
    /// <para>Updates the visibility of <paramref name="forPeer" /> according to visibility filters. If <paramref name="forPeer" /> is <c>0</c> (the default), all peers' visibilties are updated.</para>
    /// </summary>
    public void UpdateVisibility(int forPeer) => _node.UpdateVisibility(forPeer);
    /// <summary>
    /// <para>Specifies when visibility filters are updated (see <see cref="MultiplayerSynchronizer.VisibilityUpdateModeEnum" /> for options).</para>
    /// </summary>
    public MultiplayerSynchronizer.VisibilityUpdateModeEnum VisibilityUpdateMode { get => _node.VisibilityUpdateMode; set => _node.VisibilityUpdateMode = value; }

}