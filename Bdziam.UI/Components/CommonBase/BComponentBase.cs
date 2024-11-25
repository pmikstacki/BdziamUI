using Microsoft.AspNetCore.Components;

namespace Bdziam.UI.Components.CommonBase;

public abstract class BComponentBase : ComponentBase
{
    [Parameter] public string Class { get; set; } = string.Empty;
    [Parameter] public string Style { get; set; } = string.Empty;
    [Parameter] public string Id { get; set; } = string.Empty;
}