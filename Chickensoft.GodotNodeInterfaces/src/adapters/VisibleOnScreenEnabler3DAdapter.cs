namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para>The VisibleOnScreenEnabler3D will disable <see cref="RigidBody3D" /> and <see cref="AnimationPlayer" /> nodes when they are not visible. It will only affect other nodes within the same scene as the VisibleOnScreenEnabler3D itself.</para>
/// <para>If you just want to receive notifications, use <see cref="VisibleOnScreenNotifier3D" /> instead.</para>
/// <para><b>Note:</b> VisibleOnScreenEnabler3D uses an approximate heuristic for performance reasons. It doesn't take walls and other occlusion into account. The heuristic is an implementation detail and may change in future versions. If you need precise visibility checking, use another method such as adding an <see cref="Area3D" /> node as a child of a <see cref="Camera3D" /> node and/or <c>Vector3.dot</c>.</para>
/// <para><b>Note:</b> VisibleOnScreenEnabler3D will not affect nodes added after scene initialization.</para>
/// </summary>
public class VisibleOnScreenEnabler3DAdapter : VisibleOnScreenNotifier3DAdapter, IVisibleOnScreenEnabler3D {
  private readonly VisibleOnScreenEnabler3D _node;

  public VisibleOnScreenEnabler3DAdapter(Node node) : base(node) {
    if (node is not VisibleOnScreenEnabler3D typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a VisibleOnScreenEnabler3D"
      );
    }
    _node = typedNode;
  }


    public VisibleOnScreenEnabler3D.EnableModeEnum EnableMode { get => _node.EnableMode; set => _node.EnableMode = value; }

    public NodePath EnableNodePath { get => _node.EnableNodePath; set => _node.EnableNodePath = value; }

}