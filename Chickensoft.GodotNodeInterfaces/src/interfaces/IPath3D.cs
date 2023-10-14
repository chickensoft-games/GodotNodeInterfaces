namespace Chickensoft.GodotNodeInterfaces;

using Godot;


/// <summary>
/// <para>Can have <see cref="PathFollow3D" /> child nodes moving along the <see cref="Curve3D" />. See <see cref="PathFollow3D" /> for more information on the usage.</para>
/// <para>Note that the path is considered as relative to the moved nodes (children of <see cref="PathFollow3D" />). As such, the curve should usually start with a zero vector <c>(0, 0, 0)</c>.</para>
/// </summary>
public interface IPath3D : INode3D {
    /// <summary>
    /// <para>A <see cref="Curve3D" /> describing the path.</para>
    /// </summary>
    Curve3D Curve { get; set; }

}