namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>A physics joint that restricts the movement of a 3D physics body along an axis relative to another physics body. For example, Body A could be a <see cref="StaticBody3D" /> representing a piston base, while Body B could be a <see cref="RigidBody3D" /> representing the piston head, moving up and down.</para>
/// </summary>
public interface ISliderJoint3D : IJoint3D {

    void SetParam(SliderJoint3D.Param @param, float value);

    float GetParam(SliderJoint3D.Param @param);

}