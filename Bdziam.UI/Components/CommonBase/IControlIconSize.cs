using Bdziam.UI.Model.Enums;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI.Components.CommonBase;

public interface IControlIconSize
{
    [Parameter] public Size? IconSize { get; set; }
}