using Bdziam.UI.Model.Enums;

namespace BdziamUIExamples.Pages.Theming;

public class ColorData(string colorName, string colorHexValue, MaterialColor materialColor)
{
    public MaterialColor MaterialColor { get; set; } = materialColor;
    public string ColorName { get; set; } = colorName;
    public string ColorHexValue { get; set; } = colorHexValue;
}