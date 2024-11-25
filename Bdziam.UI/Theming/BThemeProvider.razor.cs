using System.Text;
using Bdziam.UI.Theming.Model;
using Bdziam.UI.Utilities;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI;

public partial class BThemeProvider
{
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
                StateHasChanged();
            }
        }
    }

    protected string BuildTheme()
    {
        var theme = new StringBuilder();
        theme.AppendLine("<style>");
        theme.AppendLine(":root {");
        theme.Append(InjectCssVariables(IsDarkMode));
        theme.Append("background-color: var(--color-background);");
        theme.AppendLine("}");
        theme.Append(InjectColorClasses());
        theme.AppendLine("</style>");

        return theme.ToString();
    }

    public string InjectCssVariables(bool isDarkMode)
    {
        var cssBuilder = new StringBuilder();
        var currentTheme = isDarkMode ? ThemeService.DarkTheme : ThemeService.LightTheme;

        AppendCssVariable(cssBuilder, "primary", currentTheme.Primary);
        AppendCssVariable(cssBuilder, "secondary", currentTheme.Secondary);
        AppendCssVariable(cssBuilder, "tertiary", currentTheme.Tertiary);
        AppendCssVariable(cssBuilder, "error", currentTheme.Error);
        AppendCssVariable(cssBuilder, "warning", currentTheme.Warning);
        AppendCssVariable(cssBuilder, "success", currentTheme.Success);
        AppendCssVariable(cssBuilder, "info", currentTheme.Info);
        AppendCssVariable(cssBuilder, "neutral", currentTheme.Neutral);
        AppendCssVariable(cssBuilder, "neutral-variant", currentTheme.NeutralVariant);

        // Background and Surface Colors
        cssBuilder.AppendLine($"--color-background: {StyleUtility.ToCssColor(currentTheme.Background)};");
        for (int i = 1; i <= 3; i++)
        {
            cssBuilder.AppendLine($"--color-surface-{i}: {StyleUtility.ToCssColor(currentTheme.GetSurfaceLevel(i))};");
        }
        cssBuilder.AppendLine($"--color-surface: {StyleUtility.ToCssColor(currentTheme.Surface)};");

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
        cssBuilder.AppendLine($".bg-surface {{ background-color: var(--color-surface); }}");
        for (int i = 1; i <= 3; i++)
        {
            cssBuilder.AppendLine($".bg-surface-{i} {{ background-color: var(--color-surface-{i}); }}");
        }

        return cssBuilder.ToString();
    }

    private void AppendCssVariable(StringBuilder cssBuilder, string name, ThemeColor themeColor)
    {
        cssBuilder.AppendLine($"--color-{name}: {StyleUtility.ToCssColor(themeColor.Main)};");
        cssBuilder.AppendLine($"--color-{name}-hover: {StyleUtility.ToCssColor(themeColor.Hover)};");
        cssBuilder.AppendLine($"--color-{name}-disabled: {StyleUtility.ToCssColor(themeColor.Disabled)};");
        cssBuilder.AppendLine($"--color-{name}-text: {StyleUtility.ToCssColor(themeColor.Text)};");
    }

    private void AppendColorClass(StringBuilder cssBuilder, string name)
    {
        cssBuilder.AppendLine($".bg-{name} {{ background-color: var(--color-{name}); }}");
        cssBuilder.AppendLine($".bg-{name}-hover:hover {{ background-color: var(--color-{name}-hover); }}");
        cssBuilder.AppendLine($".bg-{name}-disabled {{ background-color: var(--color-{name}-disabled); }}");
        cssBuilder.AppendLine($".text-{name} {{ color: var(--color-{name}-text); }}");
    }
}
