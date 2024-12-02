using System.Drawing;
using Bdziam.UI;
using Bdziam.UI.Theming.MaterialColors.DynamicColor;

namespace BdziamUIExamples.Layout;

public partial class MainLayout
{
    private bool IsDarkMode { get; set; }
    public BThemeProvider ThemeProvider { get; set; }

    private void StyleChanged(DynamicSchemeVariant style)
    {
        ThemeProvider.Style = style;
    }

    private void ColorChanged(Color color)
    {
        ThemeProvider.SeedColor = color;
    }
}