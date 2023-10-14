 namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>The <see cref="Generic6DofJoint3D" /> (6 Degrees Of Freedom) joint allows for implementing custom types of joints by locking the rotation and translation of certain axes.</para>
/// <para>The first 3 DOF represent the linear motion of the physics bodies and the last 3 DOF represent the angular motion of the physics bodies. Each axis can be either locked, or limited.</para>
/// </summary>
public class Generic6DofJoint3DAdapter : Generic6DofJoint3D, IGeneric6DofJoint3D {
  private readonly Generic6DofJoint3D _node;

  public Generic6DofJoint3DAdapter(Generic6DofJoint3D node) => _node = node;

    public bool GetFlagX(Generic6DofJoint3D.Flag flag) => _node.GetFlagX(flag);

    public bool GetFlagY(Generic6DofJoint3D.Flag flag) => _node.GetFlagY(flag);

    public bool GetFlagZ(Generic6DofJoint3D.Flag flag) => _node.GetFlagZ(flag);

    public float GetParamX(Generic6DofJoint3D.Param @param) => _node.GetParamX(@param);

    public float GetParamY(Generic6DofJoint3D.Param @param) => _node.GetParamY(@param);

    public float GetParamZ(Generic6DofJoint3D.Param @param) => _node.GetParamZ(@param);

    public void SetFlagX(Generic6DofJoint3D.Flag flag, bool value) => _node.SetFlagX(flag, value);

    public void SetFlagY(Generic6DofJoint3D.Flag flag, bool value) => _node.SetFlagY(flag, value);

    public void SetFlagZ(Generic6DofJoint3D.Flag flag, bool value) => _node.SetFlagZ(flag, value);

    public void SetParamX(Generic6DofJoint3D.Param @param, float value) => _node.SetParamX(@param, value);

    public void SetParamY(Generic6DofJoint3D.Param @param, float value) => _node.SetParamY(@param, value);

    public void SetParamZ(Generic6DofJoint3D.Param @param, float value) => _node.SetParamZ(@param, value);

}