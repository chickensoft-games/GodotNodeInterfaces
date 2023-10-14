namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>Abstract base class for sliders, used to adjust a value by moving a grabber along a horizontal or vertical axis. Sliders are <see cref="Range" />-based controls.</para>
/// </summary>
public interface ISlider : IRange {
    /// <summary>
    /// <para>If <c>true</c>, the slider can be interacted with. If <c>false</c>, the value can be changed only by code.</para>
    /// </summary>
    bool Editable { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the value can be changed using the mouse wheel.</para>
    /// </summary>
    bool Scrollable { get; set; }
    /// <summary>
    /// <para>Number of ticks displayed on the slider, including border ticks. Ticks are uniformly-distributed value markers.</para>
    /// </summary>
    int TickCount { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the slider will display ticks for minimum and maximum values.</para>
    /// </summary>
    bool TicksOnBorders { get; set; }

}