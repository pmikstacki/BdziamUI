using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Model.Enums;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI;

public partial class BStack : BComponentBase
{
    [Parameter] public RenderFragment? ChildContent { get; set; }
    [Parameter] public Orientation Orientation { get; set; } = Orientation.Vertical;
    [Parameter] public Size Spacing { get; set; } = Size.Medium;
    [Parameter] public Size Padding { get; set; } = Size.Medium;
    [Parameter] public Size ItemMargin { get; set; } = Size.None;

    private string ContainerClasses => Orientation switch
    {
        Orientation.Horizontal => $"flex flex-row space-x-{(int)Spacing} p-{(int)Padding}",
        _ => $"flex flex-col space-y-{(int)Spacing} p-{(int)Padding}"
    };

    private string ItemClasses => ItemMargin != Size.None ? $"m-{(int)ItemMargin}" : string.Empty;
}