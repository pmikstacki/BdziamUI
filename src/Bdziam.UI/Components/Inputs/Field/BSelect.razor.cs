using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Model.Enums;
using Bdziam.UI.Utilities;
using Blazicons;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace Bdziam.UI;

public partial class BSelect<T> : BInputField<T>
{
    [Parameter] public IEnumerable<T>? Options { get; set; } = Enumerable.Empty<T>();
    [Parameter] public IQueryable<T>? VirtualOptions { get; set; }
    [Parameter] public Func<T, string>? DisplayProperty { get; set; }
    [Parameter] public EventCallback<T> OnSelect { get; set; }
    [Parameter] public bool ShowSearch { get; set; } = false;
    [Parameter] public int VisibleOptionsCount { get; set; } = 10;
    [Parameter] public bool ShowOptionIcons { get; set; } = false;
    [Parameter] public Func<T, SvgIcon>? GetOptionIcon { get; set; }

    private bool DropdownVisible { get; set; }
    private string? SearchQuery { get; set; }

    private IEnumerable<T> FilteredOptions => string.IsNullOrEmpty(SearchQuery)
        ? Options ?? Enumerable.Empty<T>()
        : (Options ?? Enumerable.Empty<T>()).Where(o => OptionToString(o).Contains(SearchQuery, StringComparison.OrdinalIgnoreCase));

    private string SelectedText => Value != null ? OptionToString(Value) : "";

    protected override bool IsEmpty() => Value is null;

    private void ToggleDropdown()
    {
        if (Disabled) return;
        DropdownVisible = !DropdownVisible;
    }

    private async Task OnOptionSelect(T option)
    {
        Value = option;
        DropdownVisible = false;
        await OnSelect.InvokeAsync(option);
        Validate();
    }

    private async ValueTask<ItemsProviderResult<T>> LoadVirtualizedOptions(ItemsProviderRequest request)
    {
        var query = VirtualOptions ?? FilteredOptions.AsQueryable();

        if (!string.IsNullOrEmpty(SearchQuery))
        {
            query = query.Where(o => OptionToString(o).Contains(SearchQuery, StringComparison.OrdinalIgnoreCase));
        }

        var totalItemCount = query.Count();
        var items = query.Skip(request.StartIndex).Take(request.Count).ToList();

        return new ItemsProviderResult<T>(items, totalItemCount);
    }

    private string OptionToString(T option) =>
        DisplayProperty != null ? DisplayProperty(option) : option?.ToString() ?? string.Empty;

    private string InputContainerStyles => new CssStyleBuilder()
        .AddStyle("display", "flex")
        .AddStyle("align-self", "center")
        .AddStyle("position", "relative")
        .AddStyle("font-size", "1rem")
        .AddStyle("font-weight", "400")
        .AddStyle("margin-top", "0.7rem", IsFocusedOrFilled && Variant == FieldVariant.Filled)
        .AddStyle("font-family", "Roboto")
        .AddStyle("color", ColorUtility.GetColorVariable(IsFocused ? MaterialColor.Primary : MaterialColor.OnSurfaceVariant))
        .AddStyle("width", FullWidth ? "100%" : "10rem")
        .Build();

    public BInputView InputView { get; set; }

    public string DropdownStyle => new CssStyleBuilder()
        .AddStyle("max-height", "10rem")
        .AddStyle("min-width", "10rem")
        .AddStyle("overflow-y", "auto")
        .Build();

    private string DropdownOptionStyles(T option) => new CssStyleBuilder()
        .AddStyle("padding", "0.5rem 1rem")
        .AddStyle("cursor", "pointer")
        .AddStyle("color", "var(--md-sys-color-on-surface)")
        .AddStyle("background-color", EqualityComparer<T>.Default.Equals(Value, option) ? "var(--md-sys-color-surface-variant)" : "transparent")
        .AddStyle("hover", "background: var(--md-sys-color-surface-container-high)")
        .Build();
}
