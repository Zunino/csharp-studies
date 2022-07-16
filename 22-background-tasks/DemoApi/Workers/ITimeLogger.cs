namespace DemoApi.Workers
{
    public interface ITimeLogger
    {
        Task StartAsync(CancellationToken cancellationToken);
    }
}