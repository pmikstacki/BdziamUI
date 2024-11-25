using MaterialColorUtilities.Blend;
using MaterialColorUtilities.ColorAppearance;
using MaterialColorUtilities.Palettes;

namespace Bdziam.UI.Theming.Model;

using System.Drawing;

public class Theme
{
    // Main theme colors encapsulated in ThemeColor
    public ThemeColor Primary { get; set; }
    public ThemeColor Secondary { get; set; }
    public ThemeColor Tertiary { get; set; }
    public ThemeColor Neutral { get; set; }
     public ThemeColor NeutralVariant { get; set; }
    public Color Background { get; set; }
    public Color Surface { get; set; }
    public ThemeColor Error { get; set; }
    public ThemeColor Warning { get; set; }
    public ThemeColor Success { get; set; }
    public ThemeColor Info { get; set; }
    private bool isDarkMode;
    public void Initialize(Color primaryColor, bool isDarkMode)
    {
        this.isDarkMode = isDarkMode;
        uint primaryArgb = ToArgb(primaryColor);

        // Create the CorePalette
        var corePalette = CorePalette.Of(primaryArgb, Style.Vibrant);

        // Assign primary, secondary, and tertiary colors
        Primary = new ThemeColor(corePalette.Primary, isDarkMode);
        Secondary = new ThemeColor(corePalette.Secondary, isDarkMode);
        Tertiary = new ThemeColor(corePalette.Tertiary, isDarkMode);
        Neutral = new ThemeColor(corePalette.Neutral, isDarkMode);
        NeutralVariant = new ThemeColor(corePalette.NeutralVariant, isDarkMode);

        // Background and Surface colors
        Background = ColorFromArgb(corePalette.Neutral[isDarkMode ? (uint) 2: 95]); // Almost black for dark mode, almost white for light mode
        Surface = ColorFromArgb(corePalette.Neutral[isDarkMode ? (uint)4 : 90]); // Slightly different from Background

        // Initialize other theme colors
        Error = new ThemeColor(TonalPalette.FromInt(0xFFB000), isDarkMode); // Error color
        Warning = new ThemeColor(TonalPalette.FromInt(0xFFC107), isDarkMode); // Warning color
        Success = new ThemeColor(TonalPalette.FromInt(0x4CAF50), isDarkMode); // Success color
        Info = new ThemeColor(TonalPalette.FromInt(0x03A9F4), isDarkMode); // Info color
    }

    public Color GetSurfaceLevel(int level)
    {
        var tonalPallete = TonalPalette.FromInt(ToArgb(Surface));
        return ColorFromArgb(isDarkMode ?  tonalPallete[(uint) level * 10] : tonalPallete[100 - (uint) level * 10]);
    }

    private static uint ToArgb(Color color)
    {
        return (uint)((color.A << 24) | (color.R << 16) | (color.G << 8) | color.B);
    }

    /// <summary>
    /// Converts an ARGB integer to a Color.
    /// </summary>
    private Color ColorFromArgb(uint argb)
    {
        byte a = (byte)((argb >> 24) & 0xFF);
        byte r = (byte)((argb >> 16) & 0xFF);
        byte g = (byte)((argb >> 8) & 0xFF);
        byte b = (byte)(argb & 0xFF);
        return Color.FromArgb(a, r, g, b);
    }
}