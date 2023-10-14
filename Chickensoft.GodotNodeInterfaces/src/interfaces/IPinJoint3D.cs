namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>A physics joint that attaches two 3D physics bodies at a single point, allowing them to freely rotate. For example, a <see cref="RigidBody3D" /> can be attached to a <see cref="StaticBody3D" /> to create a pendulum or a seesaw.</para>
/// </summary>
public interface IPinJoint3D : IJoint3D {
    /// <summary>
    /// <para>Sets the value of the specified parameter.</para>
    /// </summary>
    void SetParam(PinJoint3D.Param @param, float value);
    /// <summary>
    /// <para>Returns the value of the specified parameter.</para>
    /// </summary>
    float GetParam(PinJoint3D.Param @param);

}