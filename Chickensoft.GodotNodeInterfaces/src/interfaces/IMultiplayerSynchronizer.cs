namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>By default, <see cref="MultiplayerSynchronizer" /> synchronizes configured properties to all peers.</para>
/// <para>Visibility can be handled directly with <see cref="M:Godot.MultiplayerSynchronizer.SetVisibilityFor(System.Int32,System.Boolean)" /> or as-needed with <see cref="M:Godot.MultiplayerSynchronizer.AddVisibilityFilter(Godot.Callable)" /> and <see cref="M:Godot.MultiplayerSynchronizer.UpdateVisibility(System.Int32)" />.</para>
/// <para><see cref="MultiplayerSpawner" />s will handle nodes according to visibility of synchronizers as long as the node at <see cref="MultiplayerSynchronizer.RootPath" /> was spawned by one.</para>
/// <para>Internally, <see cref="MultiplayerSynchronizer" /> uses <see cref="M:Godot.MultiplayerApi.ObjectConfigurationAdd(Godot.GodotObject,Godot.Variant)" /> to notify synchronization start passing the <see cref="Node" /> at <see cref="MultiplayerSynchronizer.RootPath" /> as the <c>object</c> and itself as the <c>configuration</c>, and uses <see cref="M:Godot.MultiplayerApi.ObjectConfigurationRemove(Godot.GodotObject,Godot.Variant)" /> to notify synchronization end in a similar way.</para>
/// <para><b>Note:</b> Synchronization is not supported for <see cref="GodotObject" /> type properties, like <see cref="Resource" />. Properties that are unique to each peer, like the instance IDs of <see cref="GodotObject" />s (see <see cref="GodotObject.GetInstanceId" />) or <see cref="Rid" />s, will also not work in synchronization.</para>
/// </summary>
public interface IMultiplayerSynchronizer {
    /// <summary>
    /// <para>Updates the visibility of <paramref name="forPeer" /> according to visibility filters. If <paramref name="forPeer" /> is <c>0</c> (the default), all peers' visibilties are updated.</para>
    /// </summary>
    void UpdateVisibility(int forPeer);
    /// <summary>
    /// <para>Adds a peer visibility filter for this synchronizer.</para>
    /// <para><paramref name="filter" /> should take a peer ID <see cref="T:System.Int32" /> and return a <see cref="T:System.Boolean" />.</para>
    /// </summary>
    void AddVisibilityFilter(Callable filter);
    /// <summary>
    /// <para>Removes a peer visibility filter from this synchronizer.</para>
    /// </summary>
    void RemoveVisibilityFilter(Callable filter);
    /// <summary>
    /// <para>Sets the visibility of <paramref name="peer" /> to <paramref name="visible" />. If <paramref name="peer" /> is <c>0</c>, the value of <see cref="MultiplayerSynchronizer.PublicVisibility" /> will be updated instead.</para>
    /// </summary>
    void SetVisibilityFor(int peer, bool visible);
    /// <summary>
    /// <para>Queries the current visibility for peer <paramref name="peer" />.</para>
    /// </summary>
    bool GetVisibilityFor(int peer);
    /// <summary>
    /// <para>Node path that replicated properties are relative to.</para>
    /// <para>If <see cref="MultiplayerSynchronizer.RootPath" /> was spawned by a <see cref="MultiplayerSpawner" />, the node will be also be spawned and despawned based on this synchronizer visibility options.</para>
    /// </summary>
    NodePath RootPath { get; set; }
    /// <summary>
    /// <para>Time interval between synchronizations. When set to <c>0.0</c> (the default), synchronizations happen every network process frame.</para>
    /// </summary>
    double ReplicationInterval { get; set; }
    /// <summary>
    /// <para>Time interval between delta synchronizations. When set to <c>0.0</c> (the default), delta synchronizations happen every network process frame.</para>
    /// </summary>
    double DeltaInterval { get; set; }
    /// <summary>
    /// <para>Resource containing which properties to synchronize.</para>
    /// </summary>
    SceneReplicationConfig ReplicationConfig { get; set; }
    /// <summary>
    /// <para>Specifies when visibility filters are updated (see <see cref="MultiplayerSynchronizer.VisibilityUpdateModeEnum" /> for options).</para>
    /// </summary>
    MultiplayerSynchronizer.VisibilityUpdateModeEnum VisibilityUpdateMode { get; set; }
    /// <summary>
    /// <para>Whether synchronization should be visible to all peers by default. See <see cref="M:Godot.MultiplayerSynchronizer.SetVisibilityFor(System.Int32,System.Boolean)" /> and <see cref="M:Godot.MultiplayerSynchronizer.AddVisibilityFilter(Godot.Callable)" /> for ways of configuring fine-grained visibility options.</para>
    /// </summary>
    bool PublicVisibility { get; set; }

}