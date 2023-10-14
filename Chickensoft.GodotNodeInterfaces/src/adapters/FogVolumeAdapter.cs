namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para><see cref="FogVolume" />s are used to add localized fog into the global volumetric fog effect. <see cref="FogVolume" />s can also remove volumetric fog from specific areas if using a <see cref="FogMaterial" /> with a negative <see cref="FogMaterial.Density" />.</para>
/// <para>Performance of <see cref="FogVolume" />s is directly related to their relative size on the screen and the complexity of their attached <see cref="FogMaterial" />. It is best to keep <see cref="FogVolume" />s relatively small and simple where possible.</para>
/// <para><b>Note:</b> <see cref="FogVolume" />s only have a visible effect if <see cref="Environment.VolumetricFogEnabled" /> is <c>true</c>. If you don't want fog to be globally visible (but only within <see cref="FogVolume" /> nodes), set <see cref="Environment.VolumetricFogDensity" /> to <c>0.0</c>.</para>
/// </summary>
public class FogVolumeAdapter : VisualInstance3DAdapter, IFogVolume {
  private readonly FogVolume _node;

  public FogVolumeAdapter(FogVolume node) : base(node) { _node = node; }

    /// <summary>
    /// <para>The <see cref="Material" /> used by the <see cref="FogVolume" />. Can be either a built-in <see cref="FogMaterial" /> or a custom <see cref="ShaderMaterial" />.</para>
    /// </summary>
    public Material Material { get => _node.Material; set => _node.Material = value; }
    /// <summary>
    /// <para>The shape of the <see cref="FogVolume" />. This can be set to either <see cref="RenderingServer.FogVolumeShape.Ellipsoid" />, <see cref="RenderingServer.FogVolumeShape.Cone" />, <see cref="RenderingServer.FogVolumeShape.Cylinder" />, <see cref="RenderingServer.FogVolumeShape.Box" /> or <see cref="RenderingServer.FogVolumeShape.World" />.</para>
    /// </summary>
    public RenderingServer.FogVolumeShape Shape { get => _node.Shape; set => _node.Shape = value; }
    /// <summary>
    /// <para>The size of the <see cref="FogVolume" /> when <see cref="FogVolume.Shape" /> is <see cref="RenderingServer.FogVolumeShape.Ellipsoid" />, <see cref="RenderingServer.FogVolumeShape.Cone" />, <see cref="RenderingServer.FogVolumeShape.Cylinder" /> or <see cref="RenderingServer.FogVolumeShape.Box" />.</para>
    /// <para><b>Note:</b> Thin fog volumes may appear to flicker when the camera moves or rotates. This can be alleviated by increasing <c>ProjectSettings.rendering/environment/volumetric_fog/volume_depth</c> (at a performance cost) or by decreasing <see cref="Environment.VolumetricFogLength" /> (at no performance cost, but at the cost of lower fog range). Alternatively, the <see cref="FogVolume" /> can be made thicker and use a lower density in the <see cref="FogVolume.Material" />.</para>
    /// <para><b>Note:</b> If <see cref="FogVolume.Shape" /> is <see cref="RenderingServer.FogVolumeShape.Cone" /> or <see cref="RenderingServer.FogVolumeShape.Cylinder" />, the cone/cylinder will be adjusted to fit within the size. Non-uniform scaling of cone/cylinder shapes via the <see cref="FogVolume.Size" /> property is not supported, but you can scale the <see cref="FogVolume" /> node instead.</para>
    /// </summary>
    public Vector3 Size { get => _node.Size; set => _node.Size = value; }

}