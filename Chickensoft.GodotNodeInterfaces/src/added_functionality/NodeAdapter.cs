namespace Chickensoft.GodotNodeInterfaces;

public partial class NodeAdapter : INodeAdapter, IFakeNodeTreeEnabled
{
  /// <summary>
  /// Fake node tree used during unit testing. The fake node tree allows node
  /// paths to be associated with mock nodes using the various methods like
  /// <see cref="INode.GetChildEx{T}(int, bool)" />.
  /// </summary>
  public FakeNodeTree? FakeNodes { get; set; }
}
