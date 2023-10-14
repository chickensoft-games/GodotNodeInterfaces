namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class GraphNodeNode : GraphNode, IGraphNode { }

/// <summary>
/// <para><see cref="GraphNode" /> allows to create nodes for a <see cref="GraphEdit" /> graph with customizable content based on its child controls. <see cref="GraphNode" /> is derived from <see cref="Container" /> and it is responsible for placing its children on screen. This works similar to <see cref="VBoxContainer" />. Children, in turn, provide <see cref="GraphNode" /> with so-called slots, each of which can have a connection port on either side.</para>
/// <para>Each <see cref="GraphNode" /> slot is defined by its index and can provide the node with up to two ports: one on the left, and one on the right. By convention the left port is also referred to as the <b>input port</b> and the right port is referred to as the <b>output port</b>. Each port can be enabled and configured individually, using different type and color. The type is an arbitrary value that you can define using your own considerations. The parent <see cref="GraphEdit" /> will receive this information on each connect and disconnect request.</para>
/// <para>Slots can be configured in the Inspector dock once you add at least one child <see cref="Control" />. The properties are grouped by each slot's index in the "Slot" section.</para>
/// <para><b>Note:</b> While GraphNode is set up using slots and slot indices, connections are made between the ports which are enabled. Because of that <see cref="GraphEdit" /> uses the port's index and not the slot's index. You can use <see cref="GraphNode.GetInputPortSlot(System.Int32)" /> and <see cref="GraphNode.GetOutputPortSlot(System.Int32)" /> to get the slot index from the port index.</para>
/// </summary>
public interface IGraphNode : IGraphElement {

    void _DrawPort(int slotIndex, Vector2I position, bool left, Color color);
    /// <summary>
    /// <para>Disables all slots of the GraphNode. This will remove all input/output ports from the GraphNode.</para>
    /// </summary>
    void ClearAllSlots();
    /// <summary>
    /// <para>Disables the slot with the given <paramref name="slotIndex" />. This will remove the corresponding input and output port from the GraphNode.</para>
    /// </summary>
    void ClearSlot(int slotIndex);
    /// <summary>
    /// <para>Returns the <see cref="Color" /> of the input port with the given <paramref name="portIdx" />.</para>
    /// </summary>
    Color GetInputPortColor(int portIdx);
    /// <summary>
    /// <para>Returns the number of slots with an enabled input port.</para>
    /// </summary>
    int GetInputPortCount();
    /// <summary>
    /// <para>Returns the position of the input port with the given <paramref name="portIdx" />.</para>
    /// </summary>
    Vector2 GetInputPortPosition(int portIdx);
    /// <summary>
    /// <para>Returns the corresponding slot index of the input port with the given <paramref name="portIdx" />.</para>
    /// </summary>
    int GetInputPortSlot(int portIdx);
    /// <summary>
    /// <para>Returns the type of the input port with the given <paramref name="portIdx" />.</para>
    /// </summary>
    int GetInputPortType(int portIdx);
    /// <summary>
    /// <para>Returns the <see cref="Color" /> of the output port with the given <paramref name="portIdx" />.</para>
    /// </summary>
    Color GetOutputPortColor(int portIdx);
    /// <summary>
    /// <para>Returns the number of slots with an enabled output port.</para>
    /// </summary>
    int GetOutputPortCount();
    /// <summary>
    /// <para>Returns the position of the output port with the given <paramref name="portIdx" />.</para>
    /// </summary>
    Vector2 GetOutputPortPosition(int portIdx);
    /// <summary>
    /// <para>Returns the corresponding slot index of the output port with the given <paramref name="portIdx" />.</para>
    /// </summary>
    int GetOutputPortSlot(int portIdx);
    /// <summary>
    /// <para>Returns the type of the output port with the given <paramref name="portIdx" />.</para>
    /// </summary>
    int GetOutputPortType(int portIdx);
    /// <summary>
    /// <para>Returns the left (input) <see cref="Color" /> of the slot with the given <paramref name="slotIndex" />.</para>
    /// </summary>
    Color GetSlotColorLeft(int slotIndex);
    /// <summary>
    /// <para>Returns the right (output) <see cref="Color" /> of the slot with the given <paramref name="slotIndex" />.</para>
    /// </summary>
    Color GetSlotColorRight(int slotIndex);
    /// <summary>
    /// <para>Returns the left (input) type of the slot with the given <paramref name="slotIndex" />.</para>
    /// </summary>
    int GetSlotTypeLeft(int slotIndex);
    /// <summary>
    /// <para>Returns the right (output) type of the slot with the given <paramref name="slotIndex" />.</para>
    /// </summary>
    int GetSlotTypeRight(int slotIndex);
    /// <summary>
    /// <para>Returns the <see cref="HBoxContainer" /> used for the title bar, only containing a <see cref="Label" /> for displaying the title by default. This can be used to add custom controls to the title bar such as option or close buttons.</para>
    /// </summary>
    HBoxContainer GetTitlebarHBox();
    /// <summary>
    /// <para>Returns true if the background <see cref="StyleBox" /> of the slot with the given <paramref name="slotIndex" /> is drawn.</para>
    /// </summary>
    bool IsSlotDrawStylebox(int slotIndex);
    /// <summary>
    /// <para>Returns <c>true</c> if left (input) side of the slot with the given <paramref name="slotIndex" /> is enabled.</para>
    /// </summary>
    bool IsSlotEnabledLeft(int slotIndex);
    /// <summary>
    /// <para>Returns <c>true</c> if right (output) side of the slot with the given <paramref name="slotIndex" /> is enabled.</para>
    /// </summary>
    bool IsSlotEnabledRight(int slotIndex);
    /// <summary>
    /// <para>Sets properties of the slot with the given <paramref name="slotIndex" />.</para>
    /// <para>If <paramref name="enableLeftPort" />/<paramref name="enableRightPort" /> is <c>true</c>, a port will appear and the slot will be able to be connected from this side.</para>
    /// <para>With <paramref name="typeLeft" />/<paramref name="typeRight" /> an arbitrary type can be assigned to each port. Two ports can be connected if they share the same type, or if the connection between their types is allowed in the parent <see cref="GraphEdit" /> (see <see cref="GraphEdit.AddValidConnectionType(System.Int32,System.Int32)" />). Keep in mind that the <see cref="GraphEdit" /> has the final say in accepting the connection. Type compatibility simply allows the <see cref="GraphEdit.ConnectionRequest" /> signal to be emitted.</para>
    /// <para>Ports can be further customized using <paramref name="colorLeft" />/<paramref name="colorRight" /> and <paramref name="customIconLeft" />/<paramref name="customIconRight" />. The color parameter adds a tint to the icon. The custom icon can be used to override the default port dot.</para>
    /// <para>Additionally, <paramref name="drawStylebox" /> can be used to enable or disable drawing of the background stylebox for each slot. See <c>slot</c>.</para>
    /// <para>Individual properties can also be set using one of the <c>set_slot_*</c> methods.</para>
    /// <para><b>Note:</b> This method only sets properties of the slot. To create the slot itself, add a <see cref="Control" />-derived child to the GraphNode.</para>
    /// </summary>
    void SetSlot(int slotIndex, bool enableLeftPort, int typeLeft, Color colorLeft, bool enableRightPort, int typeRight, Color colorRight, Texture2D customIconLeft, Texture2D customIconRight, bool drawStylebox);
    /// <summary>
    /// <para>Sets the <see cref="Color" /> of the left (input) side of the slot with the given <paramref name="slotIndex" /> to <paramref name="color" />.</para>
    /// </summary>
    void SetSlotColorLeft(int slotIndex, Color color);
    /// <summary>
    /// <para>Sets the <see cref="Color" /> of the right (output) side of the slot with the given <paramref name="slotIndex" /> to <paramref name="color" />.</para>
    /// </summary>
    void SetSlotColorRight(int slotIndex, Color color);
    /// <summary>
    /// <para>Toggles the background <see cref="StyleBox" /> of the slot with the given <paramref name="slotIndex" />.</para>
    /// </summary>
    void SetSlotDrawStylebox(int slotIndex, bool enable);
    /// <summary>
    /// <para>Toggles the left (input) side of the slot with the given <paramref name="slotIndex" />. If <paramref name="enable" /> is <c>true</c>, a port will appear on the left side and the slot will be able to be connected from this side.</para>
    /// </summary>
    void SetSlotEnabledLeft(int slotIndex, bool enable);
    /// <summary>
    /// <para>Toggles the right (output) side of the slot with the given <paramref name="slotIndex" />. If <paramref name="enable" /> is <c>true</c>, a port will appear on the right side and the slot will be able to be connected from this side.</para>
    /// </summary>
    void SetSlotEnabledRight(int slotIndex, bool enable);
    /// <summary>
    /// <para>Sets the left (input) type of the slot with the given <paramref name="slotIndex" /> to <paramref name="type" />. If the value is negative, all connections will be disallowed to be created via user inputs.</para>
    /// </summary>
    void SetSlotTypeLeft(int slotIndex, int @type);
    /// <summary>
    /// <para>Sets the right (output) type of the slot with the given <paramref name="slotIndex" /> to <paramref name="type" />. If the value is negative, all connections will be disallowed to be created via user inputs.</para>
    /// </summary>
    void SetSlotTypeRight(int slotIndex, int @type);
    /// <summary>
    /// <para>The text displayed in the GraphNode's title bar.</para>
    /// </summary>
    string Title { get; set; }

}