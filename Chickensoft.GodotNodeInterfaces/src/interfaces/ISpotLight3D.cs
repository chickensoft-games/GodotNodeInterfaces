namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class SpotLight3DNode : SpotLight3D, ISpotLight3D { }

/// <summary>
/// <para>A Spotlight is a type of <see cref="Light3D" /> node that emits lights in a specific direction, in the shape of a cone. The light is attenuated through the distance. This attenuation can be configured by changing the energy, radius and attenuation parameters of <see cref="Light3D" />.</para>
/// <para><b>Note:</b> When using the Mobile rendering method, only 8 spot lights can be displayed on each mesh resource. Attempting to display more than 8 spot lights on a single mesh resource will result in spot lights flickering in and out as the camera moves. When using the Compatibility rendering method, only 8 spot lights can be displayed on each mesh resource by default, but this can be increased by adjusting <c>ProjectSettings.rendering/limits/opengl/max_lights_per_object</c>.</para>
/// <para><b>Note:</b> When using the Mobile or Compatibility rendering methods, spot lights will only correctly affect meshes whose visibility AABB intersects with the light's AABB. If using a shader to deform the mesh in a way that makes it go outside its AABB, <see cref="GeometryInstance3D.ExtraCullMargin" /> must be increased on the mesh. Otherwise, the light may not be visible on the mesh.</para>
/// </summary>
public interface ISpotLight3D : ILight3D {
    /// <summary>
    /// <para>The spotlight's angle in degrees.</para>
    /// <para><b>Note:</b> <see cref="SpotLight3D.SpotAngle" /> is not affected by <see cref="Node3D.Scale" /> (the light's scale or its parent's scale).</para>
    /// </summary>
    float SpotAngle { get; set; }
    /// <summary>
    /// <para>The spotlight's <i>angular</i> attenuation curve. See also <see cref="SpotLight3D.SpotAttenuation" />.</para>
    /// </summary>
    float SpotAngleAttenuation { get; set; }
    /// <summary>
    /// <para>The spotlight's light energy (drop-off) attenuation curve. A number of presets are available in the <b>Inspector</b> by right-clicking the curve. Zero and negative values are allowed but can produce unusual effects. See also <see cref="SpotLight3D.SpotAngleAttenuation" />.</para>
    /// <para><b>Note:</b> Very high <see cref="SpotLight3D.SpotAttenuation" /> values (typically above 10) can impact performance negatively if the light is made to use a larger <see cref="SpotLight3D.SpotRange" /> to compensate. This is because culling opportunities will become less common and shading costs will be increased (as the light will cover more pixels on screen while resulting in the same amount of brightness). To improve performance, use the lowest <see cref="SpotLight3D.SpotAttenuation" /> value possible for the visuals you're trying to achieve.</para>
    /// </summary>
    float SpotAttenuation { get; set; }
    /// <summary>
    /// <para>The maximal range that can be reached by the spotlight. Note that the effectively lit area may appear to be smaller depending on the <see cref="SpotLight3D.SpotAttenuation" /> in use. No matter the <see cref="SpotLight3D.SpotAttenuation" /> in use, the light will never reach anything outside this range.</para>
    /// <para><b>Note:</b> <see cref="SpotLight3D.SpotRange" /> is not affected by <see cref="Node3D.Scale" /> (the light's scale or its parent's scale).</para>
    /// </summary>
    float SpotRange { get; set; }

}