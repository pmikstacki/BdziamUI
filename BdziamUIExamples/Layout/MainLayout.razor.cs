using System.Drawing;
using Bdziam.UI;
using MaterialColorUtilities.Palettes;

namespace BdziamUIExamples.Layout;

public partial class MainLayout
{
    private bool IsDarkMode { get; set; }
    public BThemeProvider ThemeProvider { get; set; }

    private void StyleChanged(Style style)
    {
        ThemeProvider.Style = style;
    }

    private void ColorChanged(Color color)
    {
        ThemeProvider.SeedColor = color;
    }
}