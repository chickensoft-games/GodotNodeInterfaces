namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>Occludes light cast by a Light2D, casting shadows. The LightOccluder2D must be provided with an <see cref="OccluderPolygon2D" /> in order for the shadow to be computed.</para>
/// </summary>
public class LightOccluder2DAdapter : Node2DAdapter, ILightOccluder2D {
  private readonly LightOccluder2D _node;

  public LightOccluder2DAdapter(LightOccluder2D node) : base(node) { _node = node; }

    /// <summary>
    /// <para>The <see cref="OccluderPolygon2D" /> used to compute the shadow.</para>
    /// </summary>
    public OccluderPolygon2D Occluder { get => _node.Occluder; set => _node.Occluder = value; }
    /// <summary>
    /// <para>The LightOccluder2D's occluder light mask. The LightOccluder2D will cast shadows only from Light2D(s) that have the same light mask(s).</para>
    /// </summary>
    public int OccluderLightMask { get => _node.OccluderLightMask; set => _node.OccluderLightMask = value; }

    public bool SdfCollision { get => _node.SdfCollision; set => _node.SdfCollision = value; }

}