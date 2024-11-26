using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Model.Enums;
using Bdziam.UI.Utilities;
using Blazicons;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Bdziam.UI
{
    public partial class BDrawerMenuItem : Components.CommonBase.BComponentBase ,IControlIcon
    {
        [Parameter] public string? Text { get; set; }
        [Parameter] public SvgIcon? Icon { get; set; }
        [Parameter] public string? Uri { get; set; }
        [Parameter] public bool HasChildren { get; set; } = false;
        [Parameter] public bool IsExpanded { get; set; } = false;
        [Parameter] public EventCallback<bool> IsExpandedChanged { get; set; }
        [Parameter] public bool IsActive { get; set; } = false;
        [Parameter] public EventCallback<bool> IsActiveChanged { get; set; }
        [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

        [Inject] private NavigationManager NavigationManager { get; set; } = default!;

        private string CurrentUri => NavigationManager.Uri;

        private string MenuItemStyles => new CssStyleBuilder()
            .AddStyle("background-color", GetBackgroundColor())
            .AddStyle("padding", "0.5rem 1rem")
            .AddStyle("display", "flex")
            .AddStyle("align-items", "center")
            .AddStyle("cursor", "pointer")
            .Build(Style);

        private Dictionary<string, object> IconAttributes => new()
        {
            ["style"] = "margin-right: 0.5rem; width: 1.5rem; height: 1.5rem;"
        };

        private Dictionary<string, object> ArrowIconAttributes => new()
        {
            ["style"] = IsExpanded ? "transform: rotate(90deg);" : "transform: rotate(0deg);",
            ["class"] = "arrow-icon"
        };

        public BPillRipple? Ripple { get; set; }

        private string GetBackgroundColor()
        {
            if (IsActive || (Uri != null && CurrentUri.Contains(Uri)))
            {
                return "var(--color-secondary)";
            }
            return "transparent";
        }

        protected override void OnInitialized()
        {
            // Set active state if URI matches
            if (Uri != null && CurrentUri.Contains(Uri, StringComparison.OrdinalIgnoreCase))
            {
                IsActive = true;
            }
        }

        private async Task HandleClick(MouseEventArgs e)
        {

            if (!IsActive)
            {
                IsActive = true;
                await IsActiveChanged.InvokeAsync(IsActive);
            }

            if (HasChildren)
            {
                IsExpanded = !IsExpanded;
                await IsExpandedChanged.InvokeAsync(IsExpanded);
            }

            if (Uri != null)
            {
                NavigationManager.NavigateTo(Uri);
            }

            await OnClick.InvokeAsync(e);
        }
    }
}
