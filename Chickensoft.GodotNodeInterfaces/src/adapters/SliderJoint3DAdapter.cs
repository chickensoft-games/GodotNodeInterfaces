namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A physics joint that restricts the movement of a 3D physics body along an axis relative to another physics body. For example, Body A could be a <see cref="StaticBody3D" /> representing a piston base, while Body B could be a <see cref="RigidBody3D" /> representing the piston head, moving up and down.</para>
/// </summary>
public class SliderJoint3DAdapter : SliderJoint3D, ISliderJoint3D {
  private readonly SliderJoint3D _node;

  public SliderJoint3DAdapter(SliderJoint3D node) => _node = node;

    public float GetParam(SliderJoint3D.Param @param) => _node.GetParam(@param);

    public void SetParam(SliderJoint3D.Param @param, float value) => _node.SetParam(@param, value);

}