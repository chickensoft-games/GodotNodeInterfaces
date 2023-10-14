 namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A physics joint that restricts the rotation of a 3D physics body around an axis relative to another physics body. For example, Body A can be a <see cref="StaticBody3D" /> representing a door hinge that a <see cref="RigidBody3D" /> rotates around.</para>
/// </summary>
public class HingeJoint3DAdapter : HingeJoint3D, IHingeJoint3D {
  private readonly HingeJoint3D _node;

  public HingeJoint3DAdapter(HingeJoint3D node) => _node = node;
    /// <summary>
    /// <para>Returns the value of the specified flag.</para>
    /// </summary>
    public bool GetFlag(HingeJoint3D.Flag flag) => _node.GetFlag(flag);
    /// <summary>
    /// <para>Returns the value of the specified parameter.</para>
    /// </summary>
    public float GetParam(HingeJoint3D.Param @param) => _node.GetParam(@param);
    /// <summary>
    /// <para>If <c>true</c>, enables the specified flag.</para>
    /// </summary>
    public void SetFlag(HingeJoint3D.Flag flag, bool enabled) => _node.SetFlag(flag, enabled);
    /// <summary>
    /// <para>Sets the value of the specified parameter.</para>
    /// </summary>
    public void SetParam(HingeJoint3D.Param @param, float value) => _node.SetParam(@param, value);

}