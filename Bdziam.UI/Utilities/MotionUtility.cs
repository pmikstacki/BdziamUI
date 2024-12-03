using System.Globalization;
using Bdziam.UI.Model.Enums;

namespace Bdziam.UI.Utilities;

public static class MotionUtility
{
    public static string ConstructTransition(Motion motion, double durationSecs, params string[] properties)
    {
        // Convert the enum value to a kebab-case string
        string motionVariantKebabCase = CaseUtility.PascalToKebab(motion.ToString());
        var propertiesList = new List<string>();
        foreach (var property in properties)
        {
            propertiesList.Add($"{property} {durationSecs.ToString(CultureInfo.InvariantCulture)}s var(--md-sys-motion-{motionVariantKebabCase})");
        }

        return string.Join(", ", propertiesList);
    }
}