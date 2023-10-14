namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class ImporterMeshInstance3DNode : ImporterMeshInstance3D, IImporterMeshInstance3D { }


public interface IImporterMeshInstance3D : INode3D {

    GeometryInstance3D.ShadowCastingSetting CastShadow { get; set; }

    uint LayerMask { get; set; }

    ImporterMesh Mesh { get; set; }

    NodePath SkeletonPath { get; set; }

    Skin Skin { get; set; }

    float VisibilityRangeBegin { get; set; }

    float VisibilityRangeBeginMargin { get; set; }

    float VisibilityRangeEnd { get; set; }

    float VisibilityRangeEndMargin { get; set; }

    GeometryInstance3D.VisibilityRangeFadeModeEnum VisibilityRangeFadeMode { get; set; }

}