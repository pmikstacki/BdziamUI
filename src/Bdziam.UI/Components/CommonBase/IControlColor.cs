using Bdziam.UI.Model.Enums;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI.Components.CommonBase;

public interface IControlColor
{
    [Parameter] public MaterialColor Color { get; set; }
}