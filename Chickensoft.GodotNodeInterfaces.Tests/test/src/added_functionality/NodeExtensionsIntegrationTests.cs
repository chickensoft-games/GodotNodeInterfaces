namespace Chickensoft.GodotNodeInterfaces.Tests;

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Godot;
using GoDotTest;
using Shouldly;

public class NodeExtensionsIntegrationTests(Node testScene) : TestClass(testScene)
{
  private const string RUNTIME_NODE_NAME = "RuntimeNode";
  private static readonly NodePath _runtimeINodePath = new(RUNTIME_NODE_NAME);
  private INode _runtimeINode = default!;

  private const string RUNTIME_CUSTOM_NODE_NAME = "RuntimeCustomNode";
  private static readonly NodePath _runtimeCustomNodePath = new(RUNTIME_CUSTOM_NODE_NAME);
  private CustomNode _runtimeCustomNode = default!;

  private const string EXISTING_NODES_PATTERN = "Connected";
  private const string RUNTIME_NODES_PATTERN = "Runtime";

  private static readonly NodePath _manuallyConnectedNodePath = new(nameof(IntegrationTestScene.ManuallyConnectedNode));
  private static readonly NodePath _manuallyConnectedCustomNodePath = new(nameof(IntegrationTestScene.ManuallyConnectedCustomNode));

  private INode[] _builtInNodes = [];
  private INode[] _customNodes = [];

  private IntegrationTestScene _scene = default!;

  [SetupAll]
  public void SetupAll() => RuntimeContext.IsTesting = false;

  [Setup]
  public async Task Setup()
  {
    _scene = ResourceLoader
      .Load<PackedScene>(UniqueIds.INTEGRATION_TEST_SCENE)
      .Instantiate<IntegrationTestScene>();

    var sceneTree = TestScene.GetTree();
    sceneTree.Root.CallDeferred(Node.MethodName.AddChild, _scene);
    await sceneTree.ToSignal(sceneTree, SceneTree.SignalName.ProcessFrame);

    _runtimeINode = GodotInterfaces.Adapt<INode>(new Node { Name = RUNTIME_NODE_NAME });
    _runtimeCustomNode = new CustomNode { Name = RUNTIME_CUSTOM_NODE_NAME };

    _builtInNodes = [
      _scene.AutoConnectedNode,
      _scene.ManuallyConnectedNode,
      _runtimeINode
    ];

    _customNodes = [
      _scene.AutoConnectedCustomNode,
      _scene.ManuallyConnectedCustomNode,
      _runtimeCustomNode
    ];
  }

  [Cleanup]
  public void Cleanup()
  {
    foreach (var child in _builtInNodes.Concat(_customNodes).ToArray())
    {
      child?.QueueFree();
    }
    _scene.QueueFree();
  }

  [CleanupAll]
  public void CleanupAll() => RuntimeContext.IsTesting = true;

  [Test]
  public void AddChildEx_ShouldUpdateSceneTree_WithINode()
  {
    _scene.AddChildEx(_runtimeINode);

    _scene.GetChildrenEx().ShouldContain(MatchingAdapterFor(_runtimeINode));
  }

  [Test]
  public void AddChildEx_ShouldUpdateSceneTree_WithCustomNode()
  {
    _scene.AddChildEx(_runtimeCustomNode);

    _scene.GetChildrenEx().ShouldContain(_runtimeCustomNode);
  }

  [Test]
  public void FindChildEx_ShouldReturnNull_WithNoMatch()
    => _scene.FindChildEx(RUNTIME_NODE_NAME).ShouldBeNull();

  [Test]
  public void FindChildEx_ShouldReturnMatchingNode_WithExistingINode()
  {
    var child = _scene.FindChildEx(nameof(IntegrationTestScene.ManuallyConnectedNode));

    child.ShouldNotBeNull();
    child.GetTargetObj<Node>().ShouldBe(_scene.ManuallyConnectedNode.GetTargetObj<Node>());
  }

  [Test]
  public void FindChildEx_ShouldReturnMatchingNode_WithExistingCustomNode()
  {
    var child = _scene.FindChildEx(nameof(IntegrationTestScene.ManuallyConnectedCustomNode));

    child.ShouldNotBeNull();
    child.ShouldBe(_scene.ManuallyConnectedCustomNode);
  }

  [Test]
  public void FindChildEx_ShouldReturnMatchingNode_WithRuntimeINode()
  {
    _scene.AddChildEx(_runtimeINode);

    // https://forum.godotengine.org/t/find-child-wont-find-child-that-is-added-during-game/74330/6
    _runtimeINode.SetOwner(_scene);

    var child = _scene.FindChildEx(RUNTIME_NODE_NAME);

    child.ShouldNotBeNull();
    child.GetTargetObj<Node>().ShouldBe(_runtimeINode.GetTargetObj<Node>());
  }

  [Test]
  public void FindChildEx_ShouldReturnMatchingNode_WithRuntimeCustomNode()
  {
    _scene.AddChildEx(_runtimeCustomNode);

    // https://forum.godotengine.org/t/find-child-wont-find-child-that-is-added-during-game/74330/6
    _runtimeCustomNode.SetOwner(_scene);

    var child = _scene.FindChildEx(RUNTIME_CUSTOM_NODE_NAME);

    child.ShouldNotBeNull();
    child.ShouldBe(_runtimeCustomNode);
  }

  [Test]
  public void FindChildrenEx_ShouldReturnMatchingNodes_WithExistingNodes()
  {
    foreach (var child in _scene.FindChildrenEx(EXISTING_NODES_PATTERN))
    {
      if (child is NodeAdapter)
      {
        _builtInNodes
          .Where(x => x.Name.ToString().Contains(EXISTING_NODES_PATTERN)).ToArray()
          .ShouldContain(MatchingAdapterFor(child));
      }
      else
      {
        _customNodes
          .Where(x => x.Name.ToString().Contains(EXISTING_NODES_PATTERN)).ToArray()
          .ShouldContain(child);
      }
    }
  }

  [Test]
  public void FindChildrenEx_ShouldReturnMatchingNodes_WithNodesAddedAtRuntime()
  {
    _scene.AddChildEx(_runtimeINode);
    _scene.AddChildEx(_runtimeCustomNode);

    foreach (var child in _scene.FindChildrenEx(RUNTIME_NODES_PATTERN))
    {
      if (child is NodeAdapter)
      {
        _builtInNodes
          .Where(x => x.Name.ToString().Contains(RUNTIME_NODES_PATTERN)).ToArray()
          .ShouldContain(MatchingAdapterFor(child));
      }
      else
      {
        _customNodes
          .Where(x => x.Name.ToString().Contains(RUNTIME_NODES_PATTERN)).ToArray()
          .ShouldContain(child);
      }
    }
  }

  [Test]
  public void GetChildEx_ShouldReturnNode()
  {
    _scene.AddChildEx(_runtimeINode);
    _scene.AddChildEx(_runtimeCustomNode);

    for (var i = 0; i < _scene.GetChildCountEx(); i++)
    {
      var child = _scene.GetChildEx(i);

      if (child is NodeAdapter)
      {
        _builtInNodes.ShouldContain(MatchingAdapterFor(child));
      }
      else
      {
        _customNodes.ShouldContain(child);
      }
    }
  }

  [Test]
  public void GetChildExOfT_ShouldReturnNode()
  {
    _scene.AddChildEx(_runtimeINode);
    _scene.AddChildEx(_runtimeCustomNode);

    for (var i = 0; i < _scene.GetChildCountEx(); i++)
    {
      var child = _scene.GetChildEx<INode>(i);

      if (child is NodeAdapter)
      {
        _builtInNodes.ShouldContain(MatchingAdapterFor(child));
      }
      else
      {
        _customNodes.ShouldContain(child);
      }
    }
  }

  [Test]
  public void GetChildCountEx_ShouldReturnCount_WithExistingNodes()
    => _scene.GetChildCountEx().ShouldBe(4);

  [Test]
  public void GetChildCountEx_ShouldReturnCount_WithRuntimeNodes()
  {
    _scene.AddChildEx(_runtimeINode);
    _scene.AddChildEx(_runtimeCustomNode);

    _scene.GetChildCountEx().ShouldBe(6);
  }

  [Test]
  public void GetChildrenEx_ShouldReturnAllNodes()
  {
    _scene.AddChildEx(_runtimeINode);
    _scene.AddChildEx(_runtimeCustomNode);

    foreach (var child in _scene.GetChildrenEx())
    {
      if (child is NodeAdapter)
      {
        _builtInNodes.ShouldContain(MatchingAdapterFor(child));
      }
      else
      {
        _customNodes.ShouldContain(child);
      }
    }
  }

  [Test]
  public void GetNodeEx_ShouldReturnNode_WithExistingINode()
  {
    var node = _scene.GetNodeEx(_manuallyConnectedNodePath);

    node.ShouldNotBeNull();
    node.GetTargetObj<Node>().ShouldBe(_scene.ManuallyConnectedNode.GetTargetObj<Node>());
  }

  [Test]
  public void GetNodeEx_ShouldReturnNode_WithExistingCustomNode()
    => _scene.GetNodeEx(_manuallyConnectedCustomNodePath)
      .ShouldBe(_scene.ManuallyConnectedCustomNode);

  [Test]
  public void GetNodeEx_ShouldReturnNode_WithRuntimeINode()
  {
    _scene.AddChildEx(_runtimeINode);

    var node = _scene.GetNodeEx(_runtimeINodePath);

    node.ShouldNotBeNull();
    node.GetTargetObj<Node>().ShouldBe(_runtimeINode.GetTargetObj<Node>());
  }

  [Test]
  public void GetNodeEx_ShouldReturnNode_WithRuntimeCustomNode()
  {
    _scene.AddChildEx(_runtimeCustomNode);

    _scene.GetNodeEx(_runtimeCustomNodePath).ShouldBe(_runtimeCustomNode);
  }

  [Test]
  public void GetNodeOrNullEx_ShouldReturnNull_WithNoMatch()
    => _scene.GetNodeOrNullEx(RUNTIME_NODE_NAME).ShouldBeNull();

  [Test]
  public void GetNodeOrNullEx_ShouldReturnNode_WithExistingINode()
  {
    var node = _scene.GetNodeOrNullEx(nameof(IntegrationTestScene.ManuallyConnectedNode));

    node.ShouldNotBeNull();
    node.GetTargetObj<Node>().ShouldBe(_scene.ManuallyConnectedNode.GetTargetObj<Node>());
  }

  [Test]
  public void GetNodeOrNullEx_ShouldReturnNode_WithExistingCustomNode()
    => _scene.GetNodeOrNullEx(nameof(IntegrationTestScene.ManuallyConnectedCustomNode))
      .ShouldBe(_scene.ManuallyConnectedCustomNode);

  [Test]
  public void GetNodeOrNullEx_ShouldReturnNode_WithRuntimeINode()
  {
    _scene.AddChildEx(_runtimeINode);

    var node = _scene.GetNodeOrNullEx(RUNTIME_NODE_NAME);

    node.ShouldNotBeNull();
    node.GetTargetObj<Node>().ShouldBe(_runtimeINode.GetTargetObj<Node>());
  }

  [Test]
  public void GetNodeOrNullEx_ShouldReturnNode_WithRuntimeCustomNode()
  {
    _scene.AddChildEx(_runtimeCustomNode);

    _scene.GetNodeOrNullEx(RUNTIME_CUSTOM_NODE_NAME).ShouldBe(_runtimeCustomNode);
  }

  [Test]
  public void GetNodeOrNullExOfT_ShouldReturnNull_WithNoMatch()
    => _scene.GetNodeOrNullEx<INode>(RUNTIME_NODE_NAME).ShouldBeNull();

  [Test]
  public void GetNodeOrNullExOfT_ShouldReturnNode_WithExistingINode()
  {
    var node = _scene.GetNodeOrNullEx<INode>(nameof(IntegrationTestScene.ManuallyConnectedNode));

    node.ShouldNotBeNull();
    node.GetTargetObj<Node>().ShouldBe(_scene.ManuallyConnectedNode.GetTargetObj<Node>());
  }

  [Test]
  public void GetNodeOrNullExOfT_ShouldReturnNode_WithExistingCustomNode()
    => _scene.GetNodeOrNullEx<INode>(nameof(IntegrationTestScene.ManuallyConnectedCustomNode))
      .ShouldBe(_scene.ManuallyConnectedCustomNode);

  [Test]
  public void GetNodeOrNullExOfT_ShouldReturnNode_WithRuntimeINode()
  {
    _scene.AddChildEx(_runtimeINode);

    var node = _scene.GetNodeOrNullEx<INode>(RUNTIME_NODE_NAME);

    node.ShouldNotBeNull();
    node.GetTargetObj<Node>().ShouldBe(_runtimeINode.GetTargetObj<Node>());
  }

  [Test]
  public void GetNodeOrNullExOfT_ShouldReturnNode_WithRuntimeCustomNode()
  {
    _scene.AddChildEx(_runtimeCustomNode);

    _scene.GetNodeOrNullEx<ICustomNode>(RUNTIME_CUSTOM_NODE_NAME).ShouldBe(_runtimeCustomNode);
  }

  [Test]
  public void HasNodeEx_ShouldReturnFalse_WithNoMatch()
    => _scene.HasNodeEx(RUNTIME_NODE_NAME).ShouldBeFalse();

  [Test]
  public void HasNodeEx_ShouldReturnTrue_WithExistingINode()
    => _scene.HasNodeEx(_manuallyConnectedNodePath).ShouldBeTrue();

  [Test]
  public void HasNodeEx_ShouldReturnTrue_WithExistingCustomNode()
    => _scene.HasNodeEx(_manuallyConnectedCustomNodePath).ShouldBeTrue();

  [Test]
  public void HasNodeEx_ShouldReturnTrue_WithRuntimeINode()
  {
    _scene.AddChildEx(_runtimeINode);

    _scene.HasNodeEx(RUNTIME_NODE_NAME).ShouldBeTrue();
  }

  [Test]
  public void HasNodeEx_ShouldReturnTrue_WithRuntimeCustomNode()
  {
    _scene.AddChildEx(_runtimeCustomNode);

    _scene.HasNodeEx(RUNTIME_CUSTOM_NODE_NAME).ShouldBeTrue();
  }

  [Test]
  public void RemoveChildEx_ShouldUpdateSceneTree_WithExistingINode()
  {
    _scene.RemoveChildEx(_scene.ManuallyConnectedNode);

    _scene.GetChildrenEx().ShouldNotContain(_scene.ManuallyConnectedNode);
  }

  [Test]
  public void RemoveChildEx_ShouldUpdateSceneTree_WithExistingCustomNode()
  {
    _scene.RemoveChildEx(_scene.ManuallyConnectedCustomNode);

    _scene.GetChildrenEx().ShouldNotContain(_scene.ManuallyConnectedCustomNode);
  }

  [Test]
  public void RemoveChildEx_ShouldUpdateSceneTree_WithRuntimeINode()
  {
    _scene.AddChildEx(_runtimeINode);
    _scene.GetChildrenEx().ShouldContain(MatchingAdapterFor(_runtimeINode));

    _scene.RemoveChildEx(_runtimeINode);

    _scene.GetChildrenEx().ShouldNotContain(MatchingAdapterFor(_runtimeINode));
  }

  [Test]
  public void RemoveChildEx_ShouldUpdateSceneTree_WithRuntimeCustomNode()
  {
    _scene.AddChildEx(_runtimeCustomNode);
    _scene.GetChildrenEx().ShouldContain(_runtimeCustomNode);

    _scene.RemoveChildEx(_runtimeCustomNode);

    _scene.GetChildrenEx().ShouldNotContain(_runtimeCustomNode);
  }

  private static Expression<Func<INode, bool>> MatchingAdapterFor(INode iNode) => x =>
    x is NodeAdapter
    && x.GetTargetObj<Node>() == iNode.GetTargetObj<Node>();
}
