namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para>Can have <see cref="PathFollow2D" /> child nodes moving along the <see cref="Curve2D" />. See <see cref="PathFollow2D" /> for more information on usage.</para>
/// <para><b>Note:</b> The path is considered as relative to the moved nodes (children of <see cref="PathFollow2D" />). As such, the curve should usually start with a zero vector (<c>(0, 0)</c>).</para>
/// </summary>
public class Path2DAdapter : Node2DAdapter, IPath2D {
  private readonly Path2D _node;

  public Path2DAdapter(Path2D node) : base(node) { _node = node; }

    /// <summary>
    /// <para>A <see cref="Curve2D" /> describing the path.</para>
    /// </summary>
    public Curve2D Curve { get => _node.Curve; set => _node.Curve = value; }

}