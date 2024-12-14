using Microsoft.JSInterop;

namespace Bdziam.UI.Services;

public class BackgroundColorService : IAsyncDisposable
{
    private readonly IJSRuntime _jsRuntime;
    private IJSObjectReference? _module;

    public BackgroundColorService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    // Dispose the JS module
    public async ValueTask DisposeAsync()
    {
        if (_module != null) await _module.DisposeAsync();
    }

    // Load the JS module
    private async Task<IJSObjectReference> GetModuleAsync()
    {
        if (_module == null)
            _module = await _jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/Bdziam.UI/js/background-color.js");
        return _module;
    }

    public async Task<string> GetBackgroundColorFromPointAsync(double x, double y)
    {
        var module = await GetModuleAsync();
        return await module.InvokeAsync<string>("getBackgroundColorFromPoint", x, y);
    }
}