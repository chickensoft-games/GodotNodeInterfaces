namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;

public class ImporterMeshInstance3DAdapter : Node3DAdapter, IImporterMeshInstance3D {
  private readonly ImporterMeshInstance3D _node;

  public ImporterMeshInstance3DAdapter(ImporterMeshInstance3D node) : base(node) { _node = node; }


    public GeometryInstance3D.ShadowCastingSetting CastShadow { get => _node.CastShadow; set => _node.CastShadow = value; }

    public uint LayerMask { get => _node.LayerMask; set => _node.LayerMask = value; }

    public ImporterMesh Mesh { get => _node.Mesh; set => _node.Mesh = value; }

    public NodePath SkeletonPath { get => _node.SkeletonPath; set => _node.SkeletonPath = value; }

    public Skin Skin { get => _node.Skin; set => _node.Skin = value; }

    public float VisibilityRangeBegin { get => _node.VisibilityRangeBegin; set => _node.VisibilityRangeBegin = value; }

    public float VisibilityRangeBeginMargin { get => _node.VisibilityRangeBeginMargin; set => _node.VisibilityRangeBeginMargin = value; }

    public float VisibilityRangeEnd { get => _node.VisibilityRangeEnd; set => _node.VisibilityRangeEnd = value; }

    public float VisibilityRangeEndMargin { get => _node.VisibilityRangeEndMargin; set => _node.VisibilityRangeEndMargin = value; }

    public GeometryInstance3D.VisibilityRangeFadeModeEnum VisibilityRangeFadeMode { get => _node.VisibilityRangeFadeMode; set => _node.VisibilityRangeFadeMode = value; }

}