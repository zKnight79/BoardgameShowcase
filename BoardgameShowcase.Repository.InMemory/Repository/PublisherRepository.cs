using BoardgameShowcase.Common.Extensions;
using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Repository.Repository;
using Microsoft.Extensions.Logging;

namespace BoardgameShowcase.Repository.InMemory.Repository
{
    class PublisherRepository : GenericRepository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(ILogger<PublisherRepository> logger, IDataAccess<Publisher> dataAccess)
            : base(logger, dataAccess)
        {
        }

        public Task<IEnumerable<Publisher>> FindByNameAsync(string namePart)
        {
            Logger.LogMethodCall(namePart);

            IEnumerable<Publisher> publishers = DataAccess.QueryEntities(x => x.Name.Contains(namePart, StringComparison.InvariantCultureIgnoreCase));

            return Task.FromResult(publishers);
        }
    }
}
