using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Utilities;
using Blazicons;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI;

public abstract class BDrawerMenuItemBase : BComponentBase, IControlIcon
{
    /// <summary>
    ///     The text displayed on the menu item.
    /// </summary>
    [Parameter]
    public string? Text { get; set; }

    [Parameter] public bool IsActive { get; set; }

    /// <summary>
    ///     CSS classes built dynamically, including additional classes.
    /// </summary>
    protected string ItemClasses => new CssClassBuilder()
        .AddClass(Class)
        .Build();

    /// <summary>
    ///     CSS styles built dynamically, including additional styles.
    /// </summary>
    protected string ItemStyles => new CssStyleBuilder()
        .AddStyle("overflow", "hidden")
        .Build(Style);


    [CascadingParameter] public BDrawerMenu? CascadedMenu { get; set; }

    /// <summary>
    ///     The main icon displayed on the menu item.
    /// </summary>
    [Parameter]
    public SvgIcon? Icon { get; set; }
}