using Bdziam.UI.Model.Enums;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI.Components.CommonBase;

public interface IControlSize
{
    [Parameter] public Size Size { get; set; }
}