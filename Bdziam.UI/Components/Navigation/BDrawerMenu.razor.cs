using Microsoft.AspNetCore.Components;

namespace Bdziam.UI;

public partial class BDrawerMenu
{
    [Parameter] public RenderFragment? ChildContent { get; set; }
}