namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>A node used for advanced animation transitions in an <see cref="AnimationPlayer" />.</para>
/// <para><b>Note:</b> When linked with an <see cref="AnimationPlayer" />, several properties and methods of the corresponding <see cref="AnimationPlayer" /> will not function as expected. Playback and transitions should be handled using only the <see cref="AnimationTree" /> and its constituent <see cref="AnimationNode" />(s). The <see cref="AnimationPlayer" /> node should be used solely for adding, deleting, and editing animations.</para>
/// </summary>
public interface IAnimationTree : IAnimationMixer {
    /// <summary>
    /// <para>For backward compatibility. See <see cref="AnimationMixer.AnimationCallbackModeProcess" />.</para>
    /// </summary>
    void SetProcessCallback(AnimationTree.AnimationProcessCallback mode);
    /// <summary>
    /// <para>For backward compatibility. See <see cref="AnimationMixer.AnimationCallbackModeProcess" />.</para>
    /// </summary>
    AnimationTree.AnimationProcessCallback GetProcessCallback();
    /// <inheritdoc cref="P:Godot.AnimationMixer.CallbackModeProcess" />
    AnimationTree.AnimationProcessCallback ProcessCallback { get; set; }
    /// <summary>
    /// <para>The root animation node of this <see cref="AnimationTree" />. See <see cref="AnimationRootNode" />.</para>
    /// </summary>
    AnimationRootNode TreeRoot { get; set; }
    /// <summary>
    /// <para>The path to the <see cref="Node" /> used to evaluate the <see cref="AnimationNode" /> <see cref="Expression" /> if one is not explicitly specified internally.</para>
    /// </summary>
    NodePath AdvanceExpressionBaseNode { get; set; }
    /// <summary>
    /// <para>The path to the <see cref="AnimationPlayer" /> used for animating.</para>
    /// </summary>
    NodePath AnimPlayer { get; set; }

}