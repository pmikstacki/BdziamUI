using System.Drawing;
using MaterialColorUtilities.Palettes;

namespace Bdziam.UI.Theming.Model;

public class ThemeSettings
{
    public uint SeedColor { get; set; }
    public bool IsDarkMode { get; set; }
    public Style PalleteStyle { get; set; }
}