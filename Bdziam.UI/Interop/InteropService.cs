using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Bdziam.UI.Interop
{
    public class InteropService : IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;

        public InteropService(IJSRuntime jsRuntime)
        {
            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/Bdziam.UI/js/bdziamui.js").AsTask());
        }

        public async Task<ElementPosition> GetElementPosition(string elementId)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<ElementPosition>("getElementPosition", elementId);
        }

        public async Task<ElementSize> GetElementSize(string elementId)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<ElementSize>("getElementSize", elementId);
        }

        public async Task AddOutsideClickListener(string elementId, DotNetObjectReference<object> dotNetHelper)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("addOutsideClickListener", elementId, dotNetHelper);
        }

        public async Task RemoveOutsideClickListener(string elementId)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("removeOutsideClickListener", elementId);
        }

        public async ValueTask DisposeAsync()
        {
            if (moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                await module.DisposeAsync();
            }
        }
    }
}