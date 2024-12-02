using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Model.Enums;
using Bdziam.UI.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Bdziam.UI
{
    public abstract class BButtonBase : Components.CommonBase.BComponentBase
    {
        [Parameter] public EventCallback OnClick { get; set; }
        [Parameter] public bool Disabled { get; set; } = false;
        [Parameter] public MdSysColor MdSysColor { get; set; } = MdSysColor.Primary;
        [Parameter] public ButtonVariant Variant { get; set; } = ButtonVariant.Normal;
        [Parameter] public BorderRadius BorderRadius { get; set; } = BorderRadius.Medium;
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
            var colorVariantName = MdSysColor.ToString().ToLower();

            var styleBuilder = new CssStyleBuilder()
                .AddStyle("padding", Variant == ButtonVariant.Outline ? $"calc({StyleUtility.GetVerticalPadding(VerticalPadding)} - 2px) {StyleUtility.GetHorizontalPadding(HorizontalPadding)}" :$"{StyleUtility.GetVerticalPadding(VerticalPadding)} {StyleUtility.GetHorizontalPadding(HorizontalPadding)}")
                .AddStyle("display", "flex")
                .AddStyle("flex-direction", "row");
            
            
            switch (Variant)
            {
                case ButtonVariant.Normal:
                    styleBuilder
                        .AddStyle("background-color", ColorUtility.GetColorVariable(MdSysColor))
                        .AddStyle("color", ColorUtility.GetTextColorVariable(MdSysColor));
                    break;
                case ButtonVariant.Outline:
                    styleBuilder
                        .AddStyle("background-color", "transparent")
                        .AddStyle("border", $"2px solid {ColorUtility.GetColorVariable(MdSysColor)}")
                        .AddStyle("color", ColorUtility.GetColorVariable(MdSysColor));
                    break;
                case ButtonVariant.Gradient:
                    styleBuilder
                        .AddStyle("background", $"linear-gradient(to right,  {ColorUtility.GetColorVariable(MdSysColor)}, {GetAlternateColorForGradient()})")
                        .AddStyle("color", ColorUtility.GetTextColorVariable(MdSysColor));
                    break;
                case ButtonVariant.Text:
                    styleBuilder
                        .AddStyle("background", $"transparent")
                        .AddStyle("color", $"{ColorUtility.GetColorVariable(MdSysColor)}");
                    break;
                default:
                    styleBuilder
                        .AddStyle("background-color", ColorUtility.GetColorVariable(MdSysColor))
                        .AddStyle("color", $"{ColorUtility.GetTextColorVariable(MdSysColor)}");
                    break;
            }

            return styleBuilder.Build(Style);
        }

        private string GetAlternateColorForGradient()
        {
            return MdSysColor switch
            {
                MdSysColor.Primary => ColorUtility.GetColorVariable(MdSysColor.Secondary),
                MdSysColor.Secondary => ColorUtility.GetColorVariable(MdSysColor.Primary),
                MdSysColor.Tertiary => ColorUtility.GetColorVariable(MdSysColor.Secondary),
                MdSysColor.Surface => ColorUtility.GetColorVariable(MdSysColor.SurfaceContainer),
                MdSysColor.SurfaceContainer => ColorUtility.GetColorVariable(MdSysColor.Surface),
                MdSysColor.Info => ColorUtility.GetColorVariable(MdSysColor.InfoContainer),
                MdSysColor.InfoContainer => ColorUtility.GetColorVariable(MdSysColor.Info),
                MdSysColor.Warning => ColorUtility.GetColorVariable(MdSysColor.WarningContainer),
                MdSysColor.WarningContainer => ColorUtility.GetColorVariable(MdSysColor.Warning),
                MdSysColor.Error => ColorUtility.GetColorVariable(MdSysColor.ErrorContainer),
                MdSysColor.ErrorContainer => ColorUtility.GetColorVariable(MdSysColor.Error),
                _ => ColorUtility.GetColorVariable(MdSysColor.Primary),
            };
        }
    }
}
