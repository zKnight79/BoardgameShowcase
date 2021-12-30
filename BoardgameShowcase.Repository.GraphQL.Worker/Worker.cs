namespace BoardgameShowcase.Repository.GraphQL.Worker
{
    class Worker : BackgroundService
    {
        private readonly IHostApplicationLifetime _hostApplicationLifetime;
        private readonly IEnumerable<IJob> _jobs;

        public Worker(IHostApplicationLifetime hostApplicationLifetime, IEnumerable<IJob> jobs)
        {
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