using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Model.Enums;
using Bdziam.UI.Services;
using Bdziam.UI.Utilities;
using Blazicons;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Bdziam.UI;

public class BInputField<T> : BInput<T>
{
    protected string inputId = $"input_{Guid.NewGuid().ToString()}";
    protected bool IsFocusedOrFilled => !IsEmpty() || IsFocused;
    public bool IsFocused { get; set; }

    protected override bool IsEmpty()
    {
        return Value != null;
    }
    
    [Parameter] public BInputView View { get; set; }
    [Parameter] public FieldVariant Variant { get; set; } = FieldVariant.Filled;
    [Parameter] public SvgIcon? LeadingIcon { get; set; }
    [Parameter] public bool FullWidth { get; set; }
    [Parameter] public string? SupportingText { get; set; }
    [Parameter] public SvgIcon? TrailingIcon { get; set; }
    [Parameter] public string Label { get; set; }
    [Parameter] public EventCallback<string> LabelChanged { get; set; }

    [Parameter] public EventCallback OnLeadingIconClick { get; set; }
    [Parameter] public EventCallback OnTrailingIconClick { get; set; }
    [Parameter] public EventCallback<FocusEventArgs> OnFieldFocus { get; set; }
    [Parameter] public EventCallback<FocusEventArgs> OnFieldBlur { get; set; }
    [Parameter] public bool ShowClearButton { get; set; }
    [Parameter] public EventCallback OnClear { get; set; }
    public async Task OnFocus(FocusEventArgs args)
    {
        IsFocused = true;
        await OnFieldFocus.InvokeAsync(args);
    }
    public async Task OnBlur(FocusEventArgs args)
    {
        IsFocused = false;
        await OnFieldBlur.InvokeAsync(args);
    }
}