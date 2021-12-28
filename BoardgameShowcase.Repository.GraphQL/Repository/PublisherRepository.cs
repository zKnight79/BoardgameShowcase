using BoardgameShowcase.Common;
using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Repository.Repository;
using Microsoft.Extensions.Logging;

namespace BoardgameShowcase.Repository.GraphQL.Repository
{
    class PublisherRepository : Loggable<PublisherRepository>, IPublisherRepository
    {
        private readonly IDataAccess _dataAccess;

        public PublisherRepository(ILogger<PublisherRepository> logger, IDataAccess dataAccess)
            : base(logger)
        {
            _dataAccess = dataAccess;
        }

        public Task<IEnumerable<Publisher>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Publisher?> FindByIdAsync(string entityId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Publisher>> FindByNameAsync(string namePart)
        {
            throw new NotImplementedException();
        }

        public Task<string?> InsertAsync(Publisher entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Publisher entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(string entityId)
        {
            throw new NotImplementedException();
        }
    }
}
