namespace Bdziam.UI.Interop;

/// <summary>
///     Represents a rectangle with position and size in the DOM.
/// </summary>
public class DOMRect
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="DOMRect" /> class.
    /// </summary>
    public DOMRect()
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="DOMRect" /> class with specified properties.
    /// </summary>
    public DOMRect(double x, double y, double width, double height, double right, double bottom)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
        Right = right;
        Bottom = bottom;
    }

    /// <summary>
    ///     The x-coordinate of the rectangle's origin (left side).
    /// </summary>
    public double X { get; set; }

    /// <summary>
    ///     The y-coordinate of the rectangle's origin (top side).
    /// </summary>
    public double Y { get; set; }

    /// <summary>
    ///     The width of the rectangle.
    /// </summary>
    public double Width { get; set; }

    /// <summary>
    ///     The height of the rectangle.
    /// </summary>
    public double Height { get; set; }

    /// <summary>
    ///     The x-coordinate of the rectangle's right edge (X + Width).
    /// </summary>
    public double Right { get; set; }

    /// <summary>
    ///     The y-coordinate of the rectangle's bottom edge (Y + Height).
    /// </summary>
    public double Bottom { get; set; }

    /// <summary>
    ///     Returns a string representation of the DOMRect instance.
    /// </summary>
    public override string ToString()
    {
        return $"DOMRect (X: {X}, Y: {Y}, Width: {Width}, Height: {Height}, Right: {Right}, Bottom: {Bottom})";
    }
}