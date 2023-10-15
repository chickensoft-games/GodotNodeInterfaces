namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
using Godot.Collections;
/// <summary>
/// <para><see cref="Camera3D" /> is a special node that displays what is visible from its current location. Cameras register themselves in the nearest <see cref="Viewport" /> node (when ascending the tree). Only one camera can be active per viewport. If no viewport is available ascending the tree, the camera will register in the global viewport. In other words, a camera just provides 3D display capabilities to a <see cref="Viewport" />, and, without one, a scene registered in that <see cref="Viewport" /> (or higher viewports) can't be displayed.</para>
/// </summary>
public class Camera3DAdapter : Node3DAdapter, ICamera3D {
  private readonly Camera3D _node;

  public Camera3DAdapter(Node node) : base(node) {
    if (node is not Camera3D typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a Camera3D"
      );
    }
    _node = typedNode;
  }

    /// <summary>
    /// <para>The <see cref="CameraAttributes" /> to use for this camera.</para>
    /// </summary>
    public CameraAttributes Attributes { get => _node.Attributes; set => _node.Attributes = value; }
    /// <summary>
    /// <para>If this is the current camera, remove it from being current. If <paramref name="enableNext" /> is <c>true</c>, request to make the next camera current, if any.</para>
    /// </summary>
    public void ClearCurrent(bool enableNext) => _node.ClearCurrent(enableNext);
    /// <summary>
    /// <para>The culling mask that describes which <see cref="VisualInstance3D.Layers" /> are rendered by this camera. By default, all 20 user-visible layers are rendered.</para>
    /// <para><b>Note:</b> Since the <see cref="Camera3D.CullMask" /> allows for 32 layers to be stored in total, there are an additional 12 layers that are only used internally by the engine and aren't exposed in the editor. Setting <see cref="Camera3D.CullMask" /> using a script allows you to toggle those reserved layers, which can be useful for editor plugins.</para>
    /// <para>To adjust <see cref="Camera3D.CullMask" /> more easily using a script, use <see cref="Camera3D.GetCullMaskValue(System.Int32)" /> and <see cref="Camera3D.SetCullMaskValue(System.Int32,System.Boolean)" />.</para>
    /// <para><b>Note:</b> <see cref="VoxelGI" />, SDFGI and <see cref="LightmapGI" /> will always take all layers into account to determine what contributes to global illumination. If this is an issue, set <see cref="GeometryInstance3D.GIMode" /> to <see cref="GeometryInstance3D.GIModeEnum.Disabled" /> for meshes and <see cref="Light3D.LightBakeMode" /> to <see cref="Light3D.BakeMode.Disabled" /> for lights to exclude them from global illumination.</para>
    /// </summary>
    public uint CullMask { get => _node.CullMask; set => _node.CullMask = value; }
    /// <summary>
    /// <para>If <c>true</c>, the ancestor <see cref="Viewport" /> is currently using this camera.</para>
    /// <para>If multiple cameras are in the scene, one will always be made current. For example, if two <see cref="Camera3D" /> nodes are present in the scene and only one is current, setting one camera's <see cref="Camera3D.Current" /> to <c>false</c> will cause the other camera to be made current.</para>
    /// </summary>
    public bool Current { get => _node.Current; set => _node.Current = value; }
    /// <summary>
    /// <para>If not <see cref="Camera3D.DopplerTrackingEnum.Disabled" />, this camera will simulate the <a href="https://en.wikipedia.org/wiki/Doppler_effect">Doppler effect</a> for objects changed in particular <c>_process</c> methods. See <see cref="Camera3D.DopplerTrackingEnum" /> for possible values.</para>
    /// </summary>
    public Camera3D.DopplerTrackingEnum DopplerTracking { get => _node.DopplerTracking; set => _node.DopplerTracking = value; }
    /// <summary>
    /// <para>The <see cref="Environment" /> to use for this camera.</para>
    /// </summary>
    public Godot.Environment Environment { get => _node.Environment; set => _node.Environment = value; }
    /// <summary>
    /// <para>The distance to the far culling boundary for this camera relative to its local Z axis. Higher values allow the camera to see further away, while decreasing <see cref="Camera3D.Far" /> can improve performance if it results in objects being partially or fully culled.</para>
    /// </summary>
    public float Far { get => _node.Far; set => _node.Far = value; }
    /// <summary>
    /// <para>The camera's field of view angle (in degrees). Only applicable in perspective mode. Since <see cref="Camera3D.KeepAspect" /> locks one axis, <see cref="Camera3D.Fov" /> sets the other axis' field of view angle.</para>
    /// <para>For reference, the default vertical field of view value (<c>75.0</c>) is equivalent to a horizontal FOV of:</para>
    /// <para>- ~91.31 degrees in a 4:3 viewport</para>
    /// <para>- ~101.67 degrees in a 16:10 viewport</para>
    /// <para>- ~107.51 degrees in a 16:9 viewport</para>
    /// <para>- ~121.63 degrees in a 21:9 viewport</para>
    /// </summary>
    public float Fov { get => _node.Fov; set => _node.Fov = value; }
    /// <summary>
    /// <para>The camera's frustum offset. This can be changed from the default to create "tilted frustum" effects such as <a href="https://zdoom.org/wiki/Y-shearing">Y-shearing</a>.</para>
    /// <para><b>Note:</b> Only effective if <see cref="Camera3D.Projection" /> is <see cref="Camera3D.ProjectionType.Frustum" />.</para>
    /// </summary>
    public Vector2 FrustumOffset { get => _node.FrustumOffset; set => _node.FrustumOffset = value; }
    /// <summary>
    /// <para>Returns the projection matrix that this camera uses to render to its associated viewport. The camera must be part of the scene tree to function.</para>
    /// </summary>
    public Projection GetCameraProjection() => _node.GetCameraProjection();
    /// <summary>
    /// <para>Returns the camera's RID from the <see cref="RenderingServer" />.</para>
    /// </summary>
    public Rid GetCameraRid() => _node.GetCameraRid();
    /// <summary>
    /// <para>Returns the transform of the camera plus the vertical (<see cref="Camera3D.VOffset" />) and horizontal (<see cref="Camera3D.HOffset" />) offsets; and any other adjustments made to the position and orientation of the camera by subclassed cameras such as <see cref="XRCamera3D" />.</para>
    /// </summary>
    public Transform3D GetCameraTransform() => _node.GetCameraTransform();
    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="Camera3D.CullMask" /> is enabled, given a <paramref name="layerNumber" /> between 1 and 20.</para>
    /// </summary>
    public bool GetCullMaskValue(int layerNumber) => _node.GetCullMaskValue(layerNumber);
    /// <summary>
    /// <para>Returns the camera's frustum planes in world space units as an array of <see cref="Plane" />s in the following order: near, far, left, top, right, bottom. Not to be confused with <see cref="Camera3D.FrustumOffset" />.</para>
    /// </summary>
    public Godot.Collections.Array<Plane> GetFrustum() => _node.GetFrustum();
    /// <summary>
    /// <para>Returns the RID of a pyramid shape encompassing the camera's view frustum, ignoring the camera's near plane. The tip of the pyramid represents the position of the camera.</para>
    /// </summary>
    public Rid GetPyramidShapeRid() => _node.GetPyramidShapeRid();
    /// <summary>
    /// <para>The horizontal (X) offset of the camera viewport.</para>
    /// </summary>
    public float HOffset { get => _node.HOffset; set => _node.HOffset = value; }
    /// <summary>
    /// <para>Returns <c>true</c> if the given position is behind the camera (the blue part of the linked diagram). <a href="https://raw.githubusercontent.com/godotengine/godot-docs/master/img/camera3d_position_frustum.png">See this diagram</a> for an overview of position query methods.</para>
    /// <para><b>Note:</b> A position which returns <c>false</c> may still be outside the camera's field of view.</para>
    /// </summary>
    public bool IsPositionBehind(Vector3 worldPoint) => _node.IsPositionBehind(worldPoint);
    /// <summary>
    /// <para>Returns <c>true</c> if the given position is inside the camera's frustum (the green part of the linked diagram). <a href="https://raw.githubusercontent.com/godotengine/godot-docs/master/img/camera3d_position_frustum.png">See this diagram</a> for an overview of position query methods.</para>
    /// </summary>
    public bool IsPositionInFrustum(Vector3 worldPoint) => _node.IsPositionInFrustum(worldPoint);
    /// <summary>
    /// <para>The axis to lock during <see cref="Camera3D.Fov" />/<see cref="Camera3D.Size" /> adjustments. Can be either <see cref="Camera3D.KeepAspectEnum.Width" /> or <see cref="Camera3D.KeepAspectEnum.Height" />.</para>
    /// </summary>
    public Camera3D.KeepAspectEnum KeepAspect { get => _node.KeepAspect; set => _node.KeepAspect = value; }
    /// <summary>
    /// <para>Makes this camera the current camera for the <see cref="Viewport" /> (see class description). If the camera node is outside the scene tree, it will attempt to become current once it's added.</para>
    /// </summary>
    public void MakeCurrent() => _node.MakeCurrent();
    /// <summary>
    /// <para>The distance to the near culling boundary for this camera relative to its local Z axis. Lower values allow the camera to see objects more up close to its origin, at the cost of lower precision across the <i>entire</i> range. Values lower than the default can lead to increased Z-fighting.</para>
    /// </summary>
    public float Near { get => _node.Near; set => _node.Near = value; }
    /// <summary>
    /// <para>The camera's projection mode. In <see cref="Camera3D.ProjectionType.Perspective" /> mode, objects' Z distance from the camera's local space scales their perceived size.</para>
    /// </summary>
    public Camera3D.ProjectionType Projection { get => _node.Projection; set => _node.Projection = value; }
    /// <summary>
    /// <para>Returns a normal vector from the screen point location directed along the camera. Orthogonal cameras are normalized. Perspective cameras account for perspective, screen width/height, etc.</para>
    /// </summary>
    public Vector3 ProjectLocalRayNormal(Vector2 screenPoint) => _node.ProjectLocalRayNormal(screenPoint);
    /// <summary>
    /// <para>Returns the 3D point in world space that maps to the given 2D coordinate in the <see cref="Viewport" /> rectangle on a plane that is the given <paramref name="zDepth" /> distance into the scene away from the camera.</para>
    /// </summary>
    public Vector3 ProjectPosition(Vector2 screenPoint, float zDepth) => _node.ProjectPosition(screenPoint, zDepth);
    /// <summary>
    /// <para>Returns a normal vector in world space, that is the result of projecting a point on the <see cref="Viewport" /> rectangle by the inverse camera projection. This is useful for casting rays in the form of (origin, normal) for object intersection or picking.</para>
    /// </summary>
    public Vector3 ProjectRayNormal(Vector2 screenPoint) => _node.ProjectRayNormal(screenPoint);
    /// <summary>
    /// <para>Returns a 3D position in world space, that is the result of projecting a point on the <see cref="Viewport" /> rectangle by the inverse camera projection. This is useful for casting rays in the form of (origin, normal) for object intersection or picking.</para>
    /// </summary>
    public Vector3 ProjectRayOrigin(Vector2 screenPoint) => _node.ProjectRayOrigin(screenPoint);
    /// <summary>
    /// <para>Based on <paramref name="value" />, enables or disables the specified layer in the <see cref="Camera3D.CullMask" />, given a <paramref name="layerNumber" /> between 1 and 20.</para>
    /// </summary>
    public void SetCullMaskValue(int layerNumber, bool value) => _node.SetCullMaskValue(layerNumber, value);
    /// <summary>
    /// <para>Sets the camera projection to frustum mode (see <see cref="Camera3D.ProjectionType.Frustum" />), by specifying a <paramref name="size" />, an <paramref name="offset" />, and the <paramref name="zNear" /> and <paramref name="zFar" /> clip planes in world space units. See also <see cref="Camera3D.FrustumOffset" />.</para>
    /// </summary>
    public void SetFrustum(float size, Vector2 offset, float zNear, float zFar) => _node.SetFrustum(size, offset, zNear, zFar);
    /// <summary>
    /// <para>Sets the camera projection to orthogonal mode (see <see cref="Camera3D.ProjectionType.Orthogonal" />), by specifying a <paramref name="size" />, and the <paramref name="zNear" /> and <paramref name="zFar" /> clip planes in world space units. (As a hint, 2D games often use this projection, with values specified in pixels.)</para>
    /// </summary>
    public void SetOrthogonal(float size, float zNear, float zFar) => _node.SetOrthogonal(size, zNear, zFar);
    /// <summary>
    /// <para>Sets the camera projection to perspective mode (see <see cref="Camera3D.ProjectionType.Perspective" />), by specifying a <paramref name="fov" /> (field of view) angle in degrees, and the <paramref name="zNear" /> and <paramref name="zFar" /> clip planes in world space units.</para>
    /// </summary>
    public void SetPerspective(float fov, float zNear, float zFar) => _node.SetPerspective(fov, zNear, zFar);
    /// <summary>
    /// <para>The camera's size in meters measured as the diameter of the width or height, depending on <see cref="Camera3D.KeepAspect" />. Only applicable in orthogonal and frustum modes.</para>
    /// </summary>
    public float Size { get => _node.Size; set => _node.Size = value; }
    /// <summary>
    /// <para>Returns the 2D coordinate in the <see cref="Viewport" /> rectangle that maps to the given 3D point in world space.</para>
    /// <para><b>Note:</b> When using this to position GUI elements over a 3D viewport, use <see cref="Camera3D.IsPositionBehind(Godot.Vector3)" /> to prevent them from appearing if the 3D point is behind the camera:</para>
    /// <para><code>
    /// # This code block is part of a script that inherits from Node3D.
    /// # `control` is a reference to a node inheriting from Control.
    /// control.visible = not get_viewport().get_camera_3d().is_position_behind(global_transform.origin)
    /// control.position = get_viewport().get_camera_3d().unproject_position(global_transform.origin)
    /// </code></para>
    /// </summary>
    public Vector2 UnprojectPosition(Vector3 worldPoint) => _node.UnprojectPosition(worldPoint);
    /// <summary>
    /// <para>The vertical (Y) offset of the camera viewport.</para>
    /// </summary>
    public float VOffset { get => _node.VOffset; set => _node.VOffset = value; }

}