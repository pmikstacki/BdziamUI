using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Model.Enums;
using Bdziam.UI.Utilities;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI;

public partial class BPillRipple : BComponentBase, IControlColor
{
    /// <summary>
    /// Invoked when the seed color changes.
    /// </summary>
    [Parameter]
    public EventCallback<bool> IsActiveChanged { get; set; }

    private bool _isActive = false;

    /// <summary>
    /// Tracks the current Active state and triggers changes.
    /// </summary>
    [Parameter]
    public bool IsActive
    {
        get => _isActive;
        set
        {
            if (_isActive != value)
            {
                _isActive = value;
                IsActiveChanged.InvokeAsync(_isActive);
                StateHasChanged();
            }
        }
    }

    private string RippleTransition { get; set; } = "transform 0.3s ease, opacity 0.3s ease";

    [Parameter] public ColorVariant Color { get; set; } = ColorVariant.Secondary;

    public string PillRippleClasses => new CssClassBuilder()
        .AddClass("pill-ripple")
        .AddClass("active", IsActive)
        .Build();
}