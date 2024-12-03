using System.Drawing;
using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Model.Enums;
using Bdziam.UI.Model.Utility;
using Bdziam.UI.Utilities;
using Blazicons;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI;

public partial class BTab : BComponentBase
{
    [CascadingParameter] private BTabs? Parent { get; set; }

    [Parameter] public string Header { get; set; } = string.Empty;
    [Parameter] public RenderFragment? ChildContent { get; set; }
    [Parameter] public SvgIcon? Icon { get; set; }
    [Parameter] public bool Disabled { get; set; } = false;

    public bool IsActive => Parent != null && Parent.ActiveTab == this;

    internal string TabStyles => new CssStyleBuilder()
        .AddStyle("display" ,"flex")
        .AddStyle("align-items" ,"center")
        .AddStyle("justify-content" ,"center")
        .AddStyle("padding", "0.5rem 1rem")
        .AddStyle("overflow", "hidden")
        .AddStyle("position", "relative")
        .AddStyle("color", Disabled ? ColorUtility.GetColorVariable(MaterialColor.SurfaceDim) : IsActive ? ColorUtility.GetColorVariable(Parent.MaterialColor) : ColorUtility.GetTextColorVariable(ColorUtility.GetContainerVariant(Parent.MaterialColor)))
        .AddStyle("font-weight", Disabled ? "normal" : IsActive ? "semibold" : "normal" )
        .AddStyle("border-radius", "0")
        .AddStyle("background-color","transparent")
        .AddStyle("cursor", Disabled ? "not-allowed" : "pointer")
        .Build();
    public BRipple? Ripple { get; set; }
    public BPillRipple? PillRipple { get; set; }

    internal string TabTextStyle => new CssStyleBuilder()
        .AddStyle("color", Disabled ? ColorUtility.GetTextColorVariable(Parent.MaterialColor) : IsActive ? ColorUtility.GetColorVariable(Parent.MaterialColor)  :   ColorUtility.GetTextColorVariable(ColorUtility.GetContainerVariant(Parent.MaterialColor)))
        .AddStyle("z-index","3")
        .Build();
    protected override void OnInitialized()
    {
        Parent?.AddPage(this);
        base.OnInitialized();
    }

    private void HandleClick()
    {
        if (!Disabled && Parent != null)
        {
            Parent.ActiveTab = this;
        }
    }
}