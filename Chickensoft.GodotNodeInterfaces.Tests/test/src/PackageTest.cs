namespace Chickensoft.GodotNodeInterfaces.Tests;

using Godot;
using GoDotTest;
using Chickensoft.GodotNodeInterfaces;
using Shouldly;

public class PackageTest : TestClass {
  public PackageTest(Node testScene) : base(testScene) { }

  [Test]
  public void AdaptsAndForwardsProperty() {
    var node = new Node();
    var name = "TestNode";
    node.Name = name;
    var inode = GodotInterfaces.Adapt<INode>(node);

    inode.Name.ToString().ShouldBe(name);
  }
}
