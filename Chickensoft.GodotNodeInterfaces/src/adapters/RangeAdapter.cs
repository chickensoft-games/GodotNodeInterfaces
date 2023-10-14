namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>Range is an abstract base class for controls that represent a number within a range, using a configured <see cref="Range.Step" /> and <see cref="Range.Page" /> size. See e.g. <see cref="ScrollBar" /> and <see cref="Slider" /> for examples of higher-level nodes using Range.</para>
/// </summary>
public class RangeAdapter : Godot.Range, IRange {
  private readonly Godot.Range _node;

  public RangeAdapter(Godot.Range node) => _node = node;
    /// <summary>
    /// <para>Called when the <see cref="Range" />'s value is changed (following the same conditions as <see cref="Range.ValueChanged" />).</para>
    /// </summary>
    public void _ValueChanged(double newValue) => _node._ValueChanged(newValue);
    /// <summary>
    /// <para>If <c>true</c>, <see cref="Range.Value" /> may be greater than <see cref="Range.MaxValue" />.</para>
    /// </summary>
    public bool AllowGreater { get => _node.AllowGreater; set => _node.AllowGreater = value; }
    /// <summary>
    /// <para>If <c>true</c>, <see cref="Range.Value" /> may be less than <see cref="Range.MinValue" />.</para>
    /// </summary>
    public bool AllowLesser { get => _node.AllowLesser; set => _node.AllowLesser = value; }
    /// <summary>
    /// <para>If <c>true</c>, and <see cref="Range.MinValue" /> is greater than 0, <see cref="Range.Value" /> will be represented exponentially rather than linearly.</para>
    /// </summary>
    public bool ExpEdit { get => _node.ExpEdit; set => _node.ExpEdit = value; }
    /// <summary>
    /// <para>Maximum value. Range is clamped if <see cref="Range.Value" /> is greater than <see cref="Range.MaxValue" />.</para>
    /// </summary>
    public double MaxValue { get => _node.MaxValue; set => _node.MaxValue = value; }
    /// <summary>
    /// <para>Minimum value. Range is clamped if <see cref="Range.Value" /> is less than <see cref="Range.MinValue" />.</para>
    /// </summary>
    public double MinValue { get => _node.MinValue; set => _node.MinValue = value; }
    /// <summary>
    /// <para>Page size. Used mainly for <see cref="ScrollBar" />. ScrollBar's length is its size multiplied by <see cref="Range.Page" /> over the difference between <see cref="Range.MinValue" /> and <see cref="Range.MaxValue" />.</para>
    /// </summary>
    public double Page { get => _node.Page; set => _node.Page = value; }
    /// <summary>
    /// <para>The value mapped between 0 and 1.</para>
    /// </summary>
    public double Ratio { get => _node.Ratio; set => _node.Ratio = value; }
    /// <summary>
    /// <para>If <c>true</c>, <see cref="Range.Value" /> will always be rounded to the nearest integer.</para>
    /// </summary>
    public bool Rounded { get => _node.Rounded; set => _node.Rounded = value; }
    /// <summary>
    /// <para>Sets the <see cref="Range" />'s current value to the specified <paramref name="value" />, without emitting the <see cref="Range.ValueChanged" /> signal.</para>
    /// </summary>
    public void SetValueNoSignal(double value) => _node.SetValueNoSignal(value);
    /// <summary>
    /// <para>Binds two <see cref="Range" />s together along with any ranges previously grouped with either of them. When any of range's member variables change, it will share the new value with all other ranges in its group.</para>
    /// </summary>
    public void Share(Node @with) => _node.Share(@with);
    /// <summary>
    /// <para>If greater than 0, <see cref="Range.Value" /> will always be rounded to a multiple of this property's value. If <see cref="Range.Rounded" /> is also <c>true</c>, <see cref="Range.Value" /> will first be rounded to a multiple of this property's value, then rounded to the nearest integer.</para>
    /// </summary>
    public double Step { get => _node.Step; set => _node.Step = value; }
    /// <summary>
    /// <para>Stops the <see cref="Range" /> from sharing its member variables with any other.</para>
    /// </summary>
    public void Unshare() => _node.Unshare();
    /// <summary>
    /// <para>Range's current value. Changing this property (even via code) will trigger <see cref="Range.ValueChanged" /> signal. Use <see cref="Range.SetValueNoSignal(System.Double)" /> if you want to avoid it.</para>
    /// </summary>
    public double Value { get => _node.Value; set => _node.Value = value; }

}