 namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>Counts down a specified interval and emits a signal on reaching 0. Can be set to repeat or "one-shot" mode.</para>
/// <para><b>Note:</b> Timers are affected by <see cref="Engine.TimeScale" />, a higher scale means quicker timeouts, and vice versa.</para>
/// <para><b>Note:</b> To create a one-shot timer without instantiating a node, use <see cref="SceneTree.CreateTimer(System.Double,System.Boolean,System.Boolean,System.Boolean)" />.</para>
/// </summary>
public class TimerAdapter : Timer, ITimer {
  private readonly Timer _node;

  public TimerAdapter(Timer node) => _node = node;
    /// <summary>
    /// <para>If <c>true</c>, the timer will automatically start when entering the scene tree.</para>
    /// <para><b>Note:</b> This property is automatically set to <c>false</c> after the timer enters the scene tree and starts.</para>
    /// </summary>
    public bool Autostart { get => _node.Autostart; set => _node.Autostart = value; }
    /// <summary>
    /// <para>Returns <c>true</c> if the timer is stopped.</para>
    /// </summary>
    public bool IsStopped() => _node.IsStopped();
    /// <summary>
    /// <para>If <c>true</c>, the timer will stop when reaching 0. If <c>false</c>, it will restart.</para>
    /// </summary>
    public bool OneShot { get => _node.OneShot; set => _node.OneShot = value; }
    /// <summary>
    /// <para>If <c>true</c>, the timer is paused and will not process until it is unpaused again, even if <see cref="Timer.Start(System.Double)" /> is called.</para>
    /// </summary>
    public bool Paused { get => _node.Paused; set => _node.Paused = value; }
    /// <summary>
    /// <para>Processing callback. See <see cref="Timer.TimerProcessCallback" />.</para>
    /// </summary>
    public Timer.TimerProcessCallback ProcessCallback { get => _node.ProcessCallback; set => _node.ProcessCallback = value; }
    /// <summary>
    /// <para>Starts the timer. Sets <see cref="Timer.WaitTime" /> to <paramref name="timeSec" /> if <c>time_sec &gt; 0</c>. This also resets the remaining time to <see cref="Timer.WaitTime" />.</para>
    /// <para><b>Note:</b> This method will not resume a paused timer. See <see cref="Timer.Paused" />.</para>
    /// </summary>
    public void Start(double timeSec) => _node.Start(timeSec);
    /// <summary>
    /// <para>Stops the timer.</para>
    /// </summary>
    public void Stop() => _node.Stop();
    /// <summary>
    /// <para>The timer's remaining time in seconds. Returns 0 if the timer is inactive.</para>
    /// <para><b>Note:</b> This value is read-only and cannot be set. It is based on <see cref="Timer.WaitTime" />, which can be set using <see cref="Timer.Start(System.Double)" />.</para>
    /// </summary>
    public double TimeLeft { get => _node.TimeLeft; }
    /// <summary>
    /// <para>The wait time in seconds.</para>
    /// <para><b>Note:</b> Timers can only emit once per rendered frame at most (or once per physics frame if <see cref="Timer.ProcessCallback" /> is <see cref="Timer.TimerProcessCallback.Physics" />). This means very low wait times (lower than 0.05 seconds) will behave in significantly different ways depending on the rendered framerate. For very low wait times, it is recommended to use a process loop in a script instead of using a Timer node. Timers are affected by <see cref="Engine.TimeScale" />, a higher scale means quicker timeouts, and vice versa.</para>
    /// </summary>
    public double WaitTime { get => _node.WaitTime; set => _node.WaitTime = value; }

}