namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class AudioStreamPlayer3DNode : AudioStreamPlayer3D, IAudioStreamPlayer3D { }

/// <summary>
/// <para>Plays audio with positional sound effects, based on the relative position of the audio listener. Positional effects include distance attenuation, directionality, and the Doppler effect. For greater realism, a low-pass filter is applied to distant sounds. This can be disabled by setting <see cref="AudioStreamPlayer3D.AttenuationFilterCutoffHz" /> to <c>20500</c>.</para>
/// <para>By default, audio is heard from the camera position. This can be changed by adding an <see cref="AudioListener3D" /> node to the scene and enabling it by calling <see cref="AudioListener3D.MakeCurrent" /> on it.</para>
/// <para>See also <see cref="AudioStreamPlayer" /> to play a sound non-positionally.</para>
/// <para><b>Note:</b> Hiding an <see cref="AudioStreamPlayer3D" /> node does not disable its audio output. To temporarily disable an <see cref="AudioStreamPlayer3D" />'s audio output, set <see cref="AudioStreamPlayer3D.VolumeDb" /> to a very low value like <c>-100</c> (which isn't audible to human hearing).</para>
/// </summary>
public interface IAudioStreamPlayer3D : INode3D {
    /// <summary>
    /// <para>Determines which <see cref="Area3D" /> layers affect the sound for reverb and audio bus effects. Areas can be used to redirect <see cref="AudioStream" />s so that they play in a certain audio bus. An example of how you might use this is making a "water" area so that sounds played in the water are redirected through an audio bus to make them sound like they are being played underwater.</para>
    /// </summary>
    uint AreaMask { get; set; }
    /// <summary>
    /// <para>The cutoff frequency of the attenuation low-pass filter, in Hz. A sound above this frequency is attenuated more than a sound below this frequency. To disable this effect, set this to <c>20500</c> as this frequency is above the human hearing limit.</para>
    /// </summary>
    float AttenuationFilterCutoffHz { get; set; }
    /// <summary>
    /// <para>Amount how much the filter affects the loudness, in decibels.</para>
    /// </summary>
    float AttenuationFilterDb { get; set; }
    /// <summary>
    /// <para>Decides if audio should get quieter with distance linearly, quadratically, logarithmically, or not be affected by distance, effectively disabling attenuation.</para>
    /// </summary>
    AudioStreamPlayer3D.AttenuationModelEnum AttenuationModel { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, audio plays when the AudioStreamPlayer3D node is added to scene tree.</para>
    /// </summary>
    bool Autoplay { get; set; }
    /// <summary>
    /// <para>The bus on which this audio is playing.</para>
    /// <para><b>Note:</b> When setting this property, keep in mind that no validation is performed to see if the given name matches an existing bus. This is because audio bus layouts might be loaded after this property is set. If this given name can't be resolved at runtime, it will fall back to <c>"Master"</c>.</para>
    /// </summary>
    StringName Bus { get; set; }
    /// <summary>
    /// <para>Decides in which step the Doppler effect should be calculated.</para>
    /// </summary>
    AudioStreamPlayer3D.DopplerTrackingEnum DopplerTracking { get; set; }
    /// <summary>
    /// <para>The angle in which the audio reaches a listener unattenuated.</para>
    /// </summary>
    float EmissionAngleDegrees { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the audio should be attenuated according to the direction of the sound.</para>
    /// </summary>
    bool EmissionAngleEnabled { get; set; }
    /// <summary>
    /// <para>Attenuation factor used if listener is outside of <see cref="AudioStreamPlayer3D.EmissionAngleDegrees" /> and <see cref="AudioStreamPlayer3D.EmissionAngleEnabled" /> is set, in decibels.</para>
    /// </summary>
    float EmissionAngleFilterAttenuationDb { get; set; }
    /// <summary>
    /// <para>Returns the position in the <see cref="AudioStream" />.</para>
    /// </summary>
    float GetPlaybackPosition();
    /// <summary>
    /// <para>Returns the <see cref="AudioStreamPlayback" /> object associated with this <see cref="AudioStreamPlayer3D" />.</para>
    /// </summary>
    AudioStreamPlayback GetStreamPlayback();
    /// <summary>
    /// <para>Returns whether the <see cref="AudioStreamPlayer" /> can return the <see cref="AudioStreamPlayback" /> object or not.</para>
    /// </summary>
    bool HasStreamPlayback();
    /// <summary>
    /// <para>Sets the absolute maximum of the sound level, in decibels.</para>
    /// </summary>
    float MaxDb { get; set; }
    /// <summary>
    /// <para>The distance past which the sound can no longer be heard at all. Only has an effect if set to a value greater than <c>0.0</c>. <see cref="AudioStreamPlayer3D.MaxDistance" /> works in tandem with <see cref="AudioStreamPlayer3D.UnitSize" />. However, unlike <see cref="AudioStreamPlayer3D.UnitSize" /> whose behavior depends on the <see cref="AudioStreamPlayer3D.AttenuationModel" />, <see cref="AudioStreamPlayer3D.MaxDistance" /> always works in a linear fashion. This can be used to prevent the <see cref="AudioStreamPlayer3D" /> from requiring audio mixing when the listener is far away, which saves CPU resources.</para>
    /// </summary>
    float MaxDistance { get; set; }
    /// <summary>
    /// <para>The maximum number of sounds this node can play at the same time. Playing additional sounds after this value is reached will cut off the oldest sounds.</para>
    /// </summary>
    int MaxPolyphony { get; set; }
    /// <summary>
    /// <para>Scales the panning strength for this node by multiplying the base <c>ProjectSettings.audio/general/3d_panning_strength</c> with this factor. Higher values will pan audio from left to right more dramatically than lower values.</para>
    /// </summary>
    float PanningStrength { get; set; }
    /// <summary>
    /// <para>The pitch and the tempo of the audio, as a multiplier of the audio sample's sample rate.</para>
    /// </summary>
    float PitchScale { get; set; }
    /// <summary>
    /// <para>Queues the audio to play on the next physics frame, from the given position <paramref name="fromPosition" />, in seconds.</para>
    /// </summary>
    void Play(float fromPosition);
    /// <summary>
    /// <para>If <c>true</c>, audio is playing or is queued to be played (see <see cref="AudioStreamPlayer3D.Play(System.Single)" />).</para>
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
    /// <para>The <see cref="AudioStream" /> resource to be played.</para>
    /// </summary>
    AudioStream Stream { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the playback is paused. You can resume it by setting <see cref="AudioStreamPlayer3D.StreamPaused" /> to <c>false</c>.</para>
    /// </summary>
    bool StreamPaused { get; set; }
    /// <summary>
    /// <para>The factor for the attenuation effect. Higher values make the sound audible over a larger distance.</para>
    /// </summary>
    float UnitSize { get; set; }
    /// <summary>
    /// <para>The base sound level before attenuation, in decibels.</para>
    /// </summary>
    float VolumeDb { get; set; }

}