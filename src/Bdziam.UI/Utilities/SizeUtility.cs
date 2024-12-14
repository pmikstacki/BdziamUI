using Bdziam.UI.Model.Enums;
using Bdziam.UI.Utilities;

namespace Bdziam.UI.Model.Utility;

public static class SizeUtility
{
    public static string GetIconSize(Size size)
    {
        return size switch
        {
            Size.Small => "1.25rem",
            Size.Medium => "1.5rem",
            Size.Large => "2rem",
            Size.ExtraLarge => "3rem",
            _ => "1.5rem"
        };
    }

    public static string GetPadding(Size size)
    {
        return size switch
        {
            Size.Small => "0.5rem",
            Size.Medium => "1rem",
            Size.Large => "2rem",
            Size.ExtraLarge => "3rem",
            Size.None => "0rem",
            _ => "0rem"
        };
    }

    public static Dictionary<string, object> GetIconSizeAttributes(Size iconSize = Size.Medium,
        string additionalStyle = "")
    {
        return new Dictionary<string, object>
        {
            ["style"] = new CssStyleBuilder()
                .AddStyle("width", GetIconSize(iconSize))
                .AddStyle("height", GetIconSize(iconSize))
                .Build(additionalStyle),
            ["width"] = GetIconSize(iconSize),
            ["height"] = GetIconSize(iconSize)
        };
    }
}