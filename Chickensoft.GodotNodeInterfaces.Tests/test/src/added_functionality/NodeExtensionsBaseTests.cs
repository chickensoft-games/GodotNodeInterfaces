namespace Chickensoft.GodotNodeInterfaces.Tests;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chickensoft.GodotNodeInterfaces;
using Chickensoft.GoDotTest;
using Godot;
using Shouldly;

public class NodeExtensionsBaseTests(Node testScene) : TestClass(testScene)
{
  protected static readonly StringName _autoConnectedNodeStringName = new(nameof(CustomActor.AutoConnectedNode));
  protected static readonly NodePath _autoConnectedNodePath = new(nameof(CustomActor.AutoConnectedNode));

  protected static readonly StringName _autoConnectedCustomNodeStringName = new(nameof(CustomActor.AutoConnectedCustomNode));
  protected static readonly NodePath _autoConnectedCustomNodePath = new(nameof(CustomActor.AutoConnectedCustomNode));

  protected static readonly StringName _manuallyConnectedNodeStringName = new(nameof(CustomActor.ManuallyConnectedNode));
  protected static readonly NodePath _manuallyConnectedNodePath = new(nameof(CustomActor.ManuallyConnectedNode));

  protected static readonly StringName _manuallyConnectedCustomNodeStringName = new(nameof(CustomActor.ManuallyConnectedCustomNode));
  protected static readonly NodePath _manuallyConnectedCustomNodePath = new(nameof(CustomActor.ManuallyConnectedCustomNode));

  protected const string RUNTIME_NODE_NAME = "RuntimeNode";
  protected static readonly StringName _runtimeNodeStringName = new(RUNTIME_NODE_NAME);
  protected static readonly NodePath _runtimeNodePath = new(RUNTIME_NODE_NAME);
  protected INode _runtimeNode = default!;

  protected const string RUNTIME_CUSTOM_NODE_NAME = "RuntimeCustomNode";
  protected static readonly StringName _runtimeCustomNodeStringName = new(RUNTIME_CUSTOM_NODE_NAME);
  protected static readonly NodePath _runtimeCustomNodePath = new(RUNTIME_CUSTOM_NODE_NAME);
  protected ICustomNode _runtimeCustomNode = default!;

  protected const string EXISTING_NODES_SUBSTRING = "Connected";
  protected const string RUNTIME_NODES_SUBSTRING = "Runtime";

  protected INode[] _builtInNodes = [];
  protected ICustomNode[] _customNodes = [];

  protected CustomActor _actor = default!;

  public virtual async Task Setup()
  {
    _runtimeNode = GodotInterfaces.Adapt<INode>(new Node { Name = _runtimeNodeStringName });
    _runtimeCustomNode = new CustomNode { Name = _runtimeCustomNodeStringName };

    await Task.CompletedTask;
  }

  public virtual void Cleanup()
  {
    foreach (var child in _builtInNodes.Concat(_customNodes).ToArray())
    {
      child?.QueueFree();
    }
    _actor.QueueFree();
  }

  public virtual void AddChildEx_ShouldUpdateSceneTree_WithNode()
  {
    _actor.AddChildEx(_runtimeNode);

    _actor.GetChildrenEx().ShouldContain(x => x.IsMatch(_runtimeNode));
  }

  public virtual void AddChildEx_ShouldUpdateSceneTree_WithCustomNode()
  {
    _actor.AddChildEx(_runtimeCustomNode);

    _actor.GetChildrenEx().ShouldContain(x => x.IsMatch(_runtimeCustomNode));
  }

  public virtual void FindChildEx_ShouldReturnNull_WithNoMatch()
    => _actor.FindChildEx(RUNTIME_NODE_NAME).ShouldBeNull();

  public virtual void FindChildEx_ShouldReturnMatchingNode_WithExistingNode()
  => _actor.FindChildEx(nameof(CustomActor.ManuallyConnectedNode))
    .ShouldMatch(_actor.ManuallyConnectedNode);

  public virtual void FindChildEx_ShouldReturnMatchingNode_WithExistingCustomNode()
    => _actor.FindChildEx(nameof(CustomActor.ManuallyConnectedCustomNode))
      .ShouldMatch(_actor.ManuallyConnectedCustomNode);

  public virtual void FindChildEx_ShouldReturnMatchingNode_WithRuntimeNode()
  {
    _actor.AddChildEx(_runtimeNode);

    // https://forum.godotengine.org/t/find-child-wont-find-child-that-is-added-during-game/74330/6
    if (!RuntimeContext.IsTesting)
    {
      _runtimeNode.SetOwner(_actor);
    }

    _actor.FindChildEx(RUNTIME_NODE_NAME).ShouldMatch(_runtimeNode);
  }

  public virtual void FindChildEx_ShouldReturnMatchingNode_WithRuntimeCustomNode()
  {
    _actor.AddChildEx(_runtimeCustomNode);

    // https://forum.godotengine.org/t/find-child-wont-find-child-that-is-added-during-game/74330/6
    if (!RuntimeContext.IsTesting)
    {
      _runtimeCustomNode.SetOwner(_actor);
    }

    _actor.FindChildEx(RUNTIME_CUSTOM_NODE_NAME).ShouldMatch(_runtimeCustomNode);
  }

  public virtual void FindChildrenEx_ShouldReturnEmptyArray_WithNoMatch()
    => _actor.FindChildrenEx("DoesNotExist").ShouldBeEmpty();

  public virtual void FindChildrenEx_ShouldReturnMatchingNodes_WithExistingNodes()
  {
    var existingBuiltInNodes = _builtInNodes
      .Where(x => x.Name.ToString().Contains(EXISTING_NODES_SUBSTRING))
      .ToArray();
    var existingCustomNodes = _customNodes
      .Where(x => x.Name.ToString().Contains(EXISTING_NODES_SUBSTRING))
      .ToArray();

    _actor.FindChildrenEx($"*{EXISTING_NODES_SUBSTRING}*")
      .ShouldContainAllMatchingNodesFrom(existingBuiltInNodes, existingCustomNodes);
  }

  public virtual void FindChildrenEx_ShouldReturnMatchingNodes_WithRuntimeNodes()
  {
    var runtimeBuiltInNodes = _builtInNodes
      .Where(x => x.Name.ToString().Contains(RUNTIME_NODES_SUBSTRING))
      .ToArray();
    var runtimeCustomNodes = _customNodes
      .Where(x => x.Name.ToString().Contains(RUNTIME_NODES_SUBSTRING))
      .ToArray();

    _actor.AddChildEx(_runtimeNode);
    _actor.AddChildEx(_runtimeCustomNode);

    // https://forum.godotengine.org/t/find-child-wont-find-child-that-is-added-during-game/74330/6
    if (!RuntimeContext.IsTesting)
    {
      _runtimeNode.SetOwner(_actor);
      _runtimeCustomNode.SetOwner(_actor);
    }

    _actor.FindChildrenEx($"*{RUNTIME_NODES_SUBSTRING}*")
      .ShouldContainAllMatchingNodesFrom(runtimeBuiltInNodes, runtimeCustomNodes);
  }

  public virtual void FindChildrenEx_ShouldReturnAllNodes_WithWildcard()
  {
    _actor.AddChildEx(_runtimeNode);
    _actor.AddChildEx(_runtimeCustomNode);

    // https://forum.godotengine.org/t/find-child-wont-find-child-that-is-added-during-game/74330/6
    if (!RuntimeContext.IsTesting)
    {
      _runtimeNode.SetOwner(_actor);
      _runtimeCustomNode.SetOwner(_actor);
    }

    _actor.FindChildrenEx("*")
      .ShouldContainAllMatchingNodesFrom(_builtInNodes, _customNodes);
  }

  public virtual void GetChildEx_ShouldReturnNull_WithInvalidIndex()
    => _actor.GetChildEx(_actor.GetChildCountEx()).ShouldBeNull();

  public virtual void GetChildEx_ShouldReturnNode()
  {
    _actor.AddChildEx(_runtimeNode);
    _actor.AddChildEx(_runtimeCustomNode);

    var getChildExResults = new List<INode>();
    for (var i = 0; i < _actor.GetChildCountEx(); i++)
    {
      var child = _actor.GetChildEx(i);

      child.ShouldNotBeNull();
      getChildExResults.Add(child);
    }

    getChildExResults.ToArray()
      .ShouldContainAllMatchingNodesFrom(_builtInNodes, _customNodes);
  }

  public virtual void GetChildExOfT_ShouldReturnNull_WithInvalidIndex()
    => _actor.GetChildEx<INode>(_actor.GetChildCountEx()).ShouldBeNull();

  public virtual void GetChildExOfT_ShouldThrow_WithIncorrectTypeSpecified()
    => Should.Throw<InvalidCastException>(() => _actor.GetChildEx<ICamera3D>(0));

  public virtual void GetChildExOfT_ShouldReturnNode()
  {
    _actor.AddChildEx(_runtimeNode);
    _actor.AddChildEx(_runtimeCustomNode);

    var getChildExResults = new List<INode>();
    for (var i = 0; i < _actor.GetChildCountEx(); i++)
    {
      var child = _actor.GetChildEx<INode>(i);

      child.ShouldNotBeNull();
      getChildExResults.Add(child);
    }

    getChildExResults.ToArray()
      .ShouldContainAllMatchingNodesFrom(_builtInNodes, _customNodes);
  }

  public virtual void GetChildCountEx_ShouldReturnCount_WithExistingNodes()
    => _actor.GetChildCountEx().ShouldBe(4);

  public virtual void GetChildCountEx_ShouldReturnCount_WithRuntimeNodes()
  {
    _actor.AddChildEx(_runtimeNode);
    _actor.AddChildEx(_runtimeCustomNode);

    _actor.GetChildCountEx().ShouldBe(6);
  }

  public virtual void GetChildrenEx_ShouldReturnAllNodes()
  {
    _actor.AddChildEx(_runtimeNode);
    _actor.AddChildEx(_runtimeCustomNode);

    _actor.GetChildrenEx().ShouldContainAllMatchingNodesFrom(_builtInNodes, _customNodes);
  }

  public virtual void GetNodeEx_ShouldReturnNull_WithNoMatch()
    => _actor.GetNodeEx(_runtimeNodePath).ShouldBeNull();

  public virtual void GetNodeEx_ShouldReturnNode_WithExistingNode()
    => _actor.GetNodeEx(_manuallyConnectedNodePath)
      .ShouldMatch(_actor.ManuallyConnectedNode);

  public virtual void GetNodeEx_ShouldReturnNode_WithExistingCustomNode()
    => _actor.GetNodeEx(_manuallyConnectedCustomNodePath)
      .ShouldMatch(_actor.ManuallyConnectedCustomNode);

  public virtual void GetNodeEx_ShouldReturnNode_WithRuntimeNode()
  {
    _actor.AddChildEx(_runtimeNode);

    _actor.GetNodeEx(_runtimeNodePath).ShouldMatch(_runtimeNode);
  }

  public virtual void GetNodeEx_ShouldReturnNode_WithRuntimeCustomNode()
  {
    _actor.AddChildEx(_runtimeCustomNode);

    _actor.GetNodeEx(_runtimeCustomNodePath).ShouldMatch(_runtimeCustomNode);
  }

  public virtual void GetNodeOrNullEx_ShouldReturnNull_WithNoMatch()
    => _actor.GetNodeOrNullEx(_runtimeNodePath).ShouldBeNull();

  public virtual void GetNodeOrNullEx_ShouldReturnNode_WithExistingNode()
    => _actor.GetNodeOrNullEx(_manuallyConnectedNodePath)
      .ShouldMatch(_actor.ManuallyConnectedNode);

  public virtual void GetNodeOrNullEx_ShouldReturnNode_WithExistingCustomNode()
    => _actor.GetNodeOrNullEx(_manuallyConnectedCustomNodePath)
      .ShouldMatch(_actor.ManuallyConnectedCustomNode);

  public virtual void GetNodeOrNullEx_ShouldReturnNode_WithRuntimeNode()
  {
    _actor.AddChildEx(_runtimeNode);

    _actor.GetNodeOrNullEx(_runtimeNodePath).ShouldMatch(_runtimeNode);
  }

  public virtual void GetNodeOrNullEx_ShouldReturnNode_WithRuntimeCustomNode()
  {
    _actor.AddChildEx(_runtimeCustomNode);

    _actor.GetNodeOrNullEx(_runtimeCustomNodePath).ShouldMatch(_runtimeCustomNode);
  }

  public virtual void GetNodeOrNullExOfT_ShouldReturnNull_WithNoMatch()
    => _actor.GetNodeOrNullEx<INode>(_runtimeNodePath).ShouldBeNull();

  public virtual void GetNodeOrNullExOfT_ShouldReturnNode_WithExistingNode()
    => _actor.GetNodeOrNullEx<INode>(_manuallyConnectedNodePath)
      .ShouldMatch(_actor.ManuallyConnectedNode);

  public virtual void GetNodeOrNullExOfT_ShouldReturnNode_WithExistingCustomNode()
    => _actor.GetNodeOrNullEx<INode>(_manuallyConnectedCustomNodePath)
      .ShouldMatch(_actor.ManuallyConnectedCustomNode);

  public virtual void GetNodeOrNullExOfT_ShouldReturnNode_WithRuntimeNode()
  {
    _actor.AddChildEx(_runtimeNode);

    _actor.GetNodeOrNullEx<INode>(_runtimeNodePath).ShouldMatch(_runtimeNode);
  }

  public virtual void GetNodeOrNullExOfT_ShouldReturnNode_WithRuntimeCustomNode()
  {
    _actor.AddChildEx(_runtimeCustomNode);

    _actor.GetNodeOrNullEx<ICustomNode>(_runtimeCustomNodePath).ShouldMatch(_runtimeCustomNode);
  }

  public virtual void HasNodeEx_ShouldReturnFalse_WithNoMatch()
    => _actor.HasNodeEx(_runtimeNodePath).ShouldBeFalse();

  public virtual void HasNodeEx_ShouldReturnTrue_WithExistingNode()
    => _actor.HasNodeEx(_manuallyConnectedNodePath).ShouldBeTrue();

  public virtual void HasNodeEx_ShouldReturnTrue_WithExistingCustomNode()
    => _actor.HasNodeEx(_manuallyConnectedCustomNodePath).ShouldBeTrue();

  public virtual void HasNodeEx_ShouldReturnTrue_WithRuntimeNode()
  {
    _actor.AddChildEx(_runtimeNode);

    _actor.HasNodeEx(_runtimeNodePath).ShouldBeTrue();
  }

  public virtual void HasNodeEx_ShouldReturnTrue_WithRuntimeCustomNode()
  {
    _actor.AddChildEx(_runtimeCustomNode);

    _actor.HasNodeEx(_runtimeCustomNodePath).ShouldBeTrue();
  }

  public virtual void RemoveChildEx_ShouldUpdateSceneTree_WithExistingNode()
  {
    _actor.GetChildrenEx().ShouldContain(x => x.IsMatch(_actor.ManuallyConnectedNode));

    _actor.RemoveChildEx(_actor.ManuallyConnectedNode);

    _actor.GetChildrenEx().ShouldNotContain(x => x.IsMatch(_actor.ManuallyConnectedNode));
  }

  public virtual void RemoveChildEx_ShouldUpdateSceneTree_WithExistingCustomNode()
  {
    _actor.GetChildrenEx().ShouldContain(x => x.IsMatch(_actor.ManuallyConnectedCustomNode));

    _actor.RemoveChildEx(_actor.ManuallyConnectedCustomNode);

    _actor.GetChildrenEx().ShouldNotContain(x => x.IsMatch(_actor.ManuallyConnectedCustomNode));
  }

  public virtual void RemoveChildEx_ShouldUpdateSceneTree_WithRuntimeNode()
  {
    _actor.AddChildEx(_runtimeNode);
    _actor.GetChildrenEx().ShouldContain(x => x.IsMatch(_runtimeNode));

    _actor.RemoveChildEx(_runtimeNode);

    _actor.GetChildrenEx().ShouldNotContain(x => x.IsMatch(_runtimeNode));
  }

  public virtual void RemoveChildEx_ShouldUpdateSceneTree_WithRuntimeCustomNode()
  {
    _actor.AddChildEx(_runtimeCustomNode);
    _actor.GetChildrenEx().ShouldContain(x => x.IsMatch(_runtimeCustomNode));

    _actor.RemoveChildEx(_runtimeCustomNode);

    _actor.GetChildrenEx().ShouldNotContain(x => x.IsMatch(_runtimeCustomNode));
  }
}
