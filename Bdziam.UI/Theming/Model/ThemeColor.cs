using System.Drawing;
using MaterialColorUtilities.Palettes;

namespace Bdziam.UI.Theming.Model;

public class ThemeColor
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
        Main = ColorFromArgb(tonalPalette[60]); // Standard tone
        Disabled = ColorFromArgb(tonalPalette[20]); // Dimmer tone for disabled state
        Hover = ColorFromArgb(tonalPalette[70]); // Slightly brighter tone for hover
        Text = ColorFromArgb(isDarkMode ? tonalPalette[90] : tonalPalette[10]); // High-contrast text tone
    }

    /// <summary>
    /// Converts an ARGB integer to a Color.
    /// </summary>
    private static Color ColorFromArgb(uint argb)
    {
        byte a = (byte)((argb >> 24) & 0xFF);
        byte r = (byte)((argb >> 16) & 0xFF);
        byte g = (byte)((argb >> 8) & 0xFF);
        byte b = (byte)(argb & 0xFF);

        return Color.FromArgb(a, r, g, b);
    }
}