namespace DemoApi.Workers
{
    public class NameLoggerHostedService : IHostedService
    {
        private readonly INameLogger nameLogger;

        public NameLoggerHostedService(INameLogger nameLogger)
        {
            this.nameLogger = nameLogger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(() => nameLogger.StartAsync(cancellationToken));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}