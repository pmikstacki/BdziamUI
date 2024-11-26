using Bdziam.UI.Components.CommonBase;
using Blazicons;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI
{
    public partial class BDrawerHeader : Components.CommonBase.BComponentBase
    {
        [Parameter] public string? Text { get; set; }
        [Parameter] public SvgIcon? Icon { get; set; }
    }
}