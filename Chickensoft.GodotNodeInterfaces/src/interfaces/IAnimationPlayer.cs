namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>An animation player is used for general-purpose playback of animations. It contains a dictionary of <see cref="AnimationLibrary" /> resources and custom blend times between animation transitions.</para>
/// <para>Some methods and properties use a single key to reference an animation directly. These keys are formatted as the key for the library, followed by a forward slash, then the key for the animation within the library, for example <c>"movement/run"</c>. If the library's key is an empty string (known as the default library), the forward slash is omitted, being the same key used by the library.</para>
/// <para><see cref="AnimationPlayer" /> is better-suited than <see cref="Tween" /> for more complex animations, for example ones with non-trivial timings. It can also be used over <see cref="Tween" /> if the animation track editor is more convenient than doing it in code.</para>
/// <para>Updating the target properties of animations occurs at the process frame.</para>
/// </summary>
public interface IAnimationPlayer : IAnimationMixer {
    /// <summary>
    /// <para>Triggers the <paramref name="animationTo" /> animation when the <paramref name="animationFrom" /> animation completes.</para>
    /// </summary>
    void AnimationSetNext(StringName animationFrom, StringName animationTo);
    /// <summary>
    /// <para>Returns the key of the animation which is queued to play after the <paramref name="animationFrom" /> animation.</para>
    /// </summary>
    StringName AnimationGetNext(StringName animationFrom);
    /// <summary>
    /// <para>Specifies a blend time (in seconds) between two animations, referenced by their keys.</para>
    /// </summary>
    void SetBlendTime(StringName animationFrom, StringName animationTo, double sec);
    /// <summary>
    /// <para>Returns the blend time (in seconds) between two animations, referenced by their keys.</para>
    /// </summary>
    double GetBlendTime(StringName animationFrom, StringName animationTo);
    /// <summary>
    /// <para>Plays the animation with key <paramref name="name" />. Custom blend times and speed can be set.</para>
    /// <para>The <paramref name="fromEnd" /> option only affects when switching to a new animation track, or if the same track but at the start or end. It does not affect resuming playback that was paused in the middle of an animation. If <paramref name="customSpeed" /> is negative and <paramref name="fromEnd" /> is <c>true</c>, the animation will play backwards (which is equivalent to calling <see cref="M:Godot.AnimationPlayer.PlayBackwards(Godot.StringName,System.Double)" />).</para>
    /// <para>The <see cref="AnimationPlayer" /> keeps track of its current or last played animation with <see cref="AnimationPlayer.AssignedAnimation" />. If this method is called with that same animation <paramref name="name" />, or with no <paramref name="name" /> parameter, the assigned animation will resume playing if it was paused.</para>
    /// <para><b>Note:</b> The animation will be updated the next time the <see cref="AnimationPlayer" /> is processed. If other variables are updated at the same time this is called, they may be updated too early. To perform the update immediately, call <c>advance(0)</c>.</para>
    /// </summary>
    void Play(StringName name, double customBlend, float customSpeed, bool fromEnd);
    /// <summary>
    /// <para>Plays the animation with key <paramref name="name" /> in reverse.</para>
    /// <para>This method is a shorthand for <see cref="M:Godot.AnimationPlayer.Play(Godot.StringName,System.Double,System.Single,System.Boolean)" /> with <c>custom_speed = -1.0</c> and <c>from_end = true</c>, so see its description for more information.</para>
    /// </summary>
    void PlayBackwards(StringName name, double customBlend);
    /// <summary>
    /// <para>Pauses the currently playing animation. The <see cref="AnimationPlayer.CurrentAnimationPosition" /> will be kept and calling <see cref="M:Godot.AnimationPlayer.Play(Godot.StringName,System.Double,System.Single,System.Boolean)" /> or <see cref="M:Godot.AnimationPlayer.PlayBackwards(Godot.StringName,System.Double)" /> without arguments or with the same animation name as <see cref="AnimationPlayer.AssignedAnimation" /> will resume the animation.</para>
    /// <para>See also <see cref="M:Godot.AnimationPlayer.Stop(System.Boolean)" />.</para>
    /// </summary>
    void Pause();
    /// <summary>
    /// <para>Stops the currently playing animation. The animation position is reset to <c>0</c> and the <c>custom_speed</c> is reset to <c>1.0</c>. See also <see cref="AnimationPlayer.Pause" />.</para>
    /// <para>If <paramref name="keepState" /> is <c>true</c>, the animation state is not updated visually.</para>
    /// <para><b>Note:</b> The method / audio / animation playback tracks will not be processed by this method.</para>
    /// </summary>
    void Stop(bool keepState);
    /// <summary>
    /// <para>Returns <c>true</c> if an animation is currently playing (even if <see cref="AnimationPlayer.SpeedScale" /> and/or <c>custom_speed</c> are <c>0</c>).</para>
    /// </summary>
    bool IsPlaying();
    /// <summary>
    /// <para>Queues an animation for playback once the current one is done.</para>
    /// <para><b>Note:</b> If a looped animation is currently playing, the queued animation will never play unless the looped animation is stopped somehow.</para>
    /// </summary>
    void Queue(StringName name);
    /// <summary>
    /// <para>Returns a list of the animation keys that are currently queued to play.</para>
    /// </summary>
    string[] GetQueue();
    /// <summary>
    /// <para>Clears all queued, unplayed animations.</para>
    /// </summary>
    void ClearQueue();
    /// <summary>
    /// <para>Returns the actual playing speed of current animation or <c>0</c> if not playing. This speed is the <see cref="AnimationPlayer.SpeedScale" /> property multiplied by <c>custom_speed</c> argument specified when calling the <see cref="M:Godot.AnimationPlayer.Play(Godot.StringName,System.Double,System.Single,System.Boolean)" /> method.</para>
    /// <para>Returns a negative value if the current animation is playing backwards.</para>
    /// </summary>
    float GetPlayingSpeed();
    /// <summary>
    /// <para>Seeks the animation to the <paramref name="seconds" /> point in time (in seconds). If <paramref name="update" /> is <c>true</c>, the animation updates too, otherwise it updates at process time. Events between the current frame and <paramref name="seconds" /> are skipped.</para>
    /// <para>If <paramref name="updateOnly" /> is true, the method / audio / animation playback tracks will not be processed.</para>
    /// <para><b>Note:</b> Seeking to the end of the animation doesn't emit <see cref="AnimationMixer.AnimationFinished" />. If you want to skip animation and emit the signal, use <see cref="M:Godot.AnimationMixer.Advance(System.Double)" />.</para>
    /// </summary>
    void Seek(double seconds, bool update, bool updateOnly);
    /// <summary>
    /// <para>For backward compatibility. See <see cref="AnimationMixer.AnimationCallbackModeProcess" />.</para>
    /// </summary>
    void SetProcessCallback(AnimationPlayer.AnimationProcessCallback mode);
    /// <summary>
    /// <para>For backward compatibility. See <see cref="AnimationMixer.AnimationCallbackModeProcess" />.</para>
    /// </summary>
    AnimationPlayer.AnimationProcessCallback GetProcessCallback();
    /// <summary>
    /// <para>For backward compatibility. See <see cref="AnimationMixer.AnimationCallbackModeMethod" />.</para>
    /// </summary>
    void SetMethodCallMode(AnimationPlayer.AnimationMethodCallMode mode);
    /// <summary>
    /// <para>For backward compatibility. See <see cref="AnimationMixer.AnimationCallbackModeMethod" />.</para>
    /// </summary>
    AnimationPlayer.AnimationMethodCallMode GetMethodCallMode();
    /// <summary>
    /// <para>For backward compatibility. See <see cref="AnimationMixer.RootNode" />.</para>
    /// </summary>
    void SetRoot(NodePath path);
    /// <summary>
    /// <para>For backward compatibility. See <see cref="AnimationMixer.RootNode" />.</para>
    /// </summary>
    NodePath GetRoot();
    /// <summary>
    /// <para>Seeks the animation to the <paramref name="seconds" /> point in time (in seconds). If <paramref name="update" /> is <c>true</c>, the animation updates too, otherwise it updates at process time. Events between the current frame and <paramref name="seconds" /> are skipped.</para>
    /// <para>If <paramref name="updateOnly" /> is true, the method / audio / animation playback tracks will not be processed.</para>
    /// <para><b>Note:</b> Seeking to the end of the animation doesn't emit <see cref="AnimationMixer.AnimationFinished" />. If you want to skip animation and emit the signal, use <see cref="M:Godot.AnimationMixer.Advance(System.Double)" />.</para>
    /// </summary>
    void Seek(double seconds, bool update);
    /// <inheritdoc cref="P:Godot.AnimationMixer.CallbackModeMethod" />
    AnimationPlayer.AnimationMethodCallMode MethodCallMode { get; set; }
    /// <inheritdoc cref="P:Godot.AnimationMixer.Active" />
    bool PlaybackActive { get; set; }
    /// <inheritdoc cref="P:Godot.AnimationMixer.CallbackModeProcess" />
    AnimationPlayer.AnimationProcessCallback PlaybackProcessMode { get; set; }
    /// <summary>
    /// <para>The key of the currently playing animation. If no animation is playing, the property's value is an empty string. Changing this value does not restart the animation. See <see cref="M:Godot.AnimationPlayer.Play(Godot.StringName,System.Double,System.Single,System.Boolean)" /> for more information on playing animations.</para>
    /// <para><b>Note:</b> While this property appears in the Inspector, it's not meant to be edited, and it's not saved in the scene. This property is mainly used to get the currently playing animation, and internally for animation playback tracks. For more information, see <see cref="Animation" />.</para>
    /// </summary>
    string CurrentAnimation { get; set; }
    /// <summary>
    /// <para>If playing, the current animation's key, otherwise, the animation last played. When set, this changes the animation, but will not play it unless already playing. See also <see cref="AnimationPlayer.CurrentAnimation" />.</para>
    /// </summary>
    string AssignedAnimation { get; set; }
    /// <summary>
    /// <para>The key of the animation to play when the scene loads.</para>
    /// </summary>
    string Autoplay { get; set; }
    /// <summary>
    /// <para>The length (in seconds) of the currently playing animation.</para>
    /// </summary>
    double CurrentAnimationLength { get; }
    /// <summary>
    /// <para>The position (in seconds) of the currently playing animation.</para>
    /// </summary>
    double CurrentAnimationPosition { get; }
    /// <summary>
    /// <para>The default time in which to blend animations. Ranges from 0 to 4096 with 0.01 precision.</para>
    /// </summary>
    double PlaybackDefaultBlendTime { get; set; }
    /// <summary>
    /// <para>The speed scaling ratio. For example, if this value is <c>1</c>, then the animation plays at normal speed. If it's <c>0.5</c>, then it plays at half speed. If it's <c>2</c>, then it plays at double speed.</para>
    /// <para>If set to a negative value, the animation is played in reverse. If set to <c>0</c>, the animation will not advance.</para>
    /// </summary>
    float SpeedScale { get; set; }
    /// <summary>
    /// <para>If <c>true</c> and the engine is running in Movie Maker mode (see <see cref="MovieWriter" />), exits the engine with <see cref="M:Godot.SceneTree.Quit(System.Int32)" /> as soon as an animation is done playing in this <see cref="AnimationPlayer" />. A message is printed when the engine quits for this reason.</para>
    /// <para><b>Note:</b> This obeys the same logic as the <see cref="AnimationMixer.AnimationFinished" /> signal, so it will not quit the engine if the animation is set to be looping.</para>
    /// </summary>
    bool MovieQuitOnFinish { get; set; }

}