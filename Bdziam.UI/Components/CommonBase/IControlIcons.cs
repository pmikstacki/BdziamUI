using Blazicons;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI.Components.CommonBase;

public interface IControlIcons
{
    [Parameter] public SvgIcon? StartIcon { get; set; }
    [Parameter] public SvgIcon? EndIcon { get; set; }
}