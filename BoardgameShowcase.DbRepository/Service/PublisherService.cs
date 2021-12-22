using BoardgameShowcase.Common.Extensions;
using BoardgameShowcase.DbRepository.Repository;
using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Service;
using Microsoft.Extensions.Logging;

namespace BoardgameShowcase.DbRepository.Service
{
    class PublisherService : GenericService<Publisher>, IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublisherService(ILogger<PublisherService> logger, IPublisherRepository publisherRepository)
            : base(logger, publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public Task<IEnumerable<Publisher>> GetByNameAsync(string namePart)
        {
            Logger.LogMethodCall(namePart);

            return _publisherRepository.FindByNameAsync(namePart);
        }
    }
}
