using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Model.Enums;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI
{
    public partial class BDrawerMenuBase : BComponentBase, IControlColor
    {
        [Parameter] public RenderFragment? ChildContent { get; set; }
        [Parameter] public Action<BDrawerMenuItemBase>? ActiveItemChanged { get; set; }
        [CascadingParameter] public MdSysColor MdSysColor { get; set; }
    }
}