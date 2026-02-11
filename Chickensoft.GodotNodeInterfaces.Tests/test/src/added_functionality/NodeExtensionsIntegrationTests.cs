namespace Chickensoft.GodotNodeInterfaces.Tests;

using System.Threading.Tasks;
using Godot;
using GoDotTest;

public class NodeExtensionsIntegrationTests(Node testScene) : NodeExtensionsBaseTests(testScene)
{
  [SetupAll]
  public void SetupAll() => RuntimeContext.IsTesting = false;

  [Setup]
  public override async Task Setup()
  {
    await base.Setup();

    _actor = ResourceLoader
      .Load<PackedScene>(UniqueIds.CUSTOM_ACTOR_SCENE)
      .Instantiate<CustomActor>();

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

  [CleanupAll]
  public void CleanupAll() => RuntimeContext.IsTesting = true;

  [Test]
  public void GetNodeEx_ShouldReturnNode_WithExistingINode()
    => _actor.GetNodeEx(_manuallyConnectedNodePath)
      .ShouldMatch(_actor.ManuallyConnectedNode);

  [Test]
  public void GetNodeEx_ShouldReturnNode_WithExistingCustomNode()
    => _actor.GetNodeEx(_manuallyConnectedCustomNodePath)
      .ShouldMatch(_actor.ManuallyConnectedCustomNode);

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
