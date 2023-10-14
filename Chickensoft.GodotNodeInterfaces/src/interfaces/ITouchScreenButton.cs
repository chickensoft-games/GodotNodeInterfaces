namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class TouchScreenButtonNode : TouchScreenButton, ITouchScreenButton { }

/// <summary>
/// <para>TouchScreenButton allows you to create on-screen buttons for touch devices. It's intended for gameplay use, such as a unit you have to touch to move. Unlike <see cref="Button" />, TouchScreenButton supports multitouch out of the box. Several TouchScreenButtons can be pressed at the same time with touch input.</para>
/// <para>This node inherits from <see cref="Node2D" />. Unlike with <see cref="Control" /> nodes, you cannot set anchors on it. If you want to create menus or user interfaces, you may want to use <see cref="Button" /> nodes instead. To make button nodes react to touch events, you can enable the Emulate Mouse option in the Project Settings.</para>
/// <para>You can configure TouchScreenButton to be visible only on touch devices, helping you develop your game both for desktop and mobile devices.</para>
/// </summary>
public interface ITouchScreenButton : INode2D {
    /// <summary>
    /// <para>The button's action. Actions can be handled with <see cref="InputEventAction" />.</para>
    /// </summary>
    string Action { get; set; }
    /// <summary>
    /// <para>The button's bitmask.</para>
    /// </summary>
    Bitmap Bitmask { get; set; }
    /// <summary>
    /// <para>Returns <c>true</c> if this button is currently pressed.</para>
    /// </summary>
    bool IsPressed();
    /// <summary>
    /// <para>If <c>true</c>, the <see cref="TouchScreenButton.Pressed" /> and <see cref="TouchScreenButton.Released" /> signals are emitted whenever a pressed finger goes in and out of the button, even if the pressure started outside the active area of the button.</para>
    /// <para><b>Note:</b> This is a "pass-by" (not "bypass") press mode.</para>
    /// </summary>
    bool PassbyPress { get; set; }
    /// <summary>
    /// <para>The button's shape.</para>
    /// </summary>
    Shape2D Shape { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the button's shape is centered in the provided texture. If no texture is used, this property has no effect.</para>
    /// </summary>
    bool ShapeCentered { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the button's shape is visible in the editor.</para>
    /// </summary>
    bool ShapeVisible { get; set; }
    /// <summary>
    /// <para>The button's texture for the normal state.</para>
    /// </summary>
    Texture2D TextureNormal { get; set; }
    /// <summary>
    /// <para>The button's texture for the pressed state.</para>
    /// </summary>
    Texture2D TexturePressed { get; set; }
    /// <summary>
    /// <para>The button's visibility mode. See <see cref="TouchScreenButton.VisibilityModeEnum" /> for possible values.</para>
    /// </summary>
    TouchScreenButton.VisibilityModeEnum VisibilityMode { get; set; }

}