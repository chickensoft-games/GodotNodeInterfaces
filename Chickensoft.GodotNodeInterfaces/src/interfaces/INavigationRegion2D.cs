namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class NavigationRegion2DNode : NavigationRegion2D, INavigationRegion2D { }

/// <summary>
/// <para>A traversable 2D region based on a <see cref="NavigationPolygon" /> that <see cref="NavigationAgent2D" />s can use for pathfinding.</para>
/// <para>Two regions can be connected to each other if they share a similar edge. You can set the minimum distance between two vertices required to connect two edges by using <see cref="NavigationServer2D.MapSetEdgeConnectionMargin(Godot.Rid,System.Single)" />.</para>
/// <para><b>Note:</b> Overlapping two regions' navigation polygons is not enough for connecting two regions. They must share a similar edge.</para>
/// <para>The pathfinding cost of entering a region from another region can be controlled with the <see cref="NavigationRegion2D.EnterCost" /> value.</para>
/// <para><b>Note:</b> This value is not added to the path cost when the start position is already inside this region.</para>
/// <para>The pathfinding cost of traveling distances inside this region can be controlled with the <see cref="NavigationRegion2D.TravelCost" /> multiplier.</para>
/// <para><b>Note:</b> This node caches changes to its properties, so if you make changes to the underlying region <see cref="Rid" /> in <see cref="NavigationServer2D" />, they will not be reflected in this node's properties.</para>
/// </summary>
public interface INavigationRegion2D : INode2D {
    /// <summary>
    /// <para>A bitfield determining all avoidance layers for the avoidance constrain.</para>
    /// </summary>
    uint AvoidanceLayers { get; set; }
    /// <summary>
    /// <para>Bakes the <see cref="NavigationPolygon" />. If <paramref name="onThread" /> is set to <c>true</c> (default), the baking is done on a separate thread.</para>
    /// </summary>
    void BakeNavigationPolygon(bool onThread);
    /// <summary>
    /// <para>If <c>true</c> constraints avoidance agent's with an avoidance mask bit that matches with a bit of the <see cref="NavigationRegion2D.AvoidanceLayers" /> to the navigation polygon. Due to each navigation polygon outline creating an obstacle and each polygon edge creating an avoidance line constrain keep the navigation polygon shape as simple as possible for performance.</para>
    /// <para><b>Experimental:</b> This is an experimental feature and should not be used in production as agent's can get stuck on the navigation polygon corners and edges especially at high frame rate.</para>
    /// </summary>
    bool ConstrainAvoidance { get; set; }
    /// <summary>
    /// <para>Determines if the <see cref="NavigationRegion2D" /> is enabled or disabled.</para>
    /// </summary>
    bool Enabled { get; set; }
    /// <summary>
    /// <para>When pathfinding enters this region's navigation mesh from another regions navigation mesh the <see cref="NavigationRegion2D.EnterCost" /> value is added to the path distance for determining the shortest path.</para>
    /// </summary>
    float EnterCost { get; set; }
    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="NavigationRegion2D.AvoidanceLayers" /> bitmask is enabled, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    bool GetAvoidanceLayerValue(int layerNumber);
    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="NavigationRegion2D.NavigationLayers" /> bitmask is enabled, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    bool GetNavigationLayerValue(int layerNumber);
    /// <summary>
    /// <para>Returns the current navigation map <see cref="Rid" /> used by this region.</para>
    /// </summary>
    Rid GetNavigationMap();
    /// <summary>
    /// <para>Returns the <see cref="Rid" /> of this region on the <see cref="NavigationServer2D" />. Combined with <see cref="NavigationServer2D.MapGetClosestPointOwner(Godot.Rid,Godot.Vector2)" /> can be used to identify the <see cref="NavigationRegion2D" /> closest to a point on the merged navigation map.</para>
    /// </summary>
    Rid GetRegionRid();
    /// <summary>
    /// <para>A bitfield determining all navigation layers the region belongs to. These navigation layers can be checked upon when requesting a path with <see cref="NavigationServer2D.MapGetPath(Godot.Rid,Godot.Vector2,Godot.Vector2,System.Boolean,System.UInt32)" />.</para>
    /// </summary>
    uint NavigationLayers { get; set; }
    /// <summary>
    /// <para>The <see cref="NavigationPolygon" /> resource to use.</para>
    /// </summary>
    NavigationPolygon NavigationPolygon { get; set; }
    /// <summary>
    /// <para>Based on <paramref name="value" />, enables or disables the specified layer in the <see cref="NavigationRegion2D.AvoidanceLayers" /> bitmask, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    void SetAvoidanceLayerValue(int layerNumber, bool value);
    /// <summary>
    /// <para>Based on <paramref name="value" />, enables or disables the specified layer in the <see cref="NavigationRegion2D.NavigationLayers" /> bitmask, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    void SetNavigationLayerValue(int layerNumber, bool value);
    /// <summary>
    /// <para>Sets the <see cref="Rid" /> of the navigation map this region should use. By default the region will automatically join the <see cref="World2D" /> default navigation map so this function is only required to override the default map.</para>
    /// </summary>
    void SetNavigationMap(Rid navigationMap);
    /// <summary>
    /// <para>When pathfinding moves inside this region's navigation mesh the traveled distances are multiplied with <see cref="NavigationRegion2D.TravelCost" /> for determining the shortest path.</para>
    /// </summary>
    float TravelCost { get; set; }
    /// <summary>
    /// <para>If enabled the navigation region will use edge connections to connect with other navigation regions within proximity of the navigation map edge connection margin.</para>
    /// </summary>
    bool UseEdgeConnections { get; set; }

}