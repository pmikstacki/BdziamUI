using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Model.Enums;
using Bdziam.UI.Utilities;
using Blazicons;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI.Components.CommonBase;

public abstract class BInputField<T> : BInputBase<T>
{
    [Parameter] public FieldVariant Variant { get; set; } = FieldVariant.Filled;
    [Parameter] public SvgIcon? LeadingIcon { get; set; }
    [Parameter] public bool FullWidth { get; set; }
    [Parameter] public string? SupportingText { get; set; }
    [Parameter] public SvgIcon? TrailingIcon { get; set; }

    protected string ContainerStyles => new CssStyleBuilder()
        .AddStyle("background-color",
            Variant == FieldVariant.Filled ? "var(--md-sys-color-surface-container-highest)" : "transparent")
        .AddStyle("height", "56px")
        .AddStyle("border",
            Variant == FieldVariant.Outline
                ? $"1px solid {(Error ? "var(--md-sys-color-error)" : "var(--md-sys-color-outline)")}"
                : "none")
        .AddStyle("border-radius", Variant == FieldVariant.Filled ? "4px 4px 0 0" : "4px")
        .AddStyle("padding", "8px 12px")
        .AddStyle("display", "flex")
        .AddStyle("align-items", "center")
        .AddStyle("position", "relative")
        .Build();

    protected string LabelStyles => new CssStyleBuilder()
        .AddStyle("color", Error ? "var(--md-sys-color-error)" : "var(--md-sys-color-on-surface-variant)")
        .AddStyle("position", "absolute")
        .AddStyle("top", string.IsNullOrEmpty(Value?.ToString()) ? "16px" : "4px")
        .AddStyle("font-size", string.IsNullOrEmpty(Value?.ToString()) ? "16px" : "12px")
        .AddStyle("line-height", string.IsNullOrEmpty(Value?.ToString()) ? "24px" : "16px")
        .AddStyle("transition", "top 0.2s ease, font-size 0.2s ease")
        .Build();

    protected string InputStyles => new CssStyleBuilder()
        .AddStyle("color", Error ? "var(--md-sys-color-error)" : "var(--md-sys-color-on-surface)")
        .AddStyle("font-family", "Roboto, sans-serif")
        .AddStyle("font-size", "16px")
        .AddStyle("line-height", "24px")
        .AddStyle("width", "100%")
        .AddStyle("background-color", "transparent")
        .AddStyle("border", "none")
        .AddStyle("outline", "none")
        .Build();

    protected string SupportingTextStyles => new CssStyleBuilder()
        .AddStyle("color", "var(--md-sys-color-on-surface-variant)")
        .AddStyle("font-family", "Roboto, sans-serif")
        .AddStyle("font-size", "12px")
        .AddStyle("line-height", "16px")
        .Build();

    protected string ValidationTextStyles => new CssStyleBuilder()
        .AddStyle("color", "var(--md-sys-color-error)")
        .AddStyle("font-family", "Roboto, sans-serif")
        .AddStyle("font-size", "12px")
        .AddStyle("line-height", "16px")
        .Build();
}