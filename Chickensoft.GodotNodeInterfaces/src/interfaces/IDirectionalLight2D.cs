namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class DirectionalLight2DNode : DirectionalLight2D, IDirectionalLight2D { }

/// <summary>
/// <para>A directional light is a type of <see cref="Light2D" /> node that models an infinite number of parallel rays covering the entire scene. It is used for lights with strong intensity that are located far away from the scene (for example: to model sunlight or moonlight).</para>
/// <para><b>Note:</b> <see cref="DirectionalLight2D" /> does not support light cull masks (but it supports shadow cull masks). It will always light up 2D nodes, regardless of the 2D node's <see cref="CanvasItem.LightMask" />.</para>
/// </summary>
public interface IDirectionalLight2D : ILight2D {
    /// <summary>
    /// <para>The height of the light. Used with 2D normal mapping. Ranges from 0 (parallel to the plane) to 1 (perpendicular to the plane).</para>
    /// </summary>
    float Height { get; set; }
    /// <summary>
    /// <para>The maximum distance from the camera center objects can be before their shadows are culled (in pixels). Decreasing this value can prevent objects located outside the camera from casting shadows (while also improving performance). <see cref="Camera2D.Zoom" /> is not taken into account by <see cref="DirectionalLight2D.MaxDistance" />, which means that at higher zoom values, shadows will appear to fade out sooner when zooming onto a given point.</para>
    /// </summary>
    float MaxDistance { get; set; }

}