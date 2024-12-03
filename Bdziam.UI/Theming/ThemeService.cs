using System.Drawing;
using System.Text;
using Bdziam.UI.Model.Enums;
using Bdziam.UI.Theming.MaterialColors.ColorSpace;
using Bdziam.UI.Theming.MaterialColors.DynamicColor;
using Bdziam.UI.Theming.MaterialColors.Scheme;
using Bdziam.UI.Theming.Model;
using Bdziam.UI.Utilities;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI.Theming;

public class ThemeService
{
    private System.Drawing.Color _seedColor = System.Drawing.Color.OrangeRed;

    public System.Drawing.Color SeedColor
    {
        get => _seedColor;
        set
        {
            _seedColor = value;
            InitializeTheme();
        }
    }
    
    private DynamicSchemeVariant _style = DynamicSchemeVariant.Vibrant;

    public DynamicSchemeVariant Style
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
        var seedColor = ColorUtility.ToArgb(_seedColor);
        var scheme = DynamicSchemeMap.GetDynamicScheme(Hct.FromInt(seedColor), IsDarkMode, 0.7, Style);
        CurrentColorScheme = new BColorScheme(scheme);
        OnThemeChanged?.Invoke();
    }
}
