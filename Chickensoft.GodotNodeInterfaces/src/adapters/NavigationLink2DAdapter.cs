 namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A link between two positions on <see cref="NavigationRegion2D" />s that agents can be routed through. These positions can be on the same <see cref="NavigationRegion2D" /> or on two different ones. Links are useful to express navigation methods other than traveling along the surface of the navigation polygon, such as ziplines, teleporters, or gaps that can be jumped across.</para>
/// </summary>
public class NavigationLink2DAdapter : NavigationLink2D, INavigationLink2D {
  private readonly NavigationLink2D _node;

  public NavigationLink2DAdapter(NavigationLink2D node) => _node = node;
    /// <summary>
    /// <para>Whether this link can be traveled in both directions or only from <see cref="NavigationLink2D.StartPosition" /> to <see cref="NavigationLink2D.EndPosition" />.</para>
    /// </summary>
    public bool Bidirectional { get => _node.Bidirectional; set => _node.Bidirectional = value; }
    /// <summary>
    /// <para>Whether this link is currently active. If <c>false</c>, <see cref="NavigationServer2D.MapGetPath(Godot.Rid,Godot.Vector2,Godot.Vector2,System.Boolean,System.UInt32)" /> will ignore this link.</para>
    /// </summary>
    public bool Enabled { get => _node.Enabled; set => _node.Enabled = value; }
    /// <summary>
    /// <para>Ending position of the link.</para>
    /// <para>This position will search out the nearest polygon in the navigation mesh to attach to.</para>
    /// <para>The distance the link will search is controlled by <see cref="NavigationServer2D.MapSetLinkConnectionRadius(Godot.Rid,System.Single)" />.</para>
    /// </summary>
    public Vector2 EndPosition { get => _node.EndPosition; set => _node.EndPosition = value; }
    /// <summary>
    /// <para>When pathfinding enters this link from another regions navigation mesh the <see cref="NavigationLink2D.EnterCost" /> value is added to the path distance for determining the shortest path.</para>
    /// </summary>
    public float EnterCost { get => _node.EnterCost; set => _node.EnterCost = value; }
    /// <summary>
    /// <para>Returns the <see cref="NavigationLink2D.EndPosition" /> that is relative to the link as a global position.</para>
    /// </summary>
    public Vector2 GetGlobalEndPosition() => _node.GetGlobalEndPosition();
    /// <summary>
    /// <para>Returns the <see cref="NavigationLink2D.StartPosition" /> that is relative to the link as a global position.</para>
    /// </summary>
    public Vector2 GetGlobalStartPosition() => _node.GetGlobalStartPosition();
    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="NavigationLink2D.NavigationLayers" /> bitmask is enabled, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    public bool GetNavigationLayerValue(int layerNumber) => _node.GetNavigationLayerValue(layerNumber);
    /// <summary>
    /// <para>A bitfield determining all navigation layers the link belongs to. These navigation layers will be checked when requesting a path with <see cref="NavigationServer2D.MapGetPath(Godot.Rid,Godot.Vector2,Godot.Vector2,System.Boolean,System.UInt32)" />.</para>
    /// </summary>
    public uint NavigationLayers { get => _node.NavigationLayers; set => _node.NavigationLayers = value; }
    /// <summary>
    /// <para>Sets the <see cref="NavigationLink2D.EndPosition" /> that is relative to the link from a global <paramref name="position" />.</para>
    /// </summary>
    public void SetGlobalEndPosition(Vector2 position) => _node.SetGlobalEndPosition(position);
    /// <summary>
    /// <para>Sets the <see cref="NavigationLink2D.StartPosition" /> that is relative to the link from a global <paramref name="position" />.</para>
    /// </summary>
    public void SetGlobalStartPosition(Vector2 position) => _node.SetGlobalStartPosition(position);
    /// <summary>
    /// <para>Based on <paramref name="value" />, enables or disables the specified layer in the <see cref="NavigationLink2D.NavigationLayers" /> bitmask, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    public void SetNavigationLayerValue(int layerNumber, bool value) => _node.SetNavigationLayerValue(layerNumber, value);
    /// <summary>
    /// <para>Starting position of the link.</para>
    /// <para>This position will search out the nearest polygon in the navigation mesh to attach to.</para>
    /// <para>The distance the link will search is controlled by <see cref="NavigationServer2D.MapSetLinkConnectionRadius(Godot.Rid,System.Single)" />.</para>
    /// </summary>
    public Vector2 StartPosition { get => _node.StartPosition; set => _node.StartPosition = value; }
    /// <summary>
    /// <para>When pathfinding moves along the link the traveled distance is multiplied with <see cref="NavigationLink2D.TravelCost" /> for determining the shortest path.</para>
    /// </summary>
    public float TravelCost { get => _node.TravelCost; set => _node.TravelCost = value; }

}