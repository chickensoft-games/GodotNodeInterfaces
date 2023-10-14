namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>A link between two positions on <see cref="NavigationRegion3D" />s that agents can be routed through. These positions can be on the same <see cref="NavigationRegion3D" /> or on two different ones. Links are useful to express navigation methods other than traveling along the surface of the navigation mesh, such as ziplines, teleporters, or gaps that can be jumped across.</para>
/// </summary>
public interface INavigationLink3D : INode3D {
    /// <summary>
    /// <para>Based on <paramref name="value" />, enables or disables the specified layer in the <see cref="NavigationLink3D.NavigationLayers" /> bitmask, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    void SetNavigationLayerValue(int layerNumber, bool value);
    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="NavigationLink3D.NavigationLayers" /> bitmask is enabled, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    bool GetNavigationLayerValue(int layerNumber);
    /// <summary>
    /// <para>Sets the <see cref="NavigationLink3D.StartPosition" /> that is relative to the link from a global <paramref name="position" />.</para>
    /// </summary>
    void SetGlobalStartPosition(Vector3 position);
    /// <summary>
    /// <para>Returns the <see cref="NavigationLink3D.StartPosition" /> that is relative to the link as a global position.</para>
    /// </summary>
    Vector3 GetGlobalStartPosition();
    /// <summary>
    /// <para>Sets the <see cref="NavigationLink3D.EndPosition" /> that is relative to the link from a global <paramref name="position" />.</para>
    /// </summary>
    void SetGlobalEndPosition(Vector3 position);
    /// <summary>
    /// <para>Returns the <see cref="NavigationLink3D.EndPosition" /> that is relative to the link as a global position.</para>
    /// </summary>
    Vector3 GetGlobalEndPosition();
    /// <summary>
    /// <para>Whether this link is currently active. If <c>false</c>, <see cref="M:Godot.NavigationServer3D.MapGetPath(Godot.Rid,Godot.Vector3,Godot.Vector3,System.Boolean,System.UInt32)" /> will ignore this link.</para>
    /// </summary>
    bool Enabled { get; set; }
    /// <summary>
    /// <para>Whether this link can be traveled in both directions or only from <see cref="NavigationLink3D.StartPosition" /> to <see cref="NavigationLink3D.EndPosition" />.</para>
    /// </summary>
    bool Bidirectional { get; set; }
    /// <summary>
    /// <para>A bitfield determining all navigation layers the link belongs to. These navigation layers will be checked when requesting a path with <see cref="M:Godot.NavigationServer3D.MapGetPath(Godot.Rid,Godot.Vector3,Godot.Vector3,System.Boolean,System.UInt32)" />.</para>
    /// </summary>
    uint NavigationLayers { get; set; }
    /// <summary>
    /// <para>Starting position of the link.</para>
    /// <para>This position will search out the nearest polygon in the navigation mesh to attach to.</para>
    /// <para>The distance the link will search is controlled by <see cref="M:Godot.NavigationServer3D.MapSetLinkConnectionRadius(Godot.Rid,System.Single)" />.</para>
    /// </summary>
    Vector3 StartPosition { get; set; }
    /// <summary>
    /// <para>Ending position of the link.</para>
    /// <para>This position will search out the nearest polygon in the navigation mesh to attach to.</para>
    /// <para>The distance the link will search is controlled by <see cref="M:Godot.NavigationServer3D.MapSetLinkConnectionRadius(Godot.Rid,System.Single)" />.</para>
    /// </summary>
    Vector3 EndPosition { get; set; }
    /// <summary>
    /// <para>When pathfinding enters this link from another regions navigation mesh the <see cref="NavigationLink3D.EnterCost" /> value is added to the path distance for determining the shortest path.</para>
    /// </summary>
    float EnterCost { get; set; }
    /// <summary>
    /// <para>When pathfinding moves along the link the traveled distance is multiplied with <see cref="NavigationLink3D.TravelCost" /> for determining the shortest path.</para>
    /// </summary>
    float TravelCost { get; set; }

}