namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>Occlusion culling can improve rendering performance in closed/semi-open areas by hiding geometry that is occluded by other objects.</para>
/// <para>The occlusion culling system is mostly static. <see cref="OccluderInstance3D" />s can be moved or hidden at run-time, but doing so will trigger a background recomputation that can take several frames. It is recommended to only move <see cref="OccluderInstance3D" />s sporadically (e.g. for procedural generation purposes), rather than doing so every frame.</para>
/// <para>The occlusion culling system works by rendering the occluders on the CPU in parallel using <a href="https://www.embree.org/">Embree</a>, drawing the result to a low-resolution buffer then using this to cull 3D nodes individually. In the 3D editor, you can preview the occlusion culling buffer by choosing <b>Perspective &gt; Debug Advanced... &gt; Occlusion Culling Buffer</b> in the top-left corner of the 3D viewport. The occlusion culling buffer quality can be adjusted in the Project Settings.</para>
/// <para><b>Baking:</b> Select an <see cref="OccluderInstance3D" /> node, then use the <b>Bake Occluders</b> button at the top of the 3D editor. Only opaque materials will be taken into account; transparent materials (alpha-blended or alpha-tested) will be ignored by the occluder generation.</para>
/// <para><b>Note:</b> Occlusion culling is only effective if <c>ProjectSettings.rendering/occlusion_culling/use_occlusion_culling</c> is <c>true</c>. Enabling occlusion culling has a cost on the CPU. Only enable occlusion culling if you actually plan to use it. Large open scenes with few or no objects blocking the view will generally not benefit much from occlusion culling. Large open scenes generally benefit more from mesh LOD and visibility ranges (<see cref="GeometryInstance3D.VisibilityRangeBegin" /> and <see cref="GeometryInstance3D.VisibilityRangeEnd" />) compared to occlusion culling.</para>
/// <para><b>Note:</b> Due to memory constraints, occlusion culling is not supported by default in Web export templates. It can be enabled by compiling custom Web export templates with <c>module_raycast_enabled=yes</c>.</para>
/// </summary>
public class OccluderInstance3DAdapter : Node3DAdapter, IOccluderInstance3D {
  private readonly OccluderInstance3D _node;

  public OccluderInstance3DAdapter(OccluderInstance3D node) : base(node) { _node = node; }

    /// <summary>
    /// <para>The visual layers to account for when baking for occluders. Only <see cref="MeshInstance3D" />s whose <see cref="VisualInstance3D.Layers" /> match with this <see cref="OccluderInstance3D.BakeMask" /> will be included in the generated occluder mesh. By default, all objects with <i>opaque</i> materials are taken into account for the occluder baking.</para>
    /// <para>To improve performance and avoid artifacts, it is recommended to exclude dynamic objects, small objects and fixtures from the baking process by moving them to a separate visual layer and excluding this layer in <see cref="OccluderInstance3D.BakeMask" />.</para>
    /// </summary>
    public uint BakeMask { get => _node.BakeMask; set => _node.BakeMask = value; }
    /// <summary>
    /// <para>The simplification distance to use for simplifying the generated occluder polygon (in 3D units). Higher values result in a less detailed occluder mesh, which improves performance but reduces culling accuracy.</para>
    /// <para>The occluder geometry is rendered on the CPU, so it is important to keep its geometry as simple as possible. Since the buffer is rendered at a low resolution, less detailed occluder meshes generally still work well. The default value is fairly aggressive, so you may have to decrease it if you run into false negatives (objects being occluded even though they are visible by the camera). A value of <c>0.01</c> will act conservatively, and will keep geometry <i>perceptually</i> unaffected in the occlusion culling buffer. Depending on the scene, a value of <c>0.01</c> may still simplify the mesh noticeably compared to disabling simplification entirely.</para>
    /// <para>Setting this to <c>0.0</c> disables simplification entirely, but vertices in the exact same position will still be merged. The mesh will also be re-indexed to reduce both the number of vertices and indices.</para>
    /// <para><b>Note:</b> This uses the <a href="https://meshoptimizer.org/">meshoptimizer</a> library under the hood, similar to LOD generation.</para>
    /// </summary>
    public float BakeSimplificationDistance { get => _node.BakeSimplificationDistance; set => _node.BakeSimplificationDistance = value; }
    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="OccluderInstance3D.BakeMask" /> is enabled, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    public bool GetBakeMaskValue(int layerNumber) => _node.GetBakeMaskValue(layerNumber);
    /// <summary>
    /// <para>The occluder resource for this <see cref="OccluderInstance3D" />. You can generate an occluder resource by selecting an <see cref="OccluderInstance3D" /> node then using the <b>Bake Occluders</b> button at the top of the editor.</para>
    /// <para>You can also draw your own 2D occluder polygon by adding a new <see cref="PolygonOccluder3D" /> resource to the <see cref="OccluderInstance3D.Occluder" /> property in the Inspector.</para>
    /// <para>Alternatively, you can select a primitive occluder to use: <see cref="QuadOccluder3D" />, <see cref="BoxOccluder3D" /> or <see cref="SphereOccluder3D" />.</para>
    /// </summary>
    public Occluder3D Occluder { get => _node.Occluder; set => _node.Occluder = value; }
    /// <summary>
    /// <para>Based on <paramref name="value" />, enables or disables the specified layer in the <see cref="OccluderInstance3D.BakeMask" />, given a <paramref name="layerNumber" /> between 1 and 32.</para>
    /// </summary>
    public void SetBakeMaskValue(int layerNumber, bool value) => _node.SetBakeMaskValue(layerNumber, value);

}