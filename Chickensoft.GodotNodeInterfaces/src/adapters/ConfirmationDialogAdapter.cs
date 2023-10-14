 namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A dialog used for confirmation of actions. This window is similar to <see cref="AcceptDialog" />, but pressing its Cancel button can have a different outcome from pressing the OK button. The order of the two buttons varies depending on the host OS.</para>
/// <para>To get cancel action, you can use:</para>
/// <para><code>
/// GetCancelButton().Pressed += Canceled;
/// </code></para>
/// </summary>
public class ConfirmationDialogAdapter : ConfirmationDialog, IConfirmationDialog {
  private readonly ConfirmationDialog _node;

  public ConfirmationDialogAdapter(ConfirmationDialog node) => _node = node;
    /// <summary>
    /// <para>The text displayed by the cancel button (see <see cref="ConfirmationDialog.GetCancelButton" />).</para>
    /// </summary>
    public string CancelButtonText { get => _node.CancelButtonText; set => _node.CancelButtonText = value; }
    /// <summary>
    /// <para>Returns the cancel button.</para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash. If you wish to hide it or any of its children, use their <see cref="CanvasItem.Visible" /> property.</para>
    /// </summary>
    public Button GetCancelButton() => _node.GetCancelButton();

}