namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para><see cref="AnimatedSprite3D" /> is similar to the <see cref="Sprite3D" /> node, except it carries multiple textures as animation <see cref="AnimatedSprite3D.SpriteFrames" />. Animations are created using a <see cref="SpriteFrames" /> resource, which allows you to import image files (or a folder containing said files) to provide the animation frames for the sprite. The <see cref="SpriteFrames" /> resource can be configured in the editor via the SpriteFrames bottom panel.</para>
/// </summary>
public class AnimatedSprite3DAdapter : AnimatedSprite3D, IAnimatedSprite3D {
  private readonly AnimatedSprite3D _node;

  public AnimatedSprite3DAdapter(AnimatedSprite3D node) => _node = node;
    /// <summary>
    /// <para>The current animation from the <see cref="AnimatedSprite3D.SpriteFrames" /> resource. If this value is changed, the <see cref="AnimatedSprite3D.Frame" /> counter and the <see cref="AnimatedSprite3D.FrameProgress" /> are reset.</para>
    /// </summary>
    public StringName Animation { get => _node.Animation; set => _node.Animation = value; }
    /// <summary>
    /// <para>The key of the animation to play when the scene loads.</para>
    /// </summary>
    public string Autoplay { get => _node.Autoplay; set => _node.Autoplay = value; }
    /// <summary>
    /// <para>The displayed animation frame's index. Setting this property also resets <see cref="AnimatedSprite3D.FrameProgress" />. If this is not desired, use <see cref="AnimatedSprite3D.SetFrameAndProgress(System.Int32,System.Single)" />.</para>
    /// </summary>
    public int Frame { get => _node.Frame; set => _node.Frame = value; }
    /// <summary>
    /// <para>The progress value between <c>0.0</c> and <c>1.0</c> until the current frame transitions to the next frame. If the animation is playing backwards, the value transitions from <c>1.0</c> to <c>0.0</c>.</para>
    /// </summary>
    public float FrameProgress { get => _node.FrameProgress; set => _node.FrameProgress = value; }
    /// <summary>
    /// <para>Returns the actual playing speed of current animation or <c>0</c> if not playing. This speed is the <see cref="AnimatedSprite3D.SpeedScale" /> property multiplied by <c>custom_speed</c> argument specified when calling the <see cref="AnimatedSprite3D.Play(Godot.StringName,System.Single,System.Boolean)" /> method.</para>
    /// <para>Returns a negative value if the current animation is playing backwards.</para>
    /// </summary>
    public float GetPlayingSpeed() => _node.GetPlayingSpeed();
    /// <summary>
    /// <para>Returns <c>true</c> if an animation is currently playing (even if <see cref="AnimatedSprite3D.SpeedScale" /> and/or <c>custom_speed</c> are <c>0</c>).</para>
    /// </summary>
    public bool IsPlaying() => _node.IsPlaying();
    /// <summary>
    /// <para>Pauses the currently playing animation. The <see cref="AnimatedSprite3D.Frame" /> and <see cref="AnimatedSprite3D.FrameProgress" /> will be kept and calling <see cref="AnimatedSprite3D.Play(Godot.StringName,System.Single,System.Boolean)" /> or <see cref="AnimatedSprite3D.PlayBackwards(Godot.StringName)" /> without arguments will resume the animation from the current playback position.</para>
    /// <para>See also <see cref="AnimatedSprite3D.Stop" />.</para>
    /// </summary>
    public void Pause() => _node.Pause();
    /// <summary>
    /// <para>Plays the animation with key <paramref name="name" />. If <paramref name="customSpeed" /> is negative and <paramref name="fromEnd" /> is <c>true</c>, the animation will play backwards (which is equivalent to calling <see cref="AnimatedSprite3D.PlayBackwards(Godot.StringName)" />).</para>
    /// <para>If this method is called with that same animation <paramref name="name" />, or with no <paramref name="name" /> parameter, the assigned animation will resume playing if it was paused.</para>
    /// </summary>
    public void Play(StringName name, float customSpeed, bool fromEnd) => _node.Play(name, customSpeed, fromEnd);
    /// <summary>
    /// <para>Plays the animation with key <paramref name="name" /> in reverse.</para>
    /// <para>This method is a shorthand for <see cref="AnimatedSprite3D.Play(Godot.StringName,System.Single,System.Boolean)" /> with <c>custom_speed = -1.0</c> and <c>from_end = true</c>, so see its description for more information.</para>
    /// </summary>
    public void PlayBackwards(StringName name) => _node.PlayBackwards(name);
    /// <summary>
    /// <para>The setter of <see cref="AnimatedSprite3D.Frame" /> resets the <see cref="AnimatedSprite3D.FrameProgress" /> to <c>0.0</c> implicitly, but this method avoids that.</para>
    /// <para>This is useful when you want to carry over the current <see cref="AnimatedSprite3D.FrameProgress" /> to another <see cref="AnimatedSprite3D.Frame" />.</para>
    /// <para><b>Example:</b></para>
    /// <para></para>
    /// </summary>
    public void SetFrameAndProgress(int frame, float progress) => _node.SetFrameAndProgress(frame, progress);
    /// <summary>
    /// <para>The speed scaling ratio. For example, if this value is <c>1</c>, then the animation plays at normal speed. If it's <c>0.5</c>, then it plays at half speed. If it's <c>2</c>, then it plays at double speed.</para>
    /// <para>If set to a negative value, the animation is played in reverse. If set to <c>0</c>, the animation will not advance.</para>
    /// </summary>
    public float SpeedScale { get => _node.SpeedScale; set => _node.SpeedScale = value; }
    /// <summary>
    /// <para>The <see cref="SpriteFrames" /> resource containing the animation(s). Allows you the option to load, edit, clear, make unique and save the states of the <see cref="SpriteFrames" /> resource.</para>
    /// </summary>
    public SpriteFrames SpriteFrames { get => _node.SpriteFrames; set => _node.SpriteFrames = value; }
    /// <summary>
    /// <para>Stops the currently playing animation. The animation position is reset to <c>0</c> and the <c>custom_speed</c> is reset to <c>1.0</c>. See also <see cref="AnimatedSprite3D.Pause" />.</para>
    /// </summary>
    public void Stop() => _node.Stop();

}