using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Model.Enums;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI;

public class BDrawerMenuBase : BComponentBase, IControlColor
{
    [Parameter] public RenderFragment? ChildContent { get; set; }
    [Parameter] public Action<BDrawerMenuItemBase>? ActiveItemChanged { get; set; }
    [CascadingParameter] public MaterialColor Color { get; set; }
}