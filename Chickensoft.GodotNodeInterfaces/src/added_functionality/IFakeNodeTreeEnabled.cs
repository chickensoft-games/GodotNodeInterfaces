namespace Chickensoft.GodotNodeInterfaces;

/// <summary>
/// Godot node or Godot node adapter that allows its child nodes to be faked
/// for unit testing.
/// </summary>
public interface IFakeNodeTreeEnabled {
  /// <summary>
  /// Fake node tree used during unit testing. The fake node tree allows node
  /// paths to be associated with mock nodes using the various methods like
  /// <see cref="INode.GetChildEx{T}(int, bool)" />.
  /// </summary>
  public FakeNodeTree? FakeNodes { get; set; }
}
