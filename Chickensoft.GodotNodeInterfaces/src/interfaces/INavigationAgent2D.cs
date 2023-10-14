namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>A 2D agent used to pathfind to a position while avoiding static and dynamic obstacles. The calculation can be used by the parent node to dynamically move it along the path. Requires navigation data to work correctly.</para>
/// <para>Dynamic obstacles are avoided using RVO collision avoidance. Avoidance is computed before physics, so the pathfinding information can be used safely in the physics step.</para>
/// <para><b>Note:</b> After setting the <see cref="NavigationAgent2D.TargetPosition" /> property, the <see cref="NavigationAgent2D.GetNextPathPosition" /> method must be used once every physics frame to update the internal path logic of the navigation agent. The vector position it returns should be used as the next movement position for the agent's parent node.</para>
/// </summary>
public interface INavigationAgent2D {
    /// <summary>
    /// <para>Returns the <see cref="Rid" /> of this agent on the <see cref="NavigationServer2D" />.</para>
    /// </summary>
    Rid GetRid();
    /// <summary>
    /// <para>Based on <paramref name="value" />, enables or disables the specified layer in the <see cref="NavigationAgent2D.NavigationLayers" /> bitmask, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    void SetNavigationLayerValue(int layerNumber, bool value);
    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="NavigationAgent2D.NavigationLayers" /> bitmask is enabled, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    bool GetNavigationLayerValue(int layerNumber);
    /// <summary>
    /// <para>Sets the <see cref="Rid" /> of the navigation map this NavigationAgent node should use and also updates the <c>agent</c> on the NavigationServer.</para>
    /// </summary>
    void SetNavigationMap(Rid navigationMap);
    /// <summary>
    /// <para>Returns the <see cref="Rid" /> of the navigation map for this NavigationAgent node. This function returns always the map set on the NavigationAgent node and not the map of the abstract agent on the NavigationServer. If the agent map is changed directly with the NavigationServer API the NavigationAgent node will not be aware of the map change. Use <see cref="M:Godot.NavigationAgent2D.SetNavigationMap(Godot.Rid)" /> to change the navigation map for the NavigationAgent and also update the agent on the NavigationServer.</para>
    /// </summary>
    Rid GetNavigationMap();
    /// <summary>
    /// <para>Returns the next position in global coordinates that can be moved to, making sure that there are no static objects in the way. If the agent does not have a navigation path, it will return the position of the agent's parent. The use of this function once every physics frame is required to update the internal path logic of the NavigationAgent.</para>
    /// </summary>
    Vector2 GetNextPathPosition();
    /// <summary>
    /// <para>Replaces the internal velocity in the collision avoidance simulation with <paramref name="velocity" />. When an agent is teleported to a new position this function should be used in the same frame. If called frequently this function can get agents stuck.</para>
    /// </summary>
    void SetVelocityForced(Vector2 velocity);
    /// <summary>
    /// <para>Returns the distance to the target position, using the agent's global position. The user must set <see cref="NavigationAgent2D.TargetPosition" /> in order for this to be accurate.</para>
    /// </summary>
    float DistanceToTarget();
    /// <summary>
    /// <para>Returns the path query result for the path the agent is currently following.</para>
    /// </summary>
    NavigationPathQueryResult2D GetCurrentNavigationResult();
    /// <summary>
    /// <para>Returns this agent's current path from start to finish in global coordinates. The path only updates when the target position is changed or the agent requires a repath. The path array is not intended to be used in direct path movement as the agent has its own internal path logic that would get corrupted by changing the path array manually. Use the intended <see cref="NavigationAgent2D.GetNextPathPosition" /> once every physics frame to receive the next path point for the agents movement as this function also updates the internal path logic.</para>
    /// </summary>
    Vector2[] GetCurrentNavigationPath();
    /// <summary>
    /// <para>Returns which index the agent is currently on in the navigation path's <see cref="Vector2" />[].</para>
    /// </summary>
    int GetCurrentNavigationPathIndex();
    /// <summary>
    /// <para>Returns true if <see cref="NavigationAgent2D.TargetPosition" /> is reached. It may not always be possible to reach the target position. It should always be possible to reach the final position though. See <see cref="NavigationAgent2D.GetFinalPosition" />.</para>
    /// </summary>
    bool IsTargetReached();
    /// <summary>
    /// <para>Returns <c>true</c> if <see cref="NavigationAgent2D.GetFinalPosition" /> is within <see cref="NavigationAgent2D.TargetDesiredDistance" /> of the <see cref="NavigationAgent2D.TargetPosition" />.</para>
    /// </summary>
    bool IsTargetReachable();
    /// <summary>
    /// <para>Returns <c>true</c> if the end of the currently loaded navigation path has been reached.</para>
    /// <para><b>Note:</b> While true prefer to stop calling update functions like <see cref="NavigationAgent2D.GetNextPathPosition" />. This avoids jittering the standing agent due to calling repeated path updates.</para>
    /// </summary>
    bool IsNavigationFinished();
    /// <summary>
    /// <para>Returns the reachable final position of the current navigation path in global coordinates. This position can change if the agent needs to update the navigation path which makes the agent emit the <see cref="NavigationAgent2D.PathChanged" /> signal.</para>
    /// </summary>
    Vector2 GetFinalPosition();
    /// <summary>
    /// <para>Based on <paramref name="value" />, enables or disables the specified layer in the <see cref="NavigationAgent2D.AvoidanceLayers" /> bitmask, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    void SetAvoidanceLayerValue(int layerNumber, bool value);
    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="NavigationAgent2D.AvoidanceLayers" /> bitmask is enabled, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    bool GetAvoidanceLayerValue(int layerNumber);
    /// <summary>
    /// <para>Based on <paramref name="value" />, enables or disables the specified mask in the <see cref="NavigationAgent2D.AvoidanceMask" /> bitmask, given a <paramref name="maskNumber" /> between 1 and 32.</para>
    /// </summary>
    void SetAvoidanceMaskValue(int maskNumber, bool value);
    /// <summary>
    /// <para>Returns whether or not the specified mask of the <see cref="NavigationAgent2D.AvoidanceMask" /> bitmask is enabled, given a <paramref name="maskNumber" /> between 1 and 32.</para>
    /// </summary>
    bool GetAvoidanceMaskValue(int maskNumber);
    /// <summary>
    /// <para>If set, a new navigation path from the current agent position to the <see cref="NavigationAgent2D.TargetPosition" /> is requested from the NavigationServer.</para>
    /// </summary>
    Vector2 TargetPosition { get; set; }
    /// <summary>
    /// <para>The distance threshold before a path point is considered to be reached. This allows agents to not have to hit a path point on the path exactly, but only to reach its general area. If this value is set too high, the NavigationAgent will skip points on the path, which can lead to leaving the navigation mesh. If this value is set too low, the NavigationAgent will be stuck in a repath loop because it will constantly overshoot or undershoot the distance to the next point on each physics frame update.</para>
    /// </summary>
    float PathDesiredDistance { get; set; }
    /// <summary>
    /// <para>The distance threshold before the final target point is considered to be reached. This allows agents to not have to hit the point of the final target exactly, but only to reach its general area. If this value is set too low, the NavigationAgent will be stuck in a repath loop because it will constantly overshoot or undershoot the distance to the final target point on each physics frame update.</para>
    /// </summary>
    float TargetDesiredDistance { get; set; }
    /// <summary>
    /// <para>The maximum distance the agent is allowed away from the ideal path to the final position. This can happen due to trying to avoid collisions. When the maximum distance is exceeded, it recalculates the ideal path.</para>
    /// </summary>
    float PathMaxDistance { get; set; }
    /// <summary>
    /// <para>A bitfield determining which navigation layers of navigation regions this agent will use to calculate a path. Changing it during runtime will clear the current navigation path and generate a new one, according to the new navigation layers.</para>
    /// </summary>
    uint NavigationLayers { get; set; }
    /// <summary>
    /// <para>The pathfinding algorithm used in the path query.</para>
    /// </summary>
    NavigationPathQueryParameters2D.PathfindingAlgorithmEnum PathfindingAlgorithm { get; set; }
    /// <summary>
    /// <para>The path postprocessing applied to the raw path corridor found by the <see cref="NavigationAgent2D.PathfindingAlgorithm" />.</para>
    /// </summary>
    NavigationPathQueryParameters2D.PathPostProcessing PathPostprocessing { get; set; }
    /// <summary>
    /// <para>Additional information to return with the navigation path.</para>
    /// </summary>
    NavigationPathQueryParameters2D.PathMetadataFlags PathMetadataFlags { get; set; }
    /// <summary>
    /// <para>If <c>true</c> the agent is registered for an RVO avoidance callback on the <see cref="NavigationServer2D" />. When <see cref="NavigationAgent2D.Velocity" /> is used and the processing is completed a <c>safe_velocity</c> Vector2 is received with a signal connection to <see cref="NavigationAgent2D.VelocityComputed" />. Avoidance processing with many registered agents has a significant performance cost and should only be enabled on agents that currently require it.</para>
    /// </summary>
    bool AvoidanceEnabled { get; set; }
    /// <summary>
    /// <para>Sets the new wanted velocity for the agent. The avoidance simulation will try to fulfill this velocity if possible but will modify it to avoid collision with other agents and obstacles. When an agent is teleported to a new position, use <see cref="M:Godot.NavigationAgent2D.SetVelocityForced(Godot.Vector2)" /> as well to reset the internal simulation velocity.</para>
    /// </summary>
    Vector2 Velocity { get; set; }
    /// <summary>
    /// <para>The radius of the avoidance agent. This is the "body" of the avoidance agent and not the avoidance maneuver starting radius (which is controlled by <see cref="NavigationAgent2D.NeighborDistance" />).</para>
    /// <para>Does not affect normal pathfinding. To change an actor's pathfinding radius bake <see cref="NavigationMesh" /> resources with a different <see cref="NavigationMesh.AgentRadius" /> property and use different navigation maps for each actor size.</para>
    /// </summary>
    float Radius { get; set; }
    /// <summary>
    /// <para>The distance to search for other agents.</para>
    /// </summary>
    float NeighborDistance { get; set; }
    /// <summary>
    /// <para>The maximum number of neighbors for the agent to consider.</para>
    /// </summary>
    int MaxNeighbors { get; set; }
    /// <summary>
    /// <para>The minimal amount of time for which this agent's velocities, that are computed with the collision avoidance algorithm, are safe with respect to other agents. The larger the number, the sooner the agent will respond to other agents, but less freedom in choosing its velocities. A too high value will slow down agents movement considerably. Must be positive.</para>
    /// </summary>
    float TimeHorizonAgents { get; set; }
    /// <summary>
    /// <para>The minimal amount of time for which this agent's velocities, that are computed with the collision avoidance algorithm, are safe with respect to static avoidance obstacles. The larger the number, the sooner the agent will respond to static avoidance obstacles, but less freedom in choosing its velocities. A too high value will slow down agents movement considerably. Must be positive.</para>
    /// </summary>
    float TimeHorizonObstacles { get; set; }
    /// <summary>
    /// <para>The maximum speed that an agent can move.</para>
    /// </summary>
    float MaxSpeed { get; set; }
    /// <summary>
    /// <para>A bitfield determining the avoidance layers for this NavigationAgent. Other agents with a matching bit on the <see cref="NavigationAgent2D.AvoidanceMask" /> will avoid this agent.</para>
    /// </summary>
    uint AvoidanceLayers { get; set; }
    /// <summary>
    /// <para>A bitfield determining what other avoidance agents and obstacles this NavigationAgent will avoid when a bit matches at least one of their <see cref="NavigationAgent2D.AvoidanceLayers" />.</para>
    /// </summary>
    uint AvoidanceMask { get; set; }
    /// <summary>
    /// <para>The agent does not adjust the velocity for other agents that would match the <see cref="NavigationAgent2D.AvoidanceMask" /> but have a lower <see cref="NavigationAgent2D.AvoidancePriority" />. This in turn makes the other agents with lower priority adjust their velocities even more to avoid collision with this agent.</para>
    /// </summary>
    float AvoidancePriority { get; set; }
    /// <summary>
    /// <para>If <c>true</c> shows debug visuals for this agent.</para>
    /// </summary>
    bool DebugEnabled { get; set; }
    /// <summary>
    /// <para>If <c>true</c> uses the defined <see cref="NavigationAgent2D.DebugPathCustomColor" /> for this agent instead of global color.</para>
    /// </summary>
    bool DebugUseCustom { get; set; }
    /// <summary>
    /// <para>If <see cref="NavigationAgent2D.DebugUseCustom" /> is <c>true</c> uses this color for this agent instead of global color.</para>
    /// </summary>
    Color DebugPathCustomColor { get; set; }
    /// <summary>
    /// <para>If <see cref="NavigationAgent2D.DebugUseCustom" /> is <c>true</c> uses this rasterized point size for rendering path points for this agent instead of global point size.</para>
    /// </summary>
    float DebugPathCustomPointSize { get; set; }
    /// <summary>
    /// <para>If <see cref="NavigationAgent2D.DebugUseCustom" /> is <c>true</c> uses this line width for rendering paths for this agent instead of global line width.</para>
    /// </summary>
    float DebugPathCustomLineWidth { get; set; }

}