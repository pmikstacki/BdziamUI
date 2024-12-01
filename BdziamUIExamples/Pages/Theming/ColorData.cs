using Bdziam.UI.Model.Enums;

namespace BdziamUIExamples.Pages.Theming;

public class ColorData(string colorName, string colorHexValue, ColorVariant colorVariant)
{
    public ColorVariant ColorVariant { get; set;  } = colorVariant;
    public string ColorName { get; set; } = colorName;
    public string ColorHexValue { get; set; } = colorHexValue;
    
}