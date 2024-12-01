using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Model.Enums;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI;
public partial class BSpacer : BComponentBase
{
    [Parameter] public Size Size { get; set; } = Size.Medium;

    private string SpacerClasses => Size switch
    {
        Size.Small => "w-2",
        Size.Medium => "w-4",
        Size.Large => "w-8",
        _ => "w-4"
    };
}