using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Interop;
using Bdziam.UI.Model.Enums;
using Bdziam.UI.Utilities;
using Blazicons;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Threading.Tasks;

namespace Bdziam.UI
{
    public partial class BFoldout : BComponentBase, IControlChildContent, IControlColor
    {
        [Parameter] public string Header { get; set; } = string.Empty;
        [Parameter] public SvgIcon? Icon { get; set; }
        [Parameter] public SvgIcon ExpandIcon { get; set; } = GoogleMaterialFilledIcon.ChevronRight;
        [Parameter] public bool IsExpanded { get; set; }
        [Parameter] public RenderFragment? ChildContent { get; set; }
        [CascadingParameter] public BFoldout? Parent { get; set; }

        [Inject] private ElementSizeService ElementSizeService { get; set; }

        private string HeaderStyles => new CssStyleBuilder()
            .AddStyle("background-color", IsExpanded ? "var(--md-sys-color-primary-container)" : "var(--md-sys-color-surface-variant)")
            .AddStyle("color", IsExpanded ? "var(--md-sys-color-on-primary-container)" : "var(--md-sys-color-on-surface-variant)")
            .AddStyle("border-radius", StyleUtility.GetRadiusStyle(BorderRadius.Pill))
            .Build();

        private string ChildContentStyle => new CssStyleBuilder()
            .AddStyle("max-height", IsExpanded ? $"{ExpandedHeight}px" : "0px")
            .AddStyle("overflow-y", "hidden")
            .AddStyle("transition", MotionUtility.ConstructTransition(Motion.EasingEmphasized, 0.5, "max-height"))
            .AddStyle("background-color", "var(--md-sys-color-surface)") // Optional for a clear visual distinction
            .Build();


        private string ExpandIconStyle => new CssStyleBuilder()
            .AddStyle("transform", IsExpanded ? "rotate(90deg)" : "rotate(0deg)")
            .AddStyle("transition", MotionUtility.ConstructTransition(Motion.EasingEmphasized, 0.5, "transform"))
            .AddStyle("color", IsExpanded ? "var(--md-sys-color-on-primary-container)" : "var(--md-sys-color-on-surface-variant)")
            .Build();


        private string ChildContainerId { get; } = $"child-container-{Guid.NewGuid()}";
        private double expandedHeight;

        public double ExpandedHeight
        {
            get => expandedHeight;
            set
            {
                expandedHeight = value;
                Parent?.Refresh(ExpandedHeight);
            }
        }

        public void Refresh(double heightChange)
        {
            ExpandedHeight += heightChange;
            Parent?.Refresh(ExpandedHeight);
            StateHasChanged();
        }

        private async Task ToggleExpand()
        {
            IsExpanded = !IsExpanded;

            if (IsExpanded)
            {
                // Measure the child container height when expanded
                var size = await ElementSizeService.GetElementSizeAsync(ChildContainerId);
                ExpandedHeight = size?.Height ?? 0;
            }
            else
            {
                ExpandedHeight = 0;
            }

            StateHasChanged();
        }

        [Parameter] public MaterialColor Color { get; set; } = MaterialColor.Primary;
    }
}
