namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para><i>Root motion</i> refers to an animation technique where a mesh's skeleton is used to give impulse to a character. When working with 3D animations, a popular technique is for animators to use the root skeleton bone to give motion to the rest of the skeleton. This allows animating characters in a way where steps actually match the floor below. It also allows precise interaction with objects during cinematics. See also <see cref="AnimationMixer" />.</para>
/// <para><b>Note:</b> <see cref="RootMotionView" /> is only visible in the editor. It will be hidden automatically in the running project.</para>
/// </summary>
public interface IRootMotionView : IVisualInstance3D {
    /// <summary>
    /// <para>Path to an <see cref="AnimationMixer" /> node to use as a basis for root motion.</para>
    /// </summary>
    NodePath AnimationPath { get; set; }
    /// <summary>
    /// <para>The grid's color.</para>
    /// </summary>
    Color Color { get; set; }
    /// <summary>
    /// <para>The grid's cell size in 3D units.</para>
    /// </summary>
    float CellSize { get; set; }
    /// <summary>
    /// <para>The grid's radius in 3D units. The grid's opacity will fade gradually as the distance from the origin increases until this <see cref="RootMotionView.Radius" /> is reached.</para>
    /// </summary>
    float Radius { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the grid's points will all be on the same Y coordinate (<i>local</i> Y = 0). If <c>false</c>, the points' original Y coordinate is preserved.</para>
    /// </summary>
    bool ZeroY { get; set; }

}