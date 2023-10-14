namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class AudioStreamPlayerNode : AudioStreamPlayer, IAudioStreamPlayer { }

/// <summary>
/// <para>Plays an audio stream non-positionally.</para>
/// <para>To play audio positionally, use <see cref="AudioStreamPlayer2D" /> or <see cref="AudioStreamPlayer3D" /> instead of <see cref="AudioStreamPlayer" />.</para>
/// </summary>
public interface IAudioStreamPlayer {
    /// <summary>
    /// <para>If <c>true</c>, audio plays when added to scene tree.</para>
    /// </summary>
    bool Autoplay { get; set; }
    /// <summary>
    /// <para>Bus on which this audio is playing.</para>
    /// <para><b>Note:</b> When setting this property, keep in mind that no validation is performed to see if the given name matches an existing bus. This is because audio bus layouts might be loaded after this property is set. If this given name can't be resolved at runtime, it will fall back to <c>"Master"</c>.</para>
    /// </summary>
    StringName Bus { get; set; }
    /// <summary>
    /// <para>Returns the position in the <see cref="AudioStream" /> in seconds.</para>
    /// </summary>
    float GetPlaybackPosition();
    /// <summary>
    /// <para>Returns the <see cref="AudioStreamPlayback" /> object associated with this <see cref="AudioStreamPlayer" />.</para>
    /// </summary>
    AudioStreamPlayback GetStreamPlayback();
    /// <summary>
    /// <para>Returns whether the <see cref="AudioStreamPlayer" /> can return the <see cref="AudioStreamPlayback" /> object or not.</para>
    /// </summary>
    bool HasStreamPlayback();
    /// <summary>
    /// <para>The maximum number of sounds this node can play at the same time. Playing additional sounds after this value is reached will cut off the oldest sounds.</para>
    /// </summary>
    int MaxPolyphony { get; set; }
    /// <summary>
    /// <para>If the audio configuration has more than two speakers, this sets the target channels. See <see cref="AudioStreamPlayer.MixTargetEnum" /> constants.</para>
    /// </summary>
    AudioStreamPlayer.MixTargetEnum MixTarget { get; set; }
    /// <summary>
    /// <para>The pitch and the tempo of the audio, as a multiplier of the audio sample's sample rate.</para>
    /// </summary>
    float PitchScale { get; set; }
    /// <summary>
    /// <para>Plays the audio from the given <paramref name="fromPosition" />, in seconds.</para>
    /// </summary>
    void Play(float fromPosition);
    /// <summary>
    /// <para>If <c>true</c>, audio is playing.</para>
    /// </summary>
    bool Playing { get; set; }
    /// <summary>
    /// <para>Sets the position from which audio will be played, in seconds.</para>
    /// </summary>
    void Seek(float toPosition);
    /// <summary>
    /// <para>Stops the audio.</para>
    /// </summary>
    void Stop();
    /// <summary>
    /// <para>The <see cref="AudioStream" /> object to be played.</para>
    /// </summary>
    AudioStream Stream { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the playback is paused. You can resume it by setting <see cref="AudioStreamPlayer.StreamPaused" /> to <c>false</c>.</para>
    /// </summary>
    bool StreamPaused { get; set; }
    /// <summary>
    /// <para>Volume of sound, in dB.</para>
    /// </summary>
    float VolumeDb { get; set; }

}