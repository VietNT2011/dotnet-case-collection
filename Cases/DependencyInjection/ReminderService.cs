namespace DotnetCases.DependencyInjection;

public sealed class ReminderService(INotificationSender sender)
{
    public Task RemindAsync(string recipient, DateOnly reviewDate, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(recipient);
        var message = $"Your next review is scheduled for {reviewDate:yyyy-MM-dd}.";
        return sender.SendAsync(recipient, message, cancellationToken);
    }
}
