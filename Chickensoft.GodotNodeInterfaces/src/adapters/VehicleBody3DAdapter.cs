namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>This physics body implements all the physics logic needed to simulate a car. It is based on the raycast vehicle system commonly found in physics engines. Aside from a <see cref="CollisionShape3D" /> for the main body of the vehicle, you must also add a <see cref="VehicleWheel3D" /> node for each wheel. You should also add a <see cref="MeshInstance3D" /> to this node for the 3D model of the vehicle, but this model should generally not include meshes for the wheels. You can control the vehicle by using the <see cref="VehicleBody3D.Brake" />, <see cref="VehicleBody3D.EngineForce" />, and <see cref="VehicleBody3D.Steering" /> properties. The position or orientation of this node shouldn't be changed directly.</para>
/// <para><b>Note:</b> The origin point of your VehicleBody3D will determine the center of gravity of your vehicle. To make the vehicle more grounded, the origin point is usually kept low, moving the <see cref="CollisionShape3D" /> and <see cref="MeshInstance3D" /> upwards.</para>
/// <para><b>Note:</b> This class has known issues and isn't designed to provide realistic 3D vehicle physics. If you want advanced vehicle physics, you may have to write your own physics integration using <see cref="CharacterBody3D" /> or <see cref="RigidBody3D" />.</para>
/// </summary>
public class VehicleBody3DAdapter : RigidBody3DAdapter, IVehicleBody3D {
  private readonly VehicleBody3D _node;

  public VehicleBody3DAdapter(Node node) : base(node) {
    if (node is not VehicleBody3D typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a VehicleBody3D"
      );
    }
    _node = typedNode;
  }

    /// <summary>
    /// <para>Slows down the vehicle by applying a braking force. The vehicle is only slowed down if the wheels are in contact with a surface. The force you need to apply to adequately slow down your vehicle depends on the <see cref="RigidBody3D.Mass" /> of the vehicle. For a vehicle with a mass set to 1000, try a value in the 25 - 30 range for hard braking.</para>
    /// </summary>
    public float Brake { get => _node.Brake; set => _node.Brake = value; }
    /// <summary>
    /// <para>Accelerates the vehicle by applying an engine force. The vehicle is only sped up if the wheels that have <see cref="VehicleWheel3D.UseAsTraction" /> set to <c>true</c> and are in contact with a surface. The <see cref="RigidBody3D.Mass" /> of the vehicle has an effect on the acceleration of the vehicle. For a vehicle with a mass set to 1000, try a value in the 25 - 50 range for acceleration.</para>
    /// <para><b>Note:</b> The simulation does not take the effect of gears into account, you will need to add logic for this if you wish to simulate gears.</para>
    /// <para>A negative value will result in the vehicle reversing.</para>
    /// </summary>
    public float EngineForce { get => _node.EngineForce; set => _node.EngineForce = value; }
    /// <summary>
    /// <para>The steering angle for the vehicle. Setting this to a non-zero value will result in the vehicle turning when it's moving. Wheels that have <see cref="VehicleWheel3D.UseAsSteering" /> set to <c>true</c> will automatically be rotated.</para>
    /// <para><b>Note:</b> This property is edited in the inspector in degrees. In code the property is set in radians.</para>
    /// </summary>
    public float Steering { get => _node.Steering; set => _node.Steering = value; }

}