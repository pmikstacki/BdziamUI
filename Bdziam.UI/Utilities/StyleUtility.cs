using Bdziam.UI.Model.Enums;
using Bdziam.UI.Theming.Model;
using System.Drawing;

namespace Bdziam.UI.Utilities;

public static class StyleUtility
{
    /// <summary>
    /// Returns the appropriate base classes for a given typography style.
    /// </summary>
    public static string GetTypographyBaseClasses(Typo typo)
    {
        return typo switch
        {
            Typo.H1 => "text-4xl font-bold leading-tight",
            Typo.H2 => "text-3xl font-bold leading-snug",
            Typo.H3 => "text-2xl font-semibold leading-normal",
            Typo.H4 => "text-xl font-semibold leading-relaxed",
            Typo.H5 => "text-lg font-medium leading-relaxed",
            Typo.H6 => "text-base font-medium leading-relaxed",
            Typo.Body => "text-base font-normal leading-normal",
            Typo.Caption => "text-sm font-light leading-tight",
            _ => "text-base font-normal leading-normal"
        };
    }

    /// <summary>
    /// Converts a System.Drawing.Color to an inline CSS color string.
    /// </summary>
    public static string ToCssColor(Color color)
    {
        return $"rgb({color.R}, {color.G}, {color.B})";
    }

    /// <summary>
    /// Returns the appropriate color from the theme based on the ColorVariant enum.
    /// </summary>
    public static Color GetColorFromTheme(ColorVariant colorVariant, Theme theme)
    {
        return colorVariant switch
        {
            ColorVariant.Primary => theme.Primary.Main,
            ColorVariant.Secondary => theme.Secondary.Main,
            ColorVariant.Tertiary => theme.Tertiary.Main,
            ColorVariant.Error => theme.Error.Main,
            ColorVariant.Warning => theme.Warning.Main,
            ColorVariant.Success => theme.Success.Main,
            ColorVariant.Info => theme.Info.Main,
            ColorVariant.Surface => theme.Surface,
            ColorVariant.Background => theme.Background,
            _ => theme.Primary.Main
        };
    }

    /// <summary>
    /// Returns the hover color from the theme based on the ColorVariant enum.
    /// </summary>
    public static Color GetHoverColorFromTheme(ColorVariant colorVariant, Theme theme)
    {
        return colorVariant switch
        {
            ColorVariant.Primary => theme.Primary.Hover,
            ColorVariant.Secondary => theme.Secondary.Hover,
            ColorVariant.Tertiary => theme.Tertiary.Hover,
            ColorVariant.Error => theme.Error.Hover,
            ColorVariant.Warning => theme.Warning.Hover,
            ColorVariant.Success => theme.Success.Hover,
            ColorVariant.Info => theme.Info.Hover,
            ColorVariant.Surface => theme.Surface, // Surface may not have a hover; fallback to Surface
            ColorVariant.Background => theme.Background, // Background may not have a hover; fallback to Background
            _ => theme.Primary.Hover
        };
    }

    /// <summary>
    /// Returns the disabled color from the theme based on the ColorVariant enum.
    /// </summary>
    public static Color GetDisabledColorFromTheme(ColorVariant colorVariant, Theme theme)
    {
        return colorVariant switch
        {
            ColorVariant.Primary => theme.Primary.Disabled,
            ColorVariant.Secondary => theme.Secondary.Disabled,
            ColorVariant.Tertiary => theme.Tertiary.Disabled,
            ColorVariant.Error => theme.Error.Disabled,
            ColorVariant.Warning => theme.Warning.Disabled,
            ColorVariant.Success => theme.Success.Disabled,
            ColorVariant.Info => theme.Info.Disabled,
            ColorVariant.Surface => theme.Surface, // Surface may not have a disabled; fallback to Surface
            ColorVariant.Background => theme.Background, // Background may not have a disabled; fallback to Background
            _ => theme.Primary.Disabled
        };
    }

    /// <summary>
    /// Returns the text color from the theme based on the ColorVariant enum.
    /// </summary>
    public static Color GetTextColorFromTheme(ColorVariant colorVariant, Theme theme)
    {
        return colorVariant switch
        {
            ColorVariant.Primary => theme.Primary.Text,
            ColorVariant.Secondary => theme.Secondary.Text,
            ColorVariant.Tertiary => theme.Tertiary.Text,
            ColorVariant.Error => theme.Error.Text,
            ColorVariant.Warning => theme.Warning.Text,
            ColorVariant.Success => theme.Success.Text,
            ColorVariant.Info => theme.Info.Text,
            ColorVariant.Surface => theme.Surface,
            ColorVariant.Background => theme.Background,
            _ => theme.Primary.Text
        };
    }
}
