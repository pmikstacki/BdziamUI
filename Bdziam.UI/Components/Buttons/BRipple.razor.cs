using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace Bdziam.UI
{
    public partial class BRipple : ComponentBase, IAsyncDisposable
    {
        [Parameter] public RenderFragment? ChildContent { get; set; }

        private IJSObjectReference? _jsModule;
        private ElementReference _rippleContainer;

        [Inject] private IJSRuntime JSRuntime { get; set; } = default!;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>(
                    "import",
                    "./_content/Bdziam.UI/js/ripple.js"
                );
            }
        }

        private async Task CreateRipple(MouseEventArgs e)
        {
            if (_jsModule != null)
            {
                await _jsModule.InvokeVoidAsync("createRipple", _rippleContainer, e.ClientX, e.ClientY);
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (_jsModule != null)
            {
                await _jsModule.DisposeAsync();
            }
        }
    }
}