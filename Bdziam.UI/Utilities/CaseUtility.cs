namespace Bdziam.UI.Utilities;

public class CaseUtility
{
    
    public static string PascalToKebab(ReadOnlySpan<char> pascalCase)
    {
        if (pascalCase.Length == 0) return string.Empty;

        Span<char> kebabCase = stackalloc char[pascalCase.Length + pascalCase.Length / 2];
        int kebabCaseIndex = 0;
        kebabCase[kebabCaseIndex++] = char.ToLower(pascalCase[0]);

        for (int i = 1; i < pascalCase.Length; i++)
        {
            char currentChar = pascalCase[i];

            if (char.IsUpper(currentChar))
            {
                kebabCase[kebabCaseIndex++] = '-';
                kebabCase[kebabCaseIndex++] = char.ToLower(currentChar);
            }
            else
            {
                kebabCase[kebabCaseIndex++] = currentChar;
            }
        }

        return new(kebabCase[..kebabCaseIndex]);
    }
}