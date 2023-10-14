 namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A directional light is a type of <see cref="Light2D" /> node that models an infinite number of parallel rays covering the entire scene. It is used for lights with strong intensity that are located far away from the scene (for example: to model sunlight or moonlight).</para>
/// <para><b>Note:</b> <see cref="DirectionalLight2D" /> does not support light cull masks (but it supports shadow cull masks). It will always light up 2D nodes, regardless of the 2D node's <see cref="CanvasItem.LightMask" />.</para>
/// </summary>
public class DirectionalLight2DAdapter : DirectionalLight2D, IDirectionalLight2D {
  private readonly DirectionalLight2D _node;

  public DirectionalLight2DAdapter(DirectionalLight2D node) => _node = node;
    /// <summary>
    /// <para>The height of the light. Used with 2D normal mapping. Ranges from 0 (parallel to the plane) to 1 (perpendicular to the plane).</para>
    /// </summary>
    public float Height { get => _node.Height; set => _node.Height = value; }
    /// <summary>
    /// <para>The maximum distance from the camera center objects can be before their shadows are culled (in pixels). Decreasing this value can prevent objects located outside the camera from casting shadows (while also improving performance). <see cref="Camera2D.Zoom" /> is not taken into account by <see cref="DirectionalLight2D.MaxDistance" />, which means that at higher zoom values, shadows will appear to fade out sooner when zooming onto a given point.</para>
    /// </summary>
    public float MaxDistance { get => _node.MaxDistance; set => _node.MaxDistance = value; }

}