namespace DotnetCases.ResultPattern;

public abstract record Result<T>
{
    public sealed record Success(T Value) : Result<T>;
    public sealed record Failure(string Code, string Message) : Result<T>;
}
