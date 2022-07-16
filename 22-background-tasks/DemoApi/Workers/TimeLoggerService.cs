namespace DemoApi.Workers
{
    public class TimeLoggerService : BackgroundService
    {
        private readonly ILogger<TimeLoggerService> logger;

        public TimeLoggerService(ILogger<TimeLoggerService> logger)
        {
            this.logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                logger.LogInformation($"It is now {DateTime.Now}");
                await Task.Delay(8000);
            }
        }
    }
}