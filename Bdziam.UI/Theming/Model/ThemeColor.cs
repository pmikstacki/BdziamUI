using System.Drawing;
using Bdziam.UI.Utilities;
using MaterialColorUtilities.Palettes;

namespace Bdziam.UI.Theming.Model;

public class ThemeColor : ThemingBase
{
    public Color Main { get; private set; }
    public Color Disabled { get; private set; }
    public Color Hover { get; private set; }
    public Color Text { get; private set; }
    /// <summary>
    /// Initializes a ThemeColor using a tonal palette.
    /// </summary>
    /// <param name="tonalPalette">The tonal palette to derive the color variants from.</param>
    public ThemeColor(TonalPalette tonalPalette, bool isDarkMode)
    {
        this.IsDarkMode = isDarkMode;
        Main = ColorUtility.ColorFromArgb(tonalPalette[60]); // Standard tone
        Disabled = ColorUtility.ColorFromArgb(tonalPalette[20]); // Dimmer tone for disabled state
        Hover = ColorUtility.ColorFromArgb(tonalPalette[70]); // Slightly brighter tone for hover
        Text = ColorUtility.ColorFromArgb(isDarkMode ? tonalPalette[90] : tonalPalette[10]); // High-contrast text tone
        Surface = ColorUtility.ColorFromArgb(isDarkMode ? tonalPalette[4]: tonalPalette[92]); // High-contrast text tone
    }
    
}