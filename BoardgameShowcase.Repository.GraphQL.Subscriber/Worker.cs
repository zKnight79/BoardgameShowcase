using BoardgameShowcase.Repository.GraphQL.Subscription;

namespace BoardgameShowcase.Repository.GraphQL.Subscriber
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IAuthorSubscription _authorSubscription;
        private readonly IIllustratorSubscription _illustratorSubscription;
        private readonly IPublisherSubscription _publisherSubscription;

        private List<IDisposable> _subscriptions = new();

        public Worker(
            ILogger<Worker> logger,
            IAuthorSubscription authorSubscription,
            IIllustratorSubscription illustratorSubscription,
            IPublisherSubscription publisherSubscription
        )
        {
            _logger = logger;
            _authorSubscription = authorSubscription;
            _illustratorSubscription = illustratorSubscription;
            _publisherSubscription = publisherSubscription;
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

            _subscriptions.Add(SuscribeIllustratorAdded());
            _subscriptions.Add(SuscribeIllustratorModified());
            _subscriptions.Add(SuscribeIllustratorRemoved());

            _subscriptions.Add(SuscribePublisherAdded());
            _subscriptions.Add(SuscribePublisherModified());
            _subscriptions.Add(SuscribePublisherRemoved());
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

        private IDisposable SuscribeIllustratorAdded()
        {
            return _illustratorSubscription.SubscribeAdded(illustrator =>
            {
                _logger.LogInformation($"Illustrator added : Id = {illustrator.Id}, Name = {illustrator.Name}");
            });
        }
        private IDisposable SuscribeIllustratorModified()
        {
            return _illustratorSubscription.SubscribeModified(illustrator =>
            {
                _logger.LogInformation($"Illustrator modified : Id = {illustrator.Id}, Name = {illustrator.Name}");
            });
        }
        private IDisposable SuscribeIllustratorRemoved()
        {
            return _illustratorSubscription.SubscribeRemoved(illustrator =>
            {
                _logger.LogInformation($"Illustrator removed : Id = {illustrator.Id}, Name = {illustrator.Name}");
            });
        }

        private IDisposable SuscribePublisherAdded()
        {
            return _publisherSubscription.SubscribeAdded(publisher =>
            {
                _logger.LogInformation($"Publisher added : Id = {publisher.Id}, Name = {publisher.Name}");
            });
        }
        private IDisposable SuscribePublisherModified()
        {
            return _publisherSubscription.SubscribeModified(publisher =>
            {
                _logger.LogInformation($"Publisher modified : Id = {publisher.Id}, Name = {publisher.Name}");
            });
        }
        private IDisposable SuscribePublisherRemoved()
        {
            return _publisherSubscription.SubscribeRemoved(publisher =>
            {
                _logger.LogInformation($"Publisher removed : Id = {publisher.Id}, Name = {publisher.Name}");
            });
        }
    }
}