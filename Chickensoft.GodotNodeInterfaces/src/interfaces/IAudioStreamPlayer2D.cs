namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>Plays audio that is attenuated with distance to the listener.</para>
/// <para>By default, audio is heard from the screen center. This can be changed by adding an <see cref="AudioListener2D" /> node to the scene and enabling it by calling <see cref="AudioListener2D.MakeCurrent" /> on it.</para>
/// <para>See also <see cref="AudioStreamPlayer" /> to play a sound non-positionally.</para>
/// <para><b>Note:</b> Hiding an <see cref="AudioStreamPlayer2D" /> node does not disable its audio output. To temporarily disable an <see cref="AudioStreamPlayer2D" />'s audio output, set <see cref="AudioStreamPlayer2D.VolumeDb" /> to a very low value like <c>-100</c> (which isn't audible to human hearing).</para>
/// </summary>
public interface IAudioStreamPlayer2D : INode2D {
    /// <summary>
    /// <para>Queues the audio to play on the next physics frame, from the given position <paramref name="fromPosition" />, in seconds.</para>
    /// </summary>
    void Play(float fromPosition);
    /// <summary>
    /// <para>Sets the position from which audio will be played, in seconds.</para>
    /// </summary>
    void Seek(float toPosition);
    /// <summary>
    /// <para>Stops the audio.</para>
    /// </summary>
    void Stop();
    /// <summary>
    /// <para>Returns the position in the <see cref="AudioStream" />.</para>
    /// </summary>
    float GetPlaybackPosition();
    /// <summary>
    /// <para>Returns whether the <see cref="AudioStreamPlayer" /> can return the <see cref="AudioStreamPlayback" /> object or not.</para>
    /// </summary>
    bool HasStreamPlayback();
    /// <summary>
    /// <para>Returns the <see cref="AudioStreamPlayback" /> object associated with this <see cref="AudioStreamPlayer2D" />.</para>
    /// </summary>
    AudioStreamPlayback GetStreamPlayback();
    /// <summary>
    /// <para>The <see cref="AudioStream" /> object to be played.</para>
    /// </summary>
    AudioStream Stream { get; set; }
    /// <summary>
    /// <para>Base volume before attenuation.</para>
    /// </summary>
    float VolumeDb { get; set; }
    /// <summary>
    /// <para>The pitch and the tempo of the audio, as a multiplier of the audio sample's sample rate.</para>
    /// </summary>
    float PitchScale { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, audio is playing or is queued to be played (see <see cref="M:Godot.AudioStreamPlayer2D.Play(System.Single)" />).</para>
    /// </summary>
    bool Playing { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, audio plays when added to scene tree.</para>
    /// </summary>
    bool Autoplay { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the playback is paused. You can resume it by setting <see cref="AudioStreamPlayer2D.StreamPaused" /> to <c>false</c>.</para>
    /// </summary>
    bool StreamPaused { get; set; }
    /// <summary>
    /// <para>Maximum distance from which audio is still hearable.</para>
    /// </summary>
    float MaxDistance { get; set; }
    /// <summary>
    /// <para>The volume is attenuated over distance with this as an exponent.</para>
    /// </summary>
    float Attenuation { get; set; }
    /// <summary>
    /// <para>The maximum number of sounds this node can play at the same time. Playing additional sounds after this value is reached will cut off the oldest sounds.</para>
    /// </summary>
    int MaxPolyphony { get; set; }
    /// <summary>
    /// <para>Scales the panning strength for this node by multiplying the base <c>ProjectSettings.audio/general/2d_panning_strength</c> with this factor. Higher values will pan audio from left to right more dramatically than lower values.</para>
    /// </summary>
    float PanningStrength { get; set; }
    /// <summary>
    /// <para>Bus on which this audio is playing.</para>
    /// <para><b>Note:</b> When setting this property, keep in mind that no validation is performed to see if the given name matches an existing bus. This is because audio bus layouts might be loaded after this property is set. If this given name can't be resolved at runtime, it will fall back to <c>"Master"</c>.</para>
    /// </summary>
    StringName Bus { get; set; }
    /// <summary>
    /// <para>Determines which <see cref="Area2D" /> layers affect the sound for reverb and audio bus effects. Areas can be used to redirect <see cref="AudioStream" />s so that they play in a certain audio bus. An example of how you might use this is making a "water" area so that sounds played in the water are redirected through an audio bus to make them sound like they are being played underwater.</para>
    /// </summary>
    uint AreaMask { get; set; }

}