using System.Drawing;
using Bdziam.UI.Utilities;
using MaterialColorUtilities.Palettes;
using MaterialColorUtilities.Schemes;

namespace Bdziam.UI.Theming.Model;

public class BColorScheme : Scheme<Color>
{
    public Color Info { get; set; } = default!;
    public Color InfoContainer { get; set; } = default!;
    public Color OnInfoContainer { get; set; } = default!;
    public Color OnInfo { get; set; } = default!;
    public Color Warning { get; set; } = default!;
    public Color WarningContainer { get; set; } = default!;
    public Color OnWarningContainer { get; set; } = default!;
    public Color OnWarning { get; set; } = default!;

    public BColorScheme()
    {
        var infoPalette = TonalPalette.FromInt(ColorUtility.ToArgb(Color.FromArgb(255, 20, 128, 255)));
        Info = ColorUtility.ColorFromArgb(infoPalette[40]);
        OnInfo = ColorUtility.ColorFromArgb(infoPalette[85]);
        OnInfoContainer = ColorUtility.ColorFromArgb(infoPalette[90]);
        InfoContainer = ColorUtility.ColorFromArgb(infoPalette[60]);
        var warningPalette = TonalPalette.FromInt(ColorUtility.ToArgb(Color.FromArgb(255, 255, 128, 20)));
        Warning = ColorUtility.ColorFromArgb(warningPalette[40]);
        OnWarning = ColorUtility.ColorFromArgb(warningPalette[85]);
        OnWarningContainer = ColorUtility.ColorFromArgb(warningPalette[90]);
        WarningContainer = ColorUtility.ColorFromArgb(warningPalette[60]);
    }
    
    
    public BColorScheme(Scheme<Color> scheme)
    {
        Primary = scheme.Primary;
        OnPrimary = scheme.OnPrimary;
        PrimaryContainer = scheme.PrimaryContainer;
        OnPrimaryContainer = scheme.OnPrimaryContainer;
        Secondary = scheme.Secondary;
        OnSecondary = scheme.OnSecondary;
        SecondaryContainer = scheme.SecondaryContainer;
        OnSecondaryContainer = scheme.OnSecondaryContainer;
        Tertiary = scheme.Tertiary;
        OnTertiary = scheme.OnTertiary;
        TertiaryContainer = scheme.TertiaryContainer;
        OnTertiaryContainer = scheme.OnTertiaryContainer;
        Error = scheme.Error;
        OnError = scheme.OnError;
        ErrorContainer = scheme.ErrorContainer;
        OnErrorContainer = scheme.OnErrorContainer;
        Background = scheme.Background;
        OnBackground = scheme.OnBackground;
        Surface = scheme.Surface;
        OnSurface = scheme.OnSurface;
        SurfaceVariant = scheme.SurfaceVariant;
        OnSurfaceVariant = scheme.OnSurfaceVariant;
        Outline = scheme.Outline;
        Shadow = scheme.Shadow;
        InverseSurface = scheme.InverseSurface;
        InverseOnSurface = scheme.InverseOnSurface;
        InversePrimary = scheme.InversePrimary;
        Surface1 = scheme.Surface1;
        Surface2 = scheme.Surface2;
        Surface3 = scheme.Surface3;
        Surface4 = scheme.Surface4;
        Surface5 = scheme.Surface5;
        SurfaceDim = scheme.SurfaceDim;
        SurfaceBright = scheme.SurfaceBright;
        SurfaceContainerLowest = scheme.SurfaceContainerLowest;
        SurfaceContainerLow = scheme.SurfaceContainerLow;
        SurfaceContainer = scheme.SurfaceContainer;
        SurfaceContainerHigh = scheme.SurfaceContainerHigh;
        SurfaceContainerHighest = scheme.SurfaceContainerHighest;
        OutlineVariant = scheme.OutlineVariant;

        var infoPalette = TonalPalette.FromInt(ColorUtility.ToArgb(Color.FromArgb(255, 20, 128, 255)));
        Info = ColorUtility.ColorFromArgb(infoPalette[40]);
        OnInfo = ColorUtility.ColorFromArgb(infoPalette[85]);
        OnInfoContainer = ColorUtility.ColorFromArgb(infoPalette[90]);
        InfoContainer = ColorUtility.ColorFromArgb(infoPalette[60]);
        var warningPalette = TonalPalette.FromInt(ColorUtility.ToArgb(Color.FromArgb(255, 255, 128, 20)));
        Warning = ColorUtility.ColorFromArgb(warningPalette[40]);
        OnWarning = ColorUtility.ColorFromArgb(warningPalette[85]);
        OnWarningContainer = ColorUtility.ColorFromArgb(warningPalette[90]);
        WarningContainer = ColorUtility.ColorFromArgb(warningPalette[60]);
    }
    
    public override IEnumerable<KeyValuePair<string, Color>> Enumerate()
    {
        var baseEnumeration = base.Enumerate().ToDictionary();
        
        baseEnumeration.Add(nameof(Info), Info);
        baseEnumeration.Add(nameof(OnInfo), OnInfo);
        baseEnumeration.Add(nameof(OnInfoContainer), OnInfoContainer);
        baseEnumeration.Add(nameof(InfoContainer), InfoContainer);
        baseEnumeration.Add(nameof(Warning), Warning);
        baseEnumeration.Add(nameof(OnWarning), OnWarning);
        baseEnumeration.Add(nameof(OnWarningContainer), OnWarningContainer);
        baseEnumeration.Add(nameof(WarningContainer), WarningContainer);

        return baseEnumeration.AsEnumerable();
    }
}