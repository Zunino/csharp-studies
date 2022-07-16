namespace DemoApi.Workers
{
    public class NameLogger : INameLogger
    {
        private static readonly string[] Names = new[]
        {
            "John", "Abigail", "Jack", "Dutch", "Uncle", "Marie", "Sadie", "Arthur"
        };

        private readonly ILogger<NameLogger> logger;

        public NameLogger(ILogger<NameLogger> logger)
        {
            this.logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                logger.LogInformation(Names[Random.Shared.Next(Names.Length)]);
                await Task.Delay(3000);
            }
        }
    }
}