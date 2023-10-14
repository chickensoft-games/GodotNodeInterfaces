namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A node used for advanced animation transitions in an <see cref="AnimationPlayer" />.</para>
/// <para><b>Note:</b> When linked with an <see cref="AnimationPlayer" />, several properties and methods of the corresponding <see cref="AnimationPlayer" /> will not function as expected. Playback and transitions should be handled using only the <see cref="AnimationTree" /> and its constituent <see cref="AnimationNode" />(s). The <see cref="AnimationPlayer" /> node should be used solely for adding, deleting, and editing animations.</para>
/// </summary>
public class AnimationTreeAdapter : AnimationMixerAdapter, IAnimationTree {
  private readonly AnimationTree _node;

  public AnimationTreeAdapter(AnimationTree node) : base(node) { _node = node; }

    /// <summary>
    /// <para>The path to the <see cref="Node" /> used to evaluate the <see cref="AnimationNode" /> <see cref="Expression" /> if one is not explicitly specified internally.</para>
    /// </summary>
    public NodePath AdvanceExpressionBaseNode { get => _node.AdvanceExpressionBaseNode; set => _node.AdvanceExpressionBaseNode = value; }
    /// <summary>
    /// <para>The path to the <see cref="AnimationPlayer" /> used for animating.</para>
    /// </summary>
    public NodePath AnimPlayer { get => _node.AnimPlayer; set => _node.AnimPlayer = value; }
    /// <summary>
    /// <para>For backward compatibility. See <see cref="AnimationMixer.AnimationCallbackModeProcess" />.</para>
    /// </summary>
    public AnimationTree.AnimationProcessCallback GetProcessCallback() => _node.GetProcessCallback();
    /// <inheritdoc cref="P:Godot.AnimationMixer.CallbackModeProcess" />
    public AnimationTree.AnimationProcessCallback ProcessCallback { get => _node.ProcessCallback; set => _node.ProcessCallback = value; }
    /// <summary>
    /// <para>For backward compatibility. See <see cref="AnimationMixer.AnimationCallbackModeProcess" />.</para>
    /// </summary>
    public void SetProcessCallback(AnimationTree.AnimationProcessCallback mode) => _node.SetProcessCallback(mode);
    /// <summary>
    /// <para>The root animation node of this <see cref="AnimationTree" />. See <see cref="AnimationRootNode" />.</para>
    /// </summary>
    public AnimationRootNode TreeRoot { get => _node.TreeRoot; set => _node.TreeRoot = value; }

}