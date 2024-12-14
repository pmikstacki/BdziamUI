using Bdziam.UI.Utilities;
using Blazicons;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI;

public partial class InputFieldIcon
{
    [Parameter] public SvgIcon? Icon { get; set; }
    [Parameter] public bool IsErrored { get; set; }
    [Parameter] public bool IsTrailing { get; set; }
    [Parameter] public EventCallback OnClick { get; set; }

    protected string IconStyles => new CssStyleBuilder()
        .AddStyle("display", "flex")
        .AddStyle("align-items", "center")
        .AddStyle("padding-right: 0.75rem", IsTrailing)
        .AddStyle("padding-left: 0.75rem", !IsTrailing)
        .AddStyle("justify-content", "center")
        .AddStyle("cursor", OnClick.HasDelegate ? "pointer" : "default")
        .Build();

    protected string IconColor => IsErrored ? "MaterialColor.Error" : "MaterialColor.OnSurfaceVariant";

    private async Task HandleClick()
    {
        if (OnClick.HasDelegate) await OnClick.InvokeAsync();
    }
}