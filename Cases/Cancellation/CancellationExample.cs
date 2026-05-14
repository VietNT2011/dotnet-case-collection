namespace DotnetCases.Cancellation;

public static class CancellationExample
{
    public static async Task<int> CountCompletedAsync(IEnumerable<Func<CancellationToken, Task>> jobs, CancellationToken cancellationToken)
    {
        var completed = 0;
        foreach (var job in jobs)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await job(cancellationToken);
            completed++;
        }
        return completed;
    }
}
