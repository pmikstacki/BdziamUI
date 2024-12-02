using Bdziam.UI.Theming.MaterialColors.ColorSpace;
using Bdziam.UI.Theming.MaterialColors.Dislike;

namespace Bdziam.UI.Theming.MaterialColors.DynamicColor;

using System;

public static class MaterialDynamicColors
{
    public static bool IsExtendedFidelity { get; } 

    public static DynamicColor HighestSurface(DynamicScheme s)
    {
        return s.IsDark ? SurfaceBright() : SurfaceDim();
    }

    public static DynamicColor PrimaryPaletteKeyColor()
    {
        return DynamicColor.FromPalette(
            "primary_palette_key_color",
            (s) => s.PrimaryPalette,
            (s) => s.PrimaryPalette.KeyColor.Tone
        );
    }

    public static DynamicColor SecondaryPaletteKeyColor()
    {
        return DynamicColor.FromPalette(
            "secondary_palette_key_color",
            (s) => s.SecondaryPalette,
            (s) => s.SecondaryPalette.KeyColor.Tone
        );
    }

    public static DynamicColor TertiaryPaletteKeyColor()
    {
        return DynamicColor.FromPalette(
            "tertiary_palette_key_color",
            (s) => s.TertiaryPalette,
            (s) => s.TertiaryPalette.KeyColor.Tone
        );
    }

    public static DynamicColor NeutralPaletteKeyColor()
    {
        return DynamicColor.FromPalette(
            "neutral_palette_key_color",
            (s) => s.NeutralPalette,
            (s) => s.NeutralPalette.KeyColor.Tone
        );
    }

    public static DynamicColor NeutralVariantPaletteKeyColor()
    {
        return DynamicColor.FromPalette(
            "neutral_variant_palette_key_color",
            (s) => s.NeutralVariantPalette,
            (s) => s.NeutralVariantPalette.KeyColor.Tone
        );
    }

    public static DynamicColor Background()
    {
        return new DynamicColor(
            name: "background",
            palette: (s) => s.NeutralPalette,
            tone: (s) => s.IsDark ? 6.0 : 98.0,
            isBackground: true,
            background: null,
            secondBackground: null,
            contrastCurve: null,
            toneDeltaPair: null
        );
    }

    public static DynamicColor OnBackground()
    {
        return new DynamicColor(
            name: "on_background",
            palette: (s) => s.NeutralPalette,
            tone: (s) => s.IsDark ? 90.0 : 10.0,
            isBackground: false,
            background: (s) => Background(),
            secondBackground: null,
            contrastCurve: new ContrastCurve(3.0, 3.0, 4.5, 7.0),
            toneDeltaPair: null
        );
    }

    public static DynamicColor Surface()
    {
        return new DynamicColor(
            name: "surface",
            palette: (s) => s.NeutralPalette,
            tone: (s) => s.IsDark ? 6.0 : 98.0,
            isBackground: true,
            background: null,
            secondBackground: null,
            contrastCurve: null,
            toneDeltaPair: null
        );
    }

    public static DynamicColor SurfaceDim()
    {
        return new DynamicColor(
            name: "surface_dim",
            palette: (s) => s.NeutralPalette,
            tone: (s) => s.IsDark ? 6.0 : new ContrastCurve(87.0, 87.0, 80.0, 75.0).Get(s.ContrastLevel),
            isBackground: true,
            background: null,
            secondBackground: null,
            contrastCurve: null,
            toneDeltaPair: null
        );
    }

    public static DynamicColor SurfaceBright()
    {
        return new DynamicColor(
            name: "surface_bright",
            palette: (s) => s.NeutralPalette,
            tone: (s) => s.IsDark ? new ContrastCurve(24.0, 24.0, 29.0, 34.0).Get(s.ContrastLevel) : 98.0,
            isBackground: true,
            background: null,
            secondBackground: null,
            contrastCurve: null,
            toneDeltaPair: null
        );
    }

    public static DynamicColor SurfaceContainerLowest()
    {
        return new DynamicColor(
            name: "surface_container_lowest",
            palette: (s) => s.NeutralPalette,
            tone: (s) => s.IsDark ? new ContrastCurve(4.0, 4.0, 2.0, 0.0).Get(s.ContrastLevel) : 100.0,
            isBackground: true,
            background: null,
            secondBackground: null,
            contrastCurve: null,
            toneDeltaPair: null
        );
    }

    public static DynamicColor SurfaceContainerLow()
    {
        return new DynamicColor(
            name: "surface_container_low",
            palette: (s) => s.NeutralPalette,
            tone: (s) =>
                s.IsDark
                    ? new ContrastCurve(10.0, 10.0, 11.0, 12.0).Get(s.ContrastLevel)
                    : new ContrastCurve(96.0, 96.0, 96.0, 95.0).Get(s.ContrastLevel),
            isBackground: true,
            background: null,
            secondBackground: null,
            contrastCurve: null,
            toneDeltaPair: null
        );
    }

    public static DynamicColor SurfaceContainer()
    {
        return new DynamicColor(
            name: "surface_container",
            palette: (s) => s.NeutralPalette,
            tone: (s) =>
                s.IsDark
                    ? new ContrastCurve(12.0, 12.0, 16.0, 20.0).Get(s.ContrastLevel)
                    : new ContrastCurve(94.0, 94.0, 92.0, 90.0).Get(s.ContrastLevel),
            isBackground: true,
            background: null,
            secondBackground: null,
            contrastCurve: null,
            toneDeltaPair: null
        );
    }

    public static DynamicColor SurfaceContainerHigh()
    {
        return new DynamicColor(
            name: "surface_container_high",
            palette: (s) => s.NeutralPalette,
            tone: (s) =>
                s.IsDark
                    ? new ContrastCurve(17.0, 17.0, 21.0, 25.0).Get(s.ContrastLevel)
                    : new ContrastCurve(92.0, 92.0, 88.0, 85.0).Get(s.ContrastLevel),
            isBackground: true,
            background: null,
            secondBackground: null,
            contrastCurve: null,
            toneDeltaPair: null
        );
    }

    public static DynamicColor SurfaceContainerHighest()
    {
        return new DynamicColor(
            name: "surface_container_highest",
            palette: (s) => s.NeutralPalette,
            tone: (s) =>
                s.IsDark
                    ? new ContrastCurve(22.0, 22.0, 26.0, 30.0).Get(s.ContrastLevel)
                    : new ContrastCurve(90.0, 90.0, 84.0, 80.0).Get(s.ContrastLevel),
            isBackground: true,
            background: null,
            secondBackground: null,
            contrastCurve: null,
            toneDeltaPair: null
        );
    }

    public static DynamicColor OnSurface()
    {
        return new DynamicColor(
            name: "on_surface",
            palette: (s) => s.NeutralPalette,
            tone: (s) => s.IsDark ? 90.0 : 10.0,
            isBackground: false,
            background: (s) => HighestSurface(s),
            secondBackground: null,
            contrastCurve: new ContrastCurve(4.5, 7.0, 11.0, 21.0),
            toneDeltaPair: null
        );
    }
    
    public static DynamicColor SurfaceVariant()
    {
        return new DynamicColor(
            name: "surface_variant",
            palette: (s) => s.NeutralVariantPalette,
            tone: (s) => s.IsDark ? 30.0 : 90.0,
            isBackground: true,
            background: null,
            secondBackground: null,
            contrastCurve: null,
            toneDeltaPair: null
        );
    }

    public static DynamicColor OnSurfaceVariant()
    {
        return new DynamicColor(
            name: "on_surface_variant",
            palette: (s) => s.NeutralVariantPalette,
            tone: (s) => s.IsDark ? 80.0 : 30.0,
            isBackground: false,
            background: (s) => HighestSurface(s),
            secondBackground: null,
            contrastCurve: new ContrastCurve(3.0, 4.5, 7.0, 11.0),
            toneDeltaPair: null
        );
    }

    public static DynamicColor InverseSurface()
    {
        return new DynamicColor(
            name: "inverse_surface",
            palette: (s) => s.NeutralPalette,
            tone: (s) => s.IsDark ? 90.0 : 20.0,
            isBackground: false,
            background: null,
            secondBackground: null,
            contrastCurve: null,
            toneDeltaPair: null
        );
    }

    public static DynamicColor InverseOnSurface()
    {
        return new DynamicColor(
            name: "inverse_on_surface",
            palette: (s) => s.NeutralPalette,
            tone: (s) => s.IsDark ? 20.0 : 95.0,
            isBackground: false,
            background: (s) => InverseSurface(),
            secondBackground: null,
            contrastCurve: new ContrastCurve(4.5, 7.0, 11.0, 21.0),
            toneDeltaPair: null
        );
    }

    public static DynamicColor Outline()
    {
        return new DynamicColor(
            name: "outline",
            palette: (s) => s.NeutralVariantPalette,
            tone: (s) => s.IsDark ? 60.0 : 50.0,
            isBackground: false,
            background: (s) => HighestSurface(s),
            secondBackground: null,
            contrastCurve: new ContrastCurve(1.5, 3.0, 4.5, 7.0),
            toneDeltaPair: null
        );
    }

    public static DynamicColor OutlineVariant()
    {
        return new DynamicColor(
            name: "outline_variant",
            palette: (s) => s.NeutralVariantPalette,
            tone: (s) => s.IsDark ? 30.0 : 80.0,
            isBackground: false,
            background: (s) => HighestSurface(s),
            secondBackground: null,
            contrastCurve: new ContrastCurve(1.0, 1.0, 3.0, 4.5),
            toneDeltaPair: null
        );
    }

    public static DynamicColor Shadow()
    {
        return new DynamicColor(
            name: "shadow",
            palette: (s) => s.NeutralPalette,
            tone: (s) => 0.0,
            isBackground: false,
            background: null,
            secondBackground: null,
            contrastCurve: null,
            toneDeltaPair: null
        );
    }

    public static DynamicColor Scrim()
    {
        return new DynamicColor(
            name: "scrim",
            palette: (s) => s.NeutralPalette,
            tone: (s) => 0.0,
            isBackground: false,
            background: null,
            secondBackground: null,
            contrastCurve: null,
            toneDeltaPair: null
        );
    }

    public static DynamicColor SurfaceTint()
    {
        return new DynamicColor(
            name: "surface_tint",
            palette: (s) => s.PrimaryPalette,
            tone: (s) => s.IsDark ? 80.0 : 40.0,
            isBackground: true,
            background: null,
            secondBackground: null,
            contrastCurve: null,
            toneDeltaPair: null
        );
    }

    public static DynamicColor Primary()
    {
        return new DynamicColor(
            name: "primary",
            palette: (s) => s.PrimaryPalette,
            tone: (s) => IsMonochrome(s) ? (s.IsDark ? 100.0 : 0.0) : (s.IsDark ? 80.0 : 40.0),
            isBackground: true,
            background: (s) => HighestSurface(s),
            secondBackground: null,
            contrastCurve: new ContrastCurve(3.0, 4.5, 7.0, 7.0),
            toneDeltaPair: (s) => new ToneDeltaPair(PrimaryContainer(), Primary(), 10.0, TonePolarity.Nearer, false)
        );
    }

    public static DynamicColor OnPrimary()
    {
        return new DynamicColor(
            name: "on_primary",
            palette: (s) => s.PrimaryPalette,
            tone: (s) => IsMonochrome(s) ? (s.IsDark ? 10.0 : 90.0) : (s.IsDark ? 20.0 : 100.0),
            isBackground: false,
            background: (s) => Primary(),
            secondBackground: null,
            contrastCurve: new ContrastCurve(4.5, 7.0, 11.0, 21.0),
            toneDeltaPair: null
        );
    }

    public static DynamicColor PrimaryContainer()
    {
        return new DynamicColor(
            name: "primary_container",
            palette: (s) => s.PrimaryPalette,
            tone: (s) =>
            {
                if (IsFidelity(s))
                {
                    return s.SourceColorHct.Tone;
                }

                if (IsMonochrome(s))
                {
                    return s.IsDark ? 85.0 : 25.0;
                }

                return s.IsDark ? 30.0 : 90.0;
            },
            isBackground: true,
            background: (s) => HighestSurface(s),
            secondBackground: null,
            contrastCurve: new ContrastCurve(1.0, 1.0, 3.0, 4.5),
            toneDeltaPair: (s) => new ToneDeltaPair(PrimaryContainer(), Primary(), 10.0, TonePolarity.Nearer, false)
        );
    }

    public static DynamicColor OnPrimaryContainer()
    {
        return new DynamicColor(
            name: "on_primary_container",
            palette: (s) => s.PrimaryPalette,
            tone: (s) =>
            {
                if (IsFidelity(s))
                {
                    return DynamicColor.ForegroundTone(PrimaryContainer().Tone(s), 4.5);
                }

                if (IsMonochrome(s))
                {
                    return s.IsDark ? 0.0 : 100.0;
                }

                return s.IsDark ? 90.0 : 30.0;
            },
            isBackground: false,
            background: (s) => PrimaryContainer(),
            secondBackground: null,
            contrastCurve: new ContrastCurve(3.0, 4.5, 7.0, 11.0),
            toneDeltaPair: null
        );
    }

    public static DynamicColor InversePrimary()
    {
        return new DynamicColor(
            name: "inverse_primary",
            palette: (s) => s.PrimaryPalette,
            tone: (s) => s.IsDark ? 40.0 : 80.0,
            isBackground: false,
            background: (s) => InverseSurface(),
            secondBackground: null,
            contrastCurve: new ContrastCurve(3.0, 4.5, 7.0, 7.0),
            toneDeltaPair: null
        );
    }

    public static DynamicColor Secondary()
    {
        return new DynamicColor(
            name: "secondary",
            palette: (s) => s.SecondaryPalette,
            tone: (s) => s.IsDark ? 80.0 : 40.0,
            isBackground: true,
            background: (s) => HighestSurface(s),
            secondBackground: null,
            contrastCurve: new ContrastCurve(3.0, 4.5, 7.0, 7.0),
            toneDeltaPair: (s) =>
                new ToneDeltaPair(SecondaryContainer(), Secondary(), 10.0, TonePolarity.Nearer, false)
        );
    }

    public static DynamicColor OnSecondary()
    {
        return new DynamicColor(
            name: "on_secondary",
            palette: (s) => s.SecondaryPalette,
            tone: (s) =>
            {
                if (IsMonochrome(s))
                {
                    return s.IsDark ? 10.0 : 100.0;
                }
                else
                {
                    return s.IsDark ? 20.0 : 100.0;
                }
            },
            isBackground: false,
            background: (s) => Secondary(),
            secondBackground: null,
            contrastCurve: new ContrastCurve(4.5, 7.0, 11.0, 21.0),
            toneDeltaPair: null
        );
    }

    public static DynamicColor SecondaryContainer()
    {
        return new DynamicColor(
            name: "secondary_container",
            palette: (s) => s.SecondaryPalette,
            tone: (s) =>
            {
                var initialTone = s.IsDark ? 30.0 : 90.0;
                if (IsMonochrome(s))
                {
                    return s.IsDark ? 30.0 : 85.0;
                }

                if (!IsFidelity(s))
                {
                    return initialTone;
                }

                return FindDesiredChromaByTone(
                    s.SecondaryPalette.Hue, s.SecondaryPalette.Chroma, initialTone, !s.IsDark
                );
            },
            isBackground: true,
            background: (s) => HighestSurface(s),
            secondBackground: null,
            contrastCurve: new ContrastCurve(1.0, 1.0, 3.0, 4.5),
            toneDeltaPair: (s) => new ToneDeltaPair(SecondaryContainer(), Secondary(), 10.0, TonePolarity.Nearer, false)
        );
    }

    public static DynamicColor OnSecondaryContainer()
    {
        return new DynamicColor(
            name: "on_secondary_container",
            palette: (s) => s.SecondaryPalette,
            tone: (s) =>
            {
                if (IsMonochrome(s))
                {
                    return s.IsDark ? 90.0 : 10.0;
                }

                if (!IsFidelity(s))
                {
                    return s.IsDark ? 90.0 : 30.0;
                }

                return DynamicColor.ForegroundTone(SecondaryContainer().Tone(s), 4.5);
            },
            isBackground: false,
            background: (s) => SecondaryContainer(),
            secondBackground: null,
            contrastCurve: new ContrastCurve(3.0, 4.5, 7.0, 11.0),
            toneDeltaPair: null
        );
    }

    public static DynamicColor Tertiary()
    {
        return new DynamicColor(
            name: "tertiary",
            palette: (s) => s.TertiaryPalette,
            tone: (s) =>
            {
                if (IsMonochrome(s))
                {
                    return s.IsDark ? 90.0 : 25.0;
                }

                return s.IsDark ? 80.0 : 40.0;
            },
            isBackground: true,
            background: (s) => HighestSurface(s),
            secondBackground: null,
            contrastCurve: new ContrastCurve(3.0, 4.5, 7.0, 7.0),
            toneDeltaPair: (s) => new ToneDeltaPair(TertiaryContainer(), Tertiary(), 10.0, TonePolarity.Nearer, false)
        );
    }

    public static DynamicColor OnTertiary()
    {
        return new DynamicColor(
            name: "on_tertiary",
            palette: (s) => s.TertiaryPalette,
            tone: (s) =>
            {
                if (IsMonochrome(s))
                {
                    return s.IsDark ? 10.0 : 90.0;
                }

                return s.IsDark ? 20.0 : 100.0;
            },
            isBackground: false,
            background: (s) => Tertiary(),
            secondBackground: null,
            contrastCurve: new ContrastCurve(4.5, 7.0, 11.0, 21.0),
            toneDeltaPair: null
        );
    }

    public static DynamicColor TertiaryContainer()
    {
        return new DynamicColor(
            name: "tertiary_container",
            palette: (s) => s.TertiaryPalette,
            tone: (s) =>
            {
                if (IsMonochrome(s))
                {
                    return s.IsDark ? 60.0 : 49.0;
                }

                if (!IsFidelity(s))
                {
                    return s.IsDark ? 30.0 : 90.0;
                }

                var proposedHct = s.TertiaryPalette[s.SourceColorHct.Tone];
                return DislikeAnalyzer.FixIfDisliked(Hct.FromInt(proposedHct)).Tone;
            },
            isBackground: true,
            background: (s) => HighestSurface(s),
            secondBackground: null,
            contrastCurve: new ContrastCurve(1.0, 1.0, 3.0, 4.5),
            toneDeltaPair: (s) => new ToneDeltaPair(TertiaryContainer(), Tertiary(), 10.0, TonePolarity.Nearer, false)
        );
    }

    public static DynamicColor OnTertiaryContainer()
    {
        return new DynamicColor(
            name: "on_tertiary_container",
            palette: (s) => s.TertiaryPalette,
            tone: (s) =>
            {
                if (IsMonochrome(s))
                {
                    return s.IsDark ? 0.0 : 100.0;
                }

                if (!IsFidelity(s))
                {
                    return s.IsDark ? 90.0 : 30.0;
                }

                return DynamicColor.ForegroundTone(TertiaryContainer().Tone(s), 4.5);
            },
            isBackground: false,
            background: (s) => TertiaryContainer(),
            secondBackground: null,
            contrastCurve: new ContrastCurve(3.0, 4.5, 7.0, 11.0),
            toneDeltaPair: null
        );
    }

    public static DynamicColor Error()
    {
        return new DynamicColor(
            name: "error",
            palette: (s) => s.ErrorPalette,
            tone: (s) => s.IsDark ? 80.0 : 40.0,
            isBackground: true,
            background: (s) => HighestSurface(s),
            secondBackground: null,
            contrastCurve: new ContrastCurve(3.0, 4.5, 7.0, 7.0),
            toneDeltaPair: (s) => new ToneDeltaPair(ErrorContainer(), Error(), 10.0, TonePolarity.Nearer, false)
        );
    }

    public static DynamicColor ErrorContainer()
    {
        return new DynamicColor(
            name: "error_container",
            palette: (s) => s.ErrorPalette,
            tone: (s) => s.IsDark ? 30.0 : 90.0,
            isBackground: true,
            background: (s) => HighestSurface(s),
            secondBackground: null,
            contrastCurve: new ContrastCurve(1.0, 1.0, 3.0, 4.5),
            toneDeltaPair: (s) => new ToneDeltaPair(ErrorContainer(), Error(), 10.0, TonePolarity.Nearer, false)
        );
    }

    public static DynamicColor OnErrorContainer()
    {
        return new DynamicColor(
            name: "on_error_container",
            palette: (s) => s.ErrorPalette,
            tone: (s) =>
            {
                if (IsMonochrome(s))
                {
                    return s.IsDark ? 90.0 : 10.0;
                }

                return s.IsDark ? 90.0 : 30.0;
            },
            isBackground: false,
            background: (s) => ErrorContainer(),
            secondBackground: null,
            contrastCurve: new ContrastCurve(3.0, 4.5, 7.0, 11.0),
            toneDeltaPair: null
        );
    }

    public static DynamicColor OnError()
    {
        return new DynamicColor(
            name: "on_error",
            palette: (s) => s.ErrorPalette,
            tone: (s) => s.IsDark ? 20.0 : 100.0,
            isBackground: false,
            background: (s) => Error(),
            secondBackground: null,
            contrastCurve: new ContrastCurve(4.5, 7.0, 11.0, 21.0),
            toneDeltaPair: null
        );
    }

    public static DynamicColor Success()
    {
        return new DynamicColor(
            name: "success",
            palette: (s) => s.SuccessPalette,
            tone: (s) => s.IsDark ? 80.0 : 40.0,
            isBackground: true,
            background: (s) => HighestSurface(s),
            secondBackground: null,
            contrastCurve: new ContrastCurve(3.0, 4.5, 7.0, 7.0),
            toneDeltaPair: (s) => new ToneDeltaPair(SuccessContainer(), Success(), 10.0, TonePolarity.Nearer, false)
        );
    }

    public static DynamicColor SuccessContainer()
    {
        return new DynamicColor(
            name: "success_container",
            palette: (s) => s.SuccessPalette,
            tone: (s) => s.IsDark ? 30.0 : 90.0,
            isBackground: true,
            background: (s) => HighestSurface(s),
            secondBackground: null,
            contrastCurve: new ContrastCurve(1.0, 1.0, 3.0, 4.5),
            toneDeltaPair: (s) => new ToneDeltaPair(SuccessContainer(), Success(), 10.0, TonePolarity.Nearer, false)
        );
    }

    public static DynamicColor OnSuccessContainer()
    {
        return new DynamicColor(
            name: "on_success_container",
            palette: (s) => s.ErrorPalette,
            tone: (s) =>
            {
                if (IsMonochrome(s))
                {
                    return s.IsDark ? 90.0 : 10.0;
                }

                return s.IsDark ? 90.0 : 30.0;
            },
            isBackground: false,
            background: (s) => SuccessContainer(),
            secondBackground: null,
            contrastCurve: new ContrastCurve(3.0, 4.5, 7.0, 11.0),
            toneDeltaPair: null
        );
    }

    public static DynamicColor OnSuccess()
    {
        return new DynamicColor(
            name: "on_success",
            palette: (s) => s.SuccessPalette,
            tone: (s) => s.IsDark ? 20.0 : 100.0,
            isBackground: false,
            background: (s) => Success(),
            secondBackground: null,
            contrastCurve: new ContrastCurve(4.5, 7.0, 11.0, 21.0),
            toneDeltaPair: null
        );
    }

    public static DynamicColor Info()
    {
        return new DynamicColor(
            name: "info",
            palette: (s) => s.InfoPalette,
            tone: (s) => s.IsDark ? 80.0 : 40.0,
            isBackground: true,
            background: (s) => HighestSurface(s),
            secondBackground: null,
            contrastCurve: new ContrastCurve(3.0, 4.5, 7.0, 7.0),
            toneDeltaPair: (s) => new ToneDeltaPair(InfoContainer(), Info(), 10.0, TonePolarity.Nearer, false)
        );
    }

    public static DynamicColor InfoContainer()
    {
        return new DynamicColor(
            name: "info_container",
            palette: (s) => s.InfoPalette,
            tone: (s) => s.IsDark ? 30.0 : 90.0,
            isBackground: true,
            background: (s) => HighestSurface(s),
            secondBackground: null,
            contrastCurve: new ContrastCurve(1.0, 1.0, 3.0, 4.5),
            toneDeltaPair: (s) => new ToneDeltaPair(InfoContainer(), Info(), 10.0, TonePolarity.Nearer, false)
        );
    }

    public static DynamicColor OnInfoContainer()
    {
        return new DynamicColor(
            name: "on_info_container",
            palette: (s) => s.InfoPalette,
            tone: (s) =>
            {
                if (IsMonochrome(s))
                {
                    return s.IsDark ? 90.0 : 10.0;
                }

                return s.IsDark ? 90.0 : 30.0;
            },
            isBackground: false,
            background: (s) => InfoContainer(),
            secondBackground: null,
            contrastCurve: new ContrastCurve(3.0, 4.5, 7.0, 11.0),
            toneDeltaPair: null
        );
    }

    public static DynamicColor OnInfo()
    {
        return new DynamicColor(
            name: "on_info",
            palette: (s) => s.InfoPalette,
            tone: (s) => s.IsDark ? 20.0 : 100.0,
            isBackground: false,
            background: (s) => Info(),
            secondBackground: null,
            contrastCurve: new ContrastCurve(4.5, 7.0, 11.0, 21.0),
            toneDeltaPair: null
        );
    }

    public static DynamicColor Warning()
    {
        return new DynamicColor(
            name: "warning",
            palette: (s) => s.WarningPalette,
            tone: (s) => s.IsDark ? 80.0 : 40.0,
            isBackground: true,
            background: (s) => HighestSurface(s),
            secondBackground: null,
            contrastCurve: new ContrastCurve(3.0, 4.5, 7.0, 7.0),
            toneDeltaPair: (s) => new ToneDeltaPair(WarningContainer(), Warning(), 10.0, TonePolarity.Nearer, false)
        );
    }

    public static DynamicColor WarningContainer()
    {
        return new DynamicColor(
            name: "warning_container",
            palette: (s) => s.WarningPalette,
            tone: (s) => s.IsDark ? 30.0 : 90.0,
            isBackground: true,
            background: (s) => HighestSurface(s),
            secondBackground: null,
            contrastCurve: new ContrastCurve(1.0, 1.0, 3.0, 4.5),
            toneDeltaPair: (s) => new ToneDeltaPair(WarningContainer(), Warning(), 10.0, TonePolarity.Nearer, false)
        );
    }

    public static DynamicColor OnWarningContainer()
    {
        return new DynamicColor(
            name: "on_warning_container",
            palette: (s) => s.WarningPalette,
            tone: (s) =>
            {
                if (IsMonochrome(s))
                {
                    return s.IsDark ? 90.0 : 10.0;
                }

                return s.IsDark ? 90.0 : 30.0;
            },
            isBackground: false,
            background: (s) => WarningContainer(),
            secondBackground: null,
            contrastCurve: new ContrastCurve(3.0, 4.5, 7.0, 11.0),
            toneDeltaPair: null
        );
    }

    public static DynamicColor OnWarning()
    {
        return new DynamicColor(
            name: "on_warning",
            palette: (s) => s.WarningPalette,
            tone: (s) => s.IsDark ? 20.0 : 100.0,
            isBackground: false,
            background: (s) => Warning(),
            secondBackground: null,
            contrastCurve: new ContrastCurve(4.5, 7.0, 11.0, 21.0),
            toneDeltaPair: null
        );
    }

    public static DynamicColor PrimaryFixed()
    {
        return new DynamicColor(
            name: "primary_fixed",
            palette: (s) => s.PrimaryPalette,
            tone: (s) => IsMonochrome(s) ? 40.0 : 90.0,
            isBackground: true,
            background: (s) => HighestSurface(s),
            secondBackground: null,
            contrastCurve: new ContrastCurve(1.0, 1.0, 3.0, 4.5),
            toneDeltaPair: (s) => new ToneDeltaPair(PrimaryFixed(), PrimaryFixedDim(), 10.0, TonePolarity.Lighter, true)
        );
    }

    public static DynamicColor PrimaryFixedDim()
    {
        return new DynamicColor(
            name: "primary_fixed_dim",
            palette: (s) => s.PrimaryPalette,
            tone: (s) => IsMonochrome(s) ? 30.0 : 80.0,
            isBackground: true,
            background: (s) => HighestSurface(s),
            secondBackground: null,
            contrastCurve: new ContrastCurve(1.0, 1.0, 3.0, 4.5),
            toneDeltaPair: (s) => new ToneDeltaPair(PrimaryFixed(), PrimaryFixedDim(), 10.0, TonePolarity.Lighter, true)
        );
    }

    public static DynamicColor OnPrimaryFixed()
    {
        return new DynamicColor(
            name: "on_primary_fixed",
            palette: (s) => s.PrimaryPalette,
            tone: (s) => IsMonochrome(s) ? 100.0 : 10.0,
            isBackground: false,
            background: (s) => PrimaryFixedDim(),
            secondBackground: (s) => PrimaryFixed(),
            contrastCurve: new ContrastCurve(4.5, 7.0, 11.0, 21.0),
            toneDeltaPair: null
        );
    }

    public static DynamicColor OnPrimaryFixedVariant()
    {
        return new DynamicColor(
            name: "on_primary_fixed_variant",
            palette: (s) => s.PrimaryPalette,
            tone: (s) => IsMonochrome(s) ? 90.0 : 30.0,
            isBackground: false,
            background: (s) => PrimaryFixedDim(),
            secondBackground: (s) => PrimaryFixed(),
            contrastCurve: new ContrastCurve(3.0, 4.5, 7.0, 11.0),
            toneDeltaPair: null
        );
    }

    public static DynamicColor SecondaryFixed()
    {
        return new DynamicColor(
            name: "secondary_fixed",
            palette: (s) => s.SecondaryPalette,
            tone: (s) => IsMonochrome(s) ? 80.0 : 90.0,
            isBackground: true,
            background: (s) => HighestSurface(s),
            secondBackground: null,
            contrastCurve: new ContrastCurve(1.0, 1.0, 3.0, 4.5),
            toneDeltaPair: (s) =>
                new ToneDeltaPair(SecondaryFixed(), SecondaryFixedDim(), 10.0, TonePolarity.Lighter, true)
        );
    }

    public static DynamicColor SecondaryFixedDim()
    {
        return new DynamicColor(
            name: "secondary_fixed_dim",
            palette: (s) => s.SecondaryPalette,
            tone: (s) => IsMonochrome(s) ? 70.0 : 80.0,
            isBackground: true,
            background: (s) => HighestSurface(s),
            secondBackground: null,
            contrastCurve: new ContrastCurve(1.0, 1.0, 3.0, 4.5),
            toneDeltaPair: (s) =>
                new ToneDeltaPair(SecondaryFixed(), SecondaryFixedDim(), 10.0, TonePolarity.Lighter, true)
        );
    }

    public static DynamicColor OnSecondaryFixed()
    {
        return new DynamicColor(
            name: "on_secondary_fixed",
            palette: (s) => s.SecondaryPalette,
            tone: (s) => 10.0,
            isBackground: false,
            background: (s) => SecondaryFixedDim(),
            secondBackground: (s) => SecondaryFixed(),
            contrastCurve: new ContrastCurve(4.5, 7.0, 11.0, 21.0),
            toneDeltaPair: null
        );
    }

    public static DynamicColor OnSecondaryFixedVariant()
    {
        return new DynamicColor(
            name: "on_secondary_fixed_variant",
            palette: (s) => s.SecondaryPalette,
            tone: (s) => IsMonochrome(s) ? 25.0 : 30.0,
            isBackground: false,
            background: (s) => SecondaryFixedDim(),
            secondBackground: (s) => SecondaryFixed(),
            contrastCurve: new ContrastCurve(3.0, 4.5, 7.0, 11.0),
            toneDeltaPair: null
        );
    }

    public static DynamicColor TertiaryFixed()
    {
        return new DynamicColor(
            name: "tertiary_fixed",
            palette: (s) => s.TertiaryPalette,
            tone: (s) => IsMonochrome(s) ? 40.0 : 90.0,
            isBackground: true,
            background: (s) => HighestSurface(s),
            secondBackground: null,
            contrastCurve: new ContrastCurve(1.0, 1.0, 3.0, 4.5),
            toneDeltaPair: (s) =>
                new ToneDeltaPair(TertiaryFixed(), TertiaryFixedDim(), 10.0, TonePolarity.Lighter, true)
        );
    }

    public static DynamicColor TertiaryFixedDim()
    {
        return new DynamicColor(
            name: "tertiary_fixed_dim",
            palette: (s) => s.TertiaryPalette,
            tone: (s) => IsMonochrome(s) ? 30.0 : 80.0,
            isBackground: true,
            background: (s) => HighestSurface(s),
            secondBackground: null,
            contrastCurve: new ContrastCurve(1.0, 1.0, 3.0, 4.5),
            toneDeltaPair: (s) =>
                new ToneDeltaPair(TertiaryFixed(), TertiaryFixedDim(), 10.0, TonePolarity.Lighter, true)
        );
    }

    public static DynamicColor OnTertiaryFixed()
    {
        return new DynamicColor(
            name: "on_tertiary_fixed",
            palette: (s) => s.TertiaryPalette,
            tone: (s) => IsMonochrome(s) ? 100.0 : 10.0,
            isBackground: false,
            background: (s) => TertiaryFixedDim(),
            secondBackground: (s) => TertiaryFixed(),
            contrastCurve: new ContrastCurve(4.5, 7.0, 11.0, 21.0),
            toneDeltaPair: null
        );
    }

    public static DynamicColor OnTertiaryFixedVariant()
    {
        return new DynamicColor(
            name: "on_tertiary_fixed_variant",
            palette: (s) => s.TertiaryPalette,
            tone: (s) => IsMonochrome(s) ? 90.0 : 30.0,
            isBackground: false,
            background: (s) => TertiaryFixedDim(),
            secondBackground: (s) => TertiaryFixed(),
            contrastCurve: new ContrastCurve(3.0, 4.5, 7.0, 11.0),
            toneDeltaPair: null
        );
    }

    public static DynamicColor ControlActivated()
    {
        return DynamicColor.FromPalette(
            "control_activated", (s) => s.PrimaryPalette, (s) => s.IsDark ? 30.0 : 90.0
        );
    }

    public static DynamicColor ControlNormal()
    {
        return DynamicColor.FromPalette(
            "control_normal", (s) => s.NeutralVariantPalette, (s) => s.IsDark ? 80.0 : 30.0
        );
    }

    public static DynamicColor ControlHighlight()
    {
        return new DynamicColor(
            name: "control_highlight",
            palette: (s) => s.NeutralPalette,
            tone: (s) => s.IsDark ? 100.0 : 0.0,
            isBackground: false,
            background: null,
            secondBackground: null,
            contrastCurve: null,
            toneDeltaPair: null,
            opacity: (s) => s.IsDark ? 0.20 : 0.12
        );
    }

    public static DynamicColor TextPrimaryInverse()
    {
        return DynamicColor.FromPalette(
            "text_primary_inverse",
            (s) => s.NeutralPalette,
            (s) => s.IsDark ? 10.0 : 90.0
        );
    }

    public static DynamicColor TextSecondaryAndTertiaryInverse()
    {
        return DynamicColor.FromPalette(
            "text_secondary_and_tertiary_inverse",
            (s) => s.NeutralVariantPalette,
            (s) => s.IsDark ? 30.0 : 80.0
        );
    }

    public static DynamicColor TextPrimaryInverseDisableOnly()
    {
        return DynamicColor.FromPalette(
            "text_primary_inverse_disable_only",
            (s) => s.NeutralPalette,
            (s) => s.IsDark ? 10.0 : 90.0
        );
    }

    public static DynamicColor TextSecondaryAndTertiaryInverseDisabled()
    {
        return DynamicColor.FromPalette(
            "text_secondary_and_tertiary_inverse_disabled",
            (s) => s.NeutralPalette,
            (s) => s.IsDark ? 10.0 : 90.0
        );
    }

    public static DynamicColor TextHintInverse()
    {
        return DynamicColor.FromPalette(
            "text_hint_inverse",
            (s) => s.NeutralPalette,
            (s) => s.IsDark ? 10.0 : 90.0
        );
    }

    private static bool IsFidelity(DynamicScheme scheme)
    {
        if (IsExtendedFidelity &&
            scheme.Variant != DynamicSchemeVariant.Monochrome &&
            scheme.Variant != DynamicSchemeVariant.Neutral)
        {
            return true;
        }

        return scheme.Variant == DynamicSchemeVariant.Fidelity || scheme.Variant == DynamicSchemeVariant.Content;
    }

    private static bool IsMonochrome(DynamicScheme scheme)
    {
        return scheme.Variant == DynamicSchemeVariant.Monochrome;
    }

    public static double FindDesiredChromaByTone(double hue, double chroma, double tone, bool byDecreasingTone)
    {
        double answer = tone;

        Hct closestToChroma = Hct.From(hue, chroma, tone);
        if (closestToChroma.Chroma < chroma)
        {
            double chromaPeak = closestToChroma.Chroma;
            while (closestToChroma.Chroma < chroma)
            {
                answer += byDecreasingTone ? -1.0 : 1.0;
                Hct potentialSolution = Hct.From(hue, chroma, answer);
                if (chromaPeak > potentialSolution.Chroma)
                {
                    break;
                }

                if (Math.Abs(potentialSolution.Chroma - chroma) < 0.4)
                {
                    break;
                }

                double potentialDelta = Math.Abs(potentialSolution.Chroma - chroma);
                double currentDelta = Math.Abs(closestToChroma.Chroma - chroma);
                if (potentialDelta < currentDelta)
                {
                    closestToChroma = potentialSolution;
                }

                chromaPeak = Math.Max(chromaPeak, potentialSolution.Chroma);
            }
        }

        return answer;
    }
}