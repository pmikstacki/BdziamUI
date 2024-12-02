using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Model.Enums;
using Bdziam.UI.Model.Utility;
using Bdziam.UI.Theming;
using Bdziam.UI.Utilities;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI;

public partial class BContainer : BComponentBase
{
    [Parameter] public RenderFragment? ChildContent { get; set; }
    [Parameter] public int Elevation { get; set; } = 0;
    [Parameter] public MdSysColor SurfaceMdSysColor { get; set; } = MdSysColor.Primary;
    [Parameter] public BorderRadius BorderRadius { get; set; } = BorderRadius.Medium;
    [Parameter] public Size Padding { get; set; } = Size.Small;
    
    private string ContainerStyle =>
        new CssStyleBuilder()
            .AddStyle("background-color",SurfaceMdSysColor == MdSysColor.Surface ? ColorUtility.GetSurfaceColorVariable(Elevation) : ColorUtility.GetColorVariable(SurfaceMdSysColor))
            .AddStyle("color", ColorUtility.GetTextColorVariable(SurfaceMdSysColor))
            .AddStyle("padding", SizeUtility.GetPadding(Padding))
            .Build(Style);

    private string ContainerClass => new CssClassBuilder()
        .AddClass(StyleUtility.GetRadiusClass(BorderRadius))
        .AddClass(Class)
        .Build();
}