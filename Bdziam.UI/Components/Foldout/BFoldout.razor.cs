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
            .AddStyle("background-color", IsExpanded ? ColorUtility.GetColorVariable(Color): ColorUtility.GetContainerColorVariable(Color))
            .AddStyle("color",ColorUtility.GetTextColorVariable(ColorUtility.GetContainerVariant(Color)))
            .Build();

        private string ChildContentStyle => new CssStyleBuilder()
            .AddStyle("max-height", IsExpanded ? $"{ExpandedHeight}px" : "0px")
            .AddStyle("overflow", "hidden", !IsExpanded)
            .AddStyle("transition", "max-height 0.3s cubic-bezier(0, 1.4, 1, 1)")
            .Build();

        private Dictionary<string, object> IconAttributes => new()
        {
            ["style"] = new CssStyleBuilder()
                .AddStyle("width", "1.5rem")
                .AddStyle("height", "1.5rem")
                .AddStyle("color",ColorUtility.GetTextColorVariable(ColorUtility.GetContainerVariant(Color)))
                .Build()
        };

        private Dictionary<string, object> ArrowIconAttributes => new()
        {
            ["style"] = new CssStyleBuilder()
                .AddStyle("width", "1.5rem")
                .AddStyle("height", "1.5rem")
                .AddStyle("color",ColorUtility.GetTextColorVariable(ColorUtility.GetContainerVariant(Color)))
                .AddStyle("transform", IsExpanded ? "rotate(90deg)" : "rotate(0deg)")
                .AddStyle("transition", "transform 0.2s cubic-bezier(0, 1.4, 1, 1)")
                .Build()
        };

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

        [Parameter] public ColorVariant Color { get; set; } = ColorVariant.Primary;
    }
}
