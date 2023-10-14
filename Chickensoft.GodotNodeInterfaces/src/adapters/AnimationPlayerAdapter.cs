namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>An animation player is used for general-purpose playback of animations. It contains a dictionary of <see cref="AnimationLibrary" /> resources and custom blend times between animation transitions.</para>
/// <para>Some methods and properties use a single key to reference an animation directly. These keys are formatted as the key for the library, followed by a forward slash, then the key for the animation within the library, for example <c>"movement/run"</c>. If the library's key is an empty string (known as the default library), the forward slash is omitted, being the same key used by the library.</para>
/// <para><see cref="AnimationPlayer" /> is better-suited than <see cref="Tween" /> for more complex animations, for example ones with non-trivial timings. It can also be used over <see cref="Tween" /> if the animation track editor is more convenient than doing it in code.</para>
/// <para>Updating the target properties of animations occurs at the process frame.</para>
/// </summary>
public class AnimationPlayerAdapter : AnimationMixerAdapter, IAnimationPlayer {
  private readonly AnimationPlayer _node;

  public AnimationPlayerAdapter(AnimationPlayer node) : base(node) { _node = node; }

    /// <summary>
    /// <para>Returns the key of the animation which is queued to play after the <paramref name="animationFrom" /> animation.</para>
    /// </summary>
    public StringName AnimationGetNext(StringName animationFrom) => _node.AnimationGetNext(animationFrom);
    /// <summary>
    /// <para>Triggers the <paramref name="animationTo" /> animation when the <paramref name="animationFrom" /> animation completes.</para>
    /// </summary>
    public void AnimationSetNext(StringName animationFrom, StringName animationTo) => _node.AnimationSetNext(animationFrom, animationTo);
    /// <summary>
    /// <para>If playing, the current animation's key, otherwise, the animation last played. When set, this changes the animation, but will not play it unless already playing. See also <see cref="AnimationPlayer.CurrentAnimation" />.</para>
    /// </summary>
    public string AssignedAnimation { get => _node.AssignedAnimation; set => _node.AssignedAnimation = value; }
    /// <summary>
    /// <para>The key of the animation to play when the scene loads.</para>
    /// </summary>
    public string Autoplay { get => _node.Autoplay; set => _node.Autoplay = value; }
    /// <summary>
    /// <para>Clears all queued, unplayed animations.</para>
    /// </summary>
    public void ClearQueue() => _node.ClearQueue();
    /// <summary>
    /// <para>The key of the currently playing animation. If no animation is playing, the property's value is an empty string. Changing this value does not restart the animation. See <see cref="AnimationPlayer.Play(Godot.StringName,System.Double,System.Single,System.Boolean)" /> for more information on playing animations.</para>
    /// <para><b>Note:</b> While this property appears in the Inspector, it's not meant to be edited, and it's not saved in the scene. This property is mainly used to get the currently playing animation, and internally for animation playback tracks. For more information, see <see cref="Animation" />.</para>
    /// </summary>
    public string CurrentAnimation { get => _node.CurrentAnimation; set => _node.CurrentAnimation = value; }
    /// <summary>
    /// <para>The length (in seconds) of the currently playing animation.</para>
    /// </summary>
    public double CurrentAnimationLength { get => _node.CurrentAnimationLength; }
    /// <summary>
    /// <para>The position (in seconds) of the currently playing animation.</para>
    /// </summary>
    public double CurrentAnimationPosition { get => _node.CurrentAnimationPosition; }
    /// <summary>
    /// <para>Returns the blend time (in seconds) between two animations, referenced by their keys.</para>
    /// </summary>
    public double GetBlendTime(StringName animationFrom, StringName animationTo) => _node.GetBlendTime(animationFrom, animationTo);
    /// <summary>
    /// <para>For backward compatibility. See <see cref="AnimationMixer.AnimationCallbackModeMethod" />.</para>
    /// </summary>
    public AnimationPlayer.AnimationMethodCallMode GetMethodCallMode() => _node.GetMethodCallMode();
    /// <summary>
    /// <para>Returns the actual playing speed of current animation or <c>0</c> if not playing. This speed is the <see cref="AnimationPlayer.SpeedScale" /> property multiplied by <c>custom_speed</c> argument specified when calling the <see cref="AnimationPlayer.Play(Godot.StringName,System.Double,System.Single,System.Boolean)" /> method.</para>
    /// <para>Returns a negative value if the current animation is playing backwards.</para>
    /// </summary>
    public float GetPlayingSpeed() => _node.GetPlayingSpeed();
    /// <summary>
    /// <para>For backward compatibility. See <see cref="AnimationMixer.AnimationCallbackModeProcess" />.</para>
    /// </summary>
    public AnimationPlayer.AnimationProcessCallback GetProcessCallback() => _node.GetProcessCallback();
    /// <summary>
    /// <para>Returns a list of the animation keys that are currently queued to play.</para>
    /// </summary>
    public string[] GetQueue() => _node.GetQueue();
    /// <summary>
    /// <para>For backward compatibility. See <see cref="AnimationMixer.RootNode" />.</para>
    /// </summary>
    public NodePath GetRoot() => _node.GetRoot();
    /// <summary>
    /// <para>Returns <c>true</c> if an animation is currently playing (even if <see cref="AnimationPlayer.SpeedScale" /> and/or <c>custom_speed</c> are <c>0</c>).</para>
    /// </summary>
    public bool IsPlaying() => _node.IsPlaying();
    /// <inheritdoc cref="P:Godot.AnimationMixer.CallbackModeMethod" />
    public AnimationPlayer.AnimationMethodCallMode MethodCallMode { get => _node.MethodCallMode; set => _node.MethodCallMode = value; }
    /// <summary>
    /// <para>If <c>true</c> and the engine is running in Movie Maker mode (see <see cref="MovieWriter" />), exits the engine with <see cref="SceneTree.Quit(System.Int32)" /> as soon as an animation is done playing in this <see cref="AnimationPlayer" />. A message is printed when the engine quits for this reason.</para>
    /// <para><b>Note:</b> This obeys the same logic as the <see cref="AnimationMixer.AnimationFinished" /> signal, so it will not quit the engine if the animation is set to be looping.</para>
    /// </summary>
    public bool MovieQuitOnFinish { get => _node.MovieQuitOnFinish; set => _node.MovieQuitOnFinish = value; }
    /// <summary>
    /// <para>Pauses the currently playing animation. The <see cref="AnimationPlayer.CurrentAnimationPosition" /> will be kept and calling <see cref="AnimationPlayer.Play(Godot.StringName,System.Double,System.Single,System.Boolean)" /> or <see cref="AnimationPlayer.PlayBackwards(Godot.StringName,System.Double)" /> without arguments or with the same animation name as <see cref="AnimationPlayer.AssignedAnimation" /> will resume the animation.</para>
    /// <para>See also <see cref="AnimationPlayer.Stop(System.Boolean)" />.</para>
    /// </summary>
    public void Pause() => _node.Pause();
    /// <summary>
    /// <para>Plays the animation with key <paramref name="name" />. Custom blend times and speed can be set.</para>
    /// <para>The <paramref name="fromEnd" /> option only affects when switching to a new animation track, or if the same track but at the start or end. It does not affect resuming playback that was paused in the middle of an animation. If <paramref name="customSpeed" /> is negative and <paramref name="fromEnd" /> is <c>true</c>, the animation will play backwards (which is equivalent to calling <see cref="AnimationPlayer.PlayBackwards(Godot.StringName,System.Double)" />).</para>
    /// <para>The <see cref="AnimationPlayer" /> keeps track of its current or last played animation with <see cref="AnimationPlayer.AssignedAnimation" />. If this method is called with that same animation <paramref name="name" />, or with no <paramref name="name" /> parameter, the assigned animation will resume playing if it was paused.</para>
    /// <para><b>Note:</b> The animation will be updated the next time the <see cref="AnimationPlayer" /> is processed. If other variables are updated at the same time this is called, they may be updated too early. To perform the update immediately, call <c>advance(0)</c>.</para>
    /// </summary>
    public void Play(StringName name, double customBlend, float customSpeed, bool fromEnd) => _node.Play(name, customBlend, customSpeed, fromEnd);
    /// <inheritdoc cref="P:Godot.AnimationMixer.Active" />
    public bool PlaybackActive { get => _node.PlaybackActive; set => _node.PlaybackActive = value; }
    /// <summary>
    /// <para>The default time in which to blend animations. Ranges from 0 to 4096 with 0.01 precision.</para>
    /// </summary>
    public double PlaybackDefaultBlendTime { get => _node.PlaybackDefaultBlendTime; set => _node.PlaybackDefaultBlendTime = value; }
    /// <inheritdoc cref="P:Godot.AnimationMixer.CallbackModeProcess" />
    public AnimationPlayer.AnimationProcessCallback PlaybackProcessMode { get => _node.PlaybackProcessMode; set => _node.PlaybackProcessMode = value; }
    /// <summary>
    /// <para>Plays the animation with key <paramref name="name" /> in reverse.</para>
    /// <para>This method is a shorthand for <see cref="AnimationPlayer.Play(Godot.StringName,System.Double,System.Single,System.Boolean)" /> with <c>custom_speed = -1.0</c> and <c>from_end = true</c>, so see its description for more information.</para>
    /// </summary>
    public void PlayBackwards(StringName name, double customBlend) => _node.PlayBackwards(name, customBlend);
    /// <summary>
    /// <para>Queues an animation for playback once the current one is done.</para>
    /// <para><b>Note:</b> If a looped animation is currently playing, the queued animation will never play unless the looped animation is stopped somehow.</para>
    /// </summary>
    public void Queue(StringName name) => _node.Queue(name);
    /// <summary>
    /// <para>Seeks the animation to the <paramref name="seconds" /> point in time (in seconds). If <paramref name="update" /> is <c>true</c>, the animation updates too, otherwise it updates at process time. Events between the current frame and <paramref name="seconds" /> are skipped.</para>
    /// <para>If <paramref name="updateOnly" /> is true, the method / audio / animation playback tracks will not be processed.</para>
    /// <para><b>Note:</b> Seeking to the end of the animation doesn't emit <see cref="AnimationMixer.AnimationFinished" />. If you want to skip animation and emit the signal, use <see cref="AnimationMixer.Advance(System.Double)" />.</para>
    /// </summary>
    public void Seek(double seconds, bool update, bool updateOnly) => _node.Seek(seconds, update, updateOnly);
    /// <summary>
    /// <para>Seeks the animation to the <paramref name="seconds" /> point in time (in seconds). If <paramref name="update" /> is <c>true</c>, the animation updates too, otherwise it updates at process time. Events between the current frame and <paramref name="seconds" /> are skipped.</para>
    /// <para>If <paramref name="updateOnly" /> is true, the method / audio / animation playback tracks will not be processed.</para>
    /// <para><b>Note:</b> Seeking to the end of the animation doesn't emit <see cref="AnimationMixer.AnimationFinished" />. If you want to skip animation and emit the signal, use <see cref="AnimationMixer.Advance(System.Double)" />.</para>
    /// </summary>
    public void Seek(double seconds, bool update) => _node.Seek(seconds, update);
    /// <summary>
    /// <para>Specifies a blend time (in seconds) between two animations, referenced by their keys.</para>
    /// </summary>
    public void SetBlendTime(StringName animationFrom, StringName animationTo, double sec) => _node.SetBlendTime(animationFrom, animationTo, sec);
    /// <summary>
    /// <para>For backward compatibility. See <see cref="AnimationMixer.AnimationCallbackModeMethod" />.</para>
    /// </summary>
    public void SetMethodCallMode(AnimationPlayer.AnimationMethodCallMode mode) => _node.SetMethodCallMode(mode);
    /// <summary>
    /// <para>For backward compatibility. See <see cref="AnimationMixer.AnimationCallbackModeProcess" />.</para>
    /// </summary>
    public void SetProcessCallback(AnimationPlayer.AnimationProcessCallback mode) => _node.SetProcessCallback(mode);
    /// <summary>
    /// <para>For backward compatibility. See <see cref="AnimationMixer.RootNode" />.</para>
    /// </summary>
    public void SetRoot(NodePath path) => _node.SetRoot(path);
    /// <summary>
    /// <para>The speed scaling ratio. For example, if this value is <c>1</c>, then the animation plays at normal speed. If it's <c>0.5</c>, then it plays at half speed. If it's <c>2</c>, then it plays at double speed.</para>
    /// <para>If set to a negative value, the animation is played in reverse. If set to <c>0</c>, the animation will not advance.</para>
    /// </summary>
    public float SpeedScale { get => _node.SpeedScale; set => _node.SpeedScale = value; }
    /// <summary>
    /// <para>Stops the currently playing animation. The animation position is reset to <c>0</c> and the <c>custom_speed</c> is reset to <c>1.0</c>. See also <see cref="AnimationPlayer.Pause" />.</para>
    /// <para>If <paramref name="keepState" /> is <c>true</c>, the animation state is not updated visually.</para>
    /// <para><b>Note:</b> The method / audio / animation playback tracks will not be processed by this method.</para>
    /// </summary>
    public void Stop(bool keepState) => _node.Stop(keepState);

}