using System.Drawing;
using System.Runtime.InteropServices.JavaScript;
using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Model.Enums;
using Bdziam.UI.Services;
using Bdziam.UI.Utilities;
using Blazicons;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI;

public partial class BInputView : BComponentBase
{
    [Parameter] public string Label { get; set; } = string.Empty;
    [Parameter] public EventCallback<string> LabelChanged { get; set; }

    [Parameter] public string InputId { get; set; } = string.Empty;

    [Parameter] public bool FullWidth { get; set; }
    [Parameter] public EventCallback<bool> FullWidthChanged { get; set; }
    
    [Parameter] public bool Disabled { get; set; }
    [Parameter] public EventCallback<bool> DisabledChanged { get; set; }

    [Parameter] public RenderFragment ChildContent { get; set; }

    [Parameter] public FieldVariant Variant { get; set; } = FieldVariant.Filled;
    [Parameter] public EventCallback<FieldVariant> VariantChanged { get; set; }

    [Parameter] public SvgIcon? LeadingIcon { get; set; }
    [Parameter] public EventCallback<SvgIcon?> LeadingIconChanged { get; set; }

    [Parameter] public string? SupportingText { get; set; }
    [Parameter] public EventCallback<string?> SupportingTextChanged { get; set; }

    [Parameter] public SvgIcon? TrailingIcon { get; set; }
    [Parameter] public EventCallback<SvgIcon?> TrailingIconChanged { get; set; }

    [Parameter] public bool IsFocused { get; set; }
    [Parameter] public EventCallback<bool> IsFocusedChanged { get; set; }
    
    [Parameter] public bool IsFilled { get; set; }
    [Parameter] public EventCallback<bool> IsFilledChanged { get; set; }

    [Parameter] public bool IsError { get; set; }
    [Parameter] public EventCallback<bool> IsErrorChanged { get; set; }

    [Parameter] public string? ErrorText { get; set; }
    [Parameter] public EventCallback<string?> ErrorTextChanged { get; set; }

    [Parameter] public EventCallback OnLeadingIconClick { get; set; }

    [Parameter] public EventCallback OnTrailingIconClick { get; set; }

    [Inject] public BackgroundColorService BackgroundColorService { get; set; }
    
    [Parameter] public bool ShowClearButton { get; set; }
    
    [Parameter] public EventCallback OnClear { get; set; }
    public string FieldContainerId = $"FieldContainer_{Guid.NewGuid()}";
    private string BackgroundColor { get; set; }

    protected string ContainerStyles => new CssStyleBuilder()
        .AddStyle("width", FullWidth ? "100%" : "auto")
        .AddStyle("display", "flex")
        .AddStyle("flex-direction", "column")
        .AddStyle("position", "relative")
        .Build(Style);

    protected string FieldContainerStyles => new CssStyleBuilder()
        .AddStyle("display", "flex")
        .AddStyle("align-items", "top")
        .AddStyle("position", "relative")
        .AddStyle("height", "3.5rem")
        .AddStyle(Variant == FieldVariant.Outline ? "border" : "background-color",
            Variant == FieldVariant.Outline
                ? $"{(IsFocused ? "0.125rem" : "0.063rem")} solid {(IsError ? "var(--md-sys-color-error)" : IsFocused ? "var(--md-sys-color-primary)" : "var(--md-sys-color-outline)")}"
                : "var(--md-sys-color-surface-container-highest)")
        .AddStyle("border-radius", Variant == FieldVariant.Outline ? "0.25rem" : "0.25rem 0.25rem 0 0")
        .AddStyle("width", FullWidth ? "100%" : "fit-content")
        .AddStyle("max-width", FullWidth ? "none" : "20rem")
        .AddStyle("transition", Variant == FieldVariant.Outline ? "border-color 0.3s ease" : "none")
        .Build();

    protected string LabelStyles => new CssStyleBuilder()
        .AddStyle("position", "absolute")
        .AddStyle("top",
            IsFocused || IsFilled
                ? Variant == FieldVariant.Outline ? "-0.65rem" : "-0.5rem"
                : Variant == FieldVariant.Filled ? "0" : "30%")
        .AddStyle("left", ".4rem", Variant == FieldVariant.Outline && (IsFocused || IsFilled))
        .AddStyle("font-size", IsFocused || IsFilled ? "0.8rem" : "1rem")
        .AddStyle("transition", MotionUtility.ConstructTransition())
        .AddStyle("padding", "0rem 0.2rem 0rem 0.2rem", Variant == FieldVariant.Outline)
        .AddStyle("color",
            Disabled ? ColorUtility.GetColorVariable(MaterialColor.SurfaceBright) :
            IsError ? "var(--md-sys-color-error)" :
            IsFocused ? "var(--md-sys-color-primary)" : "var(--md-sys-color-on-surface)")
        .AddStyle("font-weight", "400")
        .AddStyle("opacity", Disabled ? ColorUtility.DisabledOpacity : "1")
        .AddStyle("background-color", Variant == FieldVariant.Outline ? BackgroundColor : "transparent")
        .AddStyle("pointer-events", "none")
        .Build();

    protected string ActiveLineStyles => new CssStyleBuilder()
        .AddStyle("position", "absolute")
        .AddStyle("bottom", "0")
        .AddStyle("left", "0")
        .AddStyle("right", "0")
        
        .AddStyle("height", "0.125rem")
        .AddStyle("background-color", IsError ? "var(--md-sys-color-error)" : IsFocused ? "var(--md-sys-color-primary)" : ColorUtility.GetColorVariable(MaterialColor.OnSurface))
        .AddStyle("transform-origin", "middle center")
        .AddStyle("transition", MotionUtility.ConstructTransition("transform"))
        .AddStyle("transform", IsFocused || IsFilled ? "scaleX(1)" : "scaleX(0)")
        .Build();

    protected string InactiveLineStyles => new CssStyleBuilder()
        .AddStyle("position", "absolute")
        .AddStyle("bottom", "0")
        .AddStyle("left", "0")
        .AddStyle("right", "0")
        .AddStyle("height", "0.125rem")
        .AddStyle("background-color", "var(--md-sys-color-surface-variant)")
        .Build();

    public string InputContainerStyles => new CssStyleBuilder()
        .AddStyle("display", "flex")
        .AddStyle("position", "relative")
        .AddStyle("margin-top", Variant == FieldVariant.Filled ? "1rem" : "0rem")
        .AddStyle("padding-left", "1rem")
        .AddStyle("padding-right", "1rem")
        .Build();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            var size = await GetElementSizeAsync();
            BackgroundColor = await BackgroundColorService.GetBackgroundColorFromPointAsync(size.X, size.Y);
        }
    }

    // Notify methods for all bindable parameters
    private async Task NotifyLabelChanged(string newValue)
    {
        Label = newValue;
        await LabelChanged.InvokeAsync(newValue);
    }

    private async Task NotifyFullWidthChanged(bool newValue)
    {
        FullWidth = newValue;
        await FullWidthChanged.InvokeAsync(newValue);
    }

    private async Task NotifyVariantChanged(FieldVariant newValue)
    {
        Variant = newValue;
        await VariantChanged.InvokeAsync(newValue);
    }

    private async Task NotifyLeadingIconChanged(SvgIcon? newValue)
    {
        LeadingIcon = newValue;
        await LeadingIconChanged.InvokeAsync(newValue);
    }

    private async Task NotifySupportingTextChanged(string? newValue)
    {
        SupportingText = newValue;
        await SupportingTextChanged.InvokeAsync(newValue);
    }

    private async Task NotifyTrailingIconChanged(SvgIcon? newValue)
    {
        TrailingIcon = newValue;
        await TrailingIconChanged.InvokeAsync(newValue);
    }

    private async Task NotifyIsFocusedChanged(bool newValue)
    {
        IsFocused = newValue;
        await IsFocusedChanged.InvokeAsync(newValue);
    }

    private async Task NotifyIsFilledChanged(bool newValue)
    {
        IsFilled = newValue;
        await IsFilledChanged.InvokeAsync(newValue);
    }

    private async Task NotifyIsErrorChanged(bool newValue)
    {
        IsError = newValue;
        await IsErrorChanged.InvokeAsync(newValue);
    }

    private async Task NotifyErrorTextChanged(string? newValue)
    {
        ErrorText = newValue;
        await ErrorTextChanged.InvokeAsync(newValue);
    }
    
    private async Task NotifyDisabledChanged(bool newValue)
    {
        Disabled = newValue;
        await DisabledChanged.InvokeAsync(newValue);
    }

    private async Task Clear()
    {
        await OnClear.InvokeAsync();
    }
}
