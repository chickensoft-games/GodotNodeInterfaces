namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>A ParallaxBackground uses one or more <see cref="ParallaxLayer" /> child nodes to create a parallax effect. Each <see cref="ParallaxLayer" /> can move at a different speed using <see cref="ParallaxLayer.MotionOffset" />. This creates an illusion of depth in a 2D game. If not used with a <see cref="Camera2D" />, you must manually calculate the <see cref="ParallaxBackground.ScrollOffset" />.</para>
/// <para><b>Note:</b> Each <see cref="ParallaxBackground" /> is drawn on one specific <see cref="Viewport" /> and cannot be shared between multiple <see cref="Viewport" />s, see <see cref="CanvasLayer.CustomViewport" />. When using multiple <see cref="Viewport" />s, for example in a split-screen game, you need create an individual <see cref="ParallaxBackground" /> for each <see cref="Viewport" /> you want it to be drawn on.</para>
/// </summary>
public interface IParallaxBackground : ICanvasLayer {
    /// <summary>
    /// <para>The ParallaxBackground's scroll value. Calculated automatically when using a <see cref="Camera2D" />, but can be used to manually manage scrolling when no camera is present.</para>
    /// </summary>
    Vector2 ScrollOffset { get; set; }
    /// <summary>
    /// <para>The base position offset for all <see cref="ParallaxLayer" /> children.</para>
    /// </summary>
    Vector2 ScrollBaseOffset { get; set; }
    /// <summary>
    /// <para>The base motion scale for all <see cref="ParallaxLayer" /> children.</para>
    /// </summary>
    Vector2 ScrollBaseScale { get; set; }
    /// <summary>
    /// <para>Top-left limits for scrolling to begin. If the camera is outside of this limit, the background will stop scrolling. Must be lower than <see cref="ParallaxBackground.ScrollLimitEnd" /> to work.</para>
    /// </summary>
    Vector2 ScrollLimitBegin { get; set; }
    /// <summary>
    /// <para>Bottom-right limits for scrolling to end. If the camera is outside of this limit, the background will stop scrolling. Must be higher than <see cref="ParallaxBackground.ScrollLimitBegin" /> to work.</para>
    /// </summary>
    Vector2 ScrollLimitEnd { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, elements in <see cref="ParallaxLayer" /> child aren't affected by the zoom level of the camera.</para>
    /// </summary>
    bool ScrollIgnoreCameraZoom { get; set; }

}