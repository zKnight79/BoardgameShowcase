using BoardgameShowcase.Common;
using BoardgameShowcase.Model.Entity;
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

        public Task<IEnumerable<Illustrator>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Illustrator?> FindByIdAsync(string illustratorId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Illustrator>> FindByNameAsync(string namePart)
        {
            throw new NotImplementedException();
        }

        public Task<string?> InsertAsync(Illustrator illustrator)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Illustrator illustrator)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(string illustratorId)
        {
            throw new NotImplementedException();
        }
    }
}
