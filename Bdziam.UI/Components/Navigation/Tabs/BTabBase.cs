using Bdziam.UI.Components.CommonBase;
using Blazicons;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI;

public abstract class BTabBase : BComponentBase
{
    [CascadingParameter] protected BTabs? ParentTabs { get; set; }
    [Parameter] public string Header { get; set; } = string.Empty;
    [Parameter] public SvgIcon? Icon { get; set; }
    [Parameter] public bool CanClose { get; set; } = false;
    [Parameter] public RenderFragment? ChildContent { get; set; }
    [Parameter] public EventCallback OnClose { get; set; }

    public BRipple? Ripple { get; set; }
    public bool IsActive => ParentTabs?.ActiveTab == this;
    public double Width { get; set; }
    public double Left { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        ParentTabs?.RegisterTab(this);
    }

    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();
        Ripple ??= new BRipple();
    }
}