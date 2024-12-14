using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Model.Enums;
using Blazicons;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Bdziam.UI;

public partial class BToggleButton : BButtonBase, IControlChildContent, IControlIcons, IControlIconSize
{
    [Parameter] public bool Checked { get; set; }
    [Parameter] public EventCallback<bool> CheckedChanged { get; set; }
    [Parameter] public RenderFragment? ChildContent { get; set; }
    [Parameter] public SvgIcon? StartIcon { get; set; }
    [Parameter] public SvgIcon? EndIcon { get; set; }
    [Parameter] public Size IconSize { get; set; }

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