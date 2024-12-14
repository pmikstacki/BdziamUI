namespace Bdziam.UI.Utilities;

public class CssStyleBuilder
{
    private readonly List<string> _styles = new();

    /// <summary>
    ///     Adds a CSS style to the builder.
    /// </summary>
    /// <param name="property">The CSS property name.</param>
    /// <param name="value">The CSS property value.</param>
    /// <returns>The updated <see cref="CssStyleBuilder" /> instance.</returns>
    public CssStyleBuilder AddStyle(string property, string value)
    {
        if (!string.IsNullOrWhiteSpace(property) && !string.IsNullOrWhiteSpace(value))
            _styles.Add($"{property}: {value};");

        return this;
    }


    /// <summary>
    ///     Adds a CSS style to the builder.
    /// </summary>
    /// <param name="property">The CSS property name.</param>
    /// <param name="value">The CSS property value.</param>
    /// <returns>The updated <see cref="CssStyleBuilder" /> instance.</returns>
    public CssStyleBuilder AddStyle(string property, Func<string> style)
    {
        if (!string.IsNullOrWhiteSpace(property) && !string.IsNullOrWhiteSpace(style?.Invoke()))
            _styles.Add($"{property}: {style?.Invoke()};");

        return this;
    }

    /// <summary>
    ///     Adds a CSS style to the builder.
    /// </summary>
    /// <param name="property">The CSS property name.</param>
    /// <param name="value">The CSS property value.</param>
    /// <returns>The updated <see cref="CssStyleBuilder" /> instance.</returns>
    public CssStyleBuilder AddStyle(string property, Func<string, Task<string>> style)
    {
        Task.Run(async () =>
        {
            var finalString = "";
            if (!string.IsNullOrWhiteSpace(property) && !string.IsNullOrWhiteSpace(await style?.Invoke(finalString)!))
                _styles.Add($"{property}: {finalString};");
        });
        return this;
    }


    /// <summary>
    ///     Adds a CSS style to the builder.
    /// </summary>
    /// <param name="property">The CSS property name.</param>
    /// <param name="value">The CSS property value.</param>
    /// <returns>The updated <see cref="CssStyleBuilder" /> instance.</returns>
    public CssStyleBuilder AddStyle(string style, bool condition = true)
    {
        if (!string.IsNullOrWhiteSpace(style) && condition)
            _styles.Add($"{(style.EndsWith(";") ? style : $"{style};")}");

        return this;
    }

    /// <summary>
    ///     Adds a CSS style to the builder based on a condition.
    /// </summary>
    /// <param name="property">The CSS property name.</param>
    /// <param name="value">The CSS property value.</param>
    /// <param name="condition">A boolean indicating whether to add the style.</param>
    /// <returns>The updated <see cref="CssStyleBuilder" /> instance.</returns>
    public CssStyleBuilder AddStyle(string property, string value, bool condition)
    {
        if (condition && !string.IsNullOrWhiteSpace(property) && !string.IsNullOrWhiteSpace(value))
            _styles.Add($"{property}: {value};");

        return this;
    }

    /// <summary>
    ///     Builds the final CSS style string.
    /// </summary>
    /// <returns>A string containing all the CSS styles concatenated.</returns>
    public string Build(string? baseStyle = null)
    {
        return string.Concat(string.Join(" ", _styles), baseStyle != null ? $"{baseStyle}" : "");
    }
}