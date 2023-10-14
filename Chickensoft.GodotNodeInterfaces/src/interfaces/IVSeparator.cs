namespace Chickensoft.GodotNodeInterfaces;

using Godot;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class VSeparatorNode : VSeparator, IVSeparator { }

/// <summary>
/// <para>A vertical separator used for separating other controls that are arranged <b>horizontally</b>. <see cref="VSeparator" /> is purely visual and normally drawn as a <see cref="StyleBoxLine" />.</para>
/// </summary>
public interface IVSeparator : ISeparator {

}