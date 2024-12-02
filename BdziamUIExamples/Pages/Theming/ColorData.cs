using Bdziam.UI.Model.Enums;

namespace BdziamUIExamples.Pages.Theming;

public class ColorData(string colorName, string colorHexValue, MdSysColor mdSysColor)
{
    public MdSysColor MdSysColor { get; set;  } = mdSysColor;
    public string ColorName { get; set; } = colorName;
    public string ColorHexValue { get; set; } = colorHexValue;
    
}