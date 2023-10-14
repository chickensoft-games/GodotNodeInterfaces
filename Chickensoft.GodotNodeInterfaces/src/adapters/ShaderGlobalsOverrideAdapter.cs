namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para>Similar to how a <see cref="WorldEnvironment" /> node can be used to override the environment while a specific scene is loaded, <see cref="ShaderGlobalsOverride" /> can be used to override global shader parameters temporarily. Once the node is removed, the project-wide values for the global shader parameters are restored. See the <see cref="RenderingServer" /> <c>global_shader_parameter_*</c> methods for more information.</para>
/// <para><b>Note:</b> Only one <see cref="ShaderGlobalsOverride" /> can be used per scene. If there is more than one <see cref="ShaderGlobalsOverride" /> node in the scene tree, only the first node (in tree order) will be taken into account.</para>
/// <para><b>Note:</b> All <see cref="ShaderGlobalsOverride" /> nodes are made part of a <c>"shader_overrides_group"</c> group when they are added to the scene tree. The currently active <see cref="ShaderGlobalsOverride" /> node also has a <c>"shader_overrides_group_active"</c> group added to it. You can use this to check which <see cref="ShaderGlobalsOverride" /> node is currently active.</para>
/// </summary>
public class ShaderGlobalsOverrideAdapter : ShaderGlobalsOverride, IShaderGlobalsOverride {
  private readonly ShaderGlobalsOverride _node;

  public ShaderGlobalsOverrideAdapter(ShaderGlobalsOverride node) => _node = node;

}