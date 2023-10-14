namespace Chickensoft.GodotNodeInterfaces;

using Godot;
/// <summary>
/// <para><see cref="MarginContainer" /> adds an adjustable margin on each side of its child controls. The margins are added around all children, not around each individual one. To control the <see cref="MarginContainer" />'s margins, use the <c>margin_*</c> theme properties listed below.</para>
/// <para><b>Note:</b> The margin sizes are theme overrides, not normal properties. This is an example of how to change them in code:</para>
/// <para><code>
/// // This code sample assumes the current script is extending MarginContainer.
/// int marginValue = 100;
/// AddThemeConstantOverride("margin_top", marginValue);
/// AddThemeConstantOverride("margin_left", marginValue);
/// AddThemeConstantOverride("margin_bottom", marginValue);
/// AddThemeConstantOverride("margin_right", marginValue);
/// </code></para>
/// </summary>
public class MarginContainerAdapter : MarginContainer, IMarginContainer {
  private readonly MarginContainer _node;

  public MarginContainerAdapter(MarginContainer node) => _node = node;

}