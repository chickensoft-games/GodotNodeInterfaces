namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>Child <see cref="CanvasItem" /> nodes of a <see cref="CanvasGroup" /> are drawn as a single object. It allows to e.g. draw overlapping translucent 2D nodes without blending (set <see cref="CanvasItem.SelfModulate" /> property of <see cref="CanvasGroup" /> to achieve this effect).</para>
/// <para><b>Note:</b> The <see cref="CanvasGroup" /> uses a custom shader to read from the backbuffer to draw its children. Assigning a <see cref="Material" /> to the <see cref="CanvasGroup" /> overrides the builtin shader. To duplicate the behavior of the builtin shader in a custom <see cref="Shader" /> use the following:</para>
/// <para><code>
/// shader_type canvas_item;
/// render_mode unshaded;
/// uniform sampler2D screen_texture : hint_screen_texture, repeat_disable, filter_nearest;
/// void fragment() {
/// vec4 c = textureLod(screen_texture, SCREEN_UV, 0.0);
/// if (c.a &gt; 0.0001) {
/// c.rgb /= c.a;
/// }
/// COLOR *= c;
/// }
/// </code></para>
/// <para><b>Note:</b> Since <see cref="CanvasGroup" /> and <see cref="CanvasItem.ClipChildren" /> both utilize the backbuffer, children of a <see cref="CanvasGroup" /> who have their <see cref="CanvasItem.ClipChildren" /> set to anything other than <see cref="CanvasItem.ClipChildrenMode.Disabled" /> will not function correctly.</para>
/// </summary>
public class CanvasGroupAdapter : CanvasGroup, ICanvasGroup {
  private readonly CanvasGroup _node;

  public CanvasGroupAdapter(CanvasGroup node) => _node = node;
    /// <summary>
    /// <para>Sets the size of the margin used to expand the clearing rect of this <see cref="CanvasGroup" />. This expands the area of the backbuffer that will be used by the <see cref="CanvasGroup" />. A smaller margin will reduce the area of the backbuffer used which can increase performance, however if <see cref="CanvasGroup.UseMipmaps" /> is enabled, a small margin may result in mipmap errors at the edge of the <see cref="CanvasGroup" />. Accordingly, this should be left as small as possible, but should be increased if artifacts appear along the edges of the canvas group.</para>
    /// </summary>
    public float ClearMargin { get => _node.ClearMargin; set => _node.ClearMargin = value; }
    /// <summary>
    /// <para>Sets the size of a margin used to expand the drawable rect of this <see cref="CanvasGroup" />. The size of the <see cref="CanvasGroup" /> is determined by fitting a rect around its children then expanding that rect by <see cref="CanvasGroup.FitMargin" />. This increases both the backbuffer area used and the area covered by the <see cref="CanvasGroup" /> both of which can reduce performance. This should be kept as small as possible and should only be expanded when an increased size is needed (e.g. for custom shader effects).</para>
    /// </summary>
    public float FitMargin { get => _node.FitMargin; set => _node.FitMargin = value; }
    /// <summary>
    /// <para>If <c>true</c>, calculates mipmaps for the backbuffer before drawing the <see cref="CanvasGroup" /> so that mipmaps can be used in a custom <see cref="ShaderMaterial" /> attached to the <see cref="CanvasGroup" />. Generating mipmaps has a performance cost so this should not be enabled unless required.</para>
    /// </summary>
    public bool UseMipmaps { get => _node.UseMipmaps; set => _node.UseMipmaps = value; }

}