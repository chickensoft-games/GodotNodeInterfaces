namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>Plays an audio stream non-positionally.</para>
/// <para>To play audio positionally, use <see cref="AudioStreamPlayer2D" /> or <see cref="AudioStreamPlayer3D" /> instead of <see cref="AudioStreamPlayer" />.</para>
/// </summary>
public class AudioStreamPlayerAdapter : AudioStreamPlayer, IAudioStreamPlayer {
  private readonly AudioStreamPlayer _node;

  public AudioStreamPlayerAdapter(AudioStreamPlayer node) => _node = node;
    /// <summary>
    /// <para>If <c>true</c>, audio plays when added to scene tree.</para>
    /// </summary>
    public bool Autoplay { get => _node.Autoplay; set => _node.Autoplay = value; }
    /// <summary>
    /// <para>Bus on which this audio is playing.</para>
    /// <para><b>Note:</b> When setting this property, keep in mind that no validation is performed to see if the given name matches an existing bus. This is because audio bus layouts might be loaded after this property is set. If this given name can't be resolved at runtime, it will fall back to <c>"Master"</c>.</para>
    /// </summary>
    public StringName Bus { get => _node.Bus; set => _node.Bus = value; }
    /// <summary>
    /// <para>Returns the position in the <see cref="AudioStream" /> in seconds.</para>
    /// </summary>
    public float GetPlaybackPosition() => _node.GetPlaybackPosition();
    /// <summary>
    /// <para>Returns the <see cref="AudioStreamPlayback" /> object associated with this <see cref="AudioStreamPlayer" />.</para>
    /// </summary>
    public AudioStreamPlayback GetStreamPlayback() => _node.GetStreamPlayback();
    /// <summary>
    /// <para>Returns whether the <see cref="AudioStreamPlayer" /> can return the <see cref="AudioStreamPlayback" /> object or not.</para>
    /// </summary>
    public bool HasStreamPlayback() => _node.HasStreamPlayback();
    /// <summary>
    /// <para>The maximum number of sounds this node can play at the same time. Playing additional sounds after this value is reached will cut off the oldest sounds.</para>
    /// </summary>
    public int MaxPolyphony { get => _node.MaxPolyphony; set => _node.MaxPolyphony = value; }
    /// <summary>
    /// <para>If the audio configuration has more than two speakers, this sets the target channels. See <see cref="AudioStreamPlayer.MixTargetEnum" /> constants.</para>
    /// </summary>
    public AudioStreamPlayer.MixTargetEnum MixTarget { get => _node.MixTarget; set => _node.MixTarget = value; }
    /// <summary>
    /// <para>The pitch and the tempo of the audio, as a multiplier of the audio sample's sample rate.</para>
    /// </summary>
    public float PitchScale { get => _node.PitchScale; set => _node.PitchScale = value; }
    /// <summary>
    /// <para>Plays the audio from the given <paramref name="fromPosition" />, in seconds.</para>
    /// </summary>
    public void Play(float fromPosition) => _node.Play(fromPosition);
    /// <summary>
    /// <para>If <c>true</c>, audio is playing.</para>
    /// </summary>
    public bool Playing { get => _node.Playing; set => _node.Playing = value; }
    /// <summary>
    /// <para>Sets the position from which audio will be played, in seconds.</para>
    /// </summary>
    public void Seek(float toPosition) => _node.Seek(toPosition);
    /// <summary>
    /// <para>Stops the audio.</para>
    /// </summary>
    public void Stop() => _node.Stop();
    /// <summary>
    /// <para>The <see cref="AudioStream" /> object to be played.</para>
    /// </summary>
    public AudioStream Stream { get => _node.Stream; set => _node.Stream = value; }
    /// <summary>
    /// <para>If <c>true</c>, the playback is paused. You can resume it by setting <see cref="AudioStreamPlayer.StreamPaused" /> to <c>false</c>.</para>
    /// </summary>
    public bool StreamPaused { get => _node.StreamPaused; set => _node.StreamPaused = value; }
    /// <summary>
    /// <para>Volume of sound, in dB.</para>
    /// </summary>
    public float VolumeDb { get => _node.VolumeDb; set => _node.VolumeDb = value; }

}