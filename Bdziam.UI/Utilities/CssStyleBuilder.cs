namespace Bdziam.UI.Utilities;

public class CssStyleBuilder
{
    private readonly List<string> _styles = new List<string>();

    /// <summary>
    /// Adds a CSS style to the builder.
    /// </summary>
    /// <param name="property">The CSS property name.</param>
    /// <param name="value">The CSS property value.</param>
    /// <returns>The updated <see cref="CssStyleBuilder"/> instance.</returns>
    public CssStyleBuilder AddStyle(string property, string value)
    {
        if (!string.IsNullOrWhiteSpace(property) && !string.IsNullOrWhiteSpace(value))
        {
            _styles.Add($"{property}: {value};");
        }

        return this;
    }

    /// <summary>
    /// Adds a CSS style to the builder based on a condition.
    /// </summary>
    /// <param name="property">The CSS property name.</param>
    /// <param name="value">The CSS property value.</param>
    /// <param name="condition">A boolean indicating whether to add the style.</param>
    /// <returns>The updated <see cref="CssStyleBuilder"/> instance.</returns>
    public CssStyleBuilder AddStyle(string property, string value, bool condition)
    {
        if (condition && !string.IsNullOrWhiteSpace(property) && !string.IsNullOrWhiteSpace(value))
        {
            _styles.Add($"{property}: {value};");
        }

        return this;
    }

    /// <summary>
    /// Builds the final CSS style string.
    /// </summary>
    /// <returns>A string containing all the CSS styles concatenated.</returns>
    public string Build()
    {
        return string.Join(" ", _styles);
    }
}