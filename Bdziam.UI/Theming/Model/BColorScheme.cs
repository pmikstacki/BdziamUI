using System.Drawing;
using Bdziam.UI.Model.Enums;
using Bdziam.UI.Theming.MaterialColors.DynamicColor;
using Bdziam.UI.Theming.MaterialColors.Palettes;
using Bdziam.UI.Utilities;

namespace Bdziam.UI.Theming.Model;

public class BColorScheme(DynamicScheme scheme)
{
    public DynamicScheme CurrentScheme { get; set; } = scheme;

    // Palette key colors
    public System.Drawing.Color PrimaryPaletteKeyColor => ColorUtility.ColorFromArgb(CurrentScheme.PrimaryPaletteKeyColor);
    public System.Drawing.Color SecondaryPaletteKeyColor => ColorUtility.ColorFromArgb(CurrentScheme.SecondaryPaletteKeyColor);
    public System.Drawing.Color TertiaryPaletteKeyColor => ColorUtility.ColorFromArgb(CurrentScheme.TertiaryPaletteKeyColor);
    public System.Drawing.Color NeutralPaletteKeyColor => ColorUtility.ColorFromArgb(CurrentScheme.NeutralPaletteKeyColor);

    public System.Drawing.Color NeutralVariantPaletteKeyColor =>
        ColorUtility.ColorFromArgb(CurrentScheme.NeutralVariantPaletteKeyColor);

    // Background, surface, and container colors
    public System.Drawing.Color Background => ColorUtility.ColorFromArgb(CurrentScheme.Background);
    public System.Drawing.Color OnBackground => ColorUtility.ColorFromArgb(CurrentScheme.OnBackground);
    public System.Drawing.Color Surface => ColorUtility.ColorFromArgb(CurrentScheme.Surface);
    public System.Drawing.Color SurfaceDim => ColorUtility.ColorFromArgb(CurrentScheme.SurfaceDim);
    public System.Drawing.Color SurfaceBright => ColorUtility.ColorFromArgb(CurrentScheme.SurfaceBright);
    public System.Drawing.Color SurfaceContainerLowest => ColorUtility.ColorFromArgb(CurrentScheme.SurfaceContainerLowest);
    public System.Drawing.Color SurfaceContainerLow => ColorUtility.ColorFromArgb(CurrentScheme.SurfaceContainerLow);
    public System.Drawing.Color SurfaceContainer => ColorUtility.ColorFromArgb(CurrentScheme.SurfaceContainer);
    public System.Drawing.Color SurfaceContainerHigh => ColorUtility.ColorFromArgb(CurrentScheme.SurfaceContainerHigh);
    public System.Drawing.Color SurfaceContainerHighest => ColorUtility.ColorFromArgb(CurrentScheme.SurfaceContainerHighest);
    public System.Drawing.Color OnSurface => ColorUtility.ColorFromArgb(CurrentScheme.OnSurface);
    public System.Drawing.Color SurfaceVariant => ColorUtility.ColorFromArgb(CurrentScheme.SurfaceVariant);
    public System.Drawing.Color OnSurfaceVariant => ColorUtility.ColorFromArgb(CurrentScheme.OnSurfaceVariant);
    public System.Drawing.Color InverseSurface => ColorUtility.ColorFromArgb(CurrentScheme.InverseSurface);
    public System.Drawing.Color InverseOnSurface => ColorUtility.ColorFromArgb(CurrentScheme.InverseOnSurface);

    // Outline, shadow, and tint colors
    public System.Drawing.Color Outline => ColorUtility.ColorFromArgb(CurrentScheme.Outline);
    public System.Drawing.Color OutlineVariant => ColorUtility.ColorFromArgb(CurrentScheme.OutlineVariant);
    public System.Drawing.Color Shadow => ColorUtility.ColorFromArgb(CurrentScheme.Shadow);
    public System.Drawing.Color Scrim => ColorUtility.ColorFromArgb(CurrentScheme.Scrim);
    public System.Drawing.Color SurfaceTint => ColorUtility.ColorFromArgb(CurrentScheme.SurfaceTint);

    // Primary colors
    public System.Drawing.Color Primary => ColorUtility.ColorFromArgb(CurrentScheme.Primary);
    public System.Drawing.Color OnPrimary => ColorUtility.ColorFromArgb(CurrentScheme.OnPrimary);
    public System.Drawing.Color PrimaryContainer => ColorUtility.ColorFromArgb(CurrentScheme.PrimaryContainer);
    public System.Drawing.Color OnPrimaryContainer => ColorUtility.ColorFromArgb(CurrentScheme.OnPrimaryContainer);
    public System.Drawing.Color InversePrimary => ColorUtility.ColorFromArgb(CurrentScheme.InversePrimary);

    // Secondary colors
    public System.Drawing.Color Secondary => ColorUtility.ColorFromArgb(CurrentScheme.Secondary);
    public System.Drawing.Color OnSecondary => ColorUtility.ColorFromArgb(CurrentScheme.OnSecondary);
    public System.Drawing.Color SecondaryContainer => ColorUtility.ColorFromArgb(CurrentScheme.SecondaryContainer);
    public System.Drawing.Color OnSecondaryContainer => ColorUtility.ColorFromArgb(CurrentScheme.OnSecondaryContainer);

    // Tertiary colors
    public System.Drawing.Color Tertiary => ColorUtility.ColorFromArgb(CurrentScheme.Tertiary);
    public System.Drawing.Color OnTertiary => ColorUtility.ColorFromArgb(CurrentScheme.OnTertiary);
    public System.Drawing.Color TertiaryContainer => ColorUtility.ColorFromArgb(CurrentScheme.TertiaryContainer);
    public System.Drawing.Color OnTertiaryContainer => ColorUtility.ColorFromArgb(CurrentScheme.OnTertiaryContainer);

    // Error colors
    public System.Drawing.Color Error => ColorUtility.ColorFromArgb(CurrentScheme.Error);
    public System.Drawing.Color OnError => ColorUtility.ColorFromArgb(CurrentScheme.OnError);
    public System.Drawing.Color ErrorContainer => ColorUtility.ColorFromArgb(CurrentScheme.ErrorContainer);
    public System.Drawing.Color OnErrorContainer => ColorUtility.ColorFromArgb(CurrentScheme.OnErrorContainer);

    // Warning colors
    public System.Drawing.Color Warning => ColorUtility.ColorFromArgb(CurrentScheme.Warning);
    public System.Drawing.Color OnWarning => ColorUtility.ColorFromArgb(CurrentScheme.OnWarning);
    public System.Drawing.Color WarningContainer => ColorUtility.ColorFromArgb(CurrentScheme.WarningContainer);
    public System.Drawing.Color OnWarningContainer => ColorUtility.ColorFromArgb(CurrentScheme.OnWarningContainer);

    // Info colors
    public System.Drawing.Color Info => ColorUtility.ColorFromArgb(CurrentScheme.Info);
    public System.Drawing.Color OnInfo => ColorUtility.ColorFromArgb(CurrentScheme.OnInfo);
    public System.Drawing.Color InfoContainer => ColorUtility.ColorFromArgb(CurrentScheme.InfoContainer);
    public System.Drawing.Color OnInfoContainer => ColorUtility.ColorFromArgb(CurrentScheme.OnInfoContainer);

    // Success colors
    public System.Drawing.Color Success => ColorUtility.ColorFromArgb(CurrentScheme.Success);
    public System.Drawing.Color OnSuccess => ColorUtility.ColorFromArgb(CurrentScheme.OnSuccess);
    public System.Drawing.Color SuccessContainer => ColorUtility.ColorFromArgb(CurrentScheme.SuccessContainer);
    public System.Drawing.Color OnSuccessContainer => ColorUtility.ColorFromArgb(CurrentScheme.OnSuccessContainer);

    // Fixed colors
    public System.Drawing.Color PrimaryFixed => ColorUtility.ColorFromArgb(CurrentScheme.PrimaryFixed);
    public System.Drawing.Color PrimaryFixedDim => ColorUtility.ColorFromArgb(CurrentScheme.PrimaryFixedDim);
    public System.Drawing.Color OnPrimaryFixed => ColorUtility.ColorFromArgb(CurrentScheme.OnPrimaryFixed);
    public System.Drawing.Color OnPrimaryFixedVariant => ColorUtility.ColorFromArgb(CurrentScheme.OnPrimaryFixedVariant);
    public System.Drawing.Color SecondaryFixed => ColorUtility.ColorFromArgb(CurrentScheme.SecondaryFixed);
    public System.Drawing.Color SecondaryFixedDim => ColorUtility.ColorFromArgb(CurrentScheme.SecondaryFixedDim);
    public System.Drawing.Color OnSecondaryFixed => ColorUtility.ColorFromArgb(CurrentScheme.OnSecondaryFixed);
    public System.Drawing.Color OnSecondaryFixedVariant => ColorUtility.ColorFromArgb(CurrentScheme.OnSecondaryFixedVariant);
    public System.Drawing.Color TertiaryFixed => ColorUtility.ColorFromArgb(CurrentScheme.TertiaryFixed);
    public System.Drawing.Color TertiaryFixedDim => ColorUtility.ColorFromArgb(CurrentScheme.TertiaryFixedDim);
    public System.Drawing.Color OnTertiaryFixed => ColorUtility.ColorFromArgb(CurrentScheme.OnTertiaryFixed);
    public System.Drawing.Color OnTertiaryFixedVariant => ColorUtility.ColorFromArgb(CurrentScheme.OnTertiaryFixedVariant);

    // Controls and text
    public System.Drawing.Color ControlActivated => ColorUtility.ColorFromArgb(CurrentScheme.ControlActivated);
    public System.Drawing.Color ControlNormal => ColorUtility.ColorFromArgb(CurrentScheme.ControlNormal);
    public System.Drawing.Color ControlHighlight => ColorUtility.ColorFromArgb(CurrentScheme.ControlHighlight);
    public System.Drawing.Color TextPrimaryInverse => ColorUtility.ColorFromArgb(CurrentScheme.TextPrimaryInverse);

    public System.Drawing.Color TextSecondaryAndTertiaryInverse =>
        ColorUtility.ColorFromArgb(CurrentScheme.TextSecondaryAndTertiaryInverse);

    public System.Drawing.Color TextPrimaryInverseDisableOnly =>
        ColorUtility.ColorFromArgb(CurrentScheme.TextPrimaryInverseDisableOnly);

    public System.Drawing.Color TextSecondaryAndTertiaryInverseDisabled =>
        ColorUtility.ColorFromArgb(CurrentScheme.TextSecondaryAndTertiaryInverseDisabled);

    public System.Drawing.Color TextHintInverse => ColorUtility.ColorFromArgb(CurrentScheme.TextHintInverse);

    public System.Drawing.Color GetColorByEnum(MaterialColor materialColorEnum)
    {
        return materialColorEnum switch
        {
            // Palette key colors
            MaterialColor.PrimaryPaletteKeyColor => PrimaryPaletteKeyColor,
            MaterialColor.SecondaryPaletteKeyColor => SecondaryPaletteKeyColor,
            MaterialColor.TertiaryPaletteKeyColor => TertiaryPaletteKeyColor,
            MaterialColor.NeutralPaletteKeyColor => NeutralPaletteKeyColor,
            MaterialColor.NeutralVariantPaletteKeyColor => NeutralVariantPaletteKeyColor,

            // Background, surface, and container colors
            MaterialColor.Background => Background,
            MaterialColor.OnBackground => OnBackground,
            MaterialColor.Surface => Surface,
            MaterialColor.SurfaceDim => SurfaceDim,
            MaterialColor.SurfaceBright => SurfaceBright,
            MaterialColor.SurfaceContainerLowest => SurfaceContainerLowest,
            MaterialColor.SurfaceContainerLow => SurfaceContainerLow,
            MaterialColor.SurfaceContainer => SurfaceContainer,
            MaterialColor.SurfaceContainerHigh => SurfaceContainerHigh,
            MaterialColor.SurfaceContainerHighest => SurfaceContainerHighest,
            MaterialColor.OnSurface => OnSurface,
            MaterialColor.SurfaceVariant => SurfaceVariant,
            MaterialColor.OnSurfaceVariant => OnSurfaceVariant,
            MaterialColor.InverseSurface => InverseSurface,
            MaterialColor.InverseOnSurface => InverseOnSurface,

            // Outline, shadow, and tint colors
            MaterialColor.Outline => Outline,
            MaterialColor.OutlineVariant => OutlineVariant,
            MaterialColor.Shadow => Shadow,
            MaterialColor.Scrim => Scrim,
            MaterialColor.SurfaceTint => SurfaceTint,

            // Primary colors
            MaterialColor.Primary => Primary,
            MaterialColor.OnPrimary => OnPrimary,
            MaterialColor.PrimaryContainer => PrimaryContainer,
            MaterialColor.OnPrimaryContainer => OnPrimaryContainer,
            MaterialColor.InversePrimary => InversePrimary,

            // Secondary colors
            MaterialColor.Secondary => Secondary,
            MaterialColor.OnSecondary => OnSecondary,
            MaterialColor.SecondaryContainer => SecondaryContainer,
            MaterialColor.OnSecondaryContainer => OnSecondaryContainer,

            // Tertiary colors
            MaterialColor.Tertiary => Tertiary,
            MaterialColor.OnTertiary => OnTertiary,
            MaterialColor.TertiaryContainer => TertiaryContainer,
            MaterialColor.OnTertiaryContainer => OnTertiaryContainer,

            // Error colors
            MaterialColor.Error => Error,
            MaterialColor.OnError => OnError,
            MaterialColor.ErrorContainer => ErrorContainer,
            MaterialColor.OnErrorContainer => OnErrorContainer,

            // Warning colors
            MaterialColor.Warning => Warning,
            MaterialColor.OnWarning => OnWarning,
            MaterialColor.WarningContainer => WarningContainer,
            MaterialColor.OnWarningContainer => OnWarningContainer,

            // Info colors
            MaterialColor.Info => Info,
            MaterialColor.OnInfo => OnInfo,
            MaterialColor.InfoContainer => InfoContainer,
            MaterialColor.OnInfoContainer => OnInfoContainer,

            // Success colors
            MaterialColor.Success => Success,
            MaterialColor.OnSuccess => OnSuccess,
            MaterialColor.SuccessContainer => SuccessContainer,
            MaterialColor.OnSuccessContainer => OnSuccessContainer,

            // Fixed colors
            MaterialColor.PrimaryFixed => PrimaryFixed,
            MaterialColor.PrimaryFixedDim => PrimaryFixedDim,
            MaterialColor.OnPrimaryFixed => OnPrimaryFixed,
            MaterialColor.OnPrimaryFixedVariant => OnPrimaryFixedVariant,
            MaterialColor.SecondaryFixed => SecondaryFixed,
            MaterialColor.SecondaryFixedDim => SecondaryFixedDim,
            MaterialColor.OnSecondaryFixed => OnSecondaryFixed,
            MaterialColor.OnSecondaryFixedVariant => OnSecondaryFixedVariant,
            MaterialColor.TertiaryFixed => TertiaryFixed,
            MaterialColor.TertiaryFixedDim => TertiaryFixedDim,
            MaterialColor.OnTertiaryFixed => OnTertiaryFixed,
            MaterialColor.OnTertiaryFixedVariant => OnTertiaryFixedVariant,

            // Controls and text
            MaterialColor.ControlActivated => ControlActivated,
            MaterialColor.ControlNormal => ControlNormal,
            MaterialColor.ControlHighlight => ControlHighlight,
            MaterialColor.TextPrimaryInverse => TextPrimaryInverse,
            MaterialColor.TextSecondaryAndTertiaryInverse => TextSecondaryAndTertiaryInverse,
            MaterialColor.TextPrimaryInverseDisableOnly => TextPrimaryInverseDisableOnly,
            MaterialColor.TextSecondaryAndTertiaryInverseDisabled => TextSecondaryAndTertiaryInverseDisabled,
            MaterialColor.TextHintInverse => TextHintInverse,

            _ => throw new ArgumentOutOfRangeException(nameof(materialColorEnum), materialColorEnum, "Invalid color enum value")
        };

    }
}
