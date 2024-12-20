﻿using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Model.Enums;
using Bdziam.UI.Utilities;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI;

public partial class BDrawer : BComponentBase
{
    [Parameter] public RenderFragment ChildContent { get; set; }
    [Parameter] public RenderFragment? TopBar { get; set; } = null;

    [Parameter] public RenderFragment MainContent { get; set; }
    [Parameter] public bool IsOpen { get; set; } = true;
    [Parameter] public EventCallback<bool> IsOpenChanged { get; set; }
    [Parameter] public DrawerPosition Position { get; set; } = DrawerPosition.Left;
    [Parameter] public int Width { get; set; } = 300; // Default drawer width in pixels
    [Parameter] public MaterialColor MaterialColor { get; set; } = MaterialColor.Surface;
    [Parameter] public int Elevation { get; set; } = 0;

    private string DrawerStyle => new CssStyleBuilder()
        .AddStyle("width", $"{Width}px")
        .AddStyle("height", "100vh")
        .AddStyle("position", "fixed")
        .AddStyle(Position == DrawerPosition.Left ? "left" : "right", IsOpen ? "0" : $"-{Width}px")
        .AddStyle("top", "0")
        .AddStyle("overflow-y", "auto")
        .AddStyle("padding", "1rem")
        .AddStyle("transition",MotionUtility.ConstructTransition(Motion.EasingStandard, 0.3, "left", "right"))
        .AddStyle("color", ColorUtility.GetTextColorVariable(MaterialColor))
        .AddStyle("z-index", "1000")
        .Build();

    private string DrawerContainerStyle => new CssStyleBuilder()
        .AddStyle("display", "flex")
        .AddStyle("flex-direction", "row")
        .AddStyle("height", "100vh")
        .Build();

    private string MainContentStyle => new CssStyleBuilder()
        .AddStyle("background-color",
            ColorUtility.GetColorVariable(MaterialColor.Background)) // Consistent background color
        // .AddStyle("box-shadow", "0px 4px 10px rgba(0,0,0,0.1)") // Optional: subtle shadow for depth
        .Build();

    private string TopBarStyle => new CssStyleBuilder()
        .AddStyle("flex-grow", "0")
        .AddStyle("background-color",
            ColorUtility.GetColorVariable(MaterialColor.Background)) // Consistent background color
        .Build();

    private string ContentStyle => new CssStyleBuilder()
        .AddStyle("display", "flex")
        .AddStyle("flex-direction", "column")
        .AddStyle("flex-grow", "1")
        .AddStyle("margin-left", IsOpen && Position == DrawerPosition.Left ? $"{Width}px" : "0px")
        .AddStyle("margin-right", IsOpen && Position == DrawerPosition.Right ? $"{Width}px" : "0px")
        .AddStyle("transition",
            MotionUtility.ConstructTransition(Motion.EasingStandard, 0.3, "margin-left", "margin-right"))
        .AddStyle("overflow-y", "auto") // Ensure content respects the rounded corners
        .AddStyle("background-color",
            ColorUtility.GetColorVariable(MaterialColor.Background)) // Consistent background color
        // .AddStyle("box-shadow", "0px 4px 10px rgba(0,0,0,0.1)") // Optional: subtle shadow for depth
        .Build();

    private async Task ToggleDrawer()
    {
        IsOpen = !IsOpen;
        await IsOpenChanged.InvokeAsync(IsOpen);
    }
}