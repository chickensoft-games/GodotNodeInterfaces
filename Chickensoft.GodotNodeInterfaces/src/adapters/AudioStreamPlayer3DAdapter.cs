namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>Plays audio with positional sound effects, based on the relative position of the audio listener. Positional effects include distance attenuation, directionality, and the Doppler effect. For greater realism, a low-pass filter is applied to distant sounds. This can be disabled by setting <see cref="AudioStreamPlayer3D.AttenuationFilterCutoffHz" /> to <c>20500</c>.</para>
/// <para>By default, audio is heard from the camera position. This can be changed by adding an <see cref="AudioListener3D" /> node to the scene and enabling it by calling <see cref="AudioListener3D.MakeCurrent" /> on it.</para>
/// <para>See also <see cref="AudioStreamPlayer" /> to play a sound non-positionally.</para>
/// <para><b>Note:</b> Hiding an <see cref="AudioStreamPlayer3D" /> node does not disable its audio output. To temporarily disable an <see cref="AudioStreamPlayer3D" />'s audio output, set <see cref="AudioStreamPlayer3D.VolumeDb" /> to a very low value like <c>-100</c> (which isn't audible to human hearing).</para>
/// </summary>
public class AudioStreamPlayer3DAdapter : Node3DAdapter, IAudioStreamPlayer3D {
  private readonly AudioStreamPlayer3D _node;

  public AudioStreamPlayer3DAdapter(Node node) : base(node) {
    if (node is not AudioStreamPlayer3D typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a AudioStreamPlayer3D"
      );
    }
    _node = typedNode;
  }

    /// <summary>
    /// <para>Determines which <see cref="Area3D" /> layers affect the sound for reverb and audio bus effects. Areas can be used to redirect <see cref="AudioStream" />s so that they play in a certain audio bus. An example of how you might use this is making a "water" area so that sounds played in the water are redirected through an audio bus to make them sound like they are being played underwater.</para>
    /// </summary>
    public uint AreaMask { get => _node.AreaMask; set => _node.AreaMask = value; }
    /// <summary>
    /// <para>The cutoff frequency of the attenuation low-pass filter, in Hz. A sound above this frequency is attenuated more than a sound below this frequency. To disable this effect, set this to <c>20500</c> as this frequency is above the human hearing limit.</para>
    /// </summary>
    public float AttenuationFilterCutoffHz { get => _node.AttenuationFilterCutoffHz; set => _node.AttenuationFilterCutoffHz = value; }
    /// <summary>
    /// <para>Amount how much the filter affects the loudness, in decibels.</para>
    /// </summary>
    public float AttenuationFilterDb { get => _node.AttenuationFilterDb; set => _node.AttenuationFilterDb = value; }
    /// <summary>
    /// <para>Decides if audio should get quieter with distance linearly, quadratically, logarithmically, or not be affected by distance, effectively disabling attenuation.</para>
    /// </summary>
    public AudioStreamPlayer3D.AttenuationModelEnum AttenuationModel { get => _node.AttenuationModel; set => _node.AttenuationModel = value; }
    /// <summary>
    /// <para>If <c>true</c>, audio plays when the AudioStreamPlayer3D node is added to scene tree.</para>
    /// </summary>
    public bool Autoplay { get => _node.Autoplay; set => _node.Autoplay = value; }
    /// <summary>
    /// <para>The bus on which this audio is playing.</para>
    /// <para><b>Note:</b> When setting this property, keep in mind that no validation is performed to see if the given name matches an existing bus. This is because audio bus layouts might be loaded after this property is set. If this given name can't be resolved at runtime, it will fall back to <c>"Master"</c>.</para>
    /// </summary>
    public StringName Bus { get => _node.Bus; set => _node.Bus = value; }
    /// <summary>
    /// <para>Decides in which step the Doppler effect should be calculated.</para>
    /// </summary>
    public AudioStreamPlayer3D.DopplerTrackingEnum DopplerTracking { get => _node.DopplerTracking; set => _node.DopplerTracking = value; }
    /// <summary>
    /// <para>The angle in which the audio reaches a listener unattenuated.</para>
    /// </summary>
    public float EmissionAngleDegrees { get => _node.EmissionAngleDegrees; set => _node.EmissionAngleDegrees = value; }
    /// <summary>
    /// <para>If <c>true</c>, the audio should be attenuated according to the direction of the sound.</para>
    /// </summary>
    public bool EmissionAngleEnabled { get => _node.EmissionAngleEnabled; set => _node.EmissionAngleEnabled = value; }
    /// <summary>
    /// <para>Attenuation factor used if listener is outside of <see cref="AudioStreamPlayer3D.EmissionAngleDegrees" /> and <see cref="AudioStreamPlayer3D.EmissionAngleEnabled" /> is set, in decibels.</para>
    /// </summary>
    public float EmissionAngleFilterAttenuationDb { get => _node.EmissionAngleFilterAttenuationDb; set => _node.EmissionAngleFilterAttenuationDb = value; }
    /// <summary>
    /// <para>Returns the position in the <see cref="AudioStream" />.</para>
    /// </summary>
    public float GetPlaybackPosition() => _node.GetPlaybackPosition();
    /// <summary>
    /// <para>Returns the <see cref="AudioStreamPlayback" /> object associated with this <see cref="AudioStreamPlayer3D" />.</para>
    /// </summary>
    public AudioStreamPlayback GetStreamPlayback() => _node.GetStreamPlayback();
    /// <summary>
    /// <para>Returns whether the <see cref="AudioStreamPlayer" /> can return the <see cref="AudioStreamPlayback" /> object or not.</para>
    /// </summary>
    public bool HasStreamPlayback() => _node.HasStreamPlayback();
    /// <summary>
    /// <para>Sets the absolute maximum of the sound level, in decibels.</para>
    /// </summary>
    public float MaxDb { get => _node.MaxDb; set => _node.MaxDb = value; }
    /// <summary>
    /// <para>The distance past which the sound can no longer be heard at all. Only has an effect if set to a value greater than <c>0.0</c>. <see cref="AudioStreamPlayer3D.MaxDistance" /> works in tandem with <see cref="AudioStreamPlayer3D.UnitSize" />. However, unlike <see cref="AudioStreamPlayer3D.UnitSize" /> whose behavior depends on the <see cref="AudioStreamPlayer3D.AttenuationModel" />, <see cref="AudioStreamPlayer3D.MaxDistance" /> always works in a linear fashion. This can be used to prevent the <see cref="AudioStreamPlayer3D" /> from requiring audio mixing when the listener is far away, which saves CPU resources.</para>
    /// </summary>
    public float MaxDistance { get => _node.MaxDistance; set => _node.MaxDistance = value; }
    /// <summary>
    /// <para>The maximum number of sounds this node can play at the same time. Playing additional sounds after this value is reached will cut off the oldest sounds.</para>
    /// </summary>
    public int MaxPolyphony { get => _node.MaxPolyphony; set => _node.MaxPolyphony = value; }
    /// <summary>
    /// <para>Scales the panning strength for this node by multiplying the base <c>ProjectSettings.audio/general/3d_panning_strength</c> with this factor. Higher values will pan audio from left to right more dramatically than lower values.</para>
    /// </summary>
    public float PanningStrength { get => _node.PanningStrength; set => _node.PanningStrength = value; }
    /// <summary>
    /// <para>The pitch and the tempo of the audio, as a multiplier of the audio sample's sample rate.</para>
    /// </summary>
    public float PitchScale { get => _node.PitchScale; set => _node.PitchScale = value; }
    /// <summary>
    /// <para>Queues the audio to play on the next physics frame, from the given position <paramref name="fromPosition" />, in seconds.</para>
    /// </summary>
    public void Play(float fromPosition) => _node.Play(fromPosition);
    /// <summary>
    /// <para>If <c>true</c>, audio is playing or is queued to be played (see <see cref="AudioStreamPlayer3D.Play(System.Single)" />).</para>
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
    /// <para>The <see cref="AudioStream" /> resource to be played.</para>
    /// </summary>
    public AudioStream Stream { get => _node.Stream; set => _node.Stream = value; }
    /// <summary>
    /// <para>If <c>true</c>, the playback is paused. You can resume it by setting <see cref="AudioStreamPlayer3D.StreamPaused" /> to <c>false</c>.</para>
    /// </summary>
    public bool StreamPaused { get => _node.StreamPaused; set => _node.StreamPaused = value; }
    /// <summary>
    /// <para>The factor for the attenuation effect. Higher values make the sound audible over a larger distance.</para>
    /// </summary>
    public float UnitSize { get => _node.UnitSize; set => _node.UnitSize = value; }
    /// <summary>
    /// <para>The base sound level before attenuation, in decibels.</para>
    /// </summary>
    public float VolumeDb { get => _node.VolumeDb; set => _node.VolumeDb = value; }

}