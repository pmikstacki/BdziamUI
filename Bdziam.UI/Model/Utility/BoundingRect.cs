namespace Bdziam.UI.Model.Utility;

public class BoundingRect
{
    public double Top { get; }
    public double Left { get; }
    public double Width { get; }
    public double Height { get; }
    public double Bottom { get; }
    public double Right { get; }

    public BoundingRect(double top, double left, double width, double height, double bottom, double right)
    {
        Top = top;
        Left = left;
        Width = width;
        Height = height;
        Bottom = bottom;
        Right = right;
    }
}
