using Microsoft.JSInterop;
using System.Collections.Concurrent;
using System.Text;

namespace Bdziam.UI.Services;

/// <summary>
/// A service for managing dynamic CSS styles in Blazor applications.
/// Handles CSS generation, deduplication, and injection via JS interop.
/// </summary>
public class StyleService : IAsyncDisposable
{
    private readonly IJSRuntime _jsRuntime;
    private IJSObjectReference? _jsModule;
    private readonly ConcurrentDictionary<string, string> _injectedStyles = new();

    public StyleService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    /// <summary>
    /// Dynamically loads the JS module for CSS injection.
    /// </summary>
    private async Task<IJSObjectReference> GetJsModuleAsync()
    {
        if (_jsModule == null)
        {
            _jsModule = await _jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/Bdziam.UI/js/cssRegistry.js");
        }

        return _jsModule;
    }

    /// <summary>
    /// Generates scoped CSS based on the provided parameters.
    /// </summary>
    public string GenerateScopedCss(string? id, string? className, StyleState state, bool isRoot, string? childContent)
    {
        var sb = new StringBuilder();

        if (isRoot)
        {
            sb.AppendLine(":root {");
            sb.AppendLine(childContent ?? string.Empty);
            sb.AppendLine("}");
        }
        else
        {
            if (!string.IsNullOrEmpty(className)) sb.Append($".{className}");
            if (!string.IsNullOrEmpty(id)) sb.Append($"#{id}");
            if (state != StyleState.None) sb.Append($":{state.ToString().ToLower()}");
            sb.AppendLine(" {");
            sb.AppendLine(childContent ?? string.Empty);
            sb.AppendLine("}");
        }

        return sb.ToString();
    }

    /// <summary>
    /// Injects CSS content or external files into the browser's DOM.
    /// </summary>
    public async Task InjectStyleAsync(string id, string? cssContent, string? cssFile, bool unique = false)
    {
        var jsModule = await GetJsModuleAsync();

        if (!string.IsNullOrEmpty(cssContent))
        {
            if (!unique && _injectedStyles.ContainsKey(id)) return;

            _injectedStyles[id] = cssContent;
            await jsModule.InvokeVoidAsync("injectStyle", id, cssContent);
        }

        if (!string.IsNullOrEmpty(cssFile))
        {
            await jsModule.InvokeVoidAsync("injectCssFile", cssFile);
        }
    }

    /// <summary>
    /// Disposes of the loaded JS module when no longer needed.
    /// </summary>
    public async ValueTask DisposeAsync()
    {
        if (_jsModule != null)
        {
            await _jsModule.DisposeAsync();
        }
    }
}
