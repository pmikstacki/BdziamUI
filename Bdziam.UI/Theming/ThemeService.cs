using System.Drawing;
using System.Text;
using Bdziam.UI.Theming.Model;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI.Theming;

public class ThemeService
{
    [Parameter] public Color PrimaryColor { get; set; } = Color.FromArgb(249, 115, 22);
    public Theme DarkTheme { get; private set; } = new Theme();
    public Theme LightTheme { get; private set; } = new Theme();

    private readonly StringBuilder _cssVariablesBuilder = new();

    public event Action OnThemeChanged;
    /// <summary>
    /// Initializes the theme service and applies a default theme.
    /// </summary>
    public ThemeService()
    {
        InitializeThemes(PrimaryColor);
    }

    /// <summary>
    /// Applies the provided theme and updates the CSS variables.
    /// </summary>
    public void ChangeColor(Color color)
    {
        InitializeThemes(color);
        OnThemeChanged?.Invoke();
    }

    private void InitializeThemes(Color color)
    {
        LightTheme = new Theme();
        LightTheme.Initialize(color, false);
        DarkTheme = new Theme();
        DarkTheme.Initialize(color, true);
    }
}
