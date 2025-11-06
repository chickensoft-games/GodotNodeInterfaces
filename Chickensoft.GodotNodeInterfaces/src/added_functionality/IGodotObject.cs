namespace Chickensoft.GodotNodeInterfaces;

using System;
using Godot;

public partial interface IGodotObject
{
  /// <summary>
  /// Get the underlying Godot object that the adapter is wrapping (if this is
  /// an adapter). This can be used whenever you need the actual Godot object
  /// for use with Godot API's or other code that is not aware of
  /// GodotNodeInterfaces.
  /// </summary>
  /// <typeparam name="T">The expected type of Godot object.</typeparam>
  /// <returns>The Godot object, or throws if this is not an adapter or the
  /// underlying object is not the correct type.</returns>
  T GetTargetObj<T>() where T : GodotObject
  {
    if (this is IGodotObjectAdapter adapter && adapter.TargetObj is T target)
    {
      return target;
    }
    throw new InvalidCastException(
      $"Cannot get an underlying target object from {GetType().Name} " +
      $"to {typeof(T).Name}. This can happen when a mocked Godot object " +
      "interface doesn't return a real node for scripts that need it."
    );
  }
}
