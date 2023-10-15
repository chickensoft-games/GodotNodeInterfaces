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

GodotSharp doesn't expose interfaces for Godot nodes, making it [very expensive or difficult][expensive-toys] to mock them.

If you're still confused, this probably isn't for you. It's one of those "you'll know if you ever want/need this" type of things. This is really just for those completionists who like writing tests and getting 100% code coverage.

## 📦 Installation

Just install the package from nuget!

```sh
dotnet add package Chickensoft.GodotNodeInterfaces 
```

## 📖 Usage

All you have to do is implement your own extension method and use it in in place of `GetNode<T>(string)` that actually gets the godot node by the path and creates an adapter for it (or looks up the path in a cache of mocked nodes).

```csharp
public static class FakeSceneTree {
  public static T GetNodeEx<T>(this Node node, string path) where T : class, INode {
    var child = node.GetNode(path);
    if (child == null) {
      // TODO: lookup a mock node in your fake scene tree or something
      return (T)FakeSceneTree.Mocks[path];
    }

    return GodotNodes.Adapt<T>(child);
  }

  // When running tests, put your fake scene tree stuff here
  // (or come up with your own system for storing mock nodes temporarily)
  public static Dictionary<string, INode> Mocks = new();
}
```

Or you can use the `[AutoNode]` functionality from [PowerUps] with [SuperNodes].

Once you have that setup, you can use it in your node scripts.

```csharp
public partial class MyNode : Node2D {
  public ISprite2D Sprite { get; set; } = default!;

  public override void _Ready() {
    Sprite = this.GetNodeEx<ISprite2D>("Sprite");
  }
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

[chickensoft-badge]: https://raw.githubusercontent.com/chickensoft-games/chickensoft_site/main/static/img/badges/chickensoft_badge.svg
[chickensoft-website]: https://chickensoft.games
[discord-badge]: https://raw.githubusercontent.com/chickensoft-games/chickensoft_site/main/static/img/badges/discord_badge.svg
[discord]: https://discord.gg/gSjaPgMmYW
[read-the-docs-badge]: https://raw.githubusercontent.com/chickensoft-games/chickensoft_site/main/static/img/badges/read_the_docs_badge.svg
[docs]: https://chickensoft.games/docsickensoft%20Discord-%237289DA.svg?style=flat&logo=discord&logoColor=white

[setup-docs]: https://chickensoft.games/docs/setup
[Renovatebot]: https://www.mend.io/free-developer-tools/renovate/
[get-renovatebot]: https://github.com/apps/renovate
[renovate-approve]: https://github.com/apps/renovate-approve
[renovate-approve-2]: https://github.com/apps/renovate-approve-2
[about-renovate-approvals]: https://stackoverflow.com/a/66575885

[expensive-toys]: https://stackoverflow.com/questions/5556115/open-source-free-alternative-of-typemock-isolator

[PowerUps]: https://github.com/chickensoft-games/PowerUps
[SuperNodes]: https://github.com/chickensoft-games/SuperNodes
