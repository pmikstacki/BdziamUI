using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Model.Enums;
using Bdziam.UI.Utilities;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI;

public partial class BProgress : BComponentBase
{
    [Parameter] public ProgressIndicatorVariant Variant { get; set; } = ProgressIndicatorVariant.Linear;
    [Parameter] public bool Indeterminate { get; set; } = false;
    [Parameter] public double Progress { get; set; } = 0; // For determinate progress
    [Parameter] public MaterialColor IndicatorColor { get; set; } = MaterialColor.Primary;

    // Styles
    protected string ProgressContainerStyles => new CssStyleBuilder()
        .AddStyle("height", Variant == ProgressIndicatorVariant.Linear ? "4px" : "100px")
        .AddStyle("width", "100%")
        .AddStyle("background-color", Variant == ProgressIndicatorVariant.Linear ? ColorUtility.GetColorVariable(MaterialColor.SecondaryContainer) : "transparent")
        .AddStyle("border-radius", "2px", Variant == ProgressIndicatorVariant.Linear)
        .Build();

    protected string DeterminateStyles => new CssStyleBuilder()
        .AddStyle("width", $"{Math.Clamp(Progress*100, 0, 100)}%")
        .AddStyle("height", "100%")
        .AddStyle("background-color", ColorUtility.GetColorVariable(IndicatorColor))
        .AddStyle("transition", "width 0.3s linear")
        .Build();

    protected string IndeterminateStyles => new CssStyleBuilder()
        .AddStyle("position", "absolute")
        .AddStyle("background-color", ColorUtility.GetColorVariable(IndicatorColor))
        .AddStyle("animation", "indeterminate 2.1s cubic-bezier(0.65, 0.815, 0.735, 0.395) infinite")
        .Build();

    protected string CircularContainerStyles => new CssStyleBuilder()
        .AddStyle("animation", Indeterminate ? "rotate 2s linear infinite" : "none")
        .AddStyle("width", "48px")
        .AddStyle("height", "48px")
        .Build();

    protected string CircularPathStyles => new CssStyleBuilder()
        .AddStyle("stroke", ColorUtility.GetColorVariable(IndicatorColor))
        .AddStyle("stroke-dasharray", Indeterminate ? "1, 200" : $"{Math.PI * 2 * 20}, 200") // Progress in determinate mode
        .AddStyle("stroke-dashoffset", Indeterminate ? "0" : $"{Math.Clamp(1 - Progress / 100, 0, 1) * Math.PI * 2 * 20}")
        .AddStyle("stroke-width", "3")
        .AddStyle("stroke-linecap", "round")
        .AddStyle("animation", Indeterminate ? "dash 1.5s ease-in-out infinite" : "none")
        .Build();
}
