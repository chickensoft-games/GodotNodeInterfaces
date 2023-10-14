namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class NavigationLink2DNode : NavigationLink2D, INavigationLink2D { }

/// <summary>
/// <para>A link between two positions on <see cref="NavigationRegion2D" />s that agents can be routed through. These positions can be on the same <see cref="NavigationRegion2D" /> or on two different ones. Links are useful to express navigation methods other than traveling along the surface of the navigation polygon, such as ziplines, teleporters, or gaps that can be jumped across.</para>
/// </summary>
public interface INavigationLink2D : INode2D {
    /// <summary>
    /// <para>Whether this link can be traveled in both directions or only from <see cref="NavigationLink2D.StartPosition" /> to <see cref="NavigationLink2D.EndPosition" />.</para>
    /// </summary>
    bool Bidirectional { get; set; }
    /// <summary>
    /// <para>Whether this link is currently active. If <c>false</c>, <see cref="NavigationServer2D.MapGetPath(Godot.Rid,Godot.Vector2,Godot.Vector2,System.Boolean,System.UInt32)" /> will ignore this link.</para>
    /// </summary>
    bool Enabled { get; set; }
    /// <summary>
    /// <para>Ending position of the link.</para>
    /// <para>This position will search out the nearest polygon in the navigation mesh to attach to.</para>
    /// <para>The distance the link will search is controlled by <see cref="NavigationServer2D.MapSetLinkConnectionRadius(Godot.Rid,System.Single)" />.</para>
    /// </summary>
    Vector2 EndPosition { get; set; }
    /// <summary>
    /// <para>When pathfinding enters this link from another regions navigation mesh the <see cref="NavigationLink2D.EnterCost" /> value is added to the path distance for determining the shortest path.</para>
    /// </summary>
    float EnterCost { get; set; }
    /// <summary>
    /// <para>Returns the <see cref="NavigationLink2D.EndPosition" /> that is relative to the link as a global position.</para>
    /// </summary>
    Vector2 GetGlobalEndPosition();
    /// <summary>
    /// <para>Returns the <see cref="NavigationLink2D.StartPosition" /> that is relative to the link as a global position.</para>
    /// </summary>
    Vector2 GetGlobalStartPosition();
    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="NavigationLink2D.NavigationLayers" /> bitmask is enabled, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    bool GetNavigationLayerValue(int layerNumber);
    /// <summary>
    /// <para>A bitfield determining all navigation layers the link belongs to. These navigation layers will be checked when requesting a path with <see cref="NavigationServer2D.MapGetPath(Godot.Rid,Godot.Vector2,Godot.Vector2,System.Boolean,System.UInt32)" />.</para>
    /// </summary>
    uint NavigationLayers { get; set; }
    /// <summary>
    /// <para>Sets the <see cref="NavigationLink2D.EndPosition" /> that is relative to the link from a global <paramref name="position" />.</para>
    /// </summary>
    void SetGlobalEndPosition(Vector2 position);
    /// <summary>
    /// <para>Sets the <see cref="NavigationLink2D.StartPosition" /> that is relative to the link from a global <paramref name="position" />.</para>
    /// </summary>
    void SetGlobalStartPosition(Vector2 position);
    /// <summary>
    /// <para>Based on <paramref name="value" />, enables or disables the specified layer in the <see cref="NavigationLink2D.NavigationLayers" /> bitmask, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    void SetNavigationLayerValue(int layerNumber, bool value);
    /// <summary>
    /// <para>Starting position of the link.</para>
    /// <para>This position will search out the nearest polygon in the navigation mesh to attach to.</para>
    /// <para>The distance the link will search is controlled by <see cref="NavigationServer2D.MapSetLinkConnectionRadius(Godot.Rid,System.Single)" />.</para>
    /// </summary>
    Vector2 StartPosition { get; set; }
    /// <summary>
    /// <para>When pathfinding moves along the link the traveled distance is multiplied with <see cref="NavigationLink2D.TravelCost" /> for determining the shortest path.</para>
    /// </summary>
    float TravelCost { get; set; }

}