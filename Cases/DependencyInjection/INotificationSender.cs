namespace DotnetCases.DependencyInjection;

public interface INotificationSender
{
    Task SendAsync(string recipient, string message, CancellationToken cancellationToken);
}
