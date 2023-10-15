namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para>Can have <see cref="PathFollow3D" /> child nodes moving along the <see cref="Curve3D" />. See <see cref="PathFollow3D" /> for more information on the usage.</para>
/// <para>Note that the path is considered as relative to the moved nodes (children of <see cref="PathFollow3D" />). As such, the curve should usually start with a zero vector <c>(0, 0, 0)</c>.</para>
/// </summary>
public class Path3DAdapter : Node3DAdapter, IPath3D {
  private readonly Path3D _node;

  public Path3DAdapter(Node node) : base(node) {
    if (node is not Path3D typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a Path3D"
      );
    }
    _node = typedNode;
  }

    /// <summary>
    /// <para>A <see cref="Curve3D" /> describing the path.</para>
    /// </summary>
    public Curve3D Curve { get => _node.Curve; set => _node.Curve = value; }

}