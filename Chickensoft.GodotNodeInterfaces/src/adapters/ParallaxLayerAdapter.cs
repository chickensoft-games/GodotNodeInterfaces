 namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para>A ParallaxLayer must be the child of a <see cref="ParallaxBackground" /> node. Each ParallaxLayer can be set to move at different speeds relative to the camera movement or the <see cref="ParallaxBackground.ScrollOffset" /> value.</para>
/// <para>This node's children will be affected by its scroll offset.</para>
/// <para><b>Note:</b> Any changes to this node's position and scale made after it enters the scene will be ignored.</para>
/// </summary>
public class ParallaxLayerAdapter : ParallaxLayer, IParallaxLayer {
  private readonly ParallaxLayer _node;

  public ParallaxLayerAdapter(ParallaxLayer node) => _node = node;
    /// <summary>
    /// <para>The ParallaxLayer's <see cref="Texture2D" /> repeating. Useful for creating an infinite scrolling background. If an axis is set to <c>0</c>, the <see cref="Texture2D" /> will not be repeated.</para>
    /// <para>If the length of the viewport axis is bigger than twice the repeated axis size, it will not repeat infinitely, as the parallax layer only draws 2 instances of the texture at any given time.</para>
    /// <para><b>Note:</b> Despite its name, the texture will not be mirrored, it will simply be repeated.</para>
    /// </summary>
    public Vector2 MotionMirroring { get => _node.MotionMirroring; set => _node.MotionMirroring = value; }
    /// <summary>
    /// <para>The ParallaxLayer's offset relative to the parent ParallaxBackground's <see cref="ParallaxBackground.ScrollOffset" />.</para>
    /// </summary>
    public Vector2 MotionOffset { get => _node.MotionOffset; set => _node.MotionOffset = value; }
    /// <summary>
    /// <para>Multiplies the ParallaxLayer's motion. If an axis is set to <c>0</c>, it will not scroll.</para>
    /// </summary>
    public Vector2 MotionScale { get => _node.MotionScale; set => _node.MotionScale = value; }

}