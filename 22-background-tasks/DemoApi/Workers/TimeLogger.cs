namespace DemoApi.Workers
{
    public class TimeLogger : ITimeLogger
    {
        private readonly ILogger<TimeLogger> logger;

        public TimeLogger(ILogger<TimeLogger> logger)
        {
            this.logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                logger.LogInformation($"It is now {DateTime.Now}");
                await Task.Delay(8000);
            }
        }
    }
}