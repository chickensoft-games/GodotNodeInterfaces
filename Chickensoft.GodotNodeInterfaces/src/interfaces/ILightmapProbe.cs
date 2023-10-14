namespace Chickensoft.GodotNodeInterfaces;

using Godot;


/// <summary>
/// <para><see cref="LightmapProbe" /> represents the position of a single manually placed probe for dynamic object lighting with <see cref="LightmapGI" />.</para>
/// <para>Typically, <see cref="LightmapGI" /> probes are placed automatically by setting <see cref="LightmapGI.GenerateProbesSubdiv" /> to a value other than <see cref="LightmapGI.GenerateProbes.Disabled" />. By creating <see cref="LightmapProbe" /> nodes before baking lightmaps, you can add more probes in specific areas for greater detail, or disable automatic generation and rely only on manually placed probes instead.</para>
/// </summary>
public interface ILightmapProbe : INode3D {

}