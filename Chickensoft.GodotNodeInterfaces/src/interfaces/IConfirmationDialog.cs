namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class ConfirmationDialogNode : ConfirmationDialog, IConfirmationDialog { }

/// <summary>
/// <para>A dialog used for confirmation of actions. This window is similar to <see cref="AcceptDialog" />, but pressing its Cancel button can have a different outcome from pressing the OK button. The order of the two buttons varies depending on the host OS.</para>
/// <para>To get cancel action, you can use:</para>
/// <para><code>
/// GetCancelButton().Pressed += Canceled;
/// </code></para>
/// </summary>
public interface IConfirmationDialog : IAcceptDialog {
    /// <summary>
    /// <para>The text displayed by the cancel button (see <see cref="ConfirmationDialog.GetCancelButton" />).</para>
    /// </summary>
    string CancelButtonText { get; set; }
    /// <summary>
    /// <para>Returns the cancel button.</para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash. If you wish to hide it or any of its children, use their <see cref="CanvasItem.Visible" /> property.</para>
    /// </summary>
    Button GetCancelButton();

}