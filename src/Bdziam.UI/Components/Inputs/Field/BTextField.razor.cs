using System.Diagnostics.Metrics;
using System.Drawing;
using System.Net.Mime;
using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Model.Enums;
using Bdziam.UI.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Bdziam.UI;

public partial class BTextField : BInputField<string>
{
    public int? Counter { get; set; }
    [Parameter] public InputType InputType { get; set; }
    [Parameter] public int? MaxLength { get; set; }
    
    protected void OnInput(ChangeEventArgs e)
    {
        Value = e.Value?.ToString();
        Validate();
    }

    protected override bool IsEmpty()
    {
        return string.IsNullOrEmpty(Value);
    }

    protected string InputStyles => new CssStyleBuilder()
        
        .AddStyle("width", "100%")
        .AddStyle("height", "100%")
        .AddStyle("border", "none")
        .AddStyle("font-weight", "400")
        .AddStyle("outline", "none")
        .AddStyle("line-height",  "1.5rem")
        .AddStyle("background", "transparent")
        .AddStyle("padding", "1rem 0 1rem 0")
        .AddStyle("font-size", "1rem")
        .AddStyle("opacity", Disabled ? ColorUtility.DisabledOpacity : "1")
        .AddStyle("color", "var(--md-sys-color-on-surface)")
        .Build();

    
    
    private string GetCounterText() => Counter switch
    {
        null => string.Empty,
        0 => (string.IsNullOrEmpty(Value) ? "0" : $"{Value.Length}"),
        _ => (string.IsNullOrEmpty(Value) ? "0" : $"{Value.Length}") + $" / {MaxLength}"
    };
    
    protected string GetInputType()
    {
        return InputType.ToString().ToLowerInvariant().Replace("datetimeLocal", "datetime-local");
    }

}