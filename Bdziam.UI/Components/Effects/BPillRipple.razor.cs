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
    
    [Parameter] public string RippleTransition { get; set; } = "transform 0.3s ease, opacity 0.3s ease";

    [Parameter] public ColorVariant Color { get; set; }
    private string RippleContainerStyle => new CssStyleBuilder()
        .AddStyle("position", "relative")
        .AddStyle("overflow", "hidden")
        .AddStyle("display", "inline-block")
        .AddStyle("border-radius", StyleUtility.GetRadiusStyle(BorderRadius.Pill)) // Full pill shape
        .AddStyle("background-color", "transparent", !IsActive)
        .AddStyle("transition", RippleTransition)
        .Build();

    private string RippleStyle => new CssStyleBuilder()
        .AddStyle("position", "absolute")
        .AddStyle("top", "50%")
        .AddStyle("left", "50%")
        .AddStyle("width", IsActive ? "100%" : "0%")
        .AddStyle("height", "100%")
        .AddStyle("transform", "translate(-50%, -50%)")
        .AddStyle("border-radius", "50%") // Circular ripple effect
        .AddStyle("background-color", Color != ColorVariant.Surface ? $"var(--color-{Color.ToString().ToLower()}-surface)" : "var(--color-surface)")
        .AddStyle("opacity", IsActive ? "0.3" : "0") // Slight transparency when active
        .AddStyle("transition", RippleTransition)
        .Build();

}