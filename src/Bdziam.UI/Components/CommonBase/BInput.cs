using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Bdziam.UI.Components.CommonBase;

public abstract class BInput<T> : BComponentBase
{
    private T? _value;
    private FieldIdentifier _fieldIdentifier;

    [Parameter]
    public T? Value
    {
        get => _value;
        set
        {
            if (!EqualityComparer<T>.Default.Equals(value, _value))
            {
                _value = value;
                FieldChanged(_value);
                StateHasChanged();
            }
        }
    }

    [Parameter] public EventCallback<T?> ValueChanged { get; set; }
    [Parameter] public bool Disabled { get; set; }
    [Parameter] public bool ReadOnly { get; set; }
    [Parameter] public bool Required { get; set; }
    [Parameter] public string RequiredError { get; set; } = "Required";
    [Parameter] public Expression<Func<T?>>? For { get; set; }
    [Parameter] public object? Validation { get; set; }

    [CascadingParameter] private EditContext? EditContext { get; set; }

    public string? ErrorText => string.Join("\n", ValidationErrors);
    public bool Touched { get; private set; }
    protected List<string> ValidationErrors { get; } = new();
    protected bool Error => ValidationErrors.Count > 0;
    protected abstract bool IsEmpty();

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        if (For != null) _fieldIdentifier = FieldIdentifier.Create(For);
    }

    public void Validate()
    {
        ValidationErrors.Clear();

        if (Required && IsEmpty())
            ValidationErrors.Add(RequiredError);

        if (Validation is ValidationAttribute validationAttribute)
        {
            var validationContext = new ValidationContext(EditContext?.Model ?? this)
            {
                MemberName = _fieldIdentifier.FieldName
            };
            var result = validationAttribute.GetValidationResult(Value, validationContext);
            if (result != ValidationResult.Success && result?.ErrorMessage != null)
                ValidationErrors.Add(result.ErrorMessage);
        }
    }

    public void Reset()
    {
        Value = default;
        Touched = false;
        ValidationErrors.Clear();
        StateHasChanged();
    }

    public void MarkAsTouched()
    {
        Touched = true;
    }

    public void MarkAsUntouched()
    {
        Touched = false;
    }

    protected void FieldChanged(T? newValue)
    {
        ValueChanged.InvokeAsync(newValue);
        Validate();
    }

    private void OnValidationStateChanged(object? sender, ValidationStateChangedEventArgs e)
    {
        Validate();
    }
}
