namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class LightOccluder2DNode : LightOccluder2D, ILightOccluder2D { }

/// <summary>
/// <para>Occludes light cast by a Light2D, casting shadows. The LightOccluder2D must be provided with an <see cref="OccluderPolygon2D" /> in order for the shadow to be computed.</para>
/// </summary>
public interface ILightOccluder2D : INode2D {
    /// <summary>
    /// <para>The <see cref="OccluderPolygon2D" /> used to compute the shadow.</para>
    /// </summary>
    OccluderPolygon2D Occluder { get; set; }
    /// <summary>
    /// <para>The LightOccluder2D's occluder light mask. The LightOccluder2D will cast shadows only from Light2D(s) that have the same light mask(s).</para>
    /// </summary>
    int OccluderLightMask { get; set; }

    bool SdfCollision { get; set; }

}