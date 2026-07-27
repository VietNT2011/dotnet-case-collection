namespace DotnetCases.Validation;

public static class EmailAddressValidator
{
    public static bool IsPlausible(string? value)
    {
        if (string.IsNullOrWhiteSpace(value)) return false;
        var at = value.IndexOf('@');
        var lastDot = value.LastIndexOf('.');
        return at > 0 && lastDot > at + 1 && lastDot < value.Length - 1 && !value.Any(char.IsWhiteSpace);
    }
}
