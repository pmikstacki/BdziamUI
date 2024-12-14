using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Model.Enums;
using Bdziam.UI.Utilities;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI;

public partial class BUniformGrid : BComponentBase
{
    [Parameter] public RenderFragment? ChildContent { get; set; }
    [Parameter] public int Columns { get; set; } = 2; // Default number of rows
    [Parameter] public Size Gap { get; set; } = Size.Medium; // Space between items
    [Parameter] public bool IsResponsive { get; set; } = true; // Add responsiveness if required

    private string ContainerClasses => "grid";

    private string ContainerStyles => new CssStyleBuilder()
        .AddStyle("display", "grid")
        .AddStyle("grid-template-columns", $"repeat({Columns}, {(int)Gap}fr)") // Fixed number of rows
        .AddStyle("gap", $"{(int)Gap}rem")
        .AddStyle("width", "100%")
        .AddStyle("height", "100%")
        .Build();
}