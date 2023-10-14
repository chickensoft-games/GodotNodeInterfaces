namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>This is an internal editor class intended for keeping data of nodes of unknown type (most likely this type was supplied by an extension that is no longer loaded). It can't be manually instantiated or placed in the scene. Ignore it if you don't know what it is.</para>
/// </summary>
public class MissingNodeAdapter : IMissingNode {
  private readonly MissingNode _node;

  public MissingNodeAdapter(MissingNode node) { _node = node; }

    /// <summary>
    /// <para>Returns the name of the type this node was originally.</para>
    /// </summary>
    public string OriginalClass { get => _node.OriginalClass; set => _node.OriginalClass = value; }

    public bool RecordingProperties { get => _node.RecordingProperties; set => _node.RecordingProperties = value; }

}