namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
using Godot.Collections;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class TileMapNode : TileMap, ITileMap { }

/// <summary>
/// <para>Node for 2D tile-based maps. Tilemaps use a <see cref="TileSet" /> which contain a list of tiles which are used to create grid-based maps. A TileMap may have several layers, layouting tiles on top of each other.</para>
/// <para>For performance reasons, all TileMap updates are batched at the end of a frame. Notably, this means that scene tiles from a <see cref="TileSetScenesCollectionSource" /> may be initialized after their parent.</para>
/// <para>To force an update earlier on, call <see cref="TileMap.UpdateInternals" />.</para>
/// </summary>
public interface ITileMap : INode2D {
    /// <summary>
    /// <para>Called with a TileData object about to be used internally by the TileMap, allowing its modification at runtime.</para>
    /// <para>This method is only called if <see cref="TileMap._UseTileDataRuntimeUpdate(System.Int32,Godot.Vector2I)" /> is implemented and returns <c>true</c> for the given tile <paramref name="coords" /> and <paramref name="layer" />.</para>
    /// <para><b>Warning:</b> The <paramref name="tileData" /> object's sub-resources are the same as the one in the TileSet. Modifying them might impact the whole TileSet. Instead, make sure to duplicate those resources.</para>
    /// <para><b>Note:</b> If the properties of <paramref name="tileData" /> object should change over time, use <see cref="TileMap.NotifyRuntimeTileDataUpdate(System.Int32)" /> to notify the TileMap it needs an update.</para>
    /// </summary>
    void _TileDataRuntimeUpdate(int layer, Vector2I coords, TileData tileData);
    /// <summary>
    /// <para>Should return <c>true</c> if the tile at coordinates <paramref name="coords" /> on layer <paramref name="layer" /> requires a runtime update.</para>
    /// <para><b>Warning:</b> Make sure this function only return <c>true</c> when needed. Any tile processed at runtime without a need for it will imply a significant performance penalty.</para>
    /// <para><b>Note:</b> If the result of this function should changed, use <see cref="TileMap.NotifyRuntimeTileDataUpdate(System.Int32)" /> to notify the TileMap it needs an update.</para>
    /// </summary>
    bool _UseTileDataRuntimeUpdate(int layer, Vector2I coords);
    /// <summary>
    /// <para>Adds a layer at the given position <paramref name="toPosition" /> in the array. If <paramref name="toPosition" /> is negative, the position is counted from the end, with <c>-1</c> adding the layer at the end of the array.</para>
    /// </summary>
    void AddLayer(int toPosition);
    /// <summary>
    /// The TileMap's quadrant size. Optimizes drawing by batching, using chunks of this size.
    /// </summary>
    int CellQuadrantSize { get; set; }
    /// <summary>
    /// <para>Clears all cells.</para>
    /// </summary>
    void Clear();
    /// <summary>
    /// <para>Clears all cells on the given layer.</para>
    /// <para>If <paramref name="layer" /> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    void ClearLayer(int layer);
    /// <summary>
    /// <para>If enabled, the TileMap will see its collisions synced to the physics tick and change its collision type from static to kinematic. This is required to create TileMap-based moving platform.</para>
    /// <para><b>Note:</b> Enabling <see cref="TileMap.CollisionAnimatable" /> may have a small performance impact, only do it if the TileMap is moving and has colliding tiles.</para>
    /// </summary>
    bool CollisionAnimatable { get; set; }
    /// <summary>
    /// <para>Show or hide the TileMap's collision shapes. If set to <see cref="TileMap.VisibilityMode.Default" />, this depends on the show collision debug settings.</para>
    /// </summary>
    TileMap.VisibilityMode CollisionVisibilityMode { get; set; }
    /// <summary>
    /// <para>Erases the cell on layer <paramref name="layer" /> at coordinates <paramref name="coords" />.</para>
    /// <para>If <paramref name="layer" /> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    void EraseCell(int layer, Vector2I coords);
    /// <summary>
    /// <para>Clears cells that do not exist in the tileset.</para>
    /// </summary>
    void FixInvalidTiles();
    /// <summary>
    /// <para><i>Deprecated.</i> See <see cref="TileMap.NotifyRuntimeTileDataUpdate(System.Int32)" /> and <see cref="TileMap.UpdateInternals" />.</para>
    /// </summary>
    void ForceUpdate(int layer);
    /// <summary>
    /// <para>Returns the tile alternative ID of the cell on layer <paramref name="layer" /> at <paramref name="coords" />. If <paramref name="useProxies" /> is <c>false</c>, ignores the <see cref="TileSet" />'s tile proxies, returning the raw alternative identifier. See <see cref="TileSet.MapTileProxy(System.Int32,Godot.Vector2I,System.Int32)" />.</para>
    /// <para>If <paramref name="layer" /> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    int GetCellAlternativeTile(int layer, Vector2I coords, bool useProxies);
    /// <summary>
    /// <para>Returns the tile atlas coordinates ID of the cell on layer <paramref name="layer" /> at coordinates <paramref name="coords" />. If <paramref name="useProxies" /> is <c>false</c>, ignores the <see cref="TileSet" />'s tile proxies, returning the raw alternative identifier. See <see cref="TileSet.MapTileProxy(System.Int32,Godot.Vector2I,System.Int32)" />.</para>
    /// <para>If <paramref name="layer" /> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    Vector2I GetCellAtlasCoords(int layer, Vector2I coords, bool useProxies);
    /// <summary>
    /// <para>Returns the tile source ID of the cell on layer <paramref name="layer" /> at coordinates <paramref name="coords" />. Returns <c>-1</c> if the cell does not exist.</para>
    /// <para>If <paramref name="useProxies" /> is <c>false</c>, ignores the <see cref="TileSet" />'s tile proxies, returning the raw alternative identifier. See <see cref="TileSet.MapTileProxy(System.Int32,Godot.Vector2I,System.Int32)" />.</para>
    /// <para>If <paramref name="layer" /> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    int GetCellSourceId(int layer, Vector2I coords, bool useProxies);
    /// <summary>
    /// <para>Returns the <see cref="TileData" /> object associated with the given cell, or <c>null</c> if the cell does not exist or is not a <see cref="TileSetAtlasSource" />.</para>
    /// <para>If <paramref name="layer" /> is negative, the layers are accessed from the last one.</para>
    /// <para>If <paramref name="useProxies" /> is <c>false</c>, ignores the <see cref="TileSet" />'s tile proxies, returning the raw alternative identifier. See <see cref="TileSet.MapTileProxy(System.Int32,Godot.Vector2I,System.Int32)" />.</para>
    /// <para><code>
    /// func get_clicked_tile_power():
    /// var clicked_cell = tile_map.local_to_map(tile_map.get_local_mouse_position())
    /// var data = tile_map.get_cell_tile_data(0, clicked_cell)
    /// if data:
    /// return data.get_custom_data("power")
    /// else:
    /// return 0
    /// </code></para>
    /// </summary>
    TileData GetCellTileData(int layer, Vector2I coords, bool useProxies);
    /// <summary>
    /// <para>Returns the coordinates of the tile for given physics body RID. Such RID can be retrieved from <see cref="KinematicCollision2D.GetColliderRid" />, when colliding with a tile.</para>
    /// </summary>
    Vector2I GetCoordsForBodyRid(Rid body);
    /// <summary>
    /// <para>Returns the tilemap layer of the tile for given physics body RID. Such RID can be retrieved from <see cref="KinematicCollision2D.GetColliderRid" />, when colliding with a tile.</para>
    /// </summary>
    int GetLayerForBodyRid(Rid body);
    /// <summary>
    /// <para>Returns a TileMap layer's modulate.</para>
    /// <para>If <paramref name="layer" /> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    Color GetLayerModulate(int layer);
    /// <summary>
    /// <para>Returns a TileMap layer's name.</para>
    /// <para>If <paramref name="layer" /> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    string GetLayerName(int layer);
    /// <summary>
    /// <para>Returns the <see cref="NavigationServer2D" /> navigation map <see cref="Rid" /> currently assigned to the specified TileMap <paramref name="layer" />.</para>
    /// <para>By default the TileMap uses the default <see cref="World2D" /> navigation map for the first TileMap layer. For each additional TileMap layer a new navigation map is created for the additional layer.</para>
    /// <para>In order to make <see cref="NavigationAgent2D" /> switch between TileMap layer navigation maps use <see cref="NavigationAgent2D.SetNavigationMap(Godot.Rid)" /> with the navigation map received from <see cref="TileMap.GetLayerNavigationMap(System.Int32)" />.</para>
    /// <para>If <paramref name="layer" /> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    Rid GetLayerNavigationMap(int layer);
    /// <summary>
    /// <para>Returns the number of layers in the TileMap.</para>
    /// </summary>
    int GetLayersCount();
    /// <summary>
    /// <para>Returns a TileMap layer's Y sort origin.</para>
    /// <para>If <paramref name="layer" /> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    int GetLayerYSortOrigin(int layer);
    /// <summary>
    /// <para>Returns a TileMap layer's Z-index value.</para>
    /// <para>If <paramref name="layer" /> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    int GetLayerZIndex(int layer);
    /// <summary>
    /// <para>See <see cref="TileMap.GetLayerNavigationMap(System.Int32)" />.</para>
    /// </summary>
    Rid GetNavigationMap(int layer);
    /// <summary>
    /// <para>Returns the neighboring cell to the one at coordinates <paramref name="coords" />, identified by the <paramref name="neighbor" /> direction. This method takes into account the different layouts a TileMap can take.</para>
    /// </summary>
    Vector2I GetNeighborCell(Vector2I coords, TileSet.CellNeighbor neighbor);
    /// <summary>
    /// <para>Creates a new <see cref="TileMapPattern" /> from the given layer and set of cells.</para>
    /// <para>If <paramref name="layer" /> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    TileMapPattern GetPattern(int layer, Godot.Collections.Array<Vector2I> coordsArray);

    int GetQuadrantSize();
    /// <summary>
    /// <para>Returns the list of all neighbourings cells to the one at <paramref name="coords" />.</para>
    /// </summary>
    Godot.Collections.Array<Vector2I> GetSurroundingCells(Vector2I coords);
    /// <summary>
    /// <para>Returns a <see cref="Vector2I" /> array with the positions of all cells containing a tile in the given layer. A cell is considered empty if its source identifier equals -1, its atlas coordinates identifiers is <c>Vector2(-1, -1)</c> and its alternative identifier is -1.</para>
    /// <para>If <paramref name="layer" /> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    Godot.Collections.Array<Vector2I> GetUsedCells(int layer);
    /// <summary>
    /// <para>Returns a <see cref="Vector2I" /> array with the positions of all cells containing a tile in the given layer. Tiles may be filtered according to their source (<paramref name="sourceId" />), their atlas coordinates (<paramref name="atlasCoords" />) or alternative id (<paramref name="alternativeTile" />).</para>
    /// <para>If a parameter has its value set to the default one, this parameter is not used to filter a cell. Thus, if all parameters have their respective default value, this method returns the same result as <see cref="TileMap.GetUsedCells(System.Int32)" />.</para>
    /// <para>A cell is considered empty if its source identifier equals -1, its atlas coordinates identifiers is <c>Vector2(-1, -1)</c> and its alternative identifier is -1.</para>
    /// <para>If <paramref name="layer" /> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    /// <param name="atlasCoords">If the parameter is null, then the default value is <c>new Vector2I(-1, -1)</c>.</param>
    Godot.Collections.Array<Vector2I> GetUsedCellsById(int layer, int sourceId, Nullable<Vector2I> atlasCoords, int alternativeTile);
    /// <summary>
    /// <para>Returns a rectangle enclosing the used (non-empty) tiles of the map, including all layers.</para>
    /// </summary>
    Rect2I GetUsedRect();
    /// <summary>
    /// <para>Returns if a layer is enabled.</para>
    /// <para>If <paramref name="layer" /> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    bool IsLayerEnabled(int layer);
    /// <summary>
    /// <para>Returns if a layer Y-sorts its tiles.</para>
    /// <para>If <paramref name="layer" /> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    bool IsLayerYSortEnabled(int layer);
    /// <summary>
    /// <para>Returns the map coordinates of the cell containing the given <paramref name="localPosition" />. If <paramref name="localPosition" /> is in global coordinates, consider using <see cref="Node2D.ToLocal(Godot.Vector2)" /> before passing it to this method. See also <see cref="TileMap.MapToLocal(Godot.Vector2I)" />.</para>
    /// </summary>
    Vector2I LocalToMap(Vector2 localPosition);
    /// <summary>
    /// <para>Returns for the given coordinate <paramref name="coordsInPattern" /> in a <see cref="TileMapPattern" /> the corresponding cell coordinates if the pattern was pasted at the <paramref name="positionInTilemap" /> coordinates (see <see cref="TileMap.SetPattern(System.Int32,Godot.Vector2I,Godot.TileMapPattern)" />). This mapping is required as in half-offset tile shapes, the mapping might not work by calculating <c>position_in_tile_map + coords_in_pattern</c>.</para>
    /// </summary>
    Vector2I MapPattern(Vector2I positionInTilemap, Vector2I coordsInPattern, TileMapPattern pattern);
    /// <summary>
    /// <para>Returns the centered position of a cell in the TileMap's local coordinate space. To convert the returned value into global coordinates, use <see cref="Node2D.ToGlobal(Godot.Vector2)" />. See also <see cref="TileMap.LocalToMap(Godot.Vector2)" />.</para>
    /// <para><b>Note:</b> This may not correspond to the visual position of the tile, i.e. it ignores the <see cref="TileData.TextureOrigin" /> property of individual tiles.</para>
    /// </summary>
    Vector2 MapToLocal(Vector2I mapPosition);
    /// <summary>
    /// <para>Moves the layer at index <paramref name="layer" /> to the given position <paramref name="toPosition" /> in the array.</para>
    /// </summary>
    void MoveLayer(int layer, int toPosition);
    /// <summary>
    /// <para>Show or hide the TileMap's navigation meshes. If set to <see cref="TileMap.VisibilityMode.Default" />, this depends on the show navigation debug settings.</para>
    /// </summary>
    TileMap.VisibilityMode NavigationVisibilityMode { get; set; }
    /// <summary>
    /// <para>Notifies the TileMap node that calls to <see cref="TileMap._UseTileDataRuntimeUpdate(System.Int32,Godot.Vector2I)" /> or <see cref="TileMap._TileDataRuntimeUpdate(System.Int32,Godot.Vector2I,Godot.TileData)" /> will lead to different results. This will thus trigger a TileMap update.</para>
    /// <para>If <paramref name="layer" /> is provided, only notifies changes for the given layer. Providing the <paramref name="layer" /> argument (when applicable) is usually preferred for performance reasons.</para>
    /// <para><b>Warning:</b> Updating the TileMap is computationally expensive and may impact performance. Try to limit the number of calls to this function to avoid unnecessary update.</para>
    /// <para><b>Note:</b> This does not trigger a direct update of the TileMap, the update will be done at the end of the frame as usual (unless you call <see cref="TileMap.UpdateInternals" />).</para>
    /// </summary>
    void NotifyRuntimeTileDataUpdate(int layer);
    /// <summary>
    /// <para>Removes the layer at index <paramref name="layer" />.</para>
    /// </summary>
    void RemoveLayer(int layer);
    /// <summary>
    /// <para>The TileMap's quadrant size. A quadrant is a group of tiles to be drawn together on a single canvas item, for optimization purposes. <see cref="TileMap.RenderingQuadrantSize" /> defines the length of a square's side, in the map's coordinate system, that forms the quadrant. Thus, the default quandrant size groups together <c>16 * 16 = 256</c> tiles.</para>
    /// <para>The quadrant size does not apply on Y-sorted layers, as tiles are be grouped by Y position instead in that case.</para>
    /// <para><b>Note:</b> As quadrants are created according to the map's coordinate system, the quadrant's "square shape" might not look like square in the TileMap's local coordinate system.</para>
    /// </summary>
    int RenderingQuadrantSize { get; set; }
    /// <summary>
    /// <para>Sets the tile identifiers for the cell on layer <paramref name="layer" /> at coordinates <paramref name="coords" />. Each tile of the <see cref="TileSet" /> is identified using three parts:</para>
    /// <para>- The source identifier <paramref name="sourceId" /> identifies a <see cref="TileSetSource" /> identifier. See <see cref="TileSet.SetSourceId(System.Int32,System.Int32)" />,</para>
    /// <para>- The atlas coordinates identifier <paramref name="atlasCoords" /> identifies a tile coordinates in the atlas (if the source is a <see cref="TileSetAtlasSource" />). For <see cref="TileSetScenesCollectionSource" /> it should always be <c>Vector2i(0, 0)</c>),</para>
    /// <para>- The alternative tile identifier <paramref name="alternativeTile" /> identifies a tile alternative in the atlas (if the source is a <see cref="TileSetAtlasSource" />), and the scene for a <see cref="TileSetScenesCollectionSource" />.</para>
    /// <para>If <paramref name="sourceId" /> is set to <c>-1</c>, <paramref name="atlasCoords" /> to <c>Vector2i(-1, -1)</c> or <paramref name="alternativeTile" /> to <c>-1</c>, the cell will be erased. An erased cell gets <b>all</b> its identifiers automatically set to their respective invalid values, namely <c>-1</c>, <c>Vector2i(-1, -1)</c> and <c>-1</c>.</para>
    /// <para>If <paramref name="layer" /> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    /// <param name="atlasCoords">If the parameter is null, then the default value is <c>new Vector2I(-1, -1)</c>.</param>
    void SetCell(int layer, Vector2I coords, int sourceId, Nullable<Vector2I> atlasCoords, int alternativeTile);
    /// <summary>
    /// <para>Update all the cells in the <paramref name="cells" /> coordinates array so that they use the given <paramref name="terrain" /> for the given <paramref name="terrainSet" />. If an updated cell has the same terrain as one of its neighboring cells, this function tries to join the two. This function might update neighboring tiles if needed to create correct terrain transitions.</para>
    /// <para>If <paramref name="ignoreEmptyTerrains" /> is true, empty terrains will be ignored when trying to find the best fitting tile for the given terrain constraints.</para>
    /// <para>If <paramref name="layer" /> is negative, the layers are accessed from the last one.</para>
    /// <para><b>Note:</b> To work correctly, this method requires the TileMap's TileSet to have terrains set up with all required terrain combinations. Otherwise, it may produce unexpected results.</para>
    /// </summary>
    void SetCellsTerrainConnect(int layer, Godot.Collections.Array<Vector2I> cells, int terrainSet, int terrain, bool ignoreEmptyTerrains);
    /// <summary>
    /// <para>Update all the cells in the <paramref name="path" /> coordinates array so that they use the given <paramref name="terrain" /> for the given <paramref name="terrainSet" />. The function will also connect two successive cell in the path with the same terrain. This function might update neighboring tiles if needed to create correct terrain transitions.</para>
    /// <para>If <paramref name="ignoreEmptyTerrains" /> is true, empty terrains will be ignored when trying to find the best fitting tile for the given terrain constraints.</para>
    /// <para>If <paramref name="layer" /> is negative, the layers are accessed from the last one.</para>
    /// <para><b>Note:</b> To work correctly, this method requires the TileMap's TileSet to have terrains set up with all required terrain combinations. Otherwise, it may produce unexpected results.</para>
    /// </summary>
    void SetCellsTerrainPath(int layer, Godot.Collections.Array<Vector2I> path, int terrainSet, int terrain, bool ignoreEmptyTerrains);
    /// <summary>
    /// <para>Enables or disables the layer <paramref name="layer" />. A disabled layer is not processed at all (no rendering, no physics, etc...).</para>
    /// <para>If <paramref name="layer" /> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    void SetLayerEnabled(int layer, bool enabled);
    /// <summary>
    /// <para>Sets a layer's color. It will be multiplied by tile's color and TileMap's modulate.</para>
    /// <para>If <paramref name="layer" /> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    void SetLayerModulate(int layer, Color modulate);
    /// <summary>
    /// <para>Sets a layer's name. This is mostly useful in the editor.</para>
    /// <para>If <paramref name="layer" /> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    void SetLayerName(int layer, string name);
    /// <summary>
    /// <para>Assigns a <see cref="NavigationServer2D" /> navigation map <see cref="Rid" /> to the specified TileMap <paramref name="layer" />.</para>
    /// <para>By default the TileMap uses the default <see cref="World2D" /> navigation map for the first TileMap layer. For each additional TileMap layer a new navigation map is created for the additional layer.</para>
    /// <para>In order to make <see cref="NavigationAgent2D" /> switch between TileMap layer navigation maps use <see cref="NavigationAgent2D.SetNavigationMap(Godot.Rid)" /> with the navigation map received from <see cref="TileMap.GetLayerNavigationMap(System.Int32)" />.</para>
    /// <para>If <paramref name="layer" /> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    void SetLayerNavigationMap(int layer, Rid map);
    /// <summary>
    /// <para>Enables or disables a layer's Y-sorting. If a layer is Y-sorted, the layer will behave as a CanvasItem node where each of its tile gets Y-sorted.</para>
    /// <para>Y-sorted layers should usually be on different Z-index values than not Y-sorted layers, otherwise, each of those layer will be Y-sorted as whole with the Y-sorted one. This is usually an undesired behavior.</para>
    /// <para>If <paramref name="layer" /> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    void SetLayerYSortEnabled(int layer, bool ySortEnabled);
    /// <summary>
    /// <para>Sets a layer's Y-sort origin value. This Y-sort origin value is added to each tile's Y-sort origin value.</para>
    /// <para>This allows, for example, to fake a different height level on each layer. This can be useful for top-down view games.</para>
    /// <para>If <paramref name="layer" /> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    void SetLayerYSortOrigin(int layer, int ySortOrigin);
    /// <summary>
    /// <para>Sets a layers Z-index value. This Z-index is added to each tile's Z-index value.</para>
    /// <para>If <paramref name="layer" /> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    void SetLayerZIndex(int layer, int zIndex);
    /// <summary>
    /// <para>See <see cref="TileMap.SetLayerNavigationMap(System.Int32,Godot.Rid)" />.</para>
    /// </summary>
    void SetNavigationMap(int layer, Rid map);
    /// <summary>
    /// <para>Paste the given <see cref="TileMapPattern" /> at the given <paramref name="position" /> and <paramref name="layer" /> in the tile map.</para>
    /// <para>If <paramref name="layer" /> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    void SetPattern(int layer, Vector2I position, TileMapPattern pattern);

    void SetQuadrantSize(int quadrantSize);
    /// <summary>
    /// <para>The assigned <see cref="TileSet" />.</para>
    /// </summary>
    TileSet TileSet { get; set; }
    /// <summary>
    /// <para>Triggers a direct update of the TileMap. Usually, calling this function is not needed, as TileMap node updates automatically when one of its properties or cells is modified.</para>
    /// <para>However, for performance reasons, those updates are batched and delayed to the end of the frame. Calling this function will force the TileMap to update right away instead.</para>
    /// <para><b>Warning:</b> Updating the TileMap is computationally expensive and may impact performance. Try to limit the number of updates and how many tiles they impact.</para>
    /// </summary>
    void UpdateInternals();

}