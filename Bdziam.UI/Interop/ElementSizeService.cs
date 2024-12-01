using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Bdziam.UI.Interop
{
    public class ElementSizeService : IAsyncDisposable
    {
        private readonly IJSRuntime _jsRuntime;
        private IJSObjectReference? _module;

        public ElementSizeService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        private async Task<IJSObjectReference> GetModuleAsync()
        {
            if (_module == null)
            {
                _module = await _jsRuntime.InvokeAsync<IJSObjectReference>(
                    "import", "./_content/Bdziam.UI/js/element-size.js");
            }
            return _module;
        }

        /// <summary>
        /// Gets the size of an HTML element by its ID.
        /// </summary>
        /// <param name="elementId">The ID of the HTML element.</param>
        /// <returns>A tuple containing the width and height of the element, or null if not found.</returns>
        public async Task<DOMRect?> GetElementSizeAsync(string elementId)
        {
            try
            {
                var module = await GetModuleAsync();
                var size = await module.InvokeAsync<DOMRect>("getElementSize", elementId);
                return size;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting size for element '{elementId}': {ex.Message}");
                return null;
            }
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