namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A traversable 2D region based on a <see cref="NavigationPolygon" /> that <see cref="NavigationAgent2D" />s can use for pathfinding.</para>
/// <para>Two regions can be connected to each other if they share a similar edge. You can set the minimum distance between two vertices required to connect two edges by using <see cref="NavigationServer2D.MapSetEdgeConnectionMargin(Godot.Rid,System.Single)" />.</para>
/// <para><b>Note:</b> Overlapping two regions' navigation polygons is not enough for connecting two regions. They must share a similar edge.</para>
/// <para>The pathfinding cost of entering a region from another region can be controlled with the <see cref="NavigationRegion2D.EnterCost" /> value.</para>
/// <para><b>Note:</b> This value is not added to the path cost when the start position is already inside this region.</para>
/// <para>The pathfinding cost of traveling distances inside this region can be controlled with the <see cref="NavigationRegion2D.TravelCost" /> multiplier.</para>
/// <para><b>Note:</b> This node caches changes to its properties, so if you make changes to the underlying region <see cref="Rid" /> in <see cref="NavigationServer2D" />, they will not be reflected in this node's properties.</para>
/// </summary>
public class NavigationRegion2DAdapter : Node2DAdapter, INavigationRegion2D {
  private readonly NavigationRegion2D _node;

  public NavigationRegion2DAdapter(NavigationRegion2D node) : base(node) { _node = node; }

    /// <summary>
    /// <para>A bitfield determining all avoidance layers for the avoidance constrain.</para>
    /// </summary>
    public uint AvoidanceLayers { get => _node.AvoidanceLayers; set => _node.AvoidanceLayers = value; }
    /// <summary>
    /// <para>Bakes the <see cref="NavigationPolygon" />. If <paramref name="onThread" /> is set to <c>true</c> (default), the baking is done on a separate thread.</para>
    /// </summary>
    public void BakeNavigationPolygon(bool onThread) => _node.BakeNavigationPolygon(onThread);
    /// <summary>
    /// <para>If <c>true</c> constraints avoidance agent's with an avoidance mask bit that matches with a bit of the <see cref="NavigationRegion2D.AvoidanceLayers" /> to the navigation polygon. Due to each navigation polygon outline creating an obstacle and each polygon edge creating an avoidance line constrain keep the navigation polygon shape as simple as possible for performance.</para>
    /// <para><b>Experimental:</b> This is an experimental feature and should not be used in production as agent's can get stuck on the navigation polygon corners and edges especially at high frame rate.</para>
    /// </summary>
    public bool ConstrainAvoidance { get => _node.ConstrainAvoidance; set => _node.ConstrainAvoidance = value; }
    /// <summary>
    /// <para>Determines if the <see cref="NavigationRegion2D" /> is enabled or disabled.</para>
    /// </summary>
    public bool Enabled { get => _node.Enabled; set => _node.Enabled = value; }
    /// <summary>
    /// <para>When pathfinding enters this region's navigation mesh from another regions navigation mesh the <see cref="NavigationRegion2D.EnterCost" /> value is added to the path distance for determining the shortest path.</para>
    /// </summary>
    public float EnterCost { get => _node.EnterCost; set => _node.EnterCost = value; }
    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="NavigationRegion2D.AvoidanceLayers" /> bitmask is enabled, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    public bool GetAvoidanceLayerValue(int layerNumber) => _node.GetAvoidanceLayerValue(layerNumber);
    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="NavigationRegion2D.NavigationLayers" /> bitmask is enabled, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    public bool GetNavigationLayerValue(int layerNumber) => _node.GetNavigationLayerValue(layerNumber);
    /// <summary>
    /// <para>Returns the current navigation map <see cref="Rid" /> used by this region.</para>
    /// </summary>
    public Rid GetNavigationMap() => _node.GetNavigationMap();
    /// <summary>
    /// <para>Returns the <see cref="Rid" /> of this region on the <see cref="NavigationServer2D" />. Combined with <see cref="NavigationServer2D.MapGetClosestPointOwner(Godot.Rid,Godot.Vector2)" /> can be used to identify the <see cref="NavigationRegion2D" /> closest to a point on the merged navigation map.</para>
    /// </summary>
    public Rid GetRegionRid() => _node.GetRegionRid();
    /// <summary>
    /// <para>A bitfield determining all navigation layers the region belongs to. These navigation layers can be checked upon when requesting a path with <see cref="NavigationServer2D.MapGetPath(Godot.Rid,Godot.Vector2,Godot.Vector2,System.Boolean,System.UInt32)" />.</para>
    /// </summary>
    public uint NavigationLayers { get => _node.NavigationLayers; set => _node.NavigationLayers = value; }
    /// <summary>
    /// <para>The <see cref="NavigationPolygon" /> resource to use.</para>
    /// </summary>
    public NavigationPolygon NavigationPolygon { get => _node.NavigationPolygon; set => _node.NavigationPolygon = value; }
    /// <summary>
    /// <para>Based on <paramref name="value" />, enables or disables the specified layer in the <see cref="NavigationRegion2D.AvoidanceLayers" /> bitmask, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    public void SetAvoidanceLayerValue(int layerNumber, bool value) => _node.SetAvoidanceLayerValue(layerNumber, value);
    /// <summary>
    /// <para>Based on <paramref name="value" />, enables or disables the specified layer in the <see cref="NavigationRegion2D.NavigationLayers" /> bitmask, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    public void SetNavigationLayerValue(int layerNumber, bool value) => _node.SetNavigationLayerValue(layerNumber, value);
    /// <summary>
    /// <para>Sets the <see cref="Rid" /> of the navigation map this region should use. By default the region will automatically join the <see cref="World2D" /> default navigation map so this function is only required to override the default map.</para>
    /// </summary>
    public void SetNavigationMap(Rid navigationMap) => _node.SetNavigationMap(navigationMap);
    /// <summary>
    /// <para>When pathfinding moves inside this region's navigation mesh the traveled distances are multiplied with <see cref="NavigationRegion2D.TravelCost" /> for determining the shortest path.</para>
    /// </summary>
    public float TravelCost { get => _node.TravelCost; set => _node.TravelCost = value; }
    /// <summary>
    /// <para>If enabled the navigation region will use edge connections to connect with other navigation regions within proximity of the navigation map edge connection margin.</para>
    /// </summary>
    public bool UseEdgeConnections { get => _node.UseEdgeConnections; set => _node.UseEdgeConnections = value; }

}