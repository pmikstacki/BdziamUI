using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Model.Enums;
using Bdziam.UI.Utilities;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI;

public partial class BMasonryGrid : BComponentBase
{
    [Parameter] public RenderFragment? ChildContent { get; set; }
    [Parameter] public int Columns { get; set; } = 3; // Default number of columns
    [Parameter] public Size Gap { get; set; } = Size.Medium; // Space between items
    [Parameter] public List<double> ColumnWidths { get; set; } = new(); // Custom column widths
    [Parameter] public bool IsResponsive { get; set; } = true; // Add responsiveness if required

    private string ContainerClasses => "masonry-grid";

    private string ContainerStyles => new CssStyleBuilder()
        .AddStyle("display", "grid")
        .AddStyle("grid-template-columns", GenerateColumnStyles())
        .AddStyle("gap", $"{(int)Gap}rem")
        .Build();

    private string ItemClasses => "masonry-item";

    private string ItemStyles => new CssStyleBuilder()
        .AddStyle("margin", $"{(int)Gap / 2}rem") // Optional item-specific styling
        .Build();

    private IEnumerable<RenderFragment> ChildContentRenderFragments
    {
        get
        {
            var fragments = new List<RenderFragment>();
            if (ChildContent != null) fragments.Add(ChildContent);
            return fragments;
        }
    }

    private string GenerateColumnStyles()
    {
        if (ColumnWidths != null && ColumnWidths.Count > 0)
            return string.Join(" ", ColumnWidths.Select(width => $"{width}fr"));
        return $"repeat({Columns}, 1fr)";
    }
}