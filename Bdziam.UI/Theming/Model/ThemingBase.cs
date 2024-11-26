using System.Drawing;
using Bdziam.UI.Utilities;
using MaterialColorUtilities.Palettes;

namespace Bdziam.UI.Theming.Model;

public class ThemingBase
{ 
    public Color Surface { get; set; }
    public bool IsDarkMode { get; set; }

    public Color GetSurfaceLevel(int level)
    {
        var tonalPallete = TonalPalette.FromInt(ColorUtility.ToArgb(Surface));
        return ColorUtility.ColorFromArgb(IsDarkMode ? tonalPallete[(uint) level * 10] : tonalPallete[100 - (uint) level * 10]);
    }
}