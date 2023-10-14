namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
using Godot.Collections;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class NodeNode : Node, INode { }

/// <summary>
/// <para>Nodes are Godot's building blocks. They can be assigned as the child of another node, resulting in a tree arrangement. A given node can contain any number of nodes as children with the requirement that all siblings (direct children of a node) should have unique names.</para>
/// <para>A tree of nodes is called a <i>scene</i>. Scenes can be saved to the disk and then instantiated into other scenes. This allows for very high flexibility in the architecture and data model of Godot projects.</para>
/// <para><b>Scene tree:</b> The <see cref="SceneTree" /> contains the active tree of nodes. When a node is added to the scene tree, it receives the <see cref="Node.NotificationEnterTree" /> notification and its <see cref="Node._EnterTree" /> callback is triggered. Child nodes are always added <i>after</i> their parent node, i.e. the <see cref="Node._EnterTree" /> callback of a parent node will be triggered before its child's.</para>
/// <para>Once all nodes have been added in the scene tree, they receive the <see cref="Node.NotificationReady" /> notification and their respective <see cref="Node._Ready" /> callbacks are triggered. For groups of nodes, the <see cref="Node._Ready" /> callback is called in reverse order, starting with the children and moving up to the parent nodes.</para>
/// <para>This means that when adding a node to the scene tree, the following order will be used for the callbacks: <see cref="Node._EnterTree" /> of the parent, <see cref="Node._EnterTree" /> of the children, <see cref="Node._Ready" /> of the children and finally <see cref="Node._Ready" /> of the parent (recursively for the entire scene tree).</para>
/// <para><b>Processing:</b> Nodes can override the "process" state, so that they receive a callback on each frame requesting them to process (do something). Normal processing (callback <see cref="Node._Process(System.Double)" />, toggled with <see cref="Node.SetProcess(System.Boolean)" />) happens as fast as possible and is dependent on the frame rate, so the processing time <i>delta</i> (in seconds) is passed as an argument. Physics processing (callback <see cref="Node._PhysicsProcess(System.Double)" />, toggled with <see cref="Node.SetPhysicsProcess(System.Boolean)" />) happens a fixed number of times per second (60 by default) and is useful for code related to the physics engine.</para>
/// <para>Nodes can also process input events. When present, the <see cref="Node._Input(Godot.InputEvent)" /> function will be called for each input that the program receives. In many cases, this can be overkill (unless used for simple projects), and the <see cref="Node._UnhandledInput(Godot.InputEvent)" /> function might be preferred; it is called when the input event was not handled by anyone else (typically, GUI <see cref="Control" /> nodes), ensuring that the node only receives the events that were meant for it.</para>
/// <para>To keep track of the scene hierarchy (especially when instancing scenes into other scenes), an "owner" can be set for the node with the <see cref="Node.Owner" /> property. This keeps track of who instantiated what. This is mostly useful when writing editors and tools, though.</para>
/// <para>Finally, when a node is freed with <see cref="GodotObject.Free" /> or <see cref="Node.QueueFree" />, it will also free all its children.</para>
/// <para><b>Groups:</b> Nodes can be added to as many groups as you want to be easy to manage, you could create groups like "enemies" or "collectables" for example, depending on your game. See <see cref="Node.AddToGroup(Godot.StringName,System.Boolean)" />, <see cref="Node.IsInGroup(Godot.StringName)" /> and <see cref="Node.RemoveFromGroup(Godot.StringName)" />. You can then retrieve all nodes in these groups, iterate them and even call methods on groups via the methods on <see cref="SceneTree" />.</para>
/// <para><b>Networking with nodes:</b> After connecting to a server (or making one, see <see cref="ENetMultiplayerPeer" />), it is possible to use the built-in RPC (remote procedure call) system to communicate over the network. By calling <see cref="Node.Rpc(Godot.StringName,Godot.Variant[])" /> with a method name, it will be called locally and in all connected peers (peers = clients and the server that accepts connections). To identify which node receives the RPC call, Godot will use its <see cref="NodePath" /> (make sure node names are the same on all peers). Also, take a look at the high-level networking tutorial and corresponding demos.</para>
/// <para><b>Note:</b> The <c>script</c> property is part of the <see cref="GodotObject" /> class, not <see cref="Node" />. It isn't exposed like most properties but does have a setter and getter (<c>set_script()</c> and <c>get_script()</c>).</para>
/// </summary>
public interface INode {
    /// <summary>
    /// <para>Called when the node enters the <see cref="SceneTree" /> (e.g. upon instancing, scene changing, or after calling <see cref="Node.AddChild(Godot.Node,System.Boolean,Godot.Node.InternalMode)" /> in a script). If the node has children, its <see cref="Node._EnterTree" /> callback will be called first, and then that of the children.</para>
    /// <para>Corresponds to the <see cref="Node.NotificationEnterTree" /> notification in <see cref="GodotObject._Notification(System.Int32)" />.</para>
    /// </summary>
    void _EnterTree();
    /// <summary>
    /// <para>Called when the node is about to leave the <see cref="SceneTree" /> (e.g. upon freeing, scene changing, or after calling <see cref="Node.RemoveChild(Godot.Node)" /> in a script). If the node has children, its <see cref="Node._ExitTree" /> callback will be called last, after all its children have left the tree.</para>
    /// <para>Corresponds to the <see cref="Node.NotificationExitTree" /> notification in <see cref="GodotObject._Notification(System.Int32)" /> and signal <see cref="Node.TreeExiting" />. To get notified when the node has already left the active tree, connect to the <see cref="Node.TreeExited" />.</para>
    /// </summary>
    void _ExitTree();
    /// <summary>
    /// <para>The elements in the array returned from this method are displayed as warnings in the Scene dock if the script that overrides it is a <c>tool</c> script.</para>
    /// <para>Returning an empty array produces no warnings.</para>
    /// <para>Call <see cref="Node.UpdateConfigurationWarnings" /> when the warnings need to be updated for this node.</para>
    /// <para><code>
    /// @export var energy = 0:
    /// set(value):
    /// energy = value
    /// update_configuration_warnings()
    /// func _get_configuration_warnings():
    /// if energy &lt; 0:
    /// return ["Energy must be 0 or greater."]
    /// else:
    /// return []
    /// </code></para>
    /// </summary>
    string[] _GetConfigurationWarnings();

    NodePath _ImportPath { get; set; }
    /// <summary>
    /// <para>Called when there is an input event. The input event propagates up through the node tree until a node consumes it.</para>
    /// <para>It is only called if input processing is enabled, which is done automatically if this method is overridden, and can be toggled with <see cref="Node.SetProcessInput(System.Boolean)" />.</para>
    /// <para>To consume the input event and stop it propagating further to other nodes, <see cref="Viewport.SetInputAsHandled" /> can be called.</para>
    /// <para>For gameplay input, <see cref="Node._UnhandledInput(Godot.InputEvent)" /> and <see cref="Node._UnhandledKeyInput(Godot.InputEvent)" /> are usually a better fit as they allow the GUI to intercept the events first.</para>
    /// <para><b>Note:</b> This method is only called if the node is present in the scene tree (i.e. if it's not an orphan).</para>
    /// </summary>
    void _Input(InputEvent @event);
    /// <summary>
    /// <para>Called during the physics processing step of the main loop. Physics processing means that the frame rate is synced to the physics, i.e. the <paramref name="delta" /> variable should be constant. <paramref name="delta" /> is in seconds.</para>
    /// <para>It is only called if physics processing is enabled, which is done automatically if this method is overridden, and can be toggled with <see cref="Node.SetPhysicsProcess(System.Boolean)" />.</para>
    /// <para>Corresponds to the <see cref="Node.NotificationPhysicsProcess" /> notification in <see cref="GodotObject._Notification(System.Int32)" />.</para>
    /// <para><b>Note:</b> This method is only called if the node is present in the scene tree (i.e. if it's not an orphan).</para>
    /// </summary>
    void _PhysicsProcess(double delta);
    /// <summary>
    /// <para>Called during the processing step of the main loop. Processing happens at every frame and as fast as possible, so the <paramref name="delta" /> time since the previous frame is not constant. <paramref name="delta" /> is in seconds.</para>
    /// <para>It is only called if processing is enabled, which is done automatically if this method is overridden, and can be toggled with <see cref="Node.SetProcess(System.Boolean)" />.</para>
    /// <para>Corresponds to the <see cref="Node.NotificationProcess" /> notification in <see cref="GodotObject._Notification(System.Int32)" />.</para>
    /// <para><b>Note:</b> This method is only called if the node is present in the scene tree (i.e. if it's not an orphan).</para>
    /// </summary>
    void _Process(double delta);
    /// <summary>
    /// <para>Called when the node is "ready", i.e. when both the node and its children have entered the scene tree. If the node has children, their <see cref="Node._Ready" /> callbacks get triggered first, and the parent node will receive the ready notification afterwards.</para>
    /// <para>Corresponds to the <see cref="Node.NotificationReady" /> notification in <see cref="GodotObject._Notification(System.Int32)" />. See also the <c>@onready</c> annotation for variables.</para>
    /// <para>Usually used for initialization. For even earlier initialization, <see cref="GodotObject.#ctor" /> may be used. See also <see cref="Node._EnterTree" />.</para>
    /// <para><b>Note:</b> <see cref="Node._Ready" /> may be called only once for each node. After removing a node from the scene tree and adding it again, <see cref="Node._Ready" /> will not be called a second time. This can be bypassed by requesting another call with <see cref="Node.RequestReady" />, which may be called anywhere before adding the node again.</para>
    /// </summary>
    void _Ready();
    /// <summary>
    /// <para>Called when an <see cref="InputEventKey" /> or <see cref="InputEventShortcut" /> hasn't been consumed by <see cref="Node._Input(Godot.InputEvent)" /> or any GUI <see cref="Control" /> item. It is called before <see cref="Node._UnhandledKeyInput(Godot.InputEvent)" /> and <see cref="Node._UnhandledInput(Godot.InputEvent)" />. The input event propagates up through the node tree until a node consumes it.</para>
    /// <para>It is only called if shortcut processing is enabled, which is done automatically if this method is overridden, and can be toggled with <see cref="Node.SetProcessShortcutInput(System.Boolean)" />.</para>
    /// <para>To consume the input event and stop it propagating further to other nodes, <see cref="Viewport.SetInputAsHandled" /> can be called.</para>
    /// <para>This method can be used to handle shortcuts. For generic GUI events, use <see cref="Node._Input(Godot.InputEvent)" /> instead. Gameplay events should usually be handled with either <see cref="Node._UnhandledInput(Godot.InputEvent)" /> or <see cref="Node._UnhandledKeyInput(Godot.InputEvent)" />.</para>
    /// <para><b>Note:</b> This method is only called if the node is present in the scene tree (i.e. if it's not orphan).</para>
    /// </summary>
    void _ShortcutInput(InputEvent @event);
    /// <summary>
    /// <para>Called when an <see cref="InputEvent" /> hasn't been consumed by <see cref="Node._Input(Godot.InputEvent)" /> or any GUI <see cref="Control" /> item. It is called after <see cref="Node._ShortcutInput(Godot.InputEvent)" /> and after <see cref="Node._UnhandledKeyInput(Godot.InputEvent)" />. The input event propagates up through the node tree until a node consumes it.</para>
    /// <para>It is only called if unhandled input processing is enabled, which is done automatically if this method is overridden, and can be toggled with <see cref="Node.SetProcessUnhandledInput(System.Boolean)" />.</para>
    /// <para>To consume the input event and stop it propagating further to other nodes, <see cref="Viewport.SetInputAsHandled" /> can be called.</para>
    /// <para>For gameplay input, this method is usually a better fit than <see cref="Node._Input(Godot.InputEvent)" />, as GUI events need a higher priority. For keyboard shortcuts, consider using <see cref="Node._ShortcutInput(Godot.InputEvent)" /> instead, as it is called before this method. Finally, to handle keyboard events, consider using <see cref="Node._UnhandledKeyInput(Godot.InputEvent)" /> for performance reasons.</para>
    /// <para><b>Note:</b> This method is only called if the node is present in the scene tree (i.e. if it's not an orphan).</para>
    /// </summary>
    void _UnhandledInput(InputEvent @event);
    /// <summary>
    /// <para>Called when an <see cref="InputEventKey" /> hasn't been consumed by <see cref="Node._Input(Godot.InputEvent)" /> or any GUI <see cref="Control" /> item. It is called after <see cref="Node._ShortcutInput(Godot.InputEvent)" /> but before <see cref="Node._UnhandledInput(Godot.InputEvent)" />. The input event propagates up through the node tree until a node consumes it.</para>
    /// <para>It is only called if unhandled key input processing is enabled, which is done automatically if this method is overridden, and can be toggled with <see cref="Node.SetProcessUnhandledKeyInput(System.Boolean)" />.</para>
    /// <para>To consume the input event and stop it propagating further to other nodes, <see cref="Viewport.SetInputAsHandled" /> can be called.</para>
    /// <para>This method can be used to handle Unicode character input with Alt, Alt + Ctrl, and Alt + Shift modifiers, after shortcuts were handled.</para>
    /// <para>For gameplay input, this and <see cref="Node._UnhandledInput(Godot.InputEvent)" /> are usually a better fit than <see cref="Node._Input(Godot.InputEvent)" />, as GUI events should be handled first. This method also performs better than <see cref="Node._UnhandledInput(Godot.InputEvent)" />, since unrelated events such as <see cref="InputEventMouseMotion" /> are automatically filtered. For shortcuts, consider using <see cref="Node._ShortcutInput(Godot.InputEvent)" /> instead.</para>
    /// <para><b>Note:</b> This method is only called if the node is present in the scene tree (i.e. if it's not an orphan).</para>
    /// </summary>
    void _UnhandledKeyInput(InputEvent @event);
    /// <summary>
    /// <para>Adds a child <paramref name="node" />. Nodes can have any number of children, but every child must have a unique name. Child nodes are automatically deleted when the parent node is deleted, so an entire scene can be removed by deleting its topmost node.</para>
    /// <para>If <paramref name="forceReadableName" /> is <c>true</c>, improves the readability of the added <paramref name="node" />. If not named, the <paramref name="node" /> is renamed to its type, and if it shares <see cref="Node.Name" /> with a sibling, a number is suffixed more appropriately. This operation is very slow. As such, it is recommended leaving this to <c>false</c>, which assigns a dummy name featuring <c>@</c> in both situations.</para>
    /// <para>If <paramref name="internal" /> is different than <see cref="Node.InternalMode.Disabled" />, the child will be added as internal node. Such nodes are ignored by methods like <see cref="Node.GetChildren(System.Boolean)" />, unless their parameter <c>include_internal</c> is <c>true</c>. The intended usage is to hide the internal nodes from the user, so the user won't accidentally delete or modify them. Used by some GUI nodes, e.g. <see cref="ColorPicker" />. See <see cref="Node.InternalMode" /> for available modes.</para>
    /// <para><b>Note:</b> If the child node already has a parent, the function will fail. Use <see cref="Node.RemoveChild(Godot.Node)" /> first to remove the node from its current parent. For example:</para>
    /// <para><code>
    /// Node childNode = GetChild(0);
    /// if (childNode.GetParent() != null)
    /// {
    /// childNode.GetParent().RemoveChild(childNode);
    /// }
    /// AddChild(childNode);
    /// </code></para>
    /// <para>If you need the child node to be added below a specific node in the list of children, use <see cref="Node.AddSibling(Godot.Node,System.Boolean)" /> instead of this method.</para>
    /// <para><b>Note:</b> If you want a child to be persisted to a <see cref="PackedScene" />, you must set <see cref="Node.Owner" /> in addition to calling <see cref="Node.AddChild(Godot.Node,System.Boolean,Godot.Node.InternalMode)" />. This is typically relevant for <a href="$DOCS_URL/tutorials/plugins/running_code_in_the_editor.html">tool scripts</a> and <a href="$DOCS_URL/tutorials/plugins/editor/index.html">editor plugins</a>. If <see cref="Node.AddChild(Godot.Node,System.Boolean,Godot.Node.InternalMode)" /> is called without setting <see cref="Node.Owner" />, the newly added <see cref="Node" /> will not be visible in the scene tree, though it will be visible in the 2D/3D view.</para>
    /// </summary>
    void AddChild(Node node, bool forceReadableName, Node.InternalMode @internal);
    /// <summary>
    /// <para>Adds a <paramref name="sibling" /> node to current's node parent, at the same level as that node, right below it.</para>
    /// <para>If <paramref name="forceReadableName" /> is <c>true</c>, improves the readability of the added <paramref name="sibling" />. If not named, the <paramref name="sibling" /> is renamed to its type, and if it shares <see cref="Node.Name" /> with a sibling, a number is suffixed more appropriately. This operation is very slow. As such, it is recommended leaving this to <c>false</c>, which assigns a dummy name featuring <c>@</c> in both situations.</para>
    /// <para>Use <see cref="Node.AddChild(Godot.Node,System.Boolean,Godot.Node.InternalMode)" /> instead of this method if you don't need the child node to be added below a specific node in the list of children.</para>
    /// <para><b>Note:</b> If this node is internal, the new sibling will be internal too (see <c>internal</c> parameter in <see cref="Node.AddChild(Godot.Node,System.Boolean,Godot.Node.InternalMode)" />).</para>
    /// </summary>
    void AddSibling(Node sibling, bool forceReadableName);
    /// <summary>
    /// <para>Adds the node to a group. Groups are helpers to name and organize a subset of nodes, for example "enemies" or "collectables". A node can be in any number of groups. Nodes can be assigned a group at any time, but will not be added until they are inside the scene tree (see <see cref="Node.IsInsideTree" />). See notes in the description, and the group methods in <see cref="SceneTree" />.</para>
    /// <para>The <paramref name="persistent" /> option is used when packing node to <see cref="PackedScene" /> and saving to file. Non-persistent groups aren't stored.</para>
    /// <para><b>Note:</b> For performance reasons, the order of node groups is <i>not</i> guaranteed. The order of node groups should not be relied upon as it can vary across project runs.</para>
    /// </summary>
    void AddToGroup(StringName @group, bool persistent);
    /// <summary>
    /// <para>This function is similar to <see cref="GodotObject.CallDeferred(Godot.StringName,Godot.Variant[])" /> except that the call will take place when the node thread group is processed. If the node thread group processes in sub-threads, then the call will be done on that thread, right before <see cref="Node.NotificationProcess" /> or <see cref="Node.NotificationPhysicsProcess" />, the <see cref="Node._Process(System.Double)" /> or <see cref="Node._PhysicsProcess(System.Double)" /> or their internal versions are called.</para>
    /// </summary>
    Variant CallDeferredThreadGroup(StringName @method, Variant[] args);
    /// <summary>
    /// <para>This function ensures that the calling of this function will succeed, no matter whether it's being done from a thread or not. If called from a thread that is not allowed to call the function, the call will become deferred. Otherwise, the call will go through directly.</para>
    /// </summary>
    Variant CallThreadSafe(StringName @method, Variant[] args);
    /// <summary>
    /// <para>Returns <c>true</c> if the node can process while the scene tree is paused (see <see cref="Node.ProcessMode" />). Always returns <c>true</c> if the scene tree is not paused, and <c>false</c> if the node is not in the tree.</para>
    /// </summary>
    bool CanProcess();
    /// <summary>
    /// <para>Creates a new <see cref="Tween" /> and binds it to this node. This is equivalent of doing:</para>
    /// <para><code>
    /// GetTree().CreateTween().BindNode(this);
    /// </code></para>
    /// <para>The Tween will start automatically on the next process frame or physics frame (depending on <see cref="Tween.TweenProcessMode" />).</para>
    /// </summary>
    Tween CreateTween();
    /// <summary>
    /// <para>Duplicates the node, returning a new node.</para>
    /// <para>You can fine-tune the behavior using the <paramref name="flags" /> (see <see cref="Node.DuplicateFlags" />).</para>
    /// <para><b>Note:</b> It will not work properly if the node contains a script with constructor arguments (i.e. needs to supply arguments to <see cref="GodotObject.#ctor" /> method). In that case, the node will be duplicated without a script.</para>
    /// </summary>
    Node Duplicate(int flags);
    /// <summary>
    /// <para>Add a custom description to a node. It will be displayed in a tooltip when hovered in editor's scene tree.</para>
    /// </summary>
    string EditorDescription { get; set; }
    /// <summary>
    /// <para>Finds the first descendant of this node whose name matches <paramref name="pattern" /> as in <c>String.match</c>. Internal children are also searched over (see <c>internal</c> parameter in <see cref="Node.AddChild(Godot.Node,System.Boolean,Godot.Node.InternalMode)" />).</para>
    /// <para><paramref name="pattern" /> does not match against the full path, just against individual node names. It is case-sensitive, with <c>"*"</c> matching zero or more characters and <c>"?"</c> matching any single character except <c>"."</c>).</para>
    /// <para>If <paramref name="recursive" /> is <c>true</c>, all child nodes are included, even if deeply nested. Nodes are checked in tree order, so this node's first direct child is checked first, then its own direct children, etc., before moving to the second direct child, and so on. If <paramref name="recursive" /> is <c>false</c>, only this node's direct children are matched.</para>
    /// <para>If <paramref name="owned" /> is <c>true</c>, this method only finds nodes who have an assigned <see cref="Node.Owner" />. This is especially important for scenes instantiated through a script, because those scenes don't have an owner.</para>
    /// <para>Returns <c>null</c> if no matching <see cref="Node" /> is found.</para>
    /// <para><b>Note:</b> As this method walks through all the descendants of the node, it is the slowest way to get a reference to another node. Whenever possible, consider using <see cref="Node.GetNode(Godot.NodePath)" /> with unique names instead (see <see cref="Node.UniqueNameInOwner" />), or caching the node references into variable.</para>
    /// <para><b>Note:</b> To find all descendant nodes matching a pattern or a class type, see <see cref="Node.FindChildren(System.String,System.String,System.Boolean,System.Boolean)" />.</para>
    /// </summary>
    Node FindChild(string pattern, bool recursive, bool owned);
    /// <summary>
    /// <para>Finds descendants of this node whose name matches <paramref name="pattern" /> as in <c>String.match</c>, and/or type matches <paramref name="type" /> as in <see cref="GodotObject.IsClass(System.String)" />. Internal children are also searched over (see <c>internal</c> parameter in <see cref="Node.AddChild(Godot.Node,System.Boolean,Godot.Node.InternalMode)" />).</para>
    /// <para><paramref name="pattern" /> does not match against the full path, just against individual node names. It is case-sensitive, with <c>"*"</c> matching zero or more characters and <c>"?"</c> matching any single character except <c>"."</c>).</para>
    /// <para><paramref name="type" /> will check equality or inheritance, and is case-sensitive. <c>"Object"</c> will match a node whose type is <c>"Node"</c> but not the other way around.</para>
    /// <para>If <paramref name="recursive" /> is <c>true</c>, all child nodes are included, even if deeply nested. Nodes are checked in tree order, so this node's first direct child is checked first, then its own direct children, etc., before moving to the second direct child, and so on. If <paramref name="recursive" /> is <c>false</c>, only this node's direct children are matched.</para>
    /// <para>If <paramref name="owned" /> is <c>true</c>, this method only finds nodes who have an assigned <see cref="Node.Owner" />. This is especially important for scenes instantiated through a script, because those scenes don't have an owner.</para>
    /// <para>Returns an empty array if no matching nodes are found.</para>
    /// <para><b>Note:</b> As this method walks through all the descendants of the node, it is the slowest way to get references to other nodes. Whenever possible, consider caching the node references into variables.</para>
    /// <para><b>Note:</b> If you only want to find the first descendant node that matches a pattern, see <see cref="Node.FindChild(System.String,System.Boolean,System.Boolean)" />.</para>
    /// </summary>
    Godot.Collections.Array<Node> FindChildren(string pattern, string @type, bool recursive, bool owned);
    /// <summary>
    /// <para>Finds the first parent of the current node whose name matches <paramref name="pattern" /> as in <c>String.match</c>.</para>
    /// <para><paramref name="pattern" /> does not match against the full path, just against individual node names. It is case-sensitive, with <c>"*"</c> matching zero or more characters and <c>"?"</c> matching any single character except <c>"."</c>).</para>
    /// <para><b>Note:</b> As this method walks upwards in the scene tree, it can be slow in large, deeply nested scene trees. Whenever possible, consider using <see cref="Node.GetNode(Godot.NodePath)" /> with unique names instead (see <see cref="Node.UniqueNameInOwner" />), or caching the node references into variable.</para>
    /// </summary>
    Node FindParent(string pattern);
    /// <summary>
    /// Returns a child node by its index (see <see cref="Node.GetChildCount(System.Boolean)" />).
    /// This method is often used for iterating all children of a node.
    /// Negative indices access the children from the last one.
    /// To access a child node via its name, use <see cref="Node.GetNode(Godot.NodePath)" />.
    /// </summary>
    /// <seealso cref="M:Godot.Node.GetChildOrNull``1(System.Int32,System.Boolean)" />
    /// <param name="idx">Child index.</param>
    /// <param name="includeInternal">
    /// If <see langword="false" />, internal children are skipped (see <c>internal</c>
    /// parameter in <see cref="Node.AddChild(Godot.Node,System.Boolean,Godot.Node.InternalMode)" />).
    /// </param>
    /// <exception cref="T:System.InvalidCastException">
    /// The fetched node can't be casted to the given type <typeparamref name="T" />.
    /// </exception>
    /// <typeparam name="T">The type to cast to. Should be a descendant of <see cref="Node" />.</typeparam>
    /// <returns>
    /// The child <see cref="Node" /> at the given index <paramref name="idx" />.
    /// </returns>
    T GetChild<T>(int idx, bool includeInternal) where T : class;
    /// <summary>
    /// <para>Returns a child node by its index (see <see cref="Node.GetChildCount(System.Boolean)" />). This method is often used for iterating all children of a node.</para>
    /// <para>Negative indices access the children from the last one.</para>
    /// <para>If <paramref name="includeInternal" /> is <c>false</c>, internal children are skipped (see <c>internal</c> parameter in <see cref="Node.AddChild(Godot.Node,System.Boolean,Godot.Node.InternalMode)" />).</para>
    /// <para>To access a child node via its name, use <see cref="Node.GetNode(Godot.NodePath)" />.</para>
    /// </summary>
    Node GetChild(int idx, bool includeInternal);
    /// <summary>
    /// <para>Returns the number of child nodes.</para>
    /// <para>If <paramref name="includeInternal" /> is <c>false</c>, internal children aren't counted (see <c>internal</c> parameter in <see cref="Node.AddChild(Godot.Node,System.Boolean,Godot.Node.InternalMode)" />).</para>
    /// </summary>
    int GetChildCount(bool includeInternal);
    /// <summary>
    /// Returns a child node by its index (see <see cref="Node.GetChildCount(System.Boolean)" />).
    /// This method is often used for iterating all children of a node.
    /// Negative indices access the children from the last one.
    /// To access a child node via its name, use <see cref="Node.GetNode(Godot.NodePath)" />.
    /// </summary>
    /// <seealso cref="M:Godot.Node.GetChild``1(System.Int32,System.Boolean)" />
    /// <param name="idx">Child index.</param>
    /// <param name="includeInternal">
    /// If <see langword="false" />, internal children are skipped (see <c>internal</c>
    /// parameter in <see cref="Node.AddChild(Godot.Node,System.Boolean,Godot.Node.InternalMode)" />).
    /// </param>
    /// <typeparam name="T">The type to cast to. Should be a descendant of <see cref="Node" />.</typeparam>
    /// <returns>
    /// The child <see cref="Node" /> at the given index <paramref name="idx" />, or <see langword="null" /> if not found.
    /// </returns>
    T GetChildOrNull<T>(int idx, bool includeInternal) where T : class;
    /// <summary>
    /// <para>Returns an array of references to node's children.</para>
    /// <para>If <paramref name="includeInternal" /> is <c>false</c>, the returned array won't include internal children (see <c>internal</c> parameter in <see cref="Node.AddChild(Godot.Node,System.Boolean,Godot.Node.InternalMode)" />).</para>
    /// </summary>
    Godot.Collections.Array<Node> GetChildren(bool includeInternal);
    /// <summary>
    /// <para>Returns an array listing the groups that the node is a member of.</para>
    /// <para><b>Note:</b> For performance reasons, the order of node groups is <i>not</i> guaranteed. The order of node groups should not be relied upon as it can vary across project runs.</para>
    /// <para><b>Note:</b> The engine uses some group names internally (all starting with an underscore). To avoid conflicts with internal groups, do not add custom groups whose name starts with an underscore. To exclude internal groups while looping over <see cref="Node.GetGroups" />, use the following snippet:</para>
    /// <para><code>
    /// // Stores the node's non-internal groups only (as a List of strings).
    /// List&lt;string&gt; nonInternalGroups = new List&lt;string&gt;();
    /// foreach (string group in GetGroups())
    /// {
    /// if (!group.BeginsWith("_"))
    /// nonInternalGroups.Add(group);
    /// }
    /// </code></para>
    /// </summary>
    Godot.Collections.Array<StringName> GetGroups();
    /// <summary>
    /// <para>Returns the node's order in the scene tree branch. For example, if called on the first child node the position is <c>0</c>.</para>
    /// <para>If <paramref name="includeInternal" /> is <c>false</c>, the index won't take internal children into account, i.e. first non-internal child will have index of 0 (see <c>internal</c> parameter in <see cref="Node.AddChild(Godot.Node,System.Boolean,Godot.Node.InternalMode)" />).</para>
    /// </summary>
    int GetIndex(bool includeInternal);
    /// <summary>
    /// <para>Returns the <see cref="Window" /> that contains this node, or the last exclusive child in a chain of windows starting with the one that contains this node.</para>
    /// </summary>
    Window GetLastExclusiveWindow();
    /// <summary>
    /// <para>Returns the peer ID of the multiplayer authority for this node. See <see cref="Node.SetMultiplayerAuthority(System.Int32,System.Boolean)" />.</para>
    /// </summary>
    int GetMultiplayerAuthority();
    /// <summary>
    /// Fetches a node. The <see cref="NodePath" /> can be either a relative path (from
    /// the current node) or an absolute path (in the scene tree) to a node. If the path
    /// does not exist, a <see langword="null" /> instance is returned and an error
    /// is logged. Attempts to access methods on the return value will result in an
    /// "Attempt to call &lt;method&gt; on a null instance." error.
    /// Note: Fetching absolute paths only works when the node is inside the scene tree
    /// (see <see cref="Node.IsInsideTree" />).
    /// </summary>
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
    /// <seealso cref="M:Godot.Node.GetNodeOrNull``1(Godot.NodePath)" />
    /// <param name="path">The path to the node to fetch.</param>
    /// <exception cref="T:System.InvalidCastException">
    /// The fetched node can't be casted to the given type <typeparamref name="T" />.
    /// </exception>
    /// <typeparam name="T">The type to cast to. Should be a descendant of <see cref="Node" />.</typeparam>
    /// <returns>
    /// The <see cref="Node" /> at the given <paramref name="path" />.
    /// </returns>
    T GetNode<T>(NodePath path) where T : class;
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
    Node GetNode(NodePath path);
    /// <summary>
    /// <para>Fetches a node and one of its resources as specified by the <see cref="NodePath" />'s subname (e.g. <c>Area2D/CollisionShape2D:shape</c>). If several nested resources are specified in the <see cref="NodePath" />, the last one will be fetched.</para>
    /// <para>The return value is an array of size 3: the first index points to the <see cref="Node" /> (or <c>null</c> if not found), the second index points to the <see cref="Resource" /> (or <c>null</c> if not found), and the third index is the remaining <see cref="NodePath" />, if any.</para>
    /// <para>For example, assuming that <c>Area2D/CollisionShape2D</c> is a valid node and that its <c>shape</c> property has been assigned a <see cref="RectangleShape2D" /> resource, one could have this kind of output:</para>
    /// <para><code>
    /// GD.Print(GetNodeAndResource("Area2D/CollisionShape2D")); // [[CollisionShape2D:1161], Null, ]
    /// GD.Print(GetNodeAndResource("Area2D/CollisionShape2D:shape")); // [[CollisionShape2D:1161], [RectangleShape2D:1156], ]
    /// GD.Print(GetNodeAndResource("Area2D/CollisionShape2D:shape:extents")); // [[CollisionShape2D:1161], [RectangleShape2D:1156], :extents]
    /// </code></para>
    /// </summary>
    Godot.Collections.Array GetNodeAndResource(NodePath path);
    /// <summary>
    /// Similar to <see cref="Node.GetNode(Godot.NodePath)" />, but does not log an error if <paramref name="path" />
    /// does not point to a valid <see cref="Node" />.
    /// </summary>
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
    /// <seealso cref="M:Godot.Node.GetNode``1(Godot.NodePath)" />
    /// <param name="path">The path to the node to fetch.</param>
    /// <typeparam name="T">The type to cast to. Should be a descendant of <see cref="Node" />.</typeparam>
    /// <returns>
    /// The <see cref="Node" /> at the given <paramref name="path" />, or <see langword="null" /> if not found.
    /// </returns>
    T GetNodeOrNull<T>(NodePath path) where T : class;
    /// <summary>
    /// <para>Similar to <see cref="Node.GetNode(Godot.NodePath)" />, but does not log an error if <paramref name="path" /> does not point to a valid <see cref="Node" />.</para>
    /// </summary>
    Node GetNodeOrNull(NodePath path);
    /// <summary>
    /// The node owner. A node can have any other node as owner (as long as it is
    /// a valid parent, grandparent, etc. ascending in the tree). When saving a
    /// node (using <see cref="PackedScene" />), all the nodes it owns will be saved
    /// with it. This allows for the creation of complex <see cref="SceneTree" />s,
    /// with instancing and subinstancing.
    /// </summary>
    /// <seealso cref="M:Godot.Node.GetOwnerOrNull``1" />
    /// <exception cref="T:System.InvalidCastException">
    /// The fetched node can't be casted to the given type <typeparamref name="T" />.
    /// </exception>
    /// <typeparam name="T">The type to cast to. Should be a descendant of <see cref="Node" />.</typeparam>
    /// <returns>
    /// The owner <see cref="Node" />.
    /// </returns>
    T GetOwner<T>() where T : class;
    /// <summary>
    /// The node owner. A node can have any other node as owner (as long as it is
    /// a valid parent, grandparent, etc. ascending in the tree). When saving a
    /// node (using <see cref="PackedScene" />), all the nodes it owns will be saved
    /// with it. This allows for the creation of complex <see cref="SceneTree" />s,
    /// with instancing and subinstancing.
    /// </summary>
    /// <seealso cref="M:Godot.Node.GetOwner``1" />
    /// <typeparam name="T">The type to cast to. Should be a descendant of <see cref="Node" />.</typeparam>
    /// <returns>
    /// The owner <see cref="Node" />, or <see langword="null" /> if there is no owner.
    /// </returns>
    T GetOwnerOrNull<T>() where T : class;
    /// <summary>
    /// Returns the parent node of the current node, or a <see langword="null" /> instance
    /// if the node lacks a parent.
    /// </summary>
    /// <seealso cref="M:Godot.Node.GetParentOrNull``1" />
    /// <exception cref="T:System.InvalidCastException">
    /// The fetched node can't be casted to the given type <typeparamref name="T" />.
    /// </exception>
    /// <typeparam name="T">The type to cast to. Should be a descendant of <see cref="Node" />.</typeparam>
    /// <returns>
    /// The parent <see cref="Node" />.
    /// </returns>
    T GetParent<T>() where T : class;
    /// <summary>
    /// <para>Returns the parent node of the current node, or <c>null</c> if the node lacks a parent.</para>
    /// </summary>
    Node GetParent();
    /// <summary>
    /// Returns the parent node of the current node, or a <see langword="null" /> instance
    /// if the node lacks a parent.
    /// </summary>
    /// <seealso cref="M:Godot.Node.GetParent``1" />
    /// <typeparam name="T">The type to cast to. Should be a descendant of <see cref="Node" />.</typeparam>
    /// <returns>
    /// The parent <see cref="Node" />, or <see langword="null" /> if the node has no parent.
    /// </returns>
    T GetParentOrNull<T>() where T : class;
    /// <summary>
    /// <para>Returns the absolute path of the current node. This only works if the current node is inside the scene tree (see <see cref="Node.IsInsideTree" />).</para>
    /// </summary>
    NodePath GetPath();
    /// <summary>
    /// <para>Returns the relative <see cref="NodePath" /> from this node to the specified <paramref name="node" />. Both nodes must be in the same scene or the function will fail.</para>
    /// <para>If <paramref name="useUniquePath" /> is <c>true</c>, returns the shortest path considering unique node.</para>
    /// <para><b>Note:</b> If you get a relative path which starts from a unique node, the path may be longer than a normal relative path due to the addition of the unique node's name.</para>
    /// </summary>
    NodePath GetPathTo(Node node, bool useUniquePath);
    /// <summary>
    /// <para>Returns the time elapsed (in seconds) since the last physics-bound frame (see <see cref="Node._PhysicsProcess(System.Double)" />). This is always a constant value in physics processing unless the frames per second is changed via <see cref="Engine.PhysicsTicksPerSecond" />.</para>
    /// </summary>
    double GetPhysicsProcessDeltaTime();
    /// <summary>
    /// <para>Returns the time elapsed (in seconds) since the last process callback. This value may vary from frame to frame.</para>
    /// </summary>
    double GetProcessDeltaTime();
    /// <summary>
    /// <para>Returns <c>true</c> if this is an instance load placeholder. See <see cref="InstancePlaceholder" />.</para>
    /// </summary>
    bool GetSceneInstanceLoadPlaceholder();
    /// <summary>
    /// <para>Returns the <see cref="SceneTree" /> that contains this node.</para>
    /// </summary>
    SceneTree GetTree();
    /// <summary>
    /// <para>Returns the tree as a <see cref="T:System.String" />. Used mainly for debugging purposes. This version displays the path relative to the current node, and is good for copy/pasting into the <see cref="Node.GetNode(Godot.NodePath)" /> function. It also can be used in game UI/UX.</para>
    /// <para><b>Example output:</b></para>
    /// <para><code>
    /// TheGame
    /// TheGame/Menu
    /// TheGame/Menu/Label
    /// TheGame/Menu/Camera2D
    /// TheGame/SplashScreen
    /// TheGame/SplashScreen/Camera2D
    /// </code></para>
    /// </summary>
    string GetTreeString();
    /// <summary>
    /// <para>Similar to <see cref="Node.GetTreeString" />, this returns the tree as a <see cref="T:System.String" />. This version displays a more graphical representation similar to what is displayed in the Scene Dock. It is useful for inspecting larger trees.</para>
    /// <para><b>Example output:</b></para>
    /// <para><code>
    /// ┖╴TheGame
    /// ┠╴Menu
    /// ┃  ┠╴Label
    /// ┃  ┖╴Camera2D
    /// ┖╴SplashScreen
    /// ┖╴Camera2D
    /// </code></para>
    /// </summary>
    string GetTreeStringPretty();
    /// <summary>
    /// <para>Returns the node's <see cref="Viewport" />.</para>
    /// </summary>
    Viewport GetViewport();
    /// <summary>
    /// <para>Returns the <see cref="Window" /> that contains this node. If the node is in the main window, this is equivalent to getting the root node (<c>get_tree().get_root()</c>).</para>
    /// </summary>
    Window GetWindow();
    /// <summary>
    /// <para>Returns <c>true</c> if the node that the <see cref="NodePath" /> points to exists.</para>
    /// </summary>
    bool HasNode(NodePath path);
    /// <summary>
    /// <para>Returns <c>true</c> if the <see cref="NodePath" /> points to a valid node and its subname points to a valid resource, e.g. <c>Area2D/CollisionShape2D:shape</c>. Properties with a non-<see cref="Resource" /> type (e.g. nodes or primitive math types) are not considered resources.</para>
    /// </summary>
    bool HasNodeAndResource(NodePath path);
    /// <summary>
    /// <para>Returns <c>true</c> if the given node is a direct or indirect child of the current node.</para>
    /// </summary>
    bool IsAncestorOf(Node node);
    /// <summary>
    /// <para>Returns <c>true</c> if the node is folded (collapsed) in the Scene dock. This method is only intended for use with editor tooling.</para>
    /// </summary>
    bool IsDisplayedFolded();
    /// <summary>
    /// <para>Returns <c>true</c> if <paramref name="node" /> has editable children enabled relative to this node. This method is only intended for use with editor tooling.</para>
    /// </summary>
    bool IsEditableInstance(Node node);
    /// <summary>
    /// <para>Returns <c>true</c> if the given node occurs later in the scene hierarchy than the current node.</para>
    /// </summary>
    bool IsGreaterThan(Node node);
    /// <summary>
    /// <para>Returns <c>true</c> if this node is in the specified group. See notes in the description, and the group methods in <see cref="SceneTree" />.</para>
    /// </summary>
    bool IsInGroup(StringName @group);
    /// <summary>
    /// <para>Returns <c>true</c> if this node is currently inside a <see cref="SceneTree" />.</para>
    /// </summary>
    bool IsInsideTree();
    /// <summary>
    /// <para>Returns <c>true</c> if the local system is the multiplayer authority of this node.</para>
    /// </summary>
    bool IsMultiplayerAuthority();
    /// <summary>
    /// <para>Returns <c>true</c> if the node is ready, i.e. it's inside scene tree and all its children are initialized.</para>
    /// <para><see cref="Node.RequestReady" /> resets it back to <c>false</c>.</para>
    /// </summary>
    bool IsNodeReady();
    /// <summary>
    /// <para>Returns <c>true</c> if physics processing is enabled (see <see cref="Node.SetPhysicsProcess(System.Boolean)" />).</para>
    /// </summary>
    bool IsPhysicsProcessing();
    /// <summary>
    /// <para>Returns <c>true</c> if internal physics processing is enabled (see <see cref="Node.SetPhysicsProcessInternal(System.Boolean)" />).</para>
    /// </summary>
    bool IsPhysicsProcessingInternal();
    /// <summary>
    /// <para>Returns <c>true</c> if processing is enabled (see <see cref="Node.SetProcess(System.Boolean)" />).</para>
    /// </summary>
    bool IsProcessing();
    /// <summary>
    /// <para>Returns <c>true</c> if the node is processing input (see <see cref="Node.SetProcessInput(System.Boolean)" />).</para>
    /// </summary>
    bool IsProcessingInput();
    /// <summary>
    /// <para>Returns <c>true</c> if internal processing is enabled (see <see cref="Node.SetProcessInternal(System.Boolean)" />).</para>
    /// </summary>
    bool IsProcessingInternal();
    /// <summary>
    /// <para>Returns <c>true</c> if the node is processing shortcuts (see <see cref="Node.SetProcessShortcutInput(System.Boolean)" />).</para>
    /// </summary>
    bool IsProcessingShortcutInput();
    /// <summary>
    /// <para>Returns <c>true</c> if the node is processing unhandled input (see <see cref="Node.SetProcessUnhandledInput(System.Boolean)" />).</para>
    /// </summary>
    bool IsProcessingUnhandledInput();
    /// <summary>
    /// <para>Returns <c>true</c> if the node is processing unhandled key input (see <see cref="Node.SetProcessUnhandledKeyInput(System.Boolean)" />).</para>
    /// </summary>
    bool IsProcessingUnhandledKeyInput();
    /// <summary>
    /// <para>Moves a child node to a different index (order) among the other children. Since calls, signals, etc. are performed by tree order, changing the order of children nodes may be useful. If <paramref name="toIndex" /> is negative, the index will be counted from the end.</para>
    /// <para><b>Note:</b> Internal children can only be moved within their expected "internal range" (see <c>internal</c> parameter in <see cref="Node.AddChild(Godot.Node,System.Boolean,Godot.Node.InternalMode)" />).</para>
    /// </summary>
    void MoveChild(Node childNode, int toIndex);
    /// <summary>
    /// <para>The <see cref="MultiplayerApi" /> instance associated with this node. See <see cref="SceneTree.GetMultiplayer(Godot.NodePath)" />.</para>
    /// <para><b>Note:</b> Renaming the node, or moving it in the tree, will not move the <see cref="MultiplayerApi" /> to the new path, you will have to update this manually.</para>
    /// </summary>
    MultiplayerApi Multiplayer { get; }
    /// <summary>
    /// <para>The name of the node. This name is unique among the siblings (other child nodes from the same parent). When set to an existing name, the node will be automatically renamed.</para>
    /// <para><b>Note:</b> Auto-generated names might include the <c>@</c> character, which is reserved for unique names when using <see cref="Node.AddChild(Godot.Node,System.Boolean,Godot.Node.InternalMode)" />. When setting the name manually, any <c>@</c> will be removed.</para>
    /// </summary>
    StringName Name { get; set; }
    /// <summary>
    /// <para>Similar to <see cref="Node.CallDeferredThreadGroup(Godot.StringName,Godot.Variant[])" />, but for notifications.</para>
    /// </summary>
    void NotifyDeferredThreadGroup(int what);
    /// <summary>
    /// <para>Similar to <see cref="Node.CallThreadSafe(Godot.StringName,Godot.Variant[])" />, but for notifications.</para>
    /// </summary>
    void NotifyThreadSafe(int what);
    /// <summary>
    /// <para>The node owner. A node can have any ancestor node as owner (i.e. a parent, grandparent, etc. node ascending in the tree). This implies that <see cref="Node.AddChild(Godot.Node,System.Boolean,Godot.Node.InternalMode)" /> should be called before setting the owner, so that this relationship of parenting exists. When saving a node (using <see cref="PackedScene" />), all the nodes it owns will be saved with it. This allows for the creation of complex scene trees, with instancing and subinstancing.</para>
    /// <para><b>Note:</b> If you want a child to be persisted to a <see cref="PackedScene" />, you must set <see cref="Node.Owner" /> in addition to calling <see cref="Node.AddChild(Godot.Node,System.Boolean,Godot.Node.InternalMode)" />. This is typically relevant for <a href="$DOCS_URL/tutorials/plugins/running_code_in_the_editor.html">tool scripts</a> and <a href="$DOCS_URL/tutorials/plugins/editor/index.html">editor plugins</a>. If a new node is added to the tree without setting its owner as an ancestor in that tree, it will be visible in the 2D/3D view, but not in the scene tree (and not persisted when packing or saving).</para>
    /// </summary>
    Node Owner { get; set; }
    /// <summary>
    /// <para>Prints the tree to stdout. Used mainly for debugging purposes. This version displays the path relative to the current node, and is good for copy/pasting into the <see cref="Node.GetNode(Godot.NodePath)" /> function.</para>
    /// <para><b>Example output:</b></para>
    /// <para><code>
    /// TheGame
    /// TheGame/Menu
    /// TheGame/Menu/Label
    /// TheGame/Menu/Camera2D
    /// TheGame/SplashScreen
    /// TheGame/SplashScreen/Camera2D
    /// </code></para>
    /// </summary>
    void PrintTree();
    /// <summary>
    /// <para>Similar to <see cref="Node.PrintTree" />, this prints the tree to stdout. This version displays a more graphical representation similar to what is displayed in the Scene Dock. It is useful for inspecting larger trees.</para>
    /// <para><b>Example output:</b></para>
    /// <para><code>
    /// ┖╴TheGame
    /// ┠╴Menu
    /// ┃  ┠╴Label
    /// ┃  ┖╴Camera2D
    /// ┖╴SplashScreen
    /// ┖╴Camera2D
    /// </code></para>
    /// </summary>
    void PrintTreePretty();
    /// <summary>
    /// <para>Can be used to pause or unpause the node, or make the node paused based on the <see cref="SceneTree" />, or make it inherit the process mode from its parent (default).</para>
    /// </summary>
    Node.ProcessModeEnum ProcessMode { get; set; }
    /// <summary>
    /// <para>Similar to <see cref="Node.ProcessPriority" /> but for <see cref="Node.NotificationPhysicsProcess" />, <see cref="Node._PhysicsProcess(System.Double)" /> or the internal version.</para>
    /// </summary>
    int ProcessPhysicsPriority { get; set; }
    /// <summary>
    /// <para>The node's priority in the execution order of the enabled processing callbacks (i.e. <see cref="Node.NotificationProcess" />, <see cref="Node.NotificationPhysicsProcess" /> and their internal counterparts). Nodes whose process priority value is <i>lower</i> will have their processing callbacks executed first.</para>
    /// </summary>
    int ProcessPriority { get; set; }
    /// <summary>
    /// <para>Set the process thread group for this node (basically, whether it receives <see cref="Node.NotificationProcess" />, <see cref="Node.NotificationPhysicsProcess" />, <see cref="Node._Process(System.Double)" /> or <see cref="Node._PhysicsProcess(System.Double)" /> (and the internal versions) on the main thread or in a sub-thread.</para>
    /// <para>By default, the thread group is <see cref="Node.ProcessThreadGroupEnum.Inherit" />, which means that this node belongs to the same thread group as the parent node. The thread groups means that nodes in a specific thread group will process together, separate to other thread groups (depending on <see cref="Node.ProcessThreadGroupOrder" />). If the value is set is <see cref="Node.ProcessThreadGroupEnum.SubThread" />, this thread group will occur on a sub thread (not the main thread), otherwise if set to <see cref="Node.ProcessThreadGroupEnum.MainThread" /> it will process on the main thread. If there is not a parent or grandparent node set to something other than inherit, the node will belong to the <i>default thread group</i>. This default group will process on the main thread and its group order is 0.</para>
    /// <para>During processing in a sub-thread, accessing most functions in nodes outside the thread group is forbidden (and it will result in an error in debug mode). Use <see cref="GodotObject.CallDeferred(Godot.StringName,Godot.Variant[])" />, <see cref="Node.CallThreadSafe(Godot.StringName,Godot.Variant[])" />, <see cref="Node.CallDeferredThreadGroup(Godot.StringName,Godot.Variant[])" /> and the likes in order to communicate from the thread groups to the main thread (or to other thread groups).</para>
    /// <para>To better understand process thread groups, the idea is that any node set to any other value than <see cref="Node.ProcessThreadGroupEnum.Inherit" /> will include any children (and grandchildren) nodes set to inherit into its process thread group. this means that the processing of all the nodes in the group will happen together, at the same time as the node including them.</para>
    /// </summary>
    Node.ProcessThreadGroupEnum ProcessThreadGroup { get; set; }
    /// <summary>
    /// <para>Change the process thread group order. Groups with a lesser order will process before groups with a greater order. This is useful when a large amount of nodes process in sub thread and, afterwards, another group wants to collect their result in the main thread, as an example.</para>
    /// </summary>
    int ProcessThreadGroupOrder { get; set; }
    /// <summary>
    /// <para>Set whether the current thread group will process messages (calls to <see cref="Node.CallDeferredThreadGroup(Godot.StringName,Godot.Variant[])" /> on threads, and whether it wants to receive them during regular process or physics process callbacks.</para>
    /// </summary>
    Node.ProcessThreadMessagesEnum ProcessThreadMessages { get; set; }
    /// <summary>
    /// <para>Calls the given method (if present) with the arguments given in <paramref name="args" /> on this node and recursively on all its children. If the <paramref name="parentFirst" /> argument is <c>true</c>, the method will be called on the current node first, then on all its children. If <paramref name="parentFirst" /> is <c>false</c>, the children will be called first.</para>
    /// </summary>
    void PropagateCall(StringName @method, Godot.Collections.Array args, bool parentFirst);
    /// <summary>
    /// <para>Notifies the current node and all its children recursively by calling <see cref="GodotObject.Notification(System.Int32,System.Boolean)" /> on all of them.</para>
    /// </summary>
    void PropagateNotification(int what);
    /// <summary>
    /// <para>Queues a node for deletion at the end of the current frame. When deleted, all of its child nodes will be deleted as well, and all references to the node and its children will become invalid, see <see cref="GodotObject.Free" />.</para>
    /// <para>It is safe to call <see cref="Node.QueueFree" /> multiple times per frame on a node, and to <see cref="GodotObject.Free" /> a node that is currently queued for deletion. Use <see cref="GodotObject.IsQueuedForDeletion" /> to check whether a node will be deleted at the end of the frame.</para>
    /// <para>The node will only be freed after all other deferred calls are finished, so using <see cref="Node.QueueFree" /> is not always the same as calling <see cref="GodotObject.Free" /> through <see cref="GodotObject.CallDeferred(Godot.StringName,Godot.Variant[])" />.</para>
    /// </summary>
    void QueueFree();
    /// <summary>
    /// <para>Removes a child node. The node is NOT deleted and must be deleted manually.</para>
    /// <para><b>Note:</b> This function may set the <see cref="Node.Owner" /> of the removed Node (or its descendants) to be <c>null</c>, if that <see cref="Node.Owner" /> is no longer a parent or ancestor.</para>
    /// </summary>
    void RemoveChild(Node node);
    /// <summary>
    /// <para>Removes a node from the <paramref name="group" />. Does nothing if the node is not in the <paramref name="group" />. See notes in the description, and the group methods in <see cref="SceneTree" />.</para>
    /// </summary>
    void RemoveFromGroup(StringName @group);
    /// <summary>
    /// <para>Changes the parent of this <see cref="Node" /> to the <paramref name="newParent" />. The node needs to already have a parent.</para>
    /// <para>If <paramref name="keepGlobalTransform" /> is <c>true</c>, the node's global transform will be preserved if supported. <see cref="Node2D" />, <see cref="Node3D" /> and <see cref="Control" /> support this argument (but <see cref="Control" /> keeps only position).</para>
    /// </summary>
    void Reparent(Node newParent, bool keepGlobalTransform);
    /// <summary>
    /// <para>Replaces a node in a scene by the given one. Subscriptions that pass through this node will be lost.</para>
    /// <para>If <paramref name="keepGroups" /> is <c>true</c>, the <paramref name="node" /> is added to the same groups that the replaced node is in.</para>
    /// <para><b>Note:</b> The given node will become the new parent of any child nodes that the replaced node had.</para>
    /// <para><b>Note:</b> The replaced node is not automatically freed, so you either need to keep it in a variable for later use or free it using <see cref="GodotObject.Free" />.</para>
    /// </summary>
    void ReplaceBy(Node node, bool keepGroups);
    /// <summary>
    /// <para>Requests that <see cref="Node._Ready" /> be called again. Note that the method won't be called immediately, but is scheduled for when the node is added to the scene tree again. <see cref="Node._Ready" /> is called only for the node which requested it, which means that you need to request ready for each child if you want them to call <see cref="Node._Ready" /> too (in which case, <see cref="Node._Ready" /> will be called in the same order as it would normally).</para>
    /// </summary>
    void RequestReady();
    /// <summary>
    /// <para>Sends a remote procedure call request for the given <paramref name="method" /> to peers on the network (and locally), optionally sending all additional arguments as arguments to the method called by the RPC. The call request will only be received by nodes with the same <see cref="NodePath" />, including the exact same node name. Behavior depends on the RPC configuration for the given method, see <see cref="Node.RpcConfig(Godot.StringName,Godot.Variant)" /> and [annotation @GDScript.@rpc]. Methods are not exposed to RPCs by default. Returns <c>null</c>.</para>
    /// <para><b>Note:</b> You can only safely use RPCs on clients after you received the <c>connected_to_server</c> signal from the <see cref="MultiplayerApi" />. You also need to keep track of the connection state, either by the <see cref="MultiplayerApi" /> signals like <c>server_disconnected</c> or by checking <c>get_multiplayer().peer.get_connection_status() == CONNECTION_CONNECTED</c>.</para>
    /// </summary>
    Error Rpc(StringName @method, Variant[] args);
    /// <summary>
    /// <para>Changes the RPC mode for the given <paramref name="method" /> with the given <paramref name="config" /> which should be <c>null</c> (to disable) or a <see cref="Collections.Dictionary" /> in the form:</para>
    /// <para><code>
    /// {
    /// rpc_mode = MultiplayerAPI.RPCMode,
    /// transfer_mode = MultiplayerPeer.TransferMode,
    /// call_local = false,
    /// channel = 0,
    /// }
    /// </code></para>
    /// <para>See <see cref="MultiplayerApi.RpcMode" /> and <see cref="MultiplayerPeer.TransferModeEnum" />. An alternative is annotating methods and properties with the corresponding [annotation @GDScript.@rpc] annotation (<c>@rpc("any_peer")</c>, <c>@rpc("authority")</c>). By default, methods are not exposed to networking (and RPCs).</para>
    /// </summary>
    void RpcConfig(StringName @method, Variant config);
    /// <summary>
    /// <para>Sends a <see cref="Node.Rpc(Godot.StringName,Godot.Variant[])" /> to a specific peer identified by <paramref name="peerId" /> (see <see cref="MultiplayerPeer.SetTargetPeer(System.Int32)" />). Returns <c>null</c>.</para>
    /// </summary>
    Error RpcId(long peerId, StringName @method, Variant[] args);
    /// <summary>
    /// <para>If a scene is instantiated from a file, its topmost node contains the absolute file path from which it was loaded in <see cref="Node.SceneFilePath" /> (e.g. <c>res://levels/1.tscn</c>). Otherwise, <see cref="Node.SceneFilePath" /> is set to an empty string.</para>
    /// </summary>
    string SceneFilePath { get; set; }
    /// <summary>
    /// <para>Similar to <see cref="Node.CallDeferredThreadGroup(Godot.StringName,Godot.Variant[])" />, but for setting properties.</para>
    /// </summary>
    void SetDeferredThreadGroup(StringName @property, Variant value);
    /// <summary>
    /// <para>Sets the folded state of the node in the Scene dock. This method is only intended for use with editor tooling.</para>
    /// </summary>
    void SetDisplayFolded(bool fold);
    /// <summary>
    /// <para>Sets the editable children state of <paramref name="node" /> relative to this node. This method is only intended for use with editor tooling.</para>
    /// </summary>
    void SetEditableInstance(Node node, bool isEditable);
    /// <summary>
    /// <para>Sets the node's multiplayer authority to the peer with the given peer ID. The multiplayer authority is the peer that has authority over the node on the network. Useful in conjunction with <see cref="Node.RpcConfig(Godot.StringName,Godot.Variant)" /> and the <see cref="MultiplayerApi" />. Defaults to peer ID 1 (the server). If <paramref name="recursive" />, the given peer is recursively set as the authority for all children of this node.</para>
    /// <para><b>Warning:</b> This does <b>not</b> automatically replicate the new authority to other peers. It is developer's responsibility to do so. You can propagate the information about the new authority using <see cref="MultiplayerSpawner.SpawnFunction" />, an RPC, or using a <see cref="MultiplayerSynchronizer" />. Also, the parent's authority does <b>not</b> propagate to newly added children.</para>
    /// </summary>
    void SetMultiplayerAuthority(int id, bool recursive);
    /// <summary>
    /// <para>Enables or disables physics (i.e. fixed framerate) processing. When a node is being processed, it will receive a <see cref="Node.NotificationPhysicsProcess" /> at a fixed (usually 60 FPS, see <see cref="Engine.PhysicsTicksPerSecond" /> to change) interval (and the <see cref="Node._PhysicsProcess(System.Double)" /> callback will be called if exists). Enabled automatically if <see cref="Node._PhysicsProcess(System.Double)" /> is overridden. Any calls to this before <see cref="Node._Ready" /> will be ignored.</para>
    /// </summary>
    void SetPhysicsProcess(bool enable);
    /// <summary>
    /// <para>Enables or disables internal physics for this node. Internal physics processing happens in isolation from the normal <see cref="Node._PhysicsProcess(System.Double)" /> calls and is used by some nodes internally to guarantee proper functioning even if the node is paused or physics processing is disabled for scripting (<see cref="Node.SetPhysicsProcess(System.Boolean)" />). Only useful for advanced uses to manipulate built-in nodes' behavior.</para>
    /// <para><b>Warning:</b> Built-in Nodes rely on the internal processing for their own logic, so changing this value from your code may lead to unexpected behavior. Script access to this internal logic is provided for specific advanced uses, but is unsafe and not supported.</para>
    /// </summary>
    void SetPhysicsProcessInternal(bool enable);
    /// <summary>
    /// <para>Enables or disables processing. When a node is being processed, it will receive a <see cref="Node.NotificationProcess" /> on every drawn frame (and the <see cref="Node._Process(System.Double)" /> callback will be called if exists). Enabled automatically if <see cref="Node._Process(System.Double)" /> is overridden. Any calls to this before <see cref="Node._Ready" /> will be ignored.</para>
    /// </summary>
    void SetProcess(bool enable);
    /// <summary>
    /// <para>Enables or disables input processing. This is not required for GUI controls! Enabled automatically if <see cref="Node._Input(Godot.InputEvent)" /> is overridden. Any calls to this before <see cref="Node._Ready" /> will be ignored.</para>
    /// </summary>
    void SetProcessInput(bool enable);
    /// <summary>
    /// <para>Enables or disabled internal processing for this node. Internal processing happens in isolation from the normal <see cref="Node._Process(System.Double)" /> calls and is used by some nodes internally to guarantee proper functioning even if the node is paused or processing is disabled for scripting (<see cref="Node.SetProcess(System.Boolean)" />). Only useful for advanced uses to manipulate built-in nodes' behavior.</para>
    /// <para><b>Warning:</b> Built-in Nodes rely on the internal processing for their own logic, so changing this value from your code may lead to unexpected behavior. Script access to this internal logic is provided for specific advanced uses, but is unsafe and not supported.</para>
    /// </summary>
    void SetProcessInternal(bool enable);
    /// <summary>
    /// <para>Enables shortcut processing. Enabled automatically if <see cref="Node._ShortcutInput(Godot.InputEvent)" /> is overridden. Any calls to this before <see cref="Node._Ready" /> will be ignored.</para>
    /// </summary>
    void SetProcessShortcutInput(bool enable);
    /// <summary>
    /// <para>Enables unhandled input processing. This is not required for GUI controls! It enables the node to receive all input that was not previously handled (usually by a <see cref="Control" />). Enabled automatically if <see cref="Node._UnhandledInput(Godot.InputEvent)" /> is overridden. Any calls to this before <see cref="Node._Ready" /> will be ignored.</para>
    /// </summary>
    void SetProcessUnhandledInput(bool enable);
    /// <summary>
    /// <para>Enables unhandled key input processing. Enabled automatically if <see cref="Node._UnhandledKeyInput(Godot.InputEvent)" /> is overridden. Any calls to this before <see cref="Node._Ready" /> will be ignored.</para>
    /// </summary>
    void SetProcessUnhandledKeyInput(bool enable);
    /// <summary>
    /// <para>Sets whether this is an instance load placeholder. See <see cref="InstancePlaceholder" />.</para>
    /// </summary>
    void SetSceneInstanceLoadPlaceholder(bool loadPlaceholder);
    /// <summary>
    /// <para>Similar to <see cref="Node.CallThreadSafe(Godot.StringName,Godot.Variant[])" />, but for setting properties.</para>
    /// </summary>
    void SetThreadSafe(StringName @property, Variant value);
    /// <summary>
    /// <para>Sets this node's name as a unique name in its <see cref="Node.Owner" />. This allows the node to be accessed as <c>%Name</c> instead of the full path, from any node within that scene.</para>
    /// <para>If another node with the same owner already had that name declared as unique, that other node's name will no longer be set as having a unique name.</para>
    /// </summary>
    bool UniqueNameInOwner { get; set; }
    /// <summary>
    /// <para>Updates the warning displayed for this node in the Scene Dock.</para>
    /// <para>Use <see cref="Node._GetConfigurationWarnings" /> to setup the warning message to display.</para>
    /// </summary>
    void UpdateConfigurationWarnings();

}