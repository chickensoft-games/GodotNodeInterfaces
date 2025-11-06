namespace Chickensoft.GodotNodeInterfaces;

using Godot;

/// <summary>
/// Interface for a PowerUp that automatically connects declared node
/// references to their corresponding instances in the scene tree. These are
/// re-implementations of Godot node manipulation and fetching methods that
/// automatically create node adapters so that you can reference Godot nodes
/// by interface.
/// </summary>
public partial interface INode
{
  /// <summary>
  /// <para>Adds a child <paramref name="node" />. Nodes can have any number of children, but every child must have a unique name. Child nodes are automatically deleted when the parent node is deleted, so an entire scene can be removed by deleting its topmost node.</para>
  /// <para>If <paramref name="forceReadableName" /> is <c>true</c>, improves the readability of the added <paramref name="node" />. If not named, the <paramref name="node" /> is renamed to its type, and if it shares <see cref="Node.Name" /> with a sibling, a number is suffixed more appropriately. This operation is very slow. As such, it is recommended leaving this to <c>false</c>, which assigns a dummy name featuring <c>@</c> in both situations.</para>
  /// <para>If <paramref name="internal" /> is different than <see cref="Node.InternalMode.Disabled" />, the child will be added as internal node. Such nodes are ignored by methods like <see cref="Node.GetChildren(bool)" />, unless their parameter <c>include_internal</c> is <c>true</c>. The intended usage is to hide the internal nodes from the user, so the user won't accidentally delete or modify them. Used by some GUI nodes, e.g. <see cref="ColorPicker" />. See <see cref="Node.InternalMode" /> for available modes.</para>
  /// <para><b>Note:</b> If the child node already has a parent, the function will fail. Use <see cref="Node.RemoveChild(Node)" /> first to remove the node from its current parent. For example:</para>
  /// <para><code>
  /// Node childNode = GetChild(0);
  /// if (childNode.GetParent() != null)
  /// {
  /// childNode.GetParent().RemoveChild(childNode);
  /// }
  /// AddChild(childNode);
  /// </code></para>
  /// <para>If you need the child node to be added below a specific node in the list of children, use <see cref="Node.AddSibling(Node,bool)" /> instead of this method.</para>
  /// <para><b>Note:</b> If you want a child to be persisted to a <see cref="PackedScene" />, you must set <see cref="Node.Owner" /> in addition to calling <see cref="Node.AddChild(Node,bool,Node.InternalMode)" />. This is typically relevant for <a href="$DOCS_URL/tutorials/plugins/running_code_in_the_editor.html">tool scripts</a> and <a href="$DOCS_URL/tutorials/plugins/editor/index.html">editor plugins</a>. If <see cref="Node.AddChild(Node,bool,Node.InternalMode)" /> is called without setting <see cref="Node.Owner" />, the newly added <see cref="Node" /> will not be visible in the scene tree, though it will be visible in the 2D/3D view.</para>
  /// </summary>
  /// <param name="node">The node to add as a child.</param>
  /// <param name="forceReadableName">If <c>true</c>, improves the readability of the added <paramref name="node" />.</param>
  /// <param name="internal">If different than <see cref="Node.InternalMode.Disabled" />, the child will be added as internal node.</param>
  void AddChildEx(
    object node,
    bool forceReadableName = false,
    Node.InternalMode @internal = Node.InternalMode.Disabled
  ) => NodeExtensions.AddChildEx(this, node, forceReadableName, @internal);

  /// <summary>
  /// <para>Finds the first descendant of this node whose name matches <paramref name="pattern" /> as in <c>String.match</c>. Internal children are also searched over (see <c>internal</c> parameter in <see cref="Node.AddChild(Node,bool,Node.InternalMode)" />).</para>
  /// <para><paramref name="pattern" /> does not match against the full path, just against individual node names. It is case-sensitive, with <c>"*"</c> matching zero or more characters and <c>"?"</c> matching any single character except <c>"."</c>).</para>
  /// <para>If <paramref name="recursive" /> is <c>true</c>, all child nodes are included, even if deeply nested. Nodes are checked in tree order, so this node's first direct child is checked first, then its own direct children, etc., before moving to the second direct child, and so on. If <paramref name="recursive" /> is <c>false</c>, only this node's direct children are matched.</para>
  /// <para>If <paramref name="owned" /> is <c>true</c>, this method only finds nodes who have an assigned <see cref="Node.Owner" />. This is especially important for scenes instantiated through a script, because those scenes don't have an owner.</para>
  /// <para>Returns <c>null</c> if no matching <see cref="Node" /> is found.</para>
  /// <para><b>Note:</b> As this method walks through all the descendants of the node, it is the slowest way to get a reference to another node. Whenever possible, consider using <see cref="Node.GetNode(NodePath)" /> with unique names instead (see <see cref="Node.UniqueNameInOwner" />), or caching the node references into variable.</para>
  /// <para><b>Note:</b> To find all descendant nodes matching a pattern or a class type, see <see cref="Node.FindChildren(string,string,bool,bool)" />.</para>
  /// </summary>
  /// <param name="pattern">Search pattern string.</param>
  /// <param name="recursive">True recursive search.</param>
  /// <param name="owned">True to only find nodes with the same owner.</param>
  /// <returns>The first descendant of this node whose name matches <paramref name="pattern" />, or null.</returns>
  INode? FindChildEx(
    string pattern, bool recursive = true, bool owned = true
  ) => NodeExtensions.FindChildEx(this, pattern, recursive, owned);

  /// <summary>
  /// <para>Finds descendants of this node whose name matches <paramref name="pattern" /> as in <c>String.match</c>, and/or type matches <paramref name="type" /> as in <see cref="GodotObject.IsClass(string)" />. Internal children are also searched over (see <c>internal</c> parameter in <see cref="Node.AddChild(Node,bool,Node.InternalMode)" />).</para>
  /// </summary>
  /// <param name="pattern"><paramref name="pattern" /> does not match against the full path, just against individual node names. It is case-sensitive, with <c>"*"</c> matching zero or more characters and <c>"?"</c> matching any single character except <c>"."</c>).</param>
  /// <param name="type"><paramref name="type" /> will check equality or inheritance, and is case-sensitive. <c>"Object"</c> will match a node whose type is <c>"Node"</c> but not the other way around.</param>
  /// <param name="recursive">If <paramref name="recursive" /> is <c>true</c>, all child nodes are included, even if deeply nested. Nodes are checked in tree order, so this node's first direct child is checked first, then its own direct children, etc., before moving to the second direct child, and so on. If <paramref name="recursive" /> is <c>false</c>, only this node's direct children are matched.</param>
  /// <param name="owned">If <paramref name="owned" /> is <c>true</c>, this method only finds nodes who have an assigned <see cref="Node.Owner" />. This is especially important for scenes instantiated through a script, because those scenes don't have an owner.</param>
  /// <returns>
  /// <para>Returns an empty array if no matching nodes are found.</para>
  /// <para><b>Note:</b> As this method walks through all the descendants of the node, it is the slowest way to get references to other nodes. Whenever possible, consider caching the node references into variables.</para>
  /// <para><b>Note:</b> If you only want to find the first descendant node that matches a pattern, see <see cref="Node.FindChild(string,bool,bool)" />.</para>
  /// </returns>
  INode[] FindChildrenEx(
    string pattern, string type = "", bool recursive = true, bool owned = true
  ) => NodeExtensions.FindChildrenEx(this, pattern, type, recursive, owned);

  /// <summary>
  /// Returns a child node by its index (see <see cref="Node.GetChildCount(bool)" />).
  /// This method is often used for iterating all children of a node.
  /// Negative indices access the children from the last one.
  /// To access a child node via its name, use <see cref="Node.GetNode(NodePath)" />.
  /// </summary>
  /// <seealso cref="Node.GetChildOrNull(int,bool)" />
  /// <param name="idx">Child index.</param>
  /// <param name="includeInternal">
  /// If <see langword="false" />, internal children are skipped (see <c>internal</c>
  /// parameter in <see cref="Node.AddChild(Node,bool,Node.InternalMode)" />).
  /// </param>
  /// <exception cref="System.InvalidCastException">
  /// The fetched node can't be casted to the given type <typeparamref name="T" />.
  /// </exception>
  /// <typeparam name="T">The type to cast to. Should be a descendant of <see cref="Node" />.</typeparam>
  /// <returns>
  /// The child <see cref="Node" /> at the given index <paramref name="idx" />.
  /// </returns>
  T GetChildEx<T>(
    int idx, bool includeInternal = false
  ) where T : class, INode => NodeExtensions.GetChildEx<T>(
    this, idx, includeInternal
  );

  /// <summary>
  /// <para>Returns a child node by its index (see <see cref="Node.GetChildCount(bool)" />). This method is often used for iterating all children of a node.</para>
  /// <para>Negative indices access the children from the last one.</para>
  /// <para>If <paramref name="includeInternal" /> is <c>false</c>, internal children are skipped (see <c>internal</c> parameter in <see cref="Node.AddChild(Node,bool,Node.InternalMode)" />).</para>
  /// <para>To access a child node via its name, use <see cref="Node.GetNode(NodePath)" />.</para>
  /// </summary>
  /// <param name="idx">Child index.</param>
  /// <param name="includeInternal">
  /// If <see langword="false" />, internal children are skipped (see <c>internal</c>
  /// parameter in <see cref="Node.AddChild(Node,bool,Node.InternalMode)" />).
  /// </param>
  INode GetChildEx(int idx, bool includeInternal = false) =>
    NodeExtensions.GetChildEx(this, idx, includeInternal);

  /// <summary>
  /// <para>Returns the number of child nodes.</para>
  /// <para>If <paramref name="includeInternal" /> is <c>false</c>, internal children aren't counted (see <c>internal</c> parameter in <see cref="Node.AddChild(Node,bool,Node.InternalMode)" />).</para>
  /// </summary>
  /// <param name="includeInternal">
  /// If <see langword="false" />, internal children are skipped (see <c>internal</c>
  /// parameter in <see cref="Node.AddChild(Node,bool,Node.InternalMode)" />).
  /// </param>
  /// <returns>The number of child nodes.</returns>
  int GetChildCountEx(bool includeInternal = false) =>
    NodeExtensions.GetChildCountEx(this, includeInternal);

  /// <summary>
  /// <para>Returns an array of references to node's children.</para>
  /// <para>If <paramref name="includeInternal" /> is <c>false</c>, the returned array won't include internal children (see <c>internal</c> parameter in <see cref="Node.AddChild(Node,bool,Node.InternalMode)" />).</para>
  /// </summary>
  /// <returns> an array of references to node's children.</returns>
  INode[] GetChildrenEx(bool includeInternal = false) =>
    NodeExtensions.GetChildrenEx(this, includeInternal);

  /// <summary>
  /// <para>Fetches a node. The <see cref="NodePath" /> can be either a relative path (from the current node) or an absolute path (in the scene tree) to a node. If the path does not exist, <c>null</c> is returned and an error is logged. Attempts to access methods on the return value will result in an "Attempt to call &lt;method&gt; on a null instance." error.</para>
  /// <para><b>Note:</b> Fetching absolute paths only works when the node is inside the scene tree (see <see cref="Node.IsInsideTree" />).</para>
  /// <para><b>Example:</b> Assume your current node is Character and the following tree:</para>
  /// <para><code>
  /// /root
  /// /root/Character
  /// /root/Character/Sword
  /// /root/Character/Backpack/Dagger
  /// /root/MyGame
  /// /root/Swamp/Alligator
  /// /root/Swamp/Mosquito
  /// /root/Swamp/Goblin
  /// </code></para>
  /// <para>Possible paths are:</para>
  /// <para><code>
  /// GetNode("Sword");
  /// GetNode("Backpack/Dagger");
  /// GetNode("../Swamp/Alligator");
  /// GetNode("/root/MyGame");
  /// </code></para>
  /// </summary>
  /// <param name="path">The path to the node to return.</param>
  /// <returns>The node at the given <paramref name="path" />.</returns>
  INode GetNodeEx(NodePath path) => NodeExtensions.GetNodeEx(this, path);

  /// <summary>
  /// Similar to <see cref="Node.GetNode(NodePath)" />, but does not log an error if <paramref name="path" />
  /// does not point to a valid <see cref="Node" />.
  /// <example>
  /// Example: Assume your current node is Character and the following tree:
  /// <code>
  /// /root
  /// /root/Character
  /// /root/Character/Sword
  /// /root/Character/Backpack/Dagger
  /// /root/MyGame
  /// /root/Swamp/Alligator
  /// /root/Swamp/Mosquito
  /// /root/Swamp/Goblin
  /// </code>
  /// Possible paths are:
  /// <code>
  /// GetNode("Sword");
  /// GetNode("Backpack/Dagger");
  /// GetNode("../Swamp/Alligator");
  /// GetNode("/root/MyGame");
  /// </code>
  /// </example>
  /// <seealso cref="Node.GetNode(NodePath)" />
  /// </summary>
  /// <param name="path">The path to the node to fetch.</param>
  /// <typeparam name="T">The type to cast to. Should be a descendant of <see cref="Node" />.</typeparam>
  /// <returns>
  /// The <see cref="Node" /> at the given <paramref name="path" />, or <see langword="null" /> if not found.
  /// </returns>
  T? GetNodeOrNullEx<T>(
    NodePath path
  ) where T : class, INode => NodeExtensions.GetNodeOrNullEx<T>(this, path);

  /// <summary>
  /// <para>Similar to <see cref="Node.GetNode(NodePath)" />, but does not log an error if <paramref name="path" /> does not point to a valid <see cref="Node" />.</para>
  /// </summary>
  INode? GetNodeOrNullEx(NodePath path) =>
    NodeExtensions.GetNodeOrNullEx(this, path);

  /// <summary>
  /// <para>Returns <c>true</c> if the node that the <see cref="NodePath" /> points to exists.</para>
  /// </summary>
  /// <param name="path">Node path.</param>
  /// <returns><c>true</c> if the node that the <see cref="NodePath" /> points to exists.</returns>
  bool HasNodeEx(NodePath path) => NodeExtensions.HasNodeEx(this, path);

  /// <summary>
  /// <para>Removes a child node. The node is NOT deleted and must be deleted manually.</para>
  /// <para><b>Note:</b> This function may set the <see cref="Node.Owner" /> of the removed Node (or its descendants) to be <c>null</c>, if that <see cref="Node.Owner" /> is no longer a parent or ancestor.</para>
  /// </summary>
  /// <param name="node">Node to remove.</param>
  void RemoveChildEx(object node) => NodeExtensions.RemoveChildEx(this, node);
}
