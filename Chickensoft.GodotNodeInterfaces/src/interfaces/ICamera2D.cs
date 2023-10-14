namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class Camera2DNode : Camera2D, ICamera2D { }

/// <summary>
/// <para>Camera node for 2D scenes. It forces the screen (current layer) to scroll following this node. This makes it easier (and faster) to program scrollable scenes than manually changing the position of <see cref="CanvasItem" />-based nodes.</para>
/// <para>Cameras register themselves in the nearest <see cref="Viewport" /> node (when ascending the tree). Only one camera can be active per viewport. If no viewport is available ascending the tree, the camera will register in the global viewport.</para>
/// <para>This node is intended to be a simple helper to get things going quickly, but more functionality may be desired to change how the camera works. To make your own custom camera node, inherit it from <see cref="Node2D" /> and change the transform of the canvas by setting <see cref="Viewport.CanvasTransform" /> in <see cref="Viewport" /> (you can obtain the current <see cref="Viewport" /> by using <see cref="Node.GetViewport" />).</para>
/// <para>Note that the <see cref="Camera2D" /> node's <c>position</c> doesn't represent the actual position of the screen, which may differ due to applied smoothing or limits. You can use <see cref="Camera2D.GetScreenCenterPosition" /> to get the real position.</para>
/// </summary>
public interface ICamera2D : INode2D {
    /// <summary>
    /// <para>Aligns the camera to the tracked node.</para>
    /// </summary>
    void Align();
    /// <summary>
    /// <para>The Camera2D's anchor point. See <see cref="Camera2D.AnchorModeEnum" /> constants.</para>
    /// </summary>
    Camera2D.AnchorModeEnum AnchorMode { get; set; }
    /// <summary>
    /// <para>The custom <see cref="Viewport" /> node attached to the <see cref="Camera2D" />. If <c>null</c> or not a <see cref="Viewport" />, uses the default viewport instead.</para>
    /// </summary>
    Node CustomViewport { get; set; }
    /// <summary>
    /// <para>Bottom margin needed to drag the camera. A value of <c>1</c> makes the camera move only when reaching the bottom edge of the screen.</para>
    /// </summary>
    float DragBottomMargin { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the camera only moves when reaching the horizontal (left and right) drag margins. If <c>false</c>, the camera moves horizontally regardless of margins.</para>
    /// </summary>
    bool DragHorizontalEnabled { get; set; }
    /// <summary>
    /// <para>The relative horizontal drag offset of the camera between the right (<c>-1</c>) and left (<c>1</c>) drag margins.</para>
    /// <para><b>Note:</b> Used to set the initial horizontal drag offset; determine the current offset; or force the current offset. It's not automatically updated when <see cref="Camera2D.DragHorizontalEnabled" /> is <c>true</c> or the drag margins are changed.</para>
    /// </summary>
    float DragHorizontalOffset { get; set; }
    /// <summary>
    /// <para>Left margin needed to drag the camera. A value of <c>1</c> makes the camera move only when reaching the left edge of the screen.</para>
    /// </summary>
    float DragLeftMargin { get; set; }
    /// <summary>
    /// <para>Right margin needed to drag the camera. A value of <c>1</c> makes the camera move only when reaching the right edge of the screen.</para>
    /// </summary>
    float DragRightMargin { get; set; }
    /// <summary>
    /// <para>Top margin needed to drag the camera. A value of <c>1</c> makes the camera move only when reaching the top edge of the screen.</para>
    /// </summary>
    float DragTopMargin { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the camera only moves when reaching the vertical (top and bottom) drag margins. If <c>false</c>, the camera moves vertically regardless of the drag margins.</para>
    /// </summary>
    bool DragVerticalEnabled { get; set; }
    /// <summary>
    /// <para>The relative vertical drag offset of the camera between the bottom (<c>-1</c>) and top (<c>1</c>) drag margins.</para>
    /// <para><b>Note:</b> Used to set the initial vertical drag offset; determine the current offset; or force the current offset. It's not automatically updated when <see cref="Camera2D.DragVerticalEnabled" /> is <c>true</c> or the drag margins are changed.</para>
    /// </summary>
    float DragVerticalOffset { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, draws the camera's drag margin rectangle in the editor.</para>
    /// </summary>
    bool EditorDrawDragMargin { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, draws the camera's limits rectangle in the editor.</para>
    /// </summary>
    bool EditorDrawLimits { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, draws the camera's screen rectangle in the editor.</para>
    /// </summary>
    bool EditorDrawScreen { get; set; }
    /// <summary>
    /// <para>Controls whether the camera can be active or not. If <c>true</c>, the <see cref="Camera2D" /> will become the main camera when it enters the scene tree and there is no active camera currently (see <see cref="Viewport.GetCamera2D" />).</para>
    /// <para>When the camera is currently active and <see cref="Camera2D.Enabled" /> is set to <c>false</c>, the next enabled <see cref="Camera2D" /> in the scene tree will become active.</para>
    /// </summary>
    bool Enabled { get; set; }
    /// <summary>
    /// <para>Forces the camera to update scroll immediately.</para>
    /// </summary>
    void ForceUpdateScroll();
    /// <summary>
    /// <para>Returns the center of the screen from this camera's point of view, in global coordinates.</para>
    /// <para><b>Note:</b> The exact targeted position of the camera may be different. See <see cref="Camera2D.GetTargetPosition" />.</para>
    /// </summary>
    Vector2 GetScreenCenterPosition();
    /// <summary>
    /// <para>Returns this camera's target position, in global coordinates.</para>
    /// <para><b>Note:</b> The returned value is not the same as <see cref="Node2D.GlobalPosition" />, as it is affected by the drag properties. It is also not the same as the current position if <see cref="Camera2D.PositionSmoothingEnabled" /> is <c>true</c> (see <see cref="Camera2D.GetScreenCenterPosition" />).</para>
    /// </summary>
    Vector2 GetTargetPosition();
    /// <summary>
    /// <para>If <c>true</c>, the camera's rendered view is not affected by its <see cref="Node2D.Rotation" /> and <see cref="Node2D.GlobalRotation" />.</para>
    /// </summary>
    bool IgnoreRotation { get; set; }
    /// <summary>
    /// <para>Returns <c>true</c> if this <see cref="Camera2D" /> is the active camera (see <see cref="Viewport.GetCamera2D" />).</para>
    /// </summary>
    bool IsCurrent();
    /// <summary>
    /// <para>Bottom scroll limit in pixels. The camera stops moving when reaching this value, but <see cref="Camera2D.Offset" /> can push the view past the limit.</para>
    /// </summary>
    int LimitBottom { get; set; }
    /// <summary>
    /// <para>Left scroll limit in pixels. The camera stops moving when reaching this value, but <see cref="Camera2D.Offset" /> can push the view past the limit.</para>
    /// </summary>
    int LimitLeft { get; set; }
    /// <summary>
    /// <para>Right scroll limit in pixels. The camera stops moving when reaching this value, but <see cref="Camera2D.Offset" /> can push the view past the limit.</para>
    /// </summary>
    int LimitRight { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the camera smoothly stops when reaches its limits.</para>
    /// <para>This property has no effect if <see cref="Camera2D.PositionSmoothingEnabled" /> is <c>false</c>.</para>
    /// <para><b>Note:</b> To immediately update the camera's position to be within limits without smoothing, even with this setting enabled, invoke <see cref="Camera2D.ResetSmoothing" />.</para>
    /// </summary>
    bool LimitSmoothed { get; set; }
    /// <summary>
    /// <para>Top scroll limit in pixels. The camera stops moving when reaching this value, but <see cref="Camera2D.Offset" /> can push the view past the limit.</para>
    /// </summary>
    int LimitTop { get; set; }
    /// <summary>
    /// <para>Forces this <see cref="Camera2D" /> to become the current active one. <see cref="Camera2D.Enabled" /> must be <c>true</c>.</para>
    /// </summary>
    void MakeCurrent();
    /// <summary>
    /// <para>The camera's relative offset. Useful for looking around or camera shake animations. The offsetted camera can go past the limits defined in <see cref="Camera2D.LimitTop" />, <see cref="Camera2D.LimitBottom" />, <see cref="Camera2D.LimitLeft" /> and <see cref="Camera2D.LimitRight" />.</para>
    /// </summary>
    Vector2 Offset { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the camera's view smoothly moves towards its target position at <see cref="Camera2D.PositionSmoothingSpeed" />.</para>
    /// </summary>
    bool PositionSmoothingEnabled { get; set; }
    /// <summary>
    /// <para>Speed in pixels per second of the camera's smoothing effect when <see cref="Camera2D.PositionSmoothingEnabled" /> is <c>true</c>.</para>
    /// </summary>
    float PositionSmoothingSpeed { get; set; }
    /// <summary>
    /// <para>The camera's process callback. See <see cref="Camera2D.Camera2DProcessCallback" />.</para>
    /// </summary>
    Camera2D.Camera2DProcessCallback ProcessCallback { get; set; }
    /// <summary>
    /// <para>Sets the camera's position immediately to its current smoothing destination.</para>
    /// <para>This method has no effect if <see cref="Camera2D.PositionSmoothingEnabled" /> is <c>false</c>.</para>
    /// </summary>
    void ResetSmoothing();
    /// <summary>
    /// <para>If <c>true</c>, the camera's view smoothly rotates, via asymptotic smoothing, to align with its target rotation at <see cref="Camera2D.RotationSmoothingSpeed" />.</para>
    /// <para><b>Note:</b> This property has no effect if <see cref="Camera2D.IgnoreRotation" /> is <c>true</c>.</para>
    /// </summary>
    bool RotationSmoothingEnabled { get; set; }
    /// <summary>
    /// <para>The angular, asymptotic speed of the camera's rotation smoothing effect when <see cref="Camera2D.RotationSmoothingEnabled" /> is <c>true</c>.</para>
    /// </summary>
    float RotationSmoothingSpeed { get; set; }
    /// <summary>
    /// <para>The camera's zoom. A zoom of <c>Vector(2, 2)</c> doubles the size seen in the viewport. A zoom of <c>Vector(0.5, 0.5)</c> halves the size seen in the viewport.</para>
    /// <para><b>Note:</b> <see cref="FontFile.Oversampling" /> does <i>not</i> take <see cref="Camera2D" /> zoom into account. This means that zooming in/out will cause bitmap fonts and rasterized (non-MSDF) dynamic fonts to appear blurry or pixelated unless the font is part of a <see cref="CanvasLayer" /> that makes it ignore camera zoom. To ensure text remains crisp regardless of zoom, you can enable MSDF font rendering by enabling <c>ProjectSettings.gui/theme/default_font_multichannel_signed_distance_field</c> (applies to the default project font only), or enabling <b>Multichannel Signed Distance Field</b> in the import options of a DynamicFont for custom fonts. On system fonts, <see cref="SystemFont.MultichannelSignedDistanceField" /> can be enabled in the inspector.</para>
    /// </summary>
    Vector2 Zoom { get; set; }

}