namespace DotnetCases.Testing;

public sealed class PasswordPolicy
{
    public IReadOnlyList<string> Validate(string password)
    {
        var errors = new List<string>();
        if (password.Length < 12) errors.Add("Use at least 12 characters.");
        if (!password.Any(char.IsUpper)) errors.Add("Add an uppercase letter.");
        if (!password.Any(char.IsDigit)) errors.Add("Add a number.");
        return errors;
    }
}
