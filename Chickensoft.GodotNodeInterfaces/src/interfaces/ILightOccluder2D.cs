namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>Occludes light cast by a Light2D, casting shadows. The LightOccluder2D must be provided with an <see cref="OccluderPolygon2D" /> in order for the shadow to be computed.</para>
/// </summary>
public interface ILightOccluder2D : INode2D {
    /// <summary>
    /// <para>The <see cref="OccluderPolygon2D" /> used to compute the shadow.</para>
    /// </summary>
    OccluderPolygon2D Occluder { get; set; }

    bool SdfCollision { get; set; }
    /// <summary>
    /// <para>The LightOccluder2D's occluder light mask. The LightOccluder2D will cast shadows only from Light2D(s) that have the same light mask(s).</para>
    /// </summary>
    int OccluderLightMask { get; set; }

}