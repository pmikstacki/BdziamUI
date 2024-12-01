using Bdziam.UI.Interop;
using Bdziam.UI.Model.Enums;
using Bdziam.UI.Theming;
using Blazicons;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI.Components.CommonBase;

public abstract class BComponentBase : ComponentBase
{
    [Parameter] public string Class { get; set; } = string.Empty;
    [Parameter] public string Style { get; set; } = string.Empty; 
    [Parameter] public string Id { get; set; } = Guid.NewGuid().ToString();
    
    [Inject] public ElementSizeService SizeService { get; set; }

    /// <summary>
    /// Retrieves the width and height of the component using its unique ID.
    /// </summary>
    /// <returns>A tuple containing the width and height of the component, or null if unavailable.</returns>
    public DOMRect? GetElementSize()
    {
        return SizeService.GetElementSizeAsync(Id).GetAwaiter().GetResult()!;
    }
}