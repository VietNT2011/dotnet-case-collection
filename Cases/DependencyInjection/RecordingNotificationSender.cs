namespace DotnetCases.DependencyInjection;

public sealed class RecordingNotificationSender : INotificationSender
{
    public List<(string Recipient, string Message)> Sent { get; } = [];

    public Task SendAsync(string recipient, string message, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        Sent.Add((recipient, message));
        return Task.CompletedTask;
    }
}
