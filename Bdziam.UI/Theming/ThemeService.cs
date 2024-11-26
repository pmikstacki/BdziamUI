using System.Drawing;
using System.Text;
using Bdziam.UI.Theming.Model;
using MaterialColorUtilities.Palettes;
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
            InitializeThemes();
        }
    }

    private Style _style = Style.Vibrant;

    public Style Style
    {
        get => _style;
        set
        {
            _style = value;
            InitializeThemes();
        }
    }

    public Theme DarkTheme { get; private set; } = new Theme();
    public Theme LightTheme { get; private set; } = new Theme();

    private readonly StringBuilder _cssVariablesBuilder = new();

    public event Action OnThemeChanged;
    /// <summary>
    /// Initializes the theme service and applies a default theme.
    /// </summary>
    public ThemeService()
    {
        InitializeThemes();
    }
    
    public void InitializeThemes()
    {
        LightTheme = new Theme();
        LightTheme.Initialize(SeedColor, false, Style);
        DarkTheme = new Theme();
        DarkTheme.Initialize(SeedColor, true, Style);
    }
}
