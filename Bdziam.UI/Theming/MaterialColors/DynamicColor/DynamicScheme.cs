using Bdziam.UI.Theming.MaterialColors.ColorSpace;
using Bdziam.UI.Theming.MaterialColors.Palettes;
using Bdziam.UI.Theming.MaterialColors.Utils;

namespace Bdziam.UI.Theming.MaterialColors.DynamicColor
{
    public class DynamicScheme
    {
        public uint SourceColorArgb { get; }
        public Hct SourceColorHct { get; }
        public DynamicSchemeVariant Variant { get; }
        public bool IsDark { get; }
        public double ContrastLevel { get; }

        public TonalPalette PrimaryPalette { get; }
        public TonalPalette SecondaryPalette { get; }
        public TonalPalette TertiaryPalette { get; }
        public TonalPalette NeutralPalette { get; }
        public TonalPalette NeutralVariantPalette { get; }
        public TonalPalette ErrorPalette { get; }
        public TonalPalette SuccessPalette { get; }

        public TonalPalette InfoPalette { get; }
        public TonalPalette WarningPalette { get; }

        public DynamicScheme(
            Hct sourceColorHct,
            DynamicSchemeVariant variant,
            bool isDark,
            double contrastLevel,
            TonalPalette primaryPalette,
            TonalPalette secondaryPalette,
            TonalPalette tertiaryPalette,
            TonalPalette neutralPalette,
            TonalPalette neutralVariantPalette)
            : this(sourceColorHct, variant, isDark, contrastLevel, primaryPalette, secondaryPalette, tertiaryPalette, neutralPalette, neutralVariantPalette, null, null, null, null)
        { }

        public DynamicScheme(
            Hct sourceColorHct,
            DynamicSchemeVariant variant,
            bool isDark,
            double contrastLevel,
            TonalPalette primaryPalette,
            TonalPalette secondaryPalette,
            TonalPalette tertiaryPalette,
            TonalPalette neutralPalette,
            TonalPalette neutralVariantPalette,
            TonalPalette? errorPalette,
            TonalPalette? warningPalette,
            TonalPalette? infoPalette,
            TonalPalette? successPalette)
        {
            SourceColorArgb = sourceColorHct.ToInt();
            SourceColorHct = sourceColorHct;
            Variant = variant;
            IsDark = isDark;
            ContrastLevel = contrastLevel;

            PrimaryPalette = primaryPalette;
            SecondaryPalette = secondaryPalette;
            TertiaryPalette = tertiaryPalette;
            NeutralPalette = neutralPalette;
            NeutralVariantPalette = neutralVariantPalette;
            ErrorPalette = errorPalette ?? TonalPalette.FromHueAndChroma(25.0, 84.0);
            InfoPalette = infoPalette ?? TonalPalette.FromHueAndChroma(282, 80);
            WarningPalette = warningPalette ?? TonalPalette.FromHueAndChroma(59.0, 63.0);;
            SuccessPalette = successPalette ?? TonalPalette.FromHueAndChroma(139, 89.0);;
        }

        public static double GetRotatedHue(Hct sourceColorHct, double[] hues, double[] rotations)
        {
            double sourceHue = sourceColorHct.Hue;
            if (rotations.Length == 1)
            {
                return MathUtils.SanitizeDegreesDouble(sourceHue + rotations[0]);
            }

            for (int i = 0; i < hues.Length - 1; i++)
            {
                double thisHue = hues[i];
                double nextHue = hues[i + 1];
                if (thisHue < sourceHue && sourceHue < nextHue)
                {
                    return MathUtils.SanitizeDegreesDouble(sourceHue + rotations[i]);
                }
            }

            return sourceHue;
        }

        public Hct GetHct(DynamicColor dynamicColor) => dynamicColor.GetHct(this);

        public uint GetArgb(DynamicColor dynamicColor) => dynamicColor.GetArgb(this);

        // Properties for key colors
        public uint PrimaryPaletteKeyColor => GetArgb(new MaterialDynamicColors().PrimaryPaletteKeyColor());
        public uint SecondaryPaletteKeyColor => GetArgb(new MaterialDynamicColors().SecondaryPaletteKeyColor());
        public uint TertiaryPaletteKeyColor => GetArgb(new MaterialDynamicColors().TertiaryPaletteKeyColor());
        public uint NeutralPaletteKeyColor => GetArgb(new MaterialDynamicColors().NeutralPaletteKeyColor());
        public uint NeutralVariantPaletteKeyColor => GetArgb(new MaterialDynamicColors().NeutralVariantPaletteKeyColor());

        // Properties for colors
        public uint Background => GetArgb(new MaterialDynamicColors().Background());
        public uint OnBackground => GetArgb(new MaterialDynamicColors().OnBackground());
        public uint Surface => GetArgb(new MaterialDynamicColors().Surface());
        public uint SurfaceDim => GetArgb(new MaterialDynamicColors().SurfaceDim());
        public uint SurfaceBright => GetArgb(new MaterialDynamicColors().SurfaceBright());
        public uint SurfaceContainerLowest => GetArgb(new MaterialDynamicColors().SurfaceContainerLowest());
        public uint SurfaceContainerLow => GetArgb(new MaterialDynamicColors().SurfaceContainerLow());
        public uint SurfaceContainer => GetArgb(new MaterialDynamicColors().SurfaceContainer());
        public uint SurfaceContainerHigh => GetArgb(new MaterialDynamicColors().SurfaceContainerHigh());
        public uint SurfaceContainerHighest => GetArgb(new MaterialDynamicColors().SurfaceContainerHighest());
        public uint OnSurface => GetArgb(new MaterialDynamicColors().OnSurface());
        public uint SurfaceVariant => GetArgb(new MaterialDynamicColors().SurfaceVariant());
        public uint OnSurfaceVariant => GetArgb(new MaterialDynamicColors().OnSurfaceVariant());
        public uint InverseSurface => GetArgb(new MaterialDynamicColors().InverseSurface());
        public uint InverseOnSurface => GetArgb(new MaterialDynamicColors().InverseOnSurface());
        public uint Outline => GetArgb(new MaterialDynamicColors().Outline());
        public uint OutlineVariant => GetArgb(new MaterialDynamicColors().OutlineVariant());
        public uint Shadow => GetArgb(new MaterialDynamicColors().Shadow());
        public uint Scrim => GetArgb(new MaterialDynamicColors().Scrim());
        public uint SurfaceTint => GetArgb(new MaterialDynamicColors().SurfaceTint());
        public uint Primary => GetArgb(new MaterialDynamicColors().Primary());
        public uint OnPrimary => GetArgb(new MaterialDynamicColors().OnPrimary());
        public uint PrimaryContainer => GetArgb(new MaterialDynamicColors().PrimaryContainer());
        public uint OnPrimaryContainer => GetArgb(new MaterialDynamicColors().OnPrimaryContainer());
        public uint InversePrimary => GetArgb(new MaterialDynamicColors().InversePrimary());
        public uint Secondary => GetArgb(new MaterialDynamicColors().Secondary());
        public uint OnSecondary => GetArgb(new MaterialDynamicColors().OnSecondary());
        public uint SecondaryContainer => GetArgb(new MaterialDynamicColors().SecondaryContainer());
        public uint OnSecondaryContainer => GetArgb(new MaterialDynamicColors().OnSecondaryContainer());
        public uint Tertiary => GetArgb(new MaterialDynamicColors().Tertiary());
        public uint OnTertiary => GetArgb(new MaterialDynamicColors().OnTertiary());
        public uint TertiaryContainer => GetArgb(new MaterialDynamicColors().TertiaryContainer());
        public uint OnTertiaryContainer => GetArgb(new MaterialDynamicColors().OnTertiaryContainer());
        public uint Error => GetArgb(new MaterialDynamicColors().Error());
        public uint OnError => GetArgb(new MaterialDynamicColors().OnError());
        public uint ErrorContainer => GetArgb(new MaterialDynamicColors().ErrorContainer());
        public uint OnErrorContainer => GetArgb(new MaterialDynamicColors().OnErrorContainer());
        public uint Warning => GetArgb(new MaterialDynamicColors().Warning());
        public uint OnWarning => GetArgb(new MaterialDynamicColors().OnWarning());
        public uint WarningContainer => GetArgb(new MaterialDynamicColors().WarningContainer());
        public uint OnWarningContainer => GetArgb(new MaterialDynamicColors().OnWarningContainer());
        public uint Info => GetArgb(new MaterialDynamicColors().Info());
        public uint OnInfo => GetArgb(new MaterialDynamicColors().OnInfo());
        public uint InfoContainer => GetArgb(new MaterialDynamicColors().InfoContainer());
        public uint OnInfoContainer => GetArgb(new MaterialDynamicColors().OnInfoContainer());
        public uint Success => GetArgb(new MaterialDynamicColors().Success());
        public uint OnSuccess => GetArgb(new MaterialDynamicColors().OnSuccess());
        public uint SuccessContainer => GetArgb(new MaterialDynamicColors().SuccessContainer());
        public uint OnSuccessContainer => GetArgb(new MaterialDynamicColors().OnSuccessContainer());
        // Properties for fixed colors
        public uint PrimaryFixed => GetArgb(new MaterialDynamicColors().PrimaryFixed());
        public uint PrimaryFixedDim => GetArgb(new MaterialDynamicColors().PrimaryFixedDim());
        public uint OnPrimaryFixed => GetArgb(new MaterialDynamicColors().OnPrimaryFixed());
        public uint OnPrimaryFixedVariant => GetArgb(new MaterialDynamicColors().OnPrimaryFixedVariant());
        public uint SecondaryFixed => GetArgb(new MaterialDynamicColors().SecondaryFixed());
        public uint SecondaryFixedDim => GetArgb(new MaterialDynamicColors().SecondaryFixedDim());
        public uint OnSecondaryFixed => GetArgb(new MaterialDynamicColors().OnSecondaryFixed());
        public uint OnSecondaryFixedVariant => GetArgb(new MaterialDynamicColors().OnSecondaryFixedVariant());
        public uint TertiaryFixed => GetArgb(new MaterialDynamicColors().TertiaryFixed());
        public uint TertiaryFixedDim => GetArgb(new MaterialDynamicColors().TertiaryFixedDim());
        public uint OnTertiaryFixed => GetArgb(new MaterialDynamicColors().OnTertiaryFixed());
        public uint OnTertiaryFixedVariant => GetArgb(new MaterialDynamicColors().OnTertiaryFixedVariant());

        // Properties for controls and text
        public uint ControlActivated => GetArgb(new MaterialDynamicColors().ControlActivated());
        public uint ControlNormal => GetArgb(new MaterialDynamicColors().ControlNormal());
        public uint ControlHighlight => GetArgb(new MaterialDynamicColors().ControlHighlight());
        public uint TextPrimaryInverse => GetArgb(new MaterialDynamicColors().TextPrimaryInverse());
        public uint TextSecondaryAndTertiaryInverse => GetArgb(new MaterialDynamicColors().TextSecondaryAndTertiaryInverse());
        public uint TextPrimaryInverseDisableOnly => GetArgb(new MaterialDynamicColors().TextPrimaryInverseDisableOnly());
        public uint TextSecondaryAndTertiaryInverseDisabled => GetArgb(new MaterialDynamicColors().TextSecondaryAndTertiaryInverseDisabled());
        public uint TextHintInverse => GetArgb(new MaterialDynamicColors().TextHintInverse());
    }
}
