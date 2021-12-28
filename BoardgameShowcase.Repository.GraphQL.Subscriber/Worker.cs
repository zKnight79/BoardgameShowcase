using BoardgameShowcase.Repository.GraphQL.Subscription;

namespace BoardgameShowcase.Repository.GraphQL.Subscriber
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IAuthorSubscription _authorSubscription;

        private List<IDisposable> _subscriptions = new();

        public Worker(ILogger<Worker> logger, IAuthorSubscription authorSubscription)
        {
            _logger = logger;
            _authorSubscription = authorSubscription;
        }

        public override void Dispose()
        {
            while (_subscriptions.Any())
            {
                IDisposable subscription = _subscriptions.First();
                _subscriptions.Remove(subscription);
                subscription.Dispose();
            }
            
            base.Dispose();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Delay(1000, stoppingToken);

            _subscriptions.Add(SuscribeAuthorAdded());
            _subscriptions.Add(SuscribeAuthorModified());
            _subscriptions.Add(SuscribeAuthorRemoved());
        }

        private IDisposable SuscribeAuthorAdded()
        {
            return _authorSubscription.SubscribeAdded(author =>
            {
                _logger.LogInformation($"Author added : Id = {author.Id}, Name = {author.Name}");
            });
        }
        private IDisposable SuscribeAuthorModified()
        {
            return _authorSubscription.SubscribeModified(author =>
            {
                _logger.LogInformation($"Author modified : Id = {author.Id}, Name = {author.Name}");
            });
        }
        private IDisposable SuscribeAuthorRemoved()
        {
            return _authorSubscription.SubscribeRemoved(author =>
            {
                _logger.LogInformation($"Author removed : Id = {author.Id}, Name = {author.Name}");
            });
        }
    }
}