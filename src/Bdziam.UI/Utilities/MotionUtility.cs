using System.Globalization;
using Bdziam.UI.Model.Enums;

namespace Bdziam.UI.Utilities;

public static class MotionUtility
{
    public static string ConstructTransition(Motion motion = Motion.EasingEmphasized, double durationSecs = 0.2,
        params string[] properties)
    {
        // Convert the enum value to a kebab-case string
        var motionVariantKebabCase = CaseUtility.PascalToKebab(motion.ToString());
        var propertiesList = new List<string>();
        if (properties.Length == 0)
            propertiesList.Add(
                $"all {durationSecs.ToString(CultureInfo.InvariantCulture)}s var(--md-sys-motion-{motionVariantKebabCase})");

        foreach (var property in properties)
            propertiesList.Add(
                $"{property} {durationSecs.ToString(CultureInfo.InvariantCulture)}s var(--md-sys-motion-{motionVariantKebabCase})");

        return string.Join(", ", propertiesList);
    }
    
    public static string ConstructTransition(params string[] properties)
    {
        // Convert the enum value to a kebab-case string
        var motionVariantKebabCase = CaseUtility.PascalToKebab(Motion.EasingEmphasized.ToString());
        var propertiesList = new List<string>();
        if (properties.Length == 0)
            propertiesList.Add(
                $"all 0.2s var(--md-sys-motion-{motionVariantKebabCase})");

        foreach (var property in properties)
            propertiesList.Add(
                $"{property} 0.2s var(--md-sys-motion-{motionVariantKebabCase})");

        return string.Join(", ", propertiesList);
    }
}