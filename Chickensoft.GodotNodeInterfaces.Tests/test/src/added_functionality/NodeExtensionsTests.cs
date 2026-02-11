namespace Chickensoft.GodotNodeInterfaces.Tests;

using System.Threading.Tasks;
using Chickensoft.AutoInject;
using Chickensoft.GodotNodeInterfaces;
using Godot;
using GoDotTest;
using Moq;
using Shouldly;

public class NodeExtensionsTests(Node testScene) : NodeExtensionsBaseTests(testScene)
{
  private Mock<INode> _mockAutoConnectedNode = default!;
  private Mock<ICustomNode> _mockAutoConnectedCustomNode = default!;
  private Mock<INode> _mockManuallyConnectedNode = default!;
  private Mock<ICustomNode> _mockManuallyConnectedCustomNode = default!;

  [Setup]
  public override async Task Setup()
  {
    await base.Setup();

    _mockAutoConnectedNode = new();
    _mockAutoConnectedNode.Setup(x => x.Name).Returns(_autoConnectedNodeStringName);

    _mockAutoConnectedCustomNode = new();
    _mockAutoConnectedCustomNode.Setup(x => x.Name).Returns(_autoConnectedCustomNodeStringName);

    _mockManuallyConnectedNode = new();
    _mockManuallyConnectedNode.Setup(x => x.Name).Returns(_manuallyConnectedNodeStringName);

    _mockManuallyConnectedCustomNode = new();
    _mockManuallyConnectedCustomNode.Setup(x => x.Name).Returns(_manuallyConnectedCustomNodeStringName);

    _actor = new();
    _actor.FakeNodeTree(new()
    {
      [$"%{nameof(CustomActor.AutoConnectedNode)}"] = _mockAutoConnectedNode.Object,
      [$"%{nameof(CustomActor.AutoConnectedCustomNode)}"] = _mockAutoConnectedCustomNode.Object,
      [nameof(CustomActor.ManuallyConnectedNode)] = _mockManuallyConnectedNode.Object,
      [nameof(CustomActor.ManuallyConnectedCustomNode)] = _mockManuallyConnectedCustomNode.Object
    });

    var sceneTree = TestScene.GetTree();
    sceneTree.Root.CallDeferred(Node.MethodName.AddChild, _actor);
    await sceneTree.ToSignal(sceneTree, SceneTree.SignalName.ProcessFrame);

    _builtInNodes = [
      _actor.AutoConnectedNode,
      _actor.ManuallyConnectedNode,
      _runtimeNode
    ];

    _customNodes = [
      _actor.AutoConnectedCustomNode,
      _actor.ManuallyConnectedCustomNode,
      _runtimeCustomNode
    ];
  }

  [Cleanup]
  public override void Cleanup() => base.Cleanup();

  [Test]
  public void AddChildEx_ShouldUpdateSceneTree_WithMockINode()
  {
    var otherFakeChildNode = new Mock<INode>();

    _actor.AddChildEx(otherFakeChildNode.Object);

    _actor.GetChildrenEx().ShouldContain(otherFakeChildNode.Object);
  }

  [Test]
  public void AddChildEx_ShouldUpdateSceneTree_WithMockCustomNode()
  {
    var otherFakeChildNode = new Mock<ICustomNode>();

    _actor.AddChildEx(otherFakeChildNode.Object);

    _actor.GetChildrenEx().ShouldContain(otherFakeChildNode.Object);
  }

  [Test]
  public void FindChildEx_ShouldReturnMatchingNode_WithExistingMockNode()
    => _actor.FindChildEx(nameof(CustomActor.ManuallyConnectedNode))
      .ShouldMatch(_mockManuallyConnectedNode.Object);

  [Test]
  public void FindChildEx_ShouldReturnMatchingNode_WithExistingMockCustomNode()
    => _actor.FindChildEx(nameof(CustomActor.ManuallyConnectedCustomNode))
      .ShouldMatch(_mockManuallyConnectedCustomNode.Object);

  [Test]
  public void GetNodeEx_ShouldReturnNode_WithExistingMockNode()
    => _actor.GetNodeEx(_manuallyConnectedNodePath)
      .ShouldMatch(_mockManuallyConnectedNode.Object);

  [Test]
  public void GetNodeEx_ShouldReturnNode_WithExistingMockCustomNode()
  => _actor.GetNodeEx(_manuallyConnectedCustomNodePath)
    .ShouldMatch(_mockManuallyConnectedCustomNode.Object);

  [Test]
  public void GetNodeOrNullEx_ShouldReturnNode_WithExistingMockNode()
    => _actor.GetNodeOrNullEx(_manuallyConnectedNodePath)
      .ShouldMatch(_mockManuallyConnectedNode.Object);

  [Test]
  public void GetNodeOrNullEx_ShouldReturnNode_WithExistingMockCustomNode()
    => _actor.GetNodeOrNullEx(_manuallyConnectedCustomNodePath)
      .ShouldMatch(_mockManuallyConnectedCustomNode.Object);

  [Test]
  public void GetNodeOrNullExOfT_ShouldReturnNode_WithExistingMockNode()
    => _actor.GetNodeOrNullEx<INode>(_manuallyConnectedNodePath)
      .ShouldMatch(_mockManuallyConnectedNode.Object);

  [Test]
  public void GetNodeOrNullExOfT_ShouldReturnNode_WithExistingMockCustomNode()
    => _actor.GetNodeOrNullEx<ICustomNode>(_manuallyConnectedCustomNodePath)
      .ShouldMatch(_mockManuallyConnectedCustomNode.Object);

  [Test]
  public void RemoveChildEx_ShouldUpdateSceneTree_WithExistingMockNode()
  {
    _actor.GetChildrenEx().ShouldContain(x => x.IsMatch(_mockManuallyConnectedNode.Object));

    _actor.RemoveChildEx(_mockManuallyConnectedNode.Object);

    _actor.GetChildrenEx().ShouldNotContain(x => x.IsMatch(_mockManuallyConnectedNode.Object));
  }

  [Test]
  public void RemoveChildEx_ShouldUpdateSceneTree_WithExistingMockCustomNode()
  {
    _actor.GetChildrenEx().ShouldContain(x => x.IsMatch(_mockManuallyConnectedCustomNode.Object));

    _actor.RemoveChildEx(_mockManuallyConnectedCustomNode.Object);

    _actor.GetChildrenEx().ShouldNotContain(x => x.IsMatch(_mockManuallyConnectedCustomNode.Object));
  }

  // TODO: Add more Mock test cases to the unit tests that mirror the integration tests.

  #region Base Class Tests

  [Test]
  public override void AddChildEx_ShouldUpdateSceneTree_WithNode()
    => base.AddChildEx_ShouldUpdateSceneTree_WithNode();

  [Test]
  public override void AddChildEx_ShouldUpdateSceneTree_WithCustomNode()
    => base.AddChildEx_ShouldUpdateSceneTree_WithCustomNode();

  [Test]
  public override void FindChildEx_ShouldReturnNull_WithNoMatch()
    => base.FindChildEx_ShouldReturnNull_WithNoMatch();

  [Test]
  public override void FindChildEx_ShouldReturnMatchingNode_WithExistingNode()
    => base.FindChildEx_ShouldReturnMatchingNode_WithExistingNode();

  [Test]
  public override void FindChildEx_ShouldReturnMatchingNode_WithExistingCustomNode()
    => base.FindChildEx_ShouldReturnMatchingNode_WithExistingCustomNode();

  [Test]
  public override void FindChildEx_ShouldReturnMatchingNode_WithRuntimeNode()
    => base.FindChildEx_ShouldReturnMatchingNode_WithRuntimeNode();

  [Test]
  public override void FindChildEx_ShouldReturnMatchingNode_WithRuntimeCustomNode()
    => base.FindChildEx_ShouldReturnMatchingNode_WithRuntimeCustomNode();

  [Test]
  public override void FindChildrenEx_ShouldReturnEmptyArray_WithNoMatch()
    => base.FindChildrenEx_ShouldReturnEmptyArray_WithNoMatch();

  [Test]
  public override void FindChildrenEx_ShouldReturnMatchingNodes_WithExistingNodes()
    => base.FindChildrenEx_ShouldReturnMatchingNodes_WithExistingNodes();

  [Test]
  public override void FindChildrenEx_ShouldReturnMatchingNodes_WithNodesAddedAtRuntime()
    => base.FindChildrenEx_ShouldReturnMatchingNodes_WithNodesAddedAtRuntime();

  [Test]
  public override void FindChildrenEx_ShouldReturnAllNodes_WithWildcard()
    => base.FindChildrenEx_ShouldReturnAllNodes_WithWildcard();

  [Test]
  public override void GetChildEx_ShouldReturnNull_WithInvalidIndex()
    => base.GetChildEx_ShouldReturnNull_WithInvalidIndex();

  [Test]
  public override void GetChildEx_ShouldReturnNode()
    => base.GetChildEx_ShouldReturnNode();

  [Test]
  public override void GetChildExOfT_ShouldReturnNull_WithInvalidIndex()
    => base.GetChildExOfT_ShouldReturnNull_WithInvalidIndex();

  [Test]
  public override void GetChildExOfT_ShouldThrow_WithIncorrectTypeSpecified()
    => base.GetChildExOfT_ShouldThrow_WithIncorrectTypeSpecified();

  [Test]
  public override void GetChildExOfT_ShouldReturnNode()
    => base.GetChildExOfT_ShouldReturnNode();

  [Test]
  public override void GetChildCountEx_ShouldReturnCount_WithExistingNodes()
    => base.GetChildCountEx_ShouldReturnCount_WithExistingNodes();

  [Test]
  public override void GetChildCountEx_ShouldReturnCount_WithRuntimeNodes()
    => base.GetChildCountEx_ShouldReturnCount_WithRuntimeNodes();

  [Test]
  public override void GetChildrenEx_ShouldReturnAllNodes()
    => base.GetChildrenEx_ShouldReturnAllNodes();

  [Test]
  public override void GetNodeEx_ShouldReturnNull_WithNoMatch()
    => base.GetNodeEx_ShouldReturnNull_WithNoMatch();

  [Test]
  public override void GetNodeEx_ShouldReturnNode_WithRuntimeNode()
    => base.GetNodeEx_ShouldReturnNode_WithRuntimeNode();

  [Test]
  public override void GetNodeEx_ShouldReturnNode_WithRuntimeCustomNode()
    => base.GetNodeEx_ShouldReturnNode_WithRuntimeCustomNode();

  [Test]
  public override void GetNodeOrNullEx_ShouldReturnNull_WithNoMatch()
    => base.GetNodeOrNullEx_ShouldReturnNull_WithNoMatch();

  [Test]
  public override void GetNodeOrNullEx_ShouldReturnNode_WithExistingNode()
    => base.GetNodeOrNullEx_ShouldReturnNode_WithExistingNode();

  [Test]
  public override void GetNodeOrNullEx_ShouldReturnNode_WithExistingCustomNode()
    => base.GetNodeOrNullEx_ShouldReturnNode_WithExistingCustomNode();

  [Test]
  public override void GetNodeOrNullEx_ShouldReturnNode_WithRuntimeNode()
    => base.GetNodeOrNullEx_ShouldReturnNode_WithRuntimeNode();

  [Test]
  public override void GetNodeOrNullEx_ShouldReturnNode_WithRuntimeCustomNode()
    => base.GetNodeOrNullEx_ShouldReturnNode_WithRuntimeCustomNode();

  [Test]
  public override void GetNodeOrNullExOfT_ShouldReturnNull_WithNoMatch()
    => base.GetNodeOrNullExOfT_ShouldReturnNull_WithNoMatch();

  [Test]
  public override void GetNodeOrNullExOfT_ShouldReturnNode_WithExistingNode()
    => base.GetNodeOrNullExOfT_ShouldReturnNode_WithExistingNode();

  [Test]
  public override void GetNodeOrNullExOfT_ShouldReturnNode_WithExistingCustomNode()
    => base.GetNodeOrNullExOfT_ShouldReturnNode_WithExistingCustomNode();

  [Test]
  public override void GetNodeOrNullExOfT_ShouldReturnNode_WithRuntimeNode()
    => base.GetNodeOrNullExOfT_ShouldReturnNode_WithRuntimeNode();

  [Test]
  public override void GetNodeOrNullExOfT_ShouldReturnNode_WithRuntimeCustomNode()
    => base.GetNodeOrNullExOfT_ShouldReturnNode_WithRuntimeCustomNode();

  [Test]
  public override void HasNodeEx_ShouldReturnFalse_WithNoMatch()
    => base.HasNodeEx_ShouldReturnFalse_WithNoMatch();

  [Test]
  public override void HasNodeEx_ShouldReturnTrue_WithExistingNode()
    => base.HasNodeEx_ShouldReturnTrue_WithExistingNode();

  [Test]
  public override void HasNodeEx_ShouldReturnTrue_WithExistingCustomNode()
    => base.HasNodeEx_ShouldReturnTrue_WithExistingCustomNode();

  [Test]
  public override void HasNodeEx_ShouldReturnTrue_WithRuntimeNode()
    => base.HasNodeEx_ShouldReturnTrue_WithRuntimeNode();

  [Test]
  public override void HasNodeEx_ShouldReturnTrue_WithRuntimeCustomNode()
    => base.HasNodeEx_ShouldReturnTrue_WithRuntimeCustomNode();

  [Test]
  public override void RemoveChildEx_ShouldUpdateSceneTree_WithExistingNode()
    => base.RemoveChildEx_ShouldUpdateSceneTree_WithExistingNode();

  [Test]
  public override void RemoveChildEx_ShouldUpdateSceneTree_WithExistingCustomNode()
    => base.RemoveChildEx_ShouldUpdateSceneTree_WithExistingCustomNode();

  [Test]
  public override void RemoveChildEx_ShouldUpdateSceneTree_WithRuntimeNode()
    => base.RemoveChildEx_ShouldUpdateSceneTree_WithRuntimeNode();

  [Test]
  public override void RemoveChildEx_ShouldUpdateSceneTree_WithRuntimeCustomNode()
    => base.RemoveChildEx_ShouldUpdateSceneTree_WithRuntimeCustomNode();

  #endregion Base Class Tests
}
