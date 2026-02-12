namespace Chickensoft.GodotNodeInterfaces.Tests;

using Chickensoft.GodotNodeInterfaces;
using Godot;
using GoDotTest;
using Shouldly;

public class PackageTest : TestClass
{
  public PackageTest(Node testScene) : base(testScene) { }

  [Test]
  public void AdaptsAndForwardsProperty()
  {
    var node = new Node();
    var name = "TestNode";
    node.Name = name;
    var inode = GodotInterfaces.Adapt<INode>(node);

    inode.Name.ToString().ShouldBe(name);

    inode.QueueFree();
  }
}
