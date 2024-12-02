using System.Drawing;
using Bdziam.UI.Theming.MaterialColors.DynamicColor;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI;

public partial class BThemeManager : ComponentBase
{
    public bool IsThemeManagerOpen { get; set; }
    [Parameter] public Action<Color> SeedColorChanged { get; set; }
    [Parameter] public Action<DynamicSchemeVariant> StyleChanged { get; set; }
    
    
}