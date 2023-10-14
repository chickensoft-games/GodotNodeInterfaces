namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para><see cref="VoxelGI" />s are used to provide high-quality real-time indirect light and reflections to scenes. They precompute the effect of objects that emit light and the effect of static geometry to simulate the behavior of complex light in real-time. <see cref="VoxelGI" />s need to be baked before having a visible effect. However, once baked, dynamic objects will receive light from them. Furthermore, lights can be fully dynamic or baked.</para>
/// <para><b>Note:</b> <see cref="VoxelGI" /> is only supported in the Forward+ rendering method, not Mobile or Compatibility.</para>
/// <para><b>Procedural generation:</b> <see cref="VoxelGI" /> can be baked in an exported project, which makes it suitable for procedurally generated or user-built levels as long as all the geometry is generated in advance. For games where geometry is generated at any time during gameplay, SDFGI is more suitable (see <see cref="Environment.SdfgiEnabled" />).</para>
/// <para><b>Performance:</b> <see cref="VoxelGI" /> is relatively demanding on the GPU and is not suited to low-end hardware such as integrated graphics (consider <see cref="LightmapGI" /> instead). To improve performance, adjust <c>ProjectSettings.rendering/global_illumination/voxel_gi/quality</c> and enable <c>ProjectSettings.rendering/global_illumination/gi/use_half_resolution</c> in the Project Settings. To provide a fallback for low-end hardware, consider adding an option to disable <see cref="VoxelGI" /> in your project's options menus. A <see cref="VoxelGI" /> node can be disabled by hiding it.</para>
/// <para><b>Note:</b> Meshes should have sufficiently thick walls to avoid light leaks (avoid one-sided walls). For interior levels, enclose your level geometry in a sufficiently large box and bridge the loops to close the mesh. To further prevent light leaks, you can also strategically place temporary <see cref="MeshInstance3D" /> nodes with their <see cref="GeometryInstance3D.GIMode" /> set to <see cref="GeometryInstance3D.GIModeEnum.Static" />. These temporary nodes can then be hidden after baking the <see cref="VoxelGI" /> node.</para>
/// </summary>
public interface IVoxelGI : IVisualInstance3D {
    /// <summary>
    /// <para>Bakes the effect from all <see cref="GeometryInstance3D" />s marked with <see cref="GeometryInstance3D.GIModeEnum.Static" /> and <see cref="Light3D" />s marked with either <see cref="Light3D.BakeMode.Static" /> or <see cref="Light3D.BakeMode.Dynamic" />. If <paramref name="createVisualDebug" /> is <c>true</c>, after baking the light, this will generate a <see cref="MultiMesh" /> that has a cube representing each solid cell with each cube colored to the cell's albedo color. This can be used to visualize the <see cref="VoxelGI" />'s data and debug any issues that may be occurring.</para>
    /// <para><b>Note:</b> <see cref="M:Godot.VoxelGI.Bake(Godot.Node,System.Boolean)" /> works from the editor and in exported projects. This makes it suitable for procedurally generated or user-built levels. Baking a <see cref="VoxelGI" /> node generally takes from 5 to 20 seconds in most scenes. Reducing <see cref="VoxelGI.Subdiv" /> can speed up baking.</para>
    /// <para><b>Note:</b> <see cref="GeometryInstance3D" />s and <see cref="Light3D" />s must be fully ready before <see cref="M:Godot.VoxelGI.Bake(Godot.Node,System.Boolean)" /> is called. If you are procedurally creating those and some meshes or lights are missing from your baked <see cref="VoxelGI" />, use <c>call_deferred("bake")</c> instead of calling <see cref="M:Godot.VoxelGI.Bake(Godot.Node,System.Boolean)" /> directly.</para>
    /// </summary>
    void Bake(Node fromNode, bool createVisualDebug);
    /// <summary>
    /// <para>Calls <see cref="M:Godot.VoxelGI.Bake(Godot.Node,System.Boolean)" /> with <c>create_visual_debug</c> enabled.</para>
    /// </summary>
    void DebugBake();
    /// <summary>
    /// <para>Number of times to subdivide the grid that the <see cref="VoxelGI" /> operates on. A higher number results in finer detail and thus higher visual quality, while lower numbers result in better performance.</para>
    /// </summary>
    VoxelGI.SubdivEnum Subdiv { get; set; }
    /// <summary>
    /// <para>The size of the area covered by the <see cref="VoxelGI" />. If you make the size larger without increasing the subdivisions with <see cref="VoxelGI.Subdiv" />, the size of each cell will increase and result in lower detailed lighting.</para>
    /// <para><b>Note:</b> Size is clamped to 1.0 unit or more on each axis.</para>
    /// </summary>
    Vector3 Size { get; set; }
    /// <summary>
    /// <para>The <see cref="CameraAttributes" /> resource that specifies exposure levels to bake at. Auto-exposure and non exposure properties will be ignored. Exposure settings should be used to reduce the dynamic range present when baking. If exposure is too high, the <see cref="VoxelGI" /> will have banding artifacts or may have over-exposure artifacts.</para>
    /// </summary>
    CameraAttributes CameraAttributes { get; set; }
    /// <summary>
    /// <para>The <see cref="VoxelGIData" /> resource that holds the data for this <see cref="VoxelGI" />.</para>
    /// </summary>
    VoxelGIData Data { get; set; }

}