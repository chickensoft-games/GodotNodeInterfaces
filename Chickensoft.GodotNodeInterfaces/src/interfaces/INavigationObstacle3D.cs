namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>3D Obstacle used in navigation to constrain avoidance controlled agents outside or inside an area. The obstacle needs a navigation map and outline vertices defined to work correctly.</para>
/// <para>If the obstacle's vertices are winded in clockwise order, avoidance agents will be pushed in by the obstacle, otherwise, avoidance agents will be pushed out. Outlines must not cross or overlap.</para>
/// <para>Obstacles are <b>not</b> a replacement for a (re)baked navigation mesh. Obstacles <b>don't</b> change the resulting path from the pathfinding, obstacles only affect the navigation avoidance agent movement by altering the suggested velocity of the avoidance agent.</para>
/// <para>Obstacles using vertices can warp to a new position but should not moved every frame as each move requires a rebuild of the avoidance map.</para>
/// </summary>
public interface INavigationObstacle3D : INode3D {
    /// <summary>
    /// <para>Returns the <see cref="Rid" /> of this obstacle on the <see cref="NavigationServer3D" />.</para>
    /// </summary>
    Rid GetRid();
    /// <summary>
    /// <para>Sets the <see cref="Rid" /> of the navigation map this NavigationObstacle node should use and also updates the <c>obstacle</c> on the NavigationServer.</para>
    /// </summary>
    void SetNavigationMap(Rid navigationMap);
    /// <summary>
    /// <para>Returns the <see cref="Rid" /> of the navigation map for this NavigationObstacle node. This function returns always the map set on the NavigationObstacle node and not the map of the abstract obstacle on the NavigationServer. If the obstacle map is changed directly with the NavigationServer API the NavigationObstacle node will not be aware of the map change. Use <see cref="M:Godot.NavigationObstacle3D.SetNavigationMap(Godot.Rid)" /> to change the navigation map for the NavigationObstacle and also update the obstacle on the NavigationServer.</para>
    /// </summary>
    Rid GetNavigationMap();
    /// <summary>
    /// <para>Based on <paramref name="value" />, enables or disables the specified layer in the <see cref="NavigationObstacle3D.AvoidanceLayers" /> bitmask, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    void SetAvoidanceLayerValue(int layerNumber, bool value);
    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="NavigationObstacle3D.AvoidanceLayers" /> bitmask is enabled, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    bool GetAvoidanceLayerValue(int layerNumber);
    /// <summary>
    /// <para>If <c>true</c> the obstacle affects avoidance using agents.</para>
    /// </summary>
    bool AvoidanceEnabled { get; set; }
    /// <summary>
    /// <para>Sets the wanted velocity for the obstacle so other agent's can better predict the obstacle if it is moved with a velocity regularly (every frame) instead of warped to a new position. Does only affect avoidance for the obstacles <see cref="NavigationObstacle3D.Radius" />. Does nothing for the obstacles static vertices.</para>
    /// </summary>
    Vector3 Velocity { get; set; }
    /// <summary>
    /// <para>Sets the avoidance radius for the obstacle.</para>
    /// </summary>
    float Radius { get; set; }
    /// <summary>
    /// <para>Sets the obstacle height used in 2D avoidance. 2D avoidance using agent's ignore obstacles that are below or above them.</para>
    /// </summary>
    float Height { get; set; }
    /// <summary>
    /// <para>The outline vertices of the obstacle. If the vertices are winded in clockwise order agents will be pushed in by the obstacle, else they will be pushed out. Outlines can not be crossed or overlap. Should the vertices using obstacle be warped to a new position agent's can not predict this movement and may get trapped inside the obstacle.</para>
    /// </summary>
    Vector3[] Vertices { get; set; }
    /// <summary>
    /// <para>A bitfield determining the avoidance layers for this obstacle. Agents with a matching bit on the their avoidance mask will avoid this obstacle.</para>
    /// </summary>
    uint AvoidanceLayers { get; set; }
    /// <summary>
    /// <para>If <c>true</c> the obstacle affects 3D avoidance using agent's with obstacle <see cref="NavigationObstacle3D.Radius" />.</para>
    /// <para>If <c>false</c> the obstacle affects 2D avoidance using agent's with both obstacle <see cref="NavigationObstacle3D.Vertices" /> as well as obstacle <see cref="NavigationObstacle3D.Radius" />.</para>
    /// </summary>
    bool Use3DAvoidance { get; set; }

}