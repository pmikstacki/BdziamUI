using System.Reflection;
using Blazicons;

namespace Bdziam.UI.Extensions;

public static class SvgIconResolver
{
    /// <summary>
    ///     Resolves an icon name to either GoogleMaterialFilledIcon or MdiIcon.
    /// </summary>
    /// <param name="iconName">The name of the icon (e.g., "Home", "DotsGrid").</param>
    /// <returns>The resolved SvgIcon, or null if not found.</returns>
    public static SvgIcon? Resolve(string? iconName, string? svgIconContent = null)
    {
        if (svgIconContent != null) return SvgIcon.FromContent(svgIconContent);

        if (string.IsNullOrWhiteSpace(iconName))
            return null;

        // Try to resolve from GoogleMaterialFilledIcon
        var googleIcon = ResolveFromNamespace(typeof(GoogleMaterialFilledIcon), iconName);
        if (googleIcon != null)
            return googleIcon;

        // Fallback to MdiIcon
        return ResolveFromNamespace(typeof(MdiIcon), iconName);
    }

    /// <summary>
    ///     Resolves an icon from a specific namespace.
    /// </summary>
    /// <param name="namespaceName">The namespace to search (e.g., "Blazicons.GoogleMaterialFilledIcon").</param>
    /// <param name="iconName">The name of the icon.</param>
    /// <returns>The resolved SvgIcon, or null if not found.</returns>
    private static SvgIcon? ResolveFromNamespace(Type type, string iconName)
    {
        if (type == null)
            return null;

        var field = type.GetProperty(iconName, BindingFlags.Public | BindingFlags.Static);
        return field?.GetValue(null) as SvgIcon;
    }
}