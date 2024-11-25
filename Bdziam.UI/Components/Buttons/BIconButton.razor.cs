using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Model.Enums;
using Bdziam.UI.Model.Utility;
using Bdziam.UI.Utilities;
using Blazicons;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI
{
    public partial class BIconButton : BButtonBase, IControlIcon, IControlIconSize
    {
        [Parameter] public SvgIcon? Icon { get; set; }
        [Parameter] public Size? IconSize { get; set; }

        private Dictionary<string, object> IconAttributes => new()
        {
            ["style"] = new CssStyleBuilder()
                .AddStyle("width", IconSize.HasValue ? SizeUtility.GetIconSize(IconSize.Value) : SizeUtility.GetIconSize(Size))
                .AddStyle("height", IconSize.HasValue ? SizeUtility.GetIconSize(IconSize.Value) : SizeUtility.GetIconSize(Size))
                .Build(),
            ["width"] = IconSize.HasValue ? SizeUtility.GetIconSize(IconSize.Value) : SizeUtility.GetIconSize(Size),
            ["height"] = IconSize.HasValue ? SizeUtility.GetIconSize(IconSize.Value) : SizeUtility.GetIconSize(Size),
        };
    }
}