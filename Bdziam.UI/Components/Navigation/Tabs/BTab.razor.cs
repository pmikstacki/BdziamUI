using Bdziam.UI.Components.CommonBase;
using Blazicons;
using Microsoft.AspNetCore.Components;
namespace Bdziam.UI;

public partial class BTab : BTabBase
{
    [CascadingParameter] protected BTabs? ParentTabs { get; set; }
    [Parameter] public string Header { get; set; } = string.Empty;
    [Parameter] public SvgIcon? Icon { get; set; }
    [Parameter] public bool CanClose { get; set; } = false;
    [Parameter] public RenderFragment? ChildContent { get; set; }
    [Parameter] public EventCallback OnClose { get; set; }

    public BRipple? Ripple { get; set; }
    public bool IsActive => ParentTabs?.ActiveTab == this;

    protected override void OnInitialized()
    {
        base.OnInitialized();
        ParentTabs?.RegisterTab(this);
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        Ripple ??= new BRipple();
    }
}
