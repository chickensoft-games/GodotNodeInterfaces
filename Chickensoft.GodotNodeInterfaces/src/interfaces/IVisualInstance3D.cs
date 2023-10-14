namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>The <see cref="VisualInstance3D" /> is used to connect a resource to a visual representation. All visual 3D nodes inherit from the <see cref="VisualInstance3D" />. In general, you should not access the <see cref="VisualInstance3D" /> properties directly as they are accessed and managed by the nodes that inherit from <see cref="VisualInstance3D" />. <see cref="VisualInstance3D" /> is the node representation of the <see cref="RenderingServer" /> instance.</para>
/// </summary>
public interface IVisualInstance3D : INode3D {

    Aabb _GetAabb();
    /// <summary>
    /// <para>Sets the resource that is instantiated by this <see cref="VisualInstance3D" />, which changes how the engine handles the <see cref="VisualInstance3D" /> under the hood. Equivalent to <see cref="M:Godot.RenderingServer.InstanceSetBase(Godot.Rid,Godot.Rid)" />.</para>
    /// </summary>
    void SetBase(Rid @base);
    /// <summary>
    /// <para>Returns the RID of the resource associated with this <see cref="VisualInstance3D" />. For example, if the Node is a <see cref="MeshInstance3D" />, this will return the RID of the associated <see cref="Mesh" />.</para>
    /// </summary>
    Rid GetBase();
    /// <summary>
    /// <para>Returns the RID of this instance. This RID is the same as the RID returned by <see cref="RenderingServer.InstanceCreate" />. This RID is needed if you want to call <see cref="RenderingServer" /> functions directly on this <see cref="VisualInstance3D" />.</para>
    /// </summary>
    Rid GetInstance();
    /// <summary>
    /// <para>Based on <paramref name="value" />, enables or disables the specified layer in the <see cref="VisualInstance3D.Layers" />, given a <paramref name="layerNumber" /> between 1 and 20.</para>
    /// </summary>
    void SetLayerMaskValue(int layerNumber, bool value);
    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="VisualInstance3D.Layers" /> is enabled, given a <paramref name="layerNumber" /> between 1 and 20.</para>
    /// </summary>
    bool GetLayerMaskValue(int layerNumber);
    /// <summary>
    /// <para>Returns the <see cref="Aabb" /> (also known as the bounding box) for this <see cref="VisualInstance3D" />.</para>
    /// </summary>
    Aabb GetAabb();
    /// <summary>
    /// <para>The render layer(s) this <see cref="VisualInstance3D" /> is drawn on.</para>
    /// <para>This object will only be visible for <see cref="Camera3D" />s whose cull mask includes any of the render layers this <see cref="VisualInstance3D" /> is set to.</para>
    /// <para>For <see cref="Light3D" />s, this can be used to control which <see cref="VisualInstance3D" />s are affected by a specific light. For <see cref="GpuParticles3D" />, this can be used to control which particles are effected by a specific attractor. For <see cref="Decal" />s, this can be used to control which <see cref="VisualInstance3D" />s are affected by a specific decal.</para>
    /// <para>To adjust <see cref="VisualInstance3D.Layers" /> more easily using a script, use <see cref="M:Godot.VisualInstance3D.GetLayerMaskValue(System.Int32)" /> and <see cref="M:Godot.VisualInstance3D.SetLayerMaskValue(System.Int32,System.Boolean)" />.</para>
    /// <para><b>Note:</b> <see cref="VoxelGI" />, SDFGI and <see cref="LightmapGI" /> will always take all layers into account to determine what contributes to global illumination. If this is an issue, set <see cref="GeometryInstance3D.GIMode" /> to <see cref="GeometryInstance3D.GIModeEnum.Disabled" /> for meshes and <see cref="Light3D.LightBakeMode" /> to <see cref="Light3D.BakeMode.Disabled" /> for lights to exclude them from global illumination.</para>
    /// </summary>
    uint Layers { get; set; }
    /// <summary>
    /// <para>The amount by which the depth of this <see cref="VisualInstance3D" /> will be adjusted when sorting by depth. Uses the same units as the engine (which are typically meters). Adjusting it to a higher value will make the <see cref="VisualInstance3D" /> reliably draw on top of other <see cref="VisualInstance3D" />s that are otherwise positioned at the same spot. To ensure it always draws on top of other objects around it (not positioned at the same spot), set the value to be greater than the distance between this <see cref="VisualInstance3D" /> and the other nearby <see cref="VisualInstance3D" />s.</para>
    /// </summary>
    float SortingOffset { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the object is sorted based on the <see cref="Aabb" /> center. The object will be sorted based on the global position otherwise.</para>
    /// <para>The <see cref="Aabb" /> center based sorting is generally more accurate for 3D models. The position based sorting instead allows to better control the drawing order when working with <see cref="GpuParticles3D" /> and <see cref="CpuParticles3D" />.</para>
    /// </summary>
    bool SortingUseAabbCenter { get; set; }

}