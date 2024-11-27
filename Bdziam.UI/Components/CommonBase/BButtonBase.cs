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
        [Parameter] public ColorVariant Color { get; set; } = ColorVariant.Primary;
        [Parameter] public ButtonVariant Variant { get; set; } = ButtonVariant.Normal;
        [Parameter] public BorderRadius BorderRadius { get; set; } = BorderRadius.Medium;
        [Parameter] public Size Size { get; set; } = Size.Medium;
        [Parameter] public Size HorizontalPadding { get; set; } = Size.Medium;
        [Parameter] public Size VerticalPadding { get; set; } = Size.Small;
        public BRipple? Ripple { get; set; } = null;
        protected virtual string ButtonClasses => new CssClassBuilder()
            .AddClass("bd-button")
            .AddClass("font-semibold")
            .AddClass(StyleUtility.GetRadiusClass(BorderRadius))
            .AddClass($"bd-button-{Size.ToString().ToLower()}")
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
                .AddStyle("padding", Variant == ButtonVariant.Outline ? $"calc({StyleUtility.GetVerticalPadding(VerticalPadding)} - 2px) {StyleUtility.GetHorizontalPadding(HorizontalPadding)}" :$"{StyleUtility.GetVerticalPadding(VerticalPadding)} {StyleUtility.GetHorizontalPadding(HorizontalPadding)}")
                .AddStyle("display", "flex")
                .AddStyle("flex-direction", "row");
            
            
            switch (Variant)
            {
                case ButtonVariant.Normal:
                    styleBuilder
                        .AddStyle("background-color", $"var(--color-{colorVariantName})")
                        .AddStyle("color", $"var(--color-{colorVariantName}-text)");
                    break;
                case ButtonVariant.Outline:
                    styleBuilder
                        .AddStyle("background-color", "transparent")
                        .AddStyle("border", $"2px solid var(--color-{colorVariantName})")
                        .AddStyle("color", $"var(--color-{colorVariantName})");
                    break;
                case ButtonVariant.Gradient:
                    styleBuilder
                        .AddStyle("background", $"linear-gradient(to right, var(--color-{colorVariantName}), var(--color-secondary))")
                        .AddStyle("color", $"var(--color-{colorVariantName}-text)");
                    break;
                case ButtonVariant.Text:
                    styleBuilder
                        .AddStyle("background", $"transparent")
                        .AddStyle("color", $"var(--color-{colorVariantName}-surface-text)");
                    break;
                default:
                    styleBuilder
                        .AddStyle("background-color", $"var(--color-{colorVariantName})")
                        .AddStyle("color", $"var(--color-{colorVariantName}-text)");
                    break;
            }

            return styleBuilder.Build(Style);
        }
        
        
    }
}
