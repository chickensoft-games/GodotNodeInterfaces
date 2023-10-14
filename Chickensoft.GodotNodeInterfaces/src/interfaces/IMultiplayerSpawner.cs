namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>Spawnable scenes can be configured in the editor or through code (see <see cref="M:Godot.MultiplayerSpawner.AddSpawnableScene(System.String)" />).</para>
/// <para>Also supports custom node spawns through <see cref="M:Godot.MultiplayerSpawner.Spawn(Godot.Variant)" />, calling <see cref="MultiplayerSpawner.SpawnFunction" /> on all peers.</para>
/// <para>Internally, <see cref="MultiplayerSpawner" /> uses <see cref="M:Godot.MultiplayerApi.ObjectConfigurationAdd(Godot.GodotObject,Godot.Variant)" /> to notify spawns passing the spawned node as the <c>object</c> and itself as the <c>configuration</c>, and <see cref="M:Godot.MultiplayerApi.ObjectConfigurationRemove(Godot.GodotObject,Godot.Variant)" /> to notify despawns in a similar way.</para>
/// </summary>
public interface IMultiplayerSpawner {
    /// <summary>
    /// <para>Adds a scene path to spawnable scenes, making it automatically replicated from the multiplayer authority to other peers when added as children of the node pointed by <see cref="MultiplayerSpawner.SpawnPath" />.</para>
    /// </summary>
    void AddSpawnableScene(string path);
    /// <summary>
    /// <para>Returns the count of spawnable scene paths.</para>
    /// </summary>
    int GetSpawnableSceneCount();
    /// <summary>
    /// <para>Returns the spawnable scene path by index.</para>
    /// </summary>
    string GetSpawnableScene(int index);
    /// <summary>
    /// <para>Clears all spawnable scenes. Does not despawn existing instances on remote peers.</para>
    /// </summary>
    void ClearSpawnableScenes();
    /// <summary>
    /// <para>Requests a custom spawn, with <paramref name="data" /> passed to <see cref="MultiplayerSpawner.SpawnFunction" /> on all peers. Returns the locally spawned node instance already inside the scene tree, and added as a child of the node pointed by <see cref="MultiplayerSpawner.SpawnPath" />.</para>
    /// <para><b>Note:</b> Spawnable scenes are spawned automatically. <see cref="M:Godot.MultiplayerSpawner.Spawn(Godot.Variant)" /> is only needed for custom spawns.</para>
    /// </summary>
    Node Spawn(Variant data);

    string[] _SpawnableScenes { get; set; }
    /// <summary>
    /// <para>Path to the spawn root. Spawnable scenes that are added as direct children are replicated to other peers.</para>
    /// </summary>
    NodePath SpawnPath { get; set; }
    /// <summary>
    /// <para>Maximum nodes that is allowed to be spawned by this spawner. Includes both spawnable scenes and custom spawns.</para>
    /// <para>When set to <c>0</c> (the default), there is no limit.</para>
    /// </summary>
    uint SpawnLimit { get; set; }
    /// <summary>
    /// <para>Method called on all peers when for every custom <see cref="M:Godot.MultiplayerSpawner.Spawn(Godot.Variant)" /> requested by the authority. Will receive the <c>data</c> parameter, and should return a <see cref="Node" /> that is not in the scene tree.</para>
    /// <para><b>Note:</b> The returned node should <b>not</b> be added to the scene with <see cref="M:Godot.Node.AddChild(Godot.Node,System.Boolean,Godot.Node.InternalMode)" />. This is done automatically.</para>
    /// </summary>
    Callable SpawnFunction { get; set; }

}