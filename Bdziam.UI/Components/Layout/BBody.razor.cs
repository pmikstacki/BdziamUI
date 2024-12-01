using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Model.Enums;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI;

public partial class BBody : BComponentBase
{
    [Parameter] public Size Padding { get; set; } = Size.Medium;    
    [Parameter] public RenderFragment ChildContent { get; set; }

}