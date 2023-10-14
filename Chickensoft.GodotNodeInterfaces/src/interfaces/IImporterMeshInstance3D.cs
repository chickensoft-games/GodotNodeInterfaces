namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;



public interface IImporterMeshInstance3D : INode3D {

    ImporterMesh Mesh { get; set; }

    Skin Skin { get; set; }

    NodePath SkeletonPath { get; set; }

    uint LayerMask { get; set; }

    GeometryInstance3D.ShadowCastingSetting CastShadow { get; set; }

    float VisibilityRangeBegin { get; set; }

    float VisibilityRangeBeginMargin { get; set; }

    float VisibilityRangeEnd { get; set; }

    float VisibilityRangeEndMargin { get; set; }

    GeometryInstance3D.VisibilityRangeFadeModeEnum VisibilityRangeFadeMode { get; set; }

}