namespace Bdziam.UI.Theming;

public class ThemingConstants
{
    public const int SurfaceLevelsCount = 5;
    public const int LightSurfaceLevelMultiplier = 8;
    public const int DarkSurfaceLevelMultiplier = 10;
    public static readonly Dictionary<string, string> Motions = new()
    {
        ["easing-emphasized"] = "cubic-bezier(0.2, 0, 0, 1)",
        ["easing-emphasized-accelerate"] = "cubic-bezier(0.3, 0, 0.8, 0.15)",
        ["easing-emphasized-decelerate"] = "cubic-bezier(0.05, 0.7, 0.1, 1)",
        ["easing-legacy"] = "cubic-bezier(0.4, 0, 0.2, 1)",
        ["easing-legacy-accelerate"] = "cubic-bezier(0.4, 0, 1, 1)",
        ["easing-legacy-decelerate"] = "cubic-bezier(0, 0, 0.2, 1)",
        ["easing-linear"] = "cubic-bezier(0, 0, 1, 1)",
        ["easing-standard"] = "cubic-bezier(0.2, 0, 0, 1)",
        ["easing-standard-accelerate"] = "cubic-bezier(0.3, 0, 1, 1)",
        ["easing-standard-decelerate"] = "cubic-bezier(0, 0, 0, 1)"
    };

}