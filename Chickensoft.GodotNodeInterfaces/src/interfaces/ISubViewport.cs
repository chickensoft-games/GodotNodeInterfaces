namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para><see cref="SubViewport" /> Isolates a rectangular region of a scene to be displayed independently. This can be used, for example, to display UI in 3D space.</para>
/// <para><b>Note:</b> <see cref="SubViewport" /> is a <see cref="Viewport" /> that isn't a <see cref="Window" />, i.e. it doesn't draw anything by itself. To display anything, <see cref="SubViewport" /> must have a non-zero size and be either put inside a <see cref="SubViewportContainer" /> or assigned to a <see cref="ViewportTexture" />.</para>
/// </summary>
public interface ISubViewport : IViewport {
    /// <summary>
    /// <para>The width and height of the sub-viewport. Must be set to a value greater than or equal to 2 pixels on both dimensions. Otherwise, nothing will be displayed.</para>
    /// <para><b>Note:</b> If the parent node is a <see cref="SubViewportContainer" /> and its <see cref="SubViewportContainer.Stretch" /> is <c>true</c>, the viewport size cannot be changed manually.</para>
    /// </summary>
    Vector2I Size { get; set; }
    /// <summary>
    /// <para>The 2D size override of the sub-viewport. If either the width or height is <c>0</c>, the override is disabled.</para>
    /// </summary>
    Vector2I Size2DOverride { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the 2D size override affects stretch as well.</para>
    /// </summary>
    bool Size2DOverrideStretch { get; set; }
    /// <summary>
    /// <para>The clear mode when the sub-viewport is used as a render target.</para>
    /// <para><b>Note:</b> This property is intended for 2D usage.</para>
    /// </summary>
    SubViewport.ClearMode RenderTargetClearMode { get; set; }
    /// <summary>
    /// <para>The update mode when the sub-viewport is used as a render target.</para>
    /// </summary>
    SubViewport.UpdateMode RenderTargetUpdateMode { get; set; }

}