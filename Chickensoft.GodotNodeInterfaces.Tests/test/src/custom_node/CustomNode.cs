namespace Chickensoft.GodotNodeInterfaces.Tests;

using Chickensoft.AutoInject;
using Chickensoft.Introspection;
using Godot;

/// <inheritdoc cref="ICustomNode"/>
[Meta(typeof(IAutoNode))]
public partial class CustomNode : Node, ICustomNode
{
  public override void _Notification(int what) => this.Notify(what);
}
