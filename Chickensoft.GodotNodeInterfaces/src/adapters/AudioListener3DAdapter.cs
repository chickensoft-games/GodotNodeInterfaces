 namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>Once added to the scene tree and enabled using <see cref="AudioListener3D.MakeCurrent" />, this node will override the location sounds are heard from. This can be used to listen from a location different from the <see cref="Camera3D" />.</para>
/// </summary>
public class AudioListener3DAdapter : AudioListener3D, IAudioListener3D {
  private readonly AudioListener3D _node;

  public AudioListener3DAdapter(AudioListener3D node) => _node = node;
    /// <summary>
    /// <para>Disables the listener to use the current camera's listener instead.</para>
    /// </summary>
    public void ClearCurrent() => _node.ClearCurrent();
    /// <summary>
    /// <para>Returns the listener's global orthonormalized <see cref="Transform3D" />.</para>
    /// </summary>
    public Transform3D GetListenerTransform() => _node.GetListenerTransform();
    /// <summary>
    /// <para>Returns <c>true</c> if the listener was made current using <see cref="AudioListener3D.MakeCurrent" />, <c>false</c> otherwise.</para>
    /// <para><b>Note:</b> There may be more than one AudioListener3D marked as "current" in the scene tree, but only the one that was made current last will be used.</para>
    /// </summary>
    public bool IsCurrent() => _node.IsCurrent();
    /// <summary>
    /// <para>Enables the listener. This will override the current camera's listener.</para>
    /// </summary>
    public void MakeCurrent() => _node.MakeCurrent();

}