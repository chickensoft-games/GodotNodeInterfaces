namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A physics joint that attaches two 3D physics bodies at a single point, allowing them to freely rotate. For example, a <see cref="RigidBody3D" /> can be attached to a <see cref="StaticBody3D" /> to create a pendulum or a seesaw.</para>
/// </summary>
public class PinJoint3DAdapter : PinJoint3D, IPinJoint3D {
  private readonly PinJoint3D _node;

  public PinJoint3DAdapter(PinJoint3D node) => _node = node;
    /// <summary>
    /// <para>Returns the value of the specified parameter.</para>
    /// </summary>
    public float GetParam(PinJoint3D.Param @param) => _node.GetParam(@param);
    /// <summary>
    /// <para>Sets the value of the specified parameter.</para>
    /// </summary>
    public void SetParam(PinJoint3D.Param @param, float value) => _node.SetParam(@param, value);

}