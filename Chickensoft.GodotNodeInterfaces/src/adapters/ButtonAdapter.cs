namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para><see cref="Button" /> is the standard themed button. It can contain text and an icon, and it will display them according to the current <see cref="Theme" />.</para>
/// <para><b>Example of creating a button and assigning an action when pressed by code:</b></para>
/// <para><code>
/// public override void _Ready()
/// {
/// var button = new Button();
/// button.Text = "Click me";
/// button.Pressed += ButtonPressed;
/// AddChild(button);
/// }
/// private void ButtonPressed()
/// {
/// GD.Print("Hello world!");
/// }
/// </code></para>
/// <para>See also <see cref="BaseButton" /> which contains common properties and methods associated with this node.</para>
/// <para><b>Note:</b> Buttons do not interpret touch input and therefore don't support multitouch, since mouse emulation can only press one button at a given time. Use <see cref="TouchScreenButton" /> for buttons that trigger gameplay movement or actions.</para>
/// </summary>
public class ButtonAdapter : BaseButtonAdapter, IButton {
  private readonly Button _node;

  public ButtonAdapter(Node node) : base(node) {
    if (node is not Button typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a Button"
      );
    }
    _node = typedNode;
  }

    /// <summary>
    /// <para>Text alignment policy for the button's text, use one of the <see cref="HorizontalAlignment" /> constants.</para>
    /// </summary>
    public HorizontalAlignment Alignment { get => _node.Alignment; set => _node.Alignment = value; }
    /// <summary>
    /// <para>When this property is enabled, text that is too large to fit the button is clipped, when disabled the Button will always be wide enough to hold the text.</para>
    /// </summary>
    public bool ClipText { get => _node.ClipText; set => _node.ClipText = value; }
    /// <summary>
    /// <para>When enabled, the button's icon will expand/shrink to fit the button's size while keeping its aspect. See also <c>icon_max_width</c>.</para>
    /// </summary>
    public bool ExpandIcon { get => _node.ExpandIcon; set => _node.ExpandIcon = value; }
    /// <summary>
    /// <para>Flat buttons don't display decoration.</para>
    /// </summary>
    public bool Flat { get => _node.Flat; set => _node.Flat = value; }
    /// <summary>
    /// <para>Button's icon, if text is present the icon will be placed before the text.</para>
    /// <para>To edit margin and spacing of the icon, use <c>h_separation</c> theme property and <c>content_margin_*</c> properties of the used <see cref="StyleBox" />es.</para>
    /// </summary>
    public Texture2D Icon { get => _node.Icon; set => _node.Icon = value; }
    /// <summary>
    /// <para>Specifies if the icon should be aligned horizontally to the left, right, or center of a button. Uses the same <see cref="HorizontalAlignment" /> constants as the text alignment. If centered horizontally and vertically, text will draw on top of the icon.</para>
    /// </summary>
    public HorizontalAlignment IconAlignment { get => _node.IconAlignment; set => _node.IconAlignment = value; }
    /// <summary>
    /// <para>Language code used for line-breaking and text shaping algorithms, if left empty current locale is used instead.</para>
    /// </summary>
    public string Language { get => _node.Language; set => _node.Language = value; }
    /// <summary>
    /// <para>The button's text that will be displayed inside the button's area.</para>
    /// </summary>
    public string Text { get => _node.Text; set => _node.Text = value; }
    /// <summary>
    /// <para>Base text writing direction.</para>
    /// </summary>
    public Control.TextDirection TextDirection { get => _node.TextDirection; set => _node.TextDirection = value; }
    /// <summary>
    /// <para>Sets the clipping behavior when the text exceeds the node's bounding rectangle. See <see cref="TextServer.OverrunBehavior" /> for a description of all modes.</para>
    /// </summary>
    public TextServer.OverrunBehavior TextOverrunBehavior { get => _node.TextOverrunBehavior; set => _node.TextOverrunBehavior = value; }
    /// <summary>
    /// <para>Specifies if the icon should be aligned vertically to the top, bottom, or center of a button. Uses the same <see cref="VerticalAlignment" /> constants as the text alignment. If centered horizontally and vertically, text will draw on top of the icon.</para>
    /// </summary>
    public VerticalAlignment VerticalIconAlignment { get => _node.VerticalIconAlignment; set => _node.VerticalIconAlignment = value; }

}