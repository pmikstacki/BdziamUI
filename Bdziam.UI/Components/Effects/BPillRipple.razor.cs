using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Model.Enums;
using Bdziam.UI.Utilities;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI;

public partial class BPillRipple : BComponentBase
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

    private string RippleTransition { get; set; } = MotionUtility.ConstructTransition(Motion.EasingEmphasizedAccelerate, 0.3, "transform", "opacity");
    [Parameter] public MaterialColor MaterialColor { get; set; } = MaterialColor.Secondary;
    [Parameter] public bool Scale { get; set; } = true;
    [Parameter] public bool Behind { get; set; } = true;
    [Parameter] public bool Hover { get; set; } = true;
    public string PillRippleClasses => new CssClassBuilder()
        .AddClass("pill-ripple")
        .AddClass("active-scalex", IsActive && Scale)
        .AddClass("active", IsActive && !Scale)
        .Build();

    public string PillRippleStyle => new CssStyleBuilder()
        .AddStyle("background-color", ColorUtility.GetColorVariable(MaterialColor), IsActive)
        .AddStyle("z-index", "-3", Behind)
        .AddStyle("transform", "scaleX(100)", !Scale)
        .Build(Style);
    public void Pulsate()
    {
        IsActive = true;
        StateHasChanged();
        // Reset IsActive after animation duration to allow re-triggering
        Task.Delay(450).ContinueWith(_ => InvokeAsync(() => IsActive = false));
    }
    
    private string GetActivePulsateTransitionStyles()
    {
        return new CssStyleBuilder()
            .AddStyle("animation", "pulsate 0.6s ease-in-out")
            .AddStyle("animation-fill-mode", "forwards") // Ensures the final state is maintained after animation
            .Build();
    }
}