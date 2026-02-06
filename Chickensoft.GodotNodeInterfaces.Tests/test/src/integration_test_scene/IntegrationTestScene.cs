namespace Chickensoft.GodotNodeInterfaces.Tests;

using AutoInject;
using Godot;
using Introspection;

public interface IIntegrationTestScene : INode2D { }

[Meta(typeof(IAutoNode))]
public partial class IntegrationTestScene : Node2D, IIntegrationTestScene
{
  public override void _Notification(int what) => this.Notify(what);

  [Node] public INode AutoConnectedNode { get; set; } = default!;
  [Node] public ICustomNode AutoConnectedCustomNode { get; set; } = default!;

  public INode ManuallyConnectedNode { get; set; } = default!;
  public ICustomNode ManuallyConnectedCustomNode { get; set; } = default!;

  public override void _Ready()
  {
    ManuallyConnectedNode = this.GetNodeOrNullEx<INode>(nameof(ManuallyConnectedNode))!;
    ManuallyConnectedCustomNode = this.GetNodeOrNullEx<ICustomNode>(nameof(ManuallyConnectedCustomNode))!;
  }
}
