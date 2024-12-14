using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Interop;
using Bdziam.UI.Model.Enums;
using Bdziam.UI.Utilities;
using Blazicons;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI;

public partial class BFoldout : BComponentBase, IControlChildContent, IControlColor
{
    private double expandedHeight;
    [Parameter] public string Header { get; set; } = string.Empty;
    [Parameter] public SvgIcon? Icon { get; set; }
    [Parameter] public SvgIcon ExpandIcon { get; set; } = GoogleMaterialFilledIcon.ChevronRight;
    [Parameter] public bool IsExpanded { get; set; }
    [CascadingParameter] public BFoldout? Parent { get; set; }

    [Inject] private ElementSizeService ElementSizeService { get; set; }

    private string HeaderStyles => new CssStyleBuilder()
        .AddStyle("background-color", ColorUtility.GetSurfaceColorVariable(0))
        .AddStyle("color", "var(--md-sys-color-on-surface-variant)")
        .AddStyle("transition", MotionUtility.ConstructTransition("all"))
        .AddStyle("border-radius", IsExpanded? $"{StyleUtility.GetRadiusStyle(BorderRadius.Large)} {StyleUtility.GetRadiusStyle(BorderRadius.Large)} 0rem 0rem" : StyleUtility.GetRadiusStyle(BorderRadius.Large))
        .AddStyle("box-shadow", "0px 1px 0px var(--md-sys-color-surface-variant)")
        .Build();

    private string ChildContentStyle => new CssStyleBuilder()
        .AddStyle("width: 100%")
        .AddStyle("max-height", IsExpanded ? $"{ExpandedHeight}px" : "0px")
        .AddStyle("overflow-y", "hidden", !IsExpanded)
        .AddStyle("transition", MotionUtility.ConstructTransition(Motion.EasingEmphasized, 0.2, "max-height"))
        .Build();


    private string ExpandIconStyle => new CssStyleBuilder()
        .AddStyle("transform", IsExpanded ? "rotate(90deg)" : "rotate(0deg)")
        .AddStyle("transition", MotionUtility.ConstructTransition(Motion.EasingEmphasized, 0.2, "transform"))
        .Build();


    private string ChildContainerId { get; } = $"child-container-{Guid.NewGuid()}";

    public double ExpandedHeight
    {
        get => expandedHeight;
        set
        {
            expandedHeight = value;
            Parent?.Refresh(ExpandedHeight);
        }
    }

    [Parameter] public RenderFragment? ChildContent { get; set; }

    [Parameter] public MaterialColor Color { get; set; } = MaterialColor.Primary;

    public void Refresh(double heightChange)
    {
        ExpandedHeight += heightChange;
        Parent?.Refresh(ExpandedHeight);
        StateHasChanged();
    }

    private async Task ToggleExpand()
    {
        IsExpanded = !IsExpanded;

        if (IsExpanded)
        {
            // Force reflow to ensure the style is applied
            _ = ElementSizeService.GetElementSizeAsync(ChildContainerId);

            var size = await ElementSizeService.GetElementSizeAsync(ChildContainerId);
            ExpandedHeight = size?.Height ?? 0;
        }
        else
        {
            ExpandedHeight = 0;
        }

        StateHasChanged();
    }
}