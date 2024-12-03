using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Model.Enums;
using Bdziam.UI.Utilities;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI;

public partial class BTooltip : BComponentBase, IControlChildContent, IControlColor
{
    [Parameter] public RenderFragment? ChildContent { get; set; }
    [Parameter] public string TooltipText { get; set; } = string.Empty;
    [Parameter] public MaterialColor MaterialColor { get; set; }
    [Parameter] public Position Position { get; set; } = Model.Enums.Position.Top;
    private string TooltipTargetId { get; } = $"tooltip-target-{Guid.NewGuid()}";
    private bool IsTooltipVisible { get; set; } = false;

    private string TooltipStyles => new CssStyleBuilder()
        .AddStyle("padding", "8px")
        .AddStyle("font-size", "0.875rem")
        .AddStyle("line-height", "1.25rem")
        .AddStyle("color", ColorUtility.GetTextColorVariable(MaterialColor))
        .AddStyle("background-color",ColorUtility.GetContainerColorVariable(MaterialColor))
        .AddStyle("border-radius", "4px")
        .AddStyle("box-shadow", "0px 4px 6px rgba(0, 0, 0, 0.1), 0px 1px 3px rgba(0, 0, 0, 0.06);")
        .Build();

    private string TargetClasses => new CssClassBuilder()
        .AddClass("inline-flex")
        .AddClass("items-center")
        .AddClass("cursor-pointer")
        .Build();

    private void ShowTooltip() => IsTooltipVisible = true;
    private void HideTooltip() => IsTooltipVisible = false;
}