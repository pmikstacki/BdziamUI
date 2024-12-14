using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Model.Enums;
using Bdziam.UI.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Bdziam.UI;

public abstract class BButtonBase : BComponentBase
{
    [Parameter] public EventCallback OnClick { get; set; }
    [Parameter] public bool Disabled { get; set; }
    [Parameter] public MaterialColor Color { get; set; } = MaterialColor.Primary;
    [Parameter] public ButtonVariant Variant { get; set; } = ButtonVariant.Normal;
    [Parameter] public BorderRadius BorderRadius { get; set; } = BorderRadius.Pill;
    [Parameter] public Size HorizontalPadding { get; set; } = Size.Medium;
    [Parameter] public Size VerticalPadding { get; set; } = Size.Small;
    public BRipple? Ripple { get; set; } = null;

    protected virtual string ButtonClasses => new CssClassBuilder()
        .AddClass("bd-button")
        .AddClass("font-semibold")
        .AddClass(StyleUtility.GetRadiusClass(BorderRadius))
        .AddClass("transition-all transform flex items-center justify-center gap-1")
        .AddClass("opacity-50 cursor-not-allowed", Disabled)
        .AddClass("hover:brightness-90 hover:scale-102 active:scale-95", !Disabled)
        .AddClass(Class)
        .Build();

    protected virtual string ButtonStyles => GetVariantStyles();

    protected virtual async Task HandleClick(MouseEventArgs e)
    {
        if (!Disabled)
        {
            Ripple?.CreateRipple(e);
            await OnClick.InvokeAsync(e);
        }
    }


    protected virtual string GetVariantStyles()
    {
        var colorVariantName = Color.ToString().ToLower();

        var styleBuilder = new CssStyleBuilder()
            .AddStyle("padding",
                Variant == ButtonVariant.Outline
                    ? $"calc({StyleUtility.GetVerticalPadding(VerticalPadding)} - 2px) {StyleUtility.GetHorizontalPadding(HorizontalPadding)}"
                    : $"{StyleUtility.GetVerticalPadding(VerticalPadding)} {StyleUtility.GetHorizontalPadding(HorizontalPadding)}")
            .AddStyle("display", "flex")
            .AddStyle("flex-direction", "row");


        switch (Variant)
        {
            case ButtonVariant.Normal:
                styleBuilder
                    .AddStyle("background-color", ColorUtility.GetColorVariable(Color))
                    .AddStyle("color", ColorUtility.GetTextColorVariable(Color));
                break;
            case ButtonVariant.Outline:
                styleBuilder
                    .AddStyle("background-color", "transparent")
                    .AddStyle("border", $"2px solid {ColorUtility.GetColorVariable(Color)}")
                    .AddStyle("color", ColorUtility.GetColorVariable(Color));
                break;
            case ButtonVariant.Gradient:
                styleBuilder
                    .AddStyle("background",
                        $"linear-gradient(to right,  {ColorUtility.GetColorVariable(Color)}, {GetAlternateColorForGradient()})")
                    .AddStyle("color", ColorUtility.GetTextColorVariable(Color));
                break;
            case ButtonVariant.Text:
                styleBuilder
                    .AddStyle("background", "transparent")
                    .AddStyle("color", $"{ColorUtility.GetColorVariable(Color)}");
                break;
            default:
                styleBuilder
                    .AddStyle("background-color", ColorUtility.GetColorVariable(Color))
                    .AddStyle("color", $"{ColorUtility.GetTextColorVariable(Color)}");
                break;
        }

        return styleBuilder.Build(Style);
    }

    private string GetAlternateColorForGradient()
    {
        return Color switch
        {
            MaterialColor.Primary => ColorUtility.GetColorVariable(MaterialColor.Secondary),
            MaterialColor.Secondary => ColorUtility.GetColorVariable(MaterialColor.Primary),
            MaterialColor.Tertiary => ColorUtility.GetColorVariable(MaterialColor.Secondary),
            MaterialColor.Surface => ColorUtility.GetColorVariable(MaterialColor.SurfaceContainer),
            MaterialColor.SurfaceContainer => ColorUtility.GetColorVariable(MaterialColor.Surface),
            MaterialColor.Info => ColorUtility.GetColorVariable(MaterialColor.InfoContainer),
            MaterialColor.InfoContainer => ColorUtility.GetColorVariable(MaterialColor.Info),
            MaterialColor.Warning => ColorUtility.GetColorVariable(MaterialColor.WarningContainer),
            MaterialColor.WarningContainer => ColorUtility.GetColorVariable(MaterialColor.Warning),
            MaterialColor.Error => ColorUtility.GetColorVariable(MaterialColor.ErrorContainer),
            MaterialColor.ErrorContainer => ColorUtility.GetColorVariable(MaterialColor.Error),
            _ => ColorUtility.GetColorVariable(MaterialColor.Primary)
        };
    }
}