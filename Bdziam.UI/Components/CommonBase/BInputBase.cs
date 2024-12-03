using System.ComponentModel.DataAnnotations;
using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Model.Enums;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Globalization;
using System.Linq.Expressions;

namespace Bdziam.UI.Components.CommonBase
{
    public abstract class BInputBase<T> : BComponentBase
    {
        private T? _value;

        [Parameter] public T? Value 
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

        [Parameter] public string Label { get; set; } = string.Empty;

        [Parameter] public string? Placeholder { get; set; }

        [Parameter] public CultureInfo Culture { get; set; } = CultureInfo.InvariantCulture;

        [Parameter] public Expression<Func<T?>>? For { get; set; }

        [Parameter] public object? Validation { get; set; }

        [Parameter] public string? ErrorText { get; set; }

        [Parameter] public RenderFragment? ChildContent { get; set; }

        [CascadingParameter] private EditContext? EditContext { get; set; }

        protected bool Touched { get; private set; }

        protected List<string> ValidationErrors { get; private set; } = new();

        protected bool Error => ValidationErrors.Count > 0;

        private FieldIdentifier _fieldIdentifier;

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (For != null)
            {
                _fieldIdentifier = FieldIdentifier.Create(For);
            }
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            if (EditContext != null && For != null)
            {
                EditContext.OnValidationStateChanged += OnValidationStateChanged;
                _fieldIdentifier = FieldIdentifier.Create(For);
            }
        }

        protected void FieldChanged(T? newValue)
        {
            ValueChanged.InvokeAsync(newValue);
            Validate();
        }

        public void Validate()
        {
            ValidationErrors.Clear();

            if (Required && EqualityComparer<T>.Default.Equals(Value, default))
            {
                ValidationErrors.Add(RequiredError);
            }

            if (Validation is ValidationAttribute validationAttribute && For != null)
            {
                var validationContext = new ValidationContext(EditContext?.Model ?? this)
                {
                    MemberName = _fieldIdentifier.FieldName
                };

                var result = validationAttribute.GetValidationResult(Value, validationContext);
                if (result != ValidationResult.Success && result?.ErrorMessage != null)
                {
                    ValidationErrors.Add(result.ErrorMessage);
                }
            }

            StateHasChanged();
        }

        private void OnValidationStateChanged(object? sender, ValidationStateChangedEventArgs e)
        {
            Validate();
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

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender && EditContext != null)
            {
                if (For != null)
                {
                    _fieldIdentifier = FieldIdentifier.Create(For);
                }
                await base.OnAfterRenderAsync(firstRender);
            }
        }
    }
}
