namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A traversable 3D region based on a <see cref="NavigationMesh" /> that <see cref="NavigationAgent3D" />s can use for pathfinding.</para>
/// <para>Two regions can be connected to each other if they share a similar edge. You can set the minimum distance between two vertices required to connect two edges by using <see cref="NavigationServer3D.MapSetEdgeConnectionMargin(Godot.Rid,System.Single)" />.</para>
/// <para><b>Note:</b> Overlapping two regions' navigation meshes is not enough for connecting two regions. They must share a similar edge.</para>
/// <para>The cost of entering this region from another region can be controlled with the <see cref="NavigationRegion3D.EnterCost" /> value.</para>
/// <para><b>Note:</b> This value is not added to the path cost when the start position is already inside this region.</para>
/// <para>The cost of traveling distances inside this region can be controlled with the <see cref="NavigationRegion3D.TravelCost" /> multiplier.</para>
/// <para><b>Note:</b> This node caches changes to its properties, so if you make changes to the underlying region <see cref="Rid" /> in <see cref="NavigationServer3D" />, they will not be reflected in this node's properties.</para>
/// </summary>
public class NavigationRegion3DAdapter : Node3DAdapter, INavigationRegion3D {
  private readonly NavigationRegion3D _node;

  public NavigationRegion3DAdapter(NavigationRegion3D node) : base(node) { _node = node; }

    /// <summary>
    /// <para>Bakes the <see cref="NavigationMesh" />. If <paramref name="onThread" /> is set to <c>true</c> (default), the baking is done on a separate thread. Baking on separate thread is useful because navigation baking is not a cheap operation. When it is completed, it automatically sets the new <see cref="NavigationMesh" />. Please note that baking on separate thread may be very slow if geometry is parsed from meshes as async access to each mesh involves heavy synchronization. Also, please note that baking on a separate thread is automatically disabled on operating systems that cannot use threads (such as Web with threads disabled).</para>
    /// </summary>
    public void BakeNavigationMesh(bool onThread) => _node.BakeNavigationMesh(onThread);
    /// <summary>
    /// <para>Determines if the <see cref="NavigationRegion3D" /> is enabled or disabled.</para>
    /// </summary>
    public bool Enabled { get => _node.Enabled; set => _node.Enabled = value; }
    /// <summary>
    /// <para>When pathfinding enters this region's navigation mesh from another regions navigation mesh the <see cref="NavigationRegion3D.EnterCost" /> value is added to the path distance for determining the shortest path.</para>
    /// </summary>
    public float EnterCost { get => _node.EnterCost; set => _node.EnterCost = value; }
    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="NavigationRegion3D.NavigationLayers" /> bitmask is enabled, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    public bool GetNavigationLayerValue(int layerNumber) => _node.GetNavigationLayerValue(layerNumber);
    /// <summary>
    /// <para>Returns the current navigation map <see cref="Rid" /> used by this region.</para>
    /// </summary>
    public Rid GetNavigationMap() => _node.GetNavigationMap();
    /// <summary>
    /// <para>Returns the <see cref="Rid" /> of this region on the <see cref="NavigationServer3D" />. Combined with <see cref="NavigationServer3D.MapGetClosestPointOwner(Godot.Rid,Godot.Vector3)" /> can be used to identify the <see cref="NavigationRegion3D" /> closest to a point on the merged navigation map.</para>
    /// </summary>
    public Rid GetRegionRid() => _node.GetRegionRid();
    /// <summary>
    /// <para>A bitfield determining all navigation layers the region belongs to. These navigation layers can be checked upon when requesting a path with <see cref="NavigationServer3D.MapGetPath(Godot.Rid,Godot.Vector3,Godot.Vector3,System.Boolean,System.UInt32)" />.</para>
    /// </summary>
    public uint NavigationLayers { get => _node.NavigationLayers; set => _node.NavigationLayers = value; }
    /// <summary>
    /// <para>The <see cref="NavigationMesh" /> resource to use.</para>
    /// </summary>
    public NavigationMesh NavigationMesh { get => _node.NavigationMesh; set => _node.NavigationMesh = value; }
    /// <summary>
    /// <para>Based on <paramref name="value" />, enables or disables the specified layer in the <see cref="NavigationRegion3D.NavigationLayers" /> bitmask, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    public void SetNavigationLayerValue(int layerNumber, bool value) => _node.SetNavigationLayerValue(layerNumber, value);
    /// <summary>
    /// <para>Sets the <see cref="Rid" /> of the navigation map this region should use. By default the region will automatically join the <see cref="World3D" /> default navigation map so this function is only required to override the default map.</para>
    /// </summary>
    public void SetNavigationMap(Rid navigationMap) => _node.SetNavigationMap(navigationMap);
    /// <summary>
    /// <para>When pathfinding moves inside this region's navigation mesh the traveled distances are multiplied with <see cref="NavigationRegion3D.TravelCost" /> for determining the shortest path.</para>
    /// </summary>
    public float TravelCost { get => _node.TravelCost; set => _node.TravelCost = value; }
    /// <summary>
    /// <para>If enabled the navigation region will use edge connections to connect with other navigation regions within proximity of the navigation map edge connection margin.</para>
    /// </summary>
    public bool UseEdgeConnections { get => _node.UseEdgeConnections; set => _node.UseEdgeConnections = value; }

}