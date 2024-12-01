using Bdziam.UI.Components.CommonBase;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI;

public partial class BDrawerMenu : BDrawerMenuBase
{
    [Inject] NavigationManager NavigationManager { get; set; } = null!;
    public Action<string> NavigationChanged { get; set; } = null!;
    protected override void OnInitialized()
    {
        NavigationManager.RegisterLocationChangingHandler(async (location) =>
        {
                NavigationChanged?.Invoke(location.TargetLocation);
        });
    }
}