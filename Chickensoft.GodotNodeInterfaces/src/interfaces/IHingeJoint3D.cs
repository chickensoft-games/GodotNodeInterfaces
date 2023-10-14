namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class HingeJoint3DNode : HingeJoint3D, IHingeJoint3D { }

/// <summary>
/// <para>A physics joint that restricts the rotation of a 3D physics body around an axis relative to another physics body. For example, Body A can be a <see cref="StaticBody3D" /> representing a door hinge that a <see cref="RigidBody3D" /> rotates around.</para>
/// </summary>
public interface IHingeJoint3D : IJoint3D {
    /// <summary>
    /// <para>Returns the value of the specified flag.</para>
    /// </summary>
    bool GetFlag(HingeJoint3D.Flag flag);
    /// <summary>
    /// <para>Returns the value of the specified parameter.</para>
    /// </summary>
    float GetParam(HingeJoint3D.Param @param);
    /// <summary>
    /// <para>If <c>true</c>, enables the specified flag.</para>
    /// </summary>
    void SetFlag(HingeJoint3D.Flag flag, bool enabled);
    /// <summary>
    /// <para>Sets the value of the specified parameter.</para>
    /// </summary>
    void SetParam(HingeJoint3D.Param @param, float value);

}