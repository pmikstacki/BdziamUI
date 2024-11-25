using Bdziam.UI.Components.CommonBase;
using Blazicons;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI
{
    public partial class BToggleIconButton : BButtonBase
    {
        [Parameter] public SvgIcon? CheckedIcon { get; set; }
        [Parameter] public SvgIcon? UncheckedIcon { get; set; }
        [Parameter] public bool Checked { get; set; } = false;
        [Parameter] public EventCallback<bool> CheckedChanged { get; set; }

        public SvgIcon Icon => Checked ? CheckedIcon : UncheckedIcon;

        private async Task ToggleState()
        {
            if (!Disabled)
            {
                Checked = !Checked;
                await CheckedChanged.InvokeAsync(Checked);
            }
        }
    }
}