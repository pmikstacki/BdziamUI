using Bdziam.UI.Components.CommonBase;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI;

public partial class BMenu :Components.CommonBase.BComponentBase
{
    [Parameter] public string MenuButtonLabel { get; set; } = "Menu";
    [Parameter] public bool IsOpen { get; set; } = false;
    private string _menuButtonId = Guid.NewGuid().ToString();
    [Parameter] public EventCallback<bool> IsOpenChanged { get; set; }
    [Parameter] public RenderFragment? ChildContent { get; set; }
    [Parameter] public RenderFragment? MenuItems { get; set; }
    private string MenuButtonClasses => "bg-secondary text-secondary-text py-2 px-4 rounded cursor-pointer";
    private string MenuContainerClasses => "relative inline-block "+Class;

    private void ToggleMenu()
    {
        IsOpen = !IsOpen;
        IsOpenChanged.InvokeAsync(IsOpen);
        StateHasChanged();
    }
}