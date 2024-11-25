using Blazicons;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI
{
    public partial class BDrawerHeader
    {
        [Parameter] public string? Text { get; set; }
        [Parameter] public SvgIcon? Icon { get; set; }
    }
}