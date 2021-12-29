using BoardgameShowcase.Common;
using BoardgameShowcase.Common.Extensions;
using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Repository.GraphQL.Response;
using BoardgameShowcase.Repository.Repository;
using Microsoft.Extensions.Logging;

namespace BoardgameShowcase.Repository.GraphQL.Repository
{
    class IllustratorRepository : Loggable<IllustratorRepository>, IIllustratorRepository
    {
        private readonly IDataAccess _dataAccess;

        public IllustratorRepository(ILogger<IllustratorRepository> logger, IDataAccess dataAccess)
            : base(logger)
        {
            _dataAccess = dataAccess;
        }

        public async Task<IEnumerable<Illustrator>> FindAllAsync()
        {
            Logger.LogMethodCall();

            IllustratorsResponse response = await _dataAccess.Query<IllustratorsResponse>(GQL.Illustrators);

            return response.Illustrators;
        }

        public async Task<Illustrator?> FindByIdAsync(string illustratorId)
        {
            Logger.LogMethodCall(illustratorId);

            IllustratorResponse response = await _dataAccess.Query<IllustratorResponse>(GQL.Illustrator, new { illustratorId });

            return response.Illustrator;
        }

        public async Task<string?> InsertAsync(Illustrator illustrator)
        {
            Logger.LogMethodCall(illustrator);

            IllustratorResponse response = await _dataAccess.Mutation<IllustratorResponse>(GQL.IllustratorCreate, illustrator);

            return response.Illustrator?.Id;
        }

        public async Task<bool> UpdateAsync(Illustrator illustrator)
        {
            Logger.LogMethodCall(illustrator);

            IllustratorResponse response = await _dataAccess.Mutation<IllustratorResponse>(GQL.IllustratorUpdate, illustrator);

            return response.Illustrator is not null;
        }

        public async Task<bool> DeleteByIdAsync(string illustratorId)
        {
            Logger.LogMethodCall(illustratorId);

            IllustratorResponse response = await _dataAccess.Mutation<IllustratorResponse>(GQL.IllustratorDelete, new { illustratorId });

            return response.Illustrator is not null;
        }

        public async Task<IEnumerable<Illustrator>> FindByNameAsync(string namePart)
        {
            Logger.LogMethodCall(namePart);

            IllustratorsResponse response = await _dataAccess.Query<IllustratorsResponse>(GQL.IllustratorsByName, new { namePart });

            return response.Illustrators;
        }
    }
}
