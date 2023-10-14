namespace Chickensoft.GodotNodeInterfaces;

using Godot;


/// <summary>
/// <para>VisibleOnScreenEnabler2D detects when it is visible on screen (just like <see cref="VisibleOnScreenNotifier2D" />) and automatically enables or disables the target node. The target node is disabled when <see cref="VisibleOnScreenEnabler2D" /> is not visible on screen (including when <see cref="CanvasItem.Visible" /> is <c>false</c>), and enabled when the enabler is visible. The disabling is achieved by changing <see cref="Node.ProcessMode" />.</para>
/// </summary>
public interface IVisibleOnScreenEnabler2D : IVisibleOnScreenNotifier2D {
    /// <summary>
    /// <para>Determines how the node is enabled. Corresponds to <see cref="Node.ProcessModeEnum" />. Disabled node uses <see cref="Node.ProcessModeEnum.Disabled" />.</para>
    /// </summary>
    VisibleOnScreenEnabler2D.EnableModeEnum EnableMode { get; set; }
    /// <summary>
    /// <para>The path to the target node, relative to the <see cref="VisibleOnScreenEnabler2D" />. The target node is cached; it's only assigned when setting this property (if the <see cref="VisibleOnScreenEnabler2D" /> is inside scene tree) and every time the <see cref="VisibleOnScreenEnabler2D" /> enters the scene tree. If the path is invalid, nothing will happen.</para>
    /// </summary>
    NodePath EnableNodePath { get; set; }

}