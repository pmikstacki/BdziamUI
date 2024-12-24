using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Interop;
using Bdziam.UI.Model.Enums;
using Bdziam.UI.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Bdziam.UI;

public partial class BDrawerMenuItem : BDrawerMenuItemBase, IControlChildContent
{
    private double expandedHeight;
    [Parameter] public string? BadgeText { get; set; }

    [CascadingParameter] public BDrawerMenuItem? Parent { get; set; }

    [Parameter] public bool IsExpanded { get; set; }

    [Parameter] public string? Uri { get; set; }
    [Inject] private NavigationManager NavigationManager { get; set; }
    [Inject] private ElementSizeService ElementSizeService { get; set; }
    [Parameter] public BDrawerMenu? ComposedMenu { get; set; }
    private bool HasChildren => ChildContent != null;

    private Dictionary<string, object> IconAttributes => new()
    {
        ["style"] = new CssStyleBuilder()
            .AddStyle("width", "1.5rem")
            .AddStyle("height", "1.5rem")
            .AddStyle("color", ColorUtility.GetTextColorVariable(MaterialColor.SurfaceVariant), !IsActive)
            .AddStyle("color", ColorUtility.GetTextColorVariable(MaterialColor.Secondary), IsActive)
            .Build()
    };

    private Dictionary<string, object> ArrowIconAttributes => new()
    {
        ["style"] = new CssStyleBuilder()
            .AddStyle("width", "1.5rem")
            .AddStyle("height", "1.5rem")
            .AddStyle("color", ColorUtility.GetTextColorVariable(MaterialColor.SurfaceVariant), !IsActive)
            .AddStyle("color", ColorUtility.GetTextColorVariable(MaterialColor.Secondary), IsActive)
            .AddStyle("transform", IsExpanded ? "rotate(90deg)" : "rotate(0deg)")
            .AddStyle("transition", MotionUtility.ConstructTransition(Motion.EasingEmphasized, 0.2, "transform"))
            .Build()
    };

    private string MenuItemStyles => new CssStyleBuilder()
        .AddStyle("overflow: hidden")
        .AddStyle("background-color", "transparent")
        .AddStyle("color", ColorUtility.GetTextColorVariable(MaterialColor.SurfaceVariant), !IsActive)
        .AddStyle("color", ColorUtility.GetTextColorVariable(MaterialColor.Secondary), IsActive)
        .Build();

    private string ChildContentStyle => new CssStyleBuilder()
        .AddStyle("max-height", IsExpanded ? $"{ExpandedHeight}px" : "0px")
        .AddStyle("overflow", "hidden")
        .AddStyle("transition", MotionUtility.ConstructTransition(Motion.EasingEmphasized, 0.3, "max-height"))
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

    public BPillRipple PillRipple { get; set; }

    [Parameter] public RenderFragment? ChildContent { get; set; }


    public void Refresh(double expandedHeight)
    {
        ExpandedHeight += expandedHeight;
        if (Parent != null) Parent.ExpandedHeight += ExpandedHeight;
        StateHasChanged();
    }

    protected override void OnInitialized()
    {
        IsActive = false;
        var menu = ComposedMenu ?? CascadedMenu;
        if (menu == null) return;
        menu.NavigationChanged += newUri =>
        {
            if (newUri == Uri)
            {
                IsActive = true;
                StateHasChanged();
                return;
            }

            IsActive = false;
            StateHasChanged();
        };
    }

    private async Task HandleClick(MouseEventArgs eventArgs)
    {
        if (HasChildren)
        {
            IsExpanded = !IsExpanded;

            if (IsExpanded)
            {
                // Measure the child container height when expanded
                var size = await ElementSizeService.GetElementSizeAsync(ChildContainerId);
                ExpandedHeight = size?.Height ?? 0;
            }
            else
            {
                ExpandedHeight = 0;
            }

            StateHasChanged();
            return;
        }

        if (!string.IsNullOrEmpty(Uri)) NavigationManager.NavigateTo(UrlExtensions.Combine(NavigationManager.BaseUri, Uri));
    }
}