namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
using Godot.Collections;
/// <summary>
/// <para><see cref="GraphEdit" /> provides tools for creation, manipulation, and display of various graphs. Its main purpose in the engine is to power the visual programming systems, such as visual shaders, but it is also available for use in user projects.</para>
/// <para><see cref="GraphEdit" /> by itself is only an empty container, representing an infinite grid where <see cref="GraphNode" />s can be placed. Each <see cref="GraphNode" /> represents a node in the graph, a single unit of data in the connected scheme. <see cref="GraphEdit" />, in turn, helps to control various interactions with nodes and between nodes. When the user attempts to connect, disconnect, or delete a <see cref="GraphNode" />, a signal is emitted in the <see cref="GraphEdit" />, but no action is taken by default. It is the responsibility of the programmer utilizing this control to implement the necessary logic to determine how each request should be handled.</para>
/// <para><b>Performance:</b> It is greatly advised to enable low-processor usage mode (see <see cref="OS.LowProcessorUsageMode" />) when using GraphEdits.</para>
/// </summary>
public class GraphEditAdapter : ControlAdapter, IGraphEdit {
  private readonly GraphEdit _node;

  public GraphEditAdapter(GraphEdit node) : base(node) { _node = node; }

    /// <summary>
    /// <para>Virtual method which can be overridden to customize how connections are drawn.</para>
    /// </summary>
    public Vector2[] _GetConnectionLine(Vector2 fromPosition, Vector2 toPosition) => _node._GetConnectionLine(fromPosition, toPosition);
    /// <summary>
    /// <para>Returns whether the <paramref name="mousePosition" /> is in the input hot zone.</para>
    /// <para>By default, a hot zone is a <see cref="Rect2" /> positioned such that its center is at <paramref name="inNode" />.<see cref="GraphNode.GetInputPortPosition(System.Int32)" />(<paramref name="inPort" />) (For output's case, call <see cref="GraphNode.GetOutputPortPosition(System.Int32)" /> instead). The hot zone's width is twice the Theme Property <c>port_grab_distance_horizontal</c>, and its height is twice the <c>port_grab_distance_vertical</c>.</para>
    /// <para>Below is a sample code to help get started:</para>
    /// <para><code>
    /// func _is_in_input_hotzone(in_node, in_port, mouse_position):
    /// var port_size: Vector2 = Vector2(get_theme_constant("port_grab_distance_horizontal"), get_theme_constant("port_grab_distance_vertical"))
    /// var port_pos: Vector2 = in_node.get_position() + in_node.get_input_port_position(in_port) - port_size / 2
    /// var rect = Rect2(port_pos, port_size)
    /// return rect.has_point(mouse_position)
    /// </code></para>
    /// </summary>
    public bool _IsInInputHotzone(GodotObject inNode, int inPort, Vector2 mousePosition) => _node._IsInInputHotzone(inNode, inPort, mousePosition);
    /// <summary>
    /// <para>Returns whether the <paramref name="mousePosition" /> is in the output hot zone. For more information on hot zones, see <see cref="GraphEdit._IsInInputHotzone(Godot.GodotObject,System.Int32,Godot.Vector2)" />.</para>
    /// <para>Below is a sample code to help get started:</para>
    /// <para><code>
    /// func _is_in_output_hotzone(in_node, in_port, mouse_position):
    /// var port_size: Vector2 = Vector2(get_theme_constant("port_grab_distance_horizontal"), get_theme_constant("port_grab_distance_vertical"))
    /// var port_pos: Vector2 = in_node.get_position() + in_node.get_output_port_position(in_port) - port_size / 2
    /// var rect = Rect2(port_pos, port_size)
    /// return rect.has_point(mouse_position)
    /// </code></para>
    /// </summary>
    public bool _IsInOutputHotzone(GodotObject inNode, int inPort, Vector2 mousePosition) => _node._IsInOutputHotzone(inNode, inPort, mousePosition);
    /// <summary>
    /// <para>This virtual method can be used to insert additional error detection while the user is dragging a connection over a valid port.</para>
    /// <para>Return <c>true</c> if the connection is indeed valid or return <c>false</c> if the connection is impossible. If the connection is impossible, no snapping to the port and thus no connection request to that port will happen.</para>
    /// <para>In this example a connection to same node is suppressed:</para>
    /// <para><code>
    /// public override bool _IsNodeHoverValid(StringName fromNode, int fromPort, StringName toNode, int toPort)
    /// {
    /// return fromNode != toNode;
    /// }
    /// </code></para>
    /// </summary>
    public bool _IsNodeHoverValid(StringName fromNode, int fromPort, StringName toNode, int toPort) => _node._IsNodeHoverValid(fromNode, fromPort, toNode, toPort);
    /// <summary>
    /// <para>Allows the connection between two different port types. The port type is defined individually for the left and the right port of each slot with the <see cref="GraphNode.SetSlot(System.Int32,System.Boolean,System.Int32,Godot.Color,System.Boolean,System.Int32,Godot.Color,Godot.Texture2D,Godot.Texture2D,System.Boolean)" /> method.</para>
    /// <para>See also <see cref="GraphEdit.IsValidConnectionType(System.Int32,System.Int32)" /> and <see cref="GraphEdit.RemoveValidConnectionType(System.Int32,System.Int32)" />.</para>
    /// </summary>
    public void AddValidConnectionType(int fromType, int toType) => _node.AddValidConnectionType(fromType, toType);
    /// <summary>
    /// <para>Allows to disconnect nodes when dragging from the left port of the <see cref="GraphNode" />'s slot if it has the specified type. See also <see cref="GraphEdit.RemoveValidLeftDisconnectType(System.Int32)" />.</para>
    /// </summary>
    public void AddValidLeftDisconnectType(int @type) => _node.AddValidLeftDisconnectType(@type);
    /// <summary>
    /// <para>Allows to disconnect nodes when dragging from the right port of the <see cref="GraphNode" />'s slot if it has the specified type. See also <see cref="GraphEdit.RemoveValidRightDisconnectType(System.Int32)" />.</para>
    /// </summary>
    public void AddValidRightDisconnectType(int @type) => _node.AddValidRightDisconnectType(@type);
    /// <summary>
    /// <para>Rearranges selected nodes in a layout with minimum crossings between connections and uniform horizontal and vertical gap between nodes.</para>
    /// </summary>
    public void ArrangeNodes() => _node.ArrangeNodes();
    /// <inheritdoc cref="P:Godot.GraphEdit.ShowArrangeButton" />
    public bool ArrangeNodesButtonHidden { get => _node.ArrangeNodesButtonHidden; set => _node.ArrangeNodesButtonHidden = value; }
    /// <summary>
    /// <para>Removes all connections between nodes.</para>
    /// </summary>
    public void ClearConnections() => _node.ClearConnections();
    /// <summary>
    /// <para>If <c>true</c>, the lines between nodes will use antialiasing.</para>
    /// </summary>
    public bool ConnectionLinesAntialiased { get => _node.ConnectionLinesAntialiased; set => _node.ConnectionLinesAntialiased = value; }
    /// <summary>
    /// <para>The curvature of the lines between the nodes. 0 results in straight lines.</para>
    /// </summary>
    public float ConnectionLinesCurvature { get => _node.ConnectionLinesCurvature; set => _node.ConnectionLinesCurvature = value; }
    /// <summary>
    /// <para>The thickness of the lines between the nodes.</para>
    /// </summary>
    public float ConnectionLinesThickness { get => _node.ConnectionLinesThickness; set => _node.ConnectionLinesThickness = value; }
    /// <summary>
    /// <para>Create a connection between the <paramref name="fromPort" /> of the <paramref name="fromNode" /> <see cref="GraphNode" /> and the <paramref name="toPort" /> of the <paramref name="toNode" /> <see cref="GraphNode" />. If the connection already exists, no connection is created.</para>
    /// </summary>
    public Error ConnectNode(StringName fromNode, int fromPort, StringName toNode, int toPort) => _node.ConnectNode(fromNode, fromPort, toNode, toPort);
    /// <summary>
    /// <para>Removes the connection between the <paramref name="fromPort" /> of the <paramref name="fromNode" /> <see cref="GraphNode" /> and the <paramref name="toPort" /> of the <paramref name="toNode" /> <see cref="GraphNode" />. If the connection does not exist, no connection is removed.</para>
    /// </summary>
    public void DisconnectNode(StringName fromNode, int fromPort, StringName toNode, int toPort) => _node.DisconnectNode(fromNode, fromPort, toNode, toPort);
    /// <summary>
    /// <para>Ends the creation of the current connection. In other words, if you are dragging a connection you can use this method to abort the process and remove the line that followed your cursor.</para>
    /// <para>This is best used together with <see cref="GraphEdit.ConnectionDragStarted" /> and <see cref="GraphEdit.ConnectionDragEnded" /> to add custom behavior like node addition through shortcuts.</para>
    /// <para><b>Note:</b> This method suppresses any other connection request signals apart from <see cref="GraphEdit.ConnectionDragEnded" />.</para>
    /// </summary>
    public void ForceConnectionDragEnd() => _node.ForceConnectionDragEnd();
    /// <summary>
    /// <para>Returns the points which would make up a connection between <paramref name="fromNode" /> and <paramref name="toNode" />.</para>
    /// </summary>
    public Vector2[] GetConnectionLine(Vector2 fromNode, Vector2 toNode) => _node.GetConnectionLine(fromNode, toNode);
    /// <summary>
    /// <para>Returns an Array containing the list of connections. A connection consists in a structure of the form <c>{ from_port: 0, from: "GraphNode name 0", to_port: 1, to: "GraphNode name 1" }</c>.</para>
    /// </summary>
    public Godot.Collections.Array<Dictionary> GetConnectionList() => _node.GetConnectionList();
    /// <summary>
    /// <para>Gets the <see cref="HBoxContainer" /> that contains the zooming and grid snap controls in the top left of the graph. You can use this method to reposition the toolbar or to add your own custom controls to it.</para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash. If you wish to hide it or any of its children, use their <see cref="CanvasItem.Visible" /> property.</para>
    /// </summary>
    public HBoxContainer GetMenuHBox() => _node.GetMenuHBox();
    /// <inheritdoc cref="M:Godot.GraphEdit.GetMenuHBox" />
    public HBoxContainer GetZoomHBox() => _node.GetZoomHBox();

    public bool IsArrangeNodesButtonHidden() => _node.IsArrangeNodesButtonHidden();
    /// <summary>
    /// <para>Returns <c>true</c> if the <paramref name="fromPort" /> of the <paramref name="fromNode" /> <see cref="GraphNode" /> is connected to the <paramref name="toPort" /> of the <paramref name="toNode" /> <see cref="GraphNode" />.</para>
    /// </summary>
    public bool IsNodeConnected(StringName fromNode, int fromPort, StringName toNode, int toPort) => _node.IsNodeConnected(fromNode, fromPort, toNode, toPort);
    /// <summary>
    /// <para>Returns whether it's possible to make a connection between two different port types. The port type is defined individually for the left and the right port of each slot with the <see cref="GraphNode.SetSlot(System.Int32,System.Boolean,System.Int32,Godot.Color,System.Boolean,System.Int32,Godot.Color,Godot.Texture2D,Godot.Texture2D,System.Boolean)" /> method.</para>
    /// <para>See also <see cref="GraphEdit.AddValidConnectionType(System.Int32,System.Int32)" /> and <see cref="GraphEdit.RemoveValidConnectionType(System.Int32,System.Int32)" />.</para>
    /// </summary>
    public bool IsValidConnectionType(int fromType, int toType) => _node.IsValidConnectionType(fromType, toType);
    /// <summary>
    /// <para>If <c>true</c>, the minimap is visible.</para>
    /// </summary>
    public bool MinimapEnabled { get => _node.MinimapEnabled; set => _node.MinimapEnabled = value; }
    /// <summary>
    /// <para>The opacity of the minimap rectangle.</para>
    /// </summary>
    public float MinimapOpacity { get => _node.MinimapOpacity; set => _node.MinimapOpacity = value; }
    /// <summary>
    /// <para>The size of the minimap rectangle. The map itself is based on the size of the grid area and is scaled to fit this rectangle.</para>
    /// </summary>
    public Vector2 MinimapSize { get => _node.MinimapSize; set => _node.MinimapSize = value; }
    /// <summary>
    /// <para>Defines the control scheme for panning with mouse wheel.</para>
    /// </summary>
    public GraphEdit.PanningSchemeEnum PanningScheme { get => _node.PanningScheme; set => _node.PanningScheme = value; }
    /// <summary>
    /// <para>Disallows the connection between two different port types previously allowed by <see cref="GraphEdit.AddValidConnectionType(System.Int32,System.Int32)" />. The port type is defined individually for the left and the right port of each slot with the <see cref="GraphNode.SetSlot(System.Int32,System.Boolean,System.Int32,Godot.Color,System.Boolean,System.Int32,Godot.Color,Godot.Texture2D,Godot.Texture2D,System.Boolean)" /> method.</para>
    /// <para>See also <see cref="GraphEdit.IsValidConnectionType(System.Int32,System.Int32)" />.</para>
    /// </summary>
    public void RemoveValidConnectionType(int fromType, int toType) => _node.RemoveValidConnectionType(fromType, toType);
    /// <summary>
    /// <para>Disallows to disconnect nodes when dragging from the left port of the <see cref="GraphNode" />'s slot if it has the specified type. Use this to disable disconnection previously allowed with <see cref="GraphEdit.AddValidLeftDisconnectType(System.Int32)" />.</para>
    /// </summary>
    public void RemoveValidLeftDisconnectType(int @type) => _node.RemoveValidLeftDisconnectType(@type);
    /// <summary>
    /// <para>Disallows to disconnect nodes when dragging from the right port of the <see cref="GraphNode" />'s slot if it has the specified type. Use this to disable disconnection previously allowed with <see cref="GraphEdit.AddValidRightDisconnectType(System.Int32)" />.</para>
    /// </summary>
    public void RemoveValidRightDisconnectType(int @type) => _node.RemoveValidRightDisconnectType(@type);
    /// <summary>
    /// <para>If <c>true</c>, enables disconnection of existing connections in the GraphEdit by dragging the right end.</para>
    /// </summary>
    public bool RightDisconnects { get => _node.RightDisconnects; set => _node.RightDisconnects = value; }
    /// <summary>
    /// <para>The scroll offset.</para>
    /// </summary>
    public Vector2 ScrollOffset { get => _node.ScrollOffset; set => _node.ScrollOffset = value; }

    public void SetArrangeNodesButtonHidden(bool enable) => _node.SetArrangeNodesButtonHidden(enable);
    /// <summary>
    /// <para>Sets the coloration of the connection between <paramref name="fromNode" />'s <paramref name="fromPort" /> and <paramref name="toNode" />'s <paramref name="toPort" /> with the color provided in the <c>activity</c> theme property.</para>
    /// </summary>
    public void SetConnectionActivity(StringName fromNode, int fromPort, StringName toNode, int toPort, float amount) => _node.SetConnectionActivity(fromNode, fromPort, toNode, toPort, amount);
    /// <summary>
    /// <para>Sets the specified <paramref name="node" /> as the one selected.</para>
    /// </summary>
    public void SetSelected(Node node) => _node.SetSelected(node);
    /// <summary>
    /// <para>If <c>true</c>, the button to automatically arrange graph nodes is visible.</para>
    /// </summary>
    public bool ShowArrangeButton { get => _node.ShowArrangeButton; set => _node.ShowArrangeButton = value; }
    /// <summary>
    /// <para>If <c>true</c>, the grid is visible.</para>
    /// </summary>
    public bool ShowGrid { get => _node.ShowGrid; set => _node.ShowGrid = value; }
    /// <summary>
    /// <para>If <c>true</c>, buttons that allow to configure grid and snapping options are visible.</para>
    /// </summary>
    public bool ShowGridButtons { get => _node.ShowGridButtons; set => _node.ShowGridButtons = value; }
    /// <summary>
    /// <para>If <c>true</c>, the menu toolbar is visible.</para>
    /// </summary>
    public bool ShowMenu { get => _node.ShowMenu; set => _node.ShowMenu = value; }
    /// <summary>
    /// <para>If <c>true</c>, the button to toggle the minimap is visible.</para>
    /// </summary>
    public bool ShowMinimapButton { get => _node.ShowMinimapButton; set => _node.ShowMinimapButton = value; }
    /// <summary>
    /// <para>If <c>true</c>, buttons that allow to change and reset the zoom level are visible.</para>
    /// </summary>
    public bool ShowZoomButtons { get => _node.ShowZoomButtons; set => _node.ShowZoomButtons = value; }
    /// <summary>
    /// <para>If <c>true</c>, the label with the current zoom level is visible. The zoom level is displayed in percents.</para>
    /// </summary>
    public bool ShowZoomLabel { get => _node.ShowZoomLabel; set => _node.ShowZoomLabel = value; }
    /// <inheritdoc cref="P:Godot.GraphEdit.SnappingDistance" />
    public int SnapDistance { get => _node.SnapDistance; set => _node.SnapDistance = value; }
    /// <summary>
    /// <para>The snapping distance in pixels, also determines the grid line distance.</para>
    /// </summary>
    public int SnappingDistance { get => _node.SnappingDistance; set => _node.SnappingDistance = value; }
    /// <summary>
    /// <para>If <c>true</c>, enables snapping.</para>
    /// </summary>
    public bool SnappingEnabled { get => _node.SnappingEnabled; set => _node.SnappingEnabled = value; }
    /// <inheritdoc cref="P:Godot.GraphEdit.SnappingEnabled" />
    public bool UseSnap { get => _node.UseSnap; set => _node.UseSnap = value; }
    /// <summary>
    /// <para>The current zoom value.</para>
    /// </summary>
    public float Zoom { get => _node.Zoom; set => _node.Zoom = value; }
    /// <summary>
    /// <para>The upper zoom limit.</para>
    /// </summary>
    public float ZoomMax { get => _node.ZoomMax; set => _node.ZoomMax = value; }
    /// <summary>
    /// <para>The lower zoom limit.</para>
    /// </summary>
    public float ZoomMin { get => _node.ZoomMin; set => _node.ZoomMin = value; }
    /// <summary>
    /// <para>The step of each zoom level.</para>
    /// </summary>
    public float ZoomStep { get => _node.ZoomStep; set => _node.ZoomStep = value; }

}