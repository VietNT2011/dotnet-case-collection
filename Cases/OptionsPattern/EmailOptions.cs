using System.ComponentModel.DataAnnotations;

namespace DotnetCases.OptionsPattern;

public sealed class EmailOptions
{
    public const string SectionName = "Email";

    [Required]
    public string Sender { get; init; } = string.Empty;

    [Range(1, 10)]
    public int RetryCount { get; init; } = 3;
}
