namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class AcceptDialogNode : AcceptDialog, IAcceptDialog { }

/// <summary>
/// <para>The default use of <see cref="AcceptDialog" /> is to allow it to only be accepted or closed, with the same result. However, the <see cref="AcceptDialog.Confirmed" /> and <see cref="AcceptDialog.Canceled" /> signals allow to make the two actions different, and the <see cref="AcceptDialog.AddButton(System.String,System.Boolean,System.String)" /> method allows to add custom buttons and actions.</para>
/// </summary>
public interface IAcceptDialog : IWindow {
    /// <summary>
    /// <para>Adds a button with label <paramref name="text" /> and a custom <paramref name="action" /> to the dialog and returns the created button. <paramref name="action" /> will be passed to the <see cref="AcceptDialog.CustomAction" /> signal when pressed.</para>
    /// <para>If <c>true</c>, <paramref name="right" /> will place the button to the right of any sibling buttons.</para>
    /// <para>You can use <see cref="AcceptDialog.RemoveButton(Godot.Control)" /> method to remove a button created with this method from the dialog.</para>
    /// </summary>
    Button AddButton(string text, bool right, string action);
    /// <summary>
    /// <para>Adds a button with label <paramref name="name" /> and a cancel action to the dialog and returns the created button.</para>
    /// <para>You can use <see cref="AcceptDialog.RemoveButton(Godot.Control)" /> method to remove a button created with this method from the dialog.</para>
    /// </summary>
    Button AddCancelButton(string name);
    /// <summary>
    /// <para>Sets autowrapping for the text in the dialog.</para>
    /// </summary>
    bool DialogAutowrap { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the dialog will be hidden when the escape key (<see cref="Key.Escape" />) is pressed.</para>
    /// </summary>
    bool DialogCloseOnEscape { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, the dialog is hidden when the OK button is pressed. You can set it to <c>false</c> if you want to do e.g. input validation when receiving the <see cref="AcceptDialog.Confirmed" /> signal, and handle hiding the dialog in your own logic.</para>
    /// <para><b>Note:</b> Some nodes derived from this class can have a different default value, and potentially their own built-in logic overriding this setting. For example <see cref="FileDialog" /> defaults to <c>false</c>, and has its own input validation code that is called when you press OK, which eventually hides the dialog if the input is valid. As such, this property can't be used in <see cref="FileDialog" /> to disable hiding the dialog when pressing OK.</para>
    /// </summary>
    bool DialogHideOnOk { get; set; }
    /// <summary>
    /// <para>The text displayed by the dialog.</para>
    /// </summary>
    string DialogText { get; set; }
    /// <summary>
    /// <para>Returns the label used for built-in text.</para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash. If you wish to hide it or any of its children, use their <see cref="CanvasItem.Visible" /> property.</para>
    /// </summary>
    Label GetLabel();
    /// <summary>
    /// <para>Returns the OK <see cref="Button" /> instance.</para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash. If you wish to hide it or any of its children, use their <see cref="CanvasItem.Visible" /> property.</para>
    /// </summary>
    Button GetOkButton();
    /// <summary>
    /// <para>The text displayed by the OK button (see <see cref="AcceptDialog.GetOkButton" />).</para>
    /// </summary>
    string OkButtonText { get; set; }
    /// <summary>
    /// <para>Registers a <see cref="LineEdit" /> in the dialog. When the enter key is pressed, the dialog will be accepted.</para>
    /// </summary>
    void RegisterTextEnter(Control lineEdit);
    /// <summary>
    /// <para>Removes the <paramref name="button" /> from the dialog. Does NOT free the <paramref name="button" />. The <paramref name="button" /> must be a <see cref="Button" /> added with <see cref="AcceptDialog.AddButton(System.String,System.Boolean,System.String)" /> or <see cref="AcceptDialog.AddCancelButton(System.String)" /> method. After removal, pressing the <paramref name="button" /> will no longer emit this dialog's <see cref="AcceptDialog.CustomAction" /> or <see cref="AcceptDialog.Canceled" /> signals.</para>
    /// </summary>
    void RemoveButton(Control button);

}