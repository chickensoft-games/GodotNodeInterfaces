namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>The <see cref="Generic6DofJoint3D" /> (6 Degrees Of Freedom) joint allows for implementing custom types of joints by locking the rotation and translation of certain axes.</para>
/// <para>The first 3 DOF represent the linear motion of the physics bodies and the last 3 DOF represent the angular motion of the physics bodies. Each axis can be either locked, or limited.</para>
/// </summary>
public interface IGeneric6DofJoint3D : IJoint3D {

    void SetParamX(Generic6DofJoint3D.Param @param, float value);

    float GetParamX(Generic6DofJoint3D.Param @param);

    void SetParamY(Generic6DofJoint3D.Param @param, float value);

    float GetParamY(Generic6DofJoint3D.Param @param);

    void SetParamZ(Generic6DofJoint3D.Param @param, float value);

    float GetParamZ(Generic6DofJoint3D.Param @param);

    void SetFlagX(Generic6DofJoint3D.Flag flag, bool value);

    bool GetFlagX(Generic6DofJoint3D.Flag flag);

    void SetFlagY(Generic6DofJoint3D.Flag flag, bool value);

    bool GetFlagY(Generic6DofJoint3D.Flag flag);

    void SetFlagZ(Generic6DofJoint3D.Flag flag, bool value);

    bool GetFlagZ(Generic6DofJoint3D.Flag flag);

}