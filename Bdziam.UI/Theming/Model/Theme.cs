using Bdziam.UI.Utilities;
using MaterialColorUtilities.Blend;
using MaterialColorUtilities.ColorAppearance;
using MaterialColorUtilities.Palettes;

namespace Bdziam.UI.Theming.Model;

using System.Drawing;

public class Theme : ThemingBase
{
    // Main theme colors encapsulated in ThemeColor
    public ThemeColor Primary { get; set; }
    public ThemeColor Secondary { get; set; }
    public ThemeColor Tertiary { get; set; }
    public ThemeColor Neutral { get; set; }
    public ThemeColor NeutralVariant { get; set; }
    public ThemeColor Error { get; set; }
    public ThemeColor Warning { get; set; }
    public ThemeColor Success { get; set; }
    public ThemeColor Info { get; set; }
    public Color Surface { get; private set; }

    public Color Background { get; set; }
    public void Initialize(Color seedColor, bool isDarkMode, Style style = Style.Vibrant)
    {
        this.IsDarkMode = isDarkMode;
        uint primaryArgb = ColorUtility.ToArgb(seedColor);

        // Create the CorePalette
        var corePalette = CorePalette.Of(primaryArgb, style);

        // Assign primary, secondary, and tertiary colors
        Primary = new ThemeColor(corePalette.Primary, isDarkMode);
        Secondary = new ThemeColor(corePalette.Secondary, isDarkMode);
        Tertiary = new ThemeColor(corePalette.Tertiary, isDarkMode);
        Neutral = new ThemeColor(corePalette.Neutral, isDarkMode);
        NeutralVariant = new ThemeColor(corePalette.NeutralVariant, isDarkMode);
        
        // Background and Surface colors
        Background = ColorUtility.ColorFromArgb(corePalette.Neutral[isDarkMode ? (uint) 2: 95]); // Almost black for dark mode, almost white for light mode
        Surface = ColorUtility.ColorFromArgb(corePalette.Neutral[isDarkMode ? (uint) 6: 90]); // Almost black for dark mode, almost white for light mode

        // Initialize other theme colors
        Error = new ThemeColor(TonalPalette.FromInt(0xFFB000), isDarkMode); // Error color
        Warning = new ThemeColor(TonalPalette.FromInt(0xFFC107), isDarkMode); // Warning color
        Success = new ThemeColor(TonalPalette.FromInt(0x4CAF50), isDarkMode); // Success color
        Info = new ThemeColor(TonalPalette.FromInt(0x03A9F4), isDarkMode); // Info color
    }
    
}