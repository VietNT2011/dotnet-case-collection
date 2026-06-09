namespace DotnetCases.ResultPattern;

public sealed class ProfileService
{
    public Result<string> NormalizeDisplayName(string? value)
    {
        var name = value?.Trim();
        if (string.IsNullOrEmpty(name)) return new Result<string>.Failure("name.required", "Display name is required.");
        if (name.Length > 40) return new Result<string>.Failure("name.too_long", "Display name is limited to 40 characters.");
        return new Result<string>.Success(name);
    }
}
