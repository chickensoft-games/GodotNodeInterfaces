namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
using Godot.Collections;


/// <summary>
/// <para>Base class for <see cref="AnimationPlayer" /> and <see cref="AnimationTree" /> to manage animation lists. It also has general properties and methods for playback and blending.</para>
/// <para>After instantiating the playback information data within the extended class, the blending is processed by the <see cref="AnimationMixer" />.</para>
/// </summary>
public interface IAnimationMixer : INode {
    /// <summary>
    /// <para>A virtual function for processing after key getting during playback.</para>
    /// </summary>
    Variant _PostProcessKeyValue(Animation animation, int track, Variant value, GodotObject @object, int objectIdx);
    /// <summary>
    /// <para>If <c>true</c>, the <see cref="AnimationMixer" /> will be processing.</para>
    /// </summary>
    bool Active { get; set; }
    /// <summary>
    /// <para>Adds <paramref name="library" /> to the animation player, under the key <paramref name="name" />.</para>
    /// </summary>
    Error AddAnimationLibrary(StringName name, AnimationLibrary library);
    /// <summary>
    /// <para>Manually advance the animations by the specified time (in seconds).</para>
    /// </summary>
    void Advance(double delta);
    /// <summary>
    /// <para>The number of possible simultaneous sounds for each of the assigned AudioStreamPlayers.</para>
    /// <para>For example, if this value is <c>32</c> and the animation has two audio tracks, the two <see cref="AudioStreamPlayer" />s assigned can play simultaneously up to <c>32</c> voices each.</para>
    /// </summary>
    int AudioMaxPolyphony { get; set; }
    /// <summary>
    /// <para>The call mode to use for Call Method tracks.</para>
    /// </summary>
    AnimationMixer.AnimationCallbackModeMethod CallbackModeMethod { get; set; }
    /// <summary>
    /// <para>The process notification in which to update animations.</para>
    /// </summary>
    AnimationMixer.AnimationCallbackModeProcess CallbackModeProcess { get; set; }
    /// <summary>
    /// <para><see cref="AnimationMixer" /> caches animated nodes. It may not notice if a node disappears; <see cref="AnimationMixer.ClearCaches" /> forces it to update the cache again.</para>
    /// </summary>
    void ClearCaches();
    /// <summary>
    /// <para>If <c>true</c>, the blending uses the deterministic algorithm. The total weight is not normalized and the result is accumulated with an initial value (<c>0</c> or a <c>"RESET"</c> animation if present).</para>
    /// <para>This means that if the total amount of blending is <c>0.0</c>, the result is equal to the <c>"RESET"</c> animation.</para>
    /// <para>If the number of tracks between the blended animations is different, the animation with the missing track is treated as if it had the initial value.</para>
    /// <para>If <c>false</c>, The blend does not use the deterministic algorithm. The total weight is normalized and always <c>1.0</c>. If the number of tracks between the blended animations is different, nothing is done about the animation that is missing a track.</para>
    /// <para><b>Note:</b> In <see cref="AnimationTree" />, the blending with <see cref="AnimationNodeAdd2" />, <see cref="AnimationNodeAdd3" />, <see cref="AnimationNodeSub2" /> or the weight greater than <c>1.0</c> may produce unexpected results.</para>
    /// <para>For example, if <see cref="AnimationNodeAdd2" /> blends two nodes with the amount <c>1.0</c>, then total weight is <c>2.0</c> but it will be normalized to make the total amount <c>1.0</c> and the result will be equal to <see cref="AnimationNodeBlend2" /> with the amount <c>0.5</c>.</para>
    /// </summary>
    bool Deterministic { get; set; }
    /// <summary>
    /// <para>Returns the key of <paramref name="animation" /> or an empty <see cref="StringName" /> if not found.</para>
    /// </summary>
    StringName FindAnimation(Animation animation);
    /// <summary>
    /// <para>Returns the key for the <see cref="AnimationLibrary" /> that contains <paramref name="animation" /> or an empty <see cref="StringName" /> if not found.</para>
    /// </summary>
    StringName FindAnimationLibrary(Animation animation);
    /// <summary>
    /// <para>Returns the <see cref="Animation" /> with the key <paramref name="name" />. If the animation does not exist, <c>null</c> is returned and an error is logged.</para>
    /// </summary>
    Animation GetAnimation(StringName name);
    /// <summary>
    /// <para>Returns the first <see cref="AnimationLibrary" /> with key <paramref name="name" /> or <c>null</c> if not found.</para>
    /// <para>To get the <see cref="AnimationPlayer" />'s global animation library, use <c>get_animation_library("")</c>.</para>
    /// </summary>
    AnimationLibrary GetAnimationLibrary(StringName name);
    /// <summary>
    /// <para>Returns the list of stored library keys.</para>
    /// </summary>
    Godot.Collections.Array<StringName> GetAnimationLibraryList();
    /// <summary>
    /// <para>Returns the list of stored animation keys.</para>
    /// </summary>
    string[] GetAnimationList();
    /// <summary>
    /// <para>Retrieve the motion delta of position with the <see cref="AnimationMixer.RootMotionTrack" /> as a <see cref="Vector3" /> that can be used elsewhere.</para>
    /// <para>If <see cref="AnimationMixer.RootMotionTrack" /> is not a path to a track of type <see cref="Animation.TrackType.Position3D" />, returns <c>Vector3(0, 0, 0)</c>.</para>
    /// <para>See also <see cref="AnimationMixer.RootMotionTrack" /> and <see cref="RootMotionView" />.</para>
    /// <para>The most basic example is applying position to <see cref="CharacterBody3D" />:</para>
    /// <para></para>
    /// <para>By using this in combination with <see cref="AnimationMixer.GetRootMotionPositionAccumulator" />, you can apply the root motion position more correctly to account for the rotation of the node.</para>
    /// <para></para>
    /// </summary>
    Vector3 GetRootMotionPosition();
    /// <summary>
    /// <para>Retrieve the blended value of the position tracks with the <see cref="AnimationMixer.RootMotionTrack" /> as a <see cref="Vector3" /> that can be used elsewhere.</para>
    /// <para>This is useful in cases where you want to respect the initial key values of the animation.</para>
    /// <para>For example, if an animation with only one key <c>Vector3(0, 0, 0)</c> is played in the previous frame and then an animation with only one key <c>Vector3(1, 0, 1)</c> is played in the next frame, the difference can be calculated as follows:</para>
    /// <para></para>
    /// <para>However, if the animation loops, an unintended discrete change may occur, so this is only useful for some simple use cases.</para>
    /// </summary>
    Vector3 GetRootMotionPositionAccumulator();
    /// <summary>
    /// <para>Retrieve the motion delta of rotation with the <see cref="AnimationMixer.RootMotionTrack" /> as a <see cref="Quaternion" /> that can be used elsewhere.</para>
    /// <para>If <see cref="AnimationMixer.RootMotionTrack" /> is not a path to a track of type <see cref="Animation.TrackType.Rotation3D" />, returns <c>Quaternion(0, 0, 0, 1)</c>.</para>
    /// <para>See also <see cref="AnimationMixer.RootMotionTrack" /> and <see cref="RootMotionView" />.</para>
    /// <para>The most basic example is applying rotation to <see cref="CharacterBody3D" />:</para>
    /// <para></para>
    /// </summary>
    Quaternion GetRootMotionRotation();
    /// <summary>
    /// <para>Retrieve the blended value of the rotation tracks with the <see cref="AnimationMixer.RootMotionTrack" /> as a <see cref="Quaternion" /> that can be used elsewhere.</para>
    /// <para>This is necessary to apply the root motion position correctly, taking rotation into account. See also <see cref="AnimationMixer.GetRootMotionPosition" />.</para>
    /// <para>Also, this is useful in cases where you want to respect the initial key values of the animation.</para>
    /// <para>For example, if an animation with only one key <c>Quaternion(0, 0, 0, 1)</c> is played in the previous frame and then an animation with only one key <c>Quaternion(0, 0.707, 0, 0.707)</c> is played in the next frame, the difference can be calculated as follows:</para>
    /// <para></para>
    /// <para>However, if the animation loops, an unintended discrete change may occur, so this is only useful for some simple use cases.</para>
    /// </summary>
    Quaternion GetRootMotionRotationAccumulator();
    /// <summary>
    /// <para>Retrieve the motion delta of scale with the <see cref="AnimationMixer.RootMotionTrack" /> as a <see cref="Vector3" /> that can be used elsewhere.</para>
    /// <para>If <see cref="AnimationMixer.RootMotionTrack" /> is not a path to a track of type <see cref="Animation.TrackType.Scale3D" />, returns <c>Vector3(0, 0, 0)</c>.</para>
    /// <para>See also <see cref="AnimationMixer.RootMotionTrack" /> and <see cref="RootMotionView" />.</para>
    /// <para>The most basic example is applying scale to <see cref="CharacterBody3D" />:</para>
    /// <para></para>
    /// </summary>
    Vector3 GetRootMotionScale();
    /// <summary>
    /// <para>Retrieve the blended value of the scale tracks with the <see cref="AnimationMixer.RootMotionTrack" /> as a <see cref="Vector3" /> that can be used elsewhere.</para>
    /// <para>For example, if an animation with only one key <c>Vector3(1, 1, 1)</c> is played in the previous frame and then an animation with only one key <c>Vector3(2, 2, 2)</c> is played in the next frame, the difference can be calculated as follows:</para>
    /// <para></para>
    /// <para>However, if the animation loops, an unintended discrete change may occur, so this is only useful for some simple use cases.</para>
    /// </summary>
    Vector3 GetRootMotionScaleAccumulator();
    /// <summary>
    /// <para>Returns <c>true</c> if the <see cref="AnimationPlayer" /> stores an <see cref="Animation" /> with key <paramref name="name" />.</para>
    /// </summary>
    bool HasAnimation(StringName name);
    /// <summary>
    /// <para>Returns <c>true</c> if the <see cref="AnimationPlayer" /> stores an <see cref="AnimationLibrary" /> with key <paramref name="name" />.</para>
    /// </summary>
    bool HasAnimationLibrary(StringName name);
    /// <summary>
    /// <para>Removes the <see cref="AnimationLibrary" /> associated with the key <paramref name="name" />.</para>
    /// </summary>
    void RemoveAnimationLibrary(StringName name);
    /// <summary>
    /// <para>Moves the <see cref="AnimationLibrary" /> associated with the key <paramref name="name" /> to the key <paramref name="newname" />.</para>
    /// </summary>
    void RenameAnimationLibrary(StringName name, StringName newname);
    /// <summary>
    /// <para>This is used by the editor. If set to <c>true</c>, the scene will be saved with the effects of the reset animation (the animation with the key <c>"RESET"</c>) applied as if it had been seeked to time 0, with the editor keeping the values that the scene had before saving.</para>
    /// <para>This makes it more convenient to preview and edit animations in the editor, as changes to the scene will not be saved as long as they are set in the reset animation.</para>
    /// </summary>
    bool ResetOnSave { get; set; }
    /// <summary>
    /// <para>The path to the Animation track used for root motion. Paths must be valid scene-tree paths to a node, and must be specified starting from the parent node of the node that will reproduce the animation. To specify a track that controls properties or bones, append its name after the path, separated by <c>":"</c>. For example, <c>"character/skeleton:ankle"</c> or <c>"character/mesh:transform/local"</c>.</para>
    /// <para>If the track has type <see cref="Animation.TrackType.Position3D" />, <see cref="Animation.TrackType.Rotation3D" /> or <see cref="Animation.TrackType.Scale3D" /> the transformation will be canceled visually, and the animation will appear to stay in place. See also <see cref="AnimationMixer.GetRootMotionPosition" />, <see cref="AnimationMixer.GetRootMotionRotation" />, <see cref="AnimationMixer.GetRootMotionScale" /> and <see cref="RootMotionView" />.</para>
    /// </summary>
    NodePath RootMotionTrack { get; set; }
    /// <summary>
    /// <para>The node from which node path references will travel.</para>
    /// </summary>
    NodePath RootNode { get; set; }

}