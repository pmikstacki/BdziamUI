using Bdziam.UI.Components.Popover;
using Bdziam.UI.Components.Tabs;
using Bdziam.UI.Interop;
using Bdziam.UI.Theming;
using Blazored.LocalStorage;
using Microsoft.Extensions.DependencyInjection;

namespace Bdziam.UI.Extensions;

public static class BdziamExtensions
{
    public static IServiceCollection AddBdziamUiServices(this IServiceCollection services) =>
        services.AddScoped<ThemeService>().AddScoped<PopoverService>().AddScoped<TabsService>().AddScoped<ElementSizeService>().AddScoped<NavigationService>().AddBlazoredLocalStorage();
}