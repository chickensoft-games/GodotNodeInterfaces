namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
using Godot.Collections;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class ControlNode : Control, IControl { }

/// <summary>
/// <para>Base class for all UI-related nodes. <see cref="Control" /> features a bounding rectangle that defines its extents, an anchor position relative to its parent control or the current viewport, and offsets relative to the anchor. The offsets update automatically when the node, any of its parents, or the screen size change.</para>
/// <para>For more information on Godot's UI system, anchors, offsets, and containers, see the related tutorials in the manual. To build flexible UIs, you'll need a mix of UI elements that inherit from <see cref="Control" /> and <see cref="Container" /> nodes.</para>
/// <para><b>User Interface nodes and input</b></para>
/// <para>Godot propagates input events via viewports. Each <see cref="Viewport" /> is responsible for propagating <see cref="InputEvent" />s to their child nodes. As the <see cref="SceneTree.Root" /> is a <see cref="Window" />, this already happens automatically for all UI elements in your game.</para>
/// <para>Input events are propagated through the <see cref="SceneTree" /> from the root node to all child nodes by calling <see cref="Node._Input(Godot.InputEvent)" />. For UI elements specifically, it makes more sense to override the virtual method <see cref="Control._GuiInput(Godot.InputEvent)" />, which filters out unrelated input events, such as by checking z-order, <see cref="Control.MouseFilter" />, focus, or if the event was inside of the control's bounding box.</para>
/// <para>Call <see cref="Control.AcceptEvent" /> so no other node receives the event. Once you accept an input, it becomes handled so <see cref="Node._UnhandledInput(Godot.InputEvent)" /> will not process it.</para>
/// <para>Only one <see cref="Control" /> node can be in focus. Only the node in focus will receive events. To get the focus, call <see cref="Control.GrabFocus" />. <see cref="Control" /> nodes lose focus when another node grabs it, or if you hide the node in focus.</para>
/// <para>Sets <see cref="Control.MouseFilter" /> to <see cref="Control.MouseFilterEnum.Ignore" /> to tell a <see cref="Control" /> node to ignore mouse or touch events. You'll need it if you place an icon on top of a button.</para>
/// <para><see cref="Theme" /> resources change the Control's appearance. If you change the <see cref="Theme" /> on a <see cref="Control" /> node, it affects all of its children. To override some of the theme's parameters, call one of the <c>add_theme_*_override</c> methods, like <see cref="Control.AddThemeFontOverride(Godot.StringName,Godot.Font)" />. You can override the theme with the Inspector.</para>
/// <para><b>Note:</b> Theme items are <i>not</i> <see cref="GodotObject" /> properties. This means you can't access their values using <see cref="GodotObject.Get(Godot.StringName)" /> and <see cref="GodotObject.Set(Godot.StringName,Godot.Variant)" />. Instead, use the <c>get_theme_*</c> and <c>add_theme_*_override</c> methods provided by this class.</para>
/// </summary>
public interface IControl : ICanvasItem {
    /// <summary>
    /// <para>Godot calls this method to test if <paramref name="data" /> from a control's <see cref="Control._GetDragData(Godot.Vector2)" /> can be dropped at <paramref name="atPosition" />. <paramref name="atPosition" /> is local to this control.</para>
    /// <para>This method should only be used to test the data. Process the data in <see cref="Control._DropData(Godot.Vector2,Godot.Variant)" />.</para>
    /// <para><code>
    /// public override bool _CanDropData(Vector2 atPosition, Variant data)
    /// {
    /// // Check position if it is relevant to you
    /// // Otherwise, just check data
    /// return data.VariantType == Variant.Type.Dictionary &amp;&amp; data.AsGodotDictionary().ContainsKey("expected");
    /// }
    /// </code></para>
    /// </summary>
    bool _CanDropData(Vector2 atPosition, Variant data);
    /// <summary>
    /// <para>Godot calls this method to pass you the <paramref name="data" /> from a control's <see cref="Control._GetDragData(Godot.Vector2)" /> result. Godot first calls <see cref="Control._CanDropData(Godot.Vector2,Godot.Variant)" /> to test if <paramref name="data" /> is allowed to drop at <paramref name="atPosition" /> where <paramref name="atPosition" /> is local to this control.</para>
    /// <para><code>
    /// public override bool _CanDropData(Vector2 atPosition, Variant data)
    /// {
    /// return data.VariantType == Variant.Type.Dictionary &amp;&amp; dict.AsGodotDictionary().ContainsKey("color");
    /// }
    /// public override void _DropData(Vector2 atPosition, Variant data)
    /// {
    /// Color color = data.AsGodotDictionary()["color"].AsColor();
    /// }
    /// </code></para>
    /// </summary>
    void _DropData(Vector2 atPosition, Variant data);
    /// <summary>
    /// <para>Godot calls this method to get data that can be dragged and dropped onto controls that expect drop data. Returns <c>null</c> if there is no data to drag. Controls that want to receive drop data should implement <see cref="Control._CanDropData(Godot.Vector2,Godot.Variant)" /> and <see cref="Control._DropData(Godot.Vector2,Godot.Variant)" />. <paramref name="atPosition" /> is local to this control. Drag may be forced with <see cref="Control.ForceDrag(Godot.Variant,Godot.Control)" />.</para>
    /// <para>A preview that will follow the mouse that should represent the data can be set with <see cref="Control.SetDragPreview(Godot.Control)" />. A good time to set the preview is in this method.</para>
    /// <para><code>
    /// public override Variant _GetDragData(Vector2 atPosition)
    /// {
    /// var myData = MakeData(); // This is your custom method generating the drag data.
    /// SetDragPreview(MakePreview(myData)); // This is your custom method generating the preview of the drag data.
    /// return myData;
    /// }
    /// </code></para>
    /// </summary>
    Variant _GetDragData(Vector2 atPosition);
    /// <summary>
    /// <para>Virtual method to be implemented by the user. Returns the minimum size for this control. Alternative to <see cref="Control.CustomMinimumSize" /> for controlling minimum size via code. The actual minimum size will be the max value of these two (in each axis separately).</para>
    /// <para>If not overridden, defaults to <c>Vector2.ZERO</c>.</para>
    /// <para><b>Note:</b> This method will not be called when the script is attached to a <see cref="Control" /> node that already overrides its minimum size (e.g. <see cref="Label" />, <see cref="Button" />, <see cref="PanelContainer" /> etc.). It can only be used with most basic GUI nodes, like <see cref="Control" />, <see cref="Container" />, <see cref="Panel" /> etc.</para>
    /// </summary>
    Vector2 _GetMinimumSize();
    /// <summary>
    /// <para>Virtual method to be implemented by the user. Returns the tooltip text for the position <paramref name="atPosition" /> in control's local coordinates, which will typically appear when the cursor is resting over this control. See <see cref="Control.GetTooltip(System.Nullable{Godot.Vector2})" />.</para>
    /// <para><b>Note:</b> If this method returns an empty <see cref="T:System.String" />, no tooltip is displayed.</para>
    /// </summary>
    string _GetTooltip(Vector2 atPosition);
    /// <summary>
    /// <para>Virtual method to be implemented by the user. Use this method to process and accept inputs on UI elements. See <see cref="Control.AcceptEvent" />.</para>
    /// <para><b>Example usage for clicking a control:</b></para>
    /// <para><code>
    /// public override void _GuiInput(InputEvent @event)
    /// {
    /// if (@event is InputEventMouseButton mb)
    /// {
    /// if (mb.ButtonIndex == MouseButton.Left &amp;&amp; mb.Pressed)
    /// {
    /// GD.Print("I've been clicked D:");
    /// }
    /// }
    /// }
    /// </code></para>
    /// <para>The event won't trigger if:</para>
    /// <para>* clicking outside the control (see <see cref="Control._HasPoint(Godot.Vector2)" />);</para>
    /// <para>* control has <see cref="Control.MouseFilter" /> set to <see cref="Control.MouseFilterEnum.Ignore" />;</para>
    /// <para>* control is obstructed by another <see cref="Control" /> on top of it, which doesn't have <see cref="Control.MouseFilter" /> set to <see cref="Control.MouseFilterEnum.Ignore" />;</para>
    /// <para>* control's parent has <see cref="Control.MouseFilter" /> set to <see cref="Control.MouseFilterEnum.Stop" /> or has accepted the event;</para>
    /// <para>* it happens outside the parent's rectangle and the parent has either <see cref="Control.ClipContents" /> enabled.</para>
    /// <para><b>Note:</b> Event position is relative to the control origin.</para>
    /// </summary>
    void _GuiInput(InputEvent @event);
    /// <summary>
    /// <para>Virtual method to be implemented by the user. Returns whether the given <paramref name="point" /> is inside this control.</para>
    /// <para>If not overridden, default behavior is checking if the point is within control's Rect.</para>
    /// <para><b>Note:</b> If you want to check if a point is inside the control, you can use <c>Rect2(Vector2.ZERO, size).has_point(point)</c>.</para>
    /// </summary>
    bool _HasPoint(Vector2 point);
    /// <summary>
    /// <para>Virtual method to be implemented by the user. Returns a <see cref="Control" /> node that should be used as a tooltip instead of the default one. The <paramref name="forText" /> includes the contents of the <see cref="Control.TooltipText" /> property.</para>
    /// <para>The returned node must be of type <see cref="Control" /> or Control-derived. It can have child nodes of any type. It is freed when the tooltip disappears, so make sure you always provide a new instance (if you want to use a pre-existing node from your scene tree, you can duplicate it and pass the duplicated instance). When <c>null</c> or a non-Control node is returned, the default tooltip will be used instead.</para>
    /// <para>The returned node will be added as child to a <see cref="PopupPanel" />, so you should only provide the contents of that panel. That <see cref="PopupPanel" /> can be themed using <see cref="Theme.SetStylebox(Godot.StringName,Godot.StringName,Godot.StyleBox)" /> for the type <c>"TooltipPanel"</c> (see <see cref="Control.TooltipText" /> for an example).</para>
    /// <para><b>Note:</b> The tooltip is shrunk to minimal size. If you want to ensure it's fully visible, you might want to set its <see cref="Control.CustomMinimumSize" /> to some non-zero value.</para>
    /// <para><b>Note:</b> The node (and any relevant children) should be <see cref="CanvasItem.Visible" /> when returned, otherwise, the viewport that instantiates it will not be able to calculate its minimum size reliably.</para>
    /// <para><b>Example of usage with a custom-constructed node:</b></para>
    /// <para><code>
    /// public override Control _MakeCustomTooltip(string forText)
    /// {
    /// var label = new Label();
    /// label.Text = forText;
    /// return label;
    /// }
    /// </code></para>
    /// <para><b>Example of usage with a custom scene instance:</b></para>
    /// <para><code>
    /// public override Control _MakeCustomTooltip(string forText)
    /// {
    /// Node tooltip = ResourceLoader.Load&lt;PackedScene&gt;("res://some_tooltip_scene.tscn").Instantiate();
    /// tooltip.GetNode&lt;Label&gt;("Label").Text = forText;
    /// return tooltip;
    /// }
    /// </code></para>
    /// </summary>
    GodotObject _MakeCustomTooltip(string forText);
    /// <summary>
    /// <para>User defined BiDi algorithm override function.</para>
    /// <para>Returns an <see cref="Collections.Array" /> of <see cref="Vector3I" /> text ranges and text base directions, in the left-to-right order. Ranges should cover full source <paramref name="text" /> without overlaps. BiDi algorithm will be used on each range separately.</para>
    /// </summary>
    Godot.Collections.Array<Vector3I> _StructuredTextParser(Godot.Collections.Array args, string text);
    /// <summary>
    /// <para>Marks an input event as handled. Once you accept an input event, it stops propagating, even to nodes listening to <see cref="Node._UnhandledInput(Godot.InputEvent)" /> or <see cref="Node._UnhandledKeyInput(Godot.InputEvent)" />.</para>
    /// <para><b>Note:</b> This does not affect the methods in <see cref="Input" />, only the way events are propagated.</para>
    /// </summary>
    void AcceptEvent();
    /// <summary>
    /// <para>Creates a local override for a theme <see cref="Color" /> with the specified <paramref name="name" />. Local overrides always take precedence when fetching theme items for the control. An override can be removed with <see cref="Control.RemoveThemeColorOverride(Godot.StringName)" />.</para>
    /// <para>See also <see cref="Control.GetThemeColor(Godot.StringName,Godot.StringName)" />.</para>
    /// <para><b>Example of overriding a label's color and resetting it later:</b></para>
    /// <para><code>
    /// // Given the child Label node "MyLabel", override its font color with a custom value.
    /// GetNode&lt;Label&gt;("MyLabel").AddThemeColorOverride("font_color", new Color(1, 0.5f, 0));
    /// // Reset the font color of the child label.
    /// GetNode&lt;Label&gt;("MyLabel").RemoveThemeColorOverride("font_color");
    /// // Alternatively it can be overridden with the default value from the Label type.
    /// GetNode&lt;Label&gt;("MyLabel").AddThemeColorOverride("font_color", GetThemeColor("font_color", "Label"));
    /// </code></para>
    /// </summary>
    void AddThemeColorOverride(StringName name, Color color);
    /// <summary>
    /// <para>Creates a local override for a theme constant with the specified <paramref name="name" />. Local overrides always take precedence when fetching theme items for the control. An override can be removed with <see cref="Control.RemoveThemeConstantOverride(Godot.StringName)" />.</para>
    /// <para>See also <see cref="Control.GetThemeConstant(Godot.StringName,Godot.StringName)" />.</para>
    /// </summary>
    void AddThemeConstantOverride(StringName name, int constant);
    /// <summary>
    /// <para>Creates a local override for a theme <see cref="Font" /> with the specified <paramref name="name" />. Local overrides always take precedence when fetching theme items for the control. An override can be removed with <see cref="Control.RemoveThemeFontOverride(Godot.StringName)" />.</para>
    /// <para>See also <see cref="Control.GetThemeFont(Godot.StringName,Godot.StringName)" />.</para>
    /// </summary>
    void AddThemeFontOverride(StringName name, Font font);
    /// <summary>
    /// <para>Creates a local override for a theme font size with the specified <paramref name="name" />. Local overrides always take precedence when fetching theme items for the control. An override can be removed with <see cref="Control.RemoveThemeFontSizeOverride(Godot.StringName)" />.</para>
    /// <para>See also <see cref="Control.GetThemeFontSize(Godot.StringName,Godot.StringName)" />.</para>
    /// </summary>
    void AddThemeFontSizeOverride(StringName name, int fontSize);
    /// <summary>
    /// <para>Creates a local override for a theme icon with the specified <paramref name="name" />. Local overrides always take precedence when fetching theme items for the control. An override can be removed with <see cref="Control.RemoveThemeIconOverride(Godot.StringName)" />.</para>
    /// <para>See also <see cref="Control.GetThemeIcon(Godot.StringName,Godot.StringName)" />.</para>
    /// </summary>
    void AddThemeIconOverride(StringName name, Texture2D texture);
    /// <summary>
    /// <para>Creates a local override for a theme <see cref="StyleBox" /> with the specified <paramref name="name" />. Local overrides always take precedence when fetching theme items for the control. An override can be removed with <see cref="Control.RemoveThemeStyleboxOverride(Godot.StringName)" />.</para>
    /// <para>See also <see cref="Control.GetThemeStylebox(Godot.StringName,Godot.StringName)" />.</para>
    /// <para><b>Example of modifying a property in a StyleBox by duplicating it:</b></para>
    /// <para><code>
    /// // The snippet below assumes the child node MyButton has a StyleBoxFlat assigned.
    /// // Resources are shared across instances, so we need to duplicate it
    /// // to avoid modifying the appearance of all other buttons.
    /// StyleBoxFlat newStyleboxNormal = GetNode&lt;Button&gt;("MyButton").GetThemeStylebox("normal").Duplicate() as StyleBoxFlat;
    /// newStyleboxNormal.BorderWidthTop = 3;
    /// newStyleboxNormal.BorderColor = new Color(0, 1, 0.5f);
    /// GetNode&lt;Button&gt;("MyButton").AddThemeStyleboxOverride("normal", newStyleboxNormal);
    /// // Remove the stylebox override.
    /// GetNode&lt;Button&gt;("MyButton").RemoveThemeStyleboxOverride("normal");
    /// </code></para>
    /// </summary>
    void AddThemeStyleboxOverride(StringName name, StyleBox stylebox);
    /// <summary>
    /// <para>Anchors the bottom edge of the node to the origin, the center, or the end of its parent control. It changes how the bottom offset updates when the node moves or changes size. You can use one of the <see cref="Control.Anchor" /> constants for convenience.</para>
    /// </summary>
    float AnchorBottom { get; set; }
    /// <summary>
    /// <para>Anchors the left edge of the node to the origin, the center or the end of its parent control. It changes how the left offset updates when the node moves or changes size. You can use one of the <see cref="Control.Anchor" /> constants for convenience.</para>
    /// </summary>
    float AnchorLeft { get; set; }
    /// <summary>
    /// <para>Anchors the right edge of the node to the origin, the center or the end of its parent control. It changes how the right offset updates when the node moves or changes size. You can use one of the <see cref="Control.Anchor" /> constants for convenience.</para>
    /// </summary>
    float AnchorRight { get; set; }

    int AnchorsPreset { get; set; }
    /// <summary>
    /// <para>Anchors the top edge of the node to the origin, the center or the end of its parent control. It changes how the top offset updates when the node moves or changes size. You can use one of the <see cref="Control.Anchor" /> constants for convenience.</para>
    /// </summary>
    float AnchorTop { get; set; }
    /// <summary>
    /// <para>Toggles if any text should automatically change to its translated version depending on the current locale.</para>
    /// <para>Also decides if the node's strings should be parsed for POT generation.</para>
    /// </summary>
    bool AutoTranslate { get; set; }
    /// <summary>
    /// <para>Prevents <c>*_theme_*_override</c> methods from emitting <see cref="Control.NotificationThemeChanged" /> until <see cref="Control.EndBulkThemeOverride" /> is called.</para>
    /// </summary>
    void BeginBulkThemeOverride();
    /// <summary>
    /// <para>Enables whether rendering of <see cref="CanvasItem" /> based children should be clipped to this control's rectangle. If <c>true</c>, parts of a child which would be visibly outside of this control's rectangle will not be rendered and won't receive input.</para>
    /// </summary>
    bool ClipContents { get; set; }
    /// <summary>
    /// <para>The minimum size of the node's bounding rectangle. If you set it to a value greater than (0, 0), the node's bounding rectangle will always have at least this size, even if its content is smaller. If it's set to (0, 0), the node sizes automatically to fit its content, be it a texture or child nodes.</para>
    /// </summary>
    Vector2 CustomMinimumSize { get; set; }
    /// <summary>
    /// <para>Ends a bulk theme override update. See <see cref="Control.BeginBulkThemeOverride" />.</para>
    /// </summary>
    void EndBulkThemeOverride();
    /// <summary>
    /// <para>Finds the next (below in the tree) <see cref="Control" /> that can receive the focus.</para>
    /// </summary>
    Control FindNextValidFocus();
    /// <summary>
    /// <para>Finds the previous (above in the tree) <see cref="Control" /> that can receive the focus.</para>
    /// </summary>
    Control FindPrevValidFocus();
    /// <summary>
    /// <para>Finds the next <see cref="Control" /> that can receive the focus on the specified <see cref="Side" />.</para>
    /// <para><b>Note:</b> This is different from <see cref="Control.GetFocusNeighbor(Godot.Side)" />, which returns the path of a specified focus neighbor.</para>
    /// </summary>
    Control FindValidFocusNeighbor(Side side);
    /// <summary>
    /// <para>The focus access mode for the control (None, Click or All). Only one Control can be focused at the same time, and it will receive keyboard, gamepad, and mouse signals.</para>
    /// </summary>
    Control.FocusModeEnum FocusMode { get; set; }
    /// <summary>
    /// <para>Tells Godot which node it should give focus to if the user presses the down arrow on the keyboard or down on a gamepad by default. You can change the key by editing the <c>ProjectSettings.input/ui_down</c> input action. The node must be a <see cref="Control" />. If this property is not set, Godot will give focus to the closest <see cref="Control" /> to the bottom of this one.</para>
    /// </summary>
    NodePath FocusNeighborBottom { get; set; }
    /// <summary>
    /// <para>Tells Godot which node it should give focus to if the user presses the left arrow on the keyboard or left on a gamepad by default. You can change the key by editing the <c>ProjectSettings.input/ui_left</c> input action. The node must be a <see cref="Control" />. If this property is not set, Godot will give focus to the closest <see cref="Control" /> to the left of this one.</para>
    /// </summary>
    NodePath FocusNeighborLeft { get; set; }
    /// <summary>
    /// <para>Tells Godot which node it should give focus to if the user presses the right arrow on the keyboard or right on a gamepad by default. You can change the key by editing the <c>ProjectSettings.input/ui_right</c> input action. The node must be a <see cref="Control" />. If this property is not set, Godot will give focus to the closest <see cref="Control" /> to the right of this one.</para>
    /// </summary>
    NodePath FocusNeighborRight { get; set; }
    /// <summary>
    /// <para>Tells Godot which node it should give focus to if the user presses the top arrow on the keyboard or top on a gamepad by default. You can change the key by editing the <c>ProjectSettings.input/ui_up</c> input action. The node must be a <see cref="Control" />. If this property is not set, Godot will give focus to the closest <see cref="Control" /> to the top of this one.</para>
    /// </summary>
    NodePath FocusNeighborTop { get; set; }
    /// <summary>
    /// <para>Tells Godot which node it should give focus to if the user presses Tab on a keyboard by default. You can change the key by editing the <c>ProjectSettings.input/ui_focus_next</c> input action.</para>
    /// <para>If this property is not set, Godot will select a "best guess" based on surrounding nodes in the scene tree.</para>
    /// </summary>
    NodePath FocusNext { get; set; }
    /// <summary>
    /// <para>Tells Godot which node it should give focus to if the user presses Shift + Tab on a keyboard by default. You can change the key by editing the <c>ProjectSettings.input/ui_focus_prev</c> input action.</para>
    /// <para>If this property is not set, Godot will select a "best guess" based on surrounding nodes in the scene tree.</para>
    /// </summary>
    NodePath FocusPrevious { get; set; }
    /// <summary>
    /// <para>Forces drag and bypasses <see cref="Control._GetDragData(Godot.Vector2)" /> and <see cref="Control.SetDragPreview(Godot.Control)" /> by passing <paramref name="data" /> and <paramref name="preview" />. Drag will start even if the mouse is neither over nor pressed on this control.</para>
    /// <para>The methods <see cref="Control._CanDropData(Godot.Vector2,Godot.Variant)" /> and <see cref="Control._DropData(Godot.Vector2,Godot.Variant)" /> must be implemented on controls that want to receive drop data.</para>
    /// </summary>
    void ForceDrag(Variant data, Control preview);
    /// <summary>
    /// <para>Returns <see cref="Control.OffsetLeft" /> and <see cref="Control.OffsetTop" />. See also <see cref="Control.Position" />.</para>
    /// </summary>
    Vector2 GetBegin();
    /// <summary>
    /// <para>Returns combined minimum size from <see cref="Control.CustomMinimumSize" /> and <see cref="Control.GetMinimumSize" />.</para>
    /// </summary>
    Vector2 GetCombinedMinimumSize();
    /// <summary>
    /// <para>Returns the mouse cursor shape the control displays on mouse hover. See <see cref="Control.CursorShape" />.</para>
    /// </summary>
    /// <param name="position">If the parameter is null, then the default value is <c>new Vector2(0, 0)</c>.</param>
    Control.CursorShape GetCursorShape(Nullable<Vector2> position);
    /// <summary>
    /// <para>Returns <see cref="Control.OffsetRight" /> and <see cref="Control.OffsetBottom" />.</para>
    /// </summary>
    Vector2 GetEnd();
    /// <summary>
    /// <para>Returns the position and size of the control relative to the containing canvas. See <see cref="Control.GlobalPosition" /> and <see cref="Control.Size" />.</para>
    /// <para><b>Note:</b> If the node itself or any parent <see cref="CanvasItem" /> between the node and the canvas have a non default rotation or skew, the resulting size is likely not meaningful.</para>
    /// <para><b>Note:</b> Setting <see cref="Viewport.GuiSnapControlsToPixels" /> to <c>true</c> can lead to rounding inaccuracies between the displayed control and the returned <see cref="Rect2" />.</para>
    /// </summary>
    Rect2 GetGlobalRect();
    /// <summary>
    /// <para>Returns the minimum size for this control. See <see cref="Control.CustomMinimumSize" />.</para>
    /// </summary>
    Vector2 GetMinimumSize();
    /// <summary>
    /// <para>Returns the width/height occupied in the parent control.</para>
    /// </summary>
    Vector2 GetParentAreaSize();
    /// <summary>
    /// <para>Returns the parent control node.</para>
    /// </summary>
    Control GetParentControl();
    /// <summary>
    /// <para>Returns the position and size of the control in the coordinate system of the containing node. See <see cref="Control.Position" />, <see cref="Control.Scale" /> and <see cref="Control.Size" />.</para>
    /// <para><b>Note:</b> If <see cref="Control.Rotation" /> is not the default rotation, the resulting size is not meaningful.</para>
    /// <para><b>Note:</b> Setting <see cref="Viewport.GuiSnapControlsToPixels" /> to <c>true</c> can lead to rounding inaccuracies between the displayed control and the returned <see cref="Rect2" />.</para>
    /// </summary>
    Rect2 GetRect();
    /// <summary>
    /// <para>Returns the position of this <see cref="Control" /> in global screen coordinates (i.e. taking window position into account). Mostly useful for editor plugins.</para>
    /// <para>Equals to <see cref="Control.GlobalPosition" /> if the window is embedded (see <see cref="Viewport.GuiEmbedSubwindows" />).</para>
    /// <para><b>Example usage for showing a popup:</b></para>
    /// <para><code>
    /// popup_menu.position = get_screen_position() + get_local_mouse_position()
    /// popup_menu.reset_size()
    /// popup_menu.popup()
    /// </code></para>
    /// </summary>
    Vector2 GetScreenPosition();
    /// <summary>
    /// <para>Returns a <see cref="Color" /> from the first matching <see cref="Theme" /> in the tree if that <see cref="Theme" /> has a color item with the specified <paramref name="name" /> and <paramref name="themeType" />. If <paramref name="themeType" /> is omitted the class name of the current control is used as the type, or <see cref="Control.ThemeTypeVariation" /> if it is defined. If the type is a class name its parent classes are also checked, in order of inheritance. If the type is a variation its base types are checked, in order of dependency, then the control's class name and its parent classes are checked.</para>
    /// <para>For the current control its local overrides are considered first (see <see cref="Control.AddThemeColorOverride(Godot.StringName,Godot.Color)" />), then its assigned <see cref="Control.Theme" />. After the current control, each parent control and its assigned <see cref="Control.Theme" /> are considered; controls without a <see cref="Control.Theme" /> assigned are skipped. If no matching <see cref="Theme" /> is found in the tree, the custom project <see cref="Theme" /> (see <c>ProjectSettings.gui/theme/custom</c>) and the default <see cref="Theme" /> are used (see <see cref="ThemeDB" />).</para>
    /// <para><code>
    /// public override void _Ready()
    /// {
    /// // Get the font color defined for the current Control's class, if it exists.
    /// Modulate = GetThemeColor("font_color");
    /// // Get the font color defined for the Button class.
    /// Modulate = GetThemeColor("font_color", "Button");
    /// }
    /// </code></para>
    /// </summary>
    Color GetThemeColor(StringName name, StringName themeType);
    /// <summary>
    /// <para>Returns a constant from the first matching <see cref="Theme" /> in the tree if that <see cref="Theme" /> has a constant item with the specified <paramref name="name" /> and <paramref name="themeType" />.</para>
    /// <para>See <see cref="Control.GetThemeColor(Godot.StringName,Godot.StringName)" /> for details.</para>
    /// </summary>
    int GetThemeConstant(StringName name, StringName themeType);
    /// <summary>
    /// <para>Returns the default base scale value from the first matching <see cref="Theme" /> in the tree if that <see cref="Theme" /> has a valid <see cref="Theme.DefaultBaseScale" /> value.</para>
    /// <para>See <see cref="Control.GetThemeColor(Godot.StringName,Godot.StringName)" /> for details.</para>
    /// </summary>
    float GetThemeDefaultBaseScale();
    /// <summary>
    /// <para>Returns the default font from the first matching <see cref="Theme" /> in the tree if that <see cref="Theme" /> has a valid <see cref="Theme.DefaultFont" /> value.</para>
    /// <para>See <see cref="Control.GetThemeColor(Godot.StringName,Godot.StringName)" /> for details.</para>
    /// </summary>
    Font GetThemeDefaultFont();
    /// <summary>
    /// <para>Returns the default font size value from the first matching <see cref="Theme" /> in the tree if that <see cref="Theme" /> has a valid <see cref="Theme.DefaultFontSize" /> value.</para>
    /// <para>See <see cref="Control.GetThemeColor(Godot.StringName,Godot.StringName)" /> for details.</para>
    /// </summary>
    int GetThemeDefaultFontSize();
    /// <summary>
    /// <para>Returns a <see cref="Font" /> from the first matching <see cref="Theme" /> in the tree if that <see cref="Theme" /> has a font item with the specified <paramref name="name" /> and <paramref name="themeType" />.</para>
    /// <para>See <see cref="Control.GetThemeColor(Godot.StringName,Godot.StringName)" /> for details.</para>
    /// </summary>
    Font GetThemeFont(StringName name, StringName themeType);
    /// <summary>
    /// <para>Returns a font size from the first matching <see cref="Theme" /> in the tree if that <see cref="Theme" /> has a font size item with the specified <paramref name="name" /> and <paramref name="themeType" />.</para>
    /// <para>See <see cref="Control.GetThemeColor(Godot.StringName,Godot.StringName)" /> for details.</para>
    /// </summary>
    int GetThemeFontSize(StringName name, StringName themeType);
    /// <summary>
    /// <para>Returns an icon from the first matching <see cref="Theme" /> in the tree if that <see cref="Theme" /> has an icon item with the specified <paramref name="name" /> and <paramref name="themeType" />.</para>
    /// <para>See <see cref="Control.GetThemeColor(Godot.StringName,Godot.StringName)" /> for details.</para>
    /// </summary>
    Texture2D GetThemeIcon(StringName name, StringName themeType);
    /// <summary>
    /// <para>Returns a <see cref="StyleBox" /> from the first matching <see cref="Theme" /> in the tree if that <see cref="Theme" /> has a stylebox item with the specified <paramref name="name" /> and <paramref name="themeType" />.</para>
    /// <para>See <see cref="Control.GetThemeColor(Godot.StringName,Godot.StringName)" /> for details.</para>
    /// </summary>
    StyleBox GetThemeStylebox(StringName name, StringName themeType);
    /// <summary>
    /// <para>Returns the tooltip text for the position <paramref name="atPosition" /> in control's local coordinates, which will typically appear when the cursor is resting over this control. By default, it returns <see cref="Control.TooltipText" />.</para>
    /// <para>This method can be overridden to customize its behavior. See <see cref="Control._GetTooltip(Godot.Vector2)" />.</para>
    /// <para><b>Note:</b> If this method returns an empty <see cref="T:System.String" />, no tooltip is displayed.</para>
    /// </summary>
    /// <param name="atPosition">If the parameter is null, then the default value is <c>new Vector2(0, 0)</c>.</param>
    string GetTooltip(Nullable<Vector2> atPosition);
    /// <summary>
    /// <para>The node's global position, relative to the world (usually to the <see cref="CanvasLayer" />).</para>
    /// </summary>
    Vector2 GlobalPosition { get; set; }
    /// <summary>
    /// <para>Creates an <see cref="InputEventMouseButton" /> that attempts to click the control. If the event is received, the control acquires focus.</para>
    /// <para><code>
    /// public override void _Process(double delta)
    /// {
    /// GrabClickFocus(); // When clicking another Control node, this node will be clicked instead.
    /// }
    /// </code></para>
    /// </summary>
    void GrabClickFocus();
    /// <summary>
    /// <para>Steal the focus from another control and become the focused control (see <see cref="Control.FocusMode" />).</para>
    /// <para><b>Note:</b> Using this method together with <c>Callable.call_deferred</c> makes it more reliable, especially when called inside <see cref="Node._Ready" />.</para>
    /// </summary>
    void GrabFocus();
    /// <summary>
    /// <para>Controls the direction on the horizontal axis in which the control should grow if its horizontal minimum size is changed to be greater than its current size, as the control always has to be at least the minimum size.</para>
    /// </summary>
    Control.GrowDirection GrowHorizontal { get; set; }
    /// <summary>
    /// <para>Controls the direction on the vertical axis in which the control should grow if its vertical minimum size is changed to be greater than its current size, as the control always has to be at least the minimum size.</para>
    /// </summary>
    Control.GrowDirection GrowVertical { get; set; }
    /// <summary>
    /// <para>Returns <c>true</c> if this is the current focused control. See <see cref="Control.FocusMode" />.</para>
    /// </summary>
    bool HasFocus();
    /// <summary>
    /// <para>Returns <c>true</c> if there is a matching <see cref="Theme" /> in the tree that has a color item with the specified <paramref name="name" /> and <paramref name="themeType" />.</para>
    /// <para>See <see cref="Control.GetThemeColor(Godot.StringName,Godot.StringName)" /> for details.</para>
    /// </summary>
    bool HasThemeColor(StringName name, StringName themeType);
    /// <summary>
    /// <para>Returns <c>true</c> if there is a local override for a theme <see cref="Color" /> with the specified <paramref name="name" /> in this <see cref="Control" /> node.</para>
    /// <para>See <see cref="Control.AddThemeColorOverride(Godot.StringName,Godot.Color)" />.</para>
    /// </summary>
    bool HasThemeColorOverride(StringName name);
    /// <summary>
    /// <para>Returns <c>true</c> if there is a matching <see cref="Theme" /> in the tree that has a constant item with the specified <paramref name="name" /> and <paramref name="themeType" />.</para>
    /// <para>See <see cref="Control.GetThemeColor(Godot.StringName,Godot.StringName)" /> for details.</para>
    /// </summary>
    bool HasThemeConstant(StringName name, StringName themeType);
    /// <summary>
    /// <para>Returns <c>true</c> if there is a local override for a theme constant with the specified <paramref name="name" /> in this <see cref="Control" /> node.</para>
    /// <para>See <see cref="Control.AddThemeConstantOverride(Godot.StringName,System.Int32)" />.</para>
    /// </summary>
    bool HasThemeConstantOverride(StringName name);
    /// <summary>
    /// <para>Returns <c>true</c> if there is a matching <see cref="Theme" /> in the tree that has a font item with the specified <paramref name="name" /> and <paramref name="themeType" />.</para>
    /// <para>See <see cref="Control.GetThemeColor(Godot.StringName,Godot.StringName)" /> for details.</para>
    /// </summary>
    bool HasThemeFont(StringName name, StringName themeType);
    /// <summary>
    /// <para>Returns <c>true</c> if there is a local override for a theme <see cref="Font" /> with the specified <paramref name="name" /> in this <see cref="Control" /> node.</para>
    /// <para>See <see cref="Control.AddThemeFontOverride(Godot.StringName,Godot.Font)" />.</para>
    /// </summary>
    bool HasThemeFontOverride(StringName name);
    /// <summary>
    /// <para>Returns <c>true</c> if there is a matching <see cref="Theme" /> in the tree that has a font size item with the specified <paramref name="name" /> and <paramref name="themeType" />.</para>
    /// <para>See <see cref="Control.GetThemeColor(Godot.StringName,Godot.StringName)" /> for details.</para>
    /// </summary>
    bool HasThemeFontSize(StringName name, StringName themeType);
    /// <summary>
    /// <para>Returns <c>true</c> if there is a local override for a theme font size with the specified <paramref name="name" /> in this <see cref="Control" /> node.</para>
    /// <para>See <see cref="Control.AddThemeFontSizeOverride(Godot.StringName,System.Int32)" />.</para>
    /// </summary>
    bool HasThemeFontSizeOverride(StringName name);
    /// <summary>
    /// <para>Returns <c>true</c> if there is a matching <see cref="Theme" /> in the tree that has an icon item with the specified <paramref name="name" /> and <paramref name="themeType" />.</para>
    /// <para>See <see cref="Control.GetThemeColor(Godot.StringName,Godot.StringName)" /> for details.</para>
    /// </summary>
    bool HasThemeIcon(StringName name, StringName themeType);
    /// <summary>
    /// <para>Returns <c>true</c> if there is a local override for a theme icon with the specified <paramref name="name" /> in this <see cref="Control" /> node.</para>
    /// <para>See <see cref="Control.AddThemeIconOverride(Godot.StringName,Godot.Texture2D)" />.</para>
    /// </summary>
    bool HasThemeIconOverride(StringName name);
    /// <summary>
    /// <para>Returns <c>true</c> if there is a matching <see cref="Theme" /> in the tree that has a stylebox item with the specified <paramref name="name" /> and <paramref name="themeType" />.</para>
    /// <para>See <see cref="Control.GetThemeColor(Godot.StringName,Godot.StringName)" /> for details.</para>
    /// </summary>
    bool HasThemeStylebox(StringName name, StringName themeType);
    /// <summary>
    /// <para>Returns <c>true</c> if there is a local override for a theme <see cref="StyleBox" /> with the specified <paramref name="name" /> in this <see cref="Control" /> node.</para>
    /// <para>See <see cref="Control.AddThemeStyleboxOverride(Godot.StringName,Godot.StyleBox)" />.</para>
    /// </summary>
    bool HasThemeStyleboxOverride(StringName name);
    /// <summary>
    /// <para>Returns <c>true</c> if a drag operation is successful. Alternative to <see cref="Viewport.GuiIsDragSuccessful" />.</para>
    /// <para>Best used with <see cref="Node.NotificationDragEnd" />.</para>
    /// </summary>
    bool IsDragSuccessful();
    /// <summary>
    /// <para>Returns <c>true</c> if layout is right-to-left.</para>
    /// </summary>
    bool IsLayoutRtl();
    /// <summary>
    /// <para>Controls layout direction and text writing direction. Right-to-left layouts are necessary for certain languages (e.g. Arabic and Hebrew).</para>
    /// </summary>
    Control.LayoutDirectionEnum LayoutDirection { get; set; }

    int LayoutMode { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, automatically converts code line numbers, list indices, <see cref="SpinBox" /> and <see cref="ProgressBar" /> values from the Western Arabic (0..9) to the numeral systems used in current locale.</para>
    /// <para><b>Note:</b> Numbers within the text are not automatically converted, it can be done manually, using <see cref="TextServer.FormatNumber(System.String,System.String)" />.</para>
    /// </summary>
    bool LocalizeNumeralSystem { get; set; }
    /// <summary>
    /// <para>The default cursor shape for this control. Useful for Godot plugins and applications or games that use the system's mouse cursors.</para>
    /// <para><b>Note:</b> On Linux, shapes may vary depending on the cursor theme of the system.</para>
    /// </summary>
    Control.CursorShape MouseDefaultCursorShape { get; set; }
    /// <summary>
    /// <para>Controls whether the control will be able to receive mouse button input events through <see cref="Control._GuiInput(Godot.InputEvent)" /> and how these events should be handled. Also controls whether the control can receive the <see cref="Control.MouseEntered" />, and <see cref="Control.MouseExited" /> signals. See the constants to learn what each does.</para>
    /// </summary>
    Control.MouseFilterEnum MouseFilter { get; set; }
    /// <summary>
    /// <para>When enabled, scroll wheel events processed by <see cref="Control._GuiInput(Godot.InputEvent)" /> will be passed to the parent control even if <see cref="Control.MouseFilter" /> is set to <see cref="Control.MouseFilterEnum.Stop" />. As it defaults to true, this allows nested scrollable containers to work out of the box.</para>
    /// <para>You should disable it on the root of your UI if you do not want scroll events to go to the <see cref="Node._UnhandledInput(Godot.InputEvent)" /> processing.</para>
    /// </summary>
    bool MouseForcePassScrollEvents { get; set; }
    /// <summary>
    /// <para>Distance between the node's bottom edge and its parent control, based on <see cref="Control.AnchorBottom" />.</para>
    /// <para>Offsets are often controlled by one or multiple parent <see cref="Container" /> nodes, so you should not modify them manually if your node is a direct child of a <see cref="Container" />. Offsets update automatically when you move or resize the node.</para>
    /// </summary>
    float OffsetBottom { get; set; }
    /// <summary>
    /// <para>Distance between the node's left edge and its parent control, based on <see cref="Control.AnchorLeft" />.</para>
    /// <para>Offsets are often controlled by one or multiple parent <see cref="Container" /> nodes, so you should not modify them manually if your node is a direct child of a <see cref="Container" />. Offsets update automatically when you move or resize the node.</para>
    /// </summary>
    float OffsetLeft { get; set; }
    /// <summary>
    /// <para>Distance between the node's right edge and its parent control, based on <see cref="Control.AnchorRight" />.</para>
    /// <para>Offsets are often controlled by one or multiple parent <see cref="Container" /> nodes, so you should not modify them manually if your node is a direct child of a <see cref="Container" />. Offsets update automatically when you move or resize the node.</para>
    /// </summary>
    float OffsetRight { get; set; }
    /// <summary>
    /// <para>Distance between the node's top edge and its parent control, based on <see cref="Control.AnchorTop" />.</para>
    /// <para>Offsets are often controlled by one or multiple parent <see cref="Container" /> nodes, so you should not modify them manually if your node is a direct child of a <see cref="Container" />. Offsets update automatically when you move or resize the node.</para>
    /// </summary>
    float OffsetTop { get; set; }
    /// <summary>
    /// <para>By default, the node's pivot is its top-left corner. When you change its <see cref="Control.Rotation" /> or <see cref="Control.Scale" />, it will rotate or scale around this pivot. Set this property to <see cref="Control.Size" /> / 2 to pivot around the Control's center.</para>
    /// </summary>
    Vector2 PivotOffset { get; set; }
    /// <summary>
    /// <para>The node's position, relative to its containing node. It corresponds to the rectangle's top-left corner. The property is not affected by <see cref="Control.PivotOffset" />.</para>
    /// </summary>
    Vector2 Position { get; set; }
    /// <summary>
    /// <para>Give up the focus. No other control will be able to receive input.</para>
    /// </summary>
    void ReleaseFocus();
    /// <summary>
    /// <para>Removes a local override for a theme <see cref="Color" /> with the specified <paramref name="name" /> previously added by <see cref="Control.AddThemeColorOverride(Godot.StringName,Godot.Color)" /> or via the Inspector dock.</para>
    /// </summary>
    void RemoveThemeColorOverride(StringName name);
    /// <summary>
    /// <para>Removes a local override for a theme constant with the specified <paramref name="name" /> previously added by <see cref="Control.AddThemeConstantOverride(Godot.StringName,System.Int32)" /> or via the Inspector dock.</para>
    /// </summary>
    void RemoveThemeConstantOverride(StringName name);
    /// <summary>
    /// <para>Removes a local override for a theme <see cref="Font" /> with the specified <paramref name="name" /> previously added by <see cref="Control.AddThemeFontOverride(Godot.StringName,Godot.Font)" /> or via the Inspector dock.</para>
    /// </summary>
    void RemoveThemeFontOverride(StringName name);
    /// <summary>
    /// <para>Removes a local override for a theme font size with the specified <paramref name="name" /> previously added by <see cref="Control.AddThemeFontSizeOverride(Godot.StringName,System.Int32)" /> or via the Inspector dock.</para>
    /// </summary>
    void RemoveThemeFontSizeOverride(StringName name);
    /// <summary>
    /// <para>Removes a local override for a theme icon with the specified <paramref name="name" /> previously added by <see cref="Control.AddThemeIconOverride(Godot.StringName,Godot.Texture2D)" /> or via the Inspector dock.</para>
    /// </summary>
    void RemoveThemeIconOverride(StringName name);
    /// <summary>
    /// <para>Removes a local override for a theme <see cref="StyleBox" /> with the specified <paramref name="name" /> previously added by <see cref="Control.AddThemeStyleboxOverride(Godot.StringName,Godot.StyleBox)" /> or via the Inspector dock.</para>
    /// </summary>
    void RemoveThemeStyleboxOverride(StringName name);
    /// <summary>
    /// <para>Resets the size to <see cref="Control.GetCombinedMinimumSize" />. This is equivalent to calling <c>set_size(Vector2())</c> (or any size below the minimum).</para>
    /// </summary>
    void ResetSize();
    /// <summary>
    /// <para>The node's rotation around its pivot, in radians. See <see cref="Control.PivotOffset" /> to change the pivot's position.</para>
    /// <para><b>Note:</b> This property is edited in the inspector in degrees. If you want to use degrees in a script, use <see cref="Control.RotationDegrees" />.</para>
    /// </summary>
    float Rotation { get; set; }
    /// <summary>
    /// <para>Helper property to access <see cref="Control.Rotation" /> in degrees instead of radians.</para>
    /// </summary>
    float RotationDegrees { get; set; }
    /// <summary>
    /// <para>The node's scale, relative to its <see cref="Control.Size" />. Change this property to scale the node around its <see cref="Control.PivotOffset" />. The Control's <see cref="Control.TooltipText" /> will also scale according to this value.</para>
    /// <para><b>Note:</b> This property is mainly intended to be used for animation purposes. To support multiple resolutions in your project, use an appropriate viewport stretch mode as described in the <a href="$DOCS_URL/tutorials/rendering/multiple_resolutions.html">documentation</a> instead of scaling Controls individually.</para>
    /// <para><b>Note:</b> <see cref="FontFile.Oversampling" /> does <i>not</i> take <see cref="Control" /> <see cref="Control.Scale" /> into account. This means that scaling up/down will cause bitmap fonts and rasterized (non-MSDF) dynamic fonts to appear blurry or pixelated. To ensure text remains crisp regardless of scale, you can enable MSDF font rendering by enabling <c>ProjectSettings.gui/theme/default_font_multichannel_signed_distance_field</c> (applies to the default project font only), or enabling <b>Multichannel Signed Distance Field</b> in the import options of a DynamicFont for custom fonts. On system fonts, <see cref="SystemFont.MultichannelSignedDistanceField" /> can be enabled in the inspector.</para>
    /// <para><b>Note:</b> If the Control node is a child of a <see cref="Container" /> node, the scale will be reset to <c>Vector2(1, 1)</c> when the scene is instantiated. To set the Control's scale when it's instantiated, wait for one frame using <c>await get_tree().process_frame</c> then set its <see cref="Control.Scale" /> property.</para>
    /// </summary>
    Vector2 Scale { get; set; }
    /// <summary>
    /// <para>Sets the anchor for the specified <see cref="Side" /> to <paramref name="anchor" />. A setter method for <see cref="Control.AnchorBottom" />, <see cref="Control.AnchorLeft" />, <see cref="Control.AnchorRight" /> and <see cref="Control.AnchorTop" />.</para>
    /// <para>If <paramref name="keepOffset" /> is <c>true</c>, offsets aren't updated after this operation.</para>
    /// <para>If <paramref name="pushOppositeAnchor" /> is <c>true</c> and the opposite anchor overlaps this anchor, the opposite one will have its value overridden. For example, when setting left anchor to 1 and the right anchor has value of 0.5, the right anchor will also get value of 1. If <paramref name="pushOppositeAnchor" /> was <c>false</c>, the left anchor would get value 0.5.</para>
    /// </summary>
    void SetAnchor(Side side, float anchor, bool keepOffset, bool pushOppositeAnchor);
    /// <summary>
    /// <para>Works the same as <see cref="Control.SetAnchor(Godot.Side,System.Single,System.Boolean,System.Boolean)" />, but instead of <c>keep_offset</c> argument and automatic update of offset, it allows to set the offset yourself (see <see cref="Control.SetOffset(Godot.Side,System.Single)" />).</para>
    /// </summary>
    void SetAnchorAndOffset(Side side, float anchor, float offset, bool pushOppositeAnchor);
    /// <summary>
    /// <para>Sets both anchor preset and offset preset. See <see cref="Control.SetAnchorsPreset(Godot.Control.LayoutPreset,System.Boolean)" /> and <see cref="Control.SetOffsetsPreset(Godot.Control.LayoutPreset,Godot.Control.LayoutPresetMode,System.Int32)" />.</para>
    /// </summary>
    void SetAnchorsAndOffsetsPreset(Control.LayoutPreset preset, Control.LayoutPresetMode resizeMode, int margin);
    /// <summary>
    /// <para>Sets the anchors to a <paramref name="preset" /> from <see cref="Control.LayoutPreset" /> enum. This is the code equivalent to using the Layout menu in the 2D editor.</para>
    /// <para>If <paramref name="keepOffsets" /> is <c>true</c>, control's position will also be updated.</para>
    /// </summary>
    void SetAnchorsPreset(Control.LayoutPreset preset, bool keepOffsets);
    /// <summary>
    /// <para>Sets <see cref="Control.OffsetLeft" /> and <see cref="Control.OffsetTop" /> at the same time. Equivalent of changing <see cref="Control.Position" />.</para>
    /// </summary>
    void SetBegin(Vector2 position);
    /// <summary>
    /// <para>Forwards the handling of this control's <see cref="Control._GetDragData(Godot.Vector2)" />,  <see cref="Control._CanDropData(Godot.Vector2,Godot.Variant)" /> and <see cref="Control._DropData(Godot.Vector2,Godot.Variant)" /> virtual functions to delegate callables.</para>
    /// <para>For each argument, if not empty, the delegate callable is used, otherwise the local (virtual) function is used.</para>
    /// <para>The function format for each callable should be exactly the same as the virtual functions described above.</para>
    /// </summary>
    void SetDragForwarding(Callable dragFunc, Callable canDropFunc, Callable dropFunc);
    /// <summary>
    /// <para>Shows the given control at the mouse pointer. A good time to call this method is in <see cref="Control._GetDragData(Godot.Vector2)" />. The control must not be in the scene tree. You should not free the control, and you should not keep a reference to the control beyond the duration of the drag. It will be deleted automatically after the drag has ended.</para>
    /// <para><code>
    /// [Export]
    /// private Color _color = new Color(1, 0, 0, 1);
    /// public override Variant _GetDragData(Vector2 atPosition)
    /// {
    /// // Use a control that is not in the tree
    /// var cpb = new ColorPickerButton();
    /// cpb.Color = _color;
    /// cpb.Size = new Vector2(50, 50);
    /// SetDragPreview(cpb);
    /// return _color;
    /// }
    /// </code></para>
    /// </summary>
    void SetDragPreview(Control control);
    /// <summary>
    /// <para>Sets <see cref="Control.OffsetRight" /> and <see cref="Control.OffsetBottom" /> at the same time.</para>
    /// </summary>
    void SetEnd(Vector2 position);
    /// <summary>
    /// <para>Sets the <see cref="Control.GlobalPosition" /> to given <paramref name="position" />.</para>
    /// <para>If <paramref name="keepOffsets" /> is <c>true</c>, control's anchors will be updated instead of offsets.</para>
    /// </summary>
    void SetGlobalPosition(Vector2 position, bool keepOffsets);
    /// <summary>
    /// <para>Sets the offsets to a <paramref name="preset" /> from <see cref="Control.LayoutPreset" /> enum. This is the code equivalent to using the Layout menu in the 2D editor.</para>
    /// <para>Use parameter <paramref name="resizeMode" /> with constants from <see cref="Control.LayoutPresetMode" /> to better determine the resulting size of the <see cref="Control" />. Constant size will be ignored if used with presets that change size, e.g. <see cref="Control.LayoutPreset.LeftWide" />.</para>
    /// <para>Use parameter <paramref name="margin" /> to determine the gap between the <see cref="Control" /> and the edges.</para>
    /// </summary>
    void SetOffsetsPreset(Control.LayoutPreset preset, Control.LayoutPresetMode resizeMode, int margin);
    /// <summary>
    /// <para>Sets the <see cref="Control.Position" /> to given <paramref name="position" />.</para>
    /// <para>If <paramref name="keepOffsets" /> is <c>true</c>, control's anchors will be updated instead of offsets.</para>
    /// </summary>
    void SetPosition(Vector2 position, bool keepOffsets);
    /// <summary>
    /// <para>Sets the size (see <see cref="Control.Size" />).</para>
    /// <para>If <paramref name="keepOffsets" /> is <c>true</c>, control's anchors will be updated instead of offsets.</para>
    /// </summary>
    void SetSize(Vector2 size, bool keepOffsets);
    /// <summary>
    /// <para>The <see cref="Node" /> which must be a parent of the focused <see cref="Control" /> for the shortcut to be activated. If <c>null</c>, the shortcut can be activated when any control is focused (a global shortcut). This allows shortcuts to be accepted only when the user has a certain area of the GUI focused.</para>
    /// </summary>
    Node ShortcutContext { get; set; }
    /// <summary>
    /// <para>The size of the node's bounding rectangle, in the node's coordinate system. <see cref="Container" /> nodes update this property automatically.</para>
    /// </summary>
    Vector2 Size { get; set; }
    /// <summary>
    /// <para>Tells the parent <see cref="Container" /> nodes how they should resize and place the node on the X axis. Use a combination of the <see cref="Control.SizeFlags" /> constants to change the flags. See the constants to learn what each does.</para>
    /// </summary>
    Control.SizeFlags SizeFlagsHorizontal { get; set; }
    /// <summary>
    /// <para>If the node and at least one of its neighbors uses the <see cref="Control.SizeFlags.Expand" /> size flag, the parent <see cref="Container" /> will let it take more or less space depending on this property. If this node has a stretch ratio of 2 and its neighbor a ratio of 1, this node will take two thirds of the available space.</para>
    /// </summary>
    float SizeFlagsStretchRatio { get; set; }
    /// <summary>
    /// <para>Tells the parent <see cref="Container" /> nodes how they should resize and place the node on the Y axis. Use a combination of the <see cref="Control.SizeFlags" /> constants to change the flags. See the constants to learn what each does.</para>
    /// </summary>
    Control.SizeFlags SizeFlagsVertical { get; set; }
    /// <summary>
    /// <para>The <see cref="Theme" /> resource this node and all its <see cref="Control" /> and <see cref="Window" /> children use. If a child node has its own <see cref="Theme" /> resource set, theme items are merged with child's definitions having higher priority.</para>
    /// <para><b>Note:</b> <see cref="Window" /> styles will have no effect unless the window is embedded.</para>
    /// </summary>
    Theme Theme { get; set; }
    /// <summary>
    /// <para>The name of a theme type variation used by this <see cref="Control" /> to look up its own theme items. When empty, the class name of the node is used (e.g. <c>Button</c> for the <see cref="Button" /> control), as well as the class names of all parent classes (in order of inheritance).</para>
    /// <para>When set, this property gives the highest priority to the type of the specified name. This type can in turn extend another type, forming a dependency chain. See <see cref="Theme.SetTypeVariation(Godot.StringName,Godot.StringName)" />. If the theme item cannot be found using this type or its base types, lookup falls back on the class names.</para>
    /// <para><b>Note:</b> To look up <see cref="Control" />'s own items use various <c>get_theme_*</c> methods without specifying <c>theme_type</c>.</para>
    /// <para><b>Note:</b> Theme items are looked for in the tree order, from branch to root, where each <see cref="Control" /> node is checked for its <see cref="Control.Theme" /> property. The earliest match against any type/class name is returned. The project-level Theme and the default Theme are checked last.</para>
    /// </summary>
    StringName ThemeTypeVariation { get; set; }
    /// <summary>
    /// <para>The default tooltip text. The tooltip appears when the user's mouse cursor stays idle over this control for a few moments, provided that the <see cref="Control.MouseFilter" /> property is not <see cref="Control.MouseFilterEnum.Ignore" />. The time required for the tooltip to appear can be changed with the <c>ProjectSettings.gui/timers/tooltip_delay_sec</c> option. See also <see cref="Control.GetTooltip(System.Nullable{Godot.Vector2})" />.</para>
    /// <para>The tooltip popup will use either a default implementation, or a custom one that you can provide by overriding <see cref="Control._MakeCustomTooltip(System.String)" />. The default tooltip includes a <see cref="PopupPanel" /> and <see cref="Label" /> whose theme properties can be customized using <see cref="Theme" /> methods with the <c>"TooltipPanel"</c> and <c>"TooltipLabel"</c> respectively. For example:</para>
    /// <para><code>
    /// var styleBox = new StyleBoxFlat();
    /// styleBox.SetBgColor(new Color(1, 1, 0));
    /// styleBox.SetBorderWidthAll(2);
    /// // We assume here that the `Theme` property has been assigned a custom Theme beforehand.
    /// Theme.SetStyleBox("panel", "TooltipPanel", styleBox);
    /// Theme.SetColor("font_color", "TooltipLabel", new Color(0, 1, 1));
    /// </code></para>
    /// </summary>
    string TooltipText { get; set; }
    /// <summary>
    /// <para>Invalidates the size cache in this node and in parent nodes up to top level. Intended to be used with <see cref="Control.GetMinimumSize" /> when the return value is changed. Setting <see cref="Control.CustomMinimumSize" /> directly calls this method automatically.</para>
    /// </summary>
    void UpdateMinimumSize();
    /// <summary>
    /// <para>Moves the mouse cursor to <paramref name="position" />, relative to <see cref="Control.Position" /> of this <see cref="Control" />.</para>
    /// <para><b>Note:</b> <see cref="Control.WarpMouse(Godot.Vector2)" /> is only supported on Windows, macOS and Linux. It has no effect on Android, iOS and Web.</para>
    /// </summary>
    void WarpMouse(Vector2 position);

}