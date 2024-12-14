using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Model.Enums;
using Bdziam.UI.Utilities;
using Blazicons;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Bdziam.UI;

public partial class BSwitch : BInput<bool>, IControlIcon
{
    [Parameter] public bool Ripple { get; set; } = true;

    /// <summary>
    ///     Styles for the track of the switch.
    /// </summary>
    protected string TrackStyles => new CssStyleBuilder()
        .AddStyle("width", "3.25rem")
        .AddStyle("height", "2rem")
        .AddStyle("border-radius", "1rem")
        .AddStyle("background-color",
            Value ? "var(--md-sys-color-primary)" : "var(--md-sys-color-surface-container-highest)")
        .AddStyle("border", Value ? "none" : "2px solid var(--md-sys-color-outline)")
        .AddStyle("transition",
            MotionUtility.ConstructTransition(Motion.EasingEmphasized, 0.3, "background-color", "border"))
        .AddStyle("cursor", Disabled ? "not-allowed" : "pointer")
        .AddStyle("position", "relative")
        .Build();

    /// <summary>
    ///     Styles for the thumb of the switch.
    /// </summary>
    protected string ThumbStyles => new CssStyleBuilder()
        .AddStyle("position", "absolute")
        .AddStyle("top", "50%")
        .AddStyle("left", "0.25rem")
        .AddStyle("transform", Value ? "translate(1.25rem, -50%)" : "translate(0, -50%)")
        .AddStyle("width", Value ? "1.5rem" : "1rem")
        .AddStyle("height", Value ? "1.5rem" : "1rem")
        .AddStyle("border-radius", "50%")
        .AddStyle("background-color", Value ? "var(--md-sys-color-on-primary)" : "var(--md-sys-color-outline)")
        .AddStyle("box-shadow", Value ? "0px 2px 4px rgba(0, 0, 0, 0.25)" : "0px 1px 2px rgba(0, 0, 0, 0.15)")
        .AddStyle("transition",
            MotionUtility.ConstructTransition(Motion.EasingEmphasized, 0.2, "transform", "width", "height",
                "background-color"))
        .AddStyle("display", "flex")
        .AddStyle("align-items", "center")
        .AddStyle("justify-content", "center")
        .AddStyle("cursor", Disabled ? "not-allowed" : "pointer")
        .Build();

    [Parameter] public SvgIcon? Icon { get; set; }

    /// <summary>
    ///     Handles the toggle behavior for the switch.
    /// </summary>
    private async Task ToggleSwitch(MouseEventArgs e)
    {
        if (!Disabled)
        {
            Value = !Value;
            await ValueChanged.InvokeAsync(Value);
            Validate();
        }
    }
}