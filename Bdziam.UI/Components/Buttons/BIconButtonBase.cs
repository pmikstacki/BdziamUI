using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Model.Enums;
using Bdziam.UI.Model.Utility;
using Bdziam.UI.Utilities;
using Blazicons;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI;

public class BIconButtonBase : BButtonBase, IControlIcon, IControlIconSize
{
    [Parameter] public SvgIcon? Icon { get; set; }
    [Parameter] public Size IconSize { get; set; } = Size.Medium;
    
    protected override string GetVariantStyles()
    {
        var colorVariantName = MdSysColor.ToString().ToLower();

        var styleBuilder = new CssStyleBuilder()
            .AddStyle("padding", "0.5rem")
            .AddStyle("border-radius", "100%")
            .AddStyle("background", $"transparent")
            .AddStyle("color", ColorUtility.GetTextColorVariable(MdSysColor))
            .AddStyle("display", "flex")
            .AddStyle("flex-direction", "row")
            .Build();

        return styleBuilder.ToString();
    }

        
    internal Dictionary<string, object> IconAttributes => new()
    {
        ["style"] = new CssStyleBuilder()
            .AddStyle("width", SizeUtility.GetIconSize(IconSize))
            .AddStyle("height", SizeUtility.GetIconSize(IconSize))
            .Build(),
        ["width"] = SizeUtility.GetIconSize(IconSize),
        ["height"] = SizeUtility.GetIconSize(IconSize),
    };
}