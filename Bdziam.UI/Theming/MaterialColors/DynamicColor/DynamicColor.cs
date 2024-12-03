using Bdziam.UI.Theming.MaterialColors.ColorSpace;
using Bdziam.UI.Theming.MaterialColors.Palettes;
using Bdziam.UI.Theming.MaterialColors.Utils;

namespace Bdziam.UI.Theming.MaterialColors.DynamicColor
{
    /// <summary>
    /// A color that adjusts itself based on UI state, represented by DynamicScheme.
    /// </summary>
    public sealed class DynamicColor
    {
        public string Name { get; }
        public Func<DynamicScheme, TonalPalette> Palette { get; }
        public Func<DynamicScheme, double> Tone { get; }
        public bool IsBackground { get; }
        public Func<DynamicScheme, DynamicColor>? Background { get; }
        public Func<DynamicScheme, DynamicColor>? SecondBackground { get; }
        public ContrastCurve? ContrastCurve { get; }
        public Func<DynamicScheme, ToneDeltaPair>? ToneDeltaPair { get; }
        public Func<DynamicScheme, double>? Opacity { get; }
        
        public DynamicColor(
            string name,
            Func<DynamicScheme, TonalPalette> palette,
            Func<DynamicScheme, double> tone,
            bool isBackground,
            Func<DynamicScheme, DynamicColor>? background = null,
            Func<DynamicScheme, DynamicColor>? secondBackground = null,
            ContrastCurve? contrastCurve = null,
            Func<DynamicScheme, ToneDeltaPair>? toneDeltaPair = null,
            Func<DynamicScheme, double>? opacity = null)
        {
            Name = name;
            Palette = palette;
            Tone = tone;
            IsBackground = isBackground;
            Background = background;
            SecondBackground = secondBackground;
            ContrastCurve = contrastCurve;
            ToneDeltaPair = toneDeltaPair;
            Opacity = opacity;
        }

        public static DynamicColor FromPalette(
            string name,
            Func<DynamicScheme, TonalPalette> palette,
            Func<DynamicScheme, double> tone,
            bool isBackground = false)
        {
            return new DynamicColor(name, palette, tone, isBackground);
        }

        public static DynamicColor FromArgb(string name, uint argb)
        {
            Hct hct = Hct.FromInt(argb);
            TonalPalette palette = TonalPalette.FromInt(argb);
            return FromPalette(name, _ => palette, _ => hct.Tone);
        }

        public uint GetArgb(DynamicScheme scheme)
        {
            uint argb = GetHct(scheme).ToInt();
            if (Opacity == null) return argb;

            double percentage = Opacity(scheme);
            uint alpha = (uint)MathUtils.ClampInt(0, 255, (uint) Math.Round(percentage * 255));
            return (argb & 0x00FFFFFF) | (alpha << 24);
        }

        public Hct GetHct(DynamicScheme scheme)
        {
            double tone = GetTone(scheme);
            Hct result = Hct.FromInt(Palette(scheme).Tone((uint)tone));
            return result;
        }

        public double GetTone(DynamicScheme scheme)
        {
            bool decreasingContrast = scheme.ContrastLevel < 0;

            // Case 1: dual foreground, pair of colors with delta constraint.
            if (ToneDeltaPair != null)
            {
                var toneDeltaPair = ToneDeltaPair(scheme);
                var roleA = toneDeltaPair.RoleA;
                var roleB = toneDeltaPair.RoleB;
                double delta = toneDeltaPair.Delta;
                var polarity = toneDeltaPair.Polarity;
                bool stayTogether = toneDeltaPair.StayTogether;

                var bg = Background(scheme);
                double bgTone = bg.GetTone(scheme);

                bool aIsNearer =
                    polarity == TonePolarity.Nearer ||
                    (polarity == TonePolarity.Lighter && !scheme.IsDark) ||
                    (polarity == TonePolarity.Darker && scheme.IsDark);

                var nearer = aIsNearer ? roleA : roleB;
                var farther = aIsNearer ? roleB : roleA;
                bool amNearer = Name.Equals(nearer.Name, StringComparison.Ordinal);
                double expansionDir = scheme.IsDark ? 1 : -1;

                // 1st round: solve to min, each
                double nContrast = nearer.ContrastCurve.Get(scheme.ContrastLevel);
                double fContrast = farther.ContrastCurve.Get(scheme.ContrastLevel);

                // Initial and adjusted tones for `nearer`
                double nInitialTone = nearer.Tone(scheme);
                double nTone = Contrast.RatioOfTones(bgTone, nInitialTone) >= nContrast
                    ? nInitialTone
                    : DynamicColor.ForegroundTone(bgTone, nContrast);

                // Initial and adjusted tones for `farther`
                double fInitialTone = farther.Tone(scheme);
                double fTone = Contrast.RatioOfTones(bgTone, fInitialTone) >= fContrast
                    ? fInitialTone
                    : DynamicColor.ForegroundTone(bgTone, fContrast);

                if (decreasingContrast)
                {
                    nTone = DynamicColor.ForegroundTone(bgTone, nContrast);
                    fTone = DynamicColor.ForegroundTone(bgTone, fContrast);
                }

                // If constraint is not satisfied, try another round.
                if ((fTone - nTone) * expansionDir < delta)
                {
                    fTone = Math.Clamp(nTone + delta * expansionDir, 0, 100);
                    if ((fTone - nTone) * expansionDir < delta)
                    {
                        nTone = Math.Clamp(fTone - delta * expansionDir, 0, 100);
                    }
                }

                // Avoid the 50-59 awkward zone.
                if (50 <= nTone && nTone < 60)
                {
                    if (expansionDir > 0)
                    {
                        nTone = 60;
                        fTone = Math.Max(fTone, nTone + delta * expansionDir);
                    }
                    else
                    {
                        nTone = 49;
                        fTone = Math.Min(fTone, nTone + delta * expansionDir);
                    }
                }
                else if (50 <= fTone && fTone < 60)
                {
                    if (stayTogether)
                    {
                        if (expansionDir > 0)
                        {
                            nTone = 60;
                            fTone = Math.Max(fTone, nTone + delta * expansionDir);
                        }
                        else
                        {
                            nTone = 49;
                            fTone = Math.Min(fTone, nTone + delta * expansionDir);
                        }
                    }
                    else
                    {
                        if (expansionDir > 0)
                        {
                            fTone = 60;
                        }
                        else
                        {
                            fTone = 49;
                        }
                    }
                }

                return amNearer ? nTone : fTone;
            }
            else
            {
                // Case 2: No contrast pair; just solve for itself.
                double answer = Tone(scheme);

                if (Background == null)
                {
                    return answer; // No adjustment for colors with no background.
                }

                double bgTone = Background(scheme).GetTone(scheme);
                double desiredRatio = ContrastCurve.Get(scheme.ContrastLevel);

                if (Contrast.RatioOfTones(bgTone, answer) >= desiredRatio)
                {
                    // Do nothing; it's good enough.
                }
                else
                {
                    answer = DynamicColor.ForegroundTone(bgTone, desiredRatio);
                }

                if (decreasingContrast)
                {
                    answer = DynamicColor.ForegroundTone(bgTone, desiredRatio);
                }

                if (IsBackground && 50 <= answer && answer < 60)
                {
                    answer = Contrast.RatioOfTones(49, bgTone) >= desiredRatio ? 49 : 60;
                }

                if (SecondBackground != null)
                {
                    // Case 3: Adjust for dual backgrounds.
                    double bgTone1 = Background(scheme).GetTone(scheme);
                    double bgTone2 = SecondBackground(scheme).GetTone(scheme);

                    double upper = Math.Max(bgTone1, bgTone2);
                    double lower = Math.Min(bgTone1, bgTone2);

                    if (Contrast.RatioOfTones(upper, answer) >= desiredRatio &&
                        Contrast.RatioOfTones(lower, answer) >= desiredRatio)
                    {
                        return answer;
                    }

                    double lightOption = Contrast.Lighter(upper, desiredRatio);
                    double darkOption = Contrast.Darker(lower, desiredRatio);

                    var availables = new List<double>();
                    if (lightOption != -1)
                    {
                        availables.Add(lightOption);
                    }

                    if (darkOption != -1)
                    {
                        availables.Add(darkOption);
                    }

                    bool prefersLight = DynamicColor.TonePrefersLightForeground(bgTone1) ||
                                        DynamicColor.TonePrefersLightForeground(bgTone2);

                    if (prefersLight)
                    {
                        return lightOption == -1 ? 100 : lightOption;
                    }

                    if (availables.Count == 1)
                    {
                        return availables[0];
                    }

                    return darkOption == -1 ? 0 : darkOption;
                }

                return answer;
            }
        }

        public static double ForegroundTone(double bgTone, double ratio)
        {
            double lighterTone = Contrast.LighterUnsafe(bgTone, ratio);
            double darkerTone = Contrast.DarkerUnsafe(bgTone, ratio);
            double lighterRatio = Contrast.RatioOfTones(lighterTone, bgTone);
            double darkerRatio = Contrast.RatioOfTones(darkerTone, bgTone);

            return TonePrefersLightForeground(bgTone)
                ? (lighterRatio >= ratio || lighterRatio >= darkerRatio ? lighterTone : darkerTone)
                : (darkerRatio >= ratio || darkerRatio >= lighterRatio ? darkerTone : lighterTone);
        }

        public static bool TonePrefersLightForeground(double tone) => Math.Round(tone) < 60;
        public static bool ToneAllowsLightForeground(double tone) => Math.Round(tone) <= 49;

        public static double EnableLightForeground(double tone)
        {
            return TonePrefersLightForeground(tone) && !ToneAllowsLightForeground(tone) ? 49.0 : tone;
        }
    }
}
