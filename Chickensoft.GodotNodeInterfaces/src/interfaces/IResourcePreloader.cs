namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
using Godot.Collections;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class ResourcePreloaderNode : ResourcePreloader, IResourcePreloader { }

/// <summary>
/// <para>This node is used to preload sub-resources inside a scene, so when the scene is loaded, all the resources are ready to use and can be retrieved from the preloader. You can add the resources using the ResourcePreloader tab when the node is selected.</para>
/// <para>GDScript has a simplified <c>@GDScript.preload</c> built-in method which can be used in most situations, leaving the use of <see cref="ResourcePreloader" /> for more advanced scenarios.</para>
/// </summary>
public interface IResourcePreloader {
    /// <summary>
    /// <para>Adds a resource to the preloader with the given <paramref name="name" />. If a resource with the given <paramref name="name" /> already exists, the new resource will be renamed to "<paramref name="name" /> N" where N is an incrementing number starting from 2.</para>
    /// </summary>
    void AddResource(StringName name, Resource resource);
    /// <summary>
    /// <para>Returns the resource associated to <paramref name="name" />.</para>
    /// </summary>
    Resource GetResource(StringName name);
    /// <summary>
    /// <para>Returns the list of resources inside the preloader.</para>
    /// </summary>
    string[] GetResourceList();
    /// <summary>
    /// <para>Returns <c>true</c> if the preloader contains a resource associated to <paramref name="name" />.</para>
    /// </summary>
    bool HasResource(StringName name);
    /// <summary>
    /// <para>Removes the resource associated to <paramref name="name" /> from the preloader.</para>
    /// </summary>
    void RemoveResource(StringName name);
    /// <summary>
    /// <para>Renames a resource inside the preloader from <paramref name="name" /> to <paramref name="newname" />.</para>
    /// </summary>
    void RenameResource(StringName name, StringName newname);

    Godot.Collections.Array Resources { get; set; }

}