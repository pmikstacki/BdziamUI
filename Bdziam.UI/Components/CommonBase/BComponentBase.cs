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
    
   
}