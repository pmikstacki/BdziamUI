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
    [Parameter] public MaterialColor MaterialColor { get; set; } = MaterialColor.Primary;
    [Parameter] public int Elevation { get; set; } = 0;
    [Parameter] public BorderRadius TopBarMaskBorderRadius { get; set; } = BorderRadius.Medium;
    [Parameter] public bool ShowBackgroundRoundMask { get; set; } = true;

    private string ContainerStyles => new CssStyleBuilder()
        .AddStyle("padding", StyleUtility.GetPadding(Size))
        .AddStyle("height", StyleUtility.GetStaticHeight(Size))
        .Build(Style);

    private string TopBarMaskStyles => new CssStyleBuilder()
        .AddStyle("height",  StyleUtility.GetRadiusStyle(TopBarMaskBorderRadius))
        .Build();
    
   
}