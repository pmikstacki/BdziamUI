using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using Bdziam.UI.Components.CommonBase;
using Blazicons;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI
{
    public partial class BToggleButton : BButtonBase, IControlChildContent, IControlIcons
    {
        [Parameter] public RenderFragment? ChildContent { get; set; }
        [Parameter] public SvgIcon? StartIcon { get; set; }
        [Parameter] public SvgIcon? EndIcon { get; set; }
        [Parameter] public bool Checked { get; set; } = false;
        [Parameter] public EventCallback<bool> CheckedChanged { get; set; }

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
}
