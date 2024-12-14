using System.Reflection;

namespace BdziamUIExamples;

public static class EmbeddedResourceReader
{
    public static string? GetEmbeddedResource(string resourceName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var resourcePath = assembly.GetManifestResourceNames()
            .FirstOrDefault(r => r.EndsWith(resourceName, StringComparison.OrdinalIgnoreCase));

        if (resourcePath == null) return null;

        using var stream = assembly.GetManifestResourceStream(resourcePath);
        if (stream == null) return null;

        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}