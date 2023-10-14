namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
using Godot.Collections;
/// <summary>
/// <para>This node is used to preload sub-resources inside a scene, so when the scene is loaded, all the resources are ready to use and can be retrieved from the preloader. You can add the resources using the ResourcePreloader tab when the node is selected.</para>
/// <para>GDScript has a simplified <c>@GDScript.preload</c> built-in method which can be used in most situations, leaving the use of <see cref="ResourcePreloader" /> for more advanced scenarios.</para>
/// </summary>
public class ResourcePreloaderAdapter : ResourcePreloader, IResourcePreloader {
  private readonly ResourcePreloader _node;

  public ResourcePreloaderAdapter(ResourcePreloader node) => _node = node;
    /// <summary>
    /// <para>Adds a resource to the preloader with the given <paramref name="name" />. If a resource with the given <paramref name="name" /> already exists, the new resource will be renamed to "<paramref name="name" /> N" where N is an incrementing number starting from 2.</para>
    /// </summary>
    public void AddResource(StringName name, Resource resource) => _node.AddResource(name, resource);
    /// <summary>
    /// <para>Returns the resource associated to <paramref name="name" />.</para>
    /// </summary>
    public Resource GetResource(StringName name) => _node.GetResource(name);
    /// <summary>
    /// <para>Returns the list of resources inside the preloader.</para>
    /// </summary>
    public string[] GetResourceList() => _node.GetResourceList();
    /// <summary>
    /// <para>Returns <c>true</c> if the preloader contains a resource associated to <paramref name="name" />.</para>
    /// </summary>
    public bool HasResource(StringName name) => _node.HasResource(name);
    /// <summary>
    /// <para>Removes the resource associated to <paramref name="name" /> from the preloader.</para>
    /// </summary>
    public void RemoveResource(StringName name) => _node.RemoveResource(name);
    /// <summary>
    /// <para>Renames a resource inside the preloader from <paramref name="name" /> to <paramref name="newname" />.</para>
    /// </summary>
    public void RenameResource(StringName name, StringName newname) => _node.RenameResource(name, newname);

    public Godot.Collections.Array Resources { get => _node.Resources; set => _node.Resources = value; }

}