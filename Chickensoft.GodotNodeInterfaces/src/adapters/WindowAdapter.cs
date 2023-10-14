namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A node that creates a window. The window can either be a native system window or embedded inside another <see cref="Window" /> (see <see cref="Viewport.GuiEmbedSubwindows" />).</para>
/// <para>At runtime, <see cref="Window" />s will not close automatically when requested. You need to handle it manually using the <see cref="Window.CloseRequested" /> signal (this applies both to pressing the close button and clicking outside of a popup).</para>
/// </summary>
public class WindowAdapter : Window, IWindow {
  private readonly Window _node;

  public WindowAdapter(Window node) => _node = node;
    /// <summary>
    /// <para>Virtual method to be implemented by the user. Overrides the value returned by <see cref="Window.GetContentsMinimumSize" />.</para>
    /// </summary>
    public Vector2 _GetContentsMinimumSize() => _node._GetContentsMinimumSize();
    /// <summary>
    /// <para>Creates a local override for a theme <see cref="Color" /> with the specified <paramref name="name" />. Local overrides always take precedence when fetching theme items for the control. An override can be removed with <see cref="Window.RemoveThemeColorOverride(Godot.StringName)" />.</para>
    /// <para>See also <see cref="Window.GetThemeColor(Godot.StringName,Godot.StringName)" /> and <see cref="Control.AddThemeColorOverride(Godot.StringName,Godot.Color)" /> for more details.</para>
    /// </summary>
    public void AddThemeColorOverride(StringName name, Color color) => _node.AddThemeColorOverride(name, color);
    /// <summary>
    /// <para>Creates a local override for a theme constant with the specified <paramref name="name" />. Local overrides always take precedence when fetching theme items for the control. An override can be removed with <see cref="Window.RemoveThemeConstantOverride(Godot.StringName)" />.</para>
    /// <para>See also <see cref="Window.GetThemeConstant(Godot.StringName,Godot.StringName)" />.</para>
    /// </summary>
    public void AddThemeConstantOverride(StringName name, int constant) => _node.AddThemeConstantOverride(name, constant);
    /// <summary>
    /// <para>Creates a local override for a theme <see cref="Font" /> with the specified <paramref name="name" />. Local overrides always take precedence when fetching theme items for the control. An override can be removed with <see cref="Window.RemoveThemeFontOverride(Godot.StringName)" />.</para>
    /// <para>See also <see cref="Window.GetThemeFont(Godot.StringName,Godot.StringName)" />.</para>
    /// </summary>
    public void AddThemeFontOverride(StringName name, Font font) => _node.AddThemeFontOverride(name, font);
    /// <summary>
    /// <para>Creates a local override for a theme font size with the specified <paramref name="name" />. Local overrides always take precedence when fetching theme items for the control. An override can be removed with <see cref="Window.RemoveThemeFontSizeOverride(Godot.StringName)" />.</para>
    /// <para>See also <see cref="Window.GetThemeFontSize(Godot.StringName,Godot.StringName)" />.</para>
    /// </summary>
    public void AddThemeFontSizeOverride(StringName name, int fontSize) => _node.AddThemeFontSizeOverride(name, fontSize);
    /// <summary>
    /// <para>Creates a local override for a theme icon with the specified <paramref name="name" />. Local overrides always take precedence when fetching theme items for the control. An override can be removed with <see cref="Window.RemoveThemeIconOverride(Godot.StringName)" />.</para>
    /// <para>See also <see cref="Window.GetThemeIcon(Godot.StringName,Godot.StringName)" />.</para>
    /// </summary>
    public void AddThemeIconOverride(StringName name, Texture2D texture) => _node.AddThemeIconOverride(name, texture);
    /// <summary>
    /// <para>Creates a local override for a theme <see cref="StyleBox" /> with the specified <paramref name="name" />. Local overrides always take precedence when fetching theme items for the control. An override can be removed with <see cref="Window.RemoveThemeStyleboxOverride(Godot.StringName)" />.</para>
    /// <para>See also <see cref="Window.GetThemeStylebox(Godot.StringName,Godot.StringName)" /> and <see cref="Control.AddThemeStyleboxOverride(Godot.StringName,Godot.StyleBox)" /> for more details.</para>
    /// </summary>
    public void AddThemeStyleboxOverride(StringName name, StyleBox stylebox) => _node.AddThemeStyleboxOverride(name, stylebox);
    /// <summary>
    /// <para>If <c>true</c>, the window will be on top of all other windows. Does not work if <see cref="Window.Transient" /> is enabled.</para>
    /// </summary>
    public bool AlwaysOnTop { get => _node.AlwaysOnTop; set => _node.AlwaysOnTop = value; }
    /// <summary>
    /// <para>Toggles if any text should automatically change to its translated version depending on the current locale.</para>
    /// </summary>
    public bool AutoTranslate { get => _node.AutoTranslate; set => _node.AutoTranslate = value; }
    /// <summary>
    /// <para>Prevents <c>*_theme_*_override</c> methods from emitting <see cref="Window.NotificationThemeChanged" /> until <see cref="Window.EndBulkThemeOverride" /> is called.</para>
    /// </summary>
    public void BeginBulkThemeOverride() => _node.BeginBulkThemeOverride();
    /// <summary>
    /// <para>If <c>true</c>, the window will have no borders.</para>
    /// </summary>
    public bool Borderless { get => _node.Borderless; set => _node.Borderless = value; }
    /// <summary>
    /// <para>Returns whether the window is being drawn to the screen.</para>
    /// </summary>
    public bool CanDraw() => _node.CanDraw();
    /// <summary>
    /// <para>Requests an update of the <see cref="Window" /> size to fit underlying <see cref="Control" /> nodes.</para>
    /// </summary>
    public void ChildControlsChanged() => _node.ChildControlsChanged();
    /// <summary>
    /// <para>Specifies how the content's aspect behaves when the <see cref="Window" /> is resized. The base aspect is determined by <see cref="Window.ContentScaleSize" />.</para>
    /// </summary>
    public Window.ContentScaleAspectEnum ContentScaleAspect { get => _node.ContentScaleAspect; set => _node.ContentScaleAspect = value; }
    /// <summary>
    /// <para>Specifies the base scale of <see cref="Window" />'s content when its <see cref="Window.Size" /> is equal to <see cref="Window.ContentScaleSize" />.</para>
    /// </summary>
    public float ContentScaleFactor { get => _node.ContentScaleFactor; set => _node.ContentScaleFactor = value; }
    /// <summary>
    /// <para>Specifies how the content is scaled when the <see cref="Window" /> is resized.</para>
    /// </summary>
    public Window.ContentScaleModeEnum ContentScaleMode { get => _node.ContentScaleMode; set => _node.ContentScaleMode = value; }
    /// <summary>
    /// <para>Base size of the content (i.e. nodes that are drawn inside the window). If non-zero, <see cref="Window" />'s content will be scaled when the window is resized to a different size.</para>
    /// </summary>
    public Vector2I ContentScaleSize { get => _node.ContentScaleSize; set => _node.ContentScaleSize = value; }
    /// <summary>
    /// <para>The policy to use to determine the final scale factor for 2D elements. This affects how <see cref="Window.ContentScaleFactor" /> is applied, in addition to the automatic scale factor determined by <see cref="Window.ContentScaleSize" />.</para>
    /// </summary>
    public Window.ContentScaleStretchEnum ContentScaleStretch { get => _node.ContentScaleStretch; set => _node.ContentScaleStretch = value; }
    /// <summary>
    /// <para>The screen the window is currently on.</para>
    /// </summary>
    public int CurrentScreen { get => _node.CurrentScreen; set => _node.CurrentScreen = value; }
    /// <summary>
    /// <para>Ends a bulk theme override update. See <see cref="Window.BeginBulkThemeOverride" />.</para>
    /// </summary>
    public void EndBulkThemeOverride() => _node.EndBulkThemeOverride();
    /// <summary>
    /// <para>If <c>true</c>, the <see cref="Window" /> will be in exclusive mode. Exclusive windows are always on top of their parent and will block all input going to the parent <see cref="Window" />.</para>
    /// <para>Needs <see cref="Window.Transient" /> enabled to work.</para>
    /// </summary>
    public bool Exclusive { get => _node.Exclusive; set => _node.Exclusive = value; }
    /// <summary>
    /// <para>If <c>true</c>, the <see cref="Window" /> contents is expanded to the full size of the window, window title bar is transparent.</para>
    /// <para><b>Note:</b> This property is implemented only on macOS.</para>
    /// <para><b>Note:</b> This property only works with native windows.</para>
    /// </summary>
    public bool ExtendToTitle { get => _node.ExtendToTitle; set => _node.ExtendToTitle = value; }
    /// <summary>
    /// <para>Returns the combined minimum size from the child <see cref="Control" /> nodes of the window. Use <see cref="Window.ChildControlsChanged" /> to update it when children nodes have changed.</para>
    /// <para>The value returned by this method can be overridden with <see cref="Window._GetContentsMinimumSize" />.</para>
    /// </summary>
    public Vector2 GetContentsMinimumSize() => _node.GetContentsMinimumSize();
    /// <summary>
    /// <para>Returns layout direction and text writing direction.</para>
    /// </summary>
    public Window.LayoutDirection GetLayoutDirection() => _node.GetLayoutDirection();
    /// <summary>
    /// <para>Returns the window's position including its border.</para>
    /// </summary>
    public Vector2I GetPositionWithDecorations() => _node.GetPositionWithDecorations();
    /// <summary>
    /// <para>Returns the window's size including its border.</para>
    /// </summary>
    public Vector2I GetSizeWithDecorations() => _node.GetSizeWithDecorations();
    /// <summary>
    /// <para>Returns a <see cref="Color" /> from the first matching <see cref="Theme" /> in the tree if that <see cref="Theme" /> has a color item with the specified <paramref name="name" /> and <paramref name="themeType" />.</para>
    /// <para>See <see cref="Control.GetThemeColor(Godot.StringName,Godot.StringName)" /> for more details.</para>
    /// </summary>
    public Color GetThemeColor(StringName name, StringName themeType) => _node.GetThemeColor(name, themeType);
    /// <summary>
    /// <para>Returns a constant from the first matching <see cref="Theme" /> in the tree if that <see cref="Theme" /> has a constant item with the specified <paramref name="name" /> and <paramref name="themeType" />.</para>
    /// <para>See <see cref="Control.GetThemeColor(Godot.StringName,Godot.StringName)" /> for more details.</para>
    /// </summary>
    public int GetThemeConstant(StringName name, StringName themeType) => _node.GetThemeConstant(name, themeType);
    /// <summary>
    /// <para>Returns the default base scale value from the first matching <see cref="Theme" /> in the tree if that <see cref="Theme" /> has a valid <see cref="Theme.DefaultBaseScale" /> value.</para>
    /// <para>See <see cref="Control.GetThemeColor(Godot.StringName,Godot.StringName)" /> for details.</para>
    /// </summary>
    public float GetThemeDefaultBaseScale() => _node.GetThemeDefaultBaseScale();
    /// <summary>
    /// <para>Returns the default font from the first matching <see cref="Theme" /> in the tree if that <see cref="Theme" /> has a valid <see cref="Theme.DefaultFont" /> value.</para>
    /// <para>See <see cref="Control.GetThemeColor(Godot.StringName,Godot.StringName)" /> for details.</para>
    /// </summary>
    public Font GetThemeDefaultFont() => _node.GetThemeDefaultFont();
    /// <summary>
    /// <para>Returns the default font size value from the first matching <see cref="Theme" /> in the tree if that <see cref="Theme" /> has a valid <see cref="Theme.DefaultFontSize" /> value.</para>
    /// <para>See <see cref="Control.GetThemeColor(Godot.StringName,Godot.StringName)" /> for details.</para>
    /// </summary>
    public int GetThemeDefaultFontSize() => _node.GetThemeDefaultFontSize();
    /// <summary>
    /// <para>Returns a <see cref="Font" /> from the first matching <see cref="Theme" /> in the tree if that <see cref="Theme" /> has a font item with the specified <paramref name="name" /> and <paramref name="themeType" />.</para>
    /// <para>See <see cref="Control.GetThemeColor(Godot.StringName,Godot.StringName)" /> for details.</para>
    /// </summary>
    public Font GetThemeFont(StringName name, StringName themeType) => _node.GetThemeFont(name, themeType);
    /// <summary>
    /// <para>Returns a font size from the first matching <see cref="Theme" /> in the tree if that <see cref="Theme" /> has a font size item with the specified <paramref name="name" /> and <paramref name="themeType" />.</para>
    /// <para>See <see cref="Control.GetThemeColor(Godot.StringName,Godot.StringName)" /> for details.</para>
    /// </summary>
    public int GetThemeFontSize(StringName name, StringName themeType) => _node.GetThemeFontSize(name, themeType);
    /// <summary>
    /// <para>Returns an icon from the first matching <see cref="Theme" /> in the tree if that <see cref="Theme" /> has an icon item with the specified <paramref name="name" /> and <paramref name="themeType" />.</para>
    /// <para>See <see cref="Control.GetThemeColor(Godot.StringName,Godot.StringName)" /> for details.</para>
    /// </summary>
    public Texture2D GetThemeIcon(StringName name, StringName themeType) => _node.GetThemeIcon(name, themeType);
    /// <summary>
    /// <para>Returns a <see cref="StyleBox" /> from the first matching <see cref="Theme" /> in the tree if that <see cref="Theme" /> has a stylebox item with the specified <paramref name="name" /> and <paramref name="themeType" />.</para>
    /// <para>See <see cref="Control.GetThemeColor(Godot.StringName,Godot.StringName)" /> for details.</para>
    /// </summary>
    public StyleBox GetThemeStylebox(StringName name, StringName themeType) => _node.GetThemeStylebox(name, themeType);
    /// <summary>
    /// <para>Returns the ID of the window.</para>
    /// </summary>
    public int GetWindowId() => _node.GetWindowId();
    /// <summary>
    /// <para>Causes the window to grab focus, allowing it to receive user input.</para>
    /// </summary>
    public void GrabFocus() => _node.GrabFocus();
    /// <summary>
    /// <para>Returns <c>true</c> if the window is focused.</para>
    /// </summary>
    public bool HasFocus() => _node.HasFocus();
    /// <summary>
    /// <para>Returns <c>true</c> if there is a matching <see cref="Theme" /> in the tree that has a color item with the specified <paramref name="name" /> and <paramref name="themeType" />.</para>
    /// <para>See <see cref="Control.GetThemeColor(Godot.StringName,Godot.StringName)" /> for details.</para>
    /// </summary>
    public bool HasThemeColor(StringName name, StringName themeType) => _node.HasThemeColor(name, themeType);
    /// <summary>
    /// <para>Returns <c>true</c> if there is a local override for a theme <see cref="Color" /> with the specified <paramref name="name" /> in this <see cref="Control" /> node.</para>
    /// <para>See <see cref="Window.AddThemeColorOverride(Godot.StringName,Godot.Color)" />.</para>
    /// </summary>
    public bool HasThemeColorOverride(StringName name) => _node.HasThemeColorOverride(name);
    /// <summary>
    /// <para>Returns <c>true</c> if there is a matching <see cref="Theme" /> in the tree that has a constant item with the specified <paramref name="name" /> and <paramref name="themeType" />.</para>
    /// <para>See <see cref="Control.GetThemeColor(Godot.StringName,Godot.StringName)" /> for details.</para>
    /// </summary>
    public bool HasThemeConstant(StringName name, StringName themeType) => _node.HasThemeConstant(name, themeType);
    /// <summary>
    /// <para>Returns <c>true</c> if there is a local override for a theme constant with the specified <paramref name="name" /> in this <see cref="Control" /> node.</para>
    /// <para>See <see cref="Window.AddThemeConstantOverride(Godot.StringName,System.Int32)" />.</para>
    /// </summary>
    public bool HasThemeConstantOverride(StringName name) => _node.HasThemeConstantOverride(name);
    /// <summary>
    /// <para>Returns <c>true</c> if there is a matching <see cref="Theme" /> in the tree that has a font item with the specified <paramref name="name" /> and <paramref name="themeType" />.</para>
    /// <para>See <see cref="Control.GetThemeColor(Godot.StringName,Godot.StringName)" /> for details.</para>
    /// </summary>
    public bool HasThemeFont(StringName name, StringName themeType) => _node.HasThemeFont(name, themeType);
    /// <summary>
    /// <para>Returns <c>true</c> if there is a local override for a theme <see cref="Font" /> with the specified <paramref name="name" /> in this <see cref="Control" /> node.</para>
    /// <para>See <see cref="Window.AddThemeFontOverride(Godot.StringName,Godot.Font)" />.</para>
    /// </summary>
    public bool HasThemeFontOverride(StringName name) => _node.HasThemeFontOverride(name);
    /// <summary>
    /// <para>Returns <c>true</c> if there is a matching <see cref="Theme" /> in the tree that has a font size item with the specified <paramref name="name" /> and <paramref name="themeType" />.</para>
    /// <para>See <see cref="Control.GetThemeColor(Godot.StringName,Godot.StringName)" /> for details.</para>
    /// </summary>
    public bool HasThemeFontSize(StringName name, StringName themeType) => _node.HasThemeFontSize(name, themeType);
    /// <summary>
    /// <para>Returns <c>true</c> if there is a local override for a theme font size with the specified <paramref name="name" /> in this <see cref="Control" /> node.</para>
    /// <para>See <see cref="Window.AddThemeFontSizeOverride(Godot.StringName,System.Int32)" />.</para>
    /// </summary>
    public bool HasThemeFontSizeOverride(StringName name) => _node.HasThemeFontSizeOverride(name);
    /// <summary>
    /// <para>Returns <c>true</c> if there is a matching <see cref="Theme" /> in the tree that has an icon item with the specified <paramref name="name" /> and <paramref name="themeType" />.</para>
    /// <para>See <see cref="Control.GetThemeColor(Godot.StringName,Godot.StringName)" /> for details.</para>
    /// </summary>
    public bool HasThemeIcon(StringName name, StringName themeType) => _node.HasThemeIcon(name, themeType);
    /// <summary>
    /// <para>Returns <c>true</c> if there is a local override for a theme icon with the specified <paramref name="name" /> in this <see cref="Control" /> node.</para>
    /// <para>See <see cref="Window.AddThemeIconOverride(Godot.StringName,Godot.Texture2D)" />.</para>
    /// </summary>
    public bool HasThemeIconOverride(StringName name) => _node.HasThemeIconOverride(name);
    /// <summary>
    /// <para>Returns <c>true</c> if there is a matching <see cref="Theme" /> in the tree that has a stylebox item with the specified <paramref name="name" /> and <paramref name="themeType" />.</para>
    /// <para>See <see cref="Control.GetThemeColor(Godot.StringName,Godot.StringName)" /> for details.</para>
    /// </summary>
    public bool HasThemeStylebox(StringName name, StringName themeType) => _node.HasThemeStylebox(name, themeType);
    /// <summary>
    /// <para>Returns <c>true</c> if there is a local override for a theme <see cref="StyleBox" /> with the specified <paramref name="name" /> in this <see cref="Control" /> node.</para>
    /// <para>See <see cref="Window.AddThemeStyleboxOverride(Godot.StringName,Godot.StyleBox)" />.</para>
    /// </summary>
    public bool HasThemeStyleboxOverride(StringName name) => _node.HasThemeStyleboxOverride(name);
    /// <summary>
    /// <para>Hides the window. This is not the same as minimized state. Hidden window can't be interacted with and needs to be made visible with <see cref="Window.Show" />.</para>
    /// </summary>
    public void Hide() => _node.Hide();
    /// <summary>
    /// <para>Specifies the initial type of position for the <see cref="Window" />. See <see cref="Window.WindowInitialPosition" /> constants.</para>
    /// </summary>
    public Window.WindowInitialPosition InitialPosition { get => _node.InitialPosition; set => _node.InitialPosition = value; }
    /// <summary>
    /// <para>Returns <c>true</c> if the window is currently embedded in another window.</para>
    /// </summary>
    public bool IsEmbedded() => _node.IsEmbedded();
    /// <summary>
    /// <para>Returns <c>true</c> if layout is right-to-left.</para>
    /// </summary>
    public bool IsLayoutRtl() => _node.IsLayoutRtl();
    /// <summary>
    /// <para>Returns <c>true</c> if the window can be maximized (the maximize button is enabled).</para>
    /// </summary>
    public bool IsMaximizeAllowed() => _node.IsMaximizeAllowed();
    /// <summary>
    /// <para>Returns <c>true</c> if font oversampling is enabled. See <see cref="Window.SetUseFontOversampling(System.Boolean)" />.</para>
    /// </summary>
    public bool IsUsingFontOversampling() => _node.IsUsingFontOversampling();
    /// <summary>
    /// <para>If <c>true</c>, the <see cref="Window" /> width is expanded to keep the title bar text fully visible.</para>
    /// </summary>
    public bool KeepTitleVisible { get => _node.KeepTitleVisible; set => _node.KeepTitleVisible = value; }
    /// <summary>
    /// <para>If non-zero, the <see cref="Window" /> can't be resized to be bigger than this size.</para>
    /// <para><b>Note:</b> This property will be ignored if the value is lower than <see cref="Window.MinSize" />.</para>
    /// </summary>
    public Vector2I MaxSize { get => _node.MaxSize; set => _node.MaxSize = value; }
    /// <summary>
    /// <para>If non-zero, the <see cref="Window" /> can't be resized to be smaller than this size.</para>
    /// <para><b>Note:</b> This property will be ignored in favor of <see cref="Window.GetContentsMinimumSize" /> if <see cref="Window.WrapControls" /> is enabled and if its size is bigger.</para>
    /// </summary>
    public Vector2I MinSize { get => _node.MinSize; set => _node.MinSize = value; }
    /// <summary>
    /// <para>Set's the window's current mode.</para>
    /// <para><b>Note:</b> Fullscreen mode is not exclusive full screen on Windows and Linux.</para>
    /// <para><b>Note:</b> This method only works with native windows, i.e. the main window and <see cref="Window" />-derived nodes when <see cref="Viewport.GuiEmbedSubwindows" /> is disabled in the main viewport.</para>
    /// </summary>
    public Window.ModeEnum Mode { get => _node.Mode; set => _node.Mode = value; }
    /// <summary>
    /// <para>If <c>true</c>, all mouse events will be passed to the underlying window of the same application. See also <see cref="Window.MousePassthroughPolygon" />.</para>
    /// <para><b>Note:</b> This property is implemented on Linux (X11), macOS and Windows.</para>
    /// <para><b>Note:</b> This property only works with native windows.</para>
    /// </summary>
    public bool MousePassthrough { get => _node.MousePassthrough; set => _node.MousePassthrough = value; }
    /// <summary>
    /// <para>Sets a polygonal region of the window which accepts mouse events. Mouse events outside the region will be passed through.</para>
    /// <para>Passing an empty array will disable passthrough support (all mouse events will be intercepted by the window, which is the default behavior).</para>
    /// <para><code>
    /// // Set region, using Path2D node.
    /// GetNode&lt;Window&gt;("Window").MousePassthrough = GetNode&lt;Path2D&gt;("Path2D").Curve.GetBakedPoints();
    /// // Set region, using Polygon2D node.
    /// GetNode&lt;Window&gt;("Window").MousePassthrough = GetNode&lt;Polygon2D&gt;("Polygon2D").Polygon;
    /// // Reset region to default.
    /// GetNode&lt;Window&gt;("Window").MousePassthrough = new Vector2[] {};
    /// </code></para>
    /// <para><b>Note:</b> This property is ignored if <see cref="Window.MousePassthrough" /> is set to <c>true</c>.</para>
    /// <para><b>Note:</b> On Windows, the portion of a window that lies outside the region is not drawn, while on Linux (X11) and macOS it is.</para>
    /// <para><b>Note:</b> This property is implemented on Linux (X11), macOS and Windows.</para>
    /// </summary>
    public Vector2[] MousePassthroughPolygon { get => _node.MousePassthroughPolygon; set => _node.MousePassthroughPolygon = value; }
    /// <summary>
    /// <para>Centers a native window on the current screen and an embedded window on its embedder <see cref="Viewport" />.</para>
    /// </summary>
    public void MoveToCenter() => _node.MoveToCenter();
    /// <summary>
    /// <para>Moves the <see cref="Window" /> on top of other windows and focuses it.</para>
    /// </summary>
    public void MoveToForeground() => _node.MoveToForeground();
    /// <summary>
    /// <para>Shows the <see cref="Window" /> and makes it transient (see <see cref="Window.Transient" />). If <paramref name="rect" /> is provided, it will be set as the <see cref="Window" />'s size. Fails if called on the main window.</para>
    /// </summary>
    /// <param name="rect">If the parameter is null, then the default value is <c>new Rect2I(new Vector2I(0, 0), new Vector2I(0, 0))</c>.</param>
    public void Popup(Nullable<Rect2I> rect) => _node.Popup(rect);
    /// <summary>
    /// <para>Popups the <see cref="Window" /> at the center of the current screen, with optionally given minimum size. If the <see cref="Window" /> is embedded, it will be centered in the parent <see cref="Viewport" /> instead.</para>
    /// <para><b>Note:</b> Calling it with the default value of <paramref name="minsize" /> is equivalent to calling it with <see cref="Window.Size" />.</para>
    /// </summary>
    /// <param name="minsize">If the parameter is null, then the default value is <c>new Vector2I(0, 0)</c>.</param>
    public void PopupCentered(Nullable<Vector2I> minsize) => _node.PopupCentered(minsize);
    /// <summary>
    /// <para>Popups the <see cref="Window" /> centered inside its parent <see cref="Window" />. <paramref name="fallbackRatio" /> determines the maximum size of the <see cref="Window" />, in relation to its parent.</para>
    /// <para><b>Note:</b> Calling it with the default value of <paramref name="minsize" /> is equivalent to calling it with <see cref="Window.Size" />.</para>
    /// </summary>
    /// <param name="minsize">If the parameter is null, then the default value is <c>new Vector2I(0, 0)</c>.</param>
    public void PopupCenteredClamped(Nullable<Vector2I> minsize, float fallbackRatio) => _node.PopupCenteredClamped(minsize, fallbackRatio);
    /// <summary>
    /// <para>If <see cref="Window" /> is embedded, popups the <see cref="Window" /> centered inside its embedder and sets its size as a <paramref name="ratio" /> of embedder's size.</para>
    /// <para>If <see cref="Window" /> is a native window, popups the <see cref="Window" /> centered inside the screen of its parent <see cref="Window" /> and sets its size as a <paramref name="ratio" /> of the screen size.</para>
    /// </summary>
    public void PopupCenteredRatio(float ratio) => _node.PopupCenteredRatio(ratio);
    /// <summary>
    /// <para>Attempts to parent this dialog to the last exclusive window relative to <paramref name="fromNode" />, and then calls <see cref="Window.Popup(System.Nullable{Godot.Rect2I})" /> on it. The dialog must have no current parent, otherwise the method fails.</para>
    /// <para>See also <see cref="Window.SetUnparentWhenInvisible(System.Boolean)" /> and <see cref="Node.GetLastExclusiveWindow" />.</para>
    /// </summary>
    /// <param name="rect">If the parameter is null, then the default value is <c>new Rect2I(new Vector2I(0, 0), new Vector2I(0, 0))</c>.</param>
    public void PopupExclusive(Node fromNode, Nullable<Rect2I> rect) => _node.PopupExclusive(fromNode, rect);
    /// <summary>
    /// <para>Attempts to parent this dialog to the last exclusive window relative to <paramref name="fromNode" />, and then calls <see cref="Window.PopupCentered(System.Nullable{Godot.Vector2I})" /> on it. The dialog must have no current parent, otherwise the method fails.</para>
    /// <para>See also <see cref="Window.SetUnparentWhenInvisible(System.Boolean)" /> and <see cref="Node.GetLastExclusiveWindow" />.</para>
    /// </summary>
    /// <param name="minsize">If the parameter is null, then the default value is <c>new Vector2I(0, 0)</c>.</param>
    public void PopupExclusiveCentered(Node fromNode, Nullable<Vector2I> minsize) => _node.PopupExclusiveCentered(fromNode, minsize);
    /// <summary>
    /// <para>Attempts to parent this dialog to the last exclusive window relative to <paramref name="fromNode" />, and then calls <see cref="Window.PopupCenteredClamped(System.Nullable{Godot.Vector2I},System.Single)" /> on it. The dialog must have no current parent, otherwise the method fails.</para>
    /// <para>See also <see cref="Window.SetUnparentWhenInvisible(System.Boolean)" /> and <see cref="Node.GetLastExclusiveWindow" />.</para>
    /// </summary>
    /// <param name="minsize">If the parameter is null, then the default value is <c>new Vector2I(0, 0)</c>.</param>
    public void PopupExclusiveCenteredClamped(Node fromNode, Nullable<Vector2I> minsize, float fallbackRatio) => _node.PopupExclusiveCenteredClamped(fromNode, minsize, fallbackRatio);
    /// <summary>
    /// <para>Attempts to parent this dialog to the last exclusive window relative to <paramref name="fromNode" />, and then calls <see cref="Window.PopupCenteredRatio(System.Single)" /> on it. The dialog must have no current parent, otherwise the method fails.</para>
    /// <para>See also <see cref="Window.SetUnparentWhenInvisible(System.Boolean)" /> and <see cref="Node.GetLastExclusiveWindow" />.</para>
    /// </summary>
    public void PopupExclusiveCenteredRatio(Node fromNode, float ratio) => _node.PopupExclusiveCenteredRatio(fromNode, ratio);
    /// <summary>
    /// <para>Attempts to parent this dialog to the last exclusive window relative to <paramref name="fromNode" />, and then calls <see cref="Window.PopupOnParent(Godot.Rect2I)" /> on it. The dialog must have no current parent, otherwise the method fails.</para>
    /// <para>See also <see cref="Window.SetUnparentWhenInvisible(System.Boolean)" /> and <see cref="Node.GetLastExclusiveWindow" />.</para>
    /// </summary>
    public void PopupExclusiveOnParent(Node fromNode, Rect2I parentRect) => _node.PopupExclusiveOnParent(fromNode, parentRect);
    /// <summary>
    /// <para>Popups the <see cref="Window" /> with a position shifted by parent <see cref="Window" />'s position. If the <see cref="Window" /> is embedded, has the same effect as <see cref="Window.Popup(System.Nullable{Godot.Rect2I})" />.</para>
    /// </summary>
    public void PopupOnParent(Rect2I parentRect) => _node.PopupOnParent(parentRect);
    /// <summary>
    /// <para>If <c>true</c>, the <see cref="Window" /> will be considered a popup. Popups are sub-windows that don't show as separate windows in system's window manager's window list and will send close request when anything is clicked outside of them (unless <see cref="Window.Exclusive" /> is enabled).</para>
    /// </summary>
    public bool PopupWindow { get => _node.PopupWindow; set => _node.PopupWindow = value; }
    /// <summary>
    /// <para>The window's position in pixels.</para>
    /// <para>If <c>ProjectSettings.display/window/subwindows/embed_subwindows</c> is <c>false</c>, the position is in absolute screen coordinates. This typically applies to editor plugins. If the setting is <c>true</c>, the window's position is in the coordinates of its parent <see cref="Viewport" />.</para>
    /// <para><b>Note:</b> This property only works if <see cref="Window.InitialPosition" /> is set to <see cref="Window.WindowInitialPosition.Absolute" />.</para>
    /// </summary>
    public Vector2I Position { get => _node.Position; set => _node.Position = value; }
    /// <summary>
    /// <para>Removes a local override for a theme <see cref="Color" /> with the specified <paramref name="name" /> previously added by <see cref="Window.AddThemeColorOverride(Godot.StringName,Godot.Color)" /> or via the Inspector dock.</para>
    /// </summary>
    public void RemoveThemeColorOverride(StringName name) => _node.RemoveThemeColorOverride(name);
    /// <summary>
    /// <para>Removes a local override for a theme constant with the specified <paramref name="name" /> previously added by <see cref="Window.AddThemeConstantOverride(Godot.StringName,System.Int32)" /> or via the Inspector dock.</para>
    /// </summary>
    public void RemoveThemeConstantOverride(StringName name) => _node.RemoveThemeConstantOverride(name);
    /// <summary>
    /// <para>Removes a local override for a theme <see cref="Font" /> with the specified <paramref name="name" /> previously added by <see cref="Window.AddThemeFontOverride(Godot.StringName,Godot.Font)" /> or via the Inspector dock.</para>
    /// </summary>
    public void RemoveThemeFontOverride(StringName name) => _node.RemoveThemeFontOverride(name);
    /// <summary>
    /// <para>Removes a local override for a theme font size with the specified <paramref name="name" /> previously added by <see cref="Window.AddThemeFontSizeOverride(Godot.StringName,System.Int32)" /> or via the Inspector dock.</para>
    /// </summary>
    public void RemoveThemeFontSizeOverride(StringName name) => _node.RemoveThemeFontSizeOverride(name);
    /// <summary>
    /// <para>Removes a local override for a theme icon with the specified <paramref name="name" /> previously added by <see cref="Window.AddThemeIconOverride(Godot.StringName,Godot.Texture2D)" /> or via the Inspector dock.</para>
    /// </summary>
    public void RemoveThemeIconOverride(StringName name) => _node.RemoveThemeIconOverride(name);
    /// <summary>
    /// <para>Removes a local override for a theme <see cref="StyleBox" /> with the specified <paramref name="name" /> previously added by <see cref="Window.AddThemeStyleboxOverride(Godot.StringName,Godot.StyleBox)" /> or via the Inspector dock.</para>
    /// </summary>
    public void RemoveThemeStyleboxOverride(StringName name) => _node.RemoveThemeStyleboxOverride(name);
    /// <summary>
    /// <para>Tells the OS that the <see cref="Window" /> needs an attention. This makes the window stand out in some way depending on the system, e.g. it might blink on the task bar.</para>
    /// </summary>
    public void RequestAttention() => _node.RequestAttention();
    /// <summary>
    /// <para>Resets the size to the minimum size, which is the max of <see cref="Window.MinSize" /> and (if <see cref="Window.WrapControls" /> is enabled) <see cref="Window.GetContentsMinimumSize" />. This is equivalent to calling <c>set_size(Vector2i())</c> (or any size below the minimum).</para>
    /// </summary>
    public void ResetSize() => _node.ResetSize();
    /// <summary>
    /// <para>If <paramref name="active" /> is <c>true</c>, enables system's native IME (Input Method Editor).</para>
    /// </summary>
    public void SetImeActive(bool active) => _node.SetImeActive(active);
    /// <summary>
    /// <para>Moves IME to the given position.</para>
    /// </summary>
    public void SetImePosition(Vector2I position) => _node.SetImePosition(position);
    /// <summary>
    /// <para>Sets layout direction and text writing direction. Right-to-left layouts are necessary for certain languages (e.g. Arabic and Hebrew).</para>
    /// </summary>
    public void SetLayoutDirection(Window.LayoutDirection direction) => _node.SetLayoutDirection(direction);
    /// <summary>
    /// <para>If <paramref name="unparent" /> is <c>true</c>, the window is automatically unparented when going invisible.</para>
    /// <para><b>Note:</b> Make sure to keep a reference to the node, otherwise it will be orphaned. You also need to manually call <see cref="Node.QueueFree" /> to free the window if it's not parented.</para>
    /// </summary>
    public void SetUnparentWhenInvisible(bool unparent) => _node.SetUnparentWhenInvisible(unparent);
    /// <summary>
    /// <para>Enables font oversampling. This makes fonts look better when they are scaled up.</para>
    /// </summary>
    public void SetUseFontOversampling(bool enable) => _node.SetUseFontOversampling(enable);
    /// <summary>
    /// <para>Makes the <see cref="Window" /> appear. This enables interactions with the <see cref="Window" /> and doesn't change any of its property other than visibility (unlike e.g. <see cref="Window.Popup(System.Nullable{Godot.Rect2I})" />).</para>
    /// </summary>
    public void Show() => _node.Show();
    /// <summary>
    /// <para>The window's size in pixels.</para>
    /// </summary>
    public Vector2I Size { get => _node.Size; set => _node.Size = value; }
    /// <summary>
    /// <para>The <see cref="Theme" /> resource this node and all its <see cref="Control" /> and <see cref="Window" /> children use. If a child node has its own <see cref="Theme" /> resource set, theme items are merged with child's definitions having higher priority.</para>
    /// <para><b>Note:</b> <see cref="Window" /> styles will have no effect unless the window is embedded.</para>
    /// </summary>
    public Theme Theme { get => _node.Theme; set => _node.Theme = value; }
    /// <summary>
    /// <para>The name of a theme type variation used by this <see cref="Window" /> to look up its own theme items. See <see cref="Control.ThemeTypeVariation" /> for more details.</para>
    /// </summary>
    public StringName ThemeTypeVariation { get => _node.ThemeTypeVariation; set => _node.ThemeTypeVariation = value; }
    /// <summary>
    /// <para>The window's title. If the <see cref="Window" /> is native, title styles set in <see cref="Theme" /> will have no effect.</para>
    /// </summary>
    public string Title { get => _node.Title; set => _node.Title = value; }
    /// <summary>
    /// <para>If <c>true</c>, the <see cref="Window" /> is transient, i.e. it's considered a child of another <see cref="Window" />. The transient window will be destroyed with its transient parent and will return focus to their parent when closed. The transient window is displayed on top of a non-exclusive full-screen parent window. Transient windows can't enter full-screen mode.</para>
    /// <para>Note that behavior might be different depending on the platform.</para>
    /// </summary>
    public bool Transient { get => _node.Transient; set => _node.Transient = value; }
    /// <summary>
    /// <para>If <c>true</c>, the <see cref="Window" />'s background can be transparent. This is best used with embedded windows.</para>
    /// <para><b>Note:</b> Transparency support is implemented on Linux, macOS and Windows, but availability might vary depending on GPU driver, display manager, and compositor capabilities.</para>
    /// <para><b>Note:</b> This property has no effect if either <c>ProjectSettings.display/window/per_pixel_transparency/allowed</c>, or the window's <see cref="Viewport.TransparentBg" /> is set to <c>false</c>.</para>
    /// </summary>
    public bool Transparent { get => _node.Transparent; set => _node.Transparent = value; }
    /// <summary>
    /// <para>If <c>true</c>, the <see cref="Window" /> can't be focused nor interacted with. It can still be visible.</para>
    /// </summary>
    public bool Unfocusable { get => _node.Unfocusable; set => _node.Unfocusable = value; }
    /// <summary>
    /// <para>If <c>true</c>, the window can't be resized. Minimize and maximize buttons are disabled.</para>
    /// </summary>
    public bool Unresizable { get => _node.Unresizable; set => _node.Unresizable = value; }
    /// <summary>
    /// <para>If <c>true</c>, the window is visible.</para>
    /// </summary>
    public bool Visible { get => _node.Visible; set => _node.Visible = value; }
    /// <summary>
    /// <para>If <c>true</c>, the window's size will automatically update when a child node is added or removed, ignoring <see cref="Window.MinSize" /> if the new size is bigger.</para>
    /// <para>If <c>false</c>, you need to call <see cref="Window.ChildControlsChanged" /> manually.</para>
    /// </summary>
    public bool WrapControls { get => _node.WrapControls; set => _node.WrapControls = value; }

}