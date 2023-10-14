namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class MissingNodeNode : MissingNode, IMissingNode { }

/// <summary>
/// <para>This is an internal editor class intended for keeping data of nodes of unknown type (most likely this type was supplied by an extension that is no longer loaded). It can't be manually instantiated or placed in the scene. Ignore it if you don't know what it is.</para>
/// </summary>
public interface IMissingNode {
    /// <summary>
    /// <para>Returns the name of the type this node was originally.</para>
    /// </summary>
    string OriginalClass { get; set; }

    bool RecordingProperties { get; set; }

}