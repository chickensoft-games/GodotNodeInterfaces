 namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para><see cref="CharacterBody3D" /> is a specialized class for physics bodies that are meant to be user-controlled. They are not affected by physics at all, but they affect other physics bodies in their path. They are mainly used to provide high-level API to move objects with wall and slope detection (<see cref="CharacterBody3D.MoveAndSlide" /> method) in addition to the general collision detection provided by <see cref="PhysicsBody3D.MoveAndCollide(Godot.Vector3,System.Boolean,System.Single,System.Boolean,System.Int32)" />. This makes it useful for highly configurable physics bodies that must move in specific ways and collide with the world, as is often the case with user-controlled characters.</para>
/// <para>For game objects that don't require complex movement or collision detection, such as moving platforms, <see cref="AnimatableBody3D" /> is simpler to configure.</para>
/// </summary>
public class CharacterBody3DAdapter : CharacterBody3D, ICharacterBody3D {
  private readonly CharacterBody3D _node;

  public CharacterBody3DAdapter(CharacterBody3D node) => _node = node;
    /// <summary>
    /// <para>Allows to manually apply a snap to the floor regardless of the body's velocity. This function does nothing when <see cref="CharacterBody3D.IsOnFloor" /> returns <c>true</c>.</para>
    /// </summary>
    public void ApplyFloorSnap() => _node.ApplyFloorSnap();
    /// <summary>
    /// <para>If <c>true</c>, the body will be able to move on the floor only. This option avoids to be able to walk on walls, it will however allow to slide down along them.</para>
    /// </summary>
    public bool FloorBlockOnWall { get => _node.FloorBlockOnWall; set => _node.FloorBlockOnWall = value; }
    /// <summary>
    /// <para>If <c>false</c> (by default), the body will move faster on downward slopes and slower on upward slopes.</para>
    /// <para>If <c>true</c>, the body will always move at the same speed on the ground no matter the slope. Note that you need to use <see cref="CharacterBody3D.FloorSnapLength" /> to stick along a downward slope at constant speed.</para>
    /// </summary>
    public bool FloorConstantSpeed { get => _node.FloorConstantSpeed; set => _node.FloorConstantSpeed = value; }
    /// <summary>
    /// <para>Maximum angle (in radians) where a slope is still considered a floor (or a ceiling), rather than a wall, when calling <see cref="CharacterBody3D.MoveAndSlide" />. The default value equals 45 degrees.</para>
    /// </summary>
    public float FloorMaxAngle { get => _node.FloorMaxAngle; set => _node.FloorMaxAngle = value; }
    /// <summary>
    /// <para>Sets a snapping distance. When set to a value different from <c>0.0</c>, the body is kept attached to slopes when calling <see cref="CharacterBody3D.MoveAndSlide" />. The snapping vector is determined by the given distance along the opposite direction of the <see cref="CharacterBody3D.UpDirection" />.</para>
    /// <para>As long as the snapping vector is in contact with the ground and the body moves against <see cref="CharacterBody3D.UpDirection" />, the body will remain attached to the surface. Snapping is not applied if the body moves along <see cref="CharacterBody3D.UpDirection" />, meaning it contains vertical rising velocity, so it will be able to detach from the ground when jumping or when the body is pushed up by something. If you want to apply a snap without taking into account the velocity, use <see cref="CharacterBody3D.ApplyFloorSnap" />.</para>
    /// </summary>
    public float FloorSnapLength { get => _node.FloorSnapLength; set => _node.FloorSnapLength = value; }
    /// <summary>
    /// <para>If <c>true</c>, the body will not slide on slopes when calling <see cref="CharacterBody3D.MoveAndSlide" /> when the body is standing still.</para>
    /// <para>If <c>false</c>, the body will slide on floor's slopes when <see cref="CharacterBody3D.Velocity" /> applies a downward force.</para>
    /// </summary>
    public bool FloorStopOnSlope { get => _node.FloorStopOnSlope; set => _node.FloorStopOnSlope = value; }
    /// <summary>
    /// <para>Returns the floor's collision angle at the last collision point according to <paramref name="upDirection" />, which is <c>Vector3.UP</c> by default. This value is always positive and only valid after calling <see cref="CharacterBody3D.MoveAndSlide" /> and when <see cref="CharacterBody3D.IsOnFloor" /> returns <c>true</c>.</para>
    /// </summary>
    /// <param name="upDirection">If the parameter is null, then the default value is <c>new Vector3(0, 1, 0)</c>.</param>
    public float GetFloorAngle(Nullable<Vector3> upDirection) => _node.GetFloorAngle(upDirection);
    /// <summary>
    /// <para>Returns the surface normal of the floor at the last collision point. Only valid after calling <see cref="CharacterBody3D.MoveAndSlide" /> and when <see cref="CharacterBody3D.IsOnFloor" /> returns <c>true</c>.</para>
    /// </summary>
    public Vector3 GetFloorNormal() => _node.GetFloorNormal();
    /// <summary>
    /// <para>Returns the last motion applied to the <see cref="CharacterBody3D" /> during the last call to <see cref="CharacterBody3D.MoveAndSlide" />. The movement can be split into multiple motions when sliding occurs, and this method return the last one, which is useful to retrieve the current direction of the movement.</para>
    /// </summary>
    public Vector3 GetLastMotion() => _node.GetLastMotion();
    /// <summary>
    /// <para>Returns a <see cref="KinematicCollision3D" />, which contains information about the latest collision that occurred during the last call to <see cref="CharacterBody3D.MoveAndSlide" />.</para>
    /// </summary>
    public KinematicCollision3D GetLastSlideCollision() => _node.GetLastSlideCollision();
    /// <summary>
    /// <para>Returns the angular velocity of the platform at the last collision point. Only valid after calling <see cref="CharacterBody3D.MoveAndSlide" />.</para>
    /// </summary>
    public Vector3 GetPlatformAngularVelocity() => _node.GetPlatformAngularVelocity();
    /// <summary>
    /// <para>Returns the linear velocity of the platform at the last collision point. Only valid after calling <see cref="CharacterBody3D.MoveAndSlide" />.</para>
    /// </summary>
    public Vector3 GetPlatformVelocity() => _node.GetPlatformVelocity();
    /// <summary>
    /// <para>Returns the travel (position delta) that occurred during the last call to <see cref="CharacterBody3D.MoveAndSlide" />.</para>
    /// </summary>
    public Vector3 GetPositionDelta() => _node.GetPositionDelta();
    /// <summary>
    /// <para>Returns the current real velocity since the last call to <see cref="CharacterBody3D.MoveAndSlide" />. For example, when you climb a slope, you will move diagonally even though the velocity is horizontal. This method returns the diagonal movement, as opposed to <see cref="CharacterBody3D.Velocity" /> which returns the requested velocity.</para>
    /// </summary>
    public Vector3 GetRealVelocity() => _node.GetRealVelocity();
    /// <summary>
    /// <para>Returns a <see cref="KinematicCollision3D" />, which contains information about a collision that occurred during the last call to <see cref="CharacterBody3D.MoveAndSlide" />. Since the body can collide several times in a single call to <see cref="CharacterBody3D.MoveAndSlide" />, you must specify the index of the collision in the range 0 to (<see cref="CharacterBody3D.GetSlideCollisionCount" /> - 1).</para>
    /// </summary>
    public KinematicCollision3D GetSlideCollision(int slideIdx) => _node.GetSlideCollision(slideIdx);
    /// <summary>
    /// <para>Returns the number of times the body collided and changed direction during the last call to <see cref="CharacterBody3D.MoveAndSlide" />.</para>
    /// </summary>
    public int GetSlideCollisionCount() => _node.GetSlideCollisionCount();
    /// <summary>
    /// <para>Returns the surface normal of the wall at the last collision point. Only valid after calling <see cref="CharacterBody3D.MoveAndSlide" /> and when <see cref="CharacterBody3D.IsOnWall" /> returns <c>true</c>.</para>
    /// </summary>
    public Vector3 GetWallNormal() => _node.GetWallNormal();
    /// <summary>
    /// <para>Returns <c>true</c> if the body collided with the ceiling on the last call of <see cref="CharacterBody3D.MoveAndSlide" />. Otherwise, returns <c>false</c>. The <see cref="CharacterBody3D.UpDirection" /> and <see cref="CharacterBody3D.FloorMaxAngle" /> are used to determine whether a surface is "ceiling" or not.</para>
    /// </summary>
    public bool IsOnCeiling() => _node.IsOnCeiling();
    /// <summary>
    /// <para>Returns <c>true</c> if the body collided only with the ceiling on the last call of <see cref="CharacterBody3D.MoveAndSlide" />. Otherwise, returns <c>false</c>. The <see cref="CharacterBody3D.UpDirection" /> and <see cref="CharacterBody3D.FloorMaxAngle" /> are used to determine whether a surface is "ceiling" or not.</para>
    /// </summary>
    public bool IsOnCeilingOnly() => _node.IsOnCeilingOnly();
    /// <summary>
    /// <para>Returns <c>true</c> if the body collided with the floor on the last call of <see cref="CharacterBody3D.MoveAndSlide" />. Otherwise, returns <c>false</c>. The <see cref="CharacterBody3D.UpDirection" /> and <see cref="CharacterBody3D.FloorMaxAngle" /> are used to determine whether a surface is "floor" or not.</para>
    /// </summary>
    public bool IsOnFloor() => _node.IsOnFloor();
    /// <summary>
    /// <para>Returns <c>true</c> if the body collided only with the floor on the last call of <see cref="CharacterBody3D.MoveAndSlide" />. Otherwise, returns <c>false</c>. The <see cref="CharacterBody3D.UpDirection" /> and <see cref="CharacterBody3D.FloorMaxAngle" /> are used to determine whether a surface is "floor" or not.</para>
    /// </summary>
    public bool IsOnFloorOnly() => _node.IsOnFloorOnly();
    /// <summary>
    /// <para>Returns <c>true</c> if the body collided with a wall on the last call of <see cref="CharacterBody3D.MoveAndSlide" />. Otherwise, returns <c>false</c>. The <see cref="CharacterBody3D.UpDirection" /> and <see cref="CharacterBody3D.FloorMaxAngle" /> are used to determine whether a surface is "wall" or not.</para>
    /// </summary>
    public bool IsOnWall() => _node.IsOnWall();
    /// <summary>
    /// <para>Returns <c>true</c> if the body collided only with a wall on the last call of <see cref="CharacterBody3D.MoveAndSlide" />. Otherwise, returns <c>false</c>. The <see cref="CharacterBody3D.UpDirection" /> and <see cref="CharacterBody3D.FloorMaxAngle" /> are used to determine whether a surface is "wall" or not.</para>
    /// </summary>
    public bool IsOnWallOnly() => _node.IsOnWallOnly();
    /// <summary>
    /// <para>Maximum number of times the body can change direction before it stops when calling <see cref="CharacterBody3D.MoveAndSlide" />.</para>
    /// </summary>
    public int MaxSlides { get => _node.MaxSlides; set => _node.MaxSlides = value; }
    /// <summary>
    /// <para>Sets the motion mode which defines the behavior of <see cref="CharacterBody3D.MoveAndSlide" />. See <see cref="CharacterBody3D.MotionModeEnum" /> constants for available modes.</para>
    /// </summary>
    public CharacterBody3D.MotionModeEnum MotionMode { get => _node.MotionMode; set => _node.MotionMode = value; }
    /// <summary>
    /// <para>Moves the body based on <see cref="CharacterBody3D.Velocity" />. If the body collides with another, it will slide along the other body rather than stop immediately. If the other body is a <see cref="CharacterBody3D" /> or <see cref="RigidBody3D" />, it will also be affected by the motion of the other body. You can use this to make moving and rotating platforms, or to make nodes push other nodes.</para>
    /// <para>Modifies <see cref="CharacterBody3D.Velocity" /> if a slide collision occurred. To get the latest collision call <see cref="CharacterBody3D.GetLastSlideCollision" />, for more detailed information about collisions that occurred, use <see cref="CharacterBody3D.GetSlideCollision(System.Int32)" />.</para>
    /// <para>When the body touches a moving platform, the platform's velocity is automatically added to the body motion. If a collision occurs due to the platform's motion, it will always be first in the slide collisions.</para>
    /// <para>Returns <c>true</c> if the body collided, otherwise, returns <c>false</c>.</para>
    /// </summary>
    public bool MoveAndSlide() => _node.MoveAndSlide();
    /// <summary>
    /// <para>Collision layers that will be included for detecting floor bodies that will act as moving platforms to be followed by the <see cref="CharacterBody3D" />. By default, all floor bodies are detected and propagate their velocity.</para>
    /// </summary>
    public uint PlatformFloorLayers { get => _node.PlatformFloorLayers; set => _node.PlatformFloorLayers = value; }
    /// <summary>
    /// <para>Sets the behavior to apply when you leave a moving platform. By default, to be physically accurate, when you leave the last platform velocity is applied. See <see cref="CharacterBody3D.PlatformOnLeaveEnum" /> constants for available behavior.</para>
    /// </summary>
    public CharacterBody3D.PlatformOnLeaveEnum PlatformOnLeave { get => _node.PlatformOnLeave; set => _node.PlatformOnLeave = value; }
    /// <summary>
    /// <para>Collision layers that will be included for detecting wall bodies that will act as moving platforms to be followed by the <see cref="CharacterBody3D" />. By default, all wall bodies are ignored.</para>
    /// </summary>
    public uint PlatformWallLayers { get => _node.PlatformWallLayers; set => _node.PlatformWallLayers = value; }
    /// <summary>
    /// <para>Extra margin used for collision recovery when calling <see cref="CharacterBody3D.MoveAndSlide" />.</para>
    /// <para>If the body is at least this close to another body, it will consider them to be colliding and will be pushed away before performing the actual motion.</para>
    /// <para>A higher value means it's more flexible for detecting collision, which helps with consistently detecting walls and floors.</para>
    /// <para>A lower value forces the collision algorithm to use more exact detection, so it can be used in cases that specifically require precision, e.g at very low scale to avoid visible jittering, or for stability with a stack of character bodies.</para>
    /// </summary>
    public float SafeMargin { get => _node.SafeMargin; set => _node.SafeMargin = value; }
    /// <summary>
    /// <para>If <c>true</c>, during a jump against the ceiling, the body will slide, if <c>false</c> it will be stopped and will fall vertically.</para>
    /// </summary>
    public bool SlideOnCeiling { get => _node.SlideOnCeiling; set => _node.SlideOnCeiling = value; }
    /// <summary>
    /// <para>Vector pointing upwards, used to determine what is a wall and what is a floor (or a ceiling) when calling <see cref="CharacterBody3D.MoveAndSlide" />. Defaults to <c>Vector3.UP</c>. As the vector will be normalized it can't be equal to <c>Vector3.ZERO</c>, if you want all collisions to be reported as walls, consider using <see cref="CharacterBody3D.MotionModeEnum.Floating" /> as <see cref="CharacterBody3D.MotionMode" />.</para>
    /// </summary>
    public Vector3 UpDirection { get => _node.UpDirection; set => _node.UpDirection = value; }
    /// <summary>
    /// <para>Current velocity vector (typically meters per second), used and modified during calls to <see cref="CharacterBody3D.MoveAndSlide" />.</para>
    /// </summary>
    public Vector3 Velocity { get => _node.Velocity; set => _node.Velocity = value; }
    /// <summary>
    /// <para>Minimum angle (in radians) where the body is allowed to slide when it encounters a slope. The default value equals 15 degrees. When <see cref="CharacterBody3D.MotionMode" /> is <see cref="CharacterBody3D.MotionModeEnum.Grounded" />, it only affects movement if <see cref="CharacterBody3D.FloorBlockOnWall" /> is <c>true</c>.</para>
    /// </summary>
    public float WallMinSlideAngle { get => _node.WallMinSlideAngle; set => _node.WallMinSlideAngle = value; }

}