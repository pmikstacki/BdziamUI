using System;
using System.Threading.Tasks;
using Bdziam.UI.Components.Popover;
using Bdziam.UI.Model.Enums;
using Bdziam.UI.Theming;
using Bdziam.UI.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Bdziam.UI
{
    public partial class BPopover : ComponentBase, IAsyncDisposable
    {
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public bool IsOpen { get; set; } = false;
        [Parameter] public EventCallback<bool> IsOpenChanged { get; set; }
        [Parameter] public string TargetElementId { get; set; }
        [Parameter] public string AdditionalClasses { get; set; } = string.Empty;
        [Parameter] public ColorVariant ColorVariant { get; set; } = ColorVariant.Background;
        [Parameter] public Position Position { get; set; } = Position.Bottom;
        [Parameter] public Size MarginSize { get; set; } = Size.None;

        private string PopoverElementId { get; } = $"popover-{Guid.NewGuid()}";

        [Inject] private PopoverService PopoverService { get; set; }
        [Inject] private ThemeService ThemeService { get; set; }
        private string PopoverClasses => new CssClassBuilder()
            .AddClass("bd-popover")
            .AddClass("transition-all ease-in-out")
            .AddClass("transition-opacity transform")
            .AddClass(IsOpen ? "opacity-100" : "opacity-0")
            .AddClass(AdditionalClasses)
            .Build();
        private string PopoverStyles => new CssStyleBuilder()
            .AddStyle( "position","absolute")
            .AddStyle( "display","inline-block")
            .AddStyle( "z-index","1000")
            .AddStyle( "overflow","hidden")
            .AddStyle("background-color", $"var(--color-{ColorVariant.ToString().ToLower()});")
            .AddStyle("color", $"var(--color-{ColorVariant.ToString().ToLower()}-text);")
            .AddStyle("box-shadow", "0px 4px 6px rgba(0, 0, 0, 0.1), 0px 1px 3px rgba(0, 0, 0, 0.06);") // Elevation
            .AddStyle("border-radius", "12px") // Rounded corners
            .AddStyle("padding", "16px") // Padding for content
            .AddStyle("transition", "opacity 0.2s ease, transform 0.2s ease") // Smooth transitions
            .AddStyle("opacity", IsOpen ? "1" : "0") // Show/Hide animation
            .AddStyle("transform", IsOpen ? "scale(1)" : "scale(0.95)") // Scale effect for open/close
            .Build();


        private DotNetObjectReference<BPopover> _dotNetRef;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (IsOpen)
            {
                _dotNetRef ??= DotNetObjectReference.Create(this);
                await PopoverService.InitializePopoverAsync(PopoverElementId, TargetElementId, GetOptions(), _dotNetRef);
            }
            else
            {
                if (_dotNetRef != null)
                {
                    _dotNetRef.Dispose();
                    _dotNetRef = null;
                }
                await PopoverService.ClosePopoverAsync(PopoverElementId);
            }
        }

        private object GetOptions()
        {
            return new
            {
                position = Position.ToString().ToLower(),
                margin = GetMarginValue(MarginSize)
            };
        }

        private double GetMarginValue(Size marginSize)
        {
            return marginSize switch
            {
                Size.None => 0,
                Size.Small => 4,
                Size.Medium => 8,
                Size.Large => 16,
                Size.ExtraLarge => 32,
                _ => 0,
            };
        }

        [JSInvokable]
        public async Task OnOutsideClick()
        {
            IsOpen = false;
            await IsOpenChanged.InvokeAsync(IsOpen);
            await InvokeAsync(StateHasChanged);
        }

        public async ValueTask DisposeAsync()
        {
            await PopoverService.ClosePopoverAsync(PopoverElementId);

            if (_dotNetRef != null)
            {
                _dotNetRef.Dispose();
                _dotNetRef = null;
            }
        }
    }
}
