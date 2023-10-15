namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para>Node for back-buffering the currently-displayed screen. The region defined in the <see cref="BackBufferCopy" /> node is buffered with the content of the screen it covers, or the entire screen according to the <see cref="BackBufferCopy.CopyMode" />. It can be accessed in shader scripts using the screen texture (i.e. a uniform sampler with <c>hint_screen_texture</c>).</para>
/// <para><b>Note:</b> Since this node inherits from <see cref="Node2D" /> (and not <see cref="Control" />), anchors and margins won't apply to child <see cref="Control" />-derived nodes. This can be problematic when resizing the window. To avoid this, add <see cref="Control" />-derived nodes as <i>siblings</i> to the <see cref="BackBufferCopy" /> node instead of adding them as children.</para>
/// </summary>
public class BackBufferCopyAdapter : Node2DAdapter, IBackBufferCopy {
  private readonly BackBufferCopy _node;

  public BackBufferCopyAdapter(Node node) : base(node) {
    if (node is not BackBufferCopy typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a BackBufferCopy"
      );
    }
    _node = typedNode;
  }

    /// <summary>
    /// <para>Buffer mode. See <see cref="BackBufferCopy.CopyModeEnum" /> constants.</para>
    /// </summary>
    public BackBufferCopy.CopyModeEnum CopyMode { get => _node.CopyMode; set => _node.CopyMode = value; }
    /// <summary>
    /// <para>The area covered by the <see cref="BackBufferCopy" />. Only used if <see cref="BackBufferCopy.CopyMode" /> is <see cref="BackBufferCopy.CopyModeEnum.Rect" />.</para>
    /// </summary>
    public Rect2 Rect { get => _node.Rect; set => _node.Rect = value; }

}