namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para><see cref="AnimatedSprite2D" /> is similar to the <see cref="Sprite2D" /> node, except it carries multiple textures as animation frames. Animations are created using a <see cref="SpriteFrames" /> resource, which allows you to import image files (or a folder containing said files) to provide the animation frames for the sprite. The <see cref="SpriteFrames" /> resource can be configured in the editor via the SpriteFrames bottom panel.</para>
/// </summary>
public interface IAnimatedSprite2D : INode2D {
    /// <summary>
    /// <para>Returns <c>true</c> if an animation is currently playing (even if <see cref="AnimatedSprite2D.SpeedScale" /> and/or <c>custom_speed</c> are <c>0</c>).</para>
    /// </summary>
    bool IsPlaying();
    /// <summary>
    /// <para>Plays the animation with key <paramref name="name" />. If <paramref name="customSpeed" /> is negative and <paramref name="fromEnd" /> is <c>true</c>, the animation will play backwards (which is equivalent to calling <see cref="M:Godot.AnimatedSprite2D.PlayBackwards(Godot.StringName)" />).</para>
    /// <para>If this method is called with that same animation <paramref name="name" />, or with no <paramref name="name" /> parameter, the assigned animation will resume playing if it was paused.</para>
    /// </summary>
    void Play(StringName name, float customSpeed, bool fromEnd);
    /// <summary>
    /// <para>Plays the animation with key <paramref name="name" /> in reverse.</para>
    /// <para>This method is a shorthand for <see cref="M:Godot.AnimatedSprite2D.Play(Godot.StringName,System.Single,System.Boolean)" /> with <c>custom_speed = -1.0</c> and <c>from_end = true</c>, so see its description for more information.</para>
    /// </summary>
    void PlayBackwards(StringName name);
    /// <summary>
    /// <para>Pauses the currently playing animation. The <see cref="AnimatedSprite2D.Frame" /> and <see cref="AnimatedSprite2D.FrameProgress" /> will be kept and calling <see cref="M:Godot.AnimatedSprite2D.Play(Godot.StringName,System.Single,System.Boolean)" /> or <see cref="M:Godot.AnimatedSprite2D.PlayBackwards(Godot.StringName)" /> without arguments will resume the animation from the current playback position.</para>
    /// <para>See also <see cref="AnimatedSprite2D.Stop" />.</para>
    /// </summary>
    void Pause();
    /// <summary>
    /// <para>Stops the currently playing animation. The animation position is reset to <c>0</c> and the <c>custom_speed</c> is reset to <c>1.0</c>. See also <see cref="AnimatedSprite2D.Pause" />.</para>
    /// </summary>
    void Stop();
    /// <summary>
    /// <para>The setter of <see cref="AnimatedSprite2D.Frame" /> resets the <see cref="AnimatedSprite2D.FrameProgress" /> to <c>0.0</c> implicitly, but this method avoids that.</para>
    /// <para>This is useful when you want to carry over the current <see cref="AnimatedSprite2D.FrameProgress" /> to another <see cref="AnimatedSprite2D.Frame" />.</para>
    /// <para><b>Example:</b></para>
    /// <para></para>
    /// </summary>
    void SetFrameAndProgress(int frame, float progress);
    /// <summary>
    /// <para>Returns the actual playing speed of current animation or <c>0</c> if not playing. This speed is the <see cref="AnimatedSprite2D.SpeedScale" /> property multiplied by <c>custom_speed</c> argument specified when calling the <see cref="M:Godot.AnimatedSprite2D.Play(Godot.StringName,System.Single,System.Boolean)" /> method.</para>
    /// <para>Returns a negative value if the current animation is playing backwards.</para>
    /// </summary>
    float GetPlayingSpeed();
    /// <summary>
    /// <para>The <see cref="SpriteFrames" /> resource containing the animation(s). Allows you the option to load, edit, clear, make unique and save the states of the <see cref="SpriteFrames" /> resource.</para>
    /// </summary>
    SpriteFrames SpriteFrames { get; set; }
    /// <summary>
    /// <para>The current animation from the <see cref="AnimatedSprite2D.SpriteFrames" /> resource. If this value is changed, the <see cref="AnimatedSprite2D.Frame" /> counter and the <see cref="AnimatedSprite2D.FrameProgress" /> are reset.</para>
    /// </summary>
    StringName Animation { get; set; }
    /// <summary>
    /// <para>The key of the animation to play when the scene loads.</para>
    /// </summary>
    string Autoplay { get; set; }
    /// <summary>
    /// <para>The displayed animation frame's index. Setting this property also resets <see cref="AnimatedSprite2D.FrameProgress" />. If this is not desired, use <see cref="M:Godot.AnimatedSprite2D.SetFrameAndProgress(System.Int32,System.Single)" />.</para>
    /// </summary>
    int Frame { get; set; }
    /// <summary>
    /// <para>The progress value between <c>0.0</c> and <c>1.0</c> until the current frame transitions to the next frame. If the animation is playing backwards, the value transitions from <c>1.0</c> to <c>0.0</c>.</para>
    /// </summary>
    float FrameProgress { get; set; }
    /// <summary>
    /// <para>The speed scaling ratio. For example, if this value is <c>1</c>, then the animation plays at normal speed. If it's <c>0.5</c>, then it plays at half speed. If it's <c>2</c>, then it plays at double speed.</para>
    /// <para>If set to a negative value, the animation is played in reverse. If set to <c>0</c>, the animation will not advance.</para>
    /// </summary>
    float SpeedScale { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, texture will be centered.</para>
    /// </summary>
    bool Centered { get; set; }
    /// <summary>
    /// <para>The texture's drawing offset.</para>
    /// </summary>
    Vector2 Offset { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, texture is flipped horizontally.</para>
    /// </summary>
    bool FlipH { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, texture is flipped vertically.</para>
    /// </summary>
    bool FlipV { get; set; }

}