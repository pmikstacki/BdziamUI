using System.Drawing;
using MaterialColorUtilities.Palettes;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI;

public partial class BThemeManager : ComponentBase
{
    public bool IsThemeManagerOpen { get; set; }
    [Parameter] public Action<Color> SeedColorChanged { get; set; }
    [Parameter] public Action<Style> StyleChanged { get; set; }
    
    
}