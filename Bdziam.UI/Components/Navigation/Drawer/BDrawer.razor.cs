using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Model.Enums;
using Bdziam.UI.Utilities;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI
{
    public partial class BDrawer : Components.CommonBase.BComponentBase
    {
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public RenderFragment MainContent { get; set; }
        [Parameter] public bool IsOpen { get; set; } = true;
        [Parameter] public EventCallback<bool> IsOpenChanged { get; set; }
        [Parameter] public DrawerPosition Position { get; set; } = DrawerPosition.Left;
        [Parameter] public int Width { get; set; } = 300; // Default drawer width in pixels
        [Parameter] public MdSysColor MdSysColor { get; set; } = MdSysColor.Surface;
        [Parameter] public int Elevation { get; set; } = 0;

        private string DrawerStyle => new CssStyleBuilder()
            .AddStyle("width", $"{Width}px")
            .AddStyle("height", "100vh")
            .AddStyle("position", "fixed")
            .AddStyle(Position == DrawerPosition.Left ? "left" : "right", IsOpen ? "0" : $"-{Width}px")
            .AddStyle("top", "0")
            .AddStyle("padding", "1rem")
            .AddStyle("transition", "left 0.3s ease, right 0.3s ease")
            .AddStyle("color", ColorUtility.GetTextColorVariable(MdSysColor))
            .AddStyle("z-index", "1000")
            .Build();

        private string DrawerContainerStyle => new CssStyleBuilder()
            .AddStyle("display", "flex")
            .AddStyle("flex-direction", "row")
            .AddStyle("height", "100vh")
            .Build();

        private string MainContentStyle => new CssStyleBuilder()
            .AddStyle("flex-grow", "1")
            .AddStyle("margin-left", IsOpen && Position == DrawerPosition.Left ? $"{Width}px" : "0px")
            .AddStyle("margin-right", IsOpen && Position == DrawerPosition.Right ? $"{Width}px" : "0px")
            .AddStyle("transition", "margin-left 0.3s ease, margin-right 0.3s ease")
            .AddStyle("overflow", "hidden") // Ensure content respects the rounded corners
            .AddStyle("background-color", ColorUtility.GetColorVariable(MdSysColor.Background)) // Consistent background color
           // .AddStyle("box-shadow", "0px 4px 10px rgba(0,0,0,0.1)") // Optional: subtle shadow for depth
            .Build();

        private async Task ToggleDrawer()
        {
            IsOpen = !IsOpen;
            await IsOpenChanged.InvokeAsync(IsOpen);
        }
    }
}
