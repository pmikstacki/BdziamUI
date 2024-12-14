using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Model.Enums;
using Bdziam.UI.Model.Utility;
using Bdziam.UI.Utilities;
using Microsoft.AspNetCore.Components;
using Size = Bdziam.UI.Model.Enums.Size;

namespace Bdziam.UI;

public partial class BBody : BComponentBase
{
    [Parameter] public Size Padding { get; set; } = Size.Medium;
    [Parameter] public RenderFragment ChildContent { get; set; }
    
    [Parameter] public MaterialColor BackgroundColor { get; set; }

    public string AppliedStyle =>
        new CssStyleBuilder()
            .AddStyle("overflow-y", "auto")
            .AddStyle("background-color", ColorUtility.GetColorVariable(BackgroundColor))
            .Build(Style);
}