namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>Captures its surroundings as a cubemap, and stores versions of it with increasing levels of blur to simulate different material roughnesses.</para>
/// <para>The <see cref="ReflectionProbe" /> is used to create high-quality reflections at a low performance cost (when <see cref="ReflectionProbe.UpdateMode" /> is <see cref="ReflectionProbe.UpdateModeEnum.Once" />). <see cref="ReflectionProbe" />s can be blended together and with the rest of the scene smoothly. <see cref="ReflectionProbe" />s can also be combined with <see cref="VoxelGI" />, SDFGI (<see cref="Environment.SdfgiEnabled" />) and screen-space reflections (<see cref="Environment.SsrEnabled" />) to get more accurate reflections in specific areas. <see cref="ReflectionProbe" />s render all objects within their <see cref="ReflectionProbe.CullMask" />, so updating them can be quite expensive. It is best to update them once with the important static objects and then leave them as-is.</para>
/// <para><b>Note:</b> Unlike <see cref="VoxelGI" /> and SDFGI, <see cref="ReflectionProbe" />s only source their environment from a <see cref="WorldEnvironment" /> node. If you specify an <see cref="Environment" /> resource within a <see cref="Camera3D" /> node, it will be ignored by the <see cref="ReflectionProbe" />. This can lead to incorrect lighting within the <see cref="ReflectionProbe" />.</para>
/// <para><b>Note:</b> Reflection probes are only supported in the Forward+ and Mobile rendering methods, not Compatibility. When using the Mobile rendering method, only 8 reflection probes can be displayed on each mesh resource. Attempting to display more than 8 reflection probes on a single mesh resource will result in reflection probes flickering in and out as the camera moves.</para>
/// <para><b>Note:</b> When using the Mobile rendering method, reflection probes will only correctly affect meshes whose visibility AABB intersects with the reflection probe's AABB. If using a shader to deform the mesh in a way that makes it go outside its AABB, <see cref="GeometryInstance3D.ExtraCullMargin" /> must be increased on the mesh. Otherwise, the reflection probe may not be visible on the mesh.</para>
/// </summary>
public class ReflectionProbeAdapter : VisualInstance3DAdapter, IReflectionProbe {
  private readonly ReflectionProbe _node;

  public ReflectionProbeAdapter(Node node) : base(node) {
    if (node is not ReflectionProbe typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a ReflectionProbe"
      );
    }
    _node = typedNode;
  }

    /// <summary>
    /// <para>The custom ambient color to use within the <see cref="ReflectionProbe" />'s box defined by its <see cref="ReflectionProbe.Size" />. Only effective if <see cref="ReflectionProbe.AmbientMode" /> is <see cref="ReflectionProbe.AmbientModeEnum.Color" />.</para>
    /// </summary>
    public Color AmbientColor { get => _node.AmbientColor; set => _node.AmbientColor = value; }
    /// <summary>
    /// <para>The custom ambient color energy to use within the <see cref="ReflectionProbe" />'s box defined by its <see cref="ReflectionProbe.Size" />. Only effective if <see cref="ReflectionProbe.AmbientMode" /> is <see cref="ReflectionProbe.AmbientModeEnum.Color" />.</para>
    /// </summary>
    public float AmbientColorEnergy { get => _node.AmbientColorEnergy; set => _node.AmbientColorEnergy = value; }
    /// <summary>
    /// <para>The ambient color to use within the <see cref="ReflectionProbe" />'s box defined by its <see cref="ReflectionProbe.Size" />. The ambient color will smoothly blend with other <see cref="ReflectionProbe" />s and the rest of the scene (outside the <see cref="ReflectionProbe" />'s box defined by its <see cref="ReflectionProbe.Size" />).</para>
    /// </summary>
    public ReflectionProbe.AmbientModeEnum AmbientMode { get => _node.AmbientMode; set => _node.AmbientMode = value; }
    /// <summary>
    /// <para>If <c>true</c>, enables box projection. This makes reflections look more correct in rectangle-shaped rooms by offsetting the reflection center depending on the camera's location.</para>
    /// <para><b>Note:</b> To better fit rectangle-shaped rooms that are not aligned to the grid, you can rotate the <see cref="ReflectionProbe" /> node.</para>
    /// </summary>
    public bool BoxProjection { get => _node.BoxProjection; set => _node.BoxProjection = value; }
    /// <summary>
    /// <para>Sets the cull mask which determines what objects are drawn by this probe. Every <see cref="VisualInstance3D" /> with a layer included in this cull mask will be rendered by the probe. To improve performance, it is best to only include large objects which are likely to take up a lot of space in the reflection.</para>
    /// </summary>
    public uint CullMask { get => _node.CullMask; set => _node.CullMask = value; }
    /// <summary>
    /// <para>If <c>true</c>, computes shadows in the reflection probe. This makes the reflection probe slower to render; you may want to disable this if using the <see cref="ReflectionProbe.UpdateModeEnum.Always" /> <see cref="ReflectionProbe.UpdateMode" />.</para>
    /// </summary>
    public bool EnableShadows { get => _node.EnableShadows; set => _node.EnableShadows = value; }
    /// <summary>
    /// <para>Defines the reflection intensity. Intensity modulates the strength of the reflection.</para>
    /// </summary>
    public float Intensity { get => _node.Intensity; set => _node.Intensity = value; }
    /// <summary>
    /// <para>If <c>true</c>, reflections will ignore sky contribution.</para>
    /// </summary>
    public bool Interior { get => _node.Interior; set => _node.Interior = value; }
    /// <summary>
    /// <para>The maximum distance away from the <see cref="ReflectionProbe" /> an object can be before it is culled. Decrease this to improve performance, especially when using the <see cref="ReflectionProbe.UpdateModeEnum.Always" /> <see cref="ReflectionProbe.UpdateMode" />.</para>
    /// <para><b>Note:</b> The maximum reflection distance is always at least equal to the probe's extents. This means that decreasing <see cref="ReflectionProbe.MaxDistance" /> will not always cull objects from reflections, especially if the reflection probe's box defined by its <see cref="ReflectionProbe.Size" /> is already large.</para>
    /// </summary>
    public float MaxDistance { get => _node.MaxDistance; set => _node.MaxDistance = value; }
    /// <summary>
    /// <para>The automatic LOD bias to use for meshes rendered within the <see cref="ReflectionProbe" /> (this is analog to <see cref="Viewport.MeshLodThreshold" />). Higher values will use less detailed versions of meshes that have LOD variations generated. If set to <c>0.0</c>, automatic LOD is disabled. Increase <see cref="ReflectionProbe.MeshLodThreshold" /> to improve performance at the cost of geometry detail, especially when using the <see cref="ReflectionProbe.UpdateModeEnum.Always" /> <see cref="ReflectionProbe.UpdateMode" />.</para>
    /// <para><b>Note:</b> <see cref="ReflectionProbe.MeshLodThreshold" /> does not affect <see cref="GeometryInstance3D" /> visibility ranges (also known as "manual" LOD or hierarchical LOD).</para>
    /// </summary>
    public float MeshLodThreshold { get => _node.MeshLodThreshold; set => _node.MeshLodThreshold = value; }
    /// <summary>
    /// <para>Sets the origin offset to be used when this <see cref="ReflectionProbe" /> is in <see cref="ReflectionProbe.BoxProjection" /> mode. This can be set to a non-zero value to ensure a reflection fits a rectangle-shaped room, while reducing the number of objects that "get in the way" of the reflection.</para>
    /// </summary>
    public Vector3 OriginOffset { get => _node.OriginOffset; set => _node.OriginOffset = value; }
    /// <summary>
    /// <para>The size of the reflection probe. The larger the size, the more space covered by the probe, which will lower the perceived resolution. It is best to keep the size only as large as you need it.</para>
    /// <para><b>Note:</b> To better fit areas that are not aligned to the grid, you can rotate the <see cref="ReflectionProbe" /> node.</para>
    /// </summary>
    public Vector3 Size { get => _node.Size; set => _node.Size = value; }
    /// <summary>
    /// <para>Sets how frequently the <see cref="ReflectionProbe" /> is updated. Can be <see cref="ReflectionProbe.UpdateModeEnum.Once" /> or <see cref="ReflectionProbe.UpdateModeEnum.Always" />.</para>
    /// </summary>
    public ReflectionProbe.UpdateModeEnum UpdateMode { get => _node.UpdateMode; set => _node.UpdateMode = value; }

}