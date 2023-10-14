namespace Chickensoft.GodotNodeInterfaces;

using Godot;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class HSeparatorNode : HSeparator, IHSeparator { }

/// <summary>
/// <para>A horizontal separator used for separating other controls that are arranged <b>vertically</b>. <see cref="HSeparator" /> is purely visual and normally drawn as a <see cref="StyleBoxLine" />.</para>
/// </summary>
public interface IHSeparator : ISeparator {

}