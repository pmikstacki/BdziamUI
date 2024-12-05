using Bdziam.UI.Model.Enums;
using Bdziam.UI.Theming.Model;
using System.Drawing;
using Color = System.Drawing.Color;
using Size = Bdziam.UI.Model.Enums.Size;

namespace Bdziam.UI.Utilities;

public static class StyleUtility
{
    
    public static string GetRadiusClass(BorderRadius radius)
    {
        return radius switch
        {
            BorderRadius.None => "rounded-none",
            BorderRadius.Small => "rounded-sm",
            BorderRadius.Medium => "rounded-md",
            BorderRadius.Large => "rounded-lg",
            BorderRadius.Pill => "rounded-full",
            _ => "rounded-md"
        };
    }
    
    
    public static string GetRadiusStyle(BorderRadius radius)
    {
        return radius switch
        {
            BorderRadius.None => "0px",
            BorderRadius.Small => "0.250rem",
            BorderRadius.Medium => "0.5rem",
            BorderRadius.Large => "0.75rem",
            BorderRadius.Pill => "9999px",
            _ => "0.5rem"
        };
    }

    /// <summary>
    /// Converts a System.Drawing.Color to an inline CSS color string.
    /// </summary>
    public static string ToCssColor(Color color)
    {
        return $"rgb({color.R}, {color.G}, {color.B})";
    }
    
    public static string GetPadding(Size size)
    {
        return size switch
        {
            Size.Small => "0.25rem 0.5rem", // Small: 1px vertical, 2px horizontal
            Size.Medium => "0.5rem 1rem",  // Medium: 2px vertical, 4px horizontal
            Size.Large => "0.75rem 1.5rem", // Large: 3px vertical, 6px horizontal
            Size.ExtraLarge => "1rem 2rem", // ExtraLarge: 4px vertical, 8px horizontal
            _ => "0.5rem 1rem"             // Default: Medium
        };
    }
    
    public static string GetHorizontalPadding(Size size)
    {
        return size switch
        {
            Size.Small => "0.5rem", // Small: 1px vertical, 2px horizontal
            Size.Medium => "0.75rem",  // Medium: 2px vertical, 4px horizontal
            Size.Large => "1rem", // Large: 3px vertical, 6px horizontal
            Size.ExtraLarge => "1.5rem", 
            Size.None => "0rem",// ExtraLarge: 4px vertical, 8px horizontal
            _ => "0.5rem"             // Default: Medium
        };
    }
    
    public static string GetVerticalPadding(Size size)
    {
        return size switch
        {
            Size.Small => "0.375rem", // Small: 1px vertical, 2px horizontal
            Size.Medium => "0.5rem",  // Medium: 2px vertical, 4px horizontal
            Size.Large => "1rem", // Large: 3px vertical, 6px horizontal
            Size.ExtraLarge => "1.5rem", 
            Size.None => "0rem",// ExtraLarge: 4px vertical, 8px horizontal
            _ => "0.5rem"             // Default: Medium
        };
    }
    
    public static string GetStaticHeight(Size size)
    {
        return size switch
        {
            Size.Small => "36px",
            Size.Medium => "48px",
            Size.Large => "64px",
            Size.ExtraLarge => "80px",
            _ => "48px" // Default to Medium
        };
    }
}
