namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>Abstract base class for scrollbars, typically used to navigate through content that extends beyond the visible area of a control. Scrollbars are <see cref="Range" />-based controls.</para>
/// </summary>
public interface IScrollBar : IRange {
    /// <summary>
    /// <para>Overrides the step used when clicking increment and decrement buttons or when using arrow keys when the <see cref="ScrollBar" /> is focused.</para>
    /// </summary>
    float CustomStep { get; set; }

}