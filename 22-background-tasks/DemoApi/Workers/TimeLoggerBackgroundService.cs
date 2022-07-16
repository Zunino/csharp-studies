namespace DemoApi.Workers
{
    public class TimeLoggerBackgroundService : BackgroundService
    {
        private readonly ITimeLogger timeLogger;

        public TimeLoggerBackgroundService(ITimeLogger timeLogger)
        {
            this.timeLogger = timeLogger;
        }

        protected async override Task ExecuteAsync(CancellationToken cancellationToken)
        {
            await timeLogger.StartAsync(cancellationToken);
            await Task.CompletedTask;
        }
    }
}