namespace Chickensoft.GodotNodeInterfaces.Tests;

using Chickensoft.AutoInject;
using Chickensoft.GodotNodeInterfaces;
using Godot;
using GoDotTest;
using Moq;
using Shouldly;

public class NodeExtensionsTests(Node testScene) : TestClass(testScene)
{
  private const string FAKE_CHILD_NODE_NAME = "FakeChildNode";
  private static readonly StringName _fakeChildNodeStringName = new(FAKE_CHILD_NODE_NAME);
  private static readonly NodePath _fakeChildNodePath = new(FAKE_CHILD_NODE_NAME);
  private Mock<INode> _fakeChildNode = default!;

  private const string FAKE_CHILD_CUSTOM_NODE_NAME = "FakeChildCustomNode";
  private static readonly StringName _fakeChildCustomNodeStringName = new(FAKE_CHILD_CUSTOM_NODE_NAME);
  private static readonly NodePath _fakeChildCustomNodePath = new(FAKE_CHILD_CUSTOM_NODE_NAME);
  private Mock<ICustomNode> _fakeChildCustomNode = default!;

  private const string REAL_NODE_NAME = "RealNode";
  private static readonly StringName _realNodeStringName = new(REAL_NODE_NAME);
  private static readonly NodePath _realNodePath = new(REAL_NODE_NAME);
  private INode _realNode = default!;

  private const string REAL_CUSTOM_NODE_NAME = "RealCustomNode";
  private static readonly StringName _realCustomNodeStringName = new(REAL_CUSTOM_NODE_NAME);
  private static readonly NodePath _realCustomNodePath = new(REAL_CUSTOM_NODE_NAME);
  private INode _realCustomNode = default!;

  private CustomNode _node = default!;
  private IFakeNodeTreeEnabled _fakeNodeTreeEnabled = default!;

  [Setup]
  public void Setup()
  {
    _fakeChildNode = new Mock<INode>();
    _fakeChildNode.Setup(x => x.Name).Returns(_fakeChildNodeStringName);

    _fakeChildCustomNode = new Mock<ICustomNode>();
    _fakeChildCustomNode.Setup(x => x.Name).Returns(_fakeChildCustomNodeStringName);

    _realNode = GodotInterfaces.Adapt<INode>(new Node());
    _realNode.Name = _realNodeStringName;

    _realCustomNode = GodotInterfaces.Adapt<ICustomNode>(new CustomNode());
    _realCustomNode.Name = _realCustomNodeStringName;

    _node = new CustomNode();
    _fakeNodeTreeEnabled = _node;

    _node.FakeNodeTree(new()
    {
      [FAKE_CHILD_NODE_NAME] = _fakeChildNode.Object,
      [FAKE_CHILD_CUSTOM_NODE_NAME] = _fakeChildCustomNode.Object
    });
  }

  [Cleanup]
  public void Cleanup()
  {
    _realNode.QueueFree();
    _realCustomNode.QueueFree();

    _node.QueueFree();
  }

  [Test]
  public void AddChildEx_ShouldUpdateFakeNodeTree_WithFakeINode()
  {
    var otherFakeChildNode = new Mock<INode>();

    _node.AddChildEx(otherFakeChildNode.Object);

    _node.GetChildrenEx().ShouldContain(otherFakeChildNode.Object);
  }

  [Test]
  public void AddChildEx_ShouldUpdateFakeNodeTree_WithFakeCustomNode()
  {
    var otherFakeChildNode = new Mock<ICustomNode>();

    _node.AddChildEx(otherFakeChildNode.Object);

    _node.GetChildrenEx().ShouldContain(otherFakeChildNode.Object);
  }

  [Test]
  public void AddChildEx_ShouldUpdateFakeNodeTree_WithRealINode()
  {
    _node.AddChildEx(_realNode);

    _node.GetChildrenEx().ShouldContain(_realNode);
  }

  [Test]
  public void AddChildEx_ShouldUpdateFakeNodeTree_WithRealCustomNode()
  {
    _node.AddChildEx(_realCustomNode);

    _node.GetChildrenEx().ShouldContain(_realCustomNode);
  }

  [Test]
  public void FindChildEx_ShouldReturnNull_WithNoMatch()
    => _node.FindChildEx(REAL_NODE_NAME).ShouldBeNull();

  [Test]
  public void FindChildEx_ShouldReturnChildFromFakeNodeTree_WithFakeINode()
    => _node.FindChildEx(FAKE_CHILD_NODE_NAME).ShouldBe(_fakeChildNode.Object);

  [Test]
  public void FindChildEx_ShouldReturnChildFromFakeNodeTree_WithFakeCustomNode()
  => _node.FindChildEx(FAKE_CHILD_CUSTOM_NODE_NAME).ShouldBe(_fakeChildCustomNode.Object);

  [Test]
  public void FindChildEx_ShouldReturnChildFromFakeNodeTree_WithRealINode()
  {
    _node.AddChildEx(_realNode);

    _node.FindChildEx(REAL_NODE_NAME).ShouldBe(_realNode);
  }

  [Test]
  public void FindChildEx_ShouldReturnChildFromFakeNodeTree_WithRealCustomNode()
  {
    _node.AddChildEx(_realCustomNode);

    _node.FindChildEx(REAL_CUSTOM_NODE_NAME).ShouldBe(_realCustomNode);
  }

  [Test]
  public void FindChildrenEx_ShouldReturnChildFromFakeNodeTree_WithFakeINode()
    => _node.FindChildrenEx(FAKE_CHILD_NODE_NAME).ShouldContain(_fakeChildNode.Object);

  [Test]
  public void FindChildrenEx_ShouldReturnChildFromFakeNodeTree_WithFakeCustomNode()
  => _node.FindChildrenEx(FAKE_CHILD_CUSTOM_NODE_NAME).ShouldContain(_fakeChildCustomNode.Object);

  [Test]
  public void FindChildrenEx_ShouldReturnChildFromFakeNodeTree_WithRealINode()
  {
    _node.AddChildEx(_realNode);

    _node.FindChildrenEx(REAL_NODE_NAME).ShouldContain(_realNode);
  }

  [Test]
  public void FindChildrenEx_ShouldReturnChildFromFakeNodeTree_WithRealCustomNode()
  {
    _node.AddChildEx(_realCustomNode);

    _node.FindChildrenEx(REAL_CUSTOM_NODE_NAME).ShouldContain(_realCustomNode);
  }

  [Test]
  public void GetChildEx_ShouldReturnChildFromFakeNodeTree_WithFakeINode()
    => _node.GetChildEx(0).ShouldBe(_fakeChildNode.Object);

  [Test]
  public void GetChildEx_ShouldReturnChildFromFakeNodeTree_WithFakeCustomNode()
  => _node.GetChildEx(1).ShouldBe(_fakeChildCustomNode.Object);

  [Test]
  public void GetChildEx_ShouldReturnChildFromFakeNodeTree_WithRealINode()
  {
    _node.AddChildEx(_realNode);

    _node.GetChildEx(2).ShouldBe(_realNode);
  }

  [Test]
  public void GetChildEx_ShouldReturnChildFromFakeNodeTree_WithRealCustomNode()
  {
    _node.AddChildEx(_realCustomNode);

    _node.GetChildEx(2).ShouldBe(_realCustomNode);
  }

  [Test]
  public void GetChildExOfT_ShouldReturnChildFromFakeNodeTree_WithFakeINode()
    => _node.GetChildEx<INode>(0).ShouldBe(_fakeChildNode.Object);

  [Test]
  public void GetChildExOfT_ShouldReturnChildFromFakeNodeTree_WithFakeCustomNode()
  => _node.GetChildEx<ICustomNode>(1).ShouldBe(_fakeChildCustomNode.Object);

  [Test]
  public void GetChildExOfT_ShouldReturnChildFromFakeNodeTree_WithRealINode()
  {
    _node.AddChildEx(_realNode);

    _node.GetChildEx<INode>(2).ShouldBe(_realNode);
  }

  [Test]
  public void GetChildExOfT_ShouldReturnChildFromFakeNodeTree_WithRealCustomNode()
  {
    _node.AddChildEx(_realCustomNode);

    _node.GetChildEx<ICustomNode>(2).ShouldBe(_realCustomNode);
  }

  [Test]
  public void GetChildCountEx_ShouldReturnChildCountFromFakeNodeTree_WithFakeINodes()
  {
    _node.GetChildCountEx().ShouldBe(2);
    (_fakeNodeTreeEnabled.FakeNodes?.GetChildCount() ?? 0).ShouldBe(2);
  }

  [Test]
  public void GetChildCountEx_ShouldReturnChildCountFromFakeNodeTree_WithRealINodes()
  {
    _node.AddChildEx(_realNode);
    _node.AddChildEx(_realCustomNode);

    _node.GetChildCountEx().ShouldBe(4);
    (_fakeNodeTreeEnabled.FakeNodes?.GetChildCount() ?? 0).ShouldBe(4);
  }

  [Test]
  public void GetChildrenEx_ShouldReturnChildrenFromFakeNodeTree()
  {
    _node.AddChildEx(_realNode);
    _node.AddChildEx(_realCustomNode);

    _node.GetChildrenEx().ShouldBeEquivalentTo(new INode[]
    {
      _fakeChildNode.Object,
      _fakeChildCustomNode.Object,
      _realNode,
      _realCustomNode
    });
  }

  [Test]
  public void GetNodeEx_ShouldReturnChildFromFakeNodeTree_WithFakeINode()
    => _node.GetNodeEx(_fakeChildNodePath).ShouldBe(_fakeChildNode.Object);

  [Test]
  public void GetNodeEx_ShouldReturnChildFromFakeNodeTree_WithFakeCustomNode()
  => _node.GetNodeEx(_fakeChildCustomNodePath).ShouldBe(_fakeChildCustomNode.Object);

  [Test]
  public void GetNodeEx_ShouldReturnChildFromFakeNodeTree_WithRealINode()
  {
    _node.AddChildEx(_realNode);

    _node.GetNodeEx(_realNodePath).ShouldBe(_realNode);
  }

  [Test]
  public void GetNodeEx_ShouldReturnChildFromFakeNodeTree_WithRealCustomNode()
  {
    _node.AddChildEx(_realCustomNode);

    _node.GetNodeEx(_realCustomNodePath).ShouldBe(_realCustomNode);
  }

  [Test]
  public void GetNodeOrNullEx_ShouldReturnNull_WithNoMatch()
    => _node.GetNodeOrNullEx(_realNodePath).ShouldBeNull();

  [Test]
  public void GetNodeOrNullEx_ShouldReturnChildFromFakeNodeTree_WithFakeINode()
    => _node.GetNodeOrNullEx(_fakeChildNodePath).ShouldBe(_fakeChildNode.Object);

  [Test]
  public void GetNodeOrNullEx_ShouldReturnChildFromFakeNodeTree_WithFakeCustomNode()
    => _node.GetNodeOrNullEx(_fakeChildCustomNodePath).ShouldBe(_fakeChildCustomNode.Object);

  [Test]
  public void GetNodeOrNullEx_ShouldReturnChildFromFakeNodeTree_WithRealINode()
  {
    _node.AddChildEx(_realNode);

    _node.GetNodeOrNullEx(_realNodePath).ShouldBe(_realNode);
  }

  [Test]
  public void GetNodeOrNullEx_ShouldReturnChildFromFakeNodeTree_WithRealCustomNode()
  {
    _node.AddChildEx(_realCustomNode);

    _node.GetNodeOrNullEx(_realCustomNodePath).ShouldBe(_realCustomNode);
  }

  [Test]
  public void GetNodeOrNullExOfT_ShouldReturnNull_WithNoMatch()
    => _node.GetNodeOrNullEx<INode>(_realNodePath).ShouldBeNull();

  [Test]
  public void GetNodeOrNullExOfT_ShouldReturnChildFromFakeNodeTree_WithFakeINode()
    => _node.GetNodeOrNullEx<INode>(_fakeChildNodePath).ShouldBe(_fakeChildNode.Object);

  [Test]
  public void GetNodeOrNullExOfT_ShouldReturnChildFromFakeNodeTree_WithFakeCustomNode()
    => _node.GetNodeOrNullEx<ICustomNode>(_fakeChildCustomNodePath).ShouldBe(_fakeChildCustomNode.Object);

  [Test]
  public void GetNodeOrNullExOfT_ShouldReturnChildFromFakeNodeTree_WithRealINode()
  {
    _node.AddChildEx(_realNode);

    _node.GetNodeOrNullEx<INode>(_realNodePath).ShouldBe(_realNode);
  }

  [Test]
  public void GetNodeOrNullExOfT_ShouldReturnChildFromFakeNodeTree_WithRealCustomNode()
  {
    _node.AddChildEx(_realCustomNode);

    _node.GetNodeOrNullEx<ICustomNode>(_realCustomNodePath).ShouldBe(_realCustomNode);
  }

  [Test]
  public void HasNodeEx_ShouldReturnFalse_WithNoMatch()
    => _node.HasNodeEx(_realNodePath).ShouldBeFalse();

  [Test]
  public void HasNodeEx_ShouldReturnTrueForChildInFakeNodeTree_WithFakeINode()
    => _node.HasNodeEx(_fakeChildNodePath).ShouldBeTrue();

  [Test]
  public void HasNodeEx_ShouldReturnTrueForChildInFakeNodeTree_WithFakeCustomNode()
    => _node.HasNodeEx(_fakeChildCustomNodePath).ShouldBeTrue();

  [Test]
  public void HasNodeEx_ShouldReturnTrueForChildInFakeNodeTree_WithRealINode()
  {
    _node.AddChildEx(_realNode);

    _node.HasNodeEx(_realNodePath).ShouldBeTrue();
  }

  [Test]
  public void HasNodeEx_ShouldReturnTrueForChildInFakeNodeTree_WithRealCustomNode()
  {
    _node.AddChildEx(_realCustomNode);

    _node.HasNodeEx(_realCustomNodePath).ShouldBeTrue();
  }

  [Test]
  public void RemoveChildEx_ShouldUpdateFakeNodeTree_WithFakeINode()
  {
    _node.GetChildrenEx().ShouldContain(_fakeChildNode.Object);

    _node.RemoveChildEx(_fakeChildNode.Object);

    _node.GetChildrenEx().ShouldNotContain(_fakeChildNode.Object);
  }

  [Test]
  public void RemoveChildEx_ShouldUpdateFakeNodeTree_WithFakeCustomNode()
  {
    _node.GetChildrenEx().ShouldContain(_fakeChildCustomNode.Object);

    _node.RemoveChildEx(_fakeChildCustomNode.Object);

    _node.GetChildrenEx().ShouldNotContain(_fakeChildCustomNode.Object);
  }

  [Test]
  public void RemoveChildEx_ShouldUpdateFakeNodeTree_WithRealINode()
  {
    _node.AddChildEx(_realNode);

    _node.GetChildrenEx().ShouldContain(_realNode);

    _node.RemoveChildEx(_realNode);

    _node.GetChildrenEx().ShouldNotContain(_realNode);
  }

  [Test]
  public void RemoveChildEx_ShouldUpdateFakeNodeTree_WithRealCustomNode()
  {
    _node.AddChildEx(_realCustomNode);

    _node.GetChildrenEx().ShouldContain(_realCustomNode);

    _node.RemoveChildEx(_realCustomNode);

    _node.GetChildrenEx().ShouldNotContain(_realCustomNode);
  }
}
