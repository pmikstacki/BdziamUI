using Bdziam.UI.Model.Enums;
using Blazicons;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Bdziam.UI;

public partial class BToggleIconButton : BIconButtonBase
{
    [Parameter] public SvgIcon? CheckedIcon { get; set; }
    [Parameter] public SvgIcon? UncheckedIcon { get; set; }
    [Parameter] public bool Checked { get; set; } = false;
    [Parameter] public EventCallback<bool> CheckedChanged { get; set; }

    public SvgIcon Icon => Checked ? CheckedIcon : UncheckedIcon;

    protected override void OnInitialized()
    {
        BorderRadius = BorderRadius.Pill;
        base.OnInitialized();
    }

    private async Task ToggleState(MouseEventArgs e)
    {
        if (!Disabled)
        {
            Ripple?.CreateRipple(e);
            Checked = !Checked;
            await CheckedChanged.InvokeAsync(Checked);
        }
    }
}