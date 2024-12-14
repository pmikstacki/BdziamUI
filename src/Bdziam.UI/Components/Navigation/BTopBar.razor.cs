using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Model.Enums;
using Bdziam.UI.Utilities;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI;

public partial class BTopBar : BComponentBase, IControlColor
{
    [Parameter] public RenderFragment? LeftContent { get; set; }
    [Parameter] public RenderFragment? MiddleContent { get; set; }
    [Parameter] public RenderFragment? RightContent { get; set; }
    [Parameter] public Size Size { get; set; } = Size.Medium;
    [Parameter] public int Elevation { get; set; } = 0;

    private string ContainerStyles => new CssStyleBuilder()
        .AddStyle("padding", StyleUtility.GetPadding(Size))
        .AddStyle("height", StyleUtility.GetStaticHeight(Size))
        .Build(Style);

    [Parameter] public MaterialColor Color { get; set; } = MaterialColor.Primary;
}