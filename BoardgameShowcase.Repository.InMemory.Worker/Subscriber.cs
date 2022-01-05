using BoardgameShowcase.Model.Subscription;

namespace BoardgameShowcase.Repository.InMemory.Worker
{
    class Subscriber : BackgroundService
    {
        private readonly ILogger<Subscriber> _logger;
        private readonly IAuthorSubscription _authorSubscription;
        private readonly IIllustratorSubscription _illustratorSubscription;
        private readonly IPublisherSubscription _publisherSubscription;
        private readonly IBoardgameSubscription _boardgameSubscription;

        private readonly Stack<IDisposable> _subscriptions = new();

        public Subscriber(ILogger<Subscriber> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _authorSubscription = serviceProvider.GetRequiredService<IAuthorSubscription>();
            _illustratorSubscription = serviceProvider.GetRequiredService<IIllustratorSubscription>();
            _publisherSubscription = serviceProvider.GetRequiredService<IPublisherSubscription>();
            _boardgameSubscription = serviceProvider.GetRequiredService<IBoardgameSubscription>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Delay(1000, stoppingToken);

            _logger.LogInformation("Subscriber is launching subscriptions ...");

            _subscriptions.Push(_authorSubscription.SubscribeAdded(author =>
            {
                _logger.LogInformation($"Author added : Id = {author.Id}, Name = {author.Name}");
            }));
            _subscriptions.Push(_authorSubscription.SubscribeModified(author =>
            {
                _logger.LogInformation($"Author modified : Id = {author.Id}, Name = {author.Name}");
            }));
            _subscriptions.Push(_authorSubscription.SubscribeRemoved(author =>
            {
                _logger.LogInformation($"Author removed : Id = {author.Id}, Name = {author.Name}");
            }));

            _subscriptions.Push(_illustratorSubscription.SubscribeAdded(illustrator =>
            {
                _logger.LogInformation($"Illustrator added : Id = {illustrator.Id}, Name = {illustrator.Name}");
            }));
            _subscriptions.Push(_illustratorSubscription.SubscribeModified(illustrator =>
            {
                _logger.LogInformation($"Illustrator modified : Id = {illustrator.Id}, Name = {illustrator.Name}");
            }));
            _subscriptions.Push(_illustratorSubscription.SubscribeRemoved(illustrator =>
            {
                _logger.LogInformation($"Illustrator removed : Id = {illustrator.Id}, Name = {illustrator.Name}");
            }));

            _subscriptions.Push(_publisherSubscription.SubscribeAdded(publisher =>
            {
                _logger.LogInformation($"Publisher added : Id = {publisher.Id}, Name = {publisher.Name}");
            }));
            _subscriptions.Push(_publisherSubscription.SubscribeModified(publisher =>
            {
                _logger.LogInformation($"Publisher modified : Id = {publisher.Id}, Name = {publisher.Name}");
            }));
            _subscriptions.Push(_publisherSubscription.SubscribeRemoved(publisher =>
            {
                _logger.LogInformation($"Publisher removed : Id = {publisher.Id}, Name = {publisher.Name}");
            }));

            _subscriptions.Push(_boardgameSubscription.SubscribeAdded(boardgame =>
            {
                _logger.LogInformation($"Boardgame added : Id = {boardgame.Id}, Title = {boardgame.Title}");
            }));
            _subscriptions.Push(_boardgameSubscription.SubscribeModified(boardgame =>
            {
                _logger.LogInformation($"Boardgame modified : Id = {boardgame.Id}, Title = {boardgame.Title}");
            }));
            _subscriptions.Push(_boardgameSubscription.SubscribeRemoved(boardgame =>
            {
                _logger.LogInformation($"Boardgame removed : Id = {boardgame.Id}, Title = {boardgame.Title}");
            }));
        }

        public override void Dispose()
        {
            while (_subscriptions.Any())
            {
                _subscriptions.Pop().Dispose();
            }

            base.Dispose();
        }
    }
}
