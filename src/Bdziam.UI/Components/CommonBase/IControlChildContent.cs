using Microsoft.AspNetCore.Components;

namespace Bdziam.UI.Components.CommonBase;

public interface IControlChildContent
{
    [Parameter] public RenderFragment? ChildContent { get; set; }
}