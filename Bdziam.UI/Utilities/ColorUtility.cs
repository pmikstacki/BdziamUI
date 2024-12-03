using System.Drawing;
using Bdziam.UI.Model.Enums;

namespace Bdziam.UI.Utilities;

public static class ColorUtility
{
    public static uint ToArgb(System.Drawing.Color color)
    {
        return (uint)((color.A << 24) | (color.R << 16) | (color.G << 8) | color.B);
    }

    /// <summary>
    /// Converts an ARGB integer to a Color.
    /// </summary>
    public static System.Drawing.Color ColorFromArgb(uint argb)
    {
        byte a = (byte)((argb >> 24) & 0xFF);
        byte r = (byte)((argb >> 16) & 0xFF);
        byte g = (byte)((argb >> 8) & 0xFF);
        byte b = (byte)(argb & 0xFF);
        return System.Drawing.Color.FromArgb(a, r, g, b);
    }

    public static string GetColorVariable(MaterialColor materialColor)
    {
        return $"var(--md-sys-color-{CaseUtility.PascalToKebab(materialColor.ToString())})";
    }

    public static string GetSurfaceColorVariable(int elevation)
    {
       return GetSurfaceContainerColorVariable(elevation);
    }

    public static MaterialColor GetContainerVariant(MaterialColor materialColor)
    {
        if(!Enum.TryParse<MaterialColor>($"{materialColor.ToString()}Container", out var result))
            return MaterialColor.Surface;
        
        return result;
    }
    
    public static string GetContainerColorVariable(MaterialColor materialColor)
    {
        if (materialColor.ToString().Contains("Container"))
            return GetColorVariable(materialColor);
        
        return GetColorVariable(GetContainerVariant(materialColor));
    }

    public static string GetSurfaceContainerColorVariable(int elevation = 0)
    {
        if (elevation > 5)
            elevation = 5;
        if (elevation == 0)
            return GetColorVariable(MaterialColor.SurfaceContainerLowest);

        return elevation switch
        {
            4 => GetColorVariable(MaterialColor.SurfaceContainerHighest),
            3 => GetColorVariable(MaterialColor.SurfaceContainerHigh),
            2 => GetColorVariable(MaterialColor.SurfaceContainer),
            1 => GetColorVariable(MaterialColor.SurfaceContainerLow),
            _ => GetColorVariable(MaterialColor.SurfaceContainerLowest),
        };
    }

    public static string GetTextColorVariable(MaterialColor materialColor)
    {
        return GetColorVariable(GetTextColorVariant(materialColor));
    }

    public static MaterialColor GetTextColorVariant(MaterialColor materialColor)
    {
        switch (materialColor)
        {
            // Palette key colors
            case MaterialColor.PrimaryPaletteKeyColor:
                return MaterialColor.OnPrimary;

            case MaterialColor.SecondaryPaletteKeyColor:
                return MaterialColor.OnSecondary;

            case MaterialColor.TertiaryPaletteKeyColor:
                return MaterialColor.OnTertiary;

            case MaterialColor.NeutralPaletteKeyColor:
                return MaterialColor.InverseOnSurface;

            case MaterialColor.NeutralVariantPaletteKeyColor:
                return MaterialColor.InverseOnSurface;

            // Background, surface, and container colors
            case MaterialColor.Background:
                return MaterialColor.OnBackground;

            case MaterialColor.OnBackground:
                return MaterialColor.Background;

            case MaterialColor.Surface:
            case MaterialColor.SurfaceDim:
            case MaterialColor.SurfaceBright:
            case MaterialColor.SurfaceContainerLowest:
            case MaterialColor.SurfaceContainerLow:
            case MaterialColor.SurfaceContainer:
            case MaterialColor.SurfaceContainerHigh:
            case MaterialColor.SurfaceContainerHighest:
            case MaterialColor.SurfaceTint:
                return MaterialColor.OnSurface;

            case MaterialColor.OnSurface:
                return MaterialColor.Surface;

            case MaterialColor.SurfaceVariant:
                return MaterialColor.OnSurfaceVariant;

            case MaterialColor.OnSurfaceVariant:
                return MaterialColor.SurfaceVariant;

            case MaterialColor.InverseSurface:
                return MaterialColor.InverseOnSurface;

            case MaterialColor.InverseOnSurface:
                return MaterialColor.InverseSurface;

            // Outline, shadow, and tint colors
            case MaterialColor.Outline:
            case MaterialColor.OutlineVariant:
            case MaterialColor.Shadow:
            case MaterialColor.Scrim:
                return MaterialColor.OnPrimary;
            
            // Primary colors
            case MaterialColor.Primary:
                return MaterialColor.OnPrimary;

            case MaterialColor.OnPrimary:
                return MaterialColor.Primary;

            case MaterialColor.PrimaryContainer:
                return MaterialColor.OnPrimaryContainer;

            case MaterialColor.OnPrimaryContainer:
                return MaterialColor.PrimaryContainer;

            case MaterialColor.InversePrimary:
                return MaterialColor.Primary;

            // Secondary colors
            case MaterialColor.Secondary:
                return MaterialColor.OnSecondary;

            case MaterialColor.OnSecondary:
                return MaterialColor.Secondary;

            case MaterialColor.SecondaryContainer:
                return MaterialColor.OnSecondaryContainer;

            case MaterialColor.OnSecondaryContainer:
                return MaterialColor.SecondaryContainer;

            // Tertiary colors
            case MaterialColor.Tertiary:
                return MaterialColor.OnTertiary;

            case MaterialColor.OnTertiary:
                return MaterialColor.Tertiary;

            case MaterialColor.TertiaryContainer:
                return MaterialColor.OnTertiaryContainer;

            case MaterialColor.OnTertiaryContainer:
                return MaterialColor.TertiaryContainer;

            // Error colors
            case MaterialColor.Error:
                return MaterialColor.OnError;

            case MaterialColor.OnError:
                return MaterialColor.Error;

            case MaterialColor.ErrorContainer:
                return MaterialColor.OnErrorContainer;

            case MaterialColor.OnErrorContainer:
                return MaterialColor.ErrorContainer;

            // Warning colors
            case MaterialColor.Warning:
                return MaterialColor.OnWarning;

            case MaterialColor.OnWarning:
                return MaterialColor.Warning;

            case MaterialColor.WarningContainer:
                return MaterialColor.OnWarningContainer;

            case MaterialColor.OnWarningContainer:
                return MaterialColor.WarningContainer;

            // Info colors
            case MaterialColor.Info:
                return MaterialColor.OnInfo;

            case MaterialColor.OnInfo:
                return MaterialColor.Info;

            case MaterialColor.InfoContainer:
                return MaterialColor.OnInfoContainer;

            case MaterialColor.OnInfoContainer:
                return MaterialColor.InfoContainer;

            // Success colors
            case MaterialColor.Success:
                return MaterialColor.OnSuccess;

            case MaterialColor.OnSuccess:
                return MaterialColor.Success;

            case MaterialColor.SuccessContainer:
                return MaterialColor.OnSuccessContainer;

            case MaterialColor.OnSuccessContainer:
                return MaterialColor.SuccessContainer;

            // Fixed colors
            case MaterialColor.PrimaryFixed:
                return MaterialColor.OnPrimaryFixed;

            case MaterialColor.PrimaryFixedDim:
                return MaterialColor.OnPrimaryFixedVariant;

            case MaterialColor.OnPrimaryFixed:
                return MaterialColor.PrimaryFixed;

            case MaterialColor.OnPrimaryFixedVariant:
                return MaterialColor.PrimaryFixedDim;

            case MaterialColor.SecondaryFixed:
                return MaterialColor.OnSecondaryFixed;

            case MaterialColor.SecondaryFixedDim:
                return MaterialColor.OnSecondaryFixedVariant;

            case MaterialColor.OnSecondaryFixed:
                return MaterialColor.SecondaryFixed;

            case MaterialColor.OnSecondaryFixedVariant:
                return MaterialColor.SecondaryFixedDim;

            case MaterialColor.TertiaryFixed:
                return MaterialColor.OnTertiaryFixed;

            case MaterialColor.TertiaryFixedDim:
                return MaterialColor.OnTertiaryFixedVariant;

            case MaterialColor.OnTertiaryFixed:
                return MaterialColor.TertiaryFixed;

            case MaterialColor.OnTertiaryFixedVariant:
                return MaterialColor.TertiaryFixedDim;

            // Controls and text
            case MaterialColor.ControlActivated:
            case MaterialColor.ControlNormal:
            case MaterialColor.ControlHighlight:
                return MaterialColor.OnPrimary;

            case MaterialColor.TextPrimaryInverse:
                return MaterialColor.Background;

            case MaterialColor.TextSecondaryAndTertiaryInverse:
            case MaterialColor.TextPrimaryInverseDisableOnly:
            case MaterialColor.TextSecondaryAndTertiaryInverseDisabled:
            case MaterialColor.TextHintInverse:
                return MaterialColor.OnBackground;

            default:
                throw new ArgumentOutOfRangeException(nameof(materialColor), materialColor, null);
        }
    }






}