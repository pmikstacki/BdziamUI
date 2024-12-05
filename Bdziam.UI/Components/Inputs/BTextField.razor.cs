using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Model.Enums;
using Bdziam.UI.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Bdziam.UI;

public partial class BTextField : BInputField<string>
{
    private bool _isFocused = false;

    protected string ContainerStyles => new CssStyleBuilder()
        .AddStyle("width", "100%", FullWidth)
        .AddStyle("display", "flex")
        .AddStyle("flex-direction", "column")
        .AddStyle("position", "relative")
        .Build();

    protected string OutlineContainerStyles => new CssStyleBuilder()
        .AddStyle("display", "flex")
        .AddStyle("align-items", "center")
        .AddStyle("height", "56px")
        .AddStyle("padding", "0 12px")
        .AddStyle("border", $"1px solid {(Error ? "var(--md-sys-color-error)" : "var(--md-sys-color-outline)")}")
        .AddStyle("border-radius", "4px")
        .AddStyle("transition", "border-color 0.3s ease")
        .Build();

    protected string FilledContainerStyles => new CssStyleBuilder()
        .AddStyle("display", "flex")
        .AddStyle("align-items", "center")
        .AddStyle("background-color", "var(--md-sys-color-surface-container-highest)")
        .AddStyle("padding", "0 12px")
        .AddStyle("height", "56px")
        .AddStyle("border-radius", "4px 4px 0 0")
        .Build();

    protected string InputWrapperStyles => new CssStyleBuilder()
        .AddStyle("position", "relative")
        
        .AddStyle("align-content", "stretch ")
        .AddStyle("flex-grow", "1")
        .Build();

    protected string InputStyles => new CssStyleBuilder()
        .AddStyle("width", "100%")
        .AddStyle("height", "100%")
        .AddStyle("border", "none")
        .AddStyle("outline", "none")
        .AddStyle("background", "transparent")
        .AddStyle("padding", "16px 0 0 0")
        .AddStyle("font-size", "16px")
        .AddStyle("color", "var(--md-sys-color-on-surface)")
        .Build();

    protected string LabelStyles => new CssStyleBuilder()
        .AddStyle("position", "absolute")
        .AddStyle("left", LeadingIcon != null ? "40px" : "16px")
        .AddStyle("top", "-8px")
        .AddStyle("transform", _isFocused || !string.IsNullOrEmpty(Value) ? "translateY(-50%) scale(0.75)" : "translateY(-50%) scale(1)")
        .AddStyle("transform-origin", "top left")
        .AddStyle("transition", "all 0.2s ease")
        .AddStyle("color", Error ? "var(--md-sys-color-error)" : (_isFocused ? "var(--md-sys-color-primary)" : "var(--md-sys-color-on-surface-variant)"))
        .AddStyle("background-color", Variant == FieldVariant.Outline ? "var(--md-sys-color-surface)" : "transparent")
        .AddStyle("padding", "0 4px")
        .Build();

    protected string ActiveLineStyles => new CssStyleBuilder()
        .AddStyle("position", "absolute")
        .AddStyle("bottom", "0")
        .AddStyle("left", "0")
        .AddStyle("height", "2px")
        .AddStyle("width", "100%")
        .AddStyle("background-color", Error ? "var(--md-sys-color-error)" : "var(--md-sys-color-primary)")
        .AddStyle("transform-origin", "middle center")
        .AddStyle("transition", "transform 0.3s ease")
        .AddStyle("transform", _isFocused ? "scaleX(1)" : "scaleX(0)")
        .Build();

    protected string InactiveLineStyles => new CssStyleBuilder()
        .AddStyle("position", "absolute")
        .AddStyle("bottom", "0")
        .AddStyle("left", "0")
        .AddStyle("height", "2px")
        .AddStyle("width", "100%")
        .AddStyle("background-color", "var(--md-sys-color-surface-variant)")
        .Build();

    protected string SupportingTextStyles => new CssStyleBuilder()
        .AddStyle("margin-top", "4px")
        .AddStyle("font-size", "12px")
        .AddStyle("color", Error ? "var(--md-sys-color-error)" : "var(--md-sys-color-on-surface-variant)")
        .Build();

    protected string LeadingIconStyles => new CssStyleBuilder()
        .AddStyle("display", "flex")
        .AddStyle("align-items", "center")
        .AddStyle("justify-content", "center")
        .AddStyle("width", "24px")
        .AddStyle("height", "24px")
        .AddStyle("margin-right", "12px")
        .Build();

    protected string TrailingIconStyles => new CssStyleBuilder()
        .AddStyle("display", "flex")
        .AddStyle("align-items", "center")
        .AddStyle("justify-content", "center")
        .AddStyle("width", "24px")
        .AddStyle("height", "24px")
        .AddStyle("margin-left", "12px")
        .AddStyle("cursor", "pointer")
        .Build();

    protected void OnInput(ChangeEventArgs e)
    {
        Value = e.Value?.ToString();
        Validate();
    }

    protected void OnFocus(FocusEventArgs e)
    {
        _isFocused = true;
        StateHasChanged();
    }

    protected void OnBlur(FocusEventArgs e)
    {
        _isFocused = false;
        StateHasChanged();
    }
}
