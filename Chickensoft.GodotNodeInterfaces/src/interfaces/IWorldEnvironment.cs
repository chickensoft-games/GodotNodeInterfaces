namespace Chickensoft.GodotNodeInterfaces;

using Godot;


/// <summary>
/// <para>The <see cref="WorldEnvironment" /> node is used to configure the default <see cref="Environment" /> for the scene.</para>
/// <para>The parameters defined in the <see cref="WorldEnvironment" /> can be overridden by an <see cref="Environment" /> node set on the current <see cref="Camera3D" />. Additionally, only one <see cref="WorldEnvironment" /> may be instantiated in a given scene at a time.</para>
/// <para>The <see cref="WorldEnvironment" /> allows the user to specify default lighting parameters (e.g. ambient lighting), various post-processing effects (e.g. SSAO, DOF, Tonemapping), and how to draw the background (e.g. solid color, skybox). Usually, these are added in order to improve the realism/color balance of the scene.</para>
/// </summary>
public interface IWorldEnvironment {
    /// <summary>
    /// <para>The <see cref="Environment" /> resource used by this <see cref="WorldEnvironment" />, defining the default properties.</para>
    /// </summary>
    Godot.Environment Environment { get; set; }
    /// <summary>
    /// <para>The default <see cref="CameraAttributes" /> resource to use if none set on the <see cref="Camera3D" />.</para>
    /// </summary>
    CameraAttributes CameraAttributes { get; set; }

}