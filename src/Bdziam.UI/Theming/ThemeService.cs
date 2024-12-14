using System.Drawing;
using Bdziam.UI.Theming.MaterialColors.ColorSpace;
using Bdziam.UI.Theming.MaterialColors.DynamicColor;
using Bdziam.UI.Theming.MaterialColors.Scheme;
using Bdziam.UI.Theming.Model;
using Bdziam.UI.Utilities;

namespace Bdziam.UI.Theming;

public class ThemeService
{
    private bool _isDarkMode;
    private Color _seedColor = Color.OrangeRed;

    private DynamicSchemeVariant _style = DynamicSchemeVariant.Vibrant;

    /// <summary>
    ///     Initializes the theme service and applies a default theme.
    /// </summary>
    public ThemeService()
    {
        InitializeTheme();
    }

    public Color SeedColor
    {
        get => _seedColor;
        set
        {
            _seedColor = value;
            InitializeTheme();
        }
    }

    public DynamicSchemeVariant Style
    {
        get => _style;
        set
        {
            _style = value;
            InitializeTheme();
        }
    }

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

    public event Action OnThemeChanged;

    public void InitializeTheme()
    {
        var seedColor = ColorUtility.ToArgb(_seedColor);
        var scheme = DynamicSchemeMap.GetDynamicScheme(Hct.FromInt(seedColor), IsDarkMode, 0.7, Style);
        CurrentColorScheme = new BColorScheme(scheme);
        OnThemeChanged?.Invoke();
    }
}