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

    public static string GetColorVariable(MdSysColor mdSysColor)
    {
        return $"var(--md-sys-color-{CaseUtility.PascalToKebab(mdSysColor.ToString())})";
    }

    public static string GetSurfaceColorVariable(int elevation)
    {
       return GetSurfaceContainerColorVariable(elevation);
    }

    public static MdSysColor GetContainerVariant(MdSysColor mdSysColor)
    {
        if(!Enum.TryParse<MdSysColor>($"{mdSysColor.ToString()}Container", out var result))
            return MdSysColor.Surface;
        
        return result;
    }
    
    public static string GetContainerColorVariable(MdSysColor mdSysColor)
    {
        if (mdSysColor.ToString().Contains("Container"))
            return GetColorVariable(mdSysColor);
        
        return GetColorVariable(GetContainerVariant(mdSysColor));
    }

    public static string GetSurfaceContainerColorVariable(int elevation = 0)
    {
        if (elevation > 5)
            elevation = 5;
        if (elevation == 0)
            return GetColorVariable(MdSysColor.SurfaceContainerLowest);

        return elevation switch
        {
            4 => GetColorVariable(MdSysColor.SurfaceContainerHighest),
            3 => GetColorVariable(MdSysColor.SurfaceContainerHigh),
            2 => GetColorVariable(MdSysColor.SurfaceContainer),
            1 => GetColorVariable(MdSysColor.SurfaceContainerLow),
            _ => GetColorVariable(MdSysColor.SurfaceContainerLowest),
        };
    }

    public static string GetTextColorVariable(MdSysColor mdSysColor)
    {
        return GetColorVariable(GetTextColorVariant(mdSysColor));
    }

    public static MdSysColor GetTextColorVariant(MdSysColor mdSysColor)
    {
        switch (mdSysColor)
        {
            // Palette key colors
            case MdSysColor.PrimaryPaletteKeyColor:
                return MdSysColor.OnPrimary;

            case MdSysColor.SecondaryPaletteKeyColor:
                return MdSysColor.OnSecondary;

            case MdSysColor.TertiaryPaletteKeyColor:
                return MdSysColor.OnTertiary;

            case MdSysColor.NeutralPaletteKeyColor:
                return MdSysColor.OnSurface;

            case MdSysColor.NeutralVariantPaletteKeyColor:
                return MdSysColor.OnSurfaceVariant;

            // Background, surface, and container colors
            case MdSysColor.Background:
                return MdSysColor.OnBackground;

            case MdSysColor.OnBackground:
                return MdSysColor.Background;

            case MdSysColor.Surface:
            case MdSysColor.SurfaceDim:
            case MdSysColor.SurfaceBright:
            case MdSysColor.SurfaceContainerLowest:
            case MdSysColor.SurfaceContainerLow:
            case MdSysColor.SurfaceContainer:
            case MdSysColor.SurfaceContainerHigh:
            case MdSysColor.SurfaceContainerHighest:
                return MdSysColor.OnSurface;

            case MdSysColor.OnSurface:
                return MdSysColor.Surface;

            case MdSysColor.SurfaceVariant:
                return MdSysColor.OnSurfaceVariant;

            case MdSysColor.OnSurfaceVariant:
                return MdSysColor.SurfaceVariant;

            case MdSysColor.InverseSurface:
                return MdSysColor.InverseOnSurface;

            case MdSysColor.InverseOnSurface:
                return MdSysColor.InverseSurface;

            // Outline, shadow, and tint colors
            case MdSysColor.Outline:
            case MdSysColor.OutlineVariant:
                return MdSysColor.OnSurfaceVariant;

            case MdSysColor.Shadow:
            case MdSysColor.Scrim:
            case MdSysColor.SurfaceTint:
                return MdSysColor.Primary;

            // Primary colors
            case MdSysColor.Primary:
                return MdSysColor.OnPrimary;

            case MdSysColor.OnPrimary:
                return MdSysColor.Primary;

            case MdSysColor.PrimaryContainer:
                return MdSysColor.OnPrimaryContainer;

            case MdSysColor.OnPrimaryContainer:
                return MdSysColor.PrimaryContainer;

            case MdSysColor.InversePrimary:
                return MdSysColor.Primary;

            // Secondary colors
            case MdSysColor.Secondary:
                return MdSysColor.OnSecondary;

            case MdSysColor.OnSecondary:
                return MdSysColor.Secondary;

            case MdSysColor.SecondaryContainer:
                return MdSysColor.OnSecondaryContainer;

            case MdSysColor.OnSecondaryContainer:
                return MdSysColor.SecondaryContainer;

            // Tertiary colors
            case MdSysColor.Tertiary:
                return MdSysColor.OnTertiary;

            case MdSysColor.OnTertiary:
                return MdSysColor.Tertiary;

            case MdSysColor.TertiaryContainer:
                return MdSysColor.OnTertiaryContainer;

            case MdSysColor.OnTertiaryContainer:
                return MdSysColor.TertiaryContainer;

            // Error colors
            case MdSysColor.Error:
                return MdSysColor.OnError;

            case MdSysColor.OnError:
                return MdSysColor.Error;

            case MdSysColor.ErrorContainer:
                return MdSysColor.OnErrorContainer;

            case MdSysColor.OnErrorContainer:
                return MdSysColor.ErrorContainer;

            // Warning colors
            case MdSysColor.Warning:
                return MdSysColor.OnWarning;

            case MdSysColor.OnWarning:
                return MdSysColor.Warning;

            case MdSysColor.WarningContainer:
                return MdSysColor.OnWarningContainer;

            case MdSysColor.OnWarningContainer:
                return MdSysColor.WarningContainer;

            // Info colors
            case MdSysColor.Info:
                return MdSysColor.OnInfo;

            case MdSysColor.OnInfo:
                return MdSysColor.Info;

            case MdSysColor.InfoContainer:
                return MdSysColor.OnInfoContainer;

            case MdSysColor.OnInfoContainer:
                return MdSysColor.InfoContainer;

            // Success colors
            case MdSysColor.Success:
                return MdSysColor.OnSuccess;

            case MdSysColor.OnSuccess:
                return MdSysColor.Success;

            case MdSysColor.SuccessContainer:
                return MdSysColor.OnSuccessContainer;

            case MdSysColor.OnSuccessContainer:
                return MdSysColor.SuccessContainer;

            // Fixed colors
            case MdSysColor.PrimaryFixed:
                return MdSysColor.OnPrimaryFixed;

            case MdSysColor.PrimaryFixedDim:
                return MdSysColor.OnPrimaryFixedVariant;

            case MdSysColor.OnPrimaryFixed:
                return MdSysColor.PrimaryFixed;

            case MdSysColor.OnPrimaryFixedVariant:
                return MdSysColor.PrimaryFixedDim;

            case MdSysColor.SecondaryFixed:
                return MdSysColor.OnSecondaryFixed;

            case MdSysColor.SecondaryFixedDim:
                return MdSysColor.OnSecondaryFixedVariant;

            case MdSysColor.OnSecondaryFixed:
                return MdSysColor.SecondaryFixed;

            case MdSysColor.OnSecondaryFixedVariant:
                return MdSysColor.SecondaryFixedDim;

            case MdSysColor.TertiaryFixed:
                return MdSysColor.OnTertiaryFixed;

            case MdSysColor.TertiaryFixedDim:
                return MdSysColor.OnTertiaryFixedVariant;

            case MdSysColor.OnTertiaryFixed:
                return MdSysColor.TertiaryFixed;

            case MdSysColor.OnTertiaryFixedVariant:
                return MdSysColor.TertiaryFixedDim;

            // Controls and text
            case MdSysColor.ControlActivated:
            case MdSysColor.ControlNormal:
            case MdSysColor.ControlHighlight:
                return MdSysColor.OnSurface;

            case MdSysColor.TextPrimaryInverse:
                return MdSysColor.Background;

            case MdSysColor.TextSecondaryAndTertiaryInverse:
            case MdSysColor.TextPrimaryInverseDisableOnly:
            case MdSysColor.TextSecondaryAndTertiaryInverseDisabled:
            case MdSysColor.TextHintInverse:
                return MdSysColor.OnBackground;

            default:
                throw new ArgumentOutOfRangeException(nameof(mdSysColor), mdSysColor, null);
        }
    }






}