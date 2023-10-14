namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>2D Obstacle used in navigation to constrain avoidance controlled agents outside or inside an area. The obstacle needs a navigation map and outline vertices defined to work correctly.</para>
/// <para>If the obstacle's vertices are winded in clockwise order, avoidance agents will be pushed in by the obstacle, otherwise, avoidance agents will be pushed out. Outlines must not cross or overlap.</para>
/// <para>Obstacles are <b>not</b> a replacement for a (re)baked navigation mesh. Obstacles <b>don't</b> change the resulting path from the pathfinding, obstacles only affect the navigation avoidance agent movement by altering the suggested velocity of the avoidance agent.</para>
/// <para>Obstacles using vertices can warp to a new position but should not moved every frame as each move requires a rebuild of the avoidance map.</para>
/// </summary>
public class NavigationObstacle2DAdapter : NavigationObstacle2D, INavigationObstacle2D {
  private readonly NavigationObstacle2D _node;

  public NavigationObstacle2DAdapter(NavigationObstacle2D node) => _node = node;
    /// <summary>
    /// <para>If <c>true</c> the obstacle affects avoidance using agents.</para>
    /// </summary>
    public bool AvoidanceEnabled { get => _node.AvoidanceEnabled; set => _node.AvoidanceEnabled = value; }
    /// <summary>
    /// <para>A bitfield determining the avoidance layers for this obstacle. Agents with a matching bit on the their avoidance mask will avoid this obstacle.</para>
    /// </summary>
    public uint AvoidanceLayers { get => _node.AvoidanceLayers; set => _node.AvoidanceLayers = value; }
    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="NavigationObstacle2D.AvoidanceLayers" /> bitmask is enabled, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    public bool GetAvoidanceLayerValue(int layerNumber) => _node.GetAvoidanceLayerValue(layerNumber);
    /// <summary>
    /// <para>Returns the <see cref="Rid" /> of the navigation map for this NavigationObstacle node. This function returns always the map set on the NavigationObstacle node and not the map of the abstract obstacle on the NavigationServer. If the obstacle map is changed directly with the NavigationServer API the NavigationObstacle node will not be aware of the map change. Use <see cref="NavigationObstacle2D.SetNavigationMap(Godot.Rid)" /> to change the navigation map for the NavigationObstacle and also update the obstacle on the NavigationServer.</para>
    /// </summary>
    public Rid GetNavigationMap() => _node.GetNavigationMap();
    /// <summary>
    /// <para>Returns the <see cref="Rid" /> of this obstacle on the <see cref="NavigationServer2D" />.</para>
    /// </summary>
    public Rid GetRid() => _node.GetRid();
    /// <summary>
    /// <para>Sets the avoidance radius for the obstacle.</para>
    /// </summary>
    public float Radius { get => _node.Radius; set => _node.Radius = value; }
    /// <summary>
    /// <para>Based on <paramref name="value" />, enables or disables the specified layer in the <see cref="NavigationObstacle2D.AvoidanceLayers" /> bitmask, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    public void SetAvoidanceLayerValue(int layerNumber, bool value) => _node.SetAvoidanceLayerValue(layerNumber, value);
    /// <summary>
    /// <para>Sets the <see cref="Rid" /> of the navigation map this NavigationObstacle node should use and also updates the <c>obstacle</c> on the NavigationServer.</para>
    /// </summary>
    public void SetNavigationMap(Rid navigationMap) => _node.SetNavigationMap(navigationMap);
    /// <summary>
    /// <para>Sets the wanted velocity for the obstacle so other agent's can better predict the obstacle if it is moved with a velocity regularly (every frame) instead of warped to a new position. Does only affect avoidance for the obstacles <see cref="NavigationObstacle2D.Radius" />. Does nothing for the obstacles static vertices.</para>
    /// </summary>
    public Vector2 Velocity { get => _node.Velocity; set => _node.Velocity = value; }
    /// <summary>
    /// <para>The outline vertices of the obstacle. If the vertices are winded in clockwise order agents will be pushed in by the obstacle, else they will be pushed out. Outlines can not be crossed or overlap. Should the vertices using obstacle be warped to a new position agent's can not predict this movement and may get trapped inside the obstacle.</para>
    /// </summary>
    public Vector2[] Vertices { get => _node.Vertices; set => _node.Vertices = value; }

}