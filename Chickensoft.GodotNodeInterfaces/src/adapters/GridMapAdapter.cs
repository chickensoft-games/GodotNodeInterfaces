namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
using Godot.Collections;
/// <summary>
/// <para>GridMap lets you place meshes on a grid interactively. It works both from the editor and from scripts, which can help you create in-game level editors.</para>
/// <para>GridMaps use a <see cref="MeshLibrary" /> which contains a list of tiles. Each tile is a mesh with materials plus optional collision and navigation shapes.</para>
/// <para>A GridMap contains a collection of cells. Each grid cell refers to a tile in the <see cref="MeshLibrary" />. All cells in the map have the same dimensions.</para>
/// <para>Internally, a GridMap is split into a sparse collection of octants for efficient rendering and physics processing. Every octant has the same dimensions and can contain several cells.</para>
/// <para><b>Note:</b> GridMap doesn't extend <see cref="VisualInstance3D" /> and therefore can't be hidden or cull masked based on <see cref="VisualInstance3D.Layers" />. If you make a light not affect the first layer, the whole GridMap won't be lit by the light in question.</para>
/// </summary>
public class GridMapAdapter : Node3DAdapter, IGridMap {
  private readonly GridMap _node;

  public GridMapAdapter(GridMap node) : base(node) { _node = node; }

    /// <summary>
    /// <para>If <c>true</c>, this GridMap creates a navigation region for each cell that uses a <see cref="GridMap.MeshLibrary" /> item with a navigation mesh. The created navigation region will use the navigation layers bitmask assigned to the <see cref="MeshLibrary" />'s item.</para>
    /// </summary>
    public bool BakeNavigation { get => _node.BakeNavigation; set => _node.BakeNavigation = value; }
    /// <summary>
    /// <para>If <c>true</c>, grid items are centered on the X axis.</para>
    /// </summary>
    public bool CellCenterX { get => _node.CellCenterX; set => _node.CellCenterX = value; }
    /// <summary>
    /// <para>If <c>true</c>, grid items are centered on the Y axis.</para>
    /// </summary>
    public bool CellCenterY { get => _node.CellCenterY; set => _node.CellCenterY = value; }
    /// <summary>
    /// <para>If <c>true</c>, grid items are centered on the Z axis.</para>
    /// </summary>
    public bool CellCenterZ { get => _node.CellCenterZ; set => _node.CellCenterZ = value; }
    /// <summary>
    /// <para>The size of each octant measured in number of cells. This applies to all three axis.</para>
    /// </summary>
    public int CellOctantSize { get => _node.CellOctantSize; set => _node.CellOctantSize = value; }
    /// <summary>
    /// <para>The scale of the cell items.</para>
    /// <para>This does not affect the size of the grid cells themselves, only the items in them. This can be used to make cell items overlap their neighbors.</para>
    /// </summary>
    public float CellScale { get => _node.CellScale; set => _node.CellScale = value; }
    /// <summary>
    /// <para>The dimensions of the grid's cells.</para>
    /// <para>This does not affect the size of the meshes. See <see cref="GridMap.CellScale" />.</para>
    /// </summary>
    public Vector3 CellSize { get => _node.CellSize; set => _node.CellSize = value; }
    /// <summary>
    /// <para>Clear all cells.</para>
    /// </summary>
    public void Clear() => _node.Clear();
    /// <summary>
    /// <para>Clears all baked meshes. See <see cref="GridMap.MakeBakedMeshes(System.Boolean,System.Single)" />.</para>
    /// </summary>
    public void ClearBakedMeshes() => _node.ClearBakedMeshes();
    /// <summary>
    /// <para>The physics layers this GridMap is in.</para>
    /// <para>GridMaps act as static bodies, meaning they aren't affected by gravity or other forces. They only affect other physics bodies that collide with them.</para>
    /// </summary>
    public uint CollisionLayer { get => _node.CollisionLayer; set => _node.CollisionLayer = value; }
    /// <summary>
    /// <para>The physics layers this GridMap detects collisions in. See <a href="$DOCS_URL/tutorials/physics/physics_introduction.html#collision-layers-and-masks">Collision layers and masks</a> in the documentation for more information.</para>
    /// </summary>
    public uint CollisionMask { get => _node.CollisionMask; set => _node.CollisionMask = value; }
    /// <summary>
    /// <para>The priority used to solve colliding when occurring penetration. The higher the priority is, the lower the penetration into the object will be. This can for example be used to prevent the player from breaking through the boundaries of a level.</para>
    /// </summary>
    public float CollisionPriority { get => _node.CollisionPriority; set => _node.CollisionPriority = value; }
    /// <summary>
    /// <para>Returns an array of <see cref="ArrayMesh" />es and <see cref="Transform3D" /> references of all bake meshes that exist within the current GridMap.</para>
    /// </summary>
    public Godot.Collections.Array GetBakeMeshes() => _node.GetBakeMeshes();
    /// <summary>
    /// <para>Returns <see cref="Rid" /> of a baked mesh with the given <paramref name="idx" />.</para>
    /// </summary>
    public Rid GetBakeMeshInstance(int idx) => _node.GetBakeMeshInstance(idx);
    /// <summary>
    /// <para>Returns one of 24 possible rotations that lie along the vectors (x,y,z) with each component being either -1, 0, or 1. For further details, refer to the Godot source code.</para>
    /// </summary>
    public Basis GetBasisWithOrthogonalIndex(int index) => _node.GetBasisWithOrthogonalIndex(index);
    /// <summary>
    /// <para>The <see cref="MeshLibrary" /> item index located at the given grid coordinates. If the cell is empty, <see cref="GridMap.InvalidCellItem" /> will be returned.</para>
    /// </summary>
    public int GetCellItem(Vector3I position) => _node.GetCellItem(position);
    /// <summary>
    /// <para>Returns the basis that gives the specified cell its orientation.</para>
    /// </summary>
    public Basis GetCellItemBasis(Vector3I position) => _node.GetCellItemBasis(position);
    /// <summary>
    /// <para>The orientation of the cell at the given grid coordinates. <c>-1</c> is returned if the cell is empty.</para>
    /// </summary>
    public int GetCellItemOrientation(Vector3I position) => _node.GetCellItemOrientation(position);
    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="GridMap.CollisionLayer" /> is enabled, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    public bool GetCollisionLayerValue(int layerNumber) => _node.GetCollisionLayerValue(layerNumber);
    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="GridMap.CollisionMask" /> is enabled, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    public bool GetCollisionMaskValue(int layerNumber) => _node.GetCollisionMaskValue(layerNumber);
    /// <summary>
    /// <para>Returns an array of <see cref="Transform3D" /> and <see cref="Mesh" /> references corresponding to the non-empty cells in the grid. The transforms are specified in local space.</para>
    /// </summary>
    public Godot.Collections.Array GetMeshes() => _node.GetMeshes();
    /// <summary>
    /// <para>Returns the <see cref="Rid" /> of the navigation map this GridMap node uses for its cell baked navigation meshes.</para>
    /// <para>This function returns always the map set on the GridMap node and not the map on the NavigationServer. If the map is changed directly with the NavigationServer API the GridMap node will not be aware of the map change.</para>
    /// </summary>
    public Rid GetNavigationMap() => _node.GetNavigationMap();
    /// <summary>
    /// <para>This function considers a discretization of rotations into 24 points on unit sphere, lying along the vectors (x,y,z) with each component being either -1, 0, or 1, and returns the index (in the range from 0 to 23) of the point best representing the orientation of the object. For further details, refer to the Godot source code.</para>
    /// </summary>
    public int GetOrthogonalIndexFromBasis(Basis basis) => _node.GetOrthogonalIndexFromBasis(basis);
    /// <summary>
    /// <para>Returns an array of <see cref="Vector3" /> with the non-empty cell coordinates in the grid map.</para>
    /// </summary>
    public Godot.Collections.Array<Vector3I> GetUsedCells() => _node.GetUsedCells();
    /// <summary>
    /// <para>Returns an array of all cells with the given item index specified in <paramref name="item" />.</para>
    /// </summary>
    public Godot.Collections.Array<Vector3I> GetUsedCellsByItem(int item) => _node.GetUsedCellsByItem(item);
    /// <summary>
    /// <para>Returns the map coordinates of the cell containing the given <paramref name="localPosition" />. If <paramref name="localPosition" /> is in global coordinates, consider using <see cref="Node3D.ToLocal(Godot.Vector3)" /> before passing it to this method. See also <see cref="GridMap.MapToLocal(Godot.Vector3I)" />.</para>
    /// </summary>
    public Vector3I LocalToMap(Vector3 localPosition) => _node.LocalToMap(localPosition);
    /// <summary>
    /// <para>Bakes lightmap data for all meshes in the assigned <see cref="MeshLibrary" />.</para>
    /// </summary>
    public void MakeBakedMeshes(bool genLightmapUV, float lightmapUVTexelSize) => _node.MakeBakedMeshes(genLightmapUV, lightmapUVTexelSize);
    /// <summary>
    /// <para>Returns the position of a grid cell in the GridMap's local coordinate space. To convert the returned value into global coordinates, use <see cref="Node3D.ToGlobal(Godot.Vector3)" />. See also <see cref="GridMap.MapToLocal(Godot.Vector3I)" />.</para>
    /// </summary>
    public Vector3 MapToLocal(Vector3I mapPosition) => _node.MapToLocal(mapPosition);
    /// <summary>
    /// <para>The assigned <see cref="MeshLibrary" />.</para>
    /// </summary>
    public MeshLibrary MeshLibrary { get => _node.MeshLibrary; set => _node.MeshLibrary = value; }
    /// <summary>
    /// <para>Overrides the default friction and bounce physics properties for the whole <see cref="GridMap" />.</para>
    /// </summary>
    public PhysicsMaterial PhysicsMaterial { get => _node.PhysicsMaterial; set => _node.PhysicsMaterial = value; }
    /// <summary>
    /// <para><i>Obsoleted.</i> Use <see cref="Resource.Changed" /> instead.</para>
    /// </summary>
    public void ResourceChanged(Resource resource) => _node.ResourceChanged(resource);
    /// <summary>
    /// <para>Sets the mesh index for the cell referenced by its grid coordinates.</para>
    /// <para>A negative item index such as <see cref="GridMap.InvalidCellItem" /> will clear the cell.</para>
    /// <para>Optionally, the item's orientation can be passed. For valid orientation values, see <see cref="GridMap.GetOrthogonalIndexFromBasis(Godot.Basis)" />.</para>
    /// </summary>
    public void SetCellItem(Vector3I position, int item, int orientation) => _node.SetCellItem(position, item, orientation);
    /// <summary>
    /// <para>Based on <paramref name="value" />, enables or disables the specified layer in the <see cref="GridMap.CollisionLayer" />, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    public void SetCollisionLayerValue(int layerNumber, bool value) => _node.SetCollisionLayerValue(layerNumber, value);
    /// <summary>
    /// <para>Based on <paramref name="value" />, enables or disables the specified layer in the <see cref="GridMap.CollisionMask" />, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    public void SetCollisionMaskValue(int layerNumber, bool value) => _node.SetCollisionMaskValue(layerNumber, value);
    /// <summary>
    /// <para>Sets the <see cref="Rid" /> of the navigation map this GridMap node should use for its cell baked navigation meshes.</para>
    /// </summary>
    public void SetNavigationMap(Rid navigationMap) => _node.SetNavigationMap(navigationMap);

}