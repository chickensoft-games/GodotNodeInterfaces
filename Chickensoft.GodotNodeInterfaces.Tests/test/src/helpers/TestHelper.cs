namespace Chickensoft.GodotNodeInterfaces.Tests;

using System.Linq;
using Chickensoft.GodotNodeInterfaces;
using Godot;
using Shouldly;

public static class TestHelper
{
  public static bool IsMatch(this INode? node, INode? other)
  {
    // Unlike Shouldly's ShouldBe, we consider nulls unmatchable in context.
    node.ShouldNotBeNull();
    other.ShouldNotBeNull();

    if (node is NodeAdapter && other is NodeAdapter)
    {
      return node.GetTargetObj<Node>() == other.GetTargetObj<Node>();
    }
    else
    {
      return node == other;
    }
  }

  public static void ShouldContainAllMatchingNodesFrom(this INode[] nodes, INode[] builtInNodes, ICustomNode[] customNodes)
  {
    foreach (var node in nodes)
    {
      if (node is NodeAdapter)
      {
        builtInNodes.ShouldContain(x => x.IsMatch(node));
      }
      else if (node is ICustomNode)
      {
        customNodes.ShouldContain(node);
      }
      else
      {
        builtInNodes.ShouldContain(node);
      }
    }

    foreach (var other in builtInNodes.Concat(customNodes).ToArray())
    {
      if (other is NodeAdapter)
      {
        nodes.ShouldContain(x => x.IsMatch(other));
      }
      else
      {
        nodes.ShouldContain(other);
      }
    }
  }

  public static void ShouldMatch(this INode? node, INode? other)
  {
    // Unlike Shouldly's ShouldBe, we consider nulls unmatchable in context.
    node.ShouldNotBeNull();
    other.ShouldNotBeNull();

    if (node is NodeAdapter && other is NodeAdapter)
    {
      node.GetTargetObj<Node>().ShouldBe(other.GetTargetObj<Node>());
    }
    else
    {
      node.ShouldBe(other);
    }
  }
}
