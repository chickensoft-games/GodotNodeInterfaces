 namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A control used for playback of <see cref="VideoStream" /> resources.</para>
/// <para>Supported video formats are <a href="https://www.theora.org/">Ogg Theora</a> (<c>.ogv</c>, <see cref="VideoStreamTheora" />) and any format exposed via a GDExtension plugin.</para>
/// <para><b>Note:</b> Due to a bug, VideoStreamPlayer does not support localization remapping yet.</para>
/// <para><b>Warning:</b> On Web, video playback <i>will</i> perform poorly due to missing architecture-specific assembly optimizations.</para>
/// </summary>
public class VideoStreamPlayerAdapter : VideoStreamPlayer, IVideoStreamPlayer {
  private readonly VideoStreamPlayer _node;

  public VideoStreamPlayerAdapter(VideoStreamPlayer node) => _node = node;
    /// <summary>
    /// <para>The embedded audio track to play.</para>
    /// </summary>
    public int AudioTrack { get => _node.AudioTrack; set => _node.AudioTrack = value; }
    /// <summary>
    /// <para>If <c>true</c>, playback starts when the scene loads.</para>
    /// </summary>
    public bool Autoplay { get => _node.Autoplay; set => _node.Autoplay = value; }
    /// <summary>
    /// <para>Amount of time in milliseconds to store in buffer while playing.</para>
    /// </summary>
    public int BufferingMsec { get => _node.BufferingMsec; set => _node.BufferingMsec = value; }
    /// <summary>
    /// <para>Audio bus to use for sound playback.</para>
    /// </summary>
    public StringName Bus { get => _node.Bus; set => _node.Bus = value; }
    /// <summary>
    /// <para>If <c>true</c>, the video scales to the control size. Otherwise, the control minimum size will be automatically adjusted to match the video stream's dimensions.</para>
    /// </summary>
    public bool Expand { get => _node.Expand; set => _node.Expand = value; }
    /// <summary>
    /// <para>The length of the current stream, in seconds.</para>
    /// <para><b>Note:</b> For <see cref="VideoStreamTheora" /> streams (the built-in format supported by Godot), this value will always be zero, as getting the stream length is not implemented yet. The feature may be supported by video formats implemented by a GDExtension add-on.</para>
    /// </summary>
    public double GetStreamLength() => _node.GetStreamLength();
    /// <summary>
    /// <para>Returns the video stream's name, or <c>"&lt;No Stream&gt;"</c> if no video stream is assigned.</para>
    /// </summary>
    public string GetStreamName() => _node.GetStreamName();
    /// <summary>
    /// <para>Returns the current frame as a <see cref="Texture2D" />.</para>
    /// </summary>
    public Texture2D GetVideoTexture() => _node.GetVideoTexture();
    /// <summary>
    /// <para>Returns <c>true</c> if the video is playing.</para>
    /// <para><b>Note:</b> The video is still considered playing if paused during playback.</para>
    /// </summary>
    public bool IsPlaying() => _node.IsPlaying();
    /// <summary>
    /// <para>If <c>true</c>, the video restarts when it reaches its end.</para>
    /// </summary>
    public bool Loop { get => _node.Loop; set => _node.Loop = value; }
    /// <summary>
    /// <para>If <c>true</c>, the video is paused.</para>
    /// </summary>
    public bool Paused { get => _node.Paused; set => _node.Paused = value; }
    /// <summary>
    /// <para>Starts the video playback from the beginning. If the video is paused, this will not unpause the video.</para>
    /// </summary>
    public void Play() => _node.Play();
    /// <summary>
    /// <para>Stops the video playback and sets the stream position to 0.</para>
    /// <para><b>Note:</b> Although the stream position will be set to 0, the first frame of the video stream won't become the current frame.</para>
    /// </summary>
    public void Stop() => _node.Stop();
    /// <summary>
    /// <para>The assigned video stream. See description for supported formats.</para>
    /// </summary>
    public VideoStream Stream { get => _node.Stream; set => _node.Stream = value; }
    /// <summary>
    /// <para>The current position of the stream, in seconds.</para>
    /// <para><b>Note:</b> Changing this value won't have any effect as seeking is not implemented yet, except in video formats implemented by a GDExtension add-on.</para>
    /// </summary>
    public double StreamPosition { get => _node.StreamPosition; set => _node.StreamPosition = value; }
    /// <summary>
    /// <para>Audio volume as a linear value.</para>
    /// </summary>
    public float Volume { get => _node.Volume; set => _node.Volume = value; }
    /// <summary>
    /// <para>Audio volume in dB.</para>
    /// </summary>
    public float VolumeDb { get => _node.VolumeDb; set => _node.VolumeDb = value; }

}