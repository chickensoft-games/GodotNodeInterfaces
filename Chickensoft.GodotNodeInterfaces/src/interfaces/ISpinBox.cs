namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class SpinBoxNode : SpinBox, ISpinBox { }

/// <summary>
/// <para><see cref="SpinBox" /> is a numerical input text field. It allows entering integers and floating point numbers.</para>
/// <para><b>Example:</b></para>
/// <para><code>
/// var spinBox = new SpinBox();
/// AddChild(spinBox);
/// var lineEdit = spinBox.GetLineEdit();
/// lineEdit.ContextMenuEnabled = false;
/// spinBox.AlignHorizontal = LineEdit.HorizontalAlignEnum.Right;
/// </code></para>
/// <para>The above code will create a <see cref="SpinBox" />, disable context menu on it and set the text alignment to right.</para>
/// <para>See <see cref="Range" /> class for more options over the <see cref="SpinBox" />.</para>
/// <para><b>Note:</b> <see cref="SpinBox" /> relies on an underlying <see cref="LineEdit" /> node. To theme a <see cref="SpinBox" />'s background, add theme items for <see cref="LineEdit" /> and customize them.</para>
/// <para><b>Note:</b> If you want to implement drag and drop for the underlying <see cref="LineEdit" />, you can use <see cref="Control.SetDragForwarding(Godot.Callable,Godot.Callable,Godot.Callable)" /> on the node returned by <see cref="SpinBox.GetLineEdit" />.</para>
/// </summary>
public interface ISpinBox : IRange {
    /// <summary>
    /// <para>Changes the alignment of the underlying <see cref="LineEdit" />.</para>
    /// </summary>
    HorizontalAlignment Alignment { get; set; }
    /// <summary>
    /// <para>Applies the current value of this <see cref="SpinBox" />.</para>
    /// </summary>
    void Apply();
    /// <summary>
    /// <para>If not <c>0</c>, <see cref="Range.Value" /> will always be rounded to a multiple of <see cref="SpinBox.CustomArrowStep" /> when interacting with the arrow buttons of the <see cref="SpinBox" />.</para>
    /// </summary>
    double CustomArrowStep { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the <see cref="SpinBox" /> will be editable. Otherwise, it will be read only.</para>
    /// </summary>
    bool Editable { get; set; }
    /// <summary>
    /// <para>Returns the <see cref="LineEdit" /> instance from this <see cref="SpinBox" />. You can use it to access properties and methods of <see cref="LineEdit" />.</para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash. If you wish to hide it or any of its children, use their <see cref="CanvasItem.Visible" /> property.</para>
    /// </summary>
    LineEdit GetLineEdit();
    /// <summary>
    /// <para>Adds the specified prefix string before the numerical value of the <see cref="SpinBox" />.</para>
    /// </summary>
    string Prefix { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the <see cref="SpinBox" /> will select the whole text when the <see cref="LineEdit" /> gains focus. Clicking the up and down arrows won't trigger this behavior.</para>
    /// </summary>
    bool SelectAllOnFocus { get; set; }
    /// <summary>
    /// <para>Adds the specified suffix string after the numerical value of the <see cref="SpinBox" />.</para>
    /// </summary>
    string Suffix { get; set; }
    /// <summary>
    /// <para>Sets the value of the <see cref="Range" /> for this <see cref="SpinBox" /> when the <see cref="LineEdit" /> text is <i>changed</i> instead of <i>submitted</i>. See <see cref="LineEdit.TextChanged" /> and <see cref="LineEdit.TextSubmitted" />.</para>
    /// </summary>
    bool UpdateOnTextChanged { get; set; }

}