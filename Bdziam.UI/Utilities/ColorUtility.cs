using System.Drawing;
using Bdziam.UI.Model.Enums;

namespace Bdziam.UI.Utilities;

public static class ColorUtility
{
    public static uint ToArgb(Color color)
    {
        return (uint)((color.A << 24) | (color.R << 16) | (color.G << 8) | color.B);
    }

    /// <summary>
    /// Converts an ARGB integer to a Color.
    /// </summary>
    public static Color ColorFromArgb(uint argb)
    {
        byte a = (byte)((argb >> 24) & 0xFF);
        byte r = (byte)((argb >> 16) & 0xFF);
        byte g = (byte)((argb >> 8) & 0xFF);
        byte b = (byte)(argb & 0xFF);
        return Color.FromArgb(a, r, g, b);
    }

    public static string GetColorVariable(ColorVariant colorVariant)
    {
        return $"var(--md-sys-color-{CaseUtility.PascalToKebab(colorVariant.ToString())})";
    }

    public static string GetSurfaceColorVariable(int elevation)
    {
        if (elevation > 5)
            elevation = 5;
        if (elevation == 0)
            return GetColorVariable(ColorVariant.Surface);

        var enumValue = Enum.Parse<ColorVariant>(ColorVariant.Surface.ToString()+elevation);
        return GetColorVariable(enumValue);
    }

    public static ColorVariant GetContainerVariant(ColorVariant colorVariant)
    {
        if(!Enum.TryParse<ColorVariant>($"{colorVariant.ToString()}Container", out var result))
            return ColorVariant.Surface;
        
        return result;
    }
    
    public static string GetContainerColorVariable(ColorVariant colorVariant)
    {
        if (colorVariant.ToString().Contains("Container"))
            return GetColorVariable(colorVariant);
        
        return GetColorVariable(GetContainerVariant(colorVariant));
    }

    public static string GetSurfaceContainerColorVariable(int elevation = 0)
    {
        if (elevation > 5)
            elevation = 5;
        if (elevation == 0)
            return GetColorVariable(ColorVariant.SurfaceContainerLowest);

        return elevation switch
        {
            4 => GetColorVariable(ColorVariant.SurfaceContainerHighest),
            3 => GetColorVariable(ColorVariant.SurfaceContainerHigh),
            2 => GetColorVariable(ColorVariant.SurfaceContainer),
            1 => GetColorVariable(ColorVariant.SurfaceContainerLow),
            _ => GetColorVariable(ColorVariant.SurfaceContainerLowest),
        };
    }

    public static string GetTextColorVariable(ColorVariant colorVariant)
    {
        return GetColorVariable(GetTextColorVariant(colorVariant));
    }

    public static ColorVariant GetTextColorVariant(ColorVariant colorVariant)
    {
        switch (colorVariant)
        {
            case ColorVariant.Primary:
                return ColorVariant.OnPrimary;
            
            case ColorVariant.OnPrimary:
                return ColorVariant.Primary;
            
            case ColorVariant.PrimaryContainer:
                return ColorVariant.OnPrimaryContainer;
            
            case ColorVariant.OnPrimaryContainer:
                return ColorVariant.PrimaryContainer;
            
            case ColorVariant.Secondary:
                return ColorVariant.OnSecondary;
            
            case ColorVariant.OnSecondary:
                return ColorVariant.Secondary;
            
            case ColorVariant.SecondaryContainer:
                return ColorVariant.OnSecondaryContainer;
            
            case ColorVariant.OnSecondaryContainer:
                return ColorVariant.SecondaryContainer;
            
            case ColorVariant.Tertiary:
                return ColorVariant.OnTertiary;
            
            case ColorVariant.OnTertiary:
                return ColorVariant.Tertiary;
            
            case ColorVariant.TertiaryContainer:
                return ColorVariant.OnTertiaryContainer;
            
            case ColorVariant.OnTertiaryContainer:
                return ColorVariant.TertiaryContainer;
            
            case ColorVariant.Error:
                return ColorVariant.OnError;
            
            case ColorVariant.OnError:
                return ColorVariant.Error;
            
            case ColorVariant.ErrorContainer:
                return ColorVariant.OnErrorContainer;
            
            case ColorVariant.OnErrorContainer:
                return ColorVariant.ErrorContainer;
            
            case ColorVariant.OnInfo:
                return ColorVariant.Info;
            
            case ColorVariant.Info:
                return ColorVariant.OnInfo;
            
            case ColorVariant.InfoContainer:
                return ColorVariant.OnInfoContainer;
            
            case ColorVariant.OnInfoContainer:
                return ColorVariant.InfoContainer;
            
            case ColorVariant.OnWarning:
                return ColorVariant.Warning;
            
            case ColorVariant.Warning:
                return ColorVariant.OnWarning;
            
            case ColorVariant.OnWarningContainer:
                return ColorVariant.WarningContainer;
            
            case ColorVariant.WarningContainer:
                return ColorVariant.OnWarningContainer;
            
            case ColorVariant.Background:
                return ColorVariant.OnBackground;
            
            case ColorVariant.OnBackground:
                return ColorVariant.Background;
            
            case ColorVariant.Surface:
                return ColorVariant.OnSurface;
            
            case ColorVariant.OnSurface:
                return ColorVariant.Surface;
            
            case ColorVariant.SurfaceVariant:
                return ColorVariant.OnSurfaceVariant;
            
            case ColorVariant.OnSurfaceVariant:
                return ColorVariant.SurfaceVariant;
            
            case ColorVariant.Outline:
                return ColorVariant.OnPrimary;
            
            case ColorVariant.Shadow:
                return ColorVariant.OnPrimary;
            
            case ColorVariant.InverseSurface:
                return ColorVariant.InverseOnSurface;
            
            case ColorVariant.InverseOnSurface:
                return ColorVariant.InverseSurface;
            
            case ColorVariant.InversePrimary:
                return ColorVariant.InverseOnSurface;
            
            case ColorVariant.Surface1:
                return ColorVariant.OnSurface;
            
            case ColorVariant.Surface2:
                return ColorVariant.OnSurface;
            
            case ColorVariant.Surface3:
                return ColorVariant.OnSurface;
            
            case ColorVariant.Surface4:
                return ColorVariant.OnSurface;
            
            case ColorVariant.Surface5:
                return ColorVariant.OnSurface;
            
            case ColorVariant.SurfaceDim:
                return ColorVariant.OnSurface;
            
            case ColorVariant.SurfaceBright:
                return ColorVariant.OnSurface;
            
            case ColorVariant.SurfaceContainerLowest:
                return ColorVariant.OnSurface;
            
            case ColorVariant.SurfaceContainerLow:
                return ColorVariant.OnSurface;
            
            case ColorVariant.SurfaceContainer:
                return ColorVariant.OnSurface;
            
            case ColorVariant.SurfaceContainerHigh:
                return ColorVariant.OnSurface;
            
            case ColorVariant.SurfaceContainerHighest:
                return ColorVariant.OnSurface;
            
            case ColorVariant.OutlineVariant:
                return ColorVariant.OnSurfaceVariant;
            default:
                throw new ArgumentOutOfRangeException(nameof(colorVariant));
        }
    }





}