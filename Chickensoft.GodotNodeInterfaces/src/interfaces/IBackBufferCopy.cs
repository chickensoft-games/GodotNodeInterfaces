namespace Chickensoft.GodotNodeInterfaces;

using Godot;


/// <summary>
/// <para>Node for back-buffering the currently-displayed screen. The region defined in the <see cref="BackBufferCopy" /> node is buffered with the content of the screen it covers, or the entire screen according to the <see cref="BackBufferCopy.CopyMode" />. It can be accessed in shader scripts using the screen texture (i.e. a uniform sampler with <c>hint_screen_texture</c>).</para>
/// <para><b>Note:</b> Since this node inherits from <see cref="Node2D" /> (and not <see cref="Control" />), anchors and margins won't apply to child <see cref="Control" />-derived nodes. This can be problematic when resizing the window. To avoid this, add <see cref="Control" />-derived nodes as <i>siblings</i> to the <see cref="BackBufferCopy" /> node instead of adding them as children.</para>
/// </summary>
public interface IBackBufferCopy : INode2D {
    /// <summary>
    /// <para>Buffer mode. See <see cref="BackBufferCopy.CopyModeEnum" /> constants.</para>
    /// </summary>
    BackBufferCopy.CopyModeEnum CopyMode { get; set; }
    /// <summary>
    /// <para>The area covered by the <see cref="BackBufferCopy" />. Only used if <see cref="BackBufferCopy.CopyMode" /> is <see cref="BackBufferCopy.CopyModeEnum.Rect" />.</para>
    /// </summary>
    Rect2 Rect { get; set; }

}