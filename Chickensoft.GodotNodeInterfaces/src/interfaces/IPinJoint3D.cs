namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class PinJoint3DNode : PinJoint3D, IPinJoint3D { }

/// <summary>
/// <para>A physics joint that attaches two 3D physics bodies at a single point, allowing them to freely rotate. For example, a <see cref="RigidBody3D" /> can be attached to a <see cref="StaticBody3D" /> to create a pendulum or a seesaw.</para>
/// </summary>
public interface IPinJoint3D : IJoint3D {
    /// <summary>
    /// <para>Returns the value of the specified parameter.</para>
    /// </summary>
    float GetParam(PinJoint3D.Param @param);
    /// <summary>
    /// <para>Sets the value of the specified parameter.</para>
    /// </summary>
    void SetParam(PinJoint3D.Param @param, float value);

}