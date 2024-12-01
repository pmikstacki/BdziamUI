using System.Drawing;
using System.Text;
using Bdziam.UI.Model.Enums;
using Bdziam.UI.Theming.Model;
using Bdziam.UI.Utilities;
using MaterialColorUtilities.Palettes;
using MaterialColorUtilities.Schemes;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI.Theming;

public class ThemeService
{
    private Color _seedColor = Color.OrangeRed;

    public Color SeedColor
    {
        get => _seedColor;
        set
        {
            _seedColor = value;
            InitializeTheme();
        }
    }
    
    private Style _style = Style.Vibrant;

    public Style Style
    {
        get => _style;
        set
        {
            _style = value;
            InitializeTheme();
        }
    }

    private bool _isDarkMode = false;

    public bool IsDarkMode
    {
        get => _isDarkMode;
        set
        {
            _isDarkMode = value;
            InitializeTheme();
        }
    }
    
    public BColorScheme? CurrentColorScheme { get; private set; } 
    public Dictionary<ColorVariant, Color> ColorPalette { get; private set; }
    private readonly StringBuilder _cssVariablesBuilder = new();

    public event Action OnThemeChanged;
    /// <summary>
    /// Initializes the theme service and applies a default theme.
    /// </summary>
    public ThemeService()
    {
        InitializeTheme();
    }
    
    public void InitializeTheme()
    {
        Scheme<uint>? baseScheme = new Scheme<uint>();
        BaseSchemeMapper<CorePalette, Scheme<uint>> mapper = IsDarkMode ? new DarkSchemeMapper() : new LightSchemeMapper();
        var primary = CorePalette.Of(ColorUtility.ToArgb(_seedColor), Style);
  
        mapper.Map(primary, baseScheme);
        CurrentColorScheme = new BColorScheme(baseScheme.Convert(colorUint => ColorUtility.ColorFromArgb(colorUint)));
        ColorPalette = CurrentColorScheme.Enumerate().ToDictionary(k =>
        {
            if (Enum.TryParse(k.Key, true, out ColorVariant colorVariant))
            {
                return colorVariant;
            }

            return ColorVariant.Primary;
        }, v=> v.Value);
        OnThemeChanged?.Invoke();
    }
}
