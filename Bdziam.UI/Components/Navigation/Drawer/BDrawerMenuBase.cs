using Bdziam.UI.Components.CommonBase;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI
{
    public partial class BDrawerMenuBase : BComponentBase
    {
        [Parameter] public RenderFragment? ChildContent { get; set; }
        [Parameter] public Action<BDrawerMenuItemBase>? ActiveItemChanged { get; set; }
    }
}