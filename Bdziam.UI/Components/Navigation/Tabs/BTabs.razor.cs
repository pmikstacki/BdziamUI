using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Components.Tabs;
using Bdziam.UI.Model.Enums;
using Bdziam.UI.Model.Utility;
using Bdziam.UI.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace Bdziam.UI;

public partial class BTabs : BComponentBase
{
    [Parameter] public RenderFragment ChildContent { get; set; } = default!;
    [Parameter] public TabVariant Variant { get; set; } = TabVariant.Primary;
    [Parameter] public Size TabIconSize { get; set; } = Size.Small;
    [Parameter] public bool DrawSeparator { get; set; } = false;
    [Parameter] public RippleVariant RippleVariant { get; set; } = RippleVariant.Pill;

    private BTab? activeTab;
    public BTab? ActiveTab
    {
        get => activeTab;
        set
        {
            if (activeTab != value)
            {
                activeTab = value;
                StateHasChanged();
            }
        }
    }

    private readonly List<BTab> Tabs = new();

    internal void AddPage(BTab tab)
    {
        Tabs.Add(tab);
        if (Tabs.Count == 1)
            ActiveTab = tab;
        StateHasChanged();
    }
    [Inject] private TabsService TabsService { get; set; } = default!;
    private string containerId = $"tabs-container-{Guid.NewGuid().ToString()}";

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender && Tabs.Count > 0)
        {
            await ActivateTab(Tabs[0], new MouseEventArgs() { ClientX = 50, ClientY = 50 });
        }
    }

    private async Task ActivateTab(BTab tab, MouseEventArgs mouseEventArgs)
    {
        ActiveTab = tab;
        Tabs.ForEach(a =>
        {
            if (a.PillRipple != null) a.PillRipple.IsActive = false;
        });
        if (tab.Ripple  != null) await tab.Ripple.CreateRipple(mouseEventArgs);
        if (tab.PillRipple  != null) tab.PillRipple.Pulsate();

        // Update active line using TabsService
        var tabId = GetTabId(tab);
        
        await TabsService.UpdateActiveLineAsync(tabId, containerId, Variant == TabVariant.Primary);
        StateHasChanged();
    }

    private string GetTabId(BTab tab) => $"tab-{Tabs.IndexOf(tab)}-{Id}";
    private string GetTabStyles(BTab tab)
    {
        return new CssStyleBuilder()
            .AddStyle("flex-grow", "1")
            .AddStyle("flex-basis", "0")
            .AddStyle("text-align", "center")
            .AddStyle("padding", "0.5rem")
            .AddStyle("color", tab.IsActive ? "var(--md-sys-color-primary)" : "var(--md-sys-color-on-surface-variant)") // Updated icon color
            .Build(tab.TabStyles);
    }
    private string GetTabsContainerStyles()
    {
        return new CssStyleBuilder()
            .AddStyle("position", "relative")
            .AddStyle("display", "flex")
            .AddStyle("align-items", "stretch")
            .AddStyle("justify-content", "space-evenly")
            .AddStyle("gap", "0")
            .AddStyle("box-shadow", DrawSeparator ? "0px 1px 0px var(--md-sys-color-surface-variant)" : "none")
            .AddStyle("background-color", "var(--md-sys-color-surface)") // Updated background color
            .Build();
    }
    public string PillStyle => new CssStyleBuilder()
        .AddStyle("overflow", "hidden")
        .AddStyle("position", "relative")
        .AddStyle("display", "flex")
        .AddStyle("flex-direction", Variant == TabVariant.Primary ? "column" : "row")
        .AddStyle("border-radius", StyleUtility.GetRadiusStyle(BorderRadius.Pill))
        .Build();

    public string PillClass => new CssClassBuilder()
        .AddClass("pill px-4 py-1 items-center")
        .AddClass("gap-4", Variant == TabVariant.Secondary)
        .AddClass("gap-2", Variant == TabVariant.Primary)
        .Build();
    
    
    public string PillTextStyle => new CssStyleBuilder()
        .AddStyle("overflow", "hidden")
        .AddStyle("position", "relative")
        .AddStyle("display", "flex")
        .AddStyle("flex-direction", Variant == TabVariant.Primary ? "column" : "row")
        .AddStyle("border-radius", StyleUtility.GetRadiusStyle(BorderRadius.Pill))
        .Build();

    public string PillTextClass => new CssClassBuilder()
        .AddClass("pill px-4 items-center")
        .Build();
    private string GetActiveLineStyles()
    {
        if (ActiveTab == null)
        {
            return "width: 0; transform: scaleX(0);";
        }

        var index = Tabs.IndexOf(ActiveTab);
        if (index == -1) return "width: 0; transform: scaleX(0);";

        // Calculate left offset and width based on the active tab
        var leftOffset = 0;
        for (var i = 0; i < index; i++)
        {
            leftOffset += GetTabWidth(Tabs[i]);
        }

        var activeWidth = GetTabWidth(ActiveTab);

        return new CssStyleBuilder()
            .AddStyle("left", $"{leftOffset}px")
            .AddStyle("width", $"{activeWidth}px")
            .AddStyle("transform", "scaleX(1)")
            .AddStyle("z-index", "222")
            .Build();
    }

    private int GetPillRipleWidth(BTab tab) =>
        (tab.Icon != null ? GetTabWidth(tab) + 50 : GetTabWidth(tab) + 10);
    
    private int GetPillRipleLeft(BTab tab) =>
        tab.Icon != null ? -GetPillRipleWidth(tab)/10 : -GetPillRipleWidth(tab)/5;
    private int GetTabWidth(BTab tab)
    {
        // Calculate the width dynamically, e.g., using a measurement utility or predefined sizes.
        // Placeholder: adjust the width calculation to match actual tab measurements in pixels.
        var textLength = tab.Header?.Length ?? 0;
        return 8 * textLength + 16; // Example: 8px per character + 16px padding.
    }

}