using System.Drawing;
using System.Text;
using Bdziam.UI.Theming;
using Bdziam.UI.Theming.Model;
using Bdziam.UI.Utilities;
using Blazored.LocalStorage;
using MaterialColorUtilities.Palettes;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI;

public partial class BThemeProvider
{
    private const string BdziamThemeKey = "bdziam_theme";

    [Inject]
    public ILocalStorageService Storage { get; set; }
    /// <summary>
    /// Invoked when the seed color changes.
    /// </summary>
    [Parameter]
    public EventCallback<Color> SeedColorChanged { get; set; }

    private Color _seedColor = Color.OrangeRed;

    /// <summary>
    /// Tracks the current seed color state and triggers changes.
    /// </summary>
    [Parameter]
    public Color SeedColor
    {
        get => _seedColor;
        set
        {
            if (_seedColor != value)
            {
                _seedColor = value;
                SeedColorChanged.InvokeAsync(_seedColor);
                SaveBdziamTheme();
                StateHasChanged();
            }
        }
    }
    /// <summary>
    /// Invoked when the style changes.
    /// </summary>
    [Parameter]
    public EventCallback<Style> StyleChanged { get; set; }

    private Style _style = Style.Vibrant;

    /// <summary>
    /// Tracks the current style state and triggers changes.
    /// </summary>
    [Parameter]
    public Style Style
    {
        get => _style;
        set
        {
            if (_style != value)
            {
                _style = value;
                StyleChanged.InvokeAsync(_style);
                StateHasChanged();
                SaveBdziamTheme();
            }
        }
    }
    /// <summary>
    /// Invoked when the dark mode changes.
    /// </summary>
    [Parameter]
    public EventCallback<bool> IsDarkModeChanged { get; set; }

    private bool _isDarkMode;

    /// <summary>
    /// Tracks the current dark mode state and triggers changes.
    /// </summary>
    [Parameter]
    public bool IsDarkMode
    {
        get => _isDarkMode;
        set
        {
            if (_isDarkMode != value)
            {
                
                _isDarkMode = value;
                IsDarkModeChanged.InvokeAsync(_isDarkMode);
                SaveBdziamTheme();
                StateHasChanged();
            }
        }
    }

    protected string BuildTheme()
    {
        var theme = new StringBuilder();
        theme.AppendLine("<style>");
        theme.AppendLine(":root {");
        theme.Append(InjectCssVariables());
        theme.Append("background-color: var(--color-background);");
        theme.AppendLine("}");
        theme.Append(InjectColorClasses());
        theme.AppendLine("</style>");
      
        return theme.ToString();
    }

    private void SaveBdziamTheme()
    {
        Task.Run(async () => await Storage.SetItemAsync(BdziamThemeKey, new ThemeSettings()
        {
            IsDarkMode = IsDarkMode,
            PalleteStyle = Style,
            SeedColor = ColorUtility.ToArgb(SeedColor)
        }));
    }

    protected override async Task OnInitializedAsync()
    {
       var themeSettings = await Storage.GetItemAsync<ThemeSettings>(BdziamThemeKey);
       if (themeSettings != null)
       {
           SeedColor = ColorUtility.ColorFromArgb(themeSettings.SeedColor);
           Style = themeSettings.PalleteStyle;
           IsDarkMode = themeSettings.IsDarkMode;
           StateHasChanged();
       }
    }

    public string InjectCssVariables()
    {
        var cssBuilder = new StringBuilder();
        ThemeService.SeedColor = SeedColor;
        ThemeService.Style = Style;
        var currentTheme = IsDarkMode ? ThemeService.DarkTheme : ThemeService.LightTheme;

        AppendCssVariable(cssBuilder, "primary", currentTheme.Primary);
        AppendCssVariable(cssBuilder, "secondary", currentTheme.Secondary);
        AppendCssVariable(cssBuilder, "tertiary", currentTheme.Tertiary);
        AppendCssVariable(cssBuilder, "error", currentTheme.Error);
        AppendCssVariable(cssBuilder, "warning", currentTheme.Warning);
        AppendCssVariable(cssBuilder, "success", currentTheme.Success);
        AppendCssVariable(cssBuilder, "info", currentTheme.Info);
        AppendCssVariable(cssBuilder, "neutral", currentTheme.Neutral);
        AppendCssVariable(cssBuilder, "neutral-variant", currentTheme.NeutralVariant);
        cssBuilder.AppendLine($"--color-surface: {StyleUtility.ToCssColor(currentTheme.Surface)};");
        cssBuilder.AppendLine($"--color-surface-text: {StyleUtility.ToCssColor(currentTheme.SurfaceText)};");

        for (int i = 1; i <= ThemingConstants.SurfaceLevelsCount; i++)
        {
            cssBuilder.AppendLine($"--color-surface-{i}: {StyleUtility.ToCssColor(currentTheme.GetSurfaceLevel(i))};");
        }
        
        // Background and Surface Colors
        cssBuilder.AppendLine($"--color-background: {StyleUtility.ToCssColor(currentTheme.Background)};");
      

        return cssBuilder.ToString();
    }

    private string InjectColorClasses()
    {
        var cssBuilder = new StringBuilder();

        // Generate CSS classes for each color variant
        AppendColorClass(cssBuilder, "primary");
        AppendColorClass(cssBuilder, "secondary");
        AppendColorClass(cssBuilder, "tertiary");
        AppendColorClass(cssBuilder, "error");
        AppendColorClass(cssBuilder, "warning");
        AppendColorClass(cssBuilder, "success");
        AppendColorClass(cssBuilder, "info");
        AppendColorClass(cssBuilder, "variant");
        AppendColorClass(cssBuilder, "variant-neutral");
        // Background and surface classes
        cssBuilder.AppendLine($".bg-background {{ background-color: var(--color-background); }}");
        
        return cssBuilder.ToString();
    }

    private void AppendCssVariable(StringBuilder cssBuilder, string name, ThemeColor themeColor)
    {
        cssBuilder.AppendLine($"--color-{name}: {StyleUtility.ToCssColor(themeColor.Main)};");
        cssBuilder.AppendLine($"--color-{name}-hover: {StyleUtility.ToCssColor(themeColor.Hover)};");
        cssBuilder.AppendLine($"--color-{name}-disabled: {StyleUtility.ToCssColor(themeColor.Disabled)};");
        cssBuilder.AppendLine($"--color-{name}-text: {StyleUtility.ToCssColor(themeColor.Text)};");
        cssBuilder.AppendLine($"--color-{name}-surface: {StyleUtility.ToCssColor(themeColor.Surface)};");
        cssBuilder.AppendLine($"--color-{name}-surface-text: {StyleUtility.ToCssColor(themeColor.SurfaceText)};");
        for (int i = 1; i <= ThemingConstants.SurfaceLevelsCount; i++)
        {
            cssBuilder.AppendLine($"--color-{name}-surface-{i}: {StyleUtility.ToCssColor(themeColor.GetSurfaceLevel(i))};");
            cssBuilder.AppendLine($"--color-{name}-surface-text-{i}: {StyleUtility.ToCssColor(themeColor.GetSurfaceTextLevel(i))};");
        }
    }

    private void AppendColorClass(StringBuilder cssBuilder, string name)
    {
        cssBuilder.AppendLine($".bg-{name} {{ background-color: var(--color-{name}); }}");
        cssBuilder.AppendLine($".{name}-hover {{ background-color: var(--color-{name}-hover); }}");
        cssBuilder.AppendLine($".{name}-disabled {{ background-color: var(--color-{name}-disabled); }}");
        cssBuilder.AppendLine($".text-{name} {{ color: var(--color-{name}-text); }}");
        cssBuilder.AppendLine($".surface-{name} {{ color: var(--color-{name}-surface); }}");
        for (int i = 1; i <= ThemingConstants.SurfaceLevelsCount; i++)
        {
            cssBuilder.AppendLine($".surface-{name}-{i} {{ color: var(--color-{name}-surface-{i}); }}");
            cssBuilder.AppendLine($".surface-{name}-text-{i} {{ color: var(--color-{name}-surface-text-{i}); }}");

        }
    }
}
