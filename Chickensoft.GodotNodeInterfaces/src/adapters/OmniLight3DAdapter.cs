namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>An Omnidirectional light is a type of <see cref="Light3D" /> that emits light in all directions. The light is attenuated by distance and this attenuation can be configured by changing its energy, radius, and attenuation parameters.</para>
/// <para><b>Note:</b> When using the Mobile rendering method, only 8 omni lights can be displayed on each mesh resource. Attempting to display more than 8 omni lights on a single mesh resource will result in omni lights flickering in and out as the camera moves. When using the Compatibility rendering method, only 8 omni lights can be displayed on each mesh resource by default, but this can be increased by adjusting <c>ProjectSettings.rendering/limits/opengl/max_lights_per_object</c>.</para>
/// <para><b>Note:</b> When using the Mobile or Compatibility rendering methods, omni lights will only correctly affect meshes whose visibility AABB intersects with the light's AABB. If using a shader to deform the mesh in a way that makes it go outside its AABB, <see cref="GeometryInstance3D.ExtraCullMargin" /> must be increased on the mesh. Otherwise, the light may not be visible on the mesh.</para>
/// </summary>
public class OmniLight3DAdapter : Light3DAdapter, IOmniLight3D {
  private readonly OmniLight3D _node;

  public OmniLight3DAdapter(Node node) : base(node) {
    if (node is not OmniLight3D typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a OmniLight3D"
      );
    }
    _node = typedNode;
  }

    /// <summary>
    /// <para>The light's attenuation (drop-off) curve. A number of presets are available in the <b>Inspector</b> by right-clicking the curve. Zero and negative values are allowed but can produce unusual effects.</para>
    /// <para><b>Note:</b> Very high <see cref="OmniLight3D.OmniAttenuation" /> values (typically above 10) can impact performance negatively if the light is made to use a larger <see cref="OmniLight3D.OmniRange" /> to compensate. This is because culling opportunities will become less common and shading costs will be increased (as the light will cover more pixels on screen while resulting in the same amount of brightness). To improve performance, use the lowest <see cref="OmniLight3D.OmniAttenuation" /> value possible for the visuals you're trying to achieve.</para>
    /// </summary>
    public float OmniAttenuation { get => _node.OmniAttenuation; set => _node.OmniAttenuation = value; }
    /// <summary>
    /// <para>The light's radius. Note that the effectively lit area may appear to be smaller depending on the <see cref="OmniLight3D.OmniAttenuation" /> in use. No matter the <see cref="OmniLight3D.OmniAttenuation" /> in use, the light will never reach anything outside this radius.</para>
    /// <para><b>Note:</b> <see cref="OmniLight3D.OmniRange" /> is not affected by <see cref="Node3D.Scale" /> (the light's scale or its parent's scale).</para>
    /// </summary>
    public float OmniRange { get => _node.OmniRange; set => _node.OmniRange = value; }
    /// <summary>
    /// <para>See <see cref="OmniLight3D.ShadowMode" />.</para>
    /// </summary>
    public OmniLight3D.ShadowMode OmniShadowMode { get => _node.OmniShadowMode; set => _node.OmniShadowMode = value; }

}