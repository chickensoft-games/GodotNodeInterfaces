namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
using Godot.Collections;
/// <summary>
/// <para>A Viewport creates a different view into the screen, or a sub-view inside another viewport. Children 2D Nodes will display on it, and children Camera3D 3D nodes will render on it too.</para>
/// <para>Optionally, a viewport can have its own 2D or 3D world, so it doesn't share what it draws with other viewports.</para>
/// <para>Viewports can also choose to be audio listeners, so they generate positional audio depending on a 2D or 3D camera child of it.</para>
/// <para>Also, viewports can be assigned to different screens in case the devices have multiple screens.</para>
/// <para>Finally, viewports can also behave as render targets, in which case they will not be visible unless the associated texture is used to draw.</para>
/// </summary>
public class ViewportAdapter : NodeAdapter, IViewport {
  private readonly Viewport _node;

  public ViewportAdapter(Node node) : base(node) {
    if (node is not Viewport typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a Viewport"
      );
    }
    _node = typedNode;
  }

    /// <summary>
    /// <para>If <c>true</c>, the viewport will process 2D audio streams.</para>
    /// </summary>
    public bool AudioListenerEnable2D { get => _node.AudioListenerEnable2D; set => _node.AudioListenerEnable2D = value; }
    /// <summary>
    /// <para>If <c>true</c>, the viewport will process 3D audio streams.</para>
    /// </summary>
    public bool AudioListenerEnable3D { get => _node.AudioListenerEnable3D; set => _node.AudioListenerEnable3D = value; }
    /// <summary>
    /// <para>The rendering layers in which this <see cref="Viewport" /> renders <see cref="CanvasItem" /> nodes.</para>
    /// </summary>
    public uint CanvasCullMask { get => _node.CanvasCullMask; set => _node.CanvasCullMask = value; }
    /// <summary>
    /// <para>Sets the default filter mode used by <see cref="CanvasItem" />s in this Viewport. See <see cref="Viewport.DefaultCanvasItemTextureFilter" /> for options.</para>
    /// </summary>
    public Viewport.DefaultCanvasItemTextureFilter CanvasItemDefaultTextureFilter { get => _node.CanvasItemDefaultTextureFilter; set => _node.CanvasItemDefaultTextureFilter = value; }
    /// <summary>
    /// <para>Sets the default repeat mode used by <see cref="CanvasItem" />s in this Viewport. See <see cref="Viewport.DefaultCanvasItemTextureRepeat" /> for options.</para>
    /// </summary>
    public Viewport.DefaultCanvasItemTextureRepeat CanvasItemDefaultTextureRepeat { get => _node.CanvasItemDefaultTextureRepeat; set => _node.CanvasItemDefaultTextureRepeat = value; }
    /// <summary>
    /// <para>The canvas transform of the viewport, useful for changing the on-screen positions of all child <see cref="CanvasItem" />s. This is relative to the global canvas transform of the viewport.</para>
    /// </summary>
    public Transform2D CanvasTransform { get => _node.CanvasTransform; set => _node.CanvasTransform = value; }
    /// <summary>
    /// <para>The overlay mode for test rendered geometry in debug purposes.</para>
    /// </summary>
    public Viewport.DebugDrawEnum DebugDraw { get => _node.DebugDraw; set => _node.DebugDraw = value; }
    /// <summary>
    /// <para>If <c>true</c>, disables 2D rendering while keeping 3D rendering. See also <see cref="Viewport.Disable3D" />.</para>
    /// </summary>
    public bool Disable2D { get => _node.Disable2D; set => _node.Disable2D = value; }
    /// <summary>
    /// <para>If <c>true</c>, disables 3D rendering while keeping 2D rendering. See also <see cref="Viewport.Disable2D" />.</para>
    /// </summary>
    public bool Disable3D { get => _node.Disable3D; set => _node.Disable3D = value; }
    /// <summary>
    /// <para>Returns the first valid <see cref="World2D" /> for this viewport, searching the <see cref="Viewport.World2D" /> property of itself and any Viewport ancestor.</para>
    /// </summary>
    public World2D FindWorld2D() => _node.FindWorld2D();
    /// <summary>
    /// <para>Returns the first valid <see cref="World3D" /> for this viewport, searching the <see cref="Viewport.World3D" /> property of itself and any Viewport ancestor.</para>
    /// </summary>
    public World3D FindWorld3D() => _node.FindWorld3D();
    /// <summary>
    /// <para>Determines how sharp the upscaled image will be when using the FSR upscaling mode. Sharpness halves with every whole number. Values go from 0.0 (sharpest) to 2.0. Values above 2.0 won't make a visible difference.</para>
    /// <para>To control this property on the root viewport, set the <c>ProjectSettings.rendering/scaling_3d/fsr_sharpness</c> project setting.</para>
    /// </summary>
    public float FsrSharpness { get => _node.FsrSharpness; set => _node.FsrSharpness = value; }
    /// <summary>
    /// <para>Returns the currently active 2D camera. Returns null if there are no active cameras.</para>
    /// </summary>
    public Camera2D GetCamera2D() => _node.GetCamera2D();
    /// <summary>
    /// <para>Returns the currently active 3D camera.</para>
    /// </summary>
    public Camera3D GetCamera3D() => _node.GetCamera3D();
    /// <summary>
    /// <para>Returns an individual bit on the rendering layer mask.</para>
    /// </summary>
    public bool GetCanvasCullMaskBit(uint layer) => _node.GetCanvasCullMaskBit(layer);
    /// <summary>
    /// <para>Returns a list of the visible embedded <see cref="Window" />s inside the viewport.</para>
    /// <para><b>Note:</b> <see cref="Window" />s inside other viewports will not be listed.</para>
    /// </summary>
    public Godot.Collections.Array<Window> GetEmbeddedSubwindows() => _node.GetEmbeddedSubwindows();
    /// <summary>
    /// <para>Returns the transform from the viewport's coordinate system to the embedder's coordinate system.</para>
    /// </summary>
    public Transform2D GetFinalTransform() => _node.GetFinalTransform();
    /// <summary>
    /// <para>Returns the mouse's position in this <see cref="Viewport" /> using the coordinate system of this <see cref="Viewport" />.</para>
    /// </summary>
    public Vector2 GetMousePosition() => _node.GetMousePosition();
    /// <summary>
    /// <para>Returns rendering statistics of the given type. See <see cref="Viewport.RenderInfoType" /> and <see cref="Viewport.RenderInfo" /> for options.</para>
    /// </summary>
    public int GetRenderInfo(Viewport.RenderInfoType @type, Viewport.RenderInfo info) => _node.GetRenderInfo(@type, info);
    /// <summary>
    /// <para>Returns the transform from the Viewport's coordinates to the screen coordinates of the containing window manager window.</para>
    /// </summary>
    public Transform2D GetScreenTransform() => _node.GetScreenTransform();
    /// <summary>
    /// <para>Returns the viewport's texture.</para>
    /// <para><b>Note:</b> When trying to store the current texture (e.g. in a file), it might be completely black or outdated if used too early, especially when used in e.g. <see cref="Node._Ready" />. To make sure the texture you get is correct, you can await <see cref="RenderingServer.FramePostDraw" /> signal.</para>
    /// <para><code>
    /// func _ready():
    /// await RenderingServer.frame_post_draw
    /// $Viewport.get_texture().get_image().save_png("user://Screenshot.png")
    /// </code></para>
    /// </summary>
    public ViewportTexture GetTexture() => _node.GetTexture();
    /// <summary>
    /// <para>Returns the viewport's RID from the <see cref="RenderingServer" />.</para>
    /// </summary>
    public Rid GetViewportRid() => _node.GetViewportRid();
    /// <summary>
    /// <para>Returns the visible rectangle in global screen coordinates.</para>
    /// </summary>
    public Rect2 GetVisibleRect() => _node.GetVisibleRect();
    /// <summary>
    /// <para>The global canvas transform of the viewport. The canvas transform is relative to this.</para>
    /// </summary>
    public Transform2D GlobalCanvasTransform { get => _node.GlobalCanvasTransform; set => _node.GlobalCanvasTransform = value; }
    /// <summary>
    /// <para>If <c>true</c>, the viewport will not receive input events.</para>
    /// </summary>
    public bool GuiDisableInput { get => _node.GuiDisableInput; set => _node.GuiDisableInput = value; }
    /// <summary>
    /// <para>If <c>true</c>, sub-windows (popups and dialogs) will be embedded inside application window as control-like nodes. If <c>false</c>, they will appear as separate windows handled by the operating system.</para>
    /// </summary>
    public bool GuiEmbedSubwindows { get => _node.GuiEmbedSubwindows; set => _node.GuiEmbedSubwindows = value; }
    /// <summary>
    /// <para>Returns the drag data from the GUI, that was previously returned by <see cref="Control._GetDragData(Godot.Vector2)" />.</para>
    /// </summary>
    public Variant GuiGetDragData() => _node.GuiGetDragData();
    /// <summary>
    /// <para>Returns the <see cref="Control" /> having the focus within this viewport. If no <see cref="Control" /> has the focus, returns null.</para>
    /// </summary>
    public Control GuiGetFocusOwner() => _node.GuiGetFocusOwner();
    /// <summary>
    /// <para>Returns <c>true</c> if the viewport is currently performing a drag operation.</para>
    /// <para>Alternative to <see cref="Node.NotificationDragBegin" /> and <see cref="Node.NotificationDragEnd" /> when you prefer polling the value.</para>
    /// </summary>
    public bool GuiIsDragging() => _node.GuiIsDragging();
    /// <summary>
    /// <para>Returns <c>true</c> if the drag operation is successful.</para>
    /// </summary>
    public bool GuiIsDragSuccessful() => _node.GuiIsDragSuccessful();
    /// <summary>
    /// <para>Removes the focus from the currently focused <see cref="Control" /> within this viewport. If no <see cref="Control" /> has the focus, does nothing.</para>
    /// </summary>
    public void GuiReleaseFocus() => _node.GuiReleaseFocus();
    /// <summary>
    /// <para>If <c>true</c>, the GUI controls on the viewport will lay pixel perfectly.</para>
    /// </summary>
    public bool GuiSnapControlsToPixels { get => _node.GuiSnapControlsToPixels; set => _node.GuiSnapControlsToPixels = value; }
    /// <summary>
    /// <para>If <c>true</c>, this viewport will mark incoming input events as handled by itself. If <c>false</c>, this is instead done by the first parent viewport that is set to handle input locally.</para>
    /// <para>A <see cref="SubViewportContainer" /> will automatically set this property to <c>false</c> for the <see cref="Viewport" /> contained inside of it.</para>
    /// <para>See also <see cref="Viewport.SetInputAsHandled" /> and <see cref="Viewport.IsInputHandled" />.</para>
    /// </summary>
    public bool HandleInputLocally { get => _node.HandleInputLocally; set => _node.HandleInputLocally = value; }
    /// <summary>
    /// <para>Returns whether the current <see cref="InputEvent" /> has been handled. Input events are not handled until <see cref="Viewport.SetInputAsHandled" /> has been called during the lifetime of an <see cref="InputEvent" />.</para>
    /// <para>This is usually done as part of input handling methods like <see cref="Node._Input(Godot.InputEvent)" />, <see cref="Control._GuiInput(Godot.InputEvent)" /> or others, as well as in corresponding signal handlers.</para>
    /// <para>If <see cref="Viewport.HandleInputLocally" /> is set to <c>false</c>, this method will try finding the first parent viewport that is set to handle input locally, and return its value for <see cref="Viewport.IsInputHandled" /> instead.</para>
    /// </summary>
    public bool IsInputHandled() => _node.IsInputHandled();
    /// <summary>
    /// <para>The automatic LOD bias to use for meshes rendered within the <see cref="Viewport" /> (this is analogous to <see cref="ReflectionProbe.MeshLodThreshold" />). Higher values will use less detailed versions of meshes that have LOD variations generated. If set to <c>0.0</c>, automatic LOD is disabled. Increase <see cref="Viewport.MeshLodThreshold" /> to improve performance at the cost of geometry detail.</para>
    /// <para>To control this property on the root viewport, set the <c>ProjectSettings.rendering/mesh_lod/lod_change/threshold_pixels</c> project setting.</para>
    /// <para><b>Note:</b> <see cref="Viewport.MeshLodThreshold" /> does not affect <see cref="GeometryInstance3D" /> visibility ranges (also known as "manual" LOD or hierarchical LOD).</para>
    /// </summary>
    public float MeshLodThreshold { get => _node.MeshLodThreshold; set => _node.MeshLodThreshold = value; }
    /// <summary>
    /// <para>The multisample anti-aliasing mode for 2D/Canvas rendering. A higher number results in smoother edges at the cost of significantly worse performance. A value of 2 or 4 is best unless targeting very high-end systems. This has no effect on shader-induced aliasing or texture aliasing.</para>
    /// </summary>
    public Viewport.Msaa Msaa2D { get => _node.Msaa2D; set => _node.Msaa2D = value; }
    /// <summary>
    /// <para>The multisample anti-aliasing mode for 3D rendering. A higher number results in smoother edges at the cost of significantly worse performance. A value of 2 or 4 is best unless targeting very high-end systems. See also bilinear scaling 3d <see cref="Viewport.Scaling3DMode" /> for supersampling, which provides higher quality but is much more expensive. This has no effect on shader-induced aliasing or texture aliasing.</para>
    /// </summary>
    public Viewport.Msaa Msaa3D { get => _node.Msaa3D; set => _node.Msaa3D = value; }
    /// <summary>
    /// <para>If <c>true</c>, the viewport will use a unique copy of the <see cref="World3D" /> defined in <see cref="Viewport.World3D" />.</para>
    /// </summary>
    public bool OwnWorld3D { get => _node.OwnWorld3D; set => _node.OwnWorld3D = value; }
    /// <summary>
    /// <para>If <c>true</c>, the objects rendered by viewport become subjects of mouse picking process.</para>
    /// <para><b>Note:</b> The number of simultaneously pickable objects is limited to 64 and they are selected in a non-deterministic order, which can be different in each picking process.</para>
    /// </summary>
    public bool PhysicsObjectPicking { get => _node.PhysicsObjectPicking; set => _node.PhysicsObjectPicking = value; }
    /// <summary>
    /// <para>If <c>true</c>, objects receive mouse picking events sorted primarily by their <see cref="CanvasItem.ZIndex" /> and secondarily by their position in the scene tree. If <c>false</c>, the order is undetermined.</para>
    /// <para><b>Note:</b> This setting is disabled by default because of its potential expensive computational cost.</para>
    /// <para><b>Note:</b> Sorting happens after selecting the pickable objects. Because of the limitation of 64 simultaneously pickable objects, it is not guaranteed that the object with the highest <see cref="CanvasItem.ZIndex" /> receives the picking event.</para>
    /// </summary>
    public bool PhysicsObjectPickingSort { get => _node.PhysicsObjectPickingSort; set => _node.PhysicsObjectPickingSort = value; }
    /// <summary>
    /// <para>Use 16 bits for the omni/spot shadow depth map. Enabling this results in shadows having less precision and may result in shadow acne, but can lead to performance improvements on some devices.</para>
    /// </summary>
    public bool PositionalShadowAtlas16Bits { get => _node.PositionalShadowAtlas16Bits; set => _node.PositionalShadowAtlas16Bits = value; }
    /// <summary>
    /// <para>The subdivision amount of the first quadrant on the shadow atlas.</para>
    /// </summary>
    public Viewport.PositionalShadowAtlasQuadrantSubdiv PositionalShadowAtlasQuad0 { get => _node.PositionalShadowAtlasQuad0; set => _node.PositionalShadowAtlasQuad0 = value; }
    /// <summary>
    /// <para>The subdivision amount of the second quadrant on the shadow atlas.</para>
    /// </summary>
    public Viewport.PositionalShadowAtlasQuadrantSubdiv PositionalShadowAtlasQuad1 { get => _node.PositionalShadowAtlasQuad1; set => _node.PositionalShadowAtlasQuad1 = value; }
    /// <summary>
    /// <para>The subdivision amount of the third quadrant on the shadow atlas.</para>
    /// </summary>
    public Viewport.PositionalShadowAtlasQuadrantSubdiv PositionalShadowAtlasQuad2 { get => _node.PositionalShadowAtlasQuad2; set => _node.PositionalShadowAtlasQuad2 = value; }
    /// <summary>
    /// <para>The subdivision amount of the fourth quadrant on the shadow atlas.</para>
    /// </summary>
    public Viewport.PositionalShadowAtlasQuadrantSubdiv PositionalShadowAtlasQuad3 { get => _node.PositionalShadowAtlasQuad3; set => _node.PositionalShadowAtlasQuad3 = value; }
    /// <summary>
    /// <para>The shadow atlas' resolution (used for omni and spot lights). The value is rounded up to the nearest power of 2.</para>
    /// <para><b>Note:</b> If this is set to <c>0</c>, no positional shadows will be visible at all. This can improve performance significantly on low-end systems by reducing both the CPU and GPU load (as fewer draw calls are needed to draw the scene without shadows).</para>
    /// </summary>
    public int PositionalShadowAtlasSize { get => _node.PositionalShadowAtlasSize; set => _node.PositionalShadowAtlasSize = value; }
    /// <summary>
    /// <para>Triggers the given <paramref name="event" /> in this <see cref="Viewport" />. This can be used to pass an <see cref="InputEvent" /> between viewports, or to locally apply inputs that were sent over the network or saved to a file.</para>
    /// <para>If <paramref name="inLocalCoords" /> is <c>false</c>, the event's position is in the embedder's coordinates and will be converted to viewport coordinates. If <paramref name="inLocalCoords" /> is <c>true</c>, the event's position is in viewport coordinates.</para>
    /// <para>While this method serves a similar purpose as <see cref="Input.ParseInputEvent(Godot.InputEvent)" />, it does not remap the specified <paramref name="event" /> based on project settings like <c>ProjectSettings.input_devices/pointing/emulate_touch_from_mouse</c>.</para>
    /// <para>Calling this method will propagate calls to child nodes for following methods in the given order:</para>
    /// <para>- <see cref="Node._Input(Godot.InputEvent)" /></para>
    /// <para>- <see cref="Control._GuiInput(Godot.InputEvent)" /> for <see cref="Control" /> nodes</para>
    /// <para>- <see cref="Node._ShortcutInput(Godot.InputEvent)" /></para>
    /// <para>- <see cref="Node._UnhandledKeyInput(Godot.InputEvent)" /></para>
    /// <para>- <see cref="Node._UnhandledInput(Godot.InputEvent)" /></para>
    /// <para>If an earlier method marks the input as handled via <see cref="Viewport.SetInputAsHandled" />, any later method in this list will not be called.</para>
    /// <para>If none of the methods handle the event and <see cref="Viewport.PhysicsObjectPicking" /> is <c>true</c>, the event is used for physics object picking.</para>
    /// </summary>
    public void PushInput(InputEvent @event, bool inLocalCoords) => _node.PushInput(@event, inLocalCoords);
    /// <summary>
    /// <para>Helper method which calls the <c>set_text()</c> method on the currently focused <see cref="Control" />, provided that it is defined (e.g. if the focused Control is <see cref="Button" /> or <see cref="LineEdit" />).</para>
    /// </summary>
    public void PushTextInput(string text) => _node.PushTextInput(text);
    /// <summary>
    /// <para>Triggers the given <see cref="InputEvent" /> in this <see cref="Viewport" />. This can be used to pass input events between viewports, or to locally apply inputs that were sent over the network or saved to a file.</para>
    /// <para>If <paramref name="inLocalCoords" /> is <c>false</c>, the event's position is in the embedder's coordinates and will be converted to viewport coordinates. If <paramref name="inLocalCoords" /> is <c>true</c>, the event's position is in viewport coordinates.</para>
    /// <para>While this method serves a similar purpose as <see cref="Input.ParseInputEvent(Godot.InputEvent)" />, it does not remap the specified <paramref name="event" /> based on project settings like <c>ProjectSettings.input_devices/pointing/emulate_touch_from_mouse</c>.</para>
    /// <para>Calling this method will propagate calls to child nodes for following methods in the given order:</para>
    /// <para>- <see cref="Node._ShortcutInput(Godot.InputEvent)" /></para>
    /// <para>- <see cref="Node._UnhandledKeyInput(Godot.InputEvent)" /></para>
    /// <para>- <see cref="Node._UnhandledInput(Godot.InputEvent)" /></para>
    /// <para>If an earlier method marks the input as handled via <see cref="Viewport.SetInputAsHandled" />, any later method in this list will not be called.</para>
    /// <para>If none of the methods handle the event and <see cref="Viewport.PhysicsObjectPicking" /> is <c>true</c>, the event is used for physics object picking.</para>
    /// <para><b>Note:</b> This method doesn't propagate input events to embedded <see cref="Window" />s or <see cref="SubViewport" />s.</para>
    /// <para><i>Deprecated.</i> Use <see cref="Viewport.PushInput(Godot.InputEvent,System.Boolean)" /> instead.</para>
    /// </summary>
    public void PushUnhandledInput(InputEvent @event, bool inLocalCoords) => _node.PushUnhandledInput(@event, inLocalCoords);
    /// <summary>
    /// <para>Sets scaling 3d mode. Bilinear scaling renders at different resolution to either undersample or supersample the viewport. FidelityFX Super Resolution 1.0, abbreviated to FSR, is an upscaling technology that produces high quality images at fast framerates by using a spatially aware upscaling algorithm. FSR is slightly more expensive than bilinear, but it produces significantly higher image quality. FSR should be used where possible.</para>
    /// <para>To control this property on the root viewport, set the <c>ProjectSettings.rendering/scaling_3d/mode</c> project setting.</para>
    /// </summary>
    public Viewport.Scaling3DModeEnum Scaling3DMode { get => _node.Scaling3DMode; set => _node.Scaling3DMode = value; }
    /// <summary>
    /// <para>Scales the 3D render buffer based on the viewport size uses an image filter specified in <c>ProjectSettings.rendering/scaling_3d/mode</c> to scale the output image to the full viewport size. Values lower than <c>1.0</c> can be used to speed up 3D rendering at the cost of quality (undersampling). Values greater than <c>1.0</c> are only valid for bilinear mode and can be used to improve 3D rendering quality at a high performance cost (supersampling). See also <c>ProjectSettings.rendering/anti_aliasing/quality/msaa_3d</c> for multi-sample antialiasing, which is significantly cheaper but only smooths the edges of polygons.</para>
    /// <para>When using FSR upscaling, AMD recommends exposing the following values as preset options to users "Ultra Quality: 0.77", "Quality: 0.67", "Balanced: 0.59", "Performance: 0.5" instead of exposing the entire scale.</para>
    /// <para>To control this property on the root viewport, set the <c>ProjectSettings.rendering/scaling_3d/scale</c> project setting.</para>
    /// </summary>
    public float Scaling3DScale { get => _node.Scaling3DScale; set => _node.Scaling3DScale = value; }
    /// <summary>
    /// <para>Sets the screen-space antialiasing method used. Screen-space antialiasing works by selectively blurring edges in a post-process shader. It differs from MSAA which takes multiple coverage samples while rendering objects. Screen-space AA methods are typically faster than MSAA and will smooth out specular aliasing, but tend to make scenes appear blurry.</para>
    /// </summary>
    public Viewport.ScreenSpaceAAEnum ScreenSpaceAA { get => _node.ScreenSpaceAA; set => _node.ScreenSpaceAA = value; }

    public Viewport.SdfOversizeEnum SdfOversize { get => _node.SdfOversize; set => _node.SdfOversize = value; }

    public Viewport.SdfScaleEnum SdfScale { get => _node.SdfScale; set => _node.SdfScale = value; }
    /// <summary>
    /// <para>Set/clear individual bits on the rendering layer mask. This simplifies editing this <see cref="Viewport" />'s layers.</para>
    /// </summary>
    public void SetCanvasCullMaskBit(uint layer, bool enable) => _node.SetCanvasCullMaskBit(layer, enable);
    /// <summary>
    /// <para>Stops the input from propagating further down the <see cref="SceneTree" />.</para>
    /// <para><b>Note:</b> This does not affect the methods in <see cref="Input" />, only the way events are propagated.</para>
    /// </summary>
    public void SetInputAsHandled() => _node.SetInputAsHandled();

    public bool Snap2DTransformsToPixel { get => _node.Snap2DTransformsToPixel; set => _node.Snap2DTransformsToPixel = value; }

    public bool Snap2DVerticesToPixel { get => _node.Snap2DVerticesToPixel; set => _node.Snap2DVerticesToPixel = value; }
    /// <summary>
    /// <para>Affects the final texture sharpness by reading from a lower or higher mipmap (also called "texture LOD bias"). Negative values make mipmapped textures sharper but grainier when viewed at a distance, while positive values make mipmapped textures blurrier (even when up close).</para>
    /// <para>Enabling temporal antialiasing (<see cref="Viewport.UseTaa" />) will automatically apply a <c>-0.5</c> offset to this value, while enabling FXAA (<see cref="Viewport.ScreenSpaceAA" />) will automatically apply a <c>-0.25</c> offset to this value. If both TAA and FXAA are enabled at the same time, an offset of <c>-0.75</c> is applied to this value.</para>
    /// <para><b>Note:</b> If <see cref="Viewport.Scaling3DScale" /> is lower than <c>1.0</c> (exclusive), <see cref="Viewport.TextureMipmapBias" /> is used to adjust the automatic mipmap bias which is calculated internally based on the scale factor. The formula for this is <c>log2(scaling_3d_scale) + mipmap_bias</c>.</para>
    /// <para>To control this property on the root viewport, set the <c>ProjectSettings.rendering/textures/default_filters/texture_mipmap_bias</c> project setting.</para>
    /// </summary>
    public float TextureMipmapBias { get => _node.TextureMipmapBias; set => _node.TextureMipmapBias = value; }
    /// <summary>
    /// <para>If <c>true</c>, the viewport should render its background as transparent.</para>
    /// </summary>
    public bool TransparentBg { get => _node.TransparentBg; set => _node.TransparentBg = value; }
    /// <summary>
    /// <para>Force instantly updating the display based on the current mouse cursor position. This includes updating the mouse cursor shape and sending necessary <see cref="Control.MouseEntered" />, <see cref="CollisionObject2D.MouseEntered" />, <see cref="CollisionObject3D.MouseEntered" /> and <see cref="Window.MouseEntered" /> signals and their respective <c>mouse_exited</c> counterparts.</para>
    /// </summary>
    public void UpdateMouseCursorState() => _node.UpdateMouseCursorState();
    /// <summary>
    /// <para>If <c>true</c>, uses a fast post-processing filter to make banding significantly less visible in 3D. 2D rendering is <i>not</i> affected by debanding unless the <see cref="Environment.BackgroundMode" /> is <see cref="Environment.BGMode.Canvas" />. See also <c>ProjectSettings.rendering/anti_aliasing/quality/use_debanding</c>.</para>
    /// <para>In some cases, debanding may introduce a slightly noticeable dithering pattern. It's recommended to enable debanding only when actually needed since the dithering pattern will make lossless-compressed screenshots larger.</para>
    /// </summary>
    public bool UseDebanding { get => _node.UseDebanding; set => _node.UseDebanding = value; }
    /// <summary>
    /// <para>If <c>true</c>, 2D rendering will use an high dynamic range (HDR) format framebuffer matching the bit depth of the 3D framebuffer. When using the Forward+ renderer this will be a <c>RGBA16</c> framebuffer, while when using the Mobile renderer it will be a <c>RGB10_A2</c> framebuffer. Additionally, 2D rendering will take place in linear color space and will be converted to sRGB space immediately before blitting to the screen (if the Viewport is attached to the screen). Practically speaking, this means that the end result of the Viewport will not be clamped into the <c>0-1</c> range and can be used in 3D rendering without color space adjustments. This allows 2D rendering to take advantage of effects requiring high dynamic range (e.g. 2D glow) as well as substantially improves the appearance of effects requiring highly detailed gradients.</para>
    /// <para><b>Note:</b> This setting will have no effect when using the GL Compatibility renderer as the GL Compatibility renderer always renders in low dynamic range for performance reasons.</para>
    /// </summary>
    public bool UseHdr2D { get => _node.UseHdr2D; set => _node.UseHdr2D = value; }
    /// <summary>
    /// <para>If <c>true</c>, <see cref="OccluderInstance3D" /> nodes will be usable for occlusion culling in 3D for this viewport. For the root viewport, <c>ProjectSettings.rendering/occlusion_culling/use_occlusion_culling</c> must be set to <c>true</c> instead.</para>
    /// <para><b>Note:</b> Enabling occlusion culling has a cost on the CPU. Only enable occlusion culling if you actually plan to use it, and think whether your scene can actually benefit from occlusion culling. Large, open scenes with few or no objects blocking the view will generally not benefit much from occlusion culling. Large open scenes generally benefit more from mesh LOD and visibility ranges (<see cref="GeometryInstance3D.VisibilityRangeBegin" /> and <see cref="GeometryInstance3D.VisibilityRangeEnd" />) compared to occlusion culling.</para>
    /// <para><b>Note:</b> Due to memory constraints, occlusion culling is not supported by default in Web export templates. It can be enabled by compiling custom Web export templates with <c>module_raycast_enabled=yes</c>.</para>
    /// </summary>
    public bool UseOcclusionCulling { get => _node.UseOcclusionCulling; set => _node.UseOcclusionCulling = value; }
    /// <summary>
    /// <para>Enables Temporal Anti-Aliasing for this viewport. TAA works by jittering the camera and accumulating the images of the last rendered frames, motion vector rendering is used to account for camera and object motion.</para>
    /// <para><b>Note:</b> The implementation is not complete yet, some visual instances such as particles and skinned meshes may show artifacts.</para>
    /// </summary>
    public bool UseTaa { get => _node.UseTaa; set => _node.UseTaa = value; }
    /// <summary>
    /// <para>If <c>true</c>, the viewport will use the primary XR interface to render XR output. When applicable this can result in a stereoscopic image and the resulting render being output to a headset.</para>
    /// </summary>
    public bool UseXR { get => _node.UseXR; set => _node.UseXR = value; }
    /// <summary>
    /// <para>The Variable Rate Shading (VRS) mode that is used for this viewport. Note, if hardware does not support VRS this property is ignored.</para>
    /// </summary>
    public Viewport.VrsModeEnum VrsMode { get => _node.VrsMode; set => _node.VrsMode = value; }
    /// <summary>
    /// <para>Texture to use when <see cref="Viewport.VrsMode" /> is set to <see cref="Viewport.VrsModeEnum.Texture" />.</para>
    /// <para>The texture <i>must</i> use a lossless compression format so that colors can be matched precisely. The following VRS densities are mapped to various colors, with brighter colors representing a lower level of shading precision:</para>
    /// <para><code>
    /// - 1x1 = rgb(0, 0, 0)     - #000000
    /// - 1x2 = rgb(0, 85, 0)    - #005500
    /// - 2x1 = rgb(85, 0, 0)    - #550000
    /// - 2x2 = rgb(85, 85, 0)   - #555500
    /// - 2x4 = rgb(85, 170, 0)  - #55aa00
    /// - 4x2 = rgb(170, 85, 0)  - #aa5500
    /// - 4x4 = rgb(170, 170, 0) - #aaaa00
    /// - 4x8 = rgb(170, 255, 0) - #aaff00 - Not supported on most hardware
    /// - 8x4 = rgb(255, 170, 0) - #ffaa00 - Not supported on most hardware
    /// - 8x8 = rgb(255, 255, 0) - #ffff00 - Not supported on most hardware
    /// </code></para>
    /// </summary>
    public Texture2D VrsTexture { get => _node.VrsTexture; set => _node.VrsTexture = value; }
    /// <summary>
    /// <para>Moves the mouse pointer to the specified position in this <see cref="Viewport" /> using the coordinate system of this <see cref="Viewport" />.</para>
    /// <para><b>Note:</b> <see cref="Viewport.WarpMouse(Godot.Vector2)" /> is only supported on Windows, macOS and Linux. It has no effect on Android, iOS and Web.</para>
    /// </summary>
    public void WarpMouse(Vector2 position) => _node.WarpMouse(position);
    /// <summary>
    /// <para>The custom <see cref="World2D" /> which can be used as 2D environment source.</para>
    /// </summary>
    public World2D World2D { get => _node.World2D; set => _node.World2D = value; }
    /// <summary>
    /// <para>The custom <see cref="World3D" /> which can be used as 3D environment source.</para>
    /// </summary>
    public World3D World3D { get => _node.World3D; set => _node.World3D = value; }

}