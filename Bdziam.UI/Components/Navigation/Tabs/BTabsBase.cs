using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Utilities;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI;

public abstract class BTabsBase : BComponentBase
{
    [Parameter] public RenderFragment? ChildContent { get; set; }

    protected List<BTabBase> Tabs { get; private set; } = new();
    public BTabBase? ActiveTab { get; private set; }

    protected string UnderlineStyle =>
        new CssStyleBuilder()
            .AddStyle("width", $"{GetTabWidth()}px")
            .AddStyle("left", $"{GetTabLeftPosition()}px")
            .AddStyle("height", "2px")
            .AddStyle("background-color", "var(--color-primary)")
            .AddStyle("position", "absolute")
            .AddStyle("bottom", "0")
            .Build();

    private double GetTabWidth() => ActiveTab?.Width ?? 0;
    private double GetTabLeftPosition() => ActiveTab?.Left ?? 0;

    public void RegisterTab(BTabBase tab)
    {
        Tabs.Add(tab);
        if (ActiveTab == null)
        {
            ActiveTab = tab; // Automatically set the first tab as active
        }
        StateHasChanged();
    }

    protected void RemoveTab(BTabBase tab)
    {
        if (tab == ActiveTab)
        {
            var currentIndex = Tabs.IndexOf(tab);
            ActiveTab = Tabs.ElementAtOrDefault(currentIndex + 1) ?? Tabs.ElementAtOrDefault(currentIndex - 1);
        }
        Tabs.Remove(tab);
        StateHasChanged();
    }

    protected void SelectTab(BTabBase tab)
    {
        ActiveTab = tab;
        StateHasChanged();
    }

    protected void CloseTab(BTabBase tab)
    {
        RemoveTab(tab);
    }
}