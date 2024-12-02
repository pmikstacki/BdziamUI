using System.Drawing;
using Bdziam.UI.Theming.MaterialColors.DynamicColor;

namespace Bdziam.UI.Theming.Model;

public class ThemeSettings
{
    public uint SeedColor { get; set; }
    public bool IsDarkMode { get; set; }
    public DynamicSchemeVariant PalleteStyle { get; set; }
}