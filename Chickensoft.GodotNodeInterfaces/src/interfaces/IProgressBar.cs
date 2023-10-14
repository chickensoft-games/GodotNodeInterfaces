namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>A control used for visual representation of a percentage. Shows fill percentage from right to left.</para>
/// </summary>
public interface IProgressBar : IRange {
    /// <summary>
    /// <para>The fill direction. See <see cref="ProgressBar.FillModeEnum" /> for possible values.</para>
    /// </summary>
    int FillMode { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the fill percentage is displayed on the bar.</para>
    /// </summary>
    bool ShowPercentage { get; set; }

}