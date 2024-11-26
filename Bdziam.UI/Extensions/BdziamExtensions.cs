using Bdziam.UI.Components.Popover;
using Bdziam.UI.Interop;
using Bdziam.UI.Theming;
using Microsoft.Extensions.DependencyInjection;

namespace Bdziam.UI.Extensions;

public static class BdziamExtensions
{
    public static IServiceCollection AddBdziamUiServices(this IServiceCollection services) =>
        services.AddScoped<ThemeService>().AddScoped<PopoverService>();
}