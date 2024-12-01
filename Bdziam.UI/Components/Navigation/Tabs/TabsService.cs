using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Bdziam.UI.Components.Tabs
{
    public class TabsService : IAsyncDisposable
    {
        private readonly IJSRuntime _jsRuntime;
        private IJSObjectReference? _module;

        public TabsService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        private async Task<IJSObjectReference> GetModuleAsync()
        {
            if (_module == null)
            {
                _module = await _jsRuntime.InvokeAsync<IJSObjectReference>(
                    "import", "./_content/Bdziam.UI/js/tabs.js");
            }
            return _module;
        }

        public async Task UpdateActiveLineAsync(string tabId, string containerId, bool isPrimary = true)
        {
            var module = await GetModuleAsync();
            await module.InvokeVoidAsync("updateActiveLine", tabId, containerId, isPrimary);
        }

        public async ValueTask DisposeAsync()
        {
            if (_module != null)
            {
                await _module.DisposeAsync();
            }
        }
    }
}
