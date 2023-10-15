namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A directional light is a type of <see cref="Light3D" /> node that models an infinite number of parallel rays covering the entire scene. It is used for lights with strong intensity that are located far away from the scene to model sunlight or moonlight. The worldspace location of the DirectionalLight3D transform (origin) is ignored. Only the basis is used to determine light direction.</para>
/// </summary>
public class DirectionalLight3DAdapter : Light3DAdapter, IDirectionalLight3D {
  private readonly DirectionalLight3D _node;

  public DirectionalLight3DAdapter(Node node) : base(node) {
    if (node is not DirectionalLight3D typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a DirectionalLight3D"
      );
    }
    _node = typedNode;
  }

    /// <summary>
    /// <para>If <c>true</c>, shadow detail is sacrificed in exchange for smoother transitions between splits. Enabling shadow blend splitting also has a moderate performance cost. This is ignored when <see cref="DirectionalLight3D.DirectionalShadowMode" /> is <see cref="DirectionalLight3D.ShadowMode.Orthogonal" />.</para>
    /// </summary>
    public bool DirectionalShadowBlendSplits { get => _node.DirectionalShadowBlendSplits; set => _node.DirectionalShadowBlendSplits = value; }
    /// <summary>
    /// <para>Proportion of <see cref="DirectionalLight3D.DirectionalShadowMaxDistance" /> at which point the shadow starts to fade. At <see cref="DirectionalLight3D.DirectionalShadowMaxDistance" />, the shadow will disappear. The default value is a balance between smooth fading and distant shadow visibility. If the camera moves fast and the <see cref="DirectionalLight3D.DirectionalShadowMaxDistance" /> is low, consider lowering <see cref="DirectionalLight3D.DirectionalShadowFadeStart" /> below <c>0.8</c> to make shadow transitions less noticeable. On the other hand, if you tuned <see cref="DirectionalLight3D.DirectionalShadowMaxDistance" /> to cover the entire scene, you can set <see cref="DirectionalLight3D.DirectionalShadowFadeStart" /> to <c>1.0</c> to prevent the shadow from fading in the distance (it will suddenly cut off instead).</para>
    /// </summary>
    public float DirectionalShadowFadeStart { get => _node.DirectionalShadowFadeStart; set => _node.DirectionalShadowFadeStart = value; }
    /// <summary>
    /// <para>The maximum distance for shadow splits. Increasing this value will make directional shadows visible from further away, at the cost of lower overall shadow detail and performance (since more objects need to be included in the directional shadow rendering).</para>
    /// </summary>
    public float DirectionalShadowMaxDistance { get => _node.DirectionalShadowMaxDistance; set => _node.DirectionalShadowMaxDistance = value; }
    /// <summary>
    /// <para>The light's shadow rendering algorithm. See <see cref="DirectionalLight3D.ShadowMode" />.</para>
    /// </summary>
    public DirectionalLight3D.ShadowMode DirectionalShadowMode { get => _node.DirectionalShadowMode; set => _node.DirectionalShadowMode = value; }
    /// <summary>
    /// <para>Sets the size of the directional shadow pancake. The pancake offsets the start of the shadow's camera frustum to provide a higher effective depth resolution for the shadow. However, a high pancake size can cause artifacts in the shadows of large objects that are close to the edge of the frustum. Reducing the pancake size can help. Setting the size to <c>0</c> turns off the pancaking effect.</para>
    /// </summary>
    public float DirectionalShadowPancakeSize { get => _node.DirectionalShadowPancakeSize; set => _node.DirectionalShadowPancakeSize = value; }
    /// <summary>
    /// <para>The distance from camera to shadow split 1. Relative to <see cref="DirectionalLight3D.DirectionalShadowMaxDistance" />. Only used when <see cref="DirectionalLight3D.DirectionalShadowMode" /> is <see cref="DirectionalLight3D.ShadowMode.Parallel2Splits" /> or <see cref="DirectionalLight3D.ShadowMode.Parallel4Splits" />.</para>
    /// </summary>
    public float DirectionalShadowSplit1 { get => _node.DirectionalShadowSplit1; set => _node.DirectionalShadowSplit1 = value; }
    /// <summary>
    /// <para>The distance from shadow split 1 to split 2. Relative to <see cref="DirectionalLight3D.DirectionalShadowMaxDistance" />. Only used when <see cref="DirectionalLight3D.DirectionalShadowMode" /> is <see cref="DirectionalLight3D.ShadowMode.Parallel4Splits" />.</para>
    /// </summary>
    public float DirectionalShadowSplit2 { get => _node.DirectionalShadowSplit2; set => _node.DirectionalShadowSplit2 = value; }
    /// <summary>
    /// <para>The distance from shadow split 2 to split 3. Relative to <see cref="DirectionalLight3D.DirectionalShadowMaxDistance" />. Only used when <see cref="DirectionalLight3D.DirectionalShadowMode" /> is <see cref="DirectionalLight3D.ShadowMode.Parallel4Splits" />.</para>
    /// </summary>
    public float DirectionalShadowSplit3 { get => _node.DirectionalShadowSplit3; set => _node.DirectionalShadowSplit3 = value; }
    /// <summary>
    /// <para>Set whether this <see cref="DirectionalLight3D" /> is visible in the sky, in the scene, or both in the sky and in the scene. See <see cref="DirectionalLight3D.SkyModeEnum" /> for options.</para>
    /// </summary>
    public DirectionalLight3D.SkyModeEnum SkyMode { get => _node.SkyMode; set => _node.SkyMode = value; }

}