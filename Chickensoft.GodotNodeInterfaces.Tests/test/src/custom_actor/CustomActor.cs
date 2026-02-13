namespace Chickensoft.GodotNodeInterfaces.Tests;

using Godot;

public interface ICustomActor : INode2D { }

public partial class CustomActor : Node2D, ICustomActor, IFakeNodeTreeEnabled
{
  public INode ManuallyConnectedNode { get; set; } = default!;
  public ICustomNode ManuallyConnectedCustomNode { get; set; } = default!;
  public FakeNodeTree? FakeNodes { get; set; }

  public override void _Ready()
  {
    ManuallyConnectedNode = this.GetNodeOrNullEx<INode>(nameof(ManuallyConnectedNode))!;
    ManuallyConnectedCustomNode = this.GetNodeOrNullEx<ICustomNode>(nameof(ManuallyConnectedCustomNode))!;
  }
}
