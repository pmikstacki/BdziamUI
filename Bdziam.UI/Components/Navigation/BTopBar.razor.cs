using Bdziam.UI.Model.Enums;
using Bdziam.UI.Utilities;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI;

public partial class BTopBar
{
    [Parameter] public RenderFragment? LeftContent { get; set; }
    [Parameter] public RenderFragment? MiddleContent { get; set; }
    [Parameter] public RenderFragment? RightContent { get; set; }
    [Parameter] public Size Size { get; set; } = Size.Medium;
    [Parameter] public bool ShowBackgroundRoundMask { get; set; } = true;

    private string ContainerStyles => new CssStyleBuilder()
        .AddStyle("padding", GetPaddingValues())
        .AddStyle("height", GetHeight())
        .Build();

    private string TopBarMaskStyles => new CssStyleBuilder()
        .AddStyle("background-color", "var(--color-surface)")
        .AddStyle("height", "16px")
        .Build();
    
    private string GetPaddingValues()
    {
        return Size switch
        {
            Size.Small => "0.25rem 0.5rem", // Small: 1px vertical, 2px horizontal
            Size.Medium => "0.5rem 1rem",  // Medium: 2px vertical, 4px horizontal
            Size.Large => "0.75rem 1.5rem", // Large: 3px vertical, 6px horizontal
            Size.ExtraLarge => "1rem 2rem", // ExtraLarge: 4px vertical, 8px horizontal
            _ => "0.5rem 1rem"             // Default: Medium
        };
    }
    
    private string GetHeight()
    {
        return Size switch
        {
            Size.Small => "48px",
            Size.Medium => "64px",
            Size.Large => "80px",
            Size.ExtraLarge => "96px",
            _ => "64px" // Default to Medium
        };
    }
}