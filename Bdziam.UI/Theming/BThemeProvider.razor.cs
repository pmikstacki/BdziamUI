using System.Drawing;
using System.Text;
using Bdziam.UI.Theming;
using Bdziam.UI.Theming.Model;
using Bdziam.UI.Utilities;
using Blazored.LocalStorage;
using MaterialColorUtilities.Palettes;
using MaterialColorUtilities.Schemes;
using MaterialColorUtilities.Utils;
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
    public EventCallback<bool> TintSurfacesChanged { get; set; }

    private bool _tintSurfaces = true;

    /// <summary>
    /// Tracks the current seed color state and triggers changes.
    /// </summary>
    [Parameter]
    public bool TintSurfaces
    {
        get => _tintSurfaces;
        set
        {
            if (_tintSurfaces != value)
            {
                _tintSurfaces = value;
                TintSurfacesChanged.InvokeAsync(_tintSurfaces);
                SaveBdziamTheme();
                StateHasChanged();
            }
        }
    }
    
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
                ThemeService.SeedColor = SeedColor;
                SaveBdziamTheme();
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
                ThemeService.Style = Style;
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
                ThemeService.IsDarkMode = IsDarkMode;
                SaveBdziamTheme();
            }
        }
    }
    private void SaveBdziamTheme()
    {
        Task.Run(async () => await Storage.SetItemAsync(BdziamThemeKey, new ThemeSettings()
        {
            IsDarkMode = IsDarkMode,
            PalleteStyle = Style,
            SeedColor = ColorUtility.ToArgb(SeedColor),
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

       ThemeService.OnThemeChanged += StateHasChanged;
    }
    
    public string BuildTheme()
    {
        StringBuilder builder = new();
        var scheme = ThemeService.CurrentColorScheme;

        builder.AppendLine("<style>");
        builder.Append(":root");
        builder.Append(" {\n");
        foreach (var color in scheme.Enumerate())
        {
            builder.Append("    --md-sys-color-");
            builder.Append(CaseUtility.PascalToKebab(color.Key));
            builder.Append(": ");
            builder.Append(StyleUtility.ToCssColor(color.Value));
            builder.Append(";\n");
        }
        builder.Append('}');
        builder.AppendLine("</style>");
        return builder.ToString();
    }

}
