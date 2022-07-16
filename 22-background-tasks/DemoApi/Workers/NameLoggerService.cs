namespace DemoApi.Workers
{
    public class NameLoggerService : IHostedService
    {
        private static readonly string[] Names = new[]
        {
            "John", "Abigail", "Jack", "Dutch", "Uncle", "Marie", "Sadie", "Arthur"
        };

        private readonly ILogger<NameLoggerService> logger;

        public NameLoggerService(ILogger<NameLoggerService> logger)
        {
            this.logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(async () =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    logger.LogInformation(Names[Random.Shared.Next(Names.Length)]);
                    await Task.Delay(3000);
                }
            });
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}