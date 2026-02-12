namespace Chickensoft.GodotNodeInterfaces.Tests;

using System.Reflection;
using Godot;
using GoDotTest;

public partial class Tests : Node2D
{
  public override void _Ready()
  {
    RuntimeContext.IsTesting = true;
    _ = GoTest.RunTests(Assembly.GetExecutingAssembly(), this);
  }
}
