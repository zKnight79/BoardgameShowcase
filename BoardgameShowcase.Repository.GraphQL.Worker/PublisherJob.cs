using BoardgameShowcase.Common;
using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Service;

namespace BoardgameShowcase.Repository.GraphQL.Worker
{
    class PublisherJob : Loggable<PublisherJob>, IJob
    {
        private readonly IPublisherService _publisherService;

        public PublisherJob(ILogger<PublisherJob> logger, IPublisherService publisherService)
            : base(logger)
        {
            _publisherService = publisherService;
        }

        public async Task DoJob()
        {
            await GetAllPublishers();
            await GetOnePublisher("ebaa178eabf642a59f31a5e27a5be566");
            await GetOnePublisher("azertyuiopqsdfghjklmwxcvbn123456");
            await GetPublishersByName("on");
            await GetPublishersByName("s ");
            await AddPublisher("Blue Orange");
            await UpdatePublisher("77dc41e600a241e1850fe71f2da9d0a6", "Yellow");
            await DeletePublisher("f80820ac1f0c4017a0c1fba2b3d263b5");
        }

        private async Task GetAllPublishers()
        {
            IEnumerable<Publisher> publishers = await _publisherService.GetAllAsync();
            Logger.LogInformation($"{publishers.Count()} publisher(s) found");
            foreach (Publisher publisher in publishers)
            {
                Logger.LogInformation($"Publisher : Id = {publisher.Id}, Name = {publisher.Name}");
            }
        }
        private async Task GetOnePublisher(string publisherId)
        {
            Logger.LogInformation($"Try getting publisher with id = {publisherId}");
            Publisher? publisher = await _publisherService.GetByIdAsync(publisherId);
            if (publisher is null)
            {
                Logger.LogInformation("Publisher not found");
            }
            else
            {
                Logger.LogInformation($"Publisher found : Id = {publisher.Id}, Name = {publisher.Name}");
            }
        }
        private async Task GetPublishersByName(string namePart)
        {
            Logger.LogInformation($"Try getting publisher with name like {namePart}");
            IEnumerable<Publisher> publishers = await _publisherService.GetByNameAsync(namePart);
            Logger.LogInformation($"{publishers.Count()} publisher(s) found");
            foreach (Publisher publisher in publishers)
            {
                Logger.LogInformation($"Publisher : Id = {publisher.Id}, Name = {publisher.Name}");
            }
        }
        private async Task AddPublisher(string name)
        {
            Logger.LogInformation($"Try adding Publisher with name = {name}");
            Publisher publisher = new() { Name = name };
            Publisher? added = await _publisherService.SaveAsync(publisher);
            if (added is null)
            {
                Logger.LogInformation("Publisher not created");
            }
            else
            {
                Logger.LogInformation($"Publisher created : Id = {added.Id}, Name = {added.Name}");
            }
        }
        private async Task UpdatePublisher(string id, string newName)
        {
            Logger.LogInformation($"Try updating Publisher with id = {id} to new name = {newName}");
            Publisher publisher = new() { Id = id, Name = newName };
            Publisher? updated = await _publisherService.SaveAsync(publisher);
            if (updated is null)
            {
                Logger.LogInformation("Publisher not updated");
            }
            else
            {
                Logger.LogInformation($"Publisher updated : Id = {updated.Id}, Name = {updated.Name}");
            }
        }
        private async Task DeletePublisher(string id)
        {
            Logger.LogInformation($"Try deleting Publisher with id = {id}");
            Publisher? removed = await _publisherService.RemoveByIdAsync(id);
            if (removed is null)
            {
                Logger.LogInformation("Publisher not removed");
            }
            else
            {
                Logger.LogInformation($"Publisher removed : Id = {removed.Id}, Name = {removed.Name}");
            }
        }
    }
}
