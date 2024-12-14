using System.Drawing;
using Bdziam.UI.Model.Enums;
using Bdziam.UI.Theming.MaterialColors.DynamicColor;
using Bdziam.UI.Utilities;

namespace Bdziam.UI.Theming.Model;

public class BColorScheme(DynamicScheme scheme)
{
    public DynamicScheme CurrentScheme { get; set; } = scheme;

    // Palette key colors
    public Color PrimaryPaletteKeyColor => ColorUtility.ColorFromArgb(CurrentScheme.PrimaryPaletteKeyColor);
    public Color SecondaryPaletteKeyColor => ColorUtility.ColorFromArgb(CurrentScheme.SecondaryPaletteKeyColor);
    public Color TertiaryPaletteKeyColor => ColorUtility.ColorFromArgb(CurrentScheme.TertiaryPaletteKeyColor);
    public Color NeutralPaletteKeyColor => ColorUtility.ColorFromArgb(CurrentScheme.NeutralPaletteKeyColor);

    public Color NeutralVariantPaletteKeyColor =>
        ColorUtility.ColorFromArgb(CurrentScheme.NeutralVariantPaletteKeyColor);

    // Background, surface, and container colors
    public Color Background => ColorUtility.ColorFromArgb(CurrentScheme.Background);
    public Color OnBackground => ColorUtility.ColorFromArgb(CurrentScheme.OnBackground);
    public Color Surface => ColorUtility.ColorFromArgb(CurrentScheme.Surface);
    public Color SurfaceDim => ColorUtility.ColorFromArgb(CurrentScheme.SurfaceDim);
    public Color SurfaceBright => ColorUtility.ColorFromArgb(CurrentScheme.SurfaceBright);
    public Color SurfaceContainerLowest => ColorUtility.ColorFromArgb(CurrentScheme.SurfaceContainerLowest);
    public Color SurfaceContainerLow => ColorUtility.ColorFromArgb(CurrentScheme.SurfaceContainerLow);
    public Color SurfaceContainer => ColorUtility.ColorFromArgb(CurrentScheme.SurfaceContainer);
    public Color SurfaceContainerHigh => ColorUtility.ColorFromArgb(CurrentScheme.SurfaceContainerHigh);
    public Color SurfaceContainerHighest => ColorUtility.ColorFromArgb(CurrentScheme.SurfaceContainerHighest);
    public Color OnSurface => ColorUtility.ColorFromArgb(CurrentScheme.OnSurface);
    public Color SurfaceVariant => ColorUtility.ColorFromArgb(CurrentScheme.SurfaceVariant);
    public Color OnSurfaceVariant => ColorUtility.ColorFromArgb(CurrentScheme.OnSurfaceVariant);
    public Color InverseSurface => ColorUtility.ColorFromArgb(CurrentScheme.InverseSurface);
    public Color InverseOnSurface => ColorUtility.ColorFromArgb(CurrentScheme.InverseOnSurface);

    // Outline, shadow, and tint colors
    public Color Outline => ColorUtility.ColorFromArgb(CurrentScheme.Outline);
    public Color OutlineVariant => ColorUtility.ColorFromArgb(CurrentScheme.OutlineVariant);
    public Color Shadow => ColorUtility.ColorFromArgb(CurrentScheme.Shadow);
    public Color Scrim => ColorUtility.ColorFromArgb(CurrentScheme.Scrim);
    public Color SurfaceTint => ColorUtility.ColorFromArgb(CurrentScheme.SurfaceTint);

    // Primary colors
    public Color Primary => ColorUtility.ColorFromArgb(CurrentScheme.Primary);
    public Color OnPrimary => ColorUtility.ColorFromArgb(CurrentScheme.OnPrimary);
    public Color PrimaryContainer => ColorUtility.ColorFromArgb(CurrentScheme.PrimaryContainer);
    public Color OnPrimaryContainer => ColorUtility.ColorFromArgb(CurrentScheme.OnPrimaryContainer);
    public Color InversePrimary => ColorUtility.ColorFromArgb(CurrentScheme.InversePrimary);

    // Secondary colors
    public Color Secondary => ColorUtility.ColorFromArgb(CurrentScheme.Secondary);
    public Color OnSecondary => ColorUtility.ColorFromArgb(CurrentScheme.OnSecondary);
    public Color SecondaryContainer => ColorUtility.ColorFromArgb(CurrentScheme.SecondaryContainer);
    public Color OnSecondaryContainer => ColorUtility.ColorFromArgb(CurrentScheme.OnSecondaryContainer);

    // Tertiary colors
    public Color Tertiary => ColorUtility.ColorFromArgb(CurrentScheme.Tertiary);
    public Color OnTertiary => ColorUtility.ColorFromArgb(CurrentScheme.OnTertiary);
    public Color TertiaryContainer => ColorUtility.ColorFromArgb(CurrentScheme.TertiaryContainer);
    public Color OnTertiaryContainer => ColorUtility.ColorFromArgb(CurrentScheme.OnTertiaryContainer);

    // Error colors
    public Color Error => ColorUtility.ColorFromArgb(CurrentScheme.Error);
    public Color OnError => ColorUtility.ColorFromArgb(CurrentScheme.OnError);
    public Color ErrorContainer => ColorUtility.ColorFromArgb(CurrentScheme.ErrorContainer);
    public Color OnErrorContainer => ColorUtility.ColorFromArgb(CurrentScheme.OnErrorContainer);

    // Warning colors
    public Color Warning => ColorUtility.ColorFromArgb(CurrentScheme.Warning);
    public Color OnWarning => ColorUtility.ColorFromArgb(CurrentScheme.OnWarning);
    public Color WarningContainer => ColorUtility.ColorFromArgb(CurrentScheme.WarningContainer);
    public Color OnWarningContainer => ColorUtility.ColorFromArgb(CurrentScheme.OnWarningContainer);

    // Info colors
    public Color Info => ColorUtility.ColorFromArgb(CurrentScheme.Info);
    public Color OnInfo => ColorUtility.ColorFromArgb(CurrentScheme.OnInfo);
    public Color InfoContainer => ColorUtility.ColorFromArgb(CurrentScheme.InfoContainer);
    public Color OnInfoContainer => ColorUtility.ColorFromArgb(CurrentScheme.OnInfoContainer);

    // Success colors
    public Color Success => ColorUtility.ColorFromArgb(CurrentScheme.Success);
    public Color OnSuccess => ColorUtility.ColorFromArgb(CurrentScheme.OnSuccess);
    public Color SuccessContainer => ColorUtility.ColorFromArgb(CurrentScheme.SuccessContainer);
    public Color OnSuccessContainer => ColorUtility.ColorFromArgb(CurrentScheme.OnSuccessContainer);

    // Fixed colors
    public Color PrimaryFixed => ColorUtility.ColorFromArgb(CurrentScheme.PrimaryFixed);
    public Color PrimaryFixedDim => ColorUtility.ColorFromArgb(CurrentScheme.PrimaryFixedDim);
    public Color OnPrimaryFixed => ColorUtility.ColorFromArgb(CurrentScheme.OnPrimaryFixed);
    public Color OnPrimaryFixedVariant => ColorUtility.ColorFromArgb(CurrentScheme.OnPrimaryFixedVariant);
    public Color SecondaryFixed => ColorUtility.ColorFromArgb(CurrentScheme.SecondaryFixed);
    public Color SecondaryFixedDim => ColorUtility.ColorFromArgb(CurrentScheme.SecondaryFixedDim);
    public Color OnSecondaryFixed => ColorUtility.ColorFromArgb(CurrentScheme.OnSecondaryFixed);
    public Color OnSecondaryFixedVariant => ColorUtility.ColorFromArgb(CurrentScheme.OnSecondaryFixedVariant);
    public Color TertiaryFixed => ColorUtility.ColorFromArgb(CurrentScheme.TertiaryFixed);
    public Color TertiaryFixedDim => ColorUtility.ColorFromArgb(CurrentScheme.TertiaryFixedDim);
    public Color OnTertiaryFixed => ColorUtility.ColorFromArgb(CurrentScheme.OnTertiaryFixed);
    public Color OnTertiaryFixedVariant => ColorUtility.ColorFromArgb(CurrentScheme.OnTertiaryFixedVariant);

    // Controls and text
    public Color ControlActivated => ColorUtility.ColorFromArgb(CurrentScheme.ControlActivated);
    public Color ControlNormal => ColorUtility.ColorFromArgb(CurrentScheme.ControlNormal);
    public Color ControlHighlight => ColorUtility.ColorFromArgb(CurrentScheme.ControlHighlight);
    public Color TextPrimaryInverse => ColorUtility.ColorFromArgb(CurrentScheme.TextPrimaryInverse);

    public Color TextSecondaryAndTertiaryInverse =>
        ColorUtility.ColorFromArgb(CurrentScheme.TextSecondaryAndTertiaryInverse);

    public Color TextPrimaryInverseDisableOnly =>
        ColorUtility.ColorFromArgb(CurrentScheme.TextPrimaryInverseDisableOnly);

    public Color TextSecondaryAndTertiaryInverseDisabled =>
        ColorUtility.ColorFromArgb(CurrentScheme.TextSecondaryAndTertiaryInverseDisabled);

    public Color TextHintInverse => ColorUtility.ColorFromArgb(CurrentScheme.TextHintInverse);

    public Color GetColorByEnum(MaterialColor materialColorEnum)
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

            _ => throw new ArgumentOutOfRangeException(nameof(materialColorEnum), materialColorEnum,
                "Invalid color enum value")
        };
    }
}