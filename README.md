# GodotNodeInterfaces

[![Chickensoft Badge][chickensoft-badge]][chickensoft-website] [![Discord][discord-badge]][discord] [![Read the docs][read-the-docs-badge]][docs]

Godot node interfaces and adapters.

---

<p align="center">
<img alt="Chickensoft.GodotNodeInterfaces" src="Chickensoft.GodotNodeInterfaces/icon.png" width="200">
</p>

## 🤔 What...why?

In a perfect world, there are cases where mocking Godot nodes for testing makes a lot of sense:

- You are a TDD cultist.
- You want to unit-test a Godot node script.
- You don't want to instantiate the corresponding scene for a node script. Why? Because instantiating a scene also instantiates any children and their scripts, and so on. Just instantiating scripts and adding them to the scene causes test coverage to be collected, and it ends up covering far more of the app than the actual system-under-test (the node script you were trying to test), which makes it hard to tell which scripts are still un-tested.

GodotSharp doesn't expose interfaces for Godot nodes, making it [very expensive][expensive-toys] to mock them using proprietary enterprise-grade mocking solutions.

If you're still confused, this probably isn't for you. It's one of those "you'll know if you ever want/need this" type of things. This is really just for those completionists who like writing tests and getting 100% code coverage.

## 🧐 I don't see anything here

That's because the interfaces and adapters are generated at build-time based on the version of the GodotSharp API being referenced.

Here's a sample of a generated interface:

```csharp
/// <summary>
/// <para>Casts light in a 2D environment. A light is defined as a color, an energy value, a mode (see constants), and various other parameters (range and shadows-related).</para>
/// </summary>
public interface ILight2D : INode2D
{
    /// <summary>
    /// <para>The Light2D's blend mode. See <see cref="Light2D.BlendModeEnum" /> constants for values.</para>
    /// </summary>
    Light2D.BlendModeEnum BlendMode { get; set; }
    /// <summary>
    /// <para>The Light2D's <see cref="Color" />.</para>
    /// </summary>
    Color Color { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, Light2D will only appear when editing the scene.</para>
    /// </summary>
    bool EditorOnly { get; set; }

    ...
```

And here's the corresponding adapter:

```csharp
/// <summary>
/// <para>Casts light in a 2D environment. A light is defined as a color, an energy value, a mode (see constants), and various other parameters (range and shadows-related).</para>
/// </summary>
public class Light2DAdapter : Node2DAdapter, ILight2D, INodeAdapter
{
  /// <summary>Underlying Godot object this adapter uses.</summary>
  public new Light2D TargetObj { get; private set; }

  /// <summary>Creates a new Light2DAdapter for Light2D.</summary>
  /// <param name="object">Godot object.</param>
  public Light2DAdapter(GodotObject @object) : base(@object)
  {
    if (@object is not Light2D typedObj) {
      throw new System.InvalidCastException(
        $"{@object.GetType().Name} is not a Light2D"
      );
    }
    TargetObj = typedObj;
  }

    /// <summary>
    /// <para>The Light2D's blend mode. See <see cref="Godot.Light2D.BlendModeEnum" /> constants for values.</para>
    /// </summary>
    public Light2D.BlendModeEnum BlendMode { get => TargetObj.BlendMode; set => TargetObj.BlendMode = value; }

    ...
```

And here's what the adapter factory looks like:

```csharp
public static class GodotNodes
{
  private static readonly Dictionary<Type, Func<Node, IGodotNodeAdapter>> _adapters = new()
  {
      [typeof(INode)] = node => new NodeAdapter(node),
      [typeof(IAnimationPlayer)] = node => new AnimationPlayerAdapter(node),
      [typeof(IAnimationTree)] = node => new AnimationTreeAdapter(node),
      [typeof(ICodeEdit)] = node => new CodeEditAdapter(node),
      [typeof(IGraphEdit)] = node => new GraphEditAdapter(node),

      ...
```

### 🤯 Using Interfaces

`GodotNodeInterfaces` adds some extended method variants for common child node operations to adapters and vanilla Godot nodes (via extension methods).

- `AddChildEx()`
- `FindChildEx()`
- `FindChildrenEx()`
- `GetChildEx<T>()`
- `GetChildEx()`
- `GetChildCountEx()`
- `GetChildrenEx()`
- `GetChildOrNullEx()`
- `GetChildrenEx()`
- `GetNodeEx()`
- `GetNodeOrNullEx<T>()`
- `GetNodeOrNullEx()`
- `HasNodeEx()`
- `RemoveChildEx()`

These methods receive arbitrary objects that can be either Godot node instances or Godot interface adapters. The methods that return nodes will return adapted nodes so that you can continue to use interface types.

If you use these methods instead of the Godot version, you can mock subtree operations, making it easier to unit-test node scripts.

## 📦 Installation

Just install the package from nuget!

```sh
dotnet add package Chickensoft.GodotNodeInterfaces
```

## 📖 Usage

You can use interfaces in your Godot node scripts and use the various `Ex` methods mentioned above to manipulate the scene tree.

Once you have that setup, you can use it in your node scripts.

```csharp
public partial class MyNode : Node2D
{
  public ISprite2D Sprite { get; set; } = default!;

  public override void _Ready()
  {
    Sprite = this.GetNodeEx<ISprite2D>("Sprite");
  }
}
```

### 🧪 Testing

All Godot node adapter implementations have a `FakeNodes` dictionary that is checked first by each of the `Ex` node manipulation methods, like `GetNodeEx`, `GetChildrenEx`, etc. If a mocked node is found in the dictionary for the given path, it will be returned instead of looking for an actual node. This allows Godot nodes to be tested.

For example, here's a node which grabs a reference to one of its child nodes in `_Ready`.

```csharp
using Chickensoft.GodotNodeInterfaces;
using Chickensoft.PowerUps;
using Godot;
using SuperNodes.Types;

[SuperNode(typeof(AutoNode))]
public partial class MyNode : Node2D
{
  public override partial void _Notification(int what);

  public INode2D MyChild { get; set; } = default!;

  public void OnReady()
  {
    // This automatically finds the node and creates a Godot node adapter
    // so that we can refer to it by its interface.
    MyChild = this.GetNodeEx<INode2D>("MyChild");
  }
}
```

> Using the `AutoNode` PowerUp from the Chickensoft [PowerUps] allows us to use a fake node tree for our node instance. More on that in a second.

Since we're using interfaces to refer to the child node, we can mock it in our tests.

```csharp
[Test]
public void LoadsGame()
{
  var node = new MyNode();

  var myChild = new Mock<INode2D>().Object;

  // We can fake the children of the node we're testing by supplying
  // a dictionary of node paths that correspond to mock node objects.
  // Since we're referencing nodes by interfaces in our node script, this
  // works!
  node.FakeNodeTree(new()
  {
    ["MyChild"] = myChild.Object
  });

  node.OnReady();

  // Make sure our node did what we expected it to do.
  node.MyChild.ShouldBe(myChild.Object);
}
```

## Migrating

### Upgrading from GodotNodeInterfaces 2.x to 3.x

The following static state was added in GodotNodeInterfaces 3.0:

```csharp
namespace Chickensoft.GodotNodeInterfaces;

public static class RuntimeContext
{
  public static bool IsTesting { get; set; }
}
```

This must be set to true by the user in their project boilerplate to use the FakeNodeTree in tests. For example, the following line of code needed to be added to [Main.cs](https://github.com/blewis-web/Chickensoft.GameDemo/blob/main/src/Main.cs) in GameDemo.

```csharp
  public override void _Ready()
  {
#if RUN_TESTS
    // If this is a debug build, use GoDotTest to examine the
    // command line arguments and determine if we should run tests.
    Environment = TestEnvironment.From(OS.GetCmdlineArgs());
    if (Environment.ShouldRunTests)
    {
      // Add this line of boilerplate to use the FakeNodeTree in tests.
      Chickensoft.GodotNodeInterfaces.RuntimeContext.IsTesting = true;

      CallDeferred(nameof(RunTests));
      return;
    }
#endif

    // If we don't need to run tests, we can just switch to the game scene.
    CallDeferred(nameof(StartApp));
  }
```

## 💁 Getting Help

*Is this package broken? Encountering obscure C# build problems?* We'll be happy to help you in the [Chickensoft Discord server][discord].

## 💪 Contributing

This project contains a very hastily written console generator program that uses reflection (yep!) to find all the types in GodotSharp that are or extend the Godot `Node` class, and then generates interfaces, adapters, and an adapter factory.

The actual package is left empty — we generate the project in CI/CD so that we can keep this package up-to-date with [renovatebot] and automatically release a new version whenever a new GodotSharp package drops.

### 🐞 Debugging

A VSCode launch profile is provided that allows you to debug the generator program. This can be great when trying to figure out why it's generating invalid code.

> **Important:** You must setup a `GODOT` environment variable for the launch configurations above. If you haven't done so already, please see the [Chickensoft Setup Docs][setup-docs].

### 🏚 Renovatebot

This repository includes a [`renovate.json`](./renovate.json) configuration for use with [Renovatebot] to help keep it up-to-date.

![Renovatebot Pull Request](docs/renovatebot_pr.png)

> Unlike Dependabot, Renovatebot is able to combine all dependency updates into a single pull request — a must-have for Godot C# repositories where each sub-project needs the same Godot.NET.Sdk versions. If dependency version bumps were split across multiple repositories, the builds would fail in CI.

The easiest way to add Renovatebot to your repository is to [install it from the GitHub Marketplace][get-renovatebot]. Note that you have to grant it access to each organization and repository you want it to monitor.

The included `renovate.json` includes a few configuration options to limit how often Renovatebot can open pull requests as well as regex's to filter out some poorly versioned dependencies to prevent invalid dependency version updates.

If your project is setup to require approvals before pull requests can be merged *and* you wish to take advantage of Renovatebot's auto-merge feature, you can install the [Renovate Approve][renovate-approve] bot to automatically approve the Renovate dependency PR's. If you need two approvals, you can install the identical [Renovate Approve 2][renovate-approve-2] bot. See [this][about-renovate-approvals] for more information.

---

🐣 Package generated from a 🐤 Chickensoft Template — <https://chickensoft.games>

[chickensoft-badge]: https://chickensoft.games/img/badges/chickensoft_badge.svg
[chickensoft-website]: https://chickensoft.games
[discord-badge]: https://chickensoft.games/img/badges/discord_badge.svg
[discord]: https://discord.gg/gSjaPgMmYW
[read-the-docs-badge]: https://chickensoft.games/img/badges/read_the_docs_badge.svg
[docs]: https://chickensoft.games/docsickensoft%20Discord-%237289DA.svg?style=flat&logo=discord&logoColor=white

[setup-docs]: https://chickensoft.games/docs/setup
[Renovatebot]: https://www.mend.io/free-developer-tools/renovate/
[get-renovatebot]: https://github.com/apps/renovate
[renovate-approve]: https://github.com/apps/renovate-approve
[renovate-approve-2]: https://github.com/apps/renovate-approve-2
[about-renovate-approvals]: https://stackoverflow.com/a/66575885

[expensive-toys]: https://stackoverflow.com/questions/5556115/open-source-free-alternative-of-typemock-isolator

[PowerUps]: https://github.com/chickensoft-games/PowerUps
