using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Model.Enums;
using Bdziam.UI.Model.Utility;
using Bdziam.UI.Utilities;
using Blazicons;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI;

public partial class BIcon : BComponentBase, IControlIcon, IControlSize, IControlColor
{
    private string AdditionalStyle => new CssStyleBuilder()
        .AddStyle("color", ColorUtility.GetColorVariable(Color))
        .Build(Style);

    private Dictionary<string, object> IconAttributes => SizeUtility.GetIconSizeAttributes(Size, AdditionalStyle);

    [Parameter] public MaterialColor Color { get; set; }
    [Parameter] public SvgIcon? Icon { get; set; }
    [Parameter] public Size Size { get; set; } = Size.Medium;
}