using System.Drawing;

namespace Bdziam.UI.Utilities;

public static class ColorUtility
{
    public static uint ToArgb(Color color)
    {
        return (uint)((color.A << 24) | (color.R << 16) | (color.G << 8) | color.B);
    }

    /// <summary>
    /// Converts an ARGB integer to a Color.
    /// </summary>
    public static Color ColorFromArgb(uint argb)
    {
        byte a = (byte)((argb >> 24) & 0xFF);
        byte r = (byte)((argb >> 16) & 0xFF);
        byte g = (byte)((argb >> 8) & 0xFF);
        byte b = (byte)(argb & 0xFF);
        return Color.FromArgb(a, r, g, b);
    }
}