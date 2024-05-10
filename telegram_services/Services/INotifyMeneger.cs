namespace telegram_services.Services;

public interface INotifyMeneger
{
    Task SendAsync(
        string userId,
        string message,
        CancellationToken cancellationToken = default);
}