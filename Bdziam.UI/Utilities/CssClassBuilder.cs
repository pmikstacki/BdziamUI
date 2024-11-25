namespace Bdziam.UI.Utilities;

public class CssClassBuilder
{
    private readonly List<string> _classes = new List<string>();

    /// <summary>
    /// Initializes a new instance of the <see cref="CssClassBuilder"/> class.
    /// </summary>
    /// <param name="initialClass">An optional initial CSS class.</param>
    public CssClassBuilder(string initialClass = null)
    {
        if (!string.IsNullOrWhiteSpace(initialClass))
        {
            _classes.Add(initialClass);
        }
    }

    /// <summary>
    /// Adds a CSS class to the builder.
    /// </summary>
    /// <param name="className">The CSS class to add.</param>
    /// <returns>The updated <see cref="CssClassBuilder"/> instance.</returns>
    public CssClassBuilder AddClass(string className)
    {
        if (!string.IsNullOrWhiteSpace(className))
        {
            _classes.Add(className);
        }
        return this;
    }

    /// <summary>
    /// Adds a CSS class to the builder based on a condition.
    /// </summary>
    /// <param name="className">The CSS class to add.</param>
    /// <param name="condition">A boolean indicating whether to add the class.</param>
    /// <returns>The updated <see cref="CssClassBuilder"/> instance.</returns>
    public CssClassBuilder AddClass(string className, bool condition)
    {
        if (condition && !string.IsNullOrWhiteSpace(className))
        {
            _classes.Add(className);
        }
        return this;
    }

    /// <summary>
    /// Builds the final CSS class string.
    /// </summary>
    /// <returns>A string containing all the CSS classes separated by spaces.</returns>
    public string Build()
    {
        return string.Join(" ", _classes);
    }
}
