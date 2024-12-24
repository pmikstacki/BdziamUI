namespace Bdziam.UI;

[AttributeUsage(AttributeTargets.Class)]
public class NavigationItemAttribute : Attribute
{
    /// <summary>
    ///     Constructor for categories or items with no URI.
    /// </summary>
    public NavigationItemAttribute(string path, string? icon = null, int order = 0, string uri = null)
    {
        Path = path;
        IconString = icon;
        Uri = uri;
    }
    
    public int Order { get; set; } = 0;
    public string? Uri { get; }
    public string Path { get; }
    public string? IconString { get; }
    public string? SvgIconString => IsSvgIcon() ? ExtractSvgCode() : null;

    /// <summary>
    ///     Determines if the IconString is an SVG string.
    /// </summary>
    private bool IsSvgIcon()
    {
        return IconString?.StartsWith("svg(", StringComparison.OrdinalIgnoreCase) == true
               && IconString?.EndsWith(")") == true;
    }

    /// <summary>
    ///     Extracts the SVG code from the IconString if it represents an SVG.
    /// </summary>
    private string? ExtractSvgCode()
    {
        if (!IsSvgIcon()) return null;
        return IconString?.Substring(4, IconString.Length - 5); // Remove "svg(" and ")"
    }
}