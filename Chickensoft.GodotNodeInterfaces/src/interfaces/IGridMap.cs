namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
using Godot.Collections;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class GridMapNode : GridMap, IGridMap { }

/// <summary>
/// <para>GridMap lets you place meshes on a grid interactively. It works both from the editor and from scripts, which can help you create in-game level editors.</para>
/// <para>GridMaps use a <see cref="MeshLibrary" /> which contains a list of tiles. Each tile is a mesh with materials plus optional collision and navigation shapes.</para>
/// <para>A GridMap contains a collection of cells. Each grid cell refers to a tile in the <see cref="MeshLibrary" />. All cells in the map have the same dimensions.</para>
/// <para>Internally, a GridMap is split into a sparse collection of octants for efficient rendering and physics processing. Every octant has the same dimensions and can contain several cells.</para>
/// <para><b>Note:</b> GridMap doesn't extend <see cref="VisualInstance3D" /> and therefore can't be hidden or cull masked based on <see cref="VisualInstance3D.Layers" />. If you make a light not affect the first layer, the whole GridMap won't be lit by the light in question.</para>
/// </summary>
public interface IGridMap : INode3D {
    /// <summary>
    /// <para>If <c>true</c>, this GridMap creates a navigation region for each cell that uses a <see cref="GridMap.MeshLibrary" /> item with a navigation mesh. The created navigation region will use the navigation layers bitmask assigned to the <see cref="MeshLibrary" />'s item.</para>
    /// </summary>
    bool BakeNavigation { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, grid items are centered on the X axis.</para>
    /// </summary>
    bool CellCenterX { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, grid items are centered on the Y axis.</para>
    /// </summary>
    bool CellCenterY { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, grid items are centered on the Z axis.</para>
    /// </summary>
    bool CellCenterZ { get; set; }
    /// <summary>
    /// <para>The size of each octant measured in number of cells. This applies to all three axis.</para>
    /// </summary>
    int CellOctantSize { get; set; }
    /// <summary>
    /// <para>The scale of the cell items.</para>
    /// <para>This does not affect the size of the grid cells themselves, only the items in them. This can be used to make cell items overlap their neighbors.</para>
    /// </summary>
    float CellScale { get; set; }
    /// <summary>
    /// <para>The dimensions of the grid's cells.</para>
    /// <para>This does not affect the size of the meshes. See <see cref="GridMap.CellScale" />.</para>
    /// </summary>
    Vector3 CellSize { get; set; }
    /// <summary>
    /// <para>Clear all cells.</para>
    /// </summary>
    void Clear();
    /// <summary>
    /// <para>Clears all baked meshes. See <see cref="GridMap.MakeBakedMeshes(System.Boolean,System.Single)" />.</para>
    /// </summary>
    void ClearBakedMeshes();
    /// <summary>
    /// <para>The physics layers this GridMap is in.</para>
    /// <para>GridMaps act as static bodies, meaning they aren't affected by gravity or other forces. They only affect other physics bodies that collide with them.</para>
    /// </summary>
    uint CollisionLayer { get; set; }
    /// <summary>
    /// <para>The physics layers this GridMap detects collisions in. See <a href="$DOCS_URL/tutorials/physics/physics_introduction.html#collision-layers-and-masks">Collision layers and masks</a> in the documentation for more information.</para>
    /// </summary>
    uint CollisionMask { get; set; }
    /// <summary>
    /// <para>The priority used to solve colliding when occurring penetration. The higher the priority is, the lower the penetration into the object will be. This can for example be used to prevent the player from breaking through the boundaries of a level.</para>
    /// </summary>
    float CollisionPriority { get; set; }
    /// <summary>
    /// <para>Returns an array of <see cref="ArrayMesh" />es and <see cref="Transform3D" /> references of all bake meshes that exist within the current GridMap.</para>
    /// </summary>
    Godot.Collections.Array GetBakeMeshes();
    /// <summary>
    /// <para>Returns <see cref="Rid" /> of a baked mesh with the given <paramref name="idx" />.</para>
    /// </summary>
    Rid GetBakeMeshInstance(int idx);
    /// <summary>
    /// <para>Returns one of 24 possible rotations that lie along the vectors (x,y,z) with each component being either -1, 0, or 1. For further details, refer to the Godot source code.</para>
    /// </summary>
    Basis GetBasisWithOrthogonalIndex(int index);
    /// <summary>
    /// <para>The <see cref="MeshLibrary" /> item index located at the given grid coordinates. If the cell is empty, <see cref="GridMap.InvalidCellItem" /> will be returned.</para>
    /// </summary>
    int GetCellItem(Vector3I position);
    /// <summary>
    /// <para>Returns the basis that gives the specified cell its orientation.</para>
    /// </summary>
    Basis GetCellItemBasis(Vector3I position);
    /// <summary>
    /// <para>The orientation of the cell at the given grid coordinates. <c>-1</c> is returned if the cell is empty.</para>
    /// </summary>
    int GetCellItemOrientation(Vector3I position);
    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="GridMap.CollisionLayer" /> is enabled, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    bool GetCollisionLayerValue(int layerNumber);
    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="GridMap.CollisionMask" /> is enabled, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    bool GetCollisionMaskValue(int layerNumber);
    /// <summary>
    /// <para>Returns an array of <see cref="Transform3D" /> and <see cref="Mesh" /> references corresponding to the non-empty cells in the grid. The transforms are specified in local space.</para>
    /// </summary>
    Godot.Collections.Array GetMeshes();
    /// <summary>
    /// <para>Returns the <see cref="Rid" /> of the navigation map this GridMap node uses for its cell baked navigation meshes.</para>
    /// <para>This function returns always the map set on the GridMap node and not the map on the NavigationServer. If the map is changed directly with the NavigationServer API the GridMap node will not be aware of the map change.</para>
    /// </summary>
    Rid GetNavigationMap();
    /// <summary>
    /// <para>This function considers a discretization of rotations into 24 points on unit sphere, lying along the vectors (x,y,z) with each component being either -1, 0, or 1, and returns the index (in the range from 0 to 23) of the point best representing the orientation of the object. For further details, refer to the Godot source code.</para>
    /// </summary>
    int GetOrthogonalIndexFromBasis(Basis basis);
    /// <summary>
    /// <para>Returns an array of <see cref="Vector3" /> with the non-empty cell coordinates in the grid map.</para>
    /// </summary>
    Godot.Collections.Array<Vector3I> GetUsedCells();
    /// <summary>
    /// <para>Returns an array of all cells with the given item index specified in <paramref name="item" />.</para>
    /// </summary>
    Godot.Collections.Array<Vector3I> GetUsedCellsByItem(int item);
    /// <summary>
    /// <para>Returns the map coordinates of the cell containing the given <paramref name="localPosition" />. If <paramref name="localPosition" /> is in global coordinates, consider using <see cref="Node3D.ToLocal(Godot.Vector3)" /> before passing it to this method. See also <see cref="GridMap.MapToLocal(Godot.Vector3I)" />.</para>
    /// </summary>
    Vector3I LocalToMap(Vector3 localPosition);
    /// <summary>
    /// <para>Bakes lightmap data for all meshes in the assigned <see cref="MeshLibrary" />.</para>
    /// </summary>
    void MakeBakedMeshes(bool genLightmapUV, float lightmapUVTexelSize);
    /// <summary>
    /// <para>Returns the position of a grid cell in the GridMap's local coordinate space. To convert the returned value into global coordinates, use <see cref="Node3D.ToGlobal(Godot.Vector3)" />. See also <see cref="GridMap.MapToLocal(Godot.Vector3I)" />.</para>
    /// </summary>
    Vector3 MapToLocal(Vector3I mapPosition);
    /// <summary>
    /// <para>The assigned <see cref="MeshLibrary" />.</para>
    /// </summary>
    MeshLibrary MeshLibrary { get; set; }
    /// <summary>
    /// <para>Overrides the default friction and bounce physics properties for the whole <see cref="GridMap" />.</para>
    /// </summary>
    PhysicsMaterial PhysicsMaterial { get; set; }
    /// <summary>
    /// <para><i>Obsoleted.</i> Use <see cref="Resource.Changed" /> instead.</para>
    /// </summary>
    void ResourceChanged(Resource resource);
    /// <summary>
    /// <para>Sets the mesh index for the cell referenced by its grid coordinates.</para>
    /// <para>A negative item index such as <see cref="GridMap.InvalidCellItem" /> will clear the cell.</para>
    /// <para>Optionally, the item's orientation can be passed. For valid orientation values, see <see cref="GridMap.GetOrthogonalIndexFromBasis(Godot.Basis)" />.</para>
    /// </summary>
    void SetCellItem(Vector3I position, int item, int orientation);
    /// <summary>
    /// <para>Based on <paramref name="value" />, enables or disables the specified layer in the <see cref="GridMap.CollisionLayer" />, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    void SetCollisionLayerValue(int layerNumber, bool value);
    /// <summary>
    /// <para>Based on <paramref name="value" />, enables or disables the specified layer in the <see cref="GridMap.CollisionMask" />, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    void SetCollisionMaskValue(int layerNumber, bool value);
    /// <summary>
    /// <para>Sets the <see cref="Rid" /> of the navigation map this GridMap node should use for its cell baked navigation meshes.</para>
    /// </summary>
    void SetNavigationMap(Rid navigationMap);

}