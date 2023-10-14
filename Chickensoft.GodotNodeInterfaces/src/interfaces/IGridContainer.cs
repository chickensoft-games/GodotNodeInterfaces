namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;


/// <summary>
/// <para><see cref="GridContainer" /> arranges its child controls in a grid layout. The number of columns is specified by the <see cref="GridContainer.Columns" /> property, whereas the number of rows depends on how many are needed for the child controls. The number of rows and columns is preserved for every size of the container.</para>
/// <para><b>Note:</b> <see cref="GridContainer" /> only works with child nodes inheriting from <see cref="Control" />. It won't rearrange child nodes inheriting from <see cref="Node2D" />.</para>
/// </summary>
public interface IGridContainer : IContainer {
    /// <summary>
    /// <para>The number of columns in the <see cref="GridContainer" />. If modified, <see cref="GridContainer" /> reorders its Control-derived children to accommodate the new layout.</para>
    /// </summary>
    int Columns { get; set; }

}