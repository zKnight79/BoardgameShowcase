namespace BoardgameShowcase.Repository.GraphQL.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IHostApplicationLifetime _hostApplicationLifetime;
        private readonly IEnumerable<IJob> _jobs;

        public Worker(ILogger<Worker> logger, IHostApplicationLifetime hostApplicationLifetime, IEnumerable<IJob> jobs)
        {
            _logger = logger;
            _hostApplicationLifetime = hostApplicationLifetime;
            _jobs = jobs;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Delay(1000, stoppingToken);

            foreach (IJob job in _jobs)
            {
                await job.DoJob();
            }

            _hostApplicationLifetime.StopApplication();
        }
    }
}