namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class Generic6DofJoint3DNode : Generic6DofJoint3D, IGeneric6DofJoint3D { }

/// <summary>
/// <para>The <see cref="Generic6DofJoint3D" /> (6 Degrees Of Freedom) joint allows for implementing custom types of joints by locking the rotation and translation of certain axes.</para>
/// <para>The first 3 DOF represent the linear motion of the physics bodies and the last 3 DOF represent the angular motion of the physics bodies. Each axis can be either locked, or limited.</para>
/// </summary>
public interface IGeneric6DofJoint3D : IJoint3D {

    bool GetFlagX(Generic6DofJoint3D.Flag flag);

    bool GetFlagY(Generic6DofJoint3D.Flag flag);

    bool GetFlagZ(Generic6DofJoint3D.Flag flag);

    float GetParamX(Generic6DofJoint3D.Param @param);

    float GetParamY(Generic6DofJoint3D.Param @param);

    float GetParamZ(Generic6DofJoint3D.Param @param);

    void SetFlagX(Generic6DofJoint3D.Flag flag, bool value);

    void SetFlagY(Generic6DofJoint3D.Flag flag, bool value);

    void SetFlagZ(Generic6DofJoint3D.Flag flag, bool value);

    void SetParamX(Generic6DofJoint3D.Param @param, float value);

    void SetParamY(Generic6DofJoint3D.Param @param, float value);

    void SetParamZ(Generic6DofJoint3D.Param @param, float value);

}