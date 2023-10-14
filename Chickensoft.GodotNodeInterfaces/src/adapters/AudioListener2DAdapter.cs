namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>Once added to the scene tree and enabled using <see cref="AudioListener2D.MakeCurrent" />, this node will override the location sounds are heard from. Only one <see cref="AudioListener2D" /> can be current. Using <see cref="AudioListener2D.MakeCurrent" /> will disable the previous <see cref="AudioListener2D" />.</para>
/// <para>If there is no active <see cref="AudioListener2D" /> in the current <see cref="Viewport" />, center of the screen will be used as a hearing point for the audio. <see cref="AudioListener2D" /> needs to be inside <see cref="SceneTree" /> to function.</para>
/// </summary>
public class AudioListener2DAdapter : AudioListener2D, IAudioListener2D {
  private readonly AudioListener2D _node;

  public AudioListener2DAdapter(AudioListener2D node) => _node = node;
    /// <summary>
    /// <para>Disables the <see cref="AudioListener2D" />. If it's not set as current, this method will have no effect.</para>
    /// </summary>
    public void ClearCurrent() => _node.ClearCurrent();
    /// <summary>
    /// <para>Returns <c>true</c> if this <see cref="AudioListener2D" /> is currently active.</para>
    /// </summary>
    public bool IsCurrent() => _node.IsCurrent();
    /// <summary>
    /// <para>Makes the <see cref="AudioListener2D" /> active, setting it as the hearing point for the sounds. If there is already another active <see cref="AudioListener2D" />, it will be disabled.</para>
    /// <para>This method will have no effect if the <see cref="AudioListener2D" /> is not added to <see cref="SceneTree" />.</para>
    /// </summary>
    public void MakeCurrent() => _node.MakeCurrent();

}