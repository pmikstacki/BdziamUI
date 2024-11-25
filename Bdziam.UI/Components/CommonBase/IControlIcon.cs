using Blazicons;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI.Components.CommonBase;

public interface IControlIcon
{
    [Parameter] public SvgIcon? Icon { get; set; }
}