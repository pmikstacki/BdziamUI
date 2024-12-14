using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Model.Enums;
using Blazicons;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI;

public partial class BButton : BButtonBase, IControlChildContent, IControlIcons, IControlIconSize
{
    [Parameter] public RenderFragment? ChildContent { get; set; }
    [Parameter] public SvgIcon? StartIcon { get; set; }
    [Parameter] public SvgIcon? EndIcon { get; set; }
    [Parameter] public Size IconSize { get; set; }
}