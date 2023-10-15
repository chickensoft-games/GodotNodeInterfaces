namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para><see cref="FileDialog" /> is a preset dialog used to choose files and directories in the filesystem. It supports filter masks. <see cref="FileDialog" /> automatically sets its window title according to the <see cref="FileDialog.FileMode" />. If you want to use a custom title, disable this by setting <see cref="FileDialog.ModeOverridesTitle" /> to <c>false</c>.</para>
/// </summary>
public class FileDialogAdapter : ConfirmationDialogAdapter, IFileDialog {
  private readonly FileDialog _node;

  public FileDialogAdapter(Node node) : base(node) {
    if (node is not FileDialog typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a FileDialog"
      );
    }
    _node = typedNode;
  }

    /// <summary>
    /// <para>The file system access scope. See <see cref="FileDialog.AccessEnum" /> constants.</para>
    /// <para><b>Warning:</b> Currently, in sandboxed environments such as Web builds or sandboxed macOS apps, FileDialog cannot access the host file system. See <a href="https://github.com/godotengine/godot-proposals/issues/1123">godot-proposals#1123</a>.</para>
    /// </summary>
    public FileDialog.AccessEnum Access { get => _node.Access; set => _node.Access = value; }
    /// <summary>
    /// <para>Adds a comma-delimited file name <paramref name="filter" /> option to the <see cref="FileDialog" /> with an optional <paramref name="description" />, which restricts what files can be picked.</para>
    /// <para>A <paramref name="filter" /> should be of the form <c>"filename.extension"</c>, where filename and extension can be <c>*</c> to match any string. Filters starting with <c>.</c> (i.e. empty filenames) are not allowed.</para>
    /// <para>For example, a <paramref name="filter" /> of <c>"*.png, *.jpg"</c> and a <paramref name="description" /> of <c>"Images"</c> results in filter text "Images (*.png, *.jpg)".</para>
    /// </summary>
    public void AddFilter(string filter, string description) => _node.AddFilter(filter, description);
    /// <summary>
    /// <para>Clear all the added filters in the dialog.</para>
    /// </summary>
    public void ClearFilters() => _node.ClearFilters();
    /// <summary>
    /// <para>The current working directory of the file dialog.</para>
    /// </summary>
    public string CurrentDir { get => _node.CurrentDir; set => _node.CurrentDir = value; }
    /// <summary>
    /// <para>The currently selected file of the file dialog.</para>
    /// </summary>
    public string CurrentFile { get => _node.CurrentFile; set => _node.CurrentFile = value; }
    /// <summary>
    /// <para>The currently selected file path of the file dialog.</para>
    /// </summary>
    public string CurrentPath { get => _node.CurrentPath; set => _node.CurrentPath = value; }
    /// <summary>
    /// <para>Clear all currently selected items in the dialog.</para>
    /// </summary>
    public void DeselectAll() => _node.DeselectAll();
    /// <summary>
    /// <para>The dialog's open or save mode, which affects the selection behavior. See <see cref="FileDialog.FileModeEnum" />.</para>
    /// </summary>
    public FileDialog.FileModeEnum FileMode { get => _node.FileMode; set => _node.FileMode = value; }
    /// <summary>
    /// <para>The available file type filters. For example, this shows only <c>.png</c> and <c>.gd</c> files: <c>set_filters(PackedStringArray(["*.png ; PNG Images","*.gd ; GDScript Files"]))</c>. Multiple file types can also be specified in a single filter. <c>"*.png, *.jpg, *.jpeg ; Supported Images"</c> will show both PNG and JPEG files when selected.</para>
    /// </summary>
    public string[] Filters { get => _node.Filters; set => _node.Filters = value; }
    /// <summary>
    /// <para>Returns the LineEdit for the selected file.</para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash. If you wish to hide it or any of its children, use their <see cref="CanvasItem.Visible" /> property.</para>
    /// </summary>
    public LineEdit GetLineEdit() => _node.GetLineEdit();
    /// <summary>
    /// <para>Returns the vertical box container of the dialog, custom controls can be added to it.</para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash. If you wish to hide it or any of its children, use their <see cref="CanvasItem.Visible" /> property.</para>
    /// </summary>
    public VBoxContainer GetVBox() => _node.GetVBox();
    /// <summary>
    /// <para>Invalidate and update the current dialog content list.</para>
    /// </summary>
    public void Invalidate() => _node.Invalidate();
    /// <summary>
    /// <para>If <c>true</c>, changing the <see cref="FileDialog.FileMode" /> property will set the window title accordingly (e.g. setting <see cref="FileDialog.FileMode" /> to <see cref="FileDialog.FileModeEnum.OpenFile" /> will change the window title to "Open a File").</para>
    /// </summary>
    public bool ModeOverridesTitle { get => _node.ModeOverridesTitle; set => _node.ModeOverridesTitle = value; }
    /// <summary>
    /// <para>If non-empty, the given sub-folder will be "root" of this <see cref="FileDialog" />, i.e. user won't be able to go to its parent directory.</para>
    /// </summary>
    public string RootSubfolder { get => _node.RootSubfolder; set => _node.RootSubfolder = value; }
    /// <summary>
    /// <para>If <c>true</c>, the dialog will show hidden files.</para>
    /// </summary>
    public bool ShowHiddenFiles { get => _node.ShowHiddenFiles; set => _node.ShowHiddenFiles = value; }
    /// <summary>
    /// <para>If <c>true</c>, <see cref="FileDialog.Access" /> is set to <see cref="FileDialog.AccessEnum.Filesystem" />, and it is supported by the current <see cref="DisplayServer" />, OS native dialog will be used instead of custom one.</para>
    /// <para><b>Note:</b> On macOS, sandboxed apps always use native dialogs to access host filesystem.</para>
    /// </summary>
    public bool UseNativeDialog { get => _node.UseNativeDialog; set => _node.UseNativeDialog = value; }

}