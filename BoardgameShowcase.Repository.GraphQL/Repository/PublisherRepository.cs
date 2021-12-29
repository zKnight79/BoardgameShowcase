using BoardgameShowcase.Common;
using BoardgameShowcase.Common.Extensions;
using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Repository.GraphQL.Response;
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

        public async Task<IEnumerable<Publisher>> FindAllAsync()
        {
            Logger.LogMethodCall();

            PublishersResponse response = await _dataAccess.Query<PublishersResponse>(GQL.Publishers);

            return response.Publishers;
        }

        public async Task<Publisher?> FindByIdAsync(string publisherId)
        {
            Logger.LogMethodCall(publisherId);

            PublisherResponse response = await _dataAccess.Query<PublisherResponse>(GQL.Publisher, new { publisherId });

            return response.Publisher;
        }

        public async Task<string?> InsertAsync(Publisher publisher)
        {
            Logger.LogMethodCall(publisher);

            PublisherResponse response = await _dataAccess.Mutation<PublisherResponse>(GQL.PublisherCreate, publisher);

            return response.Publisher?.Id;
        }

        public async Task<bool> UpdateAsync(Publisher publisher)
        {
            Logger.LogMethodCall(publisher);

            PublisherResponse response = await _dataAccess.Mutation<PublisherResponse>(GQL.PublisherUpdate, publisher);

            return response.Publisher is not null;
        }

        public async Task<bool> DeleteByIdAsync(string publisherId)
        {
            Logger.LogMethodCall(publisherId);

            PublisherResponse response = await _dataAccess.Mutation<PublisherResponse>(GQL.PublisherDelete, new { publisherId });

            return response.Publisher is not null;
        }

        public async Task<IEnumerable<Publisher>> FindByNameAsync(string namePart)
        {
            Logger.LogMethodCall(namePart);

            PublishersResponse response = await _dataAccess.Query<PublishersResponse>(GQL.PublishersByName, new { namePart });

            return response.Publishers;
        }
    }
}
