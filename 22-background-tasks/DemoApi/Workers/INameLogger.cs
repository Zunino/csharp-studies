namespace DemoApi.Workers
{
    public interface INameLogger
    {
        Task StartAsync(CancellationToken cancellationToken);
    }
}