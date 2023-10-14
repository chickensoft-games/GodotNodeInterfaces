 namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para><see cref="SubViewport" /> Isolates a rectangular region of a scene to be displayed independently. This can be used, for example, to display UI in 3D space.</para>
/// <para><b>Note:</b> <see cref="SubViewport" /> is a <see cref="Viewport" /> that isn't a <see cref="Window" />, i.e. it doesn't draw anything by itself. To display anything, <see cref="SubViewport" /> must have a non-zero size and be either put inside a <see cref="SubViewportContainer" /> or assigned to a <see cref="ViewportTexture" />.</para>
/// </summary>
public class SubViewportAdapter : SubViewport, ISubViewport {
  private readonly SubViewport _node;

  public SubViewportAdapter(SubViewport node) => _node = node;
    /// <summary>
    /// <para>The clear mode when the sub-viewport is used as a render target.</para>
    /// <para><b>Note:</b> This property is intended for 2D usage.</para>
    /// </summary>
    public SubViewport.ClearMode RenderTargetClearMode { get => _node.RenderTargetClearMode; set => _node.RenderTargetClearMode = value; }
    /// <summary>
    /// <para>The update mode when the sub-viewport is used as a render target.</para>
    /// </summary>
    public SubViewport.UpdateMode RenderTargetUpdateMode { get => _node.RenderTargetUpdateMode; set => _node.RenderTargetUpdateMode = value; }
    /// <summary>
    /// <para>The width and height of the sub-viewport. Must be set to a value greater than or equal to 2 pixels on both dimensions. Otherwise, nothing will be displayed.</para>
    /// <para><b>Note:</b> If the parent node is a <see cref="SubViewportContainer" /> and its <see cref="SubViewportContainer.Stretch" /> is <c>true</c>, the viewport size cannot be changed manually.</para>
    /// </summary>
    public Vector2I Size { get => _node.Size; set => _node.Size = value; }
    /// <summary>
    /// <para>The 2D size override of the sub-viewport. If either the width or height is <c>0</c>, the override is disabled.</para>
    /// </summary>
    public Vector2I Size2DOverride { get => _node.Size2DOverride; set => _node.Size2DOverride = value; }
    /// <summary>
    /// <para>If <c>true</c>, the 2D size override affects stretch as well.</para>
    /// </summary>
    public bool Size2DOverrideStretch { get => _node.Size2DOverrideStretch; set => _node.Size2DOverrideStretch = value; }

}