using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Model.Enums;
using Bdziam.UI.Model.Utility;
using Bdziam.UI.Utilities;
using Blazicons;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Bdziam.UI
{
    public partial class BDrawerMenuItem : BDrawerMenuItemBase, IControlChildContent
    {
        [Parameter] public string? BadgeText { get; set; } // Badge label text
        [Parameter] public bool IsActive { get; set; }
        private bool IsActiveCalculated => Uri != null ? "/"+NavigationManager.ToBaseRelativePath(NavigationManager.Uri) == Uri : IsActive; // Whether the menu item is active (shows indicator)
        [Parameter] public bool IsExpanded { get; set; } = false; // Whether the menu item is active (shows indicator)
        [Parameter] public RenderFragment? ChildContent { get; set; }
        [Parameter] public string? Uri { get; set; }
        [Parameter] public EventCallback<MouseEventArgs>? OnClick { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        private bool HasChildren => ChildContent != null;
        private Dictionary<string, object> IconAttributes => new()
        {
            ["style"] = new CssStyleBuilder()
                .AddStyle("width", "1.5rem")
                .AddStyle("height", "1.5rem")
                .AddStyle("color", "var(--color-neutral-surface-text)")
                .Build()
        };

        private string ChildContainerStyle => new CssStyleBuilder()
            .AddStyle("overflow", "hidden")
            .AddStyle("height", "0", !IsExpanded)
            .AddStyle("height", "auto", IsExpanded)
            .AddStyle("transition", "height 0.5s ease-in-out")
            .Build();
        private Dictionary<string, object> ArrowIconAttributes => new()
        {
            ["style"] = new CssStyleBuilder()
                .AddStyle("width", "1.5rem")
                .AddStyle("height", "1.5rem")
                .AddStyle("color", $"var(--color-secondary-surface-text)", IsActiveCalculated)
                .AddStyle("color", $"var(--color-variant-surface-text)", !IsActiveCalculated)
                .AddStyle("transform", IsExpanded ? "rotate(90deg)" : "rotate(0deg)")
                .AddStyle("transition", "transform 0.2s ease-in-out")
                .Build()
        };

        private string MenuItemStyles => new CssStyleBuilder()
            .AddStyle("background-color", IsActiveCalculated ? "var(--color-secondary-surface)" : "transparent")
            .AddStyle("color", "var(--color-secondary-surface-text)")
            .Build();
        

        private void HandleClick(MouseEventArgs eventArgs)
        {
            if (HasChildren)
            {
                IsExpanded = !IsExpanded;
                StateHasChanged();
                return;
            }
            if (!string.IsNullOrEmpty(Uri))
            {
                NavigationManager.NavigateTo(Uri);
                StateHasChanged();
                return;
            }

            OnClick?.InvokeAsync(eventArgs);
        }
    }
}