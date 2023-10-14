namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
using Godot.Collections;
/// <summary>
/// <para>Turning on the option <b>Load As Placeholder</b> for an instantiated scene in the editor causes it to be replaced by an <see cref="InstancePlaceholder" /> when running the game, this will not replace the node in the editor. This makes it possible to delay actually loading the scene until calling <see cref="InstancePlaceholder.CreateInstance(System.Boolean,Godot.PackedScene)" />. This is useful to avoid loading large scenes all at once by loading parts of it selectively.</para>
/// <para>The <see cref="InstancePlaceholder" /> does not have a transform. This causes any child nodes to be positioned relatively to the <see cref="Viewport" /> from point (0,0), rather than their parent as displayed in the editor. Replacing the placeholder with a scene with a transform will transform children relatively to their parent again.</para>
/// </summary>
public class InstancePlaceholderAdapter : NodeAdapter, IInstancePlaceholder {
  private readonly InstancePlaceholder _node;

  public InstancePlaceholderAdapter(InstancePlaceholder node) : base(node) { _node = node; }

    /// <summary>
    /// <para>Call this method to actually load in the node. The created node will be placed as a sibling <i>above</i> the <see cref="InstancePlaceholder" /> in the scene tree. The <see cref="Node" />'s reference is also returned for convenience.</para>
    /// <para><b>Note:</b> <see cref="InstancePlaceholder.CreateInstance(System.Boolean,Godot.PackedScene)" /> is not thread-safe. Use <see cref="GodotObject.CallDeferred(Godot.StringName,Godot.Variant[])" /> if calling from a thread.</para>
    /// </summary>
    public Node CreateInstance(bool replace, PackedScene customScene) => _node.CreateInstance(replace, customScene);
    /// <summary>
    /// <para>Gets the path to the <see cref="PackedScene" /> resource file that is loaded by default when calling <see cref="InstancePlaceholder.CreateInstance(System.Boolean,Godot.PackedScene)" />. Not thread-safe. Use <see cref="GodotObject.CallDeferred(Godot.StringName,Godot.Variant[])" /> if calling from a thread.</para>
    /// </summary>
    public string GetInstancePath() => _node.GetInstancePath();
    /// <summary>
    /// <para>Returns the list of properties that will be applied to the node when <see cref="InstancePlaceholder.CreateInstance(System.Boolean,Godot.PackedScene)" /> is called.</para>
    /// <para>If <paramref name="withOrder" /> is <c>true</c>, a key named <c>.order</c> (note the leading period) is added to the dictionary. This <c>.order</c> key is an <see cref="Collections.Array" /> of <see cref="T:System.String" /> property names specifying the order in which properties will be applied (with index 0 being the first).</para>
    /// </summary>
    public Godot.Collections.Dictionary GetStoredValues(bool withOrder) => _node.GetStoredValues(withOrder);

}