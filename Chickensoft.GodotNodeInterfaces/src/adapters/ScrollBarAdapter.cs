namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>Abstract base class for scrollbars, typically used to navigate through content that extends beyond the visible area of a control. Scrollbars are <see cref="Range" />-based controls.</para>
/// </summary>
public class ScrollBarAdapter : RangeAdapter, IScrollBar {
  private readonly ScrollBar _node;

  public ScrollBarAdapter(ScrollBar node) : base(node) { _node = node; }

    /// <summary>
    /// <para>Overrides the step used when clicking increment and decrement buttons or when using arrow keys when the <see cref="ScrollBar" /> is focused.</para>
    /// </summary>
    public float CustomStep { get => _node.CustomStep; set => _node.CustomStep = value; }

}