namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class CanvasLayerNode : CanvasLayer, ICanvasLayer { }

/// <summary>
/// <para><see cref="CanvasItem" />-derived nodes that are direct or indirect children of a <see cref="CanvasLayer" /> will be drawn in that layer. The layer is a numeric index that defines the draw order. The default 2D scene renders with index <c>0</c>, so a <see cref="CanvasLayer" /> with index <c>-1</c> will be drawn below, and a <see cref="CanvasLayer" /> with index <c>1</c> will be drawn above. This order will hold regardless of the <see cref="CanvasItem.ZIndex" /> of the nodes within each layer.</para>
/// <para><see cref="CanvasLayer" />s can be hidden and they can also optionally follow the viewport. This makes them useful for HUDs like health bar overlays (on layers <c>1</c> and higher) or backgrounds (on layers <c>-1</c> and lower).</para>
/// <para><b>Note:</b> Embedded <see cref="Window" />s are placed on layer <c>1024</c>. <see cref="CanvasItem" />s on layers <c>1025</c> and higher appear in front of embedded windows.</para>
/// <para><b>Note:</b> Each <see cref="CanvasLayer" /> is drawn on one specific <see cref="Viewport" /> and cannot be shared between multiple <see cref="Viewport" />s, see <see cref="CanvasLayer.CustomViewport" />. When using multiple <see cref="Viewport" />s, for example in a split-screen game, you need create an individual <see cref="CanvasLayer" /> for each <see cref="Viewport" /> you want it to be drawn on.</para>
/// </summary>
public interface ICanvasLayer : INode {
    /// <summary>
    /// <para>The custom <see cref="Viewport" /> node assigned to the <see cref="CanvasLayer" />. If <c>null</c>, uses the default viewport instead.</para>
    /// </summary>
    Node CustomViewport { get; set; }
    /// <summary>
    /// <para>If enabled, the <see cref="CanvasLayer" /> will use the viewport's transform, so it will move when camera moves instead of being anchored in a fixed position on the screen.</para>
    /// <para>Together with <see cref="CanvasLayer.FollowViewportScale" /> it can be used for a pseudo 3D effect.</para>
    /// </summary>
    bool FollowViewportEnabled { get; set; }
    /// <summary>
    /// <para>Scales the layer when using <see cref="CanvasLayer.FollowViewportEnabled" />. Layers moving into the foreground should have increasing scales, while layers moving into the background should have decreasing scales.</para>
    /// </summary>
    float FollowViewportScale { get; set; }
    /// <summary>
    /// <para>Returns the RID of the canvas used by this layer.</para>
    /// </summary>
    Rid GetCanvas();
    /// <summary>
    /// <para>Returns the transform from the <see cref="CanvasLayer" />s coordinate system to the <see cref="Viewport" />s coordinate system.</para>
    /// </summary>
    Transform2D GetFinalTransform();
    /// <summary>
    /// <para>Hides any <see cref="CanvasItem" /> under this <see cref="CanvasLayer" />. This is equivalent to setting <see cref="CanvasLayer.Visible" /> to <c>false</c>.</para>
    /// </summary>
    void Hide();
    /// <summary>
    /// <para>Layer index for draw order. Lower values are drawn behind higher values.</para>
    /// <para><b>Note:</b> If multiple CanvasLayers have the same layer index, <see cref="CanvasItem" /> children of one CanvasLayer are drawn behind the <see cref="CanvasItem" /> children of the other CanvasLayer. Which CanvasLayer is drawn in front is non-deterministic.</para>
    /// </summary>
    int Layer { get; set; }
    /// <summary>
    /// <para>The layer's base offset.</para>
    /// </summary>
    Vector2 Offset { get; set; }
    /// <summary>
    /// <para>The layer's rotation in radians.</para>
    /// </summary>
    float Rotation { get; set; }
    /// <summary>
    /// <para>The layer's scale.</para>
    /// </summary>
    Vector2 Scale { get; set; }
    /// <summary>
    /// <para>Shows any <see cref="CanvasItem" /> under this <see cref="CanvasLayer" />. This is equivalent to setting <see cref="CanvasLayer.Visible" /> to <c>true</c>.</para>
    /// </summary>
    void Show();
    /// <summary>
    /// <para>The layer's transform.</para>
    /// </summary>
    Transform2D Transform { get; set; }
    /// <summary>
    /// <para>If <c>false</c>, any <see cref="CanvasItem" /> under this <see cref="CanvasLayer" /> will be hidden.</para>
    /// <para>Unlike <see cref="CanvasItem.Visible" />, visibility of a <see cref="CanvasLayer" /> isn't propagated to underlying layers.</para>
    /// </summary>
    bool Visible { get; set; }

}