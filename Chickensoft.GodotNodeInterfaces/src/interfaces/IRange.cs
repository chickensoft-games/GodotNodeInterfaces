namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para>Range is an abstract base class for controls that represent a number within a range, using a configured <see cref="Range.Step" /> and <see cref="Range.Page" /> size. See e.g. <see cref="ScrollBar" /> and <see cref="Slider" /> for examples of higher-level nodes using Range.</para>
/// </summary>
public interface IRange : IControl {
    /// <summary>
    /// <para>Called when the <see cref="Range" />'s value is changed (following the same conditions as <see cref="Range.ValueChanged" />).</para>
    /// </summary>
    void _ValueChanged(double newValue);
    /// <summary>
    /// <para>Sets the <see cref="Range" />'s current value to the specified <paramref name="value" />, without emitting the <see cref="Range.ValueChanged" /> signal.</para>
    /// </summary>
    void SetValueNoSignal(double value);
    /// <summary>
    /// <para>Binds two <see cref="Range" />s together along with any ranges previously grouped with either of them. When any of range's member variables change, it will share the new value with all other ranges in its group.</para>
    /// </summary>
    void Share(Node @with);
    /// <summary>
    /// <para>Stops the <see cref="Range" /> from sharing its member variables with any other.</para>
    /// </summary>
    void Unshare();
    /// <summary>
    /// <para>Minimum value. Range is clamped if <see cref="Range.Value" /> is less than <see cref="Range.MinValue" />.</para>
    /// </summary>
    double MinValue { get; set; }
    /// <summary>
    /// <para>Maximum value. Range is clamped if <see cref="Range.Value" /> is greater than <see cref="Range.MaxValue" />.</para>
    /// </summary>
    double MaxValue { get; set; }
    /// <summary>
    /// <para>If greater than 0, <see cref="Range.Value" /> will always be rounded to a multiple of this property's value. If <see cref="Range.Rounded" /> is also <c>true</c>, <see cref="Range.Value" /> will first be rounded to a multiple of this property's value, then rounded to the nearest integer.</para>
    /// </summary>
    double Step { get; set; }
    /// <summary>
    /// <para>Page size. Used mainly for <see cref="ScrollBar" />. ScrollBar's length is its size multiplied by <see cref="Range.Page" /> over the difference between <see cref="Range.MinValue" /> and <see cref="Range.MaxValue" />.</para>
    /// </summary>
    double Page { get; set; }
    /// <summary>
    /// <para>Range's current value. Changing this property (even via code) will trigger <see cref="Range.ValueChanged" /> signal. Use <see cref="M:Godot.Range.SetValueNoSignal(System.Double)" /> if you want to avoid it.</para>
    /// </summary>
    double Value { get; set; }
    /// <summary>
    /// <para>The value mapped between 0 and 1.</para>
    /// </summary>
    double Ratio { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, and <see cref="Range.MinValue" /> is greater than 0, <see cref="Range.Value" /> will be represented exponentially rather than linearly.</para>
    /// </summary>
    bool ExpEdit { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, <see cref="Range.Value" /> will always be rounded to the nearest integer.</para>
    /// </summary>
    bool Rounded { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, <see cref="Range.Value" /> may be greater than <see cref="Range.MaxValue" />.</para>
    /// </summary>
    bool AllowGreater { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, <see cref="Range.Value" /> may be less than <see cref="Range.MinValue" />.</para>
    /// </summary>
    bool AllowLesser { get; set; }

}