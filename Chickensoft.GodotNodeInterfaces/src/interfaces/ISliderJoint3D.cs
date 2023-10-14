namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class SliderJoint3DNode : SliderJoint3D, ISliderJoint3D { }

/// <summary>
/// <para>A physics joint that restricts the movement of a 3D physics body along an axis relative to another physics body. For example, Body A could be a <see cref="StaticBody3D" /> representing a piston base, while Body B could be a <see cref="RigidBody3D" /> representing the piston head, moving up and down.</para>
/// </summary>
public interface ISliderJoint3D : IJoint3D {

    float GetParam(SliderJoint3D.Param @param);

    void SetParam(SliderJoint3D.Param @param, float value);

}