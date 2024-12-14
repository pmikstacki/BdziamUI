using Microsoft.JSInterop;

namespace Bdziam.UI.Components.Popover;

public class PopoverService : IAsyncDisposable
{
    private readonly IJSRuntime _jsRuntime;
    private IJSObjectReference _module;

    public PopoverService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async ValueTask DisposeAsync()
    {
        if (_module != null)
        {
            await _module.InvokeVoidAsync("dispose");
            await _module.DisposeAsync();
        }
    }

    private async Task<IJSObjectReference> GetModuleAsync()
    {
        if (_module == null)
            _module = await _jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/Bdziam.UI/js/popover.js");
        return _module;
    }

    public async Task InitializePopoverAsync(string popoverId, string targetId, object options,
        DotNetObjectReference<BPopover> dotNetRef, bool matchWidth)
    {
        var module = await GetModuleAsync();
        await module.InvokeVoidAsync("initializePopover", popoverId, targetId, options, dotNetRef, matchWidth);
    }

    public async Task ClosePopoverAsync(string popoverId)
    {
        if (_module != null) await _module.InvokeVoidAsync("closePopover", popoverId);
    }
}