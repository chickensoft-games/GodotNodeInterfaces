namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class VideoStreamPlayerNode : VideoStreamPlayer, IVideoStreamPlayer { }

/// <summary>
/// <para>A control used for playback of <see cref="VideoStream" /> resources.</para>
/// <para>Supported video formats are <a href="https://www.theora.org/">Ogg Theora</a> (<c>.ogv</c>, <see cref="VideoStreamTheora" />) and any format exposed via a GDExtension plugin.</para>
/// <para><b>Note:</b> Due to a bug, VideoStreamPlayer does not support localization remapping yet.</para>
/// <para><b>Warning:</b> On Web, video playback <i>will</i> perform poorly due to missing architecture-specific assembly optimizations.</para>
/// </summary>
public interface IVideoStreamPlayer : IControl {
    /// <summary>
    /// <para>The embedded audio track to play.</para>
    /// </summary>
    int AudioTrack { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, playback starts when the scene loads.</para>
    /// </summary>
    bool Autoplay { get; set; }
    /// <summary>
    /// <para>Amount of time in milliseconds to store in buffer while playing.</para>
    /// </summary>
    int BufferingMsec { get; set; }
    /// <summary>
    /// <para>Audio bus to use for sound playback.</para>
    /// </summary>
    StringName Bus { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the video scales to the control size. Otherwise, the control minimum size will be automatically adjusted to match the video stream's dimensions.</para>
    /// </summary>
    bool Expand { get; set; }
    /// <summary>
    /// <para>The length of the current stream, in seconds.</para>
    /// <para><b>Note:</b> For <see cref="VideoStreamTheora" /> streams (the built-in format supported by Godot), this value will always be zero, as getting the stream length is not implemented yet. The feature may be supported by video formats implemented by a GDExtension add-on.</para>
    /// </summary>
    double GetStreamLength();
    /// <summary>
    /// <para>Returns the video stream's name, or <c>"&lt;No Stream&gt;"</c> if no video stream is assigned.</para>
    /// </summary>
    string GetStreamName();
    /// <summary>
    /// <para>Returns the current frame as a <see cref="Texture2D" />.</para>
    /// </summary>
    Texture2D GetVideoTexture();
    /// <summary>
    /// <para>Returns <c>true</c> if the video is playing.</para>
    /// <para><b>Note:</b> The video is still considered playing if paused during playback.</para>
    /// </summary>
    bool IsPlaying();
    /// <summary>
    /// <para>If <c>true</c>, the video restarts when it reaches its end.</para>
    /// </summary>
    bool Loop { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the video is paused.</para>
    /// </summary>
    bool Paused { get; set; }
    /// <summary>
    /// <para>Starts the video playback from the beginning. If the video is paused, this will not unpause the video.</para>
    /// </summary>
    void Play();
    /// <summary>
    /// <para>Stops the video playback and sets the stream position to 0.</para>
    /// <para><b>Note:</b> Although the stream position will be set to 0, the first frame of the video stream won't become the current frame.</para>
    /// </summary>
    void Stop();
    /// <summary>
    /// <para>The assigned video stream. See description for supported formats.</para>
    /// </summary>
    VideoStream Stream { get; set; }
    /// <summary>
    /// <para>The current position of the stream, in seconds.</para>
    /// <para><b>Note:</b> Changing this value won't have any effect as seeking is not implemented yet, except in video formats implemented by a GDExtension add-on.</para>
    /// </summary>
    double StreamPosition { get; set; }
    /// <summary>
    /// <para>Audio volume as a linear value.</para>
    /// </summary>
    float Volume { get; set; }
    /// <summary>
    /// <para>Audio volume in dB.</para>
    /// </summary>
    float VolumeDb { get; set; }

}