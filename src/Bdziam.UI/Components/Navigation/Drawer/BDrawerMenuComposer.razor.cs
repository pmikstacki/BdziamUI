using Microsoft.AspNetCore.Components;

namespace Bdziam.UI;

public partial class BDrawerMenuComposer : ComponentBase
{
    private IEnumerable<BDrawerMenuItemModel> MenuItems = Enumerable.Empty<BDrawerMenuItemModel>();

    [CascadingParameter] public BDrawerMenu DrawerMenu { get; set; }

    protected override async Task OnInitializedAsync()
    {
        MenuItems = NavigationService.GetMenuHierarchy();
    }

    private RenderFragment RenderMenuItem(BDrawerMenuItemModel item)
    {
        return builder =>
        {
            builder.OpenComponent<BDrawerMenuItem>(0);
            if (item.Uri != null) builder.AddAttribute(1, "Uri", item.Uri);
            builder.AddAttribute(2, "Text", item.Text);
            if (item.Icon != null) builder.AddAttribute(3, "Icon", item.Icon);
            builder.AddAttribute(4, "ComposedMenu", DrawerMenu);
            if (item.Children.Count > 0)
                builder.AddAttribute(5, "ChildContent", (RenderFragment)(childBuilder =>
                {
                    foreach (var child in item.Children) childBuilder.AddContent(6, RenderMenuItem(child));
                }));

            builder.CloseComponent();
        };
    }
}